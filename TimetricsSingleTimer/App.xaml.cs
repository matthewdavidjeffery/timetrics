using ManagedWinapi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Threading;
using TimetricsSingleTimer.ViewModels;

namespace TimetricsSingleTimer
{


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        DispatcherTimer timer;
        TimerViewModel viewmodel;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var ghotkey = new Hotkey();

            ghotkey.KeyCode = Keys.Q;
            ghotkey.Shift = true;
            ghotkey.Alt = true;
            ghotkey.Ctrl = true;
            ghotkey.HotkeyPressed += this.HandleHotkeyPress;
            ghotkey.Enabled = true;

            MainWindow window = new MainWindow();

            viewmodel = new TimerViewModel();

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);

            timer.Tick += new EventHandler(DispatchTick);

            viewmodel.PropertyChanged += HandleTimerStop;
            window.DataContext = viewmodel;

            window.Show();

            

        }

        //Tick handler
        public void DispatchTick(object sender, EventArgs e)
        {
            viewmodel.UpdateTime();
        }

        public void HandleTimerStop(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CanStop")
            {
                if (viewmodel.CanStop)
                {
                    timer.Start();
                }
                else
                {
                    timer.Stop();
                }
            }
        }

        public void HandleHotkeyPress(object sender, EventArgs e)
        {
            viewmodel.ToggleTimer();
        }
    }
}
