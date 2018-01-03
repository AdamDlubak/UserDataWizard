using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UserDataWizard.Helpers;
using UserDataWizard.ViewModels;

namespace UserDataWizard.Views
{
  public partial class FirstNameView : UserControl
  {
    public FirstNameView()
    {
      InitializeComponent();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
      FirstName.Focus();
      FirstName.Focusable = true;
      Keyboard.Focus(FirstName);

      MainWindowViewModel.IsNextEnable = MainWindowViewModel.PageValidation.FirstName;
      MainWindowViewModel.IsPreviousEnable = true;
    }
  }
}