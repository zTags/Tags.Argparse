using System;

namespace Tags.Argparse;

/// <summary>
/// Marks a field as a valid Argument
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class ArgumentAttribute : Attribute 
{
    internal string name;
    public bool useShort;
    
    public ArgumentAttribute(string n)
    {
        name = n;
    }
}