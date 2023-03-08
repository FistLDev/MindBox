using CircleTriangleAreaCore.Domain;
using CircleTriangleAreaCore.Interfaces;

namespace CircleTriangleAreaCore;

public sealed class AreaProcessor : IAreaProcessor
{
    private const int DoubleDegree = 2;

    public Task<double> GetArea(Shape shapeData)
    {
        double result = shapeData switch
        {
            Circle circle => GetCircleArea(circle),
            Triangle triangle => GetTriangleArea(triangle),
            _ => throw new ArgumentOutOfRangeException(nameof(shapeData))
        };

        return Task.FromResult(result);
    }

    private double GetTriangleArea(Triangle triangle)
    {
        if (IsRectangularTriangle(triangle, out double rectangularTriangleArea))
        {
            return rectangularTriangleArea;
        }

        double halfMeter = (triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide) / 2;
        double area = Math.Sqrt(halfMeter * (halfMeter - triangle.FirstSide) * (halfMeter - triangle.SecondSide) * (halfMeter - triangle.ThirdSide));

        return area;
    }

    private double GetCircleArea(Circle circle)
    {
        double area = Math.PI * Math.Pow(circle.Radius, DoubleDegree);

        return area;
    }

    private bool IsRectangularTriangle(Triangle triangle, out double area)
    {
        area = 0;

        double[] sides = {triangle.FirstSide, triangle.SecondSide, triangle.ThirdSide};
        double potentialHypotenuse = sides.Max();
        double[] potentialCathets = sides.Where(side => Math.Abs(side - potentialHypotenuse) > 0.001).ToArray();

        if (Math.Abs(Math.Pow(potentialHypotenuse, DoubleDegree) - (Math.Pow(potentialCathets[0], DoubleDegree) + Math.Pow(potentialCathets[1], DoubleDegree))) < 0.001)
        {
            area = potentialCathets[0] * potentialCathets[1] / 2;

            return true;
        }

        return false;
    }
}