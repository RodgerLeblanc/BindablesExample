using System;
using System.Windows.Threading;

namespace BindablesExample
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            UpdateSomeProperty();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += (s, e) => UpdateSomeProperty();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        public string SomeProperty { get; set; }

        private void UpdateSomeProperty()
        {
            SomeProperty = DateTime.Now.ToLongTimeString();
        }
    }
}