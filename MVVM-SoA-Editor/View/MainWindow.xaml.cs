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

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClickNewCMC(object sender, RoutedEventArgs e)
        {
            WindowFrameColumn2.Content = new CompanyInfo();
        }

        private void BtnClickPage2(object sender, RoutedEventArgs e)
        {
            WindowFrameColumn2.Content = new Page2();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowFrameColumn2.Content = new CompanyInfo();
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Open_Click(object sender, RoutedEventArgs e)
        {
            //WindowFrameColumn2.Content = new CompanyInfo();

            CompanyInfo page = null;
            if (WindowFrameColumn2.Content != null)
            {
                page = (CompanyInfo)WindowFrameColumn2.Content;
                //page.ResetPage();
            }
            else
            {
                page = new CompanyInfo();
                WindowFrameColumn2.Content = page;
            }
        }
    }
}
