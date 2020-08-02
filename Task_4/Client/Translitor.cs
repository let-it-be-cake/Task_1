using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Clients.Translate
{
    /// <summary>
    /// Enum of languages
    /// </summary>
    public enum Lang
    {
        Rus,
        Eng,
    }

    /// <summary>
    /// Method to convert text in translit
    /// </summary>
    static public class Translitor
    {
        /// <summary>
        /// Determining the message language
        /// </summary>
        /// <param name="text">Text to define</param>
        /// <returns>The defined language</returns>
        static public Lang LangDefine(string text)
        {
            text = text.ToLower();

            const string specialCharacters = "[ ()\\|/.,<>\\-+=:;'\"*!@#№$%^&`~";

            const string rusCharacters = specialCharacters + @"\P{IsCyrillic}]*";
            const string engCharacters = specialCharacters + @"\P{Lu}]*";

            Regex rusRegex = new Regex(rusCharacters);
            Regex engRegex = new Regex(engCharacters);

            if (rusRegex.Replace(text, "") == "")
                return Lang.Rus;

            if (engRegex.Replace(text, "") == "")
                return Lang.Eng;

            throw new ArgumentException("Unknown Language!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static public string ToRus(string text)
        {

            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"ш", "sh"}, {"ж", "zh"}, {"ч", "ch"}, {"ю", "yu"},
                {"я", "ia"}, {"а", "a"},  {"щ", "sh"}, {"б", "b"}, 
                {"в", "v"},  {"г", "g"},  {"д", "d"},  {"е", "e"}, 
                {"з", "z"},  {"и", "i"},  {"й", "i"},  {"к", "k"}, 
                {"л", "l"},  {"м", "m"},  {"н", "n"},  {"о", "o"}, 
                {"п", "p"},  {"р", "r"},  {"с", "s"},  {"т", "t"}, 
                {"у", "u"},  {"ф", "f"},  {"х", "h"},  {"ц", "c"}, 
                {"ъ", ""},   {"ы", "i"},  {"ь", ""},   {"э", "e"},
            };
            foreach (var letter in dictionary.Keys)
                text = text.Replace(letter, dictionary[letter]);
            return text;
        }

        static public string ToEng(string text)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"j", "дж"}, {"q", "кв"}, {"x", "кс"}, {"a", "а"},
                {"b", "б"},  {"c", "ц"},  {"d", "д"},  {"e", "е"},
                {"f", "ф"},  {"g", "г"},  {"h", "х"},  {"i", "и"}, 
                {"k", "к"},  {"l", "л"},  {"m", "м"},  {"n", "н"},  
                {"o", "о"},  {"p", "п"},  {"r", "р"},  {"s", "с"}, 
                {"t", "т"},  {"u", "у"},  {"v", "в"},  {"w", "в"}, 
                {"y", "и"},  {"z", "з"},
            };

            foreach (var letter in dictionary.Keys)
                text = text.Replace(letter, dictionary[letter]);

            return text;
        }
    }
}