namespace PSMSALNetHelper;
using Microsoft.IdentityModel.Abstractions;

public class Mylogger : IIdentityLogger
{
    public EventLogLevel MinLogLevel { get; set; }

    public Mylogger()
    {
        //Try to pull the log level from an environment variable
        var msalEnvLogLevel = Environment.GetEnvironmentVariable("MSAL_LOG_LEVEL");

        if (Enum.TryParse(msalEnvLogLevel, out EventLogLevel msalLogLevel))
        {
            MinLogLevel = msalLogLevel;
        }
        else
        {
            //Recommended default log level
            MinLogLevel = EventLogLevel.LogAlways;
        }
    }
    public bool IsEnabled(EventLogLevel eventLogLevel)
    {
        return eventLogLevel <= MinLogLevel;
    }
    public void Log(LogEntry entry)
    {
        //Log Message here:
        Console.WriteLine(entry.Message);
    }
}