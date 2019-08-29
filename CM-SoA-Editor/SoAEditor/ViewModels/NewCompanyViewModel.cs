using Caliburn.Micro;
using SOA_DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SoAEditor.ViewModels
{
    public class NewCompanyViewModel : Screen
    {
        private string _city;
        private string _street;
        private string _state;
        private string _zip;

        XDocument doc;
        Soa SampleSOA;

        public NewCompanyViewModel()
        {
            doc = new XDocument();
            SampleSOA = new Soa();
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
            //SampleSOA.Statement = Statement;
            SampleSOA.CapabilityScope.MeasuringEntity = "a";
            SampleSOA.CapabilityScope.Locations[0].id = "a";
            SampleSOA.CapabilityScope.Locations[0].ContactName = "a";
            //SampleSOA.CapabilityScope.Locations[0].ContactInfo = Contact_info;
    

            SampleSOA.writeTo(doc);

            doc.Save(@"C:\Temp\MySample.xml");


        }

    }
}
