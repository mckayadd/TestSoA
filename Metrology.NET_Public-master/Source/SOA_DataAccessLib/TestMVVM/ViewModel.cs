using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using SOA_DataAccessLibrary;
using System.Xml.Linq;
using System.Windows.Input;

namespace TestMVVM
{
    class ViewModel : INotifyPropertyChanged
    {

        //instantiate Model objects
        XDocument doc;
        Soa SampleSOA;
        private ICommand _saveCommand; // for button click, using System.Windows.Input;

        //constructor
        public ViewModel(){
            //initialize Model object
            doc = new XDocument();
            SampleSOA = new Soa();
        }

        public string Street
        {
            get {
                return "";
            }
            set{
                //SampleSOA.CapabilityScope.Locations[0].Address.Street = value;
            }
        }

        public string City
        {
            get
            {
                return "";
            }
            set
            {
                //SampleSOA.CapabilityScope.Locations[0].Address.City = value;
            }
        }

        public string State
        {
            get
            {
                return "";
            }
            set
            {
               // SampleSOA.CapabilityScope.Locations[0].Address.State = value;
            }
        }

        public string Zip
        {
            get
            {
                return "";
            }
            set
            {
                //SampleSOA.CapabilityScope.Locations[0].Address.Zip = value;
                Zip = value;
            }
        }


        public ICommand SaveCommand
        {
            get
            {
                /* if (_saveCommand == null)
                 {
                     _saveCommand = new RelayCommand(
                         param => this.SaveObject(),
                         param => this.CanSave()
                     );
                 }
                 return _saveCommand;*/

                SampleSOA.CapabilityScope.Locations[0].Address.Zip = Zip;

                return null;

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
