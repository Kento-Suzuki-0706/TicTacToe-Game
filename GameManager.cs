using System;
using System.IO;
using System.Text.Json;
using IFN563_N1109119_Final;
namespace IFN563_N1109119_Final
{
    public class GameManager : IGameManager
    {
        private Board board;
        private IPlayer[] players;
        private int currentPlayer;
        private int turns;
        private FileSaver fileSaver;

        public GameManager()
        {
            fileSaver = new FileSaver();
            board = new Board();
            players = new IPlayer[2];
        }

        public async Task StartGame()
        {
            players[0] = new HumanPlayer(new List<int> { 1, 3, 5, 7, 9 });
            players[1] = ChooseOpponent();

            currentPlayer = ChooseWhoGoesFirst();
            AssignNumbersToPlayers();
            turns = 0;
            bool gameEnded = false;

            while (!gameEnded)
            {
                board.Display();

                Console.WriteLine("Type 'undo' to undo, 'redo' to redo, 'help' to display help,\n 'save' to save game, 'load' to load game, or press Enter to continue:");
                Console.WriteLine("-------------------------------------------------------------");
                string input = Console.ReadLine();

                if (input.ToLower() == "help")
                {
                    await DisplayHelpAsync();
                    continue;
                }
                else if (input.ToLower() == "undo")
                {
                    if (board.Undo())
                    {
                        turns--;
                        currentPlayer = (currentPlayer + 1) % 2;
                    }
                    continue;
                }
                else if (input.ToLower() == "redo")
                {
                    if (board.Redo())
                    {
                        turns++;
                        currentPlayer = (currentPlayer + 1) % 2;
                    }
                    continue;
                }
                if (input.ToLower() == "save")
                {
                    SaveGame();
                    continue;
                }
                else if (input.ToLower() == "load")
                {
                    LoadGame();
                    continue;
                }

                int cell = players[currentPlayer].ChooseCell();
                int number = players[currentPlayer].ChooseNumber();

                if (board.UpdateBoard(cell, number, currentPlayer))
                {
                    turns++;

                    if (board.CheckWins(currentPlayer) || turns == 9)
                    {
                        board.Display();
                        Console.WriteLine(turns == 9 ? "Draw" : $"Player {currentPlayer + 1} won!");
                        gameEnded = true;
                    }
                    else
                    {
                        currentPlayer = (currentPlayer + 1) % 2;
                    }
                }
            }
        }

        public IPlayer ChooseOpponent()
        {
            int choice = 0;
            while (choice < 1 || choice > 2)
            {
                Console.WriteLine("Choose opponent:\n1. Human\n2. Computer");
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
                {
                    Console.WriteLine("Invalid input. Please choose 1 for Human or 2 for Computer.");
                    Console.WriteLine("-------------------------------------------");
                }
            }

            if (choice == 1)
            {
                return new HumanPlayer(new List<int> { 2, 4, 6, 8 });
            }
            else
            {
                return new ComputerPlayer(new List<int> { 2, 4, 6, 8 });
            }
        }

        public int ChooseWhoGoesFirst()
        {
            int choice = 0;
            while (choice < 1 || choice > 2)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Who goes first?\n1. Player 1\n2. Player 2");
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
                {
                    Console.WriteLine("Invalid input. Please choose 1 for Player 1 or 2 for Player 2.");
                    Console.WriteLine("-------------------------------------------");
                }
            }

            return choice - 1;
        }


        public async Task DisplayHelpAsync()
        {
            HelpSystem helpSystem = new HelpSystem();
            string helpContent = await helpSystem.GetHelpAsync();
            Console.WriteLine(helpContent);
        }
        public void SaveGame()
        {
            fileSaver.SaveGame(board);
        }

        public void LoadGame()
        {
            Board? loadedBoard = fileSaver.LoadGame();
            if (loadedBoard != null)
            {
                board = loadedBoard;
            }
        }

        private void AssignNumbersToPlayers()
        {
            List<int> oddNumbers = new List<int> { 1, 3, 5, 7, 9 };
            List<int> evenNumbers = new List<int> { 2, 4, 6, 8 };

            if (currentPlayer == 0)
            {
                (players[0] as HumanPlayer)?.SetAvailableNumbers(oddNumbers);
                (players[1] as HumanPlayer)?.SetAvailableNumbers(evenNumbers);
            }
            else
            {
                (players[0] as HumanPlayer)?.SetAvailableNumbers(evenNumbers);
                (players[1] as HumanPlayer)?.SetAvailableNumbers(oddNumbers);
            }
        }

    }

}

