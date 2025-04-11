using LotteryApp.Contracts.Services;

namespace LotteryApp.Services;

public class LotteryNumberGenerator : ILotteryNumberGenerator
{
    public LotteryNumberGenerator() {

    }
    
    public int GenerateBonusBall(HashSet<int> existingNumbers)
    {
        throw new NotImplementedException();
    }

    public HashSet<int> GenerateUniqueNumbers()
    {
        throw new NotImplementedException();
    }

    public string GetColorClass(int number)
    {
        throw new NotImplementedException();
    }

    public List<int> SortNumbers(List<int> numbers)
    {
        throw new NotImplementedException();
    }
}