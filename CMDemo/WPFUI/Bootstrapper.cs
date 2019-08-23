using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFUI.ViewModels;

namespace WPFUI
{
    public class Bootstrapper : BootstrapperBase // using Caliburn.Micro // must be added
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>(); // we want this code to run on startup // using WPFUI.ViewModels; must be added
        }

    }
}
