using LotteryApp.Contracts.Services;
using LotteryApp.Services;
using Microsoft.AspNetCore.Authentication;

namespace LotteryApp.Tests.Unit.Services;

public class LotteryNumberGeneratorTests
{
    private readonly ILotteryNumberGenerator _lotteryNumberGenerator;
    public LotteryNumberGeneratorTests()
    {
        _lotteryNumberGenerator = new LotteryNumberGenerator();
    }

    [Fact]
    public void GenerateUniqueNumbers_ReturnsExactlySixNumbers()
    {
        const int expectedCount = 6;


        var result = _lotteryNumberGenerator.GenerateUniqueNumbers();


        Assert.Equal(expectedCount, result.Count);
    }

    [Fact]
    public void GenerateUniqueNumbers_ReturnsUniqueNumbersOnly()
    {
        var result = _lotteryNumberGenerator.GenerateUniqueNumbers();


        var uniqueCount = result.Distinct().Count();
        Assert.Equal(result.Count, uniqueCount);
    }

    [Fact]
    public void GenerateUniqueNumbers_ValuesAreWithinRange()
    {
        var result = _lotteryNumberGenerator.GenerateUniqueNumbers();

        Assert.All(result, number =>
        {
            Assert.InRange(number, 1, 49);
        });
    }

    [Fact]
    public void GenerateBonusBall_IsNotInMainNumbers()
    {
        var mainNumbers = _lotteryNumberGenerator.GenerateUniqueNumbers();

        var bonusBall = _lotteryNumberGenerator.GenerateBonusBall(mainNumbers);

        Assert.DoesNotContain(bonusBall, mainNumbers);
        Assert.InRange(bonusBall, 1, 49);
    }

    [Fact]
    public void SortNumbers_ReturnsSortedList()
    {
        var unsorted = new List<int> { 35, 10, 43, 15, 8, 28 };


        var sorted = _lotteryNumberGenerator.SortNumbers(unsorted);


        var expected = unsorted.OrderBy(n => n).ToList();
        Assert.Equal(expected, sorted);
    }

    [Theory]
    [InlineData(1, "bg-grey")]
    [InlineData(9, "bg-grey")]
    [InlineData(10, "bg-blue")]
    [InlineData(19, "bg-blue")]
    [InlineData(20, "bg-pink")]
    [InlineData(29, "bg-pink")]
    [InlineData(30, "bg-green")]
    [InlineData(39, "bg-green")]
    [InlineData(40, "bg-yellow")]
    [InlineData(49, "bg-yellow")]
    public void GetColorClass_ReturnsCorrectClassForValidRanges(int number, string expectedClass)
    {
        var result = _lotteryNumberGenerator.GetColorClass(number);


        Assert.Equal(expectedClass, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(50)]
    [InlineData(-5)]
    public void GetColorClass_ThrowsForInvalidNumber(int number)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _lotteryNumberGenerator.GetColorClass(number));
    }



}