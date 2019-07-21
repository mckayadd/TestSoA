using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using SOA_DataAccessLibrary;
using System.Xml.Linq;
using System.Windows.Input;
using System.Windows.Forms;

namespace TestMVVM
{
    public class ViewModel : ObservableObject
    {
        private string _AB_ID;
        private string _AB_logo_sign;
        private string _Scope_ID;
        private string _Criteria;
        private string _Effective_date;
        private string _Expiration_date;
        private string _Statement;
        private string _Name;
        private string _Location_ID;
        private string _Contact_name;
        private string _Contact_info;
        private string _Street;
        private string _City;
        private string _State;
        private string _Zip;

        //define Model objects
        XDocument doc;
        Soa SampleSOA;
        SOA_DataAccess dao;

        //constructor
        public ViewModel()
        {

            //instanciate objects
            doc = new XDocument();
            SampleSOA = new Soa();
        }

        public string AB_ID { get => _AB_ID; set { _AB_ID = value; RaisePropertyChangedEvent("AB_ID");} }
        public string AB_logo_sign { get => _AB_logo_sign; set { _AB_logo_sign = value; RaisePropertyChangedEvent("AB_logo_sign"); } }
        public string Scope_ID { get => _Scope_ID; set { _Scope_ID = value; RaisePropertyChangedEvent("Scope_ID"); } }
        public string Criteria { get => _Criteria; set { _Criteria = value; RaisePropertyChangedEvent("Criteria"); } }
        public string Effective_date { get => _Effective_date; set { _Effective_date = value; RaisePropertyChangedEvent("Effective_date"); } }
        public string Expiration_date { get => _Expiration_date; set { _Expiration_date = value; RaisePropertyChangedEvent("Expiration_date"); } }
        public string Statement { get => _Statement; set { _Expiration_date = value; RaisePropertyChangedEvent("Statement"); } }
        public string Name { get => _Name; set { _Name = value; RaisePropertyChangedEvent("Name"); } }
        public string Location_ID { get => _Location_ID; set { _Location_ID = value; RaisePropertyChangedEvent("Location_ID"); } }
        public string Contact_name { get => _Contact_name; set { _Contact_name = value; RaisePropertyChangedEvent("Contact_name"); } }
        public string Contact_info { get => _Contact_info; set { _Contact_info = value; RaisePropertyChangedEvent("Contact_info"); } }

        public string Street
        {
            get
            {
                return _Street;
            }
            set
            {
                _Street = value;
                //this informs the UI to update the the "Street" field
                RaisePropertyChangedEvent("Street");
            }
        }

        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
                RaisePropertyChangedEvent("City");
            }
        }

        public string State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
                RaisePropertyChangedEvent("State");
            }
        }

        public string Zip
        {
            get
            {
                return _Zip;
            }
            set
            {
                _Zip = value;
                RaisePropertyChangedEvent("Zip");
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new DelegateCommand(saveAction);
            }
        }

        private void saveAction()
        {
            SampleSOA.Ab_ID = AB_ID;
            SampleSOA.Ab_Logo_Signature = AB_logo_sign;
            SampleSOA.Scope_ID_Number = Scope_ID;
            SampleSOA.Criteria = Criteria;
            SampleSOA.EffectiveDate = Effective_date;
            SampleSOA.ExpirationDate = Expiration_date;
            SampleSOA.Statement = Statement;
            SampleSOA.CapabilityScope.MeasuringEntity = Name;
            SampleSOA.CapabilityScope.Locations[0].id = Location_ID;
            SampleSOA.CapabilityScope.Locations[0].ContactName = Contact_name;
            //SampleSOA.CapabilityScope.Locations[0].ContactInfo = Contact_info;
            SampleSOA.CapabilityScope.Locations[0].Address.Street = Street;
            SampleSOA.CapabilityScope.Locations[0].Address.City = City;
            SampleSOA.CapabilityScope.Locations[0].Address.State = State;
            SampleSOA.CapabilityScope.Locations[0].Address.Zip = Zip;

            SampleSOA.writeTo(doc);

            doc.Save(@"C:\Temp\sample.xml");

            //MessageBox.Show("file saved!");

            //now reset the text boxes
        }

        public ICommand OpenCommand
        {
            get
            {
                return new DelegateCommand(openAction);
            }
        }

        private void openAction()
        {
            dao = new SOA_DataAccess();

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Filter = "XML Files (*.xml)|*.xml|All Files(*.*)|*.*";
            dlg.Multiselect = false;            
            try
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;
                
                dao.load(dlg.FileName);
                SampleSOA = dao.SOADataMaster;

                AB_ID = SampleSOA.Ab_ID;
                AB_logo_sign = SampleSOA.Ab_Logo_Signature;
                Scope_ID = SampleSOA.Scope_ID_Number;
                Criteria = SampleSOA.Criteria;
                Effective_date = SampleSOA.EffectiveDate;
                Expiration_date = SampleSOA.ExpirationDate;
                Statement = SampleSOA.Statement;
                Name = SampleSOA.CapabilityScope.MeasuringEntity.ToString();
                Location_ID = SampleSOA.CapabilityScope.Locations[0].id;
                Contact_name = SampleSOA.CapabilityScope.Locations[0].ContactName;
                Contact_info = SampleSOA.CapabilityScope.Locations[0].ContactInfo.ToString();
                Street = SampleSOA.CapabilityScope.Locations[0].Address.Street;
                City = SampleSOA.CapabilityScope.Locations[0].Address.City;
                State = SampleSOA.CapabilityScope.Locations[0].Address.State;
                Zip = SampleSOA.CapabilityScope.Locations[0].Address.Zip;

            }
            catch (Exception)
            {
                MessageBox.Show("The data file is invalid!");
                return;
            }
        }
    }
}
