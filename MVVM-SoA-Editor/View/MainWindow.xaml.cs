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
using SOA_DataAccessLibrary;
using System.Xml;

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

            tabs.SelectedIndex = 0;            
        }

        private void BtnClickNewCMC(object sender, RoutedEventArgs e)
        {
            //WindowFrameColumn2.Content = new CompanyInfo();
        }

        private void BtnClickPage2(object sender, RoutedEventArgs e)
        {
            //WindowFrameColumn2.Content = new Page2();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //WindowFrameColumn2.Content = new CompanyInfo();

        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Open_Click(object sender, RoutedEventArgs e)
        {
            ////WindowFrameColumn2.Content = new CompanyInfo();

            //CompanyInfo page = null;
            //if (WindowFrameColumn2.Content != null)
            //{
            //    page = (CompanyInfo)WindowFrameColumn2.Content;
            //    //page.ResetPage();
            //}
            //else
            //{
            //    page = new CompanyInfo();
            //    WindowFrameColumn2.Content = page;
            //}

            //tabs.SelectedIndex = 1;
        }

        private void comboTaxonomySelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboTaxonomyMeasureTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String str = comboTaxonomyMeasureType.SelectedValue.ToString();


            if (str.Contains("Measure"))
            {
                comboTaxonomy.ItemsSource = "{Binding Path=MeasureTaxonomies}";
                comboTaxonomy.DisplayMemberPath = "ProcessType";
            }
            else if (str.Contains("Source"))
            {
                comboTaxonomy.ItemsSource = "{Binding Path=SourceTaxonomies}";
                comboTaxonomy.DisplayMemberPath = "ProcessType";
            }
        }
    }
}
