namespace ftpdeploy.Interfaces.CommandLineArguments;

public interface IWithValueCommandLineOption<T> : ICommandLineOption {
    T? GetValue();
}

