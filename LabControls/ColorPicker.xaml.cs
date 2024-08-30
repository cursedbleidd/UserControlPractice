using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
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
using static System.Net.Mime.MediaTypeNames;

namespace LabControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
public partial class ColorPicker : UserControl
    {
        public Color Color { get; set; }
        public event EventHandler? ColorChanged;
        public ColorPicker()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content)
            {
                case "Dec":
                    r.BaseI = BaseI.Dec;
                    g.BaseI = BaseI.Dec;
                    b.BaseI = BaseI.Dec;
                    break;
                case "Hex":
                    r.BaseI = BaseI.Hex;
                    g.BaseI = BaseI.Hex;
                    b.BaseI = BaseI.Hex;
                    break;
            }
        }

        private void rgb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (r == null || g == null || b == null)
                return;
            try
            {
                Color = Color.FromRgb(Convert.ToByte(Convert.ToInt32(r.Text, (int)r.BaseI)), Convert.ToByte(Convert.ToInt32(g.Text, (int)g.BaseI)), Convert.ToByte(Convert.ToInt32(b.Text, (int)b.BaseI)));
                square.Fill = new SolidColorBrush(Color);
                if (ColorChanged != null)
                    ColorChanged(this, EventArgs.Empty);
            }
            catch (FormatException ex)
            { 

            }
        }
    }
}