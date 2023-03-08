using AutoFixture;

using CircleTriangleAreaCore;
using CircleTriangleAreaCore.Domain;
using CircleTriangleAreaCore.Interfaces;

using CircleTriangleAreaCoreUnitTests.Contracts;

namespace CircleTriangleAreaCoreUnitTests;

public sealed class UnitTests
{
    private IFixture _fixture = new Fixture();
    private AreaProcessor _areaProcessor = new AreaProcessor();

    [Fact]
    public async Task GetCircleArea_Success()
    {
        var circle = new Circle(_fixture.Create<double>());

        double result = await _areaProcessor.GetArea(circle);
        double expectedResult = Math.PI * Math.Pow(circle.Radius, 2);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public async Task GetTriangleArea_Success()
    {
        var triangle = new Triangle(_fixture.Create<double>(), _fixture.Create<double>(), _fixture.Create<double>());

        double result = await _areaProcessor.GetArea(triangle);
        double halfMeter = (triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide) / 2;
        double expectedResult = Math.Sqrt(halfMeter * (halfMeter - triangle.FirstSide) * (halfMeter - triangle.SecondSide) * (halfMeter - triangle.ThirdSide));

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public async Task GetRectangularTriangleArea_Success()
    {
        var triangle = new Triangle(0.1, 0.1, 0.14);

        double result = await _areaProcessor.GetArea(triangle);

        double expectedResult = triangle.FirstSide * triangle.SecondSide / 2;

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public async Task GetArea_NotExpectedShapeType_Failed()
    {
        var square = new Square();

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _areaProcessor.GetArea(square));
    }
}