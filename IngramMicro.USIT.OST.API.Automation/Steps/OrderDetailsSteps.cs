using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using IngramMicro.USIT.OST.API.Automation.Pages;
using System.Data;
using IngramMicro.USIT.OST.API.Automation;
using System.IO;
using System.Threading;

namespace IngramMicro.USIT.OST.API.Automation.Steps
{
    [Binding]
    public sealed class OrderDetailsSteps
    {
        public static string authorization = null;
        public static string type = null;
        public static string resellerID = null;
        public static string orderID = null;
        public static string shipmentID = null;
        public static string expectedResponse = null;
        public int row;
        public int col;
        public static string dataPoint1 = null;
        public static string dataPoint2 = null;
        public static string dataPoint3 = null;
        public static string dataPoint4 = null;
        public static string dataPoint5 = null;
        public static string dataPoint6 = null;


        [Given(@"I have get trackings request - Stock Order endpoint (.*)")]
        public void GivenIHaveGetTrackingsRequest_StockOrderEndpointEndpoint(string endpoint)
        {
            /*int x = 0;
            do
            {
                string qry = string.Format(CommanMethods.GetDBQueryfromXML("EmailTriggered"));
                qry = qry.Replace("reportIDfromAPI", "'" + "52127" + "'");
                DataBaseHelper.DBConnection = CommanMethods.DBString("OSTReport");
                dataFromOST = DataBaseHelper.ExecuteQuery(qry, DataBaseHelper.DBConnection);
                Console.WriteLine("dataFromOST - " + dataFromOST.Rows.Count);
                string emailDeliveryStatus = dataFromOST.Rows[0]["EmailDeliveryStatus"].ToString();
                x = Int32.Parse(emailDeliveryStatus);
                //int x = 0;
            }   while (x == 1);


            if (x == 1)
            {
                Thread.Sleep(60000);
                ReadEmailHelper.ReadMailItems();
            }
            else
            {
                Assert.Fail("Email Delivery Failed");
            }*/

            string testcaseID = "TC1_01";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();            
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            //row = 2;
            //col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get trackings request - Cash Order endpoint (.*)")]
        public void GivenIHaveGetTrackingsRequest_CashOrderEndpointEndpoint(string endpoint)
        {                  
            string testcaseID = "TC1_02";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();            
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 3;
            col = 9;
            
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get trackings request - Directship Order endpoint (.*)")]
        public void GivenIHaveGetTrackingsRequest_DirectshipOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_03";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 4;
            col = 9;
            
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get trackings request - ODS Order endpoint (.*)")]
        public void GivenIHaveGetTrackingsRequest_ODSOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_04";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 5;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get trackings request - OLR Order endpoint (.*)")]
        public void GivenIHaveGetTrackingsRequest_OLROrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_05";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 6;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get trackings request - Multiple Tracking endpoint (.*)")]
        public void GivenIHaveGetTrackingsRequest_MultipleTrackingEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_06";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 7;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get trackings request - Tracking No\. Not Available endpoint (.*)")]
        public void GivenIHaveGetTrackingsRequest_TrackingNo_NotAvailableEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_07";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 8;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the get method of trackings API")]
        public void WhenICallTheGetMethodOfTrackingsAPI()
        {
            OrderDetailsPage.GetOrderDetails(authorization);
        }

        [Then(@"I get trackings API response")]
        public void ThenIGetTrackingsAPIResponse()
        {
            OrderDetailsPage.VerifyResponseOK(resellerID, orderID, expectedResponse, row, col);
        }

        [Given(@"I have get serials request - Cash Order_Single Serial endpoint (.*)")]
        public void GivenIHaveGetSerialsRequest_CashOrder_SingleSerialEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_08";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 9;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get serials request - Stock Order_Multiple Serial endpoint (.*)")]
        public void GivenIHaveGetSerialsRequest_StockOrder_MultipleSerialEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_09";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 10;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get serials request - Directship Order endpoint (.*)")]
        public void GivenIHaveGetSerialsRequest_DirectshipOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_10";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 11;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get serials request - ODS Order endpoint (.*)")]
        public void GivenIHaveGetSerialsRequest_ODSOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_11";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 12;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get serials request - OLR Order endpoint (.*)")]
        public void GivenIHaveGetSerialsRequest_OLROrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_12";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 13;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get serials request - Serials Not Present endpoint (.*)")]
        public void GivenIHaveGetSerialsRequest_SerialsNotPresentEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_13";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 14;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the get method of serials API")]
        public void WhenICallTheGetMethodOfSerialsAPI()
        {
            OrderDetailsPage.GetOrderDetails(authorization);
        }

        [Then(@"I get serials API response")]
        public void ThenIGetSerialsAPIResponse()
        {
            OrderDetailsPage.VerifyResponseOK(resellerID, orderID, expectedResponse, row, col);
        }

        [Given(@"I have get licenses request endpoint (.*)")]
        public void GivenIHaveGetLicensesRequestEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_14";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 15;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the get method of licenses API")]
        public void WhenICallTheGetMethodOfLicensesAPI()
        {
            OrderDetailsPage.GetOrderDetails(authorization);
        }

        [Then(@"I get licenses API response")]
        public void ThenIGetLicensesAPIResponse()
        {
            OrderDetailsPage.VerifyResponseOK(resellerID, orderID, expectedResponse, row, col);
        }

        [Given(@"I have get orders request - Stock Order endpoint (.*)")]
        public void GivenIHaveGetOrdersRequest_StockOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_15";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 16;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get orders request - Cash Order endpoint (.*)")]
        public void GivenIHaveGetOrdersRequest_CashOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_16";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 17;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get orders request - Direct Order endpoint (.*)")]
        public void GivenIHaveGetOrdersRequest_DirectOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_17";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 18;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get orders request - ODS Order endpoint (.*)")]
        public void GivenIHaveGetOrdersRequest_ODSOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_18";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 19;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get orders request - OLR Order endpoint (.*)")]
        public void GivenIHaveGetOrdersRequest_OLROrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_19";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 20;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the get method of orders API")]
        public void WhenICallTheGetMethodOfOrdersAPI()
        {
            OrderDetailsPage.GetOrderDetails(authorization);
        }

        [Then(@"I get orders API response")]
        public void ThenIGetOrdersAPIResponse()
        {
            OrderDetailsPage.VerifyResponseOK(resellerID, orderID, expectedResponse, row, col);
        }

        [Given(@"I have get lines request - Stock Order \(Single Shipment\) endpoint (.*)")]
        public void GivenIHaveGetLinesRequest_StockOrderSingleShipmentEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_20";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 21;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get lines request - Cash Order endpoint (.*)")]
        public void GivenIHaveGetLinesRequest_CashOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_21";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 22;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get lines request - Directship Order endpoint (.*)")]
        public void GivenIHaveGetLinesRequest_DirectshipOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_22";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 23;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get lines request - ODS Order endpoint (.*)")]
        public void GivenIHaveGetLinesRequest_ODSOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_23";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 24;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get lines request - OLR Order endpoint (.*)")]
        public void GivenIHaveGetLinesRequest_OLROrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_24";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 25;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get lines request - With Multiple Shipment endpoint (.*)")]
        public void GivenIHaveGetLinesRequest_WithMultipleShipmentEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_25";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 26;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get lines request - Partially Shipped Line Status endpoint (.*)")]
        public void GivenIHaveGetLinesRequest_PartiallyShippedLineStatusEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_26";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 27;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get lines request - Void Line Status endpoint (.*)")]
        public void GivenIHaveGetLinesRequest_VoidLineStatusEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_27";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 28;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get lines request - Open Line Status endpoint (.*)")]
        public void GivenIHaveGetLinesRequest_OpenLineStatusEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_28";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 29;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the get method of lines API")]
        public void WhenICallTheGetMethodOfLinesAPI()
        {
            OrderDetailsPage.GetOrderDetails(authorization);
        }

        [Then(@"I get lines API response")]
        public void ThenIGetLinesAPIResponse()
        {
            OrderDetailsPage.VerifyResponseOK(resellerID, orderID, expectedResponse, row, col);
        }             

        [Given(@"I have get tracking shipment request - Stock Order endpoint (.*)")]
        public void GivenIHaveGetTrackingShipmentRequest_StockOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_29";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            shipmentID = testdataRow[0]["Column8"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID).Replace("shipmentID", shipmentID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 30;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get tracking shipment request - Cash Order endpoint (.*)")]
        public void GivenIHaveGetTrackingShipmentRequest_CashOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_30";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            shipmentID = testdataRow[0]["Column8"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID).Replace("shipmentID", shipmentID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 31;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have get tracking shipment request - Direct Order endpoint (.*)")]
        public void GivenIHaveGetTrackingShipmentRequest_DirectOrderEndpointEndpoint(string endpoint)
        {
            string testcaseID = "TC1_31";
            DataRow[] testdataRow = Constants.OrderDetailsTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column5"].ToString();
            resellerID = testdataRow[0]["Column6"].ToString();
            orderID = testdataRow[0]["Column7"].ToString();
            shipmentID = testdataRow[0]["Column8"].ToString();
            string Endpoint1 = testdataRow[0]["Column4"].ToString();
            string Endpoint = Endpoint1.Replace("resellerID", resellerID).Replace("orderID", orderID).Replace("shipmentID", shipmentID);
            expectedResponse = testdataRow[0]["Column9"].ToString();
            row = 32;
            col = 9;
            OrderDetailsPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the get method of tracking shipment API")]
        public void WhenICallTheGetMethodOfTrackingShipmentAPI()
        {
            OrderDetailsPage.GetOrderDetails(authorization);
        }

        [Then(@"I get tracking shipment API response")]
        public void ThenIGetTrackingShipmentAPIResponse()
        {
            OrderDetailsPage.VerifyShipmentResponseOK(resellerID, orderID, shipmentID, expectedResponse, row, col);
        }              
    }
}