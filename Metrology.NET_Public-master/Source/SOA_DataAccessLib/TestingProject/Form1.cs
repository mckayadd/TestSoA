using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SOA_DataAccessLibrary;
using System.Xml.Linq;

namespace TestingProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //SOA_DataAccess dao = new SOA_DataAccess();

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

            


            doc.Save(@"C:\Users\mckaya\Desktop\sample.xml");

        }
    }
}
