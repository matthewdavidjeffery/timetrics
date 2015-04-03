using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetrics.ViewModels
{
    public class AllTimerProjectsViewModel : WorkspaceViewModel
    {

        ObservableCollection<TimerProjectViewModel> AllTimerProjects
        {
            get;
            set;
        }

        public AllTimerProjectsViewModel()
        {
            
        }

    }
}
