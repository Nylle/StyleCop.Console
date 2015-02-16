using System;
using System.Collections.Generic;

namespace StyleCop.Console
{
    public abstract class CommandLineArguments
    {
        private readonly IDictionary<string, string> _keyValueMap = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        public int Count
        {
            get { return _keyValueMap.Count; }
        }

        public CommandLineArguments(params string[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                var arg = args[i];
                if (IsKey(arg))
                {
                    if (IsNextArgAValue(args, i))
                    {
                        if (_keyValueMap.ContainsKey(arg))
                        {
                            throw new ArgumentException(string.Format("the key {0} is contained twice ", arg));
                        }
                        _keyValueMap.Add(arg.Substring(1), args[i + 1]);
                        i++;
                    }
                    else
                    {
                        _keyValueMap.Add(arg.Substring(1), "");
                    }
                }
                else
                {
                    throw new ArgumentException("The argument list must have the form (-key value?)* ");
                }
            }
        }

        private bool IsNextArgAValue(string[] args, int i)
        {
            return i + 1 < args.Length && !IsKey(args[i + 1]);
        }

        protected string this[string key]
        {
            get
            {
                return !_keyValueMap.ContainsKey(key) ? null : _keyValueMap[key];
            }
        }

        private bool IsKey(string s)
        {
            return s.StartsWith("-");
        }
    }
}
