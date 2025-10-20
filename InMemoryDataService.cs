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
        public ObservableCollection<Project> LoadProjects()
            {
            
var p1 =new Project()
p1.Tasks.Add( new TaskItem(,6)
p1.Tasks.Add( new TaskItem(,8)

         var p2 =new Project()
p2.Tasks.Add( new TaskItem(,4)
p2.Tasks.Add( new TaskItem(,5)   
            }













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

