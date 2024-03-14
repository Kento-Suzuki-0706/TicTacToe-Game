using System;
using System.IO;
using System.Text.Json;
using IFN563_N1109119_Final;
namespace IFN563_N1109119_Final
{
    public class HelpSystem
    {
        public Task<string> GetHelpAsync()
        {
            return Task.FromResult(GetHelp());
        }

        private string GetHelp()
        {
            string helpContent = @"
Available commands:

undo       - Undo the previous move
redo       - Redo the previously undone move
save       - Save the current game state
load       - Load the previously saved game state
help       - Display this help message

Gameplay:

1. Choose a cell to place your number (1-9)
2. Choose a number to place in the cell (odd numbers for Player 1, even numbers for Player 2)
3. The goal is to have a row, column, or diagonal with a sum of 15
";
            return helpContent;
        }
    }
}

