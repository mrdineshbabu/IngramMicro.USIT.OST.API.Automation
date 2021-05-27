//-----------------------------------------------------------------------
// <copyright file="CommanMethods.cs" company="Ingram Micro Inc">
//     Copyright (c) Ingram Micro Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace IngramMicro.USIT.OST.API.Automation
{
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml.Linq;
    //using Microsoft.Azure.KeyVault;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Xml;
    using System.Diagnostics;
    using NUnit.Framework.Interfaces;

    public class CommanMethods
    {
        public const string Alphabet =
        "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string GenerateString(int size)
        {
            Random rand = new Random();
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }
            return new string(chars);
        }

        /// <summary>
        /// Gets the test data xml from data table.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>property value</returns>
        public static string GetTestDataXMLfromDataTable(string propertyName, string fileName = "")
        {
            string xmlFilePath = string.Format(@"{0}\{1}", Directory.GetCurrentDirectory(), string.IsNullOrEmpty(fileName) ? "TestData.xml" : fileName);
            DataSet xmlDataSet = new DataSet();
            xmlDataSet.ReadXml(xmlFilePath);
            return Convert.ToString(xmlDataSet.Tables["Properties"].AsEnumerable().Where(row => Convert.ToString(row["PropertyName"]).Equals(propertyName)).CopyToDataTable().Rows[0][1]).Replace("\r\n    ", "\r\n").Replace("\r\n  ", "\r\n").TrimStart(new char[] { '\r', '\n' }).TrimEnd(new char[] { '\r', '\n' });
        }

        /// <summary>
        /// Gets the database query from XML.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Database query</returns>
        public static string GetDBQueryfromXML(string propertyName)
        {
            string xmlFilePath = string.Format(@"{0}\TestData\DBQueries.xml", Constants.FilePath);
            XDocument xmlDoc = XDocument.Load(xmlFilePath);
            var dicProperties = xmlDoc.Descendants("Properties").ToDictionary(data => data.Element("PropertyName").Value.Replace("\r\n    ", "\r\n").Replace("\r\n  ", "\r\n").TrimStart(new char[] { '\r', '\n' }).TrimEnd(new char[] { '\r', '\n' }), data => data.Element("PropertyValue").Value.Replace("\r\n    ", "\r\n").Replace("\r\n  ", "\r\n").Replace("      ", string.Empty).TrimStart(new char[] { '\r', '\n' }).TrimEnd(new char[] { '\r', '\n' }));
            return dicProperties[propertyName].Replace("XMLString1", "<XMLRoot><RowData>").Replace("XMLString2", "</RowData><RowData>").Replace("XMLString3", "</RowData></XMLRoot> "); /*GetTestDataXMLfromDataTable(propertyName, "DBQueries.xml");*/
        }

        public static string DBString(string key)
        {
            string connectionString = ConfigurationManager.AppSettings[key].ToString();
            return connectionString;
        }

        public static void Xml()
        {
            Process p = new Process();
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "cmd.exe";
            ps.WindowStyle = ProcessWindowStyle.Normal;
            //ps.Arguments = "/k cd " + Constants.FilePath + @"\NUnit.org\nunit-console";
            //ps.Arguments = @"/k cd C:\Automation\IngramMicro.USIT.OST.API.Automation\IngramMicro.USIT.OST.API.NunitConsole\bin\Debug\NUnit.org\nunit-console";
            //Process.Start(ps);
            //ps.Arguments = @"/k nunit3-console.exe "+@"--result = E:\Newfolder\test.xml; format = nunit2 " +  @"C:\Automation\IngramMicro.USIT.OST.API.Automation\IngramMicro.USIT.OST.API.Automation\bin\Debug\IngramMicro.USIT.OST.API.Automation.dll";
            ps.RedirectStandardInput = true;
            ps.UseShellExecute = false;

            p.StartInfo = ps;
            p.Start();
            string te = @"nunit3-console.exe " + @"--result = E:\Newfolder\test.xml; format = nunit2 " + @"C:\Automation\IngramMicro.USIT.OST.API.Automation\IngramMicro.USIT.OST.API.Automation\bin\Debug\IngramMicro.USIT.OST.API.Automation.dll";
            string tr = @"nunit3-console.exe " + "\"--result=E:\\Newfolder\\test.xml;format=nunit2\"" + @" C:\Automation\IngramMicro.USIT.OST.API.Automation\IngramMicro.USIT.OST.API.Automation\bin\Debug\IngramMicro.USIT.OST.API.Automation.dll";
            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine(@"cd NUnit.org\nunit-console");
                    sw.WriteLine(tr);

                }
            }
        }
    }
}