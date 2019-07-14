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
using System.Xml.Linq;

namespace TestingWPF
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //txt1.Text = "Button is Clicked";
            XDocument doc = new XDocument();
            Soa SampleSOA = new Soa();

            SampleSOA.CapabilityScope.Activities[0].ProcessTypes[0].name = "myPT";
            SampleSOA.CapabilityScope.Locations[0].Address.Street = "myStreet";
            SampleSOA.CapabilityScope.Locations[0].Address.City = "myCity";
            SampleSOA.CapabilityScope.Locations[0].Address.State = "myState";
            SampleSOA.CapabilityScope.Locations[0].Address.Zip = "myZip";
            SampleSOA.Ab_ID = "myAB_ID";
            SampleSOA.Ab_Logo_Signature = "myaAB_Logo_Sign";
            SampleSOA.Scope_ID_Number = "myScopeIdNo";
            SampleSOA.Criteria = "myCriteria";
            SampleSOA.EffectiveDate = "myDate";
            SampleSOA.ExpirationDate = "myExprDate";
            SampleSOA.Statement = "myStatement";

            SampleSOA.CapabilityScope.Locations[0].ContactName = "myContact";
            SampleSOA.CapabilityScope.Locations[0].id = "myID";




            SampleSOA.writeTo(doc);


            // comment added

            doc.Save(@"C:\Users\mckaya\Desktop\sample.xml");

        }


    }
}
