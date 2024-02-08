using Timekeeping;

// A stopwatch instance to use in the app
Stopwatch? stopwatch = null;

// A flag to indicate if the app is running or not
bool running = true;

// Create a stopwatch instance with 60 seconds and 500 milliseconds interval
stopwatch = Stopwatch.Get("myStopwatch", 60, 500);

// Add event handlers for the tick and end events
stopwatch.Tick += OnTick;
stopwatch.End += OnEnd;

// Start the stopwatch
stopwatch.Start();

// Display the instructions
Console.WriteLine("Press ESC to stop the app");
Console.WriteLine("Press SPACE to pause/resume the stopwatch");
Console.WriteLine("Press R to restart the stopwatch");

// Loop until the user presses ESC
while (running)
{
    // Check if the user presses a key
    if (Console.KeyAvailable)
    {
        // Read the key and process it
        var key = Console.ReadKey(true);
        ProcessKey(key);
    }
}

// Define what to do when the stopwatch ticks
void OnTick(object? sender, int seconds)
{
    // Clear the console
    Console.Clear();

    // Display the remaining seconds in a nice format
    Console.WriteLine("Time left: {0:00}:{1:00}", seconds / 60, seconds % 60);
}

// Define what to do when the stopwatch ends
void OnEnd(object? sender, EventArgs e)
{
    // Display a message
    Console.WriteLine("Time's up!");
}

// Define how to process the user input
void ProcessKey(ConsoleKeyInfo key)
{
    switch (key.Key)
    {
        // If the user presses ESC, stop the app
        case ConsoleKey.Escape:
            running = false;
            break;

        // If the user presses SPACE, pause or resume the stopwatch
        case ConsoleKey.Spacebar:
            if (stopwatch!.Started())
            {
                stopwatch.Stop();
            }
            else
            {
                stopwatch.Start();
            }
            break;

        // If the user presses R, restart the stopwatch
        case ConsoleKey.R:
            stopwatch!.Restart(60, 500);
            stopwatch.Tick += OnTick;
            stopwatch.End += OnEnd;
            break;

        // Ignore any other key
        default:
            break;
    }
}
