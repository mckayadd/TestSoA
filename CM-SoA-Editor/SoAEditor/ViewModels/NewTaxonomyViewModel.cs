using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SoAEditor.Models;

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
        private BindableCollection<ProcessType> _processTypes = new BindableCollection<ProcessType>(); // ProcessType is defined in the Models


        private ProcessType _currentProcessType; // to be saved for a company

        private string _optionalParameters = "World";
        private string _requiredParameters = "Hello";





        public NewTaxonomyViewModel()
        {
            //SampleSOA = new Soa();

            TaxonomyOptions.Add("Source");
            TaxonomyOptions.Add("Measure");

            _currentProcessType = new ProcessType();

            LoadTaxonomyDatabase();

        }

        public void LoadTaxonomyDatabase()
        {
            XmlDocument db = new XmlDocument();
            db.Load(@"c:\temp\MetrologyNET_Taxonomy_v2.xml"); //the path should be updated in the final version

            //////////////////////////////

            XmlNodeList ptNodesList = db.GetElementsByTagName("mtc:ProcessType");

            foreach(XmlNode xmlNode in ptNodesList)
            {
                ProcessType tempPt = new ProcessType(); // Model object to be filled by XML node
                String tempName = xmlNode.Attributes["name"].Value;
                //Console.WriteLine(tempName);
                if(tempName.StartsWith("Source"))     // taxonomy contains: <mtc:ProcessType name="D0AD73A4-E43E-4B9A-9C41-9A54281C18BC">, changed with: Source.Power.Lorem.Ipsum
                {
                    tempPt.Action = "Source";
                    tempPt.Taxonomy = tempName.Substring(7);
                }
                else if (tempName.StartsWith("Measure"))
                {
                    tempPt.Action = "Measure";
                    tempPt.Taxonomy = tempName.Substring(8);
                }

                XmlNodeList childNodeList = xmlNode.ChildNodes;
                foreach(XmlNode childNode in childNodeList)
                {
                    if(childNode.Name.Equals("mtc:Parameter"))
                    {
                        bool isOptional = false;
                        XmlAttributeCollection attributes = childNode.Attributes;
                        foreach (XmlAttribute xmlAttribute in attributes)
                        {
                            if (xmlAttribute.Name.Equals("optional")) isOptional = true;
                        }

                        if (isOptional == true) // optional parameter
                        {
                            tempPt.OptionalParameters.Add(childNode.Attributes["name"].Value);
                        }
                        else if (isOptional == false)
                        {
                            tempPt.RequiredParameters.Add(childNode.Attributes["name"].Value);
                        }
                    }
                }

                ProcessTypes.Add(tempPt);
            }

            /////////////////////////////


            int process_count = db.GetElementsByTagName("mtc:ProcessType").Count;
            string strTemp;
            System.Xml.XmlNode nd = db.GetElementsByTagName("mtc:ProcessType")[0]; //("mtc:Parameter"); // Attributes["name"].Value;

            System.Xml.XmlNodeList ndList = nd.ChildNodes;

            //Console.WriteLine("Count: " + process_count + "    !!!!!!!");

            //Console.WriteLine("List Length: " + ptNodesList.Count + "    !!!!!!!");

            foreach (XmlNode iNode in ndList)
            {
                if (iNode.Name.Equals("mtc:Parameter"))
                {
                    //Console.WriteLine(iNode.Attributes["name"].Value);
                }
            }

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
                    foreach (ProcessType processType in ProcessTypes)
                    {
                        if (processType.Action.Equals("Source"))
                        {
                            SelectedTaxonomy.Add(processType.Taxonomy);
                        }
                    }
                    CanSelectATaxonomy = IsSelectedTaxonomyEmpty();
                }
                else if (string.Equals(value, "Measure"))
                {
                    SelectedTaxonomy.Clear();
                    foreach (ProcessType processType in ProcessTypes)
                    {
                        if (processType.Action.Equals("Measure"))
                        {
                            SelectedTaxonomy.Add(processType.Taxonomy);
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

                // SelectedOptionForTaxonomy + SelectedProcessType; // Source + Volts.AC
                
                foreach(ProcessType processType in ProcessTypes)
                {
                    if(processType.Action.Equals(SelectedOptionForTaxonomy) && processType.Taxonomy.Equals(SelectedProcessType))
                    {
                        CurrentProcessType = processType;
                        break;
                    }
                }

                //Console.WriteLine("--- " + CurrentProcessType.Action + "." + CurrentProcessType.Taxonomy + " ---");

                string strReq = "";

                RequiredParameters = "";
                foreach (string str in CurrentProcessType.RequiredParameters)
                {
                    strReq += str + "\n";
                }

                RequiredParameters = strReq;

                string strOpt = "";

                OptionalParameters = "";
                foreach (string str in CurrentProcessType.OptionalParameters)
                {
                    strOpt += str + "\n";
                }

                OptionalParameters = strOpt;

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

        public BindableCollection<ProcessType> ProcessTypes
        {
            get { return _processTypes; }
            set { _processTypes = value; }
        }

        public ProcessType CurrentProcessType
        {
            get { return _currentProcessType; }
            set { _currentProcessType = value; }
        }

        public string OptionalParameters
        {
            get { return _optionalParameters; }
            set
            {
                _optionalParameters = value;
                NotifyOfPropertyChange(() => OptionalParameters);
            }
        }

        public string RequiredParameters
        {
            get { return _requiredParameters; }
            set
            {
                _requiredParameters = value;
                NotifyOfPropertyChange(() => RequiredParameters);
            }
        }

    }


}
