namespace RMTech.StrMaster.Tests.RegexFiltersTests;

public class TextEndsWithRegexTests
{
    [Theory]
    [InlineData("Esta é uma frase.", true)]    // Termina com ponto (.)
    [InlineData("Esta é uma pergunta?", true)]  // Termina com ponto de interrogação (?)
    [InlineData("Essa é uma exclamacao!", true)] // Termina com ponto de exclamação (!)
    [InlineData("Texto sem pontuação", false)]  // Não termina com . ! ou ?
    [InlineData("Texto com pontuação seguida de espaço. ", true)]  // Ponto seguido de espaço
    [InlineData("Texto com ponto mas sem espaço.", true)] // Ponto mas sem espaço depois
    [InlineData("Começando com ponto. E outra frase aqui.", true)]  // Várias frases com pontuação
    [InlineData("Sim? Não! Talvez.", true)]  // Sequência de frases separadas
    [InlineData("Apenas uma frase", false)]  // Sem pontuação final
    [InlineData("", false)]  // String vazia
    public void TextEndsWithRegex_ShouldMatchCorrectly(string input, bool expectedMatch)
    {
        // Act
        var regex = RegexFilters.TextEndsWithRegex();
        var match = regex.IsMatch(input);

        // Assert
        Assert.Equal(expectedMatch, match);
    }

    [Fact]
    public void TextEndsWithRegex_ShouldNotMatchEmptyString()
    {
        // Act
        var regex = RegexFilters.TextEndsWithRegex();
        var match = regex.IsMatch("");

        // Assert
        Assert.False(match);
    }

    [Fact]
    public void TextEndsWithRegex_ShouldMatchStringWithPunctuationAndSpace()
    {
        // Act
        var regex = RegexFilters.TextEndsWithRegex();
        var match = regex.IsMatch("Frase com pontuação e espaço. ");

        // Assert
        Assert.True(match);
    }
}