using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object> // Screen
    {
        private string _firstName;
        private string _lastName;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "MC", LastName = "Kaya" });
            People.Add(new PersonModel { FirstName = "Mahdi", LastName = "SN" });
            People.Add(new PersonModel { FirstName = "Moose", LastName = "Pi" });
        }


        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }
       
        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }

       

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }



        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName) // used to disable the button when the text boxes are empty. Again, the naming matters: ClearText, CanClearText...
        {
            //throw new NotImplementedException();
            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());

        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }

    }
}
