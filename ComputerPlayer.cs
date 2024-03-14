using System;
using System.IO;
using System.Text.Json;
using IFN563_N1109119_Final;
namespace IFN563_N1109119_Final
{
    public class ComputerPlayer : IPlayer
    {
        private Random random;
        private HashSet<int> availableNumbers;

        public ComputerPlayer(IEnumerable<int> numbers)
        {
            random = new Random();
            availableNumbers = new HashSet<int>(numbers);
        }

        public int ChooseCell()
        {
            return random.Next(1, 10);
        }

        public int ChooseNumber()
        {
            int number = random.Next(1, 10);
            while (!availableNumbers.Contains(number))
            {
                number = random.Next(1, 10);
            }
            availableNumbers.Remove(number);
            Console.WriteLine($"Computer chose an {GetNumberType()} number: {number}");
            Console.WriteLine("-------------------------------------------");
            return number;
        }

        private string GetNumberType()
        {
            return availableNumbers.Min() % 2 == 0 ? "even" : "odd";
        }
    }
}

