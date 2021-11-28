using ftpdeploy.BL.FtpRelated;

namespace ftpdeploy.BL.Tests.FtpRelated;

public class ParseFtpStringsIntoSeperateAccessInformationTests {
    [Fact]
    public void When_all_fields_are_given_then_all_are_extracted() {
        var testString = "user:password@somehost.com:1234";

        var accessInformation = FtpStringParser.Parse(testString);

        Assert.Equal("user", accessInformation.User);
        Assert.Equal("password", accessInformation.Password);
        Assert.Equal("somehost.com", accessInformation.Host);
        Assert.Equal(1234, accessInformation.Port);
    }

    [Fact]
    public void Passwords_with_doublepoint_work() {
        var testString = "user:pass::word@somehost.com:1234";

        var accessInformation = FtpStringParser.Parse(testString);

        Assert.Equal("user", accessInformation.User);
        Assert.Equal("pass::word", accessInformation.Password);
        Assert.Equal("somehost.com", accessInformation.Host);
        Assert.Equal(1234, accessInformation.Port);
    }

    [Fact]
    public void When_the_port_is_not_given_then_21_is_always_assumed() {
        var testString = "user:password@somehost.com";

        var accessInformation = FtpStringParser.Parse(testString);

        Assert.Equal("user", accessInformation.User);
        Assert.Equal("password", accessInformation.Password);
        Assert.Equal("somehost.com", accessInformation.Host);
        Assert.Equal(21, accessInformation.Port);
    }

    [Fact]
    public void When_the_host_is_missing_an_exception_is_thrown() {
        var testString = "user:password";

        Assert.Throws<Exception>(() => {
            var accessInformation = FtpStringParser.Parse(testString);
        });
    }

    [Fact]
    public void When_the_user_is_missing_an_exception_is_thrown() {
        var testString = "password@somehost.com";

        Assert.Throws<Exception>(() => {
            var accessInformation = FtpStringParser.Parse(testString);
        });
    }

    [Fact]
    public void When_the_password_is_missing_an_exception_is_thrown() {
        var testString = "user@somehost.com";

        Assert.Throws<Exception>(() => {
            var accessInformation = FtpStringParser.Parse(testString);
        });
    }

}