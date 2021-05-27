using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IngramMicro.USIT.OST.API.Automation;
using System.Json;
using System.Text.RegularExpressions;

namespace IngramMicro.USIT.OST.API.Automation.Pages
{
    public static class OSTReportPage
    {
        public static RestClient client;
        public static RestRequest restRequest;
        public static string reportID1 = null;
        public static string reportID = null;
        public static string reportName = null;
        public static DataTable dataFromOST = null;

        public static RestClient SetURL(string APIUrl, string endpoint)
        {
            var url = APIUrl + endpoint;
            return client = new RestClient(url);
        }

        public static IRestResponse GetResponse()
        {
            return client.Execute(restRequest);            
        }

        public static RestRequest GetReportListRequest(string authorization)
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddHeader("X-Request-ID", "100");
            restRequest.AddHeader("X-Trace-ID", "1");
            return restRequest;
        }

        public static void VerifyGetReportListResponse(string expectedValue)
        {
            string GetReportListResponse = GetResponse().Content;
            var GetReportListResponseCode = GetResponse().StatusCode;
            if (!(GetReportListResponse.Contains(expectedValue) && (GetReportListResponseCode == System.Net.HttpStatusCode.OK)))
            {
                Assert.Fail("Response Code: " + GetReportListResponseCode + " Invalid Response: " + GetReportListResponse);
            }            
        }

        public static RestRequest PutReportRequests(string condition1, string condition2, string authorization)
        {
            reportName = "Automation Test Report - " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"); ;
            JObject reportRequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\PutReportsBody.json"));
            string requestbody = reportRequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");

            string ReportRequestsBody = content.ToString().Replace("Automation Test Report", reportName).Replace(condition1, condition2);
            var requestBody = JsonConvert.DeserializeObject(ReportRequestsBody);
            restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PutReportRequests1(string condition1, string condition2, string authorization)
        {
            reportName = "Automation Test Report - " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"); ;
            JObject reportRequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\PutReportsBody.json"));
            string requestbody = reportRequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");

            string ReportRequestsBody = content.ToString().Replace(condition1, condition2);
            var requestBody = JsonConvert.DeserializeObject(ReportRequestsBody);
            restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static void VerifyPutReportBadResponse(string errorMSG)
        {
            var response = client.Execute(restRequest);
            var PutReportsResponseCode = response.StatusCode;
            var errormsg = response.Content;

            if (!((PutReportsResponseCode == System.Net.HttpStatusCode.BadRequest) && (errormsg.Contains(errorMSG))))
            {
                Assert.Fail("Response Code: " + PutReportsResponseCode);
            }
        }

        public static void VerifyPutReportResponse(string errorMSG)
        {
            var response = client.Execute(restRequest);
            var PutReportsResponseCode = response.StatusCode;
            var actualresponse = response.Content;

            if (!((PutReportsResponseCode == System.Net.HttpStatusCode.OK) && (actualresponse.Contains(errorMSG))))
            {
                Assert.Fail("Response Code: " + PutReportsResponseCode);
            }
        }

        public static RestRequest GetReportFormatsRequest(string authorization)
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddHeader("X-Request-ID", "100");
            restRequest.AddHeader("X-Trace-ID", "1");
            return restRequest;
        }

        public static void VerifyGetReportFormatsResponse()
        {
            JObject expectedBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\GetReportFormatExpected.json"));
            string Expectedbody = expectedBody.ToString();
            var ExpectedBody = Regex.Replace(Expectedbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");

            string GetReportFormatsResponse = GetResponse().Content.ToString();
            var GetReportFormatsResponseCode = GetResponse().StatusCode;
            if (!((GetReportFormatsResponse == ExpectedBody) && (GetReportFormatsResponseCode == System.Net.HttpStatusCode.OK)))
            {
                Assert.Fail("Response Code: " + GetReportFormatsResponseCode + " Invalid Response: " + GetReportFormatsResponse);
            }
        }

        public static RestRequest GetReportFormatsResellerRequest(string authorization)
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddHeader("X-Request-ID", "100");
            restRequest.AddHeader("X-Trace-ID", "1");
            return restRequest;
        }

        public static void VerifyGetReportFormatsResellerResponse()
        {
            JObject expectedBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\GetReportFormatExpected.json"));
            string Expectedbody = expectedBody.ToString();
            var ExpectedBody = Regex.Replace(Expectedbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");

            string GetReportFormatsResellerResponse = GetResponse().Content;
            var GetReportFormatsResellerResponseCode = GetResponse().StatusCode;
            //string sub = GetReportFormatsResellerResponse.Substring(GetReportFormatsResellerResponse.IndexOf("timestamp") + 5);
            if (!((GetReportFormatsResellerResponse == ExpectedBody) && (GetReportFormatsResellerResponseCode == System.Net.HttpStatusCode.OK)))
            {
                Assert.Fail("Response Code: " + GetReportFormatsResellerResponseCode + " Invalid Response: " + GetReportFormatsResellerResponse);
            }
        }

        public static RestRequest GetReportFieldsRequest(string authorization)
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddHeader("X-Request-ID", "100");
            restRequest.AddHeader("X-Trace-ID", "1");
            return restRequest;
        }

        public static void VerifyGetReportFieldsResponse()
        {
            JObject expectedBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\GetReportFieldsExpected.json"));
            string Expectedbody = expectedBody.ToString();
            var ExpectedBody = Regex.Replace(Expectedbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");

            string GetReportFieldsResponse = GetResponse().Content;
            var GetReportFieldsResponseCode = GetResponse().StatusCode;            
            if (!((GetReportFieldsResponse == ExpectedBody) && (GetReportFieldsResponseCode == System.Net.HttpStatusCode.OK)))
            {
                Assert.Fail("Response Code: " + GetReportFieldsResponseCode + " Invalid Response: " + GetReportFieldsResponse);
            }
        }

        public static RestRequest GetReportFieldsResellerRequest(string authorization)
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddHeader("X-Request-ID", "100");
            restRequest.AddHeader("X-Trace-ID", "1");
            return restRequest;
        }

        public static void VerifyGetReportFieldsResellerResponse()
        {
            JObject expectedBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\GetReportFieldsExpected.json"));
            string Expectedbody = expectedBody.ToString();
            var ExpectedBody = Regex.Replace(Expectedbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");

            string GetReportFieldsResellerResponse = GetResponse().Content;
            var GetReportFieldsResellerResponseCode = GetResponse().StatusCode;
            if (!((GetReportFieldsResellerResponse == ExpectedBody) && (GetReportFieldsResellerResponseCode == System.Net.HttpStatusCode.OK)))
            {
                Assert.Fail("Response Code: " + GetReportFieldsResellerResponseCode + " Invalid Response: " + GetReportFieldsResellerResponse);
            }
        }

        public static RestRequest PostReports(string reportType, string fileType, string orderType, string authorization)
        {
            reportName = "Automation Test Report - " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"); ;
            JObject reportRequestBody =  JObject.Parse (File.ReadAllText(Constants.FilePath + @"\TestData\ReportsInputBody.json"));
            string ReportRequestBody = reportRequestBody.ToString().Replace("Automation Test Report", reportName).Replace("daily", reportType).Replace("excel", fileType).Replace("STOCK ORDER", orderType);
            var requestBody = JsonConvert.DeserializeObject(ReportRequestBody);            
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostReportsOnDemand(string reportType1, string reportType2, string fileType, string orderType, string authorization)
        {
            reportName = "Automation Test Report - " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            JObject reportRequestBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\ReportsInputBody.json"));
            string requestbody = reportRequestBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string ReportRequestBody = content.ToString().Replace("Automation Test Report", reportName).Replace(reportType2, reportType1).Replace("excel", fileType).Replace("STOCK ORDER", orderType);
            var requestBody = JsonConvert.DeserializeObject(ReportRequestBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostReportsRemove(string reportType, string fileType, string orderType, string authorization)
        {
            reportName = "Automation Test Report - " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"); ;
            JObject reportRequestBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\ReportsInputBodyRemove.json"));
            string ReportRequestBody = reportRequestBody.ToString().Replace("Automation Test Report", reportName).Replace("daily", reportType).Replace("excel", fileType).Replace("STOCK ORDER", orderType);
            var requestBody = JsonConvert.DeserializeObject(ReportRequestBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostReportsMultipleEmail(string reportType, string fileType, string orderType, string authorization, string email)
        {
            reportName = "Automation Test Report - " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"); ;
            JObject reportRequestBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\ReportsInputBody.json"));
            string ReportRequestBody = reportRequestBody.ToString().Replace("Automation Test Report", reportName).Replace("daily", reportType).Replace("excel", fileType).Replace("STOCK ORDER", orderType).Replace("\"dineshbabu.uvarajulu@ingrammicro.com\"", email);
            var requestBody = JsonConvert.DeserializeObject(ReportRequestBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static void VerifyPostReportsResponse1()
        {
            var response = client.Execute(restRequest);
            string content = response.Content;
            var PostReportsResponseHeader = response.Headers;
            var PostReportsResponseCode = response.StatusCode;
            

            if (!(PostReportsResponseCode == System.Net.HttpStatusCode.Created))
            {
                Assert.Fail("Response Code: " + PostReportsResponseCode);
            }
            else
            {
                string location = response.Headers.ToList().Find(x => x.Name == "Location").Value.ToString();
                int firstStringPosition = location.IndexOf("ts/");
                int secondStringPosition = location.IndexOf("?user");
                string stringBetweenTwoStrings = location.Substring(firstStringPosition, secondStringPosition - firstStringPosition + 0);
                reportID = stringBetweenTwoStrings.Replace("ts/", "");
            }
        }

        public static void VerifyPostReportsResponse()
        {
            var response = client.Execute(restRequest);
            var PostReportsResponseHeader = response.Headers;
            var PostReportsResponseCode = response.StatusCode;
            var errormsg = response.ErrorMessage;
            var tet = response.Content;

            if (!(PostReportsResponseCode == System.Net.HttpStatusCode.Created))
            {
                Assert.Fail("Response Code: " + PostReportsResponseCode);
            }
            else
            {
                string location = response.Headers.ToList().Find(x => x.Name == "Location").Value.ToString();
                int firstStringPosition = location.IndexOf("ts/") + 3;
                int secondStringPosition = location.IndexOf("?user");
                reportID = location.Substring(firstStringPosition, secondStringPosition - firstStringPosition + 0);
                //reportID = stringBetweenTwoStrings.Replace("ts/", "");                
            }
        }

        public static RestRequest PostReportsBad(string condition1, string condition2, string authorization)
        {
            reportName = "Automation Test Report - " + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"); ;
            JObject reportRequestBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\ReportsInputBody.json"));
            string requestbody = reportRequestBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string ReportRequestBody = content.Replace("Automation Test Report", reportName).Replace(condition1, condition2);
            var requestBody = JsonConvert.DeserializeObject(ReportRequestBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static void VerifyPostReportsBadResponse(string errorMSG)
        {
            var response = client.Execute(restRequest);
            var PostReportsResponseCode = response.StatusCode;
            var errormsg = response.Content;

            if (!((PostReportsResponseCode == System.Net.HttpStatusCode.BadRequest) && (errormsg.Contains(errorMSG))))
            {
                Assert.Fail("Response Code: " + PostReportsResponseCode);
            }            
        }

        public static RestRequest PostReportRequests(string flag, string authorization)
        {
            JObject reportRequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\ReportRequestsBody.json"));
            string ReportRequestsBody = reportRequestsBody.ToString().Replace("{{", "{").Replace("}}", "}").Replace("FALSE", flag);
            var requestBody = JsonConvert.DeserializeObject(ReportRequestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostReportRequest(string authorization)
        {
            JObject reportRequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\ReportRequestsBody.json"));
            string ReportRequestsBody = reportRequestsBody.ToString();
            var requestBody = JsonConvert.DeserializeObject(ReportRequestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostReportRequestsRemove(string condition1, string condition2, string authorization)
        {
            JObject reportRequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\ReportRequestsBody.json"));
            string requestbody = reportRequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string ReportRequestsBody = content.ToString().Replace(condition1, condition2);
            var requestBody = JsonConvert.DeserializeObject(ReportRequestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static void VerifyPostReportDailyRequestsResponse()
        {
            var response = client.Execute(restRequest);
            var PostReportRequestsResponseCode = response.StatusCode;

            if (!(PostReportRequestsResponseCode == System.Net.HttpStatusCode.Created))
            {
                Assert.Fail("Response Code: " + PostReportRequestsResponseCode);
            }
        }

        public static void VerifyPostReportRequestsResponse(string invoicedDays)
        {
            var response = client.Execute(restRequest);            
            var PostReportRequestsResponseCode = response.StatusCode;
            var test = response.Content;
            
            if (PostReportRequestsResponseCode == System.Net.HttpStatusCode.Created)
            {
                /*int x = 0;
                do
                {
                    string qry = string.Format(CommanMethods.GetDBQueryfromXML("EmailTriggered"));
                    qry = qry.Replace("reportIDfromAPI", "'" + reportID + "'");
                    DataBaseHelper.DBConnection = CommanMethods.DBString("OSTReport");
                    dataFromOST = DataBaseHelper.ExecuteQuery(qry, DataBaseHelper.DBConnection);
                    Console.WriteLine("dataFromOST - " + dataFromOST.Rows.Count);
                    string emailDeliveryStatus = dataFromOST.Rows[0]["EmailDeliveryStatus"].ToString();
                    x = Int32.Parse(emailDeliveryStatus);
                }   while (x == 1);

                if (x == 1)
                {
                    Thread.Sleep(120000);
                    ReadEmailHelper.ReadMailItems(invoicedDays);
                }
                else
                {
                    Assert.Fail("Email Delivery Failed");
                }*/
                //ReadEmailHelper.ReadMailItems(invoicedDays);
            }
            else
            {
                Assert.Fail("Response Code: " + PostReportRequestsResponseCode);
            }
        }

        public static RestRequest GetReportsRequest(string authorization)
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddHeader("X-Request-ID", "100");
            restRequest.AddHeader("X-Trace-ID", "1");
            return restRequest;
        }

        public static void VerifyGetReportsResponse()
        {
            string GetReportsResponse = GetResponse().Content;
            var GetReportsResponseCode = GetResponse().StatusCode;
            if (!(GetReportsResponse.Contains("Account Number") && (GetReportsResponseCode == System.Net.HttpStatusCode.OK)))
            {
                Assert.Fail("Response Code: " + GetReportsResponseCode + " Invalid Response: " + GetReportsResponse);
            }
        }

        public static RestRequest PutReportRequests1(string reportType, string fileType, string orderType, string authorization)
        {
            JObject reportRequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\ReportRequestsBody.json"));
            string ReportRequestsBody = reportRequestsBody.ToString().Replace("{{", "{").Replace("}}", "}").Replace("Automation Test Report", reportName).Replace("daily", reportType).Replace("excel", fileType).Replace("STOCK ORDER", orderType);
            var requestBody = JsonConvert.DeserializeObject(ReportRequestsBody);
            restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static void VerifyPutReportsResponse()
        {            
            var response = client.Execute(restRequest);
            string PutReportsResponse = response.Content;
            var PutReportsResponseCode = response.StatusCode;

            if (!(PutReportsResponse.Contains(reportName) && (PutReportsResponseCode == System.Net.HttpStatusCode.OK)))
            {
                Assert.Fail("Response Code: " + PutReportsResponseCode + " Invalid Response: " + PutReportsResponse);
            }
        }

        public static void VerifyPutResponse()
        {
            var response = client.Execute(restRequest);
            string PutReportsResponse = response.Content;
            var PutReportsResponseCode = response.StatusCode;

            if (!(PutReportsResponse.Contains("csv") && (PutReportsResponseCode == System.Net.HttpStatusCode.OK)))
            {
                Assert.Fail("Response Code: " + PutReportsResponseCode + " Invalid Response: " + PutReportsResponse);
            }
        }

        public static void VerifySingleEmail(string expected)
        {
            var response = client.Execute(restRequest);
            string ReportsResponse = response.Content.ToString();
            var ReportsResponseCode = response.StatusCode;

            if (!(ReportsResponse.Contains(expected) && (ReportsResponseCode == System.Net.HttpStatusCode.OK)))
            {
                Assert.Fail("Response Code: " + ReportsResponseCode + " Invalid Response: " + ReportsResponse);
            }
        }        

        public static void VerifyMultipleEmail(string expected)
        {
            var response = client.Execute(restRequest);
            string ReportsResponse = response.Content.ToString();
            var ReportsResponseCode = response.StatusCode;

            if (!(ReportsResponse.Contains(expected) && (ReportsResponseCode == System.Net.HttpStatusCode.OK)))
            {
                Assert.Fail("Response Code: " + ReportsResponseCode + " Invalid Response: " + ReportsResponse);
            }
        }        

        public static RestRequest PatchReportRequests(string email, string authorization)
        {
            JObject reportRequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\PatchReportsBodyAdd.json"));
            string ReportRequestsBody = reportRequestsBody.ToString().Replace("{{", "{").Replace("}}", "}").Replace("dineshbabu.uvarajulu@ingrammicro.com", email);
            var requestBody = JsonConvert.DeserializeObject(ReportRequestsBody);
            restRequest = new RestRequest(Method.PATCH);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }



        public static RestRequest PatchReportBadRequests(string condition1, string condition2, string authorization)
        {
            JObject reportRequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\PatchReportsBodyAdd.json"));
            string requestbody = reportRequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string ReportRequestsBody = content.ToString().Replace("{{", "{").Replace("}}", "}").Replace(condition1, condition2);
            var requestBody = JsonConvert.DeserializeObject(ReportRequestsBody);
            restRequest = new RestRequest(Method.PATCH);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PatchReportRemoveRequests(string condition1, string condition2, string authorization)
        {
            JObject reportRequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\PatchReportsBodyRemove.json"));
            string requestbody = reportRequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string ReportRequestsBody = content.ToString().Replace("{{", "{").Replace("}}", "}").Replace(condition1, condition2);
            var requestBody = JsonConvert.DeserializeObject(ReportRequestsBody);
            restRequest = new RestRequest(Method.PATCH);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static void VerifyPatchBadResponse(string errorMSG)
        {
            var response = client.Execute(restRequest);
            var PatchResponseCode = response.StatusCode;
            var errormsg = response.Content;

            if (!((PatchResponseCode == System.Net.HttpStatusCode.BadRequest) && (errormsg.Contains(errorMSG))))
            {
                Assert.Fail("Response Code: " + PatchResponseCode);
            }
        }        

        public static void VerifyPatchResponse(string errorMSG)
        {
            var response = client.Execute(restRequest);
            var PatchResponseCode = response.StatusCode;
            var errormsg = response.Content;

            if (!((PatchResponseCode == System.Net.HttpStatusCode.NoContent)))
            {
                Assert.Fail("Response Code: " + PatchResponseCode);
            }
        }

        public static void VerifyPatchReportsResponse()
        {
            var response = client.Execute(restRequest);
            var PatchReportsResponseCode = response.StatusCode;

            if (!(PatchReportsResponseCode == System.Net.HttpStatusCode.OK))
            {
                Assert.Fail("Response Code: " + PatchReportsResponseCode);
            }
        }

        public static RestRequest DeleteReportRequests(string authorization)
        {            
            restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddHeader("X-Request-ID", "100");
            return restRequest;
        }

        public static void VerifyDeleteReportsResponse()
        {
            var response = client.Execute(restRequest);
            var DeleteReportsResponseCode = response.StatusCode;

            if (!(DeleteReportsResponseCode == System.Net.HttpStatusCode.NoContent))
            {
                Assert.Fail("Response Code: " + DeleteReportsResponseCode);
            }
        }

        public static void VerifyDeleteInvalidReportsResponse()
        {
            var response = client.Execute(restRequest);
            var DeleteReportsResponseCode = response.StatusCode;

            if (!(DeleteReportsResponseCode == System.Net.HttpStatusCode.BadRequest))
            {
                Assert.Fail("Response Code: " + DeleteReportsResponseCode);
            }
        }

        public static void VerifyAlreadyDeletedReportsResponse()
        {
            var response = client.Execute(restRequest);
            var DeleteReportsResponseCode = response.StatusCode;

            if (!(DeleteReportsResponseCode == System.Net.HttpStatusCode.NotFound))
            {
                Assert.Fail("Response Code: " + DeleteReportsResponseCode);
            }
        }

        public static void VerifyInvalidReportIDGetResponse()
        {
            var response = client.Execute(restRequest);
            var ReportsResponseCode = response.StatusCode;

            if (!(ReportsResponseCode == System.Net.HttpStatusCode.BadRequest))
            {
                Assert.Fail("Response Code: " + ReportsResponseCode);
            }
        }

        public static void VerifyPostRequestBadResponse(string errorMSG)
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var errormsg = response.Content;

            if (!((ResponseCode == System.Net.HttpStatusCode.BadRequest) && (errormsg.Contains(errorMSG))))
            {
                Assert.Fail("Response Code: " + ResponseCode);
            }
        }
    }
}