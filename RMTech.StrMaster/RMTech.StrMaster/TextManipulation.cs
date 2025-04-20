using System.Globalization;

namespace RMTech.StrMaster;

public class TextManipulation
{
    protected TextManipulation()
    { }

    private static string ConvertWordsToTitleCase(string input)
    {
        TextInfo textInfo = new CultureInfo("pt-BR", false).TextInfo;
        return textInfo.ToTitleCase(input);
    }

    private static string ConvertFirstWordToTitleCase(string input)
    {
        char[] array = input.ToCharArray();
        if (array.Length >= 1)
        {
            array[0] = char.ToUpper(array[0], CultureInfo.GetCultureInfo("pt-BR"));
        }

        string text = new(array);
        return text;
    }

    public static string ToTitleCase(string input, bool onlyFirstWord = true, bool toLower = false)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var text = input;
        if (toLower)
        {
            text = text.ToLower();
        }

        return onlyFirstWord ? ConvertFirstWordToTitleCase(text) : ConvertWordsToTitleCase(text);
    }
}