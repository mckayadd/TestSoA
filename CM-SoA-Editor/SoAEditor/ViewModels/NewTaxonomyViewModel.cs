using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SoAEditor.ViewModels
{
   public class NewTaxonomyViewModel : Screen
    {
        private string _selectedOptionForTaxonomy;
        private string _selectedProcessType;
        private bool _canSelectATaxonomy = false;
        //Soa SampleSOA;

        private BindableCollection<string> _taxonomyOptions = new BindableCollection<string>();
        private BindableCollection<string> _taxonomyContent = new BindableCollection<string>();
        private BindableCollection<string> _selectedTaxonomy = new BindableCollection<string>();

        public NewTaxonomyViewModel()
        {
            //SampleSOA = new Soa();

            TaxonomyOptions.Add("Source");
            TaxonomyOptions.Add("Measure");


            LoadTaxonomyDatabase();

            /* TaxonomyContent.Add("Source.AC.DC");
             TaxonomyContent.Add("Source.DF.HF");
             TaxonomyContent.Add("Source.Merhaba");
             TaxonomyContent.Add("Source.Hello");
             TaxonomyContent.Add("Source.World");
             TaxonomyContent.Add("Measure.AC.DC");
             TaxonomyContent.Add("Measure.Nesimi");
             TaxonomyContent.Add("Measure.Kildiyse");
             TaxonomyContent.Add("Measure.bir.katre");
             TaxonomyContent.Add("Measure.Tovbe");*/
        }

        public void LoadTaxonomyDatabase()
        {
            XmlDocument db = new XmlDocument();
            db.Load(@"c:\temp\MetrologyNET_Taxonomy_v2.xml"); //the path should be updated in the final version
            int process_count = db.GetElementsByTagName("mtc:ProcessType").Count;
            string strTemp;
            strTemp = db.GetElementsByTagName("mtc:ProcessType")[0].Attributes["name"].Value; //("mtc:Parameter"); // Attributes["name"].Value;

            for (int i = 0; i < process_count; i++)
            {
                TaxonomyContent.Add(db.GetElementsByTagName("mtc:ProcessType")[i].Attributes["name"].Value);


                
                // string str = SampleSOA.CapabilityScope.Activities[0].ProcessTypes[0].ProcessType.Parameters;
            }
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
                            string tempStr = str.Substring(7);
                            SelectedTaxonomy.Add(tempStr);
                        }
                    }
                    CanSelectATaxonomy = IsSelectedTaxonomyEmpty();
                }
                else if (string.Equals(value, "Measure"))
                {
                    SelectedTaxonomy.Clear();
                    foreach (string str in TaxonomyContent)
                    {
                        if (str.StartsWith("Measure"))
                        {
                            string tempStr = str.Substring(8);
                            SelectedTaxonomy.Add(tempStr);
                        }
                    }
                    CanSelectATaxonomy = IsSelectedTaxonomyEmpty();
                }
                NotifyOfPropertyChange(() => SelectedOptionForTaxonomy);
            }
        }

        public bool IsSelectedTaxonomyEmpty()
        {
            if (SelectedTaxonomy.Any())
            {
                return true;
            }
            else if(!SelectedTaxonomy.Any())
            {
                return false;
            }

            return false;

        }

        public string SelectedProcessType
        {
            get { return _selectedProcessType; }
            set
            {
                _selectedProcessType = value;

                // string str = SelectedOptionForTaxonomy + SelectedProcessType; // Source + Volts.AC

                // required parameters will be added

                NotifyOfPropertyChange(() => SelectedProcessType);
            }
        }

        public bool CanSelectATaxonomy
        {
            get { return _canSelectATaxonomy; }
            set
            {
                _canSelectATaxonomy = value;
                NotifyOfPropertyChange(() => CanSelectATaxonomy);
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
