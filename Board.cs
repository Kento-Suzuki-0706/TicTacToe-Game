using System;
using System.IO;
using System.Text.Json;
using IFN563_N1109119_Final;
namespace IFN563_N1109119_Final
{
    [Serializable]
    public class Board : IBoard
    {
        private int[] cells;
        private Stack<int[]> undoStack;
        private Stack<int[]> redoStack;

        public Board()
        {
            cells = new int[9];
            undoStack = new Stack<int[]>();
            redoStack = new Stack<int[]>();
        }

        public void Display()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($" {cells[0]} | {cells[1]} | {cells[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {cells[3]} | {cells[4]} | {cells[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {cells[6]} | {cells[7]} | {cells[8]} ");
            Console.WriteLine("-------------------------------------------");
        }

        public bool UpdateBoard(int cell, int number, int player)
        {
            if (cells[cell - 1] == 0)
            {
                // Save the current state before making changes
                undoStack.Push((int[])cells.Clone());
                // Clear the redo stack when a new move is made
                redoStack.Clear();

                cells[cell - 1] = number;
                return true;
            }
            return false;
        }

        public bool Undo()
        {
            if (undoStack.Count > 0)
            {
                // Save the current state before undoing
                redoStack.Push((int[])cells.Clone());
                cells = undoStack.Pop();
                return true;
            }
            return false;
        }

        public bool Redo()
        {
            if (redoStack.Count > 0)
            {
                // Save the current state before redoing
                undoStack.Push((int[])cells.Clone());
                cells = redoStack.Pop();
                return true;
            }
            return false;
        }

        public bool CheckWins(int player)
        {
            int[][] winningCombinations = new int[][]
            {
            new int[] { cells[0], cells[1], cells[2] },
            new int[] { cells[3], cells[4], cells[5] },
            new int[] { cells[6], cells[7], cells[8] },
            new int[] { cells[0], cells[3], cells[6] },
            new int[] { cells[1], cells[4], cells[7] },
            new int[] { cells[2], cells[5], cells[8] },
            new int[] { cells[0], cells[4], cells[8] },
            new int[] { cells[2], cells[4], cells[6] }
            };

            foreach (int[] combination in winningCombinations)
            {
                if (Array.TrueForAll(combination, x => x != 0) && GetSum(combination) == 15)
                {
                    return true;
                }
            }

            return false;
        }

        private int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }
    }

}

