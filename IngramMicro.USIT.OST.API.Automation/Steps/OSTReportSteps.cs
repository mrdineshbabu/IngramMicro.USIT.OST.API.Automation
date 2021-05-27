using IngramMicro.USIT.OST.API.Automation;
using IngramMicro.USIT.OST.API.Automation.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace IngramMicro.USIT.OST.API.Automation.Steps
{
    [Binding]
    public sealed class OSTReportSteps
    {
        public static string authorization = null;
        public static string resellerID = null;  
        public static DataRow[] testdataRow = null;
        public static string reportID = null;
        public static string flag = null;
        public static string errormsg = null;
        public static string expectedValue = null;
        public static string condition1 = null;
        public static string condition2 = null;
        public static string invoicedDays = null;

        [Given(@"I have post report Daily_Stock_Excel_UpdateEmail\(Add\)_E2E endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_UpdateEmailAdd_E2EEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_01";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the post method of the report API Daily - Excel - Stock Order")]
        public void WhenICallThePostMethodOfTheReportAPIDaily_Excel_StockOrder()
        {
            string ReportType = testdataRow[0]["Column10"].ToString();
            string FileType = testdataRow[0]["Column11"].ToString();
            string OrderType = testdataRow[0]["Column12"].ToString();
            OSTReportPage.PostReports(ReportType, FileType, OrderType, authorization);
        }

        [When(@"I call the post method of the report API Multiple Emai Daily - Excel - Stock Order")]
        public void WhenICallThePostMethodOfTheReportAPIMultipleEmaiDaily_Excel_StockOrder()
        {
            string ReportType = testdataRow[0]["Column10"].ToString();
            string FileType = testdataRow[0]["Column11"].ToString();
            string OrderType = testdataRow[0]["Column12"].ToString();
            string Email = testdataRow[0]["Column13"].ToString();
            OSTReportPage.PostReportsMultipleEmail(ReportType, FileType, OrderType, authorization, Email);
        }


        [Then(@"I get report API response with report ID")]
        public void ThenIGetReportAPIResponseWithReportID()
        {
            OSTReportPage.VerifyPostReportsResponse();
        }

        [Given(@"I have post report request endpoint (.*)")]
        public void GivenIHavePostReportRequestEndpointEndpoint(string endpoint)
        {
            reportID = OSTReportPage.reportID;
            string APIUrl = testdataRow[0]["Column3"].ToString();
            string Endpoint2 = testdataRow[0]["Column5"].ToString();
            string GenerateReportEndpoint = Endpoint2.Replace("resellerID", resellerID).Replace("reportID", reportID);
            OSTReportPage.SetURL(APIUrl, GenerateReportEndpoint);
        }

        [When(@"I call the post method of the report request API")]
        public void WhenICallThePostMethodOfTheReportRequestAPI()
        {
            string flag = testdataRow[0]["Column14"].ToString();
            OSTReportPage.PostReportRequests(flag, authorization);
        }       


        [Then(@"I get report request daily API response")]
        public void ThenIGetReportRequestDailyAPIResponse()
        {
            OSTReportPage.VerifyPostReportDailyRequestsResponse();
        }

        [Then(@"I get report request API response")]
        public void ThenIGetReportRequestAPIResponse()
        {
            string invoicedDays = testdataRow[0]["Column16"].ToString();
            OSTReportPage.VerifyPostReportRequestsResponse(invoicedDays);
        }

        [Given(@"I have patch report endpoint (.*)")]
        public void GivenIHavePatchReportEndpointEndpoint(string endpoint)
        {
            reportID = OSTReportPage.reportID;
            string APIUrl = testdataRow[0]["Column3"].ToString();
            string Endpoint3 = testdataRow[0]["Column6"].ToString();
            string PatchReportEndpoint = Endpoint3.Replace("resellerID", resellerID).Replace("reportID", reportID);
            OSTReportPage.SetURL(APIUrl, PatchReportEndpoint);
        }

        [When(@"I call the patch method of the reports API")]
        public void WhenICallThePatchMethodOfTheReportsAPI()
        {
            string email = testdataRow[0]["Column13"].ToString();
            OSTReportPage.PatchReportRequests(email, authorization);
        }



        [Then(@"I get report \(PATCH\) API response")]
        public void ThenIGetReportPATCHAPIResponse()
        {
            OSTReportPage.VerifyPatchReportsResponse();
        }

        [Given(@"I have delete report endpoint (.*)")]
        public void GivenIHaveDeleteReportEndpointEndpoint(string endpoint)
        {
            reportID = OSTReportPage.reportID;
            string APIUrl = testdataRow[0]["Column3"].ToString();
            string Endpoint4 = testdataRow[0]["Column7"].ToString();
            string DeleteReportEndpoint = Endpoint4.Replace("resellerID", resellerID).Replace("reportID", reportID);
            OSTReportPage.SetURL(APIUrl, DeleteReportEndpoint);
        }

        [When(@"I call the delete method of the reports API")]
        public void WhenICallTheDeleteMethodOfTheReportsAPI()
        {
            OSTReportPage.DeleteReportRequests(authorization);
        }       
        
        [Then(@"I get report \(DELETE\) API response")]
        public void ThenIGetReportDELETEAPIResponse()
        {
            OSTReportPage.VerifyDeleteReportsResponse();
        }

        [Given(@"I have delete invalid report ID endpoint (.*)")]
        public void GivenIHaveDeleteInvalidReportIDEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_14";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Then(@"I get invalid report \(DELETE\) API response")]
        public void ThenIGetInvalidReportDELETEAPIResponse()
        {
            OSTReportPage.VerifyDeleteInvalidReportsResponse();
        }

        [Then(@"I get report \(Already DELETE\) API response")]
        public void ThenIGetReportAlreadyDELETEAPIResponse()
        {
            OSTReportPage.VerifyAlreadyDeletedReportsResponse();
        }

        [Then(@"I get other reseller report \(DELETE\) API response")]
        public void ThenIGetOtherResellerReportDELETEAPIResponse()
        {
            OSTReportPage.VerifyAlreadyDeletedReportsResponse();
        }


        [Given(@"I have post report Daily_Stock_Excel_UpdateReportConfiguration_SentToSubscribers-True_E2E (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_UpdateReportConfiguration_SentToSubscribers_True_E2EEndpoint(string endpoint)
        {
            //DataRow[] filteredRows = Constants.OSTReportTestData.Select("Column9 = 'MD-14-451871'");
            string testcaseID = "TC2_02";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the post method of the report request API TRUE")]
        public void WhenICallThePostMethodOfTheReportRequestAPITRUE()
        {
            string flag = testdataRow[0]["Column14"].ToString();
            OSTReportPage.PostReportRequests(flag, authorization);
        }       

        [When(@"I call the post method of the report request API FALSE")]
        public void WhenICallThePostMethodOfTheReportRequestAPIFALSE()
        {
            string flag = testdataRow[0]["Column14"].ToString();
            OSTReportPage.PostReportRequests(flag, authorization);
        }

        [Given(@"I have post report Daily_Stock_CSV_Update Email Only-Remove_SentToSubscribers-False_E2E (.*)")]
        public void GivenIHavePostReportDaily_Stock_CSV_UpdateEmailOnly_Remove_SentToSubscribers_False_E2EEndpoint(string endpoint)
        {
            string testcaseID = "TC2_03";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have get report list request endpoint (.*)")]
        public void GivenIHaveGetReportListRequestEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_06";
            DataRow[] testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the get method of report list API")]
        public void WhenICallTheGetMethodOfReportListAPI()
        {
            OSTReportPage.GetReportListRequest(authorization);
        }

        [Then(@"I get report list API response")]
        public void ThenIGetReportListAPIResponse()
        {
            OSTReportPage.GetResponse();
            OSTReportPage.VerifyGetReportListResponse(expectedValue);
        }        

        [Given(@"I have put report list IsEditable-FALSE request endpoint (.*)")]
        public void GivenIHavePutReportListIsEditable_FALSERequestEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_07";
            DataRow[] testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the put method of report list API")]
        public void WhenICallThePutMethodOfReportListAPI()
        {            
            OSTReportPage.PutReportRequests(condition1, condition2, authorization);
        }

        [Then(@"I get report API response with error")]
        public void ThenIGetReportAPIResponseWithError()
        {            
            OSTReportPage.VerifyPutReportBadResponse(errormsg);
        }

        [Given(@"I have post report Daily_Stock_Excel endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_ExcelEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_09";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }


        [Given(@"I have put report list IsEditable-TRUE request endpoint (.*)")]
        public void GivenIHavePutReportListIsEditable_TRUERequestEndpointEndpoint(string endpoint)
        {
            reportID = OSTReportPage.reportID;
            string APIUrl = testdataRow[0]["Column3"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint2 = testdataRow[0]["Column5"].ToString();
            string Endpoint = Endpoint2.Replace("resellerID", resellerID).Replace("reportID", reportID);
            
            errormsg = testdataRow[0]["Column17"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [Then(@"I get report API response without error")]
        public void ThenIGetReportAPIResponseWithoutError()
        {
            OSTReportPage.VerifyPutResponse();
        }

        [Given(@"I have post report Daily_Stock_Excel Single Email Address endpoint /endpoint/")]
        public void GivenIHavePostReportDaily_Stock_ExcelSingleEmailAddressEndpointEndpoint()
        {
            string testcaseID = "TC2_17";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have the get reports endpoint /endpoint/")]
        public void GivenIHaveTheGetReportsEndpointEndpoint()
        {
            reportID = OSTReportPage.reportID;
            string APIUrl = testdataRow[0]["Column3"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint2 = testdataRow[0]["Column5"].ToString();
            string Endpoint = Endpoint2.Replace("resellerID", resellerID).Replace("reportID", reportID);
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [Then(@"I see single email id in the response")]
        public void ThenISeeSingleEmailIdInTheResponse()
        {
            OSTReportPage.VerifySingleEmail(expectedValue);
        }

        [Given(@"I have post report Daily_Stock_Excel Multiple Email Address endpoint /endpoint/")]
        public void GivenIHavePostReportDaily_Stock_ExcelMultipleEmailAddressEndpointEndpoint()
        {
            string testcaseID = "TC2_18";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Then(@"I see multiple email ids in the response")]
        public void ThenISeeMultipleEmailIdsInTheResponse()
        {
            OSTReportPage.VerifyMultipleEmail(expectedValue);
        }

        [Then(@"I see no email field in the response")]
        public void ThenISeeNoEmailFieldInTheResponse()
        {
            OSTReportPage.VerifyMultipleEmail(expectedValue);
        }


        [Given(@"I have get report formats request endpoint (.*)")]
        public void GivenIHaveGetReportFormatsRequestEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_63";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            //resellerID = testdataRow[0]["Column9"].ToString();
            string ReportConfigEndpoint = testdataRow[0]["Column4"].ToString();
            //string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the get method of report formats API")]
        public void WhenICallTheGetMethodOfReportFormatsAPI()
        {
            OSTReportPage.GetReportFormatsRequest(authorization);
        }

        [Then(@"I get report formats API response")]
        public void ThenIGetReportFormatsAPIResponse()
        {
            OSTReportPage.GetResponse();
            OSTReportPage.VerifyGetReportFormatsResponse();
        }

        [Given(@"I have get report formats for reseller request endpoint (.*)")]
        public void GivenIHaveGetReportFormatsForResellerRequestEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_64";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the get method of report formats for reseller API")]
        public void WhenICallTheGetMethodOfReportFormatsForResellerAPI()
        {
            OSTReportPage.GetReportFormatsResellerRequest(authorization);
        }

        [Then(@"I get report formats for reseller API response")]
        public void ThenIGetReportFormatsForResellerAPIResponse()
        {
            OSTReportPage.GetResponse();
            OSTReportPage.VerifyGetReportFormatsResellerResponse();
        }

        [Given(@"I have get report fields request endpoint (.*)")]
        public void GivenIHaveGetReportFieldsRequestEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_65";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            //resellerID = testdataRow[0]["Column9"].ToString();
            string ReportConfigEndpoint = testdataRow[0]["Column4"].ToString();
            //string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the get method of report fields API")]
        public void WhenICallTheGetMethodOfReportFieldsAPI()
        {
            OSTReportPage.GetReportFieldsRequest(authorization);
        }

        [Then(@"I get report fields API response")]
        public void ThenIGetReportFieldsAPIResponse()
        {
            OSTReportPage.GetResponse();
            OSTReportPage.VerifyGetReportFieldsResponse();
        }

        [Given(@"I have get report fields for reseller request endpoint (.*)")]
        public void GivenIHaveGetReportFieldsForResellerRequestEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_66";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the get method of report fields for reseller API")]
        public void WhenICallTheGetMethodOfReportFieldsForResellerAPI()
        {
            OSTReportPage.GetReportFieldsResellerRequest(authorization);
        }

        [Then(@"I get report fields for reseller API response")]
        public void ThenIGetReportFieldsForResellerAPIResponse()
        {
            OSTReportPage.GetResponse();
            OSTReportPage.VerifyGetReportFieldsResellerResponse();
        }

        [Given(@"I have get report invalid report ID endpoint (.*)")]
        public void GivenIHaveGetReportInvalidReportIDEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_12";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Then(@"I get invalid report id API response")]
        public void ThenIGetInvalidReportIdAPIResponse()
        {
            OSTReportPage.VerifyInvalidReportIDGetResponse();
        }


        [Given(@"I have post report Invalid Email Address endpoint (.*)")]
        public void GivenIHavePostReportInvalidEmailAddressEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_19";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have post report Remove Email Address field endpoint (.*)")]
        public void GivenIHavePostReportRemoveEmailAddressFieldEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_20";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have post report Remove Frequency field endpoint (.*)")]
        public void GivenIHavePostReportRemoveFrequencyFieldEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_21";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have post report Frequency other than daily or on_demand endpoint (.*)")]
        public void GivenIHavePostReportFrequencyOtherThanDailyOrOn_DemandEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_22";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have post report Remove scheduledTime endpoint (.*)")]
        public void GivenIHavePostReportRemoveScheduledTimeEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_23";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have post report FrequencyOn-Demand_Add scheduledTime field endpoint (.*)")]
        public void GivenIHavePostReportFrequencyOn_Demand_AddScheduledTimeFieldEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_24";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have post report Add scheduledTime value other than 00:00 to 23:00 endpoint (.*)")]
        public void GivenIHavePostReportAddScheduledTimeValueOtherThanToEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_25";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have post report Add scheduledTime value with Mins endpoint (.*)")]
        public void GivenIHavePostReportAddScheduledTimeValueWithMinsEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_26";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have post report Remove Report Format endpoint (.*)")]
        public void GivenIHavePostReportRemoveReportFormatEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_27";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have post report Duplicate ID number on Fields endpoint (.*)")]
        public void GivenIHavePostReportDuplicateIDNumberOnFieldsEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_28";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }


        [When(@"I call the post method of the report API")]
        public void WhenICallThePostMethodOfTheReportAPI()
        {
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.PostReportsBad(condition1, condition2, authorization);
        }

        [Then(@"I get report API response")]
        public void ThenIGetReportAPIResponse()
        {            
            OSTReportPage.VerifyPostReportsBadResponse(errormsg);
        }

        [Then(@"I get report API response with no email field")]
        public void ThenIGetReportAPIResponseWithNoEmailField()
        {
            OSTReportPage.VerifyPostReportsResponse();
        }


        [Given(@"I have get reports endpoint (.*)")]
        public void GivenIHaveGetReportsEndpointEndpoint(string endpoint)
        {
            string reportid = OSTReportPage.reportID;
            //OSTReportPage.SetURL("/OSTReportAPI/ost/v1/resellers/MD-14-451871/reports/" + reportid + "?user=OST Dev");
        }

        [When(@"I call the get method of the reports API")]
        public void WhenICallTheGetMethodOfTheReportsAPI()
        {
            OSTReportPage.GetReportsRequest(authorization);
        }

        [Then(@"I get reports API response")]
        public void ThenIGetReportsAPIResponse()
        {
            OSTReportPage.GetResponse();
            OSTReportPage.VerifyGetReportsResponse();
        }

        [Given(@"I have put report endpoint (.*)")]
        public void GivenIHavePutReportEndpointEndpoint(string endpoint)
        {
            string reportid = OSTReportPage.reportID;
            //OSTReportPage.SetURL("/OSTReportAPI/ost/v1/resellers/MD-14-451871/reports/" + reportid + "?user=OST Dev");
        }

        [When(@"I call the put method of the reports API Daily - Excel - Stock Order")]
        public void WhenICallThePutMethodOfTheReportsAPIDaily_Excel_StockOrder()
        {
            string ReportType = "daily";
            string FileType = "excel";
            string OrderType = "STOCK ORDER";
            OSTReportPage.PutReportRequests1(ReportType, FileType, OrderType, authorization);
        }
        
        [Then(@"I get report \(PUT\) API response")]
        public void ThenIGetReportPUTAPIResponse()
        {
            OSTReportPage.VerifyPutReportsResponse();
        }      
                
        [When(@"I call the post method of the report API On Demand - CSV - Cash Order")]
        public void WhenICallThePostMethodOfTheReportAPIOnDemand_CSV_CashOrder()
        {
            string ReportType = "on_demand";
            string FileType = "csv";
            string OrderType = "STOCK ORDER";
            OSTReportPage.PostReports(ReportType, FileType, OrderType, authorization);
        }

        [When(@"I call the put method of the reports API On Demand - CSV - Cash Order")]
        public void WhenICallThePutMethodOfTheReportsAPIOnDemand_CSV_CashOrder()
        {
            string ReportType = "on_demand";
            string FileType = "csv";
            string OrderType = "STOCK ORDER";
            OSTReportPage.PutReportRequests1(ReportType, FileType, OrderType, authorization);
        }

        [Given(@"I have post report Daily_Stock_Excel_Configure Columns order endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_ConfigureColumnsOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_29";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have put report list request endpoint (.*)")]
        public void GivenIHavePutReportListRequestEndpointEndpoint(string endpoint)
        {
            reportID = OSTReportPage.reportID;
            string APIUrl = testdataRow[0]["Column3"].ToString();
            string Endpoint2 = testdataRow[0]["Column5"].ToString();
            string GenerateReportEndpoint = Endpoint2.Replace("resellerID", resellerID).Replace("reportID", reportID);
            OSTReportPage.SetURL(APIUrl, GenerateReportEndpoint);
        }

        [Then(@"I get report API response with column changes")]
        public void ThenIGetReportAPIResponseWithColumnChanges()
        {
            OSTReportPage.VerifyPutReportResponse(errormsg);
        }

        [Given(@"I have post report Daily_Stock_Excel_Customized Columns Names endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_CustomizedColumnsNamesEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_30";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have post report Daily_Stock_Excel_Invalid Path endpoint /endpoint/")]
        public void GivenIHavePostReportDaily_Stock_Excel_InvalidPathEndpointEndpoint()
        {
            string testcaseID = "TC2_51";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the patch method of the reports API with invalid path")]
        public void WhenICallThePatchMethodOfTheReportsAPIWithInvalidPath()
        {
            OSTReportPage.PatchReportBadRequests(condition1, condition2, authorization);
        }
        
        [Then(@"I get report \(PATCH\) API bad response")]
        public void ThenIGetReportPATCHAPIBadResponse()
        {
            OSTReportPage.VerifyPatchBadResponse(errormsg);
        }

        [Given(@"I have post report Daily_Stock_Excel_Invalid Email endpoint /endpoint/")]
        public void GivenIHavePostReportDaily_Stock_Excel_InvalidEmailEndpointEndpoint()
        {
            string testcaseID = "TC2_60";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have post report Daily_Stock_Excel_Add Single Email endpoint /endpoint/")]
        public void GivenIHavePostReportDaily_Stock_Excel_AddSingleEmailEndpointEndpoint()
        {
            string testcaseID = "TC2_52";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the patch method of the reports API with Single Email")]
        public void WhenICallThePatchMethodOfTheReportsAPIWithSingleEmail()
        {
            OSTReportPage.PatchReportBadRequests(condition1, condition2, authorization);
        }

        [Then(@"I get report \(PATCH\) API valid response")]
        public void ThenIGetReportPATCHAPIValidResponse()
        {
            OSTReportPage.VerifyPatchResponse(errormsg);
        }

        [Then(@"I see valid email ids in the response")]
        public void ThenISeeValidEmailIdsInTheResponse()
        {
            OSTReportPage.VerifyMultipleEmail(expectedValue);
        }

        [Given(@"I have post report Daily_Stock_Excel_Add multiple Email endpoint /endpoint/")]
        public void GivenIHavePostReportDaily_Stock_Excel_AddMultipleEmailEndpointEndpoint()
        {
            string testcaseID = "TC2_53";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the patch method of the reports API with multiple Email")]
        public void WhenICallThePatchMethodOfTheReportsAPIWithMultipleEmail()
        {
            OSTReportPage.PatchReportBadRequests(condition1, condition2, authorization);
        }

        [Given(@"I have post report Daily_Stock_Excel_Add same Email endpoint /endpoint/")]
        public void GivenIHavePostReportDaily_Stock_Excel_AddSameEmailEndpointEndpoint()
        {
            string testcaseID = "TC2_54";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the patch method of the reports API with same Email")]
        public void WhenICallThePatchMethodOfTheReportsAPIWithSameEmail()
        {
            OSTReportPage.PatchReportBadRequests(condition1, condition2, authorization);
        }

        [Given(@"I have post report Daily_Stock_Excel_Add Already Subscribed Email endpoint /endpoint/")]
        public void GivenIHavePostReportDaily_Stock_Excel_AddAlreadySubscribedEmailEndpointEndpoint()
        {
            string testcaseID = "TC2_55";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the patch method of the reports API with Already Subscribed Email")]
        public void WhenICallThePatchMethodOfTheReportsAPIWithAlreadySubscribedEmail()
        {
            OSTReportPage.PatchReportBadRequests(condition1, condition2, authorization);
        }

        [Given(@"I have post report Daily_Stock_Excel_Remove Single Email endpoint /endpoint/")]
        public void GivenIHavePostReportDaily_Stock_Excel_RemoveSingleEmailEndpointEndpoint()
        {
            string testcaseID = "TC2_56";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the post method of the report API Remove Daily - Excel - Stock Order")]
        public void WhenICallThePostMethodOfTheReportAPIRemoveDaily_Excel_StockOrder()
        {
            string ReportType = testdataRow[0]["Column10"].ToString();
            string FileType = testdataRow[0]["Column11"].ToString();
            string OrderType = testdataRow[0]["Column12"].ToString();
            OSTReportPage.PostReportsRemove(ReportType, FileType, OrderType, authorization);
        }

        [When(@"I call the patch method of the reports API with Remove Single Email")]
        public void WhenICallThePatchMethodOfTheReportsAPIWithRemoveSingleEmail()
        {
            OSTReportPage.PatchReportRemoveRequests(condition1, condition2, authorization);
        }

        [Given(@"I have post report Daily_Stock_Excel_Remove multiple Email endpoint /endpoint/")]
        public void GivenIHavePostReportDaily_Stock_Excel_RemoveMultipleEmailEndpointEndpoint()
        {
            string testcaseID = "TC2_57";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the patch method of the reports API with Remove multiple Email")]
        public void WhenICallThePatchMethodOfTheReportsAPIWithRemoveMultipleEmail()
        {
            OSTReportPage.PatchReportRemoveRequests(condition1, condition2, authorization);
        }

        [Given(@"I have post report Daily_Stock_Excel_Remove Same Email endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_RemoveSameEmailEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_58";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the patch method of the reports API with Remove Same Email")]
        public void WhenICallThePatchMethodOfTheReportsAPIWithRemoveSameEmail()
        {
            OSTReportPage.PatchReportRemoveRequests(condition1, condition2, authorization);
        }

        [Given(@"I have post report Daily_Stock_Excel_Remove Already Removed Email endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_RemoveAlreadyRemovedEmailEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_59";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }
        
        
        [When(@"I call the patch method of the reports API with Remove Already Removed Email")]
        public void WhenICallThePatchMethodOfTheReportsAPIWithRemoveAlreadyRemovedEmail()
        {
            OSTReportPage.PatchReportRemoveRequests(condition1, condition2, authorization);
        }

        [Given(@"I have post report Daily_Stock_Excel_Add Upper Case Email endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_AddUpperCaseEmailEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_61";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the patch method of the reports API with Upper Case Email")]
        public void WhenICallThePatchMethodOfTheReportsAPIWithUpperCaseEmail()
        {
            OSTReportPage.PatchReportBadRequests(condition1, condition2, authorization);
        }

        [Given(@"I have post report Daily_Stock_Excel_Add Upper and Lower Case Email endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_AddUpperAndLowerCaseEmailEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_62";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            expectedValue = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the patch method of the reports API with Upper and Lower Case Email")]
        public void WhenICallThePatchMethodOfTheReportsAPIWithUpperAndLowerCaseEmail()
        {
            OSTReportPage.PatchReportBadRequests(condition1, condition2, authorization);
        }

        [Given(@"I have post report Daily_Stock_Excel_Remove SendToSubscribers endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_RemoveSendToSubscribersEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_43";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the post method of the report remove request API")]
        public void WhenICallThePostMethodOfTheReportRemoveRequestAPI()
        {
            OSTReportPage.PostReportRequestsRemove(condition1, condition2, authorization);
        }

        [Given(@"I have post report Daily_Stock_Excel_Remove Email Addresses field and SendToSubscribers_TRUE endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_RemoveEmailAddressesFieldAndSendToSubscribers_TRUEEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_44";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [Given(@"I have post report Daily_Stock_Excel_Remove Email Addresses field and SendToSubscribers_FALSE endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_RemoveEmailAddressesFieldAndSendToSubscribers_FALSEEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_45";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }
        [Then(@"I get report request daily API remove response")]
        public void ThenIGetReportRequestDailyAPIRemoveResponse()
        {
            OSTReportPage.VerifyPostReportsBadResponse(errormsg);
        }

        [Given(@"I have post report Daily_Stock_Excel_SendToSubscribers_TRUE endpoint /endpoint/")]
        public void GivenIHavePostReportDaily_Stock_Excel_SendToSubscribers_TRUEEndpointEndpoint()
        {
            string testcaseID = "TC2_46";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the post method of the report SendToSubscribers_TRUE request API")]
        public void WhenICallThePostMethodOfTheReportSendToSubscribers_TRUERequestAPI()
        {
            OSTReportPage.PostReportRequestsRemove(condition1, condition2, authorization);            
        }

        [Given(@"I have post report Daily_Stock_Excel_SendToSubscribers_FALSE endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_SendToSubscribers_FALSEEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_47";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the post method of the report SendToSubscribers_FALSE request API")]
        public void WhenICallThePostMethodOfTheReportSendToSubscribers_FALSERequestAPI()
        {
            OSTReportPage.PostReportRequestsRemove(condition1, condition2, authorization);
        }

        [Given(@"I have post report Daily_Stock_Excel_Update Delivery Mechanism Schedule endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_UpdateDeliveryMechanismScheduleEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_48";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have post report Daily_Stock_Excel_Update Fields endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_UpdateFieldsEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_49";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have post report Daily_Stock_Excel_Update filters endpoint (.*)")]
        public void GivenIHavePostReportDaily_Stock_Excel_UpdateFiltersEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_50";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }


        [Then(@"I get report API response with changes")]
        public void ThenIGetReportAPIResponseWithChanges()
        {
            OSTReportPage.VerifyPutReportResponse(errormsg);
        }

        [Given(@"I have post report Add 1_S_50-848432_On_Demand endpoint (.*)")]
        public void GivenIHavePostReportAdd1_S_50_848432_On_DemandEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_31";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column17"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have post report On_Demand_Stock_Excel_0_D_14-291091_On_Demand endpoint (.*)")]
        public void GivenIHavePostReportOn_Demand_Stock_Excel_0_D_14_291091_On_DemandEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_32";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of the report API On_Demand - Excel - Stock Order")]
        public void WhenICallThePostMethodOfTheReportAPIOn_Demand_Excel_StockOrder()
        {
            string ReportType1 = testdataRow[0]["Column10"].ToString();
            string ReportType2 = testdataRow[0]["Column17"].ToString();
            string FileType = testdataRow[0]["Column11"].ToString();
            string OrderType = testdataRow[0]["Column12"].ToString();
            OSTReportPage.PostReportsOnDemand(ReportType1, ReportType2, FileType, OrderType, authorization);
        }

        [Given(@"I have post report On_Demand_Stock_Excel_-1_S_70-811722_On_Demand endpoint (.*)")]
        public void GivenIHavePostReportOn_Demand_Stock_Excel__1_S_70_811722_On_DemandEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC2_33";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }        
                
        [When(@"I call the post method of the report request API\.")]
        public void WhenICallThePostMethodOfTheReportRequestAPI_()
        {
            OSTReportPage.PostReportRequest(authorization);
        }

        [Then(@"I get report request on demand API response with email")]
        public void ThenIGetReportRequestOnDemandAPIResponseWithEmail()
        {
            invoicedDays = testdataRow[0]["Column16"].ToString();
            OSTReportPage.VerifyPostReportRequestsResponse(invoicedDays);
        }

        [Given(@"I have post report On_Demand_Stock_Excel_-5_S_60-559472_On_Demand endpoint\. (.*)")]
        public void GivenIHavePostReportOn_Demand_Stock_Excel__5_S_60_559472_On_DemandEndpoint_Endpoint(string endpoint)
        {
            string testcaseID = "TC2_34";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have post report On_Demand_Stock_Excel_-9_D_40-033473_Daily endpoint\. (.*)")]
        public void GivenIHavePostReportOn_Demand_Stock_Excel__9_D_40_033473_DailyEndpoint_Endpoint(string endpoint)
        {
            string testcaseID = "TC2_35";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have post report On_Demand_Stock_Excel_-10_S_50-448473_On_Demand endpoint\. (.*)")]
        public void GivenIHavePostReportOn_Demand_Stock_Excel__10_S_50_448473_On_DemandEndpoint_Endpoint(string endpoint)
        {
            string testcaseID = "TC2_36";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have post report On_Demand_Stock_Excel_-11_S_60-750590_Daily endpoint\. (.*)")]
        public void GivenIHavePostReportOn_Demand_Stock_Excel__11_S_60_750590_DailyEndpoint_Endpoint(string endpoint)
        {
            string testcaseID = "TC2_37";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have post report On_Demand_Stock_Excel_-30_D_60-341520_On_Demand endpoint\. (.*)")]
        public void GivenIHavePostReportOn_Demand_Stock_Excel__30_D_60_341520_On_DemandEndpoint_Endpoint(string endpoint)
        {
            string testcaseID = "TC2_38";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have post report On_Demand_Stock_Excel_-29_S_72-217944_On_Daily endpoint\. (.*)")]
        public void GivenIHavePostReportOn_Demand_Stock_Excel__29_S_72_217944_On_DailyEndpoint_Endpoint(string endpoint)
        {
            string testcaseID = "TC2_39";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have post report On_Demand_Stock_Excel_-30_D_60-266956_On_Demand endpoint\. (.*)")]
        public void GivenIHavePostReportOn_Demand_Stock_Excel__30_D_60_266956_On_DemandEndpoint_Endpoint(string endpoint)
        {
            string testcaseID = "TC2_40";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID);
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, Endpoint);                               
        }

        [Given(@"I have post report On_Demand_Stock_Excel_-31_S_10-952850_On_Demand endpoint\. (.*)")]
        public void GivenIHavePostReportOn_Demand_Stock_Excel__31_S_10_952850_On_DemandEndpoint_Endpoint(string endpoint)
        {
            string testcaseID = "TC2_21";
            testdataRow = Constants.OSTReportTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            resellerID = testdataRow[0]["Column9"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string ReportConfigEndpoint = Endpoint1.Replace("resellerID", resellerID);
            errormsg = testdataRow[0]["Column18"].ToString();
            condition1 = testdataRow[0]["Column15"].ToString();
            condition2 = testdataRow[0]["Column16"].ToString();
            OSTReportPage.SetURL(APIUrl, ReportConfigEndpoint);
        }

        [When(@"I call the post method of the report API\.")]
        public void WhenICallThePostMethodOfTheReportAPI_()
        {
            string ReportType1 = testdataRow[0]["Column10"].ToString();
            string ReportType2 = testdataRow[0]["Column17"].ToString();
            string FileType = testdataRow[0]["Column11"].ToString();
            string OrderType = testdataRow[0]["Column12"].ToString();
            OSTReportPage.PostReportsOnDemand(ReportType1, ReportType2, FileType, OrderType, authorization);
        }       
         
        [Then(@"I get report request daily API response with email")]
        public void ThenIGetReportRequestDailyAPIResponseWithEmail()
        {
            invoicedDays = testdataRow[0]["Column16"].ToString();
            OSTReportPage.VerifyPostReportRequestsResponse(invoicedDays);
        }        

        [When(@"I call the post method of the report API ReportType Daily - Excel - Stock Order")]
        public void WhenICallThePostMethodOfTheReportAPIReportTypeDaily_Excel_StockOrder()
        {
            string ReportType1 = testdataRow[0]["Column10"].ToString();
            string ReportType2 = testdataRow[0]["Column17"].ToString();
            string FileType = testdataRow[0]["Column11"].ToString();
            string OrderType = testdataRow[0]["Column12"].ToString();
            OSTReportPage.PostReportsOnDemand(ReportType1, ReportType2, FileType, OrderType, authorization);
        }

    }
}