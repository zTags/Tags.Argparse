using System.Reflection;
using System.Collections.Generic;

namespace Tags.Argparse;

/// <summary>
/// This contains all the methods to actually parse your program's arguments
/// </summary>
public class Parser<T>
    where T: new()
{
    public ProgramAttribute? pData;
    public bool generateHelp;
    public bool helpOnEmptyArgs;
    public string help;

    /// <summary>
    /// Create a new parser for program T
    /// </summary>
    /// <exception cref="Tags.Argparse.Exceptions.NoProgramAttributeException">If T doesn't have the Program attribute</exception>
    public static Parser<T> Create() {
        Type program = typeof(T);
        Attribute? attr = Attribute.GetCustomAttribute(program, typeof(ProgramAttribute));
        if (attr is null)
            throw new Exceptions.NoProgramAttributeException("No program attribute found, did you add `[Program(name)]`?");
        ProgramAttribute programdata = (ProgramAttribute)attr;
        Parser<T> parser = new Parser<T>();
        parser.pData = programdata;
        return parser;
    }

    /// <summary>
    /// Parse a string[] into a Program
    /// </summary>
    /// <exception cref="Tags.Argparse.Exceptions.IlligalFlagTypeException">Flags must always be of type bool</exception>
    /// <exception cref="Tags.Argparse.Exceptions.IlligalArgumentTypeException">Arguments must always be of type string</exception>
    /// <exception cref="Tags.Argparse.Exceptions.NoArgumentValueException">Thrown if you passed a flag without value; e.g. `-w` instead of `-w 1920`</exception>
    public T Parse(string[] args)
    {
        if (generateHelp)
        {
            help = "";
            ProgramAttribute attr = (ProgramAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(ProgramAttribute))!;
            help += $"{attr.name}";
            #if WIN32
            help += ".exe";
            #endif
            help += "\n\nFlags:\n";
        }

        Type classType = typeof(T);
        FieldInfo[] fields = classType.GetFields();
        T parsed = new T();
        Dictionary<String, (FlagAttribute, FieldInfo)> possibleFlags = new();

        foreach (FieldInfo fi in fields)
        {
            object[] attrs = fi.GetCustomAttributes(typeof(FlagAttribute), false);
            foreach (object o in attrs)
            {
                if (o is not FlagAttribute)
                    continue;
                FlagAttribute arg = (FlagAttribute) o;
                possibleFlags.Add(arg.name, (arg, fi));

                if (fi.FieldType != typeof(bool)) 
                    throw new Exceptions.IlligalFlagTypeException("Flags must always be of type bool");
            }
        }

        Dictionary<string, List<string>> flags = new();
        foreach (KeyValuePair<string, (FlagAttribute, FieldInfo)> p in possibleFlags)
        {
            flags.Add(p.Key, new() { $"--{p.Key}" });
            if (p.Value.Item1.useShort)
                flags[p.Key].Add($"-{p.Key[0]}");
            
            if (generateHelp)
            {
                help += $"  --{p.Key}";
                if (p.Value.Item1.useShort)
                    help += $" | -{p.Key[0]}";
                if (p.Value.Item1.help != String.Empty)
                    help += $": {p.Value.Item1.help}";
                help += "\n";
            }
        }

        foreach (KeyValuePair<string, List<string>> p in flags)
        {
            int tally = 0;
            foreach (string s in p.Value)
            {
                tally += args.Count(v => v == s);
            }

            if (tally >= 1)
                possibleFlags[p.Key].Item2.SetValue(parsed, true);
            else 
                possibleFlags[p.Key].Item2.SetValue(parsed, false);
            
            
        }

        if (generateHelp)
        {
            help += "\n\nArguments:\n";
        }

        Dictionary<string, (ArgumentAttribute, FieldInfo)> possibleArgs = new();

        foreach (FieldInfo fi in fields)
        {
            object[] attrs = fi.GetCustomAttributes(typeof(ArgumentAttribute), false);
            foreach (object o in attrs)
            {
                if (o is not ArgumentAttribute)
                    continue;
                ArgumentAttribute arg = (ArgumentAttribute) o;
                possibleArgs.Add(arg.name, (arg, fi));
                if (fi.FieldType != typeof(string)) 
                    throw new Exceptions.IlligalArgumentTypeException("Arguments must always be of type string");

                if (generateHelp)
                {
                    help += $"  --{arg.name}";
                    if (arg.useShort)
                    {
                        help += $" | -{arg.name[0]}";
                    }
                    help += $" [{fi.FieldType.ToString()}]";
                    help += "\n";
                }
            }
        }
        int count = args.Count();
        foreach (KeyValuePair<string, (ArgumentAttribute, FieldInfo)> p in possibleArgs)
        {
            int idx = -1;
            foreach (string s in args) 
            {
                idx++;
                if (s == $"--{p.Value.Item1.name}" || (p.Value.Item1.useShort && s == $"-{p.Value.Item1.name[0]}")) {
                    if (idx+1 >= count) {
                        throw new Exceptions.NoArgumentValueException("Couldn't find an argument");
                    }
                    string value = args[idx+1];
                    p.Value.Item2.SetValue(parsed, value);
                }
            }
        }

        if (args.Count() == 0 && helpOnEmptyArgs)
        {
            Console.Write(help);
            Environment.Exit(1);
        }
        return parsed;
    }

    private Parser() {
        generateHelp = true;
        helpOnEmptyArgs = false;
        help = "help wasn't generated.";
    }

    /// <summary>
    /// Set to true if you want to generate help
    /// </summary>
    public Parser<T> doGenerateHelp(bool b) {
        generateHelp = b;
        return this;
    }

    /// <summary>
    /// Set to true if you want help if no args were provided
    /// </summary>
    public Parser<T> doHelpOnEmptyArgs(bool b) {
        helpOnEmptyArgs = b;
        return this;
    }
}