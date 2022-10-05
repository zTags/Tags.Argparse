using System;

namespace Tags.Argparse.Exceptions;

/// <summary>
/// Thrown if there was an Argument that wasn't of type string
/// </summary>
public class IlligalArgumentTypeException : Exception {
    public IlligalArgumentTypeException()
        : base()
    {

    }

    public IlligalArgumentTypeException(string help)
        : base(help)
    {

    }

    public IlligalArgumentTypeException(string help, Exception inner)
        : base(help, inner)
    {

    }
}