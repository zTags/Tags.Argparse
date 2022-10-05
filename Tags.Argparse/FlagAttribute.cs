using System;

namespace Tags.Argparse;

/// <summary>
/// Marks a field as a valid Flag
/// </summary>
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