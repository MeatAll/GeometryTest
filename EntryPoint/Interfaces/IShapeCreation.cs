using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace GeometryApp.Interfaces;

public interface IShapeCreation
{
    string ButtonText { get; }
    IReadOnlyList<string> PointsInsertTooltips { get; }
    Geometry Create(Point[] points);
}
