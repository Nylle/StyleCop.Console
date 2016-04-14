[![Build Status](https://travis-ci.org/Nylle/StyleCop.Console.svg?branch=master)](https://travis-ci.org/Nylle/StyleCop.Console)

# StyleCop.Console

## Getting Started

Run `StyleCop.Console.exe -project-path "path/to/your/cs/project"` to get a static code analysis with StyleCop's default rules.

To *not* analyse subdirectories recursively add the argument switch `-not-recursively`.

## Rules

### Default Rules

To deactivate default rules, edit the file `Settings.StyleCop` with the `StyleCopSettingsEditor.exe` or pass your existing settings file via command line argument:

```Shell
StyleCop.Console.exe -settings-location "path/to/your/Settings.StyleCop" -project-path "path/to/your/cs/project"
```

### Custom Rules

You can add your own rules by adding your own `SourceAnalyzer` class in the `StyleCop.Rules` project. Refer to the existing `RulesAnalyzer.cs` class as a real-life example for disallowing more than one class per code file.

Further reading: [How to Create StyleCop Custom Rule](https://stylecopplus.codeplex.com/wikipage?title=How%20to%20Create%20StyleCop%20Custom%20Rule)

## All Command Line Arguments

- Show help screen: `-help` or `-?`
- Specify project path: `-project-path <path>` or `-p <path>`
- Custom settings file: `-settings-location <path>` or `-s <path>`
- Do not analyse subdirectories: `-not-recursively` or `-n`
