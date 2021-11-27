using ftpdeploy.Interfaces.CommandLineArguments;

namespace ftpdeploy.BL.CommandLineArguments;

public class Parser {
    private readonly ICommandLineOption[] options;

    public Parser(ICommandLineOption[] options)
    {
        this.options = options;
    }

    public bool TryParse(string[] args)
    {
        var position = 0;

        while (position < args.Length) {
            var startPositionForTheRound = position;

            foreach (var option in options) {
                if (option.HasNoValueYet()) {
                    if (option.TryParseFrom(args, ref position))
                        continue;
                }
            }

            if (startPositionForTheRound == position) {
                return false;
            }
        }

        return true;
    }

    public bool GetBoolOption(string name)
    {
        foreach (var option in options) {
            if (option.Name.ToLower().Trim() == name.ToLower().Trim()) {
                if (option is IBoolCommandLineOption op) {
                    return op.GetValue();
                }
            }
        }

        throw new Exception($"A bool command line option with the name {name} could not be found.");
    }

    public int GetInt32Option(string name) {
        foreach (var option in options) {
            if (option.Name.ToLower().Trim() == name.ToLower().Trim()) {
                if (option is IInt32CommandLineOption op) {
                    return op.GetValue();
                }
            }
        }

        throw new Exception($"A bool command line option with the name {name} could not be found.");
    }
}
