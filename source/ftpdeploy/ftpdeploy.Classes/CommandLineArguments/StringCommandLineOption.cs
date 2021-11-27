namespace ftpdeploy.Classes.CommandLineArguments;

public class StringCommandLineOption : WithValueCommandLineOption<string>
{
    public StringCommandLineOption(
        string name, 
        string defaultValue = "") 
            : base(name, defaultValue)
    {
    }

    protected override string ValidateAndParseValue(string value) => value;
}