using System;

namespace Tags.Argparse.Exceptions;

/// <summary>
/// Thrown if there was an Flag that wasn't of type bool
/// </summary>
public class IlligalFlagTypeException : Exception {
    public IlligalFlagTypeException()
        : base()
    {

    }

    public IlligalFlagTypeException(string help)
        : base(help)
    {

    }

    public IlligalFlagTypeException(string help, Exception inner)
        : base(help, inner)
    {

    }
}