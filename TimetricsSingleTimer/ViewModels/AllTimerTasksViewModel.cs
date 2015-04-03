using MVVMBase.Commanding;
using MVVMBase.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimetricsData;

namespace TimetricsSingleTimer.ViewModels
{
    public class AllTimerTasksViewModel : ViewModelBase
    {

        private bool _CanLoad;

        public bool CanLoad
        {
            get { return _CanLoad; }
            set { _CanLoad = value; }
        }


        public ObservableCollection<TimerTask> TimerTasks { get; set; }

        public AllTimerTasksViewModel()
        {
            TimerTasks = new ObservableCollection<TimerTask>();
        }


        private ICommand _LoadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new RelayCommand((param) => this.LoadTimerTasks(), (param) => this.CanLoad);
                }
                return LoadCommand;
            }
            set { LoadCommand = value; }
        }


        public void LoadTimerTasks()
        {

            TimetricsDataClassesDataContext context = new TimetricsDataClassesDataContext();

            TimerTasks.Clear();

            var tasks = (from t in context.TimerTasks select t);


            foreach (var task in tasks)
            {
                TimerTasks.Add(task);   
            };

        }

    }
}
