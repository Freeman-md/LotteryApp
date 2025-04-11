using LotteryApp.Contracts.Services;
using LotteryApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddScoped<ILotteryNumberGenerator, LotteryNumberGenerator>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();
