namespace ccwc
{
    class Program
    {
        readonly static List<string> _options = ["-c", "-l", "-w"];

        static void Main(string[] args)
        {
            if (args.Length < 1
                || !File.Exists(args[0])
                || (args.Length > 1 && !args[1..].Any(_options.Contains)))
            {
                Console.WriteLine("Arguments are not valid or file does not exist. Example of usage:");
                Console.WriteLine("ccwc <file path> <option>");
                Console.WriteLine("Options:");
                Console.WriteLine("-c   print the byte counts");
                Console.WriteLine("-l   print the newline counts");
                Console.WriteLine("-w   print the word counts");
            }
            else
            {
                var text = File.ReadAllText(args[0]);

                if (args.Length == 1)
                {
                    ShowByteCounts(args[0]);
                    ShowNumberOfLines(text);
                    ShowNumberOfWords(text);
                    ShowFileName(args[0]);
                    return;
                }

                foreach (var arg in args[1..])
                {
                    if (arg.Equals(_options[0]))
                    {
                        ShowByteCounts(args[0]);
                    }
                    if (arg.Equals(_options[1]))
                    {
                        ShowNumberOfLines(text);
                    }
                    if (arg.Equals(_options[2]))
                    {
                        ShowNumberOfWords(text);
                    }
                }

                ShowFileName(args[0]);
            }
        }

        private static void ShowByteCounts(string file)
        {
            Console.Write($" {File.ReadAllBytes(file).Length}");
        }

        private static void ShowNumberOfLines(string text)
        {
            Console.Write($" {text.Count(c => c == '\n')}");
        }

        private static void ShowNumberOfWords(string text)
        {
            Console.Write($" {text.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries).Length}");
        }

        private static void ShowFileName(string fileName)
        {
            Console.WriteLine($" {fileName}");
        }
    }
}
