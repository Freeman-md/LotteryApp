using LotteryApp.Contracts.Services;

namespace LotteryApp.Services;

public class LotteryNumberGenerator : ILotteryNumberGenerator
{
    private readonly Random _random;

    public LotteryNumberGenerator() {
        _random = new Random();
    }
    
    public int GenerateBonusBall(List<int> existingNumbers)
    {
        int bonus;

        do {
            bonus = _random.Next(1, 50);
        } while (existingNumbers.Contains(bonus));

        return bonus;
    }

    public HashSet<int> GenerateUniqueNumbers()
    {
        var numbers = new HashSet<int>();

        while (numbers.Count < 6) {
            int number = _random.Next(1, 50);
            numbers.Add(number);
        }

        return numbers;
    }

    public string GetColorClass(int number)
    {
        if (number >= 1 && number <= 9) return "bg-grey";
        if (number >= 10 && number <= 19) return "bg-blue";
        if (number >= 20 && number <= 29) return "bg-pink";
        if (number >= 30 && number <= 39) return "bg-green";
        if (number >= 40 && number <= 49) return "bg-yellow";

        // this can as well be done at the top to avoid having to always go through each condition before throwing the exception - for error cases.
        throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 1 and 49.");
    }

    public List<int> SortNumbers(List<int> numbers)
    {
        var sorted = new List<int>(numbers);

        sorted.Sort();
        
        return sorted;
    }
}