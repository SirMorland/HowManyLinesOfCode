using System;
using System.Collections;
using System.IO;
class Program
{
    public static void Main ()
    {
        while (true) {
            Console.Write ("Path: ");
            string path = Console.ReadLine ();
            Console.Write ("File type: ");
            string mask = Console.ReadLine ();
            int i = CountLinesIn (path, mask);
            System.Console.WriteLine (i + " lines of code\n");
        }
    }

    public static int CountLinesIn (string path, string mask)
    {
        int lines = 0;
        if (File.Exists (path)) {
            if (path.Split ('.') [path.Split ('.').Length - 1] == mask) {
                StreamReader sr = File.OpenText (path);
                while (true) {
                    string line = "";
                    if ((line = sr.ReadLine ()) != null) {
                        lines++;
                    } else break;
                }
                Console.WriteLine (path);
            }
        }
        if (Directory.Exists (path)) {
            string [] files = Directory.GetFiles (path);
            for (int i = 0; i < files.Length; i++) {
                lines += CountLinesIn (files [i], mask);
            }
            string [] directories = Directory.GetDirectories (path);
            for (int i = 0; i < directories.Length; i++) {
                lines += CountLinesIn (directories [i], mask);
            }
        }
        return lines;
    }
}
