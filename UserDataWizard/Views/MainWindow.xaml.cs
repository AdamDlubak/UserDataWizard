using System.Windows;
using UserDataWizard.ViewModels;

namespace UserDataWizard.Views
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      DataContext = new MainWindowViewModel();
    }
  }
}