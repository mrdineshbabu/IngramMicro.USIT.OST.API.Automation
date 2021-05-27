//-----------------------------------------------------------------------
// <copyright file="Constants.cs" company="Ingram Micro Inc">
//     Copyright (c) Ingram Micro Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace IngramMicro.USIT.OST.API.Automation
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.IO;
    public static class Constants
    {
        //This will give us the full name path of the executable file
        public static string ExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        //This will strip just the working path name:
        public static string FilePath = System.IO.Path.GetDirectoryName(ExeFilePath);

        /// <summary>
        /// The application URL
        /// </summary>
        //private static string apiUrl = Convert.ToString(ConfigurationManager.AppSettings["APIUrl"]);

        /// <summary>
        /// Gets or sets the application URL.
        /// </summary>
        /// <value>The application URL.</value>
        //public static string APIUrl
        //{
        //    get { return Constants.apiUrl; }
        //    set { Constants.apiUrl = value; }
        //}

        /// <summary>
        /// The application URL
        /// </summary>
        //private static string authorization = Convert.ToString(ConfigurationManager.AppSettings["Authorization"]);

        private static string environment = Convert.ToString(ConfigurationManager.AppSettings["Environment"]);

        public static string Environment
        {
            get { return Constants.environment; }
            set { Constants.environment = value; }
        }              
               
        public static DataTable OrderDetailsTestData = ReadWriteHelper.ReadExcel(FilePath + @"\TestData\OrderDetailsTestData.xlsx", Environment, true);
        public static DataTable OSTReportTestData = ReadWriteHelper.ReadExcel(FilePath + @"\TestData\OSTReportTestData.xlsx", Environment, true);
        public static DataTable NotificationHubTestData = ReadWriteHelper.ReadExcel(FilePath + @"\TestData\NotificationHubTestData.xlsx", Environment, true);

        public static string projectDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
        public static string OrderDatailsTestDataDirectory = Directory.GetParent(projectDirectory).Parent.Parent.FullName + "\\TestData\\OrderDetailsTestData.xlsx";

    }
}