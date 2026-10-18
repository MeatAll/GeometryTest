using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace GeometryApp.Presenters;

internal class TriangleCreationPresenter : ShapeCreationPresenter
{
    public override string ButtonText => "Triangle";
    public override IReadOnlyList<string> PointsInsertTooltips => ["Выберите первую точку", "Выберите вторую точку", "Выберите третью точку"];
    protected override Geometry CreateGeometry(Point[] points)
    {
        var gg = new GeometryGroup();
        var l1 = new LineGeometry(points[0], points[1]);
        gg.Children.Add(l1);
        var l2 = new LineGeometry(points[1], points[2]);
        gg.Children.Add(l2);
        var l3 = new LineGeometry(points[0], points[2]);
        gg.Children.Add(l3);
        return gg;
    }
}
