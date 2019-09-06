using Caliburn.Micro;
using System.Windows;


namespace SoAEditor.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private NewCompanyViewModel ncvm = null;

        public ShellViewModel()
        {

        }

        public void LoadNewCompany()
        {
            ActivateItem(ncvm = new NewCompanyViewModel());
        }

        public void LoadNewTaxonomy()
        {
            ActivateItem(new NewTaxonomyViewModel());
        }

        public void OpenXMLFile()
        {
            ActivateItem(ncvm = new NewCompanyViewModel("openFile"));
        }

        public void SaveXML()
        {
            ncvm.SaveXML();
        }

        public void SaveAsXML()
        {
            ncvm.SaveAsXML();
        }

        public void ExitApp()
        {
            Application.Current.Shutdown();
        }

    }
}
