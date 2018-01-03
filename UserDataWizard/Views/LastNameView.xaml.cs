﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PersonDataWizard.ViewModels;

namespace PersonDataWizard.Views
{
  public partial class LastNameView : UserControl
  {
    public LastNameView()
    {
      InitializeComponent();
    }
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
      LastNameTextBox.Focus();
      LastNameTextBox.Focusable = true;
      Keyboard.Focus(LastNameTextBox);

      MainWindowViewModel.IsNextEnable = MainWindowViewModel.User.LastName != null;
    }
  }
}