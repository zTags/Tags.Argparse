using Example.Simple;
using Tags.Argparse;

SimpleProgram arguments = Parser<SimpleProgram>
    .Create()
    .doHelpOnEmptyArgs(true)
    .Parse(args);

Console.WriteLine($"use fullscreen: {arguments.Fullscreen}");