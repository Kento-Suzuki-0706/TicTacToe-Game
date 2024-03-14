using System;
using System.IO;
using System.Text.Json;
using IFN563_N1109119_Final;

namespace IFN563_N1109119_Final
{
    public class NumericalTicTacToeGame
    {
        static async Task Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            await gameManager.StartGame();
        }
    }
}