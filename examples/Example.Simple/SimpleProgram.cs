using Tags.Argparse;

namespace Example.Simple;

[Program("Example.Simple")]
public class SimpleProgram {
    // usage: --fullscreen
    [Flag("fullscreen", useShort = false, help = "Run in fullscreen")]
    public bool Fullscreen;

    // usage: -w 1920
    [Argument("width", useShort = true)]
    public int Width;
    
    // usage -h 1080
    [Argument("height", useShort = true)]
    public int Height;

    // put your default values here
    public SimpleProgram() { 
        Fullscreen = false;
        Width = 1280;
        Height = 720;
    }
}