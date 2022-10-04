using System;

namespace Tags.Argparse;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ProgramAttribute : Attribute 
{
    internal string name;
    public double version;
    public bool subcommands;
    
    public ProgramAttribute(string n)
    {
        name = n;
        
        // defaults
        version = 1.0;
    }
}