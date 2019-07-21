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

            XmlDocument db = new XmlDocument();
            db.Load(@"c:\temp\MetrologyNET_Taxonomy_v2.xml");
            int process_count = db.GetElementsByTagName("mtc:ProcessType").Count;
            //put the processes into combobox(combo2)
            ComboBoxItem comboitem = null;
            comboitem = new ComboBoxItem();
            for (int i = 0; i < process_count; i++)
            {
                comboitem = new ComboBoxItem();
                comboitem.Uid = i.ToString();
                comboitem.Content = db.GetElementsByTagName("mtc:ProcessType")[i].Attributes["name"].Value;
                comboTaxonomy.Items.Add(comboitem);
                //comboitem2.IsSelected = true;
            }
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
    }
}
