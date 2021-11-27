namespace ftpdeploy.BL.FtpRelated;

public static class FtpStringParser {
    public static IFtpAccessInformation Parse(string input) {
        return new FtpAccessInformation("", "", "", 21);
    }
}