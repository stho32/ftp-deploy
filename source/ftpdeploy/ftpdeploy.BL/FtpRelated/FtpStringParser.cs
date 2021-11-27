using ftpdeploy.BL.ExtensionMethods;

namespace ftpdeploy.BL.FtpRelated;

public static class FtpStringParser {
    public static IFtpAccessInformation Parse(string input) {
        // user:password@somehost.com:1234
        var user = GetUntil(":", ref input);
        // password@somehost.com:1234
        var password = GetUntil("@", ref input);
        // somehost.com:1234
        var host = GetUntil(":", ref input);
        // 1234
        var port = input.ToInt();

        return new FtpAccessInformation(user, password, host, port);
    }

    private static string GetUntil(string end, ref string input)
    {
        if (input.Contains(end)) {
            var split = input.Split(new[] {end}, 2, StringSplitOptions.None);
            input = split[1];
            return split[0];
        }

        var temp = input;
        input = "";
        return temp;
    }
}