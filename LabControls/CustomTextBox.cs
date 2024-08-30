using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LabControls
{
    enum BaseI { Hex = 16, Dec = 10};
    class CustomTextBox : TextBox
    {
        private BaseI basei = BaseI.Dec;
        public BaseI BaseI { 
            get {
                return basei; 
            }
            set {
                basei = value;
                switch (value)
                {
                    case BaseI.Dec:
                        Text = $"{Convert.ToInt32(Text, (int)BaseI.Hex)}";
                        break;
                    case BaseI.Hex:
                        Text = $"{Convert.ToInt32(Text):X}";
                        break;
                }
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl ||
                (BaseI == BaseI.Hex && e.Key >= Key.A && e.Key <= Key.F)))
                e.Handled = true;
            //if (!char.IsDigit(e.Key) && !char.IsControl((e.KeyChar)))
            //    e.Handled = true;
            if (BaseI == BaseI.Hex && e.Key >= Key.A && e.Key <= Key.F)
            {
                Text += e.Key.ToString();
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            int num = 0;
            switch (BaseI)
            {
                case BaseI.Dec:
                    int.TryParse(Text, out num);
                    break;
                case BaseI.Hex:
                    int.TryParse(Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out num);
                    break;
            }
            if (num > 255 && BaseI == BaseI.Dec)
                Text = "255";
            else if (num > 255 && BaseI == BaseI.Hex)
                Text = "FF";
            else if (num < 0 || Text == "")
                Text = "0";
            base.OnTextChanged(e);
        }
    }
}
