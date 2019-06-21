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
using System.Runtime.InteropServices;
using System.Windows.Shapes;


namespace MyWPF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            phoneDigitPanel.DigitBtnClickEventHandler += receivePhoneBtnDigitClick;
        }


        [DllImport("MyCalCulator.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void exportCppFunctionAdd(int[] src, int[] src2, int[] dst, int length);

        [DllImport("MyCalCulator.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern void exportCppFunctionSub(int[] src, int[] src2, int[] dst, int length);


        private void receivePhoneBtnDigitClick(object sender, Phone.BasicNumberPanel.DigitBtnEventArgs e)
        {

            string receivedDigitString = e.digit;


            if (string.Compare("*", receivedDigitString) == 0)
            {
                //asterisk

                string dialString = txt_dial.Text;
                int txtLength = dialString.Length;

                if (txtLength > 0)
                {
                    int number = int.Parse(dialString);

                    int[] src1 = { number * 10, number * 20 };
                    int[] src2 = { number, number * 2 };
                    int[] dst = { 0, 0 };

                    exportCppFunctionAdd(src1, src2, dst, 2);

                    MessageBox.Show(dst[0] + "," + dst[1] + "");

                    dialString = dialString.Substring(0, txtLength - 1);
                    txt_dial.Text = dialString;
                }               
                
            }
            else if (string.Compare("#", receivedDigitString) == 0)
            {
                //pound

                string dialString = txt_dial.Text;
                int txtLength = dialString.Length;

                if (txtLength > 0)
                {
                    int number = int.Parse(dialString);

                    int[] src1 = {number * 10, number * 20};
                    int[] src2 = {number,number * 2 };
                    int[] dst = { 0, 0 };

                    exportCppFunctionSub(src1, src2, dst, 2);

                    MessageBox.Show(dst[0] + "," + dst[1] + "");
                }
                
                txt_dial.Clear();
            }
            else
            {
                txt_dial.AppendText(e.digit);

            }
            

            //MessageBox.Show("Your click button is : " + e.digit);

        }



    }
}
