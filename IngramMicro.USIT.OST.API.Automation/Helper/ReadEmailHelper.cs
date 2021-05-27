//-----------------------------------------------------------------------
// <copyright file="ReadEmailHelper.cs" company="Microsoft Services">
//     Copyright (c) Microsoft Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace IngramMicro.USIT.OST.API.Automation
{
    using System;
    using Bytescout.Spreadsheet;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Outlook;
    using IngramMicro.USIT.OST.API.Automation.Steps;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class ReadEmailHelper
    {
        public static string reportName = null;        
        public string EmailFrom { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }

        public static string ReadMailItems(string invoicedDays)
        {
            Application outlookApplication = null;
            NameSpace outlookNamespace = null;
            MAPIFolder inboxFolder = null;
            Items mailItems = null;
            bool mailIdentified = false;
            string returnmessage = null;

            List<ReadEmailHelper> listEmailDetails = new List<ReadEmailHelper>();
            ReadEmailHelper emailDetails;
            try
            {
                outlookApplication = new Application();
                outlookNamespace = outlookApplication.GetNamespace("MAPI");
                inboxFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox).Folders["Collate"];
                mailItems = inboxFolder.Items;
                Console.WriteLine(mailItems.Count);
                
                //fetch unread emails 
                /*Microsoft.Office.Interop.Outlook.Items unreadItems = inboxFolder.Items.Restrict("[Unread]=true");
                Console.WriteLine(string.Format("Unread items in Inbox = {0}", unreadItems.Count));*/

                foreach (MailItem item in mailItems)
                {
                    //emailDetails = new OutlookEmails();
                    //emailDetails.EmailFrom = item.SenderEmailAddress;
                    //emailDetails.EmailSubject = item.Subject;
                    //emailDetails.EmailBody = item.Body;
                    //listEmailDetails.Add(emailDetails);
                    //ReleaseComObject(item);

                    string mailtest = item.Subject.ToString();
                    if (mailtest.Contains(reportName))
                    {
                        emailDetails = new ReadEmailHelper
                        {
                            EmailFrom = item.SenderEmailAddress,
                            EmailSubject = item.Subject,
                            EmailBody = item.Body
                        };
                        MailItem mi = item;
                        var attachments = mi.Attachments;
                        if (attachments.Count != 0)
                        {
                            for (int i = 1; i <= mi.Attachments.Count; i++)
                            {
                                Console.WriteLine("Attachment: " + mi.Attachments[i].FileName);
                                string[] extensionsArray = { ".xlsx", ".zip" };
                                if (extensionsArray.Any(mi.Attachments[i].FileName.Contains))
                                {
                                    mi.Attachments[i].SaveAsFile(Constants.FilePath + @"\TestData\" + mi.Attachments[i].FileName);
                                    if(mi.Attachments[i].FileName.Contains(".zip"))
                                    {
                                        //string startPath = @"c:\example\start";
                                        string zipPath = Constants.FilePath + @"\TestData\" + mi.Attachments[i].FileName;
                                        string extractPath = Constants.FilePath + @"\TestData\";

                                        //System.IO.Compression.ZipFile.CreateFromDirectory(startPath, zipPath);
                                        System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);

                                        string filename = Path.GetFileName(Constants.FilePath + @"\TestData\" + mi.Attachments[i].FileName);

                                        filename = filename.Replace(".zip", ".csv");

                                        DataTable OSTReport = ReadWriteHelper.ReadExcel(Constants.FilePath + @"\TestData\" + filename, "OST_Report", true);
                                        DataRow[] filteredRows = OSTReport.Select("Column9 = 'INVOICED'");
                                        int OSTReportRowCount = filteredRows.Length;
                                        for (int j = 1; j <= OSTReportRowCount; j++)
                                        {
                                            string invoicedDate1 = filteredRows[j][50].ToString();
                                            DateTime invoicedDate = DateTime.Parse(invoicedDate1);
                                            if (invoicedDate >= DateTime.Now.AddDays(-3))
                                            {
                                                //do nothing
                                            }
                                            else
                                            {
                                                Assert.Fail("OST report contains different invoiced date");
                                            }
                                        }

                                        File.Delete(Constants.FilePath + @"\TestData\" + mi.Attachments[i].FileName);
                                    }
                                    else if(mi.Attachments[i].FileName.Contains(".xlsx"))
                                    {
                                        DataTable OSTReport = ReadWriteHelper.ReadExcel(Constants.FilePath + @"\TestData\" + mi.Attachments[i].FileName, "OST_Report", true);
                                        DataRow[] filteredRows = OSTReport.Select("Column9 = 'INVOICED'");
                                        //int OSTReportRowCount = OSTReport.Rows.Count;
                                        //DataRow[] filteredRows = Constants.OSTReportTestData.Select("Column17 = 'Test'");
                                        int OSTReportRowCount = filteredRows.Length;
                                        for (int j = 1; j <= OSTReportRowCount; j++)
                                        {
                                            string invoicedDate1 = filteredRows[j][50].ToString();
                                            DateTime invoicedDate = DateTime.Parse(invoicedDate1);
                                            if (invoicedDate >= DateTime.Now.AddDays(-3))
                                            {
                                                //do nothing
                                            }
                                            else
                                            {
                                                Assert.Fail("OST report contains different invoiced date");
                                            }
                                        }
                                        File.Delete(Constants.FilePath + @"\TestData\" + mi.Attachments[i].FileName);
                                    }

                                    

                                    //mi.Attachments[i].Delete(); //removes attachment from the email
                                }
                            }
                        }
                        Console.WriteLine("Identified");
                        mailIdentified = true;
                        returnmessage = "Idendified";
                        break;
                    }
                    ReleaseComObject(item);
                }
                if (!mailIdentified)
                {
                    returnmessage = "Not Idendified";
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("{0} Exception caught: ", ex);
            }
            finally
            {
                ReleaseComObject(mailItems);
                ReleaseComObject(inboxFolder);
                ReleaseComObject(outlookNamespace);
                ReleaseComObject(outlookApplication);
            }
            //return listEmailDetails;
            return returnmessage;
        }

        private static void ReleaseComObject(object obj)
        {
            if (obj != null)
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
        }
    }
}