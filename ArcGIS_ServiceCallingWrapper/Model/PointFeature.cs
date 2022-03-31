namespace ArcGIS_ServiceCallingWrapper.Model
{
    public class PointFeature : Feature
    {
        public PointGeometry Geometry { get; set; }
    }

    public class PointGeometry
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
