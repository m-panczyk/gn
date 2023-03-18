using Mapsui;
using Mapsui.Layers;
using Mapsui.Tiling;
using Mapsui.Nts;
//Map class with writable layer and OSM layer
namespace gn.Mapsui;
public class MapWritable : Map
{
    
    private WritableLayer writableLayer
    {
        get
        {
            return (WritableLayer)this.Layers[1];
        }
    } 
    public MapWritable()
    {
        Init();
    }
    public MapWritable(MPoint location)
    {
        Init();
        this.writableLayer.Add(new PointFeature(location));
    }
    public MapWritable(MPoint[] locations)
    {
        Init();
        foreach (MPoint location in locations)
        {
            this.writableLayer.Add(new PointFeature(location));
        }
    }
    private void Init(){
        this.Layers.Add(OpenStreetMap.CreateTileLayer());
        this.Layers.Add(new WritableLayer());

    }

}