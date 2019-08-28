﻿using Caliburn.Micro;
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
        private string _city = "El-aziz";
        private string _selectedPage;
        private BindableCollection<string> _pages = new BindableCollection<string>();
        private BindableCollection<string> _taxonomies = new BindableCollection<string>();
        private BindableCollection<string> _selectedTaxonomy = new BindableCollection<string>();
       
               
        XDocument doc;
        Soa SampleSOA;

        public ShellViewModel()
        {
            doc = new XDocument();
            SampleSOA = new Soa();
            Pages.Add("Source");
            Pages.Add("Measure");
            Taxonomies.Add("Source.AC.DC");
            Taxonomies.Add("Source.DF.HF");
            Taxonomies.Add("Source.Merhaba");
            Taxonomies.Add("Source.Hello");
            Taxonomies.Add("Source.World");
            Taxonomies.Add("Measure.AC.DC");
            Taxonomies.Add("Measure.Nesimi");
            Taxonomies.Add("Measure.Kildiyse");
            Taxonomies.Add("Measure.bir.katre");
            Taxonomies.Add("Measure.Tovbe");
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

        public void SaveXML()
        {
            SampleSOA.CapabilityScope.Locations[0].Address.City = City;

            SampleSOA.Ab_ID = "a";
            SampleSOA.Ab_Logo_Signature = "a";
            SampleSOA.Scope_ID_Number = "a";
            SampleSOA.Criteria = "a";
            SampleSOA.EffectiveDate = "a";
            SampleSOA.ExpirationDate = "a";
            //SampleSOA.Statement = Statement;
            SampleSOA.CapabilityScope.MeasuringEntity = "a";
            SampleSOA.CapabilityScope.Locations[0].id = "a";
            SampleSOA.CapabilityScope.Locations[0].ContactName = "a";
            //SampleSOA.CapabilityScope.Locations[0].ContactInfo = Contact_info;
            SampleSOA.CapabilityScope.Locations[0].Address.Street = "a";
            //SampleSOA.CapabilityScope.Locations[0].Address.City = City;
            SampleSOA.CapabilityScope.Locations[0].Address.State = "a";
            SampleSOA.CapabilityScope.Locations[0].Address.Zip = "a";

            SampleSOA.writeTo(doc);

            doc.Save(@"C:\Temp\MySample.xml");


        }

        public void LoadPageOne()
        {
            ActivateItem(new PageOneViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new PageTwoViewModel());
        }


        public string SelectedPage
        {
            get { return _selectedPage; }
            set
            {
                _selectedPage = value;
                if (string.Equals(value, "Source"))
                {
                    foreach (string str in Taxonomies)
                    {
                        if (str.StartsWith("Source"))
                        {
                            SelectedTaxonomy.Add(str);
                        }
                    }
                    LoadPageOne();
                }
                else if (string.Equals(value, "Measure"))
                {
                    foreach (string str in Taxonomies)
                    {
                        if (str.StartsWith("Measure"))
                        {
                            SelectedTaxonomy.Add(str);
                        }
                    }
                    LoadPageTwo();
                }
                NotifyOfPropertyChange(() => SelectedPage);
            }
        }

        public BindableCollection<string> Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }

        public BindableCollection<string> SelectedTaxonomy
        {
            get { return _selectedTaxonomy; }
            set { _selectedTaxonomy = value; }
        }

        public BindableCollection<string> Taxonomies
        {
            get { return _taxonomies; }
            set { _taxonomies = value; }
        }

    }
}
