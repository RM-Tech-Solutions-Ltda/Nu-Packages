namespace RMTech.StrMaster.Tests.StringProcessorTests;

public class SplitIntoSentencesTests
{
    [Theory]
    [InlineData("Olá. Como você está?", new string[] { "Olá.", "Como você está?" })]
    [InlineData("Este é um teste! Funciona?", new string[] { "Este é um teste!", "Funciona?" })]
    [InlineData("Não. Sim?", new string[] { "Não.", "Sim?" })]
    [InlineData("  Teste com espaços extras.  Mais uma frase!   ", new string[] { "Teste com espaços extras.", "Mais uma frase!" })]
    public void SplitIntoSentences_ShouldSplitTextCorrectly(string input, string[] expected)
    {
        // Act
        var result = StringProcessor.SplitIntoSentences(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("Apenas uma frase", new string[] { })]  // Caso de entrada sem match (não há pontuação para separar frases)
    [InlineData("", new string[] { })]  // Caso de entrada vazia
    [InlineData("   ", new string[] { })]  // Caso de entrada com apenas espaços
    [InlineData(null, new string[] { })]  // Caso de entrada com apenas espaços
    public void SplitIntoSentences_ShouldReturnEmptyArrayForNoMatchOrNullOrEmptyInput(string? input, string[] expected)
    {
        // Act
        var result = StringProcessor.SplitIntoSentences(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SplitIntoSentences_ShouldHandleSingleSentenceCorrectly()
    {
        // Act
        var result = StringProcessor.SplitIntoSentences("Só uma frase.");

        // Assert
        Assert.Single(result);
        Assert.Equal("Só uma frase.", result[0]);
    }
}