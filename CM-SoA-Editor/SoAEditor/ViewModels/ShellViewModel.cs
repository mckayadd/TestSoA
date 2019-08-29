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
        
        private string _selectedOptionForTaxonomy;
        private BindableCollection<string> _taxonomyOptions = new BindableCollection<string>();
        private BindableCollection<string> _taxonomyContent = new BindableCollection<string>();
        private BindableCollection<string> _selectedTaxonomy = new BindableCollection<string>();
       
        public ShellViewModel()
        {
            
            TaxonomyOptions.Add("Source");
            TaxonomyOptions.Add("Measure");

            TaxonomyContent.Add("Source.AC.DC");
            TaxonomyContent.Add("Source.DF.HF");
            TaxonomyContent.Add("Source.Merhaba");
            TaxonomyContent.Add("Source.Hello");
            TaxonomyContent.Add("Source.World");
            TaxonomyContent.Add("Measure.AC.DC");
            TaxonomyContent.Add("Measure.Nesimi");
            TaxonomyContent.Add("Measure.Kildiyse");
            TaxonomyContent.Add("Measure.bir.katre");
            TaxonomyContent.Add("Measure.Tovbe");
        }

        public void LoadNewCompany()
        {
            ActivateItem(new NewCompanyViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new PageTwoViewModel());
        }


        public string SelectedOptionForTaxonomy
        {
            get { return _selectedOptionForTaxonomy; }
            set
            {
                _selectedOptionForTaxonomy = value;
                if (string.Equals(value, "Source"))
                {
                    SelectedTaxonomy.Clear();
                    foreach (string str in TaxonomyContent)
                    {
                        if (str.StartsWith("Source"))
                        {
                            SelectedTaxonomy.Add(str);
                        }
                    }
                    LoadNewCompany();
                }
                else if (string.Equals(value, "Measure"))
                {
                    SelectedTaxonomy.Clear();
                    foreach (string str in TaxonomyContent)
                    {
                        if (str.StartsWith("Measure"))
                        {
                            SelectedTaxonomy.Add(str);
                        }
                    }
                    LoadPageTwo();
                }
                NotifyOfPropertyChange(() => SelectedOptionForTaxonomy);
            }
        }

        public BindableCollection<string> TaxonomyOptions
        {
            get { return _taxonomyOptions; }
            set { _taxonomyOptions = value; }
        }

        public BindableCollection<string> SelectedTaxonomy
        {
            get { return _selectedTaxonomy; }
            set { _selectedTaxonomy = value; }
        }

        public BindableCollection<string> TaxonomyContent
        {
            get { return _taxonomyContent; }
            set { _taxonomyContent = value; }
        }

    }
}
