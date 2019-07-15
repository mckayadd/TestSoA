using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWPF
{
    class MyViewModel : INotifyPropertyChanged
    {

        private User user;

        public string FirstName
        {
            get { return user.FirstName; }
            set
            {
                if (user.FirstName != value)
                {
                    user.FirstName = value;
                    OnPropertyChange("FirstName");
                    // If the first name has changed, the FullName property needs to be udpated as well.
                    OnPropertyChange("FullName");
                }
            }
        }

        public string LastName
        {
            get { return user.LastName; }
            set
            {
                if (user.LastName != value)
                {
                    user.LastName = value;
                    OnPropertyChange("LastName");
                    // If the first name has changed, the FullName property needs to be udpated as well.
                    OnPropertyChange("FullName");
                }
            }
        }

        // This property is an example of how model properties can be presented differently to the View.
        // In this case, we transform the birth date to the user's age, which is read only.
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - user.BirthDate.Year;
                if (user.BirthDate > today.AddYears(-age)) age--;
                return age;
            }
        }

        // This property is just for display purposes and is a composition of existing data.
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public MyViewModel()
        {
            user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Now.AddYears(-30)
            };
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
