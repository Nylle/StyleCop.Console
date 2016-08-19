namespace StyleCop.Console
{
    internal class RunnerArguments : CommandLineArguments
    {
        public RunnerArguments(string[] args)
            : base(args)
        {
        }

        public string ProjectPath
        {
            get { return this["project-path"] ?? this["p"]; }
        }

        public bool NotRecursive
        {
            get { return (this["not-recursively"] ?? this["n"]) != null; }
        }

        public bool Help
        {
            get { return (this["help"] ?? this["?"]) != null; }
        }

        public string SettingsLocation
        {
            get { return this["settings-location"] ?? this["s"]; }
        }

        public string OutputFile
        {
            get { return this["output-file"] ?? this["o"]; }
        }

        public string Rule
        {
            get { return this["rule"] ?? this["r"]; }
        }
    }
}
