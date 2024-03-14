using System;
using System.IO;
using System.Text.Json;
using IFN563_N1109119_Final;
namespace IFN563_N1109119_Final
{
    public interface IBoard
    {
        void Display();
        bool UpdateBoard(int cell, int number, int player);
        bool Undo();
        bool Redo();
        bool CheckWins(int player);
    }
}

