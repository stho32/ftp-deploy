using ftpdeploy.Interfaces.CommandLineArguments;

namespace ftpdeploy.Classes.CommandLineArguments;

public class BoolCommandLineOption : IBoolCommandLineOption
{
    private bool _value = false;
    private bool _hasValue = false;

    public BoolCommandLineOption(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public bool GetValue()
    {
        return _value;
    }

    public bool HasNoValueYet()
    {
        return !_hasValue;
    }

    public bool TryParseFrom(string[] args, ref int position)
    {
        var myName = Name.ToLower().Trim(); 
        var arg = args[position].ToLower().Trim();

        if (myName == arg) {
            _hasValue = true;
            _value = true;
            position += 1;
            return true;
        }

        return false;
    }
}
