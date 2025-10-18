using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LCNXY1_ITCompanyManager
{
    public partial class Developer : ObservableObject
    {
        [ObservableProperty] private string name;
        [ObservableProperty] private string role;
        [ObservableProperty] private int experienceYears;

        public Developer(string name, string role, int experienceYears)
        {
            Name = name;
            Role = role;
            ExperienceYears = experienceYears;

        }

        public override string ToString() => $"{Name}({Role})";
            
    }

    
    
}
