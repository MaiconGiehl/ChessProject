using System;

namespace board
{
    internal class BoardException : Exception
    {
        public BoardException(string msg) : base(msg)
        {
        }
    }
}
