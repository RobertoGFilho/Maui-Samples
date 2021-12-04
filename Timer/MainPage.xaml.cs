using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace Timer
{
    public partial class MainPage : ContentPage
    {
        private TimeOnly time = new();
        private bool isRunning;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnStartStop(object sender, EventArgs e)
        {
            isRunning = !isRunning;
            startStopButton.Source = isRunning ? "pause" : "play";

            while (isRunning)
            {
                time = time.Add(TimeSpan.FromSeconds(1));
                SetTime();
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        private void OnReset(object sender, EventArgs e)
        {
            time = new TimeOnly();
            SetTime();
        }

        private void SetTime()
        {
            timeLabel.Text = $"{time.Minute}:{time.Second:000}";
        }
    }
}
