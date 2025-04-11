using LotteryApp.Contracts.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly ILotteryNumberGenerator _lotteryNumberGenerator;
    public List<int> MainNumbers { get; set; } = new List<int>();
    public int BonusBall { get; set; }

    public IndexModel(ILotteryNumberGenerator lotteryNumberGenerator)
    {
        _lotteryNumberGenerator = lotteryNumberGenerator;
    }
    public void OnGet()
    {
        var mainNumbers = _lotteryNumberGenerator.GenerateUniqueNumbers();
        var sortedNumbers = _lotteryNumberGenerator.SortNumbers(mainNumbers.ToList());
        var bonusBall = _lotteryNumberGenerator.GenerateBonusBall(sortedNumbers);

        MainNumbers = sortedNumbers;
        BonusBall = bonusBall;
    }

    public string GetColorClass(int number)
    {
        return _lotteryNumberGenerator.GetColorClass(number);
    }

}