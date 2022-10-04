using System;

namespace Tags.Argparse.Exceptions;

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