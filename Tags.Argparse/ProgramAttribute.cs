using System;

namespace Tags.Argparse;

/// <summary>
/// Marks a class as a valid Program
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ProgramAttribute : Attribute 
{
    internal string name;
    public double version;
    
    public ProgramAttribute(string n)
    {
        name = n;
        
        // defaults
        version = 1.0;
    }
}