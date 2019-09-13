using SoAEditor.Models;

namespace SoAEditor.ViewModels
{
    public class CompanyInfoViewModel : Caliburn.Micro.Screen
    {
        private string _city;
        private string _street;
        private string _state;
        private string _zip;

        public CompanyInfoModel companyInfoM;

        //XDocument doc;
        //Soa SampleSoA;

        public CompanyInfoViewModel(CompanyInfoModel companyInfoModel)
        {
            companyInfoM = companyInfoModel;

        }

        public void SaveCompanyInfo()
        {
            companyInfoM.Street = Street;
            companyInfoM.City = City;
            companyInfoM.State = State;
            companyInfoM.Zip = Zip;

            System.Windows.Forms.MessageBox.Show("Company Info Saved!");

        }

        public void LoadCompanyInfo()
        {
            Street = companyInfoM.Street;
            City = companyInfoM.City;
            State = companyInfoM.State;
            Zip = companyInfoM.Zip;
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
            set
            {
                _zip = value;
                NotifyOfPropertyChange(() => Zip);
            }
        }

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                NotifyOfPropertyChange(() => State);
            }
        }

        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                NotifyOfPropertyChange(() => Street);
            }
        }

    }
}
