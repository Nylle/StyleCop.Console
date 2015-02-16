using System;
using System.IO;

namespace StyleCop.Console
{
    public class Program
    {
        private static int _encounteredViolations;

        public static int Main(string[] args)
        {
            var arguments = new RunnerArguments(args);

            if (arguments.Help)
            {
                ShowHelp();
                return (int)ExitCode.Failed;
            }

            if (string.IsNullOrWhiteSpace(arguments.ProjectPath))
            {
                ShowHelp();
                System.Console.WriteLine("");
                System.Console.WriteLine("ERROR: No path specified!");
                return (int)ExitCode.Failed;
            }

            var searchOption = arguments.NotRecursive ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories;
            var projectPath = arguments.ProjectPath; //"D:\\Stuff\\Projects\\StyleCopConsole\\StyleCop.Console";
            
            var settings = @"c:\Program Files (x86)\StyleCop 4.7\Settings.StyleCop";

            var console = new StyleCopConsole(settings, false, null, null, true);
            var project = new CodeProject(0, projectPath, new Configuration(null));

            foreach (var file in Directory.EnumerateFiles(projectPath, "*.cs", searchOption))
            {
                console.Core.Environment.AddSourceCode(project, file, null);
            }

            console.OutputGenerated += OnOutputGenerated;
            console.ViolationEncountered += OnViolationEncountered;
            console.Start(new[] {project}, true);
            console.OutputGenerated -= OnOutputGenerated;
            console.ViolationEncountered -= OnViolationEncountered;

            return _encounteredViolations > 0 ? (int)ExitCode.Failed : (int)ExitCode.Passed;
        }

        private static void ShowHelp()
        {
            System.Console.WriteLine("-------------------");
            System.Console.WriteLine("| StyleCop Runner |");
            System.Console.WriteLine("-------------------");
            System.Console.WriteLine("");
            System.Console.WriteLine("Usage:");
            System.Console.WriteLine("  -project-path <path> or -p <path> .... The path to analyze cs-files in");
            System.Console.WriteLine("  -not-recursively or -n ............... Do not process path recursively");
            System.Console.WriteLine("  -help or -? .......................... Show this screen");
        }

        private static void OnOutputGenerated(object sender, OutputEventArgs e)
        {
            System.Console.WriteLine(e.Output);
        }

        private static void OnViolationEncountered(object sender, ViolationEventArgs e)
        {
            _encounteredViolations++;
            WriteLineViolationMessage(string.Format("{0}: {1}", e.Violation.Rule.CheckId, e.Message));
        }

        private static void WriteLineViolationMessage(string message)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine(message);
            System.Console.ResetColor();
        }
    }
}