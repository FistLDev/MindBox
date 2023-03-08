namespace CircleTriangleAreaCore.Domain;

public class Circle : Shape
{
    public readonly double Radius;

    public Circle(double radius)
    {
        Radius = radius;
    }
}