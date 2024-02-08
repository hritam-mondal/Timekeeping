# Timekeeping

**Author:** Hritam Mondal

## Description
This is a C# project that implements a stopwatch class that inherits from the `System.Timers.Timer` class and allows you to create and manage multiple stopwatch instances with different settings. You can use this project as a library in your own applications or as a console app that demonstrates the functionality of the stopwatch class.

## Features
- Create a stopwatch instance with a unique ID and optional parameters for seconds and intervals.
- Start, stop, restart, or check the status of a stopwatch instance.
- Add event handlers for the tick and end events of a stopwatch instance.
- Manage multiple stopwatch instances using a static dictionary.

## Installation
To install this project, you need to have the following prerequisites:
- .NET 8.0 SDK or later
- Visual Studio 2022 or later (optional)
- JetBrains Rider (optional)

You can clone this project from GitHub using the following command:

```shell
git clone https://github.com/hritam-mondal/Timekeeping.git
```

## Usage
To use this project as a library in your applications, you need to add a reference to the Timekeeping.dll file in your project. You can do this by using the dotnet add reference command, such as:

```shell
dotnet add reference path/to/Timekeeping.dll
```

Or you can use the Visual Studio IDE to add the reference.
Then you can import the Timekeeping namespace in your code, such as:

```using Timekeeping;```

To use this project as a console app, you can run the following command in the project directory:

```shell
dotnet run
```

Or you can use the Visual Studio or JetBrains Rider to run the app.
The console app will show you how to create and use a stopwatch instance, and how to handle the user input to control the app.

## License

This repository is licensed with the [MIT](LICENSE) license.
