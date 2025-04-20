using System.Text;
using System.Text.RegularExpressions;

namespace RMTech.StrMaster;

public static class StringProcessor
{
    /// <summary>
    /// Divide um texto em frases com base em pontuações finais como ponto (.), exclamação (!) ou interrogação (?).
    /// As pontuações finais são mantidas em cada frase, e o método tenta preservar a lógica natural da divisão.
    /// </summary>
    /// <param name="input">Texto de entrada a ser dividido.</param>
    /// <returns>Array de strings, cada uma representando uma frase do texto original.</returns>
    public static string[] SplitIntoSentences(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return [];

        // Captura frases que terminam com ., ! ou ?, seguido de espaço ou fim de string
        var regex = RegexFilters.TextEndsWithRegex();
        var matches = regex.Matches(input);

        // Seleciona e retorna os valores dos matches encontrados na expressão regular,
        // removendo quaisquer espaços em branco extras antes e depois de cada valor encontrado.
        return [.. matches
            .Cast<Match>()                  // Converte a coleção de 'matches' para uma sequência de 'Match'
            .Select(m => m.Value.Trim())];  // Para cada 'Match', pega o valor e remove os espaços em branco extras
    }

    /// <summary>
    /// Processa um texto, corrigindo a capitalização de frases sem alterar a capitalização original das palavras.
    /// Cada frase terá sua primeira letra convertida para maiúscula, mantendo o restante da frase intacto.
    /// Também preserva parágrafos e linhas em branco entre blocos de texto.
    /// </summary>
    /// <param name="input">Texto de entrada a ser processado.</param>
    /// <returns>Texto com as frases capitalizadas corretamente e estrutura de parágrafos preservada.</returns>
    public static string StringProcess(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        var paragraphs = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        var finalText = new StringBuilder();

        foreach (var paragraph in paragraphs)
        {
            if (string.IsNullOrWhiteSpace(paragraph))
            {
                finalText.AppendLine();
                continue;
            }

            var sentences = SplitIntoSentences(paragraph);
            var rebuilt = new StringBuilder();

            foreach (var sentence in sentences)
            {
                var trimmed = sentence.Trim();
                if (string.IsNullOrEmpty(trimmed)) continue;

                // Preserva capitalização original, só garante que a primeira letra esteja maiúscula
                var firstChar = trimmed[0];
                string capitalized;

                if (char.IsLower(firstChar))
                    capitalized = char.ToUpper(firstChar) + trimmed.Substring(1);
                else
                    capitalized = trimmed;

                rebuilt.Append(capitalized).Append(" ");
            }

            finalText.AppendLine(rebuilt.ToString().TrimEnd());
        }

        return finalText.ToString().TrimEnd();
    }
}