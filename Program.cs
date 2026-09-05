
namespace foxlang
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string usage = @"foxlang <filename>
Executes a compiled binary file

foxlang -c <filename> <outputFilename>
Compiles <filename> into bytecode and outputs it as a file <outputFilename>";
            if (args.Length == 0)
            {
                
                Console.WriteLine(usage);
                return;
            }

            if (args.Length == 1)
                Interpreter.Run(File.ReadAllBytes(args[0]));
            else if (args.Length == 3)
            {
                if (args[0] == "-c")
                {
                    string filename = args[1];
                    string outputFilename = args[2];
                    Compiler.Compile(File.ReadAllText(filename), outputFilename);
                }
                else
                {
                    Console.WriteLine($"Unknown parameter ${args[0]}");
                }
            }
            else
            {
                Console.WriteLine($"Unknown input, refer to the manual.\n\n{usage}");
            }
        }
    }
}