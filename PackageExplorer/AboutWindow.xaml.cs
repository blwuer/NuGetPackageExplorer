﻿using System.Reflection;
using System.Windows;
using System.Windows.Documents;
using StringResources = PackageExplorer.Resources;

namespace PackageExplorer
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : StandardDialog
    {
    
#if   STORE
      const string Channel = "Store";
#elif NIGHTLY
      const string Channel = "Nightly";
#elif CHOCO
      const string Channel = "Chocolatey";
#else
      const string Channel = "Zip";
#endif

        public AboutWindow()
        {
            InitializeComponent();

            ProductTitle.Text = $"{StringResources.Dialog_Title} - {Channel} - ({ typeof(AboutWindow).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion})";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var link = (Hyperlink)sender;
            UriHelper.OpenExternalLink(link.NavigateUri);
        }
    }
}
