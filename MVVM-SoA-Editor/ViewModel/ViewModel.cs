using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using SOA_DataAccessLibrary;
using System.Xml.Linq;
using System.Windows.Input;
using System.Windows;

namespace TestMVVM
{
    public class ViewModel : ObservableObject
    {

        private string _Street;
        private string _City;
        private string _State;
        private string _Zip;

        //define Model objects
        XDocument doc;
        Soa SampleSOA;

        //constructor
        public ViewModel()
        {

            //instanciate objects
            doc = new XDocument();
            SampleSOA = new Soa();
        }

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
            SampleSOA.CapabilityScope.Locations[0].Address.Street = Street;
            SampleSOA.CapabilityScope.Locations[0].Address.City = City;
            SampleSOA.CapabilityScope.Locations[0].Address.State = State;
            SampleSOA.CapabilityScope.Locations[0].Address.Zip = Zip;

            SampleSOA.writeTo(doc);

            doc.Save(@"C:\Temp\sample.xml");

            //MessageBox.Show("file saved!");

            //now reset the text boxes
        }

    }
}
