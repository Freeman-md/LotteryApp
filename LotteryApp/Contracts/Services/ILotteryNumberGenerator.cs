namespace LotteryApp.Contracts.Services;

public interface ILotteryNumberGenerator {
    public HashSet<int> GenerateUniqueNumbers();

    public int GenerateBonusBall(HashSet<int> existingNumbers);

    public string GetColorClass(int number);

    public List<int> SortNumbers(List<int> numbers);
}