using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace SpeedRClock
{
    public partial class MainWindow : Window
    {
        private Stopwatch stopwatch;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            stopwatch = new Stopwatch();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = stopwatch.Elapsed;

            TimeDisplay.Text = string.Format("{0:00}:{1:00}:{2:00}:{3:00}.{4:000}",
                ts.Days,
                ts.Hours,
                ts.Minutes,
                ts.Seconds,
                ts.Milliseconds);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Start();
            timer.Start();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            timer.Stop();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            timer.Stop();
            TimeDisplay.Text = "00:00:00:00.000";
        }
    }
}