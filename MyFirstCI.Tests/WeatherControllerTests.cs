using MyFirstCI.Api.Controllers;
using Xunit;
using System.Linq;
using System;

namespace MyFirstCI.Tests;

public class WeatherControllerTests
{
    [Fact]
    public void Get_ReturnsFiveForecasts()
    {
        // Arrange
        var controller = new WeatherController();

        // Act
        var result = controller.Get();

        // Assert
        Assert.Equal(5, result.Length);
    }

    [Fact]
    public void AllForecastsInFuture()
    {
        // Arrange
        var controller = new WeatherController();
        var today = DateOnly.FromDateTime(DateTime.Now);

        // Act
        var result = controller.Get();

        // Assert
        foreach (var forecast in result)
        {
            Assert.True(forecast.Date >= today);
        }
    }
    [Fact]
public void AlwaysRedTest()
{
    Assert.True(false);
}
}