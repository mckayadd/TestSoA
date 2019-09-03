using Caliburn.Micro;
using System.Windows;


namespace SoAEditor.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {  
        public ShellViewModel()
        {

        }

        public void LoadNewCompany()
        {
            ActivateItem(new NewCompanyViewModel());
        }

        public void LoadNewTaxonomy()
        {
            ActivateItem(new NewTaxonomyViewModel());
        }

        public void OpenXMLFile()
        {
            ActivateItem(new NewCompanyViewModel("openFile"));
        }

        public void ExitApp()
        {
            Application.Current.Shutdown();
        }

    }
}
