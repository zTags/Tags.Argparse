using System;

namespace Tags.Argparse.Exceptions;

/// <summary>
/// Thrown if there was an Argument without a linked value
/// </summary>
public class NoArgumentValueException : Exception {
    public NoArgumentValueException()
        : base()
    {

    }

    public NoArgumentValueException(string help)
        : base(help)
    {

    }

    public NoArgumentValueException(string help, Exception inner)
        : base(help, inner)
    {

    }
}