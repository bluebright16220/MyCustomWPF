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


namespace MyWPF.Phone
{
    /// <summary>
    /// MyCalculator.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BasicNumberPanel : UserControl
    {

        public event EventHandler<DigitBtnEventArgs> DigitBtnClickEventHandler;


        public BasicNumberPanel()
        {
            InitializeComponent();
        }


        private void BtnDigit_Click(object sender, RoutedEventArgs e)
        {
            var keyword = (e.Source as Button).Content.ToString();
            OnBtnDigitClicked(new DigitBtnEventArgs(keyword));

        }


        protected virtual void OnBtnDigitClicked(DigitBtnEventArgs e)
        {
            DigitBtnClickEventHandler?.Invoke(this, e);
        }


        public class DigitBtnEventArgs : EventArgs
        {

            public string digit { get; set; }

            public DigitBtnEventArgs(string digit)
            {
                this.digit = digit;
            }

        }

    }


}
