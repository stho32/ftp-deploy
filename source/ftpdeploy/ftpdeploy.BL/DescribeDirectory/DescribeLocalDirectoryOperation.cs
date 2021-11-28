using ftpdeploy.BL.Interfaces;
using ftpdeploy.Interfaces.Common;
using ftpdeploy.Classes.Common;
using System.Text.Json;

namespace ftpdeploy.BL.DescribeDirectory;

///<summary>
/// ftpdeploy describe-dir --local C:\path\ --ignores ignore-something.json --output C:\listing.json
///</summary>
public class DescribeLocalDirectoryOperation : IOperation
{
    private string? localDirectory;
    private string? outputParameter;

    public DescribeLocalDirectoryOperation(string? localDirectoryParameter, string? outputParameter)
    {
        if (string.IsNullOrWhiteSpace(localDirectoryParameter)) {
            throw new Exception("A path is required");
        }
        if (string.IsNullOrWhiteSpace(outputParameter)) {
            throw new Exception("You did not tell me where to put the results.");
        }

        this.localDirectory = localDirectoryParameter;
        this.outputParameter = outputParameter;
    }

    public void Execute()
    {
        Console.WriteLine(" - describing local directory " + localDirectory);
        var result = GetFolderDescription(localDirectory);

        File.WriteAllText(outputParameter, JsonSerializer.Serialize(result));
    }

    static IFileDescription[] GetFileDescriptions(string path) {
        var result = new List<IFileDescription>();
        var files = Directory.GetFiles(path);

        foreach (var file in files) {
            result.Add(new FileDescription(file.Remove(0, path.Length+1)));
        }

        return result.ToArray();
    }

    static IFolderDescription[] GetFolderDescriptions(string path) {
        var directories = Directory.GetDirectories(path);
        var result = new List<IFolderDescription>();
        foreach ( var folder in directories )
        {
            result.Add(GetFolderDescription(folder));
        }
        return result.ToArray();
    }

    static IFolderDescription GetFolderDescription(string path)
    {
        Console.WriteLine(" - describing " + path + "...");
        return new FolderDescription(path, 
            GetFileDescriptions(path),
            GetFolderDescriptions(path)
        );
    }
}
