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


    }
}
