using Avalonia.Controls;
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