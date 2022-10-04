using System;

namespace Tags.Argparse.Exceptions;

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