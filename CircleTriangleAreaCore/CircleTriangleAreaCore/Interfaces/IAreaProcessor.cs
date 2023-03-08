using CircleTriangleAreaCore.Domain;

namespace CircleTriangleAreaCore.Interfaces;

public interface IAreaProcessor
{
    public Task<double> GetArea(Shape shapeData);
}