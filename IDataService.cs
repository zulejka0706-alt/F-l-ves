using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace LCNXY1_ITCompanyManager
{
   public interface IDataService
    {
        ObservableCollection<Project> LoadProjects();
        ObservableCollection<Developer> LoadDevelopers();

        void SaveProjects(ObservableCollection<Project> projects);
        void SaveDevelopers (ObservableCollection<Developer> developers);

    }
}
