using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_GameOfLife
{
    internal class Cell
    {
        public bool IsAlive;
        public string aliveSymbol = "O";
        public string deadSymbol = "-";

        /// <summary>
        /// default: has default alive/dead symbols ("[X]" and "[ ]"). has a 30% chance to be alive when created.
        /// </summary>
        public Cell() 
        {
            
            if (Random.Shared.Next(0, 3) == 0)
            {
                IsAlive = true;
            }
            else IsAlive = false;
        }

        /// <summary>
        /// initialize alive or dead cell
        /// </summary>
        /// <param name="status"></param>
        public Cell(bool status) 
        {
            IsAlive = status;
        }

        /// <summary>
        /// Specifies alive/dead symbol, but randomizes state
        /// </summary>
        /// <param name="deadSymbol">string representing dead state</param>
        /// <param name="aliveSymbol">string representing alive state</param>
        public Cell(string deadSymbol, string aliveSymbol)
        {
            this.deadSymbol = deadSymbol;
            this.aliveSymbol = aliveSymbol;

            if (Random.Shared.Next(0, 3) == 0)
            {
                IsAlive = true;
            }
            else IsAlive = false;
        }

        /// <summary>
        /// Initializes a cell with a custom alive/dead symbol, and specifies if this cell is alive/dead
        /// </summary>
        /// <param name="deadSymbol"></param>
        /// <param name="aliveSymbol"></param>
        /// <param name="isAlive"></param>
        public Cell(string deadSymbol, string aliveSymbol, bool isAlive)
        {
            this.deadSymbol = deadSymbol;
            this.aliveSymbol = aliveSymbol;

            if (isAlive)
            {
                IsAlive = true;
            }
            else IsAlive = false;

        }

        /// <summary>
        /// Counts all neighbors of a target cell and returns the number of alive neighbors
        /// </summary>
        /// <param name="X">X coordinate (from top left) of cell to search neighbors of</param>
        /// <param name="Y">Y coordinate (from top left) of cell to search neighbors of</param>
        /// <param name="board"> current board as 2D array</param>
        /// <param name="boardWidth"> width of passed board array</param>
        /// <param name="boardHeight">height of passed board array</param>
        /// <returns></returns>
        public int CountAllNeighbors(int X, int Y, Cell[,] board,int boardWidth,int boardHeight)
        {
            int aliveNeighbors = 0;

            //if (ValidTarget(X - 1, Y - 1, boardWidth, boardHeight)) { Console.WriteLine("valid target!"); }

            //check top left --> bottom right like a book
            // whats the opposite of a magnus opus...?
            if (ValidTarget(X - 1, Y - 1, boardWidth, boardHeight))
            {
                if (board[Y - 1, X - 1].IsAlive) { aliveNeighbors++; }
            }
            if (ValidTarget(X, Y - 1, boardWidth, boardHeight))
            {
                if (board[Y - 1, X].IsAlive) { aliveNeighbors++; }
            }
            if (ValidTarget(X + 1, Y - 1, boardWidth, boardHeight))
            {
                if (board[Y-1, X+1].IsAlive) { aliveNeighbors++; }
            }
            if (ValidTarget(X - 1, Y, boardWidth, boardHeight))
            {
                if (board[Y, X-1].IsAlive) { aliveNeighbors++; }
            }
            if (ValidTarget(X + 1, Y, boardWidth, boardHeight))
            {
                if (board[Y, X+1].IsAlive) { aliveNeighbors++; }
            }
            if (ValidTarget(X - 1, Y + 1, boardWidth, boardHeight))
            {
                if (board[Y+1, X-1].IsAlive) { aliveNeighbors++; }
            }
            if (ValidTarget(X, Y + 1, boardWidth, boardHeight))
            {
                if (board[Y+1,X].IsAlive) { aliveNeighbors++; }
            }
            if (ValidTarget(X + 1, Y + 1, boardWidth, boardHeight))
            {
                if (board[Y+1, X+1].IsAlive) { aliveNeighbors++; }
            }

            return aliveNeighbors;
        }

        /// <summary>
        /// helper function for CountAllNeighbors(). Checks to see if target neighbor cell is valid to
        /// prevent indexOutOfRange exceptions.
        /// </summary>
        /// <param name="X">X coordinate (from top left) of cell who's neighbors are being searched </param>
        /// <param name="Y">Y coordinate (from top left) of cell who's neighbors are being searched</param>
        /// <param name="boardWidth"></param>
        /// <param name="boardHeight"></param>
        /// <returns></returns>
        public bool ValidTarget(int X, int Y, int boardWidth, int boardHeight)
        {
            if ((X < 0 || X >= boardWidth) || (Y < 0 || Y >= boardHeight))
            {
                return false;
            }

            else return true;
        }

        /// <summary>
        /// sets IsAlive to false (dead)
        /// </summary>
        public void Die()
        {
            IsAlive = false;
        }

        /// <summary>
        /// sets IsAlive to true (alive) (shocker)
        /// </summary>
        public void Live()
        {
            IsAlive = true;
        }

        /// <summary>
        /// ToString Override
        /// </summary>
        /// <returns> Alive/Dead string representation depending on cell state</returns>
        public override string ToString()
        {
            if (IsAlive)
            {
                return aliveSymbol;
            }
            else return deadSymbol;
        }
    }
}
