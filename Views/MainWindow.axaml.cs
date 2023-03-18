using Avalonia.Controls;
using Mapsui;
using Mapsui.Layers;
using Mapsui.Tiling;
using gn.Mapsui;

namespace gn.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
      InitializeComponent();
      //mapControl.Map = new MapWritable(Default.defLocation);
    } 

}