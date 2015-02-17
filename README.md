# StyleCop.Console

## Getting Started

Run `StyleCop.Console.exe -project-path "path/to/your/cs/project"` to get a static code analysis with StyleCop's default rules.

To *not* analyse subdirectories recursively add the argument switch `-not-recursively`.

## Rules

### Default Rules

To deactivate default rules, edit the file `Settings.StyleCop` with the `StyleCopSettingsEditor.exe` or pass your existing settings file via command line argument:

```Shell
StyleCop.Console.exe -project-path "path/to/your/cs/project" -settings-location "path/to/your/Settings.StyleCop"
```

### Custom Rules

Coming soon...

## All Command Line Arguments

- Show help screen: `-help` or `-?`
- Specify project path: `-project-path <path>` or `-p <path>`
- Custom custom settings file: `-settings-location <path>` or `-s <path>`
- Do not analyse subdirectories: `-not-recursively` or `-n`