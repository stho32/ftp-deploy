using ftpdeploy.BL.ExtensionMethods;

namespace ftpdeploy.BL.FtpRelated;

public static class FtpStringParser {
    public static IFtpAccessInformation Parse(string input) {
        // user:password@somehost.com:1234
        var user = GetUntil(":", ref input);
        if (string.IsNullOrEmpty(user)) {
            throw new Exception("The user is missing.");
        }

        // password@somehost.com:1234
        var password = GetUntil("@", ref input);
        if (string.IsNullOrEmpty(password)) {
            throw new Exception("The password is missing.");
        }

        // somehost.com:1234
        var host = GetUntil(":", ref input);
        if (string.IsNullOrEmpty(host)) {
            throw new Exception("The host is missing.");
        }

        // 1234
        var port = 21;
        if (!string.IsNullOrWhiteSpace(input)) {
            port = input.ToInt();
        }

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