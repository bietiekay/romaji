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
                System.Console.WriteLine("Kana to Romaji - command line tool utilizing the WanaKanaSharp library (https://github.com/caguiclajmg/WanaKanaSharp");
                System.Console.WriteLine("\tromaji -s <kana text>");
                System.Console.WriteLine("\tromaji -d <directory to be renamed recursively>");
                return;
            }

            switch (args[0].ToUpper())
            {
                case "-S":
                    System.Console.Write(WanaKana.ToRomaji(args[0]));
                    break;
                case "-D":
                    System.Console.WriteLine("Renaming " + args[1]);
                    WalkAndRename(new System.IO.DirectoryInfo(args[1]));
                    break;
                default:
                    System.Console.WriteLine("no parameter recognized.");
                    break;
            }

            void WalkAndRename(System.IO.DirectoryInfo root)
            {
                System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
                System.IO.FileInfo[] files = null;
                System.IO.DirectoryInfo[] subDirs = null;

                // First, process all the files directly under this folder
                try
                {
                    files = root.GetFiles("*.*");
                }
                // This is thrown if even one of the files requires permissions greater
                // than the application provides.
                catch (UnauthorizedAccessException e)
                {
                    // This code just writes out the message and continues to recurse.
                    // You may decide to do something different here. For example, you
                    // can try to elevate your privileges and access the file again.
                    log.Add(e.Message);
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }

                if (files != null)
                {
                    foreach (System.IO.FileInfo fi in files)
                    {
                        // In this example, we only access the existing FileInfo object. If we
                        // want to open, delete or modify the file, then
                        // a try-catch block is required here to handle the case
                        // where the file has been deleted since the call to TraverseTree().

                        System.Console.Write(fi.FullName+"  -->  ");
                        System.Console.WriteLine(WanaKana.ToRomaji(fi.FullName));
                        System.IO.File.Move(fi.FullName, WanaKana.ToRomaji(fi.FullName));

                    }

                    // Now find all the subdirectories under this directory.
                    subDirs = root.GetDirectories();

                    foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                    {
                        // Resursive call for each subdirectory.
                        WalkAndRename(dirInfo);
                    }
                }
            }
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
