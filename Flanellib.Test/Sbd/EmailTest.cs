using Xunit;
using Flanellib.Sbd.Common;
using Flanellib.Functions.UtilFunctions;

public class EmailValidatorTests
{
    [Fact]
    public void Validate_ValidEmail_ReturnsEmail()
    {
        // Arrange
        string email = "test@example.com";
        Email emailObj = new Email(email);

        // Act and Assert
        Assert.Equal(email, emailObj.Value);
    }

    [Fact]
    public void Validate_ValidEmailWithSubdomain_ReturnsEmail()
    {
        // Arrange
        string email = "test.test@example.com";
        Email emailObj = new Email(email);

        // Act and Assert
        Assert.Equal(email, emailObj.Value);
    }

    [Fact]
    public void Validate_ValidEmailWithTwoLetterTLD_ReturnsEmail()
    {
        // Arrange
        string email = "rh.ru@tf.com";
        Email emailObj = new Email(email);

        // Act and Assert
        Assert.Equal(email, emailObj.Value);
    }

    [Fact]
    public void Validate_ValidEmailWithSingleLetterTLD_ReturnsEmail()
    {
        // Arrange
        string email = "rh@tf.com";
        Email emailObj = new Email(email);

        // Act and Assert
        Assert.Equal(email, emailObj.Value);
    }

    [Fact]
    public void Validate_NullEmail_ThrowsArgumentException()
    {
        // Arrange
        string email = null!;

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => new Email(email));
    }

    [Fact]
    public void Validate_FunkyStuff_ThrowsArgumentException()
    {
        // Arrange
        string email = "OR '1'='1";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Email(email));
    }

    [Fact]
    public void Validate_EmptyEmail_ThrowsArgumentException()
    {
        // Arrange
        var email = "";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Email(email));
    }

    [Fact]
    public void Validate_InvalidEmailFormat_ThrowsArgumentException()
    {
        // Arrange
        string email = "invalid_email";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Email(email));
    }

    [Fact]
    public void Validate_EmailTooLong_ThrowsArgumentException()
    {
        // Arrange
        string email = new string('a', 101) + "@example.com";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Email(email));
    }

    [Fact]
    public void Validate_EmailWithInvalidCharacters_ThrowsArgumentException()
    {
        // Arrange
        string email = "test@exa!mple.com";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Email(email));
    }

    [Fact]
    public void Validate_EmailWithMultipleAtSymbols_ThrowsArgumentException()
    {
        // Arrange
        string email = "test@@example.com";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Email(email));
    }

    [Fact]
    public void Validate_EmailWithConsecutiveDots_ThrowsArgumentException()
    {
        // Arrange
        string email = "test..test@example.com";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Email(email));
    }

    [Fact]
    public void Validate_EmailWithLeadingOrTrailingDots_ThrowsArgumentException()
    {
        // Arrange
        string email = ".test@example.com";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Email(email));
    }

    [Fact]
    public void Validate_EmailWithDoSString_ThrowsArgumentException()
    {
        // Arrange
        string email = new string('a', 1000000) + "@example.com";

        // Act and Assert
        Assert.Throws<ArgumentException>(() => new Email(email));
    }
}