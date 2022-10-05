using System;

namespace Tags.Argparse.Exceptions;

/// <summary>
/// Thrown if you tried to create an Parser with a class without a Program attribute
/// </summary>
public class NoProgramAttributeException : Exception {
    public NoProgramAttributeException()
        : base()
    {

    }

    public NoProgramAttributeException(string help)
        : base(help)
    {

    }

    public NoProgramAttributeException(string help, Exception inner)
        : base(help, inner)
    {

    }
}