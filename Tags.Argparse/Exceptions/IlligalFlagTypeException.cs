using System;

namespace Tags.Argparse.Exceptions;

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