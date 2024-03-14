using System;
namespace IFN563_N1109119_Final
{
    public class HumanPlayer : IPlayer
    {
        private HashSet<int> availableNumbers;

        public HumanPlayer(IEnumerable<int> numbers)
        {
            availableNumbers = new HashSet<int>(numbers);
        }

        public int ChooseCell()
        {
            int cell = 0;
            bool success = false;

            while (!success)
            {
                Console.WriteLine("First Player - Odd | Second Player - Even");
                DisplayCellNumbers();
                Console.WriteLine("Enter a cell number (1-9): ");
                Console.WriteLine("-------------------------------------------");
                success = int.TryParse(Console.ReadLine(), out cell);

                if (!success)
                {
                    Console.WriteLine("Invalid input. Only numbers are allowed.");
                    Console.WriteLine("-------------------------------------------");
                    continue;
                }

                if (cell < 1 || cell > 9)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                    success = false;
                }
            }

            return cell;
        }

        private void DisplayCellNumbers()
        {
            Console.WriteLine("Cell numbers:");
            Console.WriteLine(" 1 | 2 | 3 ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" 4 | 5 | 6 ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" 7 | 8 | 9 ");
            Console.WriteLine("-------------------------------------------");
        }

        public int ChooseNumber()
        {
            int number = 0;
            bool success = false;

            while (!success)
            {
                Console.WriteLine("Enter a number to place in the cell: ");
                Console.WriteLine("-------------------------------------------");
                success = int.TryParse(Console.ReadLine(), out number);

                if (!success || !availableNumbers.Contains(number))
                {
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine($"Invalid input. Please enter an available {GetNumberType()} number.");
                    success = false;
                }
                else
                {
                    availableNumbers.Remove(number);
                }
            }

            return number;
        }

        private string GetNumberType()
        {
            return availableNumbers.Min() % 2 == 0 ? "even" : "odd";
        }

        public void SetAvailableNumbers(List<int> numbers)
        {
            availableNumbers = new HashSet<int>(numbers);
        }
    }

}

