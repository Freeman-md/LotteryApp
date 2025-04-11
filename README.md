# Lottery Number Generator

A minimal lottery number generator built with Razor Pages in .NET

## 💡 Features

- Generates 6 **unique** random numbers between **1 and 49**
- Sorts the numbers in ascending order
- Assigns a background color based on number range:
  - 1–9: Grey
  - 10–19: Blue
  - 20–29: Pink
  - 30–39: Green
  - 40–49: Yellow
- Generates a **bonus ball** that is not part of the main numbers
- Simple web UI with minimal styling
- Core logic tested with **xUnit**

## 🧠 Design Notes

- Logic is abstracted into a service class (`LotteryNumberGenerator`) for testability and separation of concerns
- Used `HashSet` for uniqueness and `List.Sort()` for ordering
- Background color logic handled via a helper method
- Set up manually without Razor scaffolding to show deeper understanding

## 🚀 How to Run

```bash
dotnet run --project LotteryApp
