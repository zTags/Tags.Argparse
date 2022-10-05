using Example.Simple;
using Tags.Argparse;

SimpleProgram arguments = Parser<SimpleProgram>
    .Create()
    .doHelpOnEmptyArgs(true)
    .Parse(args);

Console.WriteLine($"use fullscreen: {arguments.Fullscreen}");
Console.WriteLine($"Width: {arguments.Width}");
Console.WriteLine($"Height: {arguments.Height}");