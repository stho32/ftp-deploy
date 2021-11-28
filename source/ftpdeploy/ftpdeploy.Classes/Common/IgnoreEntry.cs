using ftpdeploy.Interfaces.Common;

namespace ftpdeploy.Classes.Common;

public class IgnoreEntry : IIgnoreEntry
{
    public string Pattern { get; }
}