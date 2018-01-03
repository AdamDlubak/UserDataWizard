using System.Windows;
using System.Windows.Controls;
using PersonDataWizard.ViewModels;

namespace PersonDataWizard.Views
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomeView : UserControl
  {
        public WelcomeView()
        {
            InitializeComponent();
        }
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
      MainWindowViewModel.IsPreviousEnable = false;
      MainWindowViewModel.IsNextEnable = true;


    }
  }
}
