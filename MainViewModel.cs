using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LCNXY1_ITCompanyManager
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IDataService _dataService;

        public ObservableCollection<Developer> Developers { get; }

        [ObservableProperty]
        private Developer selectedDeveloper;

        [ObservableProperty]
        private int totalCollectedClosedTickets;

        public MainViewModel() : this(new InMemoryDataService()) { }

        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Developers = _dataService.LoadDevelopers();
            TotalCollectedClosedTickets = 0;
        }

        [RelayCommand]
        private async Task AssignTicketAsync()
        {
            if (SelectedDeveloper == null)
            {
                MessageBox.Show("Válassz ki egy fejlesztőt!");
                return;
            }

            if (SelectedDeveloper.HasPendingTicket)
            {
                MessageBox.Show("Ennek a fejlesztőnek már van folyamatban lévő ticketje.");
                return;
            }

            // jelöljük hogy folyamatban van
            SelectedDeveloper.HasPendingTicket = true;

            // generáljunk véletlen késleltetést és véletlen lezárandó ticket számot
            int delayMs = Random.Shared.Next(3000, 5001); // 3-5s
            int closed = Random.Shared.Next(1, 4); // 1-3 ticket lezárása

            // súlyosság beállítása demonstrációként
            var severities = new[] { "Low", "Medium", "High" };
            SelectedDeveloper.CurrentTicketSeverity = severities[Random.Shared.Next(severities.Length)];

            await Task.Delay(delayMs);

            // frissítjük a fejlesztő napi lezárt ticket számait
            SelectedDeveloper.DailyClosedTickets += closed;
            SelectedDeveloper.HasPendingTicket = false;
            SelectedDeveloper.CurrentTicketSeverity = "—";
        }

        [RelayCommand]
        private void CollectDailyReports()
        {
            int sum = 0;
            foreach (var dev in Developers)
            {
                sum += dev.DailyClosedTickets;
                dev.DailyClosedTickets = 0;
                dev.HasPendingTicket = false;
                dev.CurrentTicketSeverity = "—";
            }

            TotalCollectedClosedTickets += sum;
        }

        [RelayCommand]
        private void NewDeveloper()
        {
            var dev = new Developer("Új Fejlesztő", "Role", 1);
            Developers.Add(dev);
            SelectedDeveloper = dev;
        }

        [RelayCommand]
        private void DeleteDeveloper()
        {
            if (SelectedDeveloper == null)
            {
                MessageBox.Show("Válassz ki egy fejlesztőt a törléshez!");
                return;
            }

            if (MessageBox.Show($"Törölje a fejlesztőt: {SelectedDeveloper.Name}?", "Megerősítés", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Developers.Remove(SelectedDeveloper);
                SelectedDeveloper = null;
            }
        }

        [RelayCommand]
        private void EditDeveloper()
        {
            if (SelectedDeveloper == null)
            {
                MessageBox.Show("Válassz ki egy fejlesztőt!");
                return;
            }

            var window = new EditDeveloperWindow(SelectedDeveloper);
            // Feliratkozás a routed eventre (opcionális) — a MainWindow kezeli, de itt megmutatjuk az opciót
            window.AddHandler(MainWindow.DeveloperUpdatedEvent, new RoutedEventHandler(OnDeveloperUpdated));
            window.ShowDialog();
        }

        private void OnDeveloperUpdated(object? sender, RoutedEventArgs e)
        {
            // Itt lehet audit, naplózás, további logika. Binding miatt maga az objektum már frissül.
        }
    }
}
}
