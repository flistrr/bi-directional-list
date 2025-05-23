using System;

namespace BiDirectionalList.Exceptions;

public class EmptyListException : Exception
{
    public EmptyListException() { }
    public EmptyListException(string message) : base(message) { }
    public EmptyListException(string message, Exception inner) : base(message, inner) { }
}
