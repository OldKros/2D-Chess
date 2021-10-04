using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _2D_Chess
{
    public static class Logger
    {
        public static LogForm logForm;
        public static List<LogMessage> Messages { get; private set; } = new List<LogMessage>();

        public enum LogStatus
        {
            Log,
            Debug,
            Error
        }

        public static Dictionary<LogStatus, Color> StatusTextColour { get; private set; } = new Dictionary<LogStatus, Color>()
        {
            { LogStatus.Log, Color.Black },
            { LogStatus.Debug, Color.Orange },
            { LogStatus.Error, Color.Red }
        };

        private static Dictionary<LogStatus, string> keyValuePairs { get; set; } = new Dictionary<LogStatus, string>()
        {
            { LogStatus.Log, "Info" },
            { LogStatus.Debug, "Debug" },
            { LogStatus.Error, "Error" }
        };

        public static void Log(string message)
        {
            AddMessage(LogStatus.Log, message);
        }

        public static void Debug(string message)
        {
            AddMessage(LogStatus.Debug, message);
        }

        public static void Error(string message)
        {
            AddMessage(LogStatus.Error, message);
        }

        private static void AddMessage(LogStatus status, string message)
        {
            Messages.Add(new LogMessage(status, $"{DateTime.Now} - {keyValuePairs[status]}\t: {message}"));
            try
            {
                logForm.Log(Messages);
            }
            catch (Exception e)
            {
                logForm = new LogForm();
                logForm.Log(Messages);
                Error(e.Message);
            }
        }

        public class LogMessage
        {
            public string Message { get; private set; }
            public LogStatus Status { get; private set; }

            public LogMessage(LogStatus logStatus, string message)
            {
                Status = logStatus;
                Message = message;
            }
        }
    }



}
