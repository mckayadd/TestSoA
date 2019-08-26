using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOA_DataAccessLibrary;
using System.Xml.Linq;
using Microsoft.Win32;
using System.Windows;
using System.Xml;

namespace SoAEditor.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _city = "El-aziz";

        XDocument doc;
        Soa SampleSOA;

        public ShellViewModel()
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

        public void OpenXML()
        {
            SampleSOA.CapabilityScope.Locations[0].Address.City = City;

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
            SampleSOA.CapabilityScope.Locations[0].Address.Street = "a";
            //SampleSOA.CapabilityScope.Locations[0].Address.City = City;
            SampleSOA.CapabilityScope.Locations[0].Address.State = "a";
            SampleSOA.CapabilityScope.Locations[0].Address.Zip = "a";

            SampleSOA.writeTo(doc);

            doc.Save(@"C:\Temp\MySample.xml");


        }

    }
}
