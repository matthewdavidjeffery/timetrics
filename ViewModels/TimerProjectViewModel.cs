using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetricsData;

namespace Timetrics.ViewModels
{
    class TimerProjectViewModel : ViewModelBase
    {

        #region Properties

        private TimerProject _timerProject;

        public TimerProject timerProject
        {
            get { return _timerProject; }
            set { _timerProject = value; }
        }

        #endregion

        #region Constructors
        public TimerProjectViewModel()
        {
            //Nothing here...
        }
        #endregion


    }
}
