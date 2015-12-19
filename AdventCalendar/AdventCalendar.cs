using System;
using Day1;
using Day2;
using Day3;
using Day4;
using Day5;

namespace AdventCalendar
{
    internal sealed class AdventCalendar
    {
        private static void Main()
        {
            var day1Solution = new Day1Solution();
            PrintAnswer(1, 1, day1Solution.SolvePart1());
            PrintAnswer(1, 2, day1Solution.SolvePart2());

            var day2Solution = new Day2Solution();
            PrintAnswer(2, 1, day2Solution.SolvePart1());
            PrintAnswer(2, 2, day2Solution.SolvePart2());

            var day3Solution = new Day3Solution();
            PrintAnswer(3, 1, day3Solution.SolvePart1());
            PrintAnswer(3, 2, day3Solution.SolvePart2());

            var day4Solution = new Day4Solution();
            PrintAnswer(4, 1, day4Solution.SolvePart1());
            PrintAnswer(4, 2, day4Solution.SolvePart2());

            var day5Solution = new Day5Solution();
            PrintAnswer(5, 1, day5Solution.SolvePart1());
            PrintAnswer(5, 2, day5Solution.SolvePart2());
        }

        private static void PrintAnswer(int day, int part, int answer)
        {
            Console.WriteLine($"The answer to Day {day} Part {part} is {answer}");
        }
    }
}
