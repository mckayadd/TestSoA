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
using System.Collections.ObjectModel;
using System.Xml;

namespace TestMVVM
{
    public class ViewModel : ObservableObject
    {
        //taxonomy binding
        private ObservableCollection<Taxonomy> _measureTaxonomies;
        public ObservableCollection<Taxonomy> MeasureTaxonomies
        {
            get { return _measureTaxonomies; }
            set { _measureTaxonomies = value; RaisePropertyChangedEvent("MeasureTaxonomies"); }
        }

        private ObservableCollection<Taxonomy> _sourceTaxonomies;
        public ObservableCollection<Taxonomy> SourceTaxonomies
        {
            get { return _sourceTaxonomies; }
            set { _sourceTaxonomies = value; RaisePropertyChangedEvent("SourceTaxonomies"); }
        }
        
        private Taxonomy _sTaxonmony;

        public Taxonomy STaxonomy
        {
            get { return _sTaxonmony; }
            set { _sTaxonmony = value; }
        }

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

            //load taxonomies into combobox. To be used by the View
            MeasureTaxonomies = createTaxonomyList("measure");
            SourceTaxonomies = createTaxonomyList("source");
        }

        private ObservableCollection<Taxonomy> createTaxonomyList(string measureType) {

            ObservableCollection<Taxonomy> tempTaxonomies = new ObservableCollection<Taxonomy>();

            XmlDocument db = new XmlDocument();
            db.Load(@"c:\temp\MetrologyNET_Taxonomy_v2.xml"); //the path should be updated in the final version
            int process_count = db.GetElementsByTagName("mtc:ProcessType").Count;

            if (measureType.Equals("measure"))//"measure" in the function argument
            {
                for (int i = 0; i < process_count; i++)
                {
                    string tempProcessType;
                    tempProcessType = db.GetElementsByTagName("mtc:ProcessType")[i].Attributes["name"].Value;

                    if (tempProcessType.StartsWith("Measure"))//"Measure" in the Taxonomy database
                    {
                        tempTaxonomies.Add(new Taxonomy() { ProcessType = db.GetElementsByTagName("mtc:ProcessType")[i].Attributes["name"].Value });
                    }
                }
            }
            else if (measureType.Equals("source"))//"source" in the function argument
            {
                for (int i = 0; i < process_count; i++)
                {
                    string tempProcessType;
                    tempProcessType = db.GetElementsByTagName("mtc:ProcessType")[i].Attributes["name"].Value;

                    if (tempProcessType.StartsWith("Source"))//"Source" in the Taxonomy database
                    {
                        tempTaxonomies.Add(new Taxonomy() { ProcessType = db.GetElementsByTagName("mtc:ProcessType")[i].Attributes["name"].Value });
                    }
                }
            }
            
            return tempTaxonomies;
        }

        public string AB_ID { get { return _AB_ID; } set { _AB_ID = value; RaisePropertyChangedEvent("AB_ID");} }
        public string AB_logo_sign { get { return _AB_logo_sign; } set { _AB_logo_sign = value; RaisePropertyChangedEvent("AB_logo_sign"); } }
        public string Scope_ID { get { return _Scope_ID; } set { _Scope_ID = value; RaisePropertyChangedEvent("Scope_ID"); } }
        public string Criteria { get { return _Criteria; } set { _Criteria = value; RaisePropertyChangedEvent("Criteria"); } }
        public string Effective_date { get { return _Effective_date; } set { _Effective_date = value; RaisePropertyChangedEvent("Effective_date"); } }
        public string Expiration_date { get { return _Expiration_date; } set { _Expiration_date = value; RaisePropertyChangedEvent("Expiration_date"); } }
        public string Statement { get { return _Statement; } set { _Expiration_date = value; RaisePropertyChangedEvent("Statement"); } }
        public string Name { get { return _Name; } set { _Name = value; RaisePropertyChangedEvent("Name"); } }
        public string Location_ID { get { return _Location_ID; } set { _Location_ID = value; RaisePropertyChangedEvent("Location_ID"); } }
        public string Contact_name { get { return _Contact_name; } set { _Contact_name = value; RaisePropertyChangedEvent("Contact_name"); } }
        public string Contact_info { get { return _Contact_info; } set { _Contact_info = value; RaisePropertyChangedEvent("Contact_info"); } }

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
                //Statement = SampleSOA.Statement;
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
