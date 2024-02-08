using System.Timers;
using Timer = System.Timers.Timer;

namespace Timekeeping;

public class Stopwatch
{
    // A dictionary to store all the stopwatch instances by their ids
    private static Dictionary<string, Stopwatch> stopwatches = new Dictionary<string, Stopwatch>();

    // A timer to run the stopwatch logic
    private Timer timer;

    // The id of the stopwatch instance
    public string Id { get; private set; }

    // The number of seconds that the stopwatch will run for
    public int Seconds { get; private set; }

    // The time interval in milliseconds between each tick of the stopwatch
    public int Interval { get; private set; }

    // An event handler for the tick event
    public event EventHandler<int>? Tick;

    // An event handler for the end event
    public event EventHandler? End;

    // A private constructor to create a stopwatch instance
    private Stopwatch(string id, int seconds, int interval)
    {
        this.Id = id;
        this.Seconds = seconds;
        this.Interval = interval;
        this.timer = new Timer(interval);
        this.timer.Elapsed += OnTimerElapsed;
    }

    // A method to stop the stopwatch
    public void Stop()
    {
        this.timer.Stop();
    }

    // A method to start the stopwatch
    public void Start()
    {
        this.timer.Start();
    }

    // A method to check if the stopwatch is started
    public bool Started()
    {
        return this.timer.Enabled;
    }

    // A method to restart the stopwatch
    public void Restart(int seconds, int interval)
    {
        this.Stop();
        this.Tick = null;
        this.End = null;
        this.Seconds = seconds;
        this.Interval = interval;
        this.Start();
    }

    // A method to handle the timer elapsed event
    private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
    {
        // Raise the tick event with the current seconds value
        this.Tick?.Invoke(this, Seconds);

        // Decrement the seconds by one
        this.Seconds--;

        // Check if the seconds reach zero
        if (this.Seconds < 0)
        {
            // Stop the stopwatch
            this.Stop();

            // Raise the end event
            this.End?.Invoke(this, EventArgs.Empty);

            // Remove the stopwatch instance from the dictionary
            stopwatches.Remove(this.Id);
        }
    }

    // A static method to get a stopwatch instance by id and options
    public static Stopwatch Get(string id, int seconds = 10, int interval = 1000)
    {
        // Check if the stopwatch instance already exists in the dictionary
        if (stopwatches.ContainsKey(id))
        {
            // Return the existing instance
            return stopwatches[id];
        }
        else
        {
            // Create a new instance
            Stopwatch stopwatch = new Stopwatch(id, seconds, interval);

            // Add the instance to the dictionary
            stopwatches.Add(id, stopwatch);

            // Return the new instance
            return stopwatch;
        }
    }
}
