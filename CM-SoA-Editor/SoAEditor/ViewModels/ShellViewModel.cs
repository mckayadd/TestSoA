using Caliburn.Micro;

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

    }
}
