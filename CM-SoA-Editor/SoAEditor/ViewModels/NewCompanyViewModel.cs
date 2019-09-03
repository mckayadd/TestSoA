using Caliburn.Micro;
using Microsoft.Win32;
using SOA_DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SoAEditor.ViewModels
{
    public class NewCompanyViewModel : Caliburn.Micro.Screen
    {
        private string _city;
        private string _street;
        private string _state;
        private string _zip;

        XDocument doc;
        Soa SampleSOA;
        SOA_DataAccess dao;

        public NewCompanyViewModel()
        {
            //doc = new XDocument();
            SampleSOA = new Soa();
        }

        public NewCompanyViewModel(string str)
        {
            if(str.Equals("openFile"))
            {
                //doc = new XDocument();
                SampleSOA = new Soa();
                OpenFile();
            }
        }

        public void OpenFile()
        {
            dao = new SOA_DataAccess();

            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Filter = "XML Files (*.xml)|*.xml|All Files(*.*)|*.*";
            dlg.Multiselect = false;
            //string path = dlg.FileName;
            try
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                dao.load(dlg.FileName);
                SampleSOA = dao.SOADataMaster;

                /*
                AB_ID = SampleSOA.Ab_ID;
                AB_logo_sign = SampleSOA.Ab_Logo_Signature;
                Scope_ID = SampleSOA.Scope_ID_Number;
                Criteria = SampleSOA.Criteria;
                Effective_date = SampleSOA.EffectiveDate;
                Expiration_date = SampleSOA.ExpirationDate;
                //Statement = SampleSOA.Statement;
                Name = SampleSOA.CapabilityScope.MeasuringEntity.ToString();
                Location_ID = SampleSOA.CapabilityScope.Locations[0].id;
                Contact_name = SampleSOA.CapabilityScope.Locations[0].ContactName;
                Contact_info = SampleSOA.CapabilityScope.Locations[0].ContactInfo.ToString(); */
                Street = SampleSOA.CapabilityScope.Locations[0].Address.Street; 
                City = SampleSOA.CapabilityScope.Locations[0].Address.City;
                State = SampleSOA.CapabilityScope.Locations[0].Address.State;
                Zip = SampleSOA.CapabilityScope.Locations[0].Address.Zip;

            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("The data file is invalid!");
                return;
            }
        }

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                NotifyOfPropertyChange(() => City);    
            }
        }

        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }


        public string State
        {
            get { return _state; }
            set { _state = value; }
        }


        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        public void SaveXML()
        {

            doc = new XDocument();

            SampleSOA.CapabilityScope.Locations[0].Address.Street = Street;
            SampleSOA.CapabilityScope.Locations[0].Address.City = City;
            SampleSOA.CapabilityScope.Locations[0].Address.State = State;
            SampleSOA.CapabilityScope.Locations[0].Address.Zip = Zip;

            SampleSOA.Ab_ID = "a";
            SampleSOA.Ab_Logo_Signature = "a";
            SampleSOA.Scope_ID_Number = "a";
            SampleSOA.Criteria = "a";
            SampleSOA.EffectiveDate = "a";
            SampleSOA.ExpirationDate = "a";
            SampleSOA.Statement = "a";
            SampleSOA.CapabilityScope.MeasuringEntity = "a";
            SampleSOA.CapabilityScope.Locations[0].id = "a";
            SampleSOA.CapabilityScope.Locations[0].ContactName = "a";
            //SampleSOA.CapabilityScope.Locations[0].ContactInfo = Contact_info;
    

            SampleSOA.writeTo(doc); // doc becomes null when open a document

            doc.Save(@"C:\Temp\MySample.xml");


        }

    }
}
