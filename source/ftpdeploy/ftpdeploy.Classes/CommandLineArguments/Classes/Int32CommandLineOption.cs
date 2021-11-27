using ftpdeploy.Interfaces.CommandLineArguments;

namespace fftpdeploy.Classes.CommandLineArguments;

public class Int32CommandLineOption : IInt32CommandLineOption
{
    private int _value = 0;
    private int _min;
    private int _max;
    private bool _hasValue = false;

    public Int32CommandLineOption(string name, int defaultValue = 0, int min = Int32.MinValue, int max = Int32.MaxValue)
    {
        Name = name;
        _value = defaultValue;
        _min = min;
        _max = max;
    }

    public string Name { get; }

    public int GetValue()
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

            try {
                if (!Int32.TryParse(args[position+1], out _value)) {
                    throw new Exception(args[position+1] + " is an invalid value for argument " + myName);
                }

                if (_value < _min) {
                    throw new Exception(args[position+1] + " is a too low value for argument " + myName);
                }

                if (_value > _max) {
                    throw new Exception(args[position+1] + " is a too high value for argument " + myName);
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            position += 1;
            return true;
        }

        return false;
    }
}