using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class View : Window
    {
        public View()
        {
            InitializeComponent();
        }
        
        private void BtnClickNewCMC(object sender, RoutedEventArgs e)
        {
            WindowFrameColumn2.Content = new Views.CompanyInfo();
        }

        private void BtnClickPage2(object sender, RoutedEventArgs e)
        {
            WindowFrameColumn2.Content = new Views.Page2();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowFrameColumn2.Content = new Views.CompanyInfo();
        }
    }
}
