using AventStack.ExtentReports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Json;
using System.Windows.Data;
using Json.Net;
using Newtonsoft.Json.Schema;
using System.Reflection;

namespace IngramMicro.USIT.OST.API.Automation.Pages
{
    public static class OrderDetailsPage
    {
        public static RestClient client;
        public static RestRequest restRequest;

        public static RestClient SetURL(string APIUrl, string endpoint)
        {
            var url = APIUrl + endpoint;
            return client = new RestClient(url);
        }

        public static IRestResponse GetResponse()
        {
            return client.Execute(restRequest);
        }

        public static RestRequest GetOrderDetails(string authorization)
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddHeader("X-SourceSystem", "OST");
            restRequest.AddHeader("X-Request-ID", "100");
            return restRequest;
        }

        public static void VerifyResponseOK(string resellerID, string orderID, string expectedResponse, int row, int col)
        {            
            var GetOrdersResponseCode = GetResponse().StatusCode;
            var actualResponse = GetResponse().Content;
            var header = GetResponse().ErrorMessage;

            if ((GetOrdersResponseCode == System.Net.HttpStatusCode.OK) && (actualResponse == expectedResponse))
            {
                Assert.Pass("<b>Reseller ID:</b> " + resellerID + " <b>Order ID:</b> " + orderID + "<br />" + "Both actual and expected responses are same.");
            }
            /*else if ((GetOrdersResponseCode == System.Net.HttpStatusCode.OK) && ((actualResponse.Contains(dataPoint1)) && (actualResponse.Contains(dataPoint2)) && (actualResponse.Contains(dataPoint3)) && (actualResponse.Contains(dataPoint4)) && (actualResponse.Contains(dataPoint5)) && (actualResponse.Contains(dataPoint6))))
            {                
                actualResponse = actualResponse.ToString();
                //ReadWriteHelper.UpdateTestDataExcel(Constants.OrderDatailsTestDataDirectory, Constants.Environment, row, col, actualResponse);
                string test = "Reseller ID: " + resellerID + " Order ID: " + orderID + Environment.NewLine + " Partial data points are matched.";
                Assert.Pass(test);
            }*/
            else
            {
                Assert.Fail("<b>Reseller ID:</b> " + resellerID + " <b>Order ID:</b> " + orderID + " <b>Response Code:</b> " + GetOrdersResponseCode + "<br />" + " <b>Actual Response:</b> " + actualResponse + "<br />" + " <b>Expected Response:</b> " + expectedResponse);
            }
        }

        /*public static void VerifyResponseOK(string resellerID, string orderID, string expectedResponse)
        {
            var GetOrdersResponseCode = GetResponse().StatusCode;
            var actualResponse = GetResponse().Content;
            
            JSchema schema1 = JSchema.Parse(expectedResponse);
            JObject test = JObject.Parse(actualResponse);
            IList<string> validationEvents = new List<string>();
            if (test.IsValid(schema1))
            {

            }
            else
            {
                foreach (string evt in validationEvents)
                {
                    Console.WriteLine(evt);
                }
            }

            if (!((GetOrdersResponseCode == System.Net.HttpStatusCode.OK) && (actualResponse == expectedResponse)))
            {
                Assert.Fail(" Reseller ID: " + resellerID + " Order ID: " + orderID + "Response Code: " + GetOrdersResponseCode + " Actual Response: " + actualResponse);
            }
            else
            {
                Assert.Pass("Reseller ID: " + resellerID + " Order ID: " + orderID);
            }
        }*/

        public static void VerifyShipmentResponseOK(string resellerID, string orderID, string shipmentID, string expectedResponse, int row, int col)
        {
            var GetOrdersResponseCode = GetResponse().StatusCode;
            var actualResponse = GetResponse().Content;
            if ((GetOrdersResponseCode == System.Net.HttpStatusCode.OK) && (actualResponse == expectedResponse))
            {
                Assert.Pass("<b>Reseller ID:</b> " + resellerID + " <b>Order ID:</b> " + orderID + " <b>Shipment ID:</b> " + shipmentID + "<br />" + "Both actual and expected responses are same.");
                
            }
            /*else if ((GetOrdersResponseCode == System.Net.HttpStatusCode.OK) && ((actualResponse.Contains(dataPoint1)) && (actualResponse.Contains(dataPoint2)) && (actualResponse.Contains(dataPoint3)) && (actualResponse.Contains(dataPoint4)) && (actualResponse.Contains(dataPoint5)) && (actualResponse.Contains(dataPoint6))))
            {                
                actualResponse = actualResponse.ToString();
                //ReadWriteHelper.UpdateTestDataExcel(Constants.OrderDatailsTestDataDirectory, Constants.Environment, row, col, actualResponse);
                Assert.Pass("Reseller ID: " + resellerID + " Order ID: " + orderID + " Shipment ID: " + shipmentID + " Partial data points are matched.");
            }*/
            else
            {
                Assert.Fail("<b>Reseller ID:</b> " + resellerID + " <b>Order ID:</b> " + orderID + " <b>Shipment ID:</b> " + shipmentID + " <b>Response Code:</b> " + GetOrdersResponseCode + "<br />" + " <b>Actual Response:</b> " + actualResponse + "<br />" + " <b>Expected Response:</b> " + expectedResponse);
            }
        }
    }
}