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

namespace LabControls
{
    /// <summary>
    /// Логика взаимодействия для ClockSegment.xaml
    /// </summary>
    public partial class ClockSegment : UserControl
    {
        private int val;
        private Brush brush = new SolidColorBrush(Colors.Green);
        private Brush black = new SolidColorBrush(Colors.Black);
        private Brush canvasBrush = new SolidColorBrush(Colors.Black);
        public Brush CanvasBrush
        {
            get { return canvasBrush; }
            set
            {
                canvasBrush = value;
                UpdateCanvas();
            }
        }
        public Brush Brush
        {
            get { return brush; } 
            set
            { 
                brush = value;
                UpdateCanvas();
            }
        }
        public int Value
        { 
            get
            { return val; }
            set 
            { 
                val = value;
                UpdateCanvas();
            } }
        public ClockSegment()
        {
            InitializeComponent();
        }
        private void UpdateCanvas()
        {
            canvas.Background = canvasBrush;
            switch (Value) 
            {
                case 1:
                    first.Fill = black;
                    second.Fill = brush;
                    third.Fill = brush;
                    fourth.Fill = black;
                    fifth.Fill = black;
                    sixth.Fill = black;
                    seventh.Fill = black;
                    break;
                case 2:
                    first.Fill = brush;
                    second.Fill = brush;
                    third.Fill = black;
                    fourth.Fill = brush;
                    fifth.Fill = brush;
                    sixth.Fill = black;
                    seventh.Fill = brush;
                    break;
                case 3:
                    first.Fill = brush;
                    second.Fill = brush;
                    third.Fill = brush;
                    fourth.Fill = brush;
                    fifth.Fill = black;
                    sixth.Fill = black;
                    seventh.Fill = brush;
                    break;
                case 4:
                    first.Fill = black;
                    second.Fill = brush;
                    third.Fill = brush;
                    fourth.Fill = black;
                    fifth.Fill = black;
                    sixth.Fill = brush;
                    seventh.Fill = brush;
                    break;
                case 5:
                    first.Fill = brush;
                    second.Fill = black;
                    third.Fill = brush;
                    fourth.Fill = brush;
                    fifth.Fill = black;
                    sixth.Fill = brush;
                    seventh.Fill = brush;
                    break;
                case 6:
                    first.Fill = brush;
                    second.Fill = black;
                    third.Fill = brush;
                    fourth.Fill = brush;
                    fifth.Fill = brush;
                    sixth.Fill = brush;
                    seventh.Fill = brush;
                    break;
                case 7:
                    first.Fill = brush;
                    second.Fill = brush;
                    third.Fill = brush;
                    fourth.Fill = black;
                    fifth.Fill = black;
                    sixth.Fill = black;
                    seventh.Fill = black;
                    break;
                case 8:
                    first.Fill = brush;
                    second.Fill = brush;
                    third.Fill = brush;
                    fourth.Fill = brush;
                    fifth.Fill = brush;
                    sixth.Fill = brush;
                    seventh.Fill = brush;
                    break;
                case 9:
                    first.Fill = brush;
                    second.Fill = brush;
                    third.Fill = brush;
                    fourth.Fill = brush;
                    fifth.Fill = black;
                    sixth.Fill = brush;
                    seventh.Fill = brush;
                    break;
                case 0:
                    first.Fill = brush;
                    second.Fill = brush;
                    third.Fill = brush;
                    fourth.Fill = brush;
                    fifth.Fill = brush;
                    sixth.Fill = brush;
                    seventh.Fill = black;
                    break;

            }
        }
    }
}
