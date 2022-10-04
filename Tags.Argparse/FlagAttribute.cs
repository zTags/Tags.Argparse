using System;

namespace Tags.Argparse;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class FlagAttribute : Attribute 
{
    internal string name;
    public bool useShort;
    public string help;
    
    public FlagAttribute(string n)
    {
        name = n;
        help = "";
    }
}