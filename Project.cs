using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace LCNXY1_ITCompanyManager
{
    public partial class Project: ObservableObject
    {
        [ObservableProperty] private string _projectName;
        [ObservableProperty] private string description;
        public ObservableCollection<TaskItem> Tasks { get; } = new();

        public Project(string _projectName, string description = "") 
        {
         ProjectName = _projectName;
            Description = description;
        
        }

        public override string ToString() =>  ProjectName;

    }
}
