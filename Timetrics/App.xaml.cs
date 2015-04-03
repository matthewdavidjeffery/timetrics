using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Timetrics.ViewModels;

namespace Timetrics
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region Properties

        private AllTimerProjectsViewModel _allTimerProjects;

        public AllTimerProjectsViewModel allTimerProjects
        {
            get { return _allTimerProjects; }
            set { _allTimerProjects = value; }
        }

        #endregion

        public App() : base()
        {            
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            MainWindow window = new MainWindow();

            _allTimerProjects = new AllTimerProjectsViewModel();

            _allTimerProjects.RequestClose += delegate { window.Close(); };

            window.DataContext = _allTimerProjects;

            window.Show();

        }

    }
}
