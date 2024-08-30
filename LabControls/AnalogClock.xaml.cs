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
using System.Windows.Threading;

namespace LabControls
{
    /// <summary>
    /// Логика взаимодействия для AnalogClock.xaml
    /// </summary>
    public partial class AnalogClock : UserControl
    {
        private DispatcherTimer tmr;
        private Brush stroke;
        public Brush Stroke {
            get { return stroke; }
            set 
            { 
                stroke = value;
                RenderClock();
            }
        }
        public AnalogClock()
        {
            InitializeComponent();

            Stroke = new SolidColorBrush(Colors.Black);
            
            Unloaded += Unload;
            tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromSeconds(1);
            tmr.Tick += Timer_Tick;
            tmr.Start();
            UpdateClock(DateTime.Now);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            UpdateClock(now);
        }
        private void UpdateClock(DateTime now)
        {
            // Установка углов поворота стрелок
            hourHandTransform.Angle = 360.0 * ((now.Hour % 12) + now.Minute / 60.0) / 12.0;
            minuteHandTransform.Angle = 360.0 * (now.Minute + now.Second / 60.0) / 60.0;
        }
        private void Unload(object sender, RoutedEventArgs e)
        {
            // Остановка таймера при закрытии элемента
            tmr.Stop();
        }
        private void RenderClock()
        {
            for (int i = 0; i < 360; i += 6)
            {
                if (i % 30 == 0)
                    continue;
                PathFigure pathFigure = new PathFigure();
                pathFigure.StartPoint = new Point(75, 0);
                pathFigure.Segments.Add(new LineSegment(new Point(75, 3), true));

                PathGeometry pathGeometry = new PathGeometry();
                pathGeometry.Figures.Add(pathFigure);
                Path p = new Path()
                {
                    Stroke = stroke,
                    StrokeThickness = 1,
                    Data = pathGeometry,
                    RenderTransform = new RotateTransform(i, 75, 75),
                };
                grid.Children.Add(p);
            }
            for (int i = 0; i < 360; i += 30)
            {
                PathFigure pathFigure = new PathFigure();
                pathFigure.StartPoint = new Point(75, 0);
                pathFigure.Segments.Add(new LineSegment(new Point(75, (i % 90 == 0) ? 10 : 7), true));

                PathGeometry pathGeometry = new PathGeometry();
                pathGeometry.Figures.Add(pathFigure);
                Path p = new Path()
                {
                    Stroke = stroke,
                    StrokeThickness = 1,
                    Data = pathGeometry,
                    RenderTransform = new RotateTransform(i, 75, 75),
                };
                grid.Children.Add(p);
            }
            el.Stroke = stroke;
        }
    }
}
