using System;
using WanaKanaSharp;

namespace romaji
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("Kana to Romaji - command line tool utilizing the WanaKanaSharp library (https://github.com/caguiclajmg/WanaKanaSharp"));
                System.Console.WriteLine("\tromaji <kana text>");
                return;
            }

            System.Console.Write(WanaKana.ToRomaji(args[0]));

            /*Console.WriteLine(WanaKana.IsRomaji("hello")); // true
            Console.WriteLine(WanaKana.IsHiragana("こんにちは")); // true
            Console.WriteLine(WanaKana.IsKatakana("テレビ")); // true
            Console.WriteLine(WanaKana.IsKana("これはキュートです")); // true
            Console.WriteLine(WanaKana.IsKanji("日本語")); // true

            Console.WriteLine(WanaKana.ToRomaji("ひらがな")); // hiragana
            Console.WriteLine(WanaKana.ToRomaji("カタカナ")); // katakana*/

        }
    }
}
