using System.Windows;
using UserDataWizard.ViewModels;

namespace UserDataWizard.Views
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {

      InitializeComponent();
      this.DataContext = new MainWindowViewModel();
    }
  }
}
