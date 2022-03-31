using System.Collections.Generic;

namespace ArcGIS_ServiceCallingWrapper.Model
{
    public class AllDataTypes
    {
        public IEnumerable<PointFeature> Points { get; set; }
        public IEnumerable<LineFeature> Lines { get; set; }
        public IEnumerable<PolygonFeature> Polygons { get; set; }
        public IEnumerable<TableFeature> Tables { get; set; }

        public AllDataTypes(IEnumerable<PointFeature> _points, IEnumerable<LineFeature> _lines, 
            IEnumerable<PolygonFeature> _polygons, IEnumerable<TableFeature> _tables)
        {
            this.Points = _points;
            this.Lines = _lines;
            this.Polygons = _polygons;
            this.Tables = _tables;
        }
    }
}
