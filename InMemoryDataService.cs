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
    public class InMemoryDataService : IDataService
    {
        public ObservableCollection<Project> 
            {}













        public ObservableCollection<Developer> LoadDevelopers()
        {
            throw new NotImplementedException(); // ezt át kell írni 
        }

        public ObservableCollection<Project> LoadProjects()
        {
            throw new NotImplementedException(); // ezt át kell írni 
        }

        public void SaveDevelopers(ObservableCollection<Developer> developers)
        {
            throw new NotImplementedException(); // ezt át kell írni 
        }

        public void SaveProjects(ObservableCollection<Project> projects)
        {
            throw new NotImplementedException(); // ezt át kell írni 
        }
    }
}
