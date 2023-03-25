using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using Avalonia.Controls;
using Avalonia.Interactivity;
using gn.Models;
using gn.Services;
using gn.ViewModels;

namespace gn.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        Database db = new Database();
        DataContext = new MainWindowViewModel(db);
        InitializeComponent();
    }
}