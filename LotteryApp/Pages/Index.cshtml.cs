using LotteryApp.Contracts.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel {
    private readonly ILotteryNumberGenerator _lotteryNumberGenerator;
    public List<int> MainNumbers { get; set; }
public int BonusBall { get; set; }

    public IndexModel(ILotteryNumberGenerator lotteryNumberGenerator) {
        _lotteryNumberGenerator = lotteryNumberGenerator;
    }
    public void OnGet() {
        var mainNumbers = _lotteryNumberGenerator.GenerateUniqueNumbers();
        var sortedNumbers = _lotteryNumberGenerator.SortNumbers(mainNumbers.ToList());
        var bonusBall = _lotteryNumberGenerator.GenerateBonusBall(sortedNumbers);

        MainNumbers = sortedNumbers;
        bonusBall = BonusBall;
    }
}