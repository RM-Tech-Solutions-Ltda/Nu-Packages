namespace RMTech.StrMaster.Tests.StringProcessorTests;

public class StringProcessTests
{
    [Theory]
    [MemberData(nameof(GetTestCases))]
    public void Process_ShouldCorrectlyFormatText(string input, string expected)
    {
        // Act
        var result = StringProcessor.StringProcess(input);

        // Assert
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> GetTestCases()
    {
        yield return new string[]
        {
            // Teste original com parágrafos e nomes próprios
            @"robôs humanoides se juntaram a milhares de corredores na meia-maratona de Yizhuang, em Pequim, na China, neste sábado (19). foi a primeira vez que essas máquinas correram ao lado de humanos em um percurso de 21 quilômetros.

o vencedor da corrida foi um humano, que levou 1 hora e 2 minutos para completar o percurso. o robô que atravessou primeiro a linha de chegada fez um tempo de 2 horas e 40 minutos.

os robôs corredores são de fabricantes chineses como DroidUP e Noetix Robotics e têm vários formatos e tamanhos. alguns medem menos de 120 centímetros e outros, quase 2 metros.",

            @"Robôs humanoides se juntaram a milhares de corredores na meia-maratona de Yizhuang, em Pequim, na China, neste sábado (19). Foi a primeira vez que essas máquinas correram ao lado de humanos em um percurso de 21 quilômetros.

O vencedor da corrida foi um humano, que levou 1 hora e 2 minutos para completar o percurso. O robô que atravessou primeiro a linha de chegada fez um tempo de 2 horas e 40 minutos.

Os robôs corredores são de fabricantes chineses como DroidUP e Noetix Robotics e têm vários formatos e tamanhos. Alguns medem menos de 120 centímetros e outros, quase 2 metros."
        };

        yield return new string[]
        {
            // Teste simples sem parágrafos
            "este é um teste. outro teste.",
            "Este é um teste. Outro teste."
        };

        yield return new string[]
        {
            // Teste com frase já iniciando com letra maiúscula
            "Exemplo de texto já capitalizado. precisa apenas de ajustes mínimos.",
            "Exemplo de texto já capitalizado. Precisa apenas de ajustes mínimos."
        };

        yield return new string[]
        {
            // Frase com siglas
            "a sigla ONU apareceu no texto. também a NASA.",
            "A sigla ONU apareceu no texto. Também a NASA."
        };
    }
}