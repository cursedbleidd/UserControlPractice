using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using System.Windows.Threading;

namespace LabControls
{
    /// <summary>
    /// Логика взаимодействия для DigitalClock.xaml
    /// </summary>
    public partial class DigitalClock : UserControl
    {
        private DispatcherTimer tmr;
        private Brush back = new SolidColorBrush(Colors.Black);
        private Brush fore = new SolidColorBrush(Colors.Green);
        public Brush Fore
        {
            get { return fore; }
            set
            {
                fore = value;
                ColorUpdate();
            }
        }
        public Brush Back
        {
            get { return back; }
            set
            { 
                back = value;
                ColorUpdate();
            }
        }
        public DigitalClock()
        {
            InitializeComponent();
            Unloaded += Unload;
            tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromMilliseconds(100);
            tmr.Tick += Timer_Tick;
            tmr.Start();
            ColorUpdate();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            SetTime(DateTime.Now);
        }
        private void Unload(object sender, RoutedEventArgs e)
        {
            // Остановка таймера при закрытии элемента
            tmr.Stop();
        }
        private void ColorUpdate()
        {
            hour1.Brush = fore;
            hour2.Brush = fore;
            minute1.Brush = fore;
            minute2.Brush = fore;
            second1.Brush = fore;
            second2.Brush = fore;
            mgrid.Background = back;
        }
        private void SetTime(DateTime time)
        {
            hour1.Value = time.Hour / 10;
            hour2.Value = time.Hour % 10;
            minute1.Value = time.Minute / 10;
            minute2.Value = time.Minute % 10;
            second1.Value = time.Second / 10;
            second2.Value = time.Second % 10;
        }
    }
}
