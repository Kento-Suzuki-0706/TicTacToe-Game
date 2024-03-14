using System;
using System.IO;
using System.Text.Json;
using IFN563_N1109119_Final;

namespace IFN563_N1109119_Final
{
    public class FileSaver
    {
        private const string FileName = "TicTacToe_Save.dat";

        public void SaveGame(Board board)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(board);
                File.WriteAllText(FileName, jsonString);
                Console.WriteLine("Game saved successfully!");
                Console.WriteLine("-------------------------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving game: " + e.Message);
                Console.WriteLine("-------------------------------------------");
            }
        }

        public Board? LoadGame()
        {
            try
            {
                if (File.Exists(FileName))
                {
                    string jsonString = File.ReadAllText(FileName);
                    Board? loadedBoard = JsonSerializer.Deserialize<Board>(jsonString);
                    Console.WriteLine("Game loaded successfully!");
                    Console.WriteLine("-------------------------------------------");
                    return loadedBoard;
                }
                else
                {
                    Console.WriteLine("No saved game found.");
                    Console.WriteLine("-------------------------------------------");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error loading game: " + e.Message);
                Console.WriteLine("-------------------------------------------");
                return null;
            }
        }
    }
}



