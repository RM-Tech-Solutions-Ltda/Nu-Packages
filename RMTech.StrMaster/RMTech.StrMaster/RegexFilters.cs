using System.Text.RegularExpressions;

namespace RMTech.StrMaster
{
    public static partial class RegexFilters
    {
        /// <summary>
        /// Gera uma expressão regular para corresponder sequências de texto que terminam com um ponto final (.),
        /// ponto de exclamação (!) ou ponto de interrogação (?), seguidos por um espaço ou o fim da string.
        ///
        /// Esta expressão regular é útil para separar ou validar frases completas, garantindo que cada frase
        /// termine com uma pontuação apropriada, seguida de um espaço ou o fim do texto.
        /// </summary>
        /// <returns>
        /// Um objeto <see cref="Regex"/> que pode ser utilizado para testar se uma string termina com uma
        /// pontuação final seguida de espaço ou o final da string.
        /// </returns>
        /// <example>
        /// Exemplo de uso:
        /// <code>
        /// var regex = RegexFilters.TextEndsWithRegex();
        /// bool isMatch = regex.IsMatch("Esta é uma frase!");
        /// </code>
        /// O código acima retornará <c>true</c>, pois a frase termina com um ponto de exclamação e espaço.
        /// </example>
        [GeneratedRegex(@"[^.!?]+[.!?]+(\s|$)", RegexOptions.Multiline)]
        public static partial Regex TextEndsWithRegex();
    }
}