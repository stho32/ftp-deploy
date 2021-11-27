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

    public void Passwords_with_doublepoint_work() {
        
    }

    public void When_the_port_is_not_given_then_21_is_always_assumed() {
        
    }

    public void When_the_host_is_missing_an_exception_is_thrown() {
        
    }

    public void When_the_user_is_missing_an_exception_is_thrown() {
        
    }

    public void When_the_password_is_missing_an_exception_is_thrown() {
        
    }

}