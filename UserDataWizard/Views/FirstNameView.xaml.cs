using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
      FirstNameTextBox.Focus();
      FirstNameTextBox.Focusable = true;
      Keyboard.Focus(FirstNameTextBox);

      MainWindowViewModel.IsNextEnable = MainWindowViewModel.User.FirstName != null;
      MainWindowViewModel.IsPreviousEnable = true;

    }


  }
}