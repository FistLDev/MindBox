namespace CircleTriangleAreaCore.Domain;

public class Triangle : Shape
{
    public double FirstSide { get; private set; }
    public double SecondSide { get; private set; }
    public double ThirdSide { get; private set; }

    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        FirstSide = firstSide;
        SecondSide = secondSide;
        ThirdSide = thirdSide;
    }
}