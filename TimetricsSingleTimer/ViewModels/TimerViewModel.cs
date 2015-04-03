using MVVMBase.Commanding;
using MVVMBase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimetricsData;

namespace TimetricsSingleTimer.ViewModels
{
    public class TimerViewModel : ViewModelBase
    {
        #region Properties

        private TimerTask _timerTask;

        public TimerTask TTask
        {
            get { return _timerTask; }
            set
            {
                _timerTask = value;
                OnPropertyChanged("TTask");
            }
        }

        public TimeSpan TotalTime
        {
            get
            {
                if (TTask.StartTime.HasValue && TTask.EndTime.HasValue)
                {
                    return TTask.EndTime.Value.Subtract(TTask.StartTime.Value);
                } else
                {
                    return new TimeSpan(0);
                }
            }
            private set { }
        }

        public String TotalTimeAsString
        {
            get
            {
                return TotalTime.ToString(@"mm\:ss");
            }
            private set { }
        }


        public bool IsTotalTimeAvailable
        {
            get
            {
                return (TTask.StartTime.HasValue && TTask.EndTime.HasValue);
            }

            private set { }
        }

        private bool _CanStart;

        public bool CanStart
        {
            get { return _CanStart; }
            set { _CanStart = value; OnPropertyChanged("CanStart"); }
        }

        private bool _CanStop;

        public bool CanStop
        {
            get { return _CanStop; }
            set { _CanStop = value; OnPropertyChanged("CanStop"); }
        }


        #endregion

        #region Constructors
        public TimerViewModel()
        {
            TTask = new TimerTask();
            this.CanStart = true;
            this.CanStop = false;
        }
        #endregion

        #region Commands

        private ICommand _StartCommand;

        public ICommand StartCommand
        {
            get
            {
                if (_StartCommand == null)
                {
                    _StartCommand = new RelayCommand((param) => this.StartTask(), (param) => this.CanStart);
                }
                return _StartCommand;
            }
            set {  }
        }

        private ICommand _StopCommand;

        public ICommand StopCommand
        {
            get {
                if (_StopCommand == null)
                {
                    _StopCommand = new RelayCommand((param) => this.StopTask(), (param) => this.CanStop);
                }
                return _StopCommand;
            }
            private set { }
        }

        private ICommand _ResetCommand;

        public ICommand ResetCommand
        {
            get
            {
                if (_ResetCommand == null)
                {
                    _ResetCommand = new RelayCommand((param) => ResetTime(), null);
                }
                return _ResetCommand;
            }
            private set {  }
        }


        #endregion

        #region Methods

        public void StartTask()
        {
            _timerTask.StartTime = DateTime.Now;
            OnPropertyChanged("TotalTimeAsString");
            _timerTask.EndTime = null;
            this.CanStart = false;
            this.CanStop = true;
        }

        public void StopTask()
        {
            _timerTask.EndTime = DateTime.Now;
            OnPropertyChanged("TotalTimeAsString");
            this.CanStop = false;
            this.CanStart = true;
        }

        public void UpdateTime()
        {
            TTask.EndTime = DateTime.Now;
            OnPropertyChanged("TotalTimeAsString");
        }

        public void ResetTime()
        {
            TTask.StartTime = null;
            TTask.EndTime = null;
            CanStop = false;
            CanStart = true;
            OnPropertyChanged("TotalTimeAsString");
        }

        public void ToggleTimer()
        {
            if (this.CanStop)
            {
                StopTask();
            } else
            {
                StartTask();
            }
        }
        #endregion

    }
}
