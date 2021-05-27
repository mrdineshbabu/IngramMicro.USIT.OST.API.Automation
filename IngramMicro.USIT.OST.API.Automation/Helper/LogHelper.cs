//-----------------------------------------------------------------------
// <copyright file="LogHelper.cs" company="Microsoft Services">
//     Copyright (c) Microsoft Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace IngramMicro.USIT.OST.API.Automation
{
    using System;
    using System.Configuration;
    using System.IO;

    /// <summary>
    /// The log helper
    /// </summary>
    public class LogHelper
    {
        /// Global Declaration
        /// <summary>
        /// File Name
        /// </summary>
        private static string logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);

        /// <summary>
        /// Stream Writer
        /// </summary>
        private static StreamWriter streamw = null;

        /// <summary>
        /// File Created
        /// </summary>
        private static bool fileCreated = false;

        /// <summary>
        /// The string log path
        /// </summary>
        private static string strLogPath = Convert.ToString(ConfigurationManager.AppSettings["LogFilePath"]);

        /// <summary>
        /// Gets or sets a value indicating whether the file created.
        /// </summary>
        /// <value>
        /// The file created
        /// </value>
        public static bool File_Created
        {
            get
            {
                return fileCreated;
            }

            set
            {
                fileCreated = value;
            }
        }

        /// Create a file which can store the log information
        /// <summary>
        /// Create a log file.
        /// </summary>
        public static void CreateLogFile()
        {
            string dir = strLogPath;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (File_Created == false)
            {
                if (Directory.Exists(dir))
                {
                    File_Created = true;
                    streamw = File.AppendText(dir + logFileName + ".log");
                }
                else
                {
                    File_Created = true;
                    Directory.CreateDirectory(dir);
                    streamw = File.AppendText(dir + logFileName + ".log");
                }
            }
        }

        /// Create a method which can write the text in the log file
        /// <summary>
        /// Write the log message.
        /// </summary>
        /// <param name="logMessage">log message</param>
        public static void Write(string logMessage)
        {
            streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            streamw.WriteLine("    {0}", logMessage);
            streamw.Flush();
        }
    }
}