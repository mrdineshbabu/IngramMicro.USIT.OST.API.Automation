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
using System.Text.RegularExpressions;
using System.Data;
using System.Threading;

namespace IngramMicro.USIT.OST.API.Automation.Pages
{
    public static class NotificationHubPage
    {
        public static RestClient client;
        public static RestRequest restRequest;
        public static string firstName = null;
        public static string requestsBody1 = null;
        public static string SubscriptionID = null;
        public static string userEmailConfigID1 = null;
        private static DataTable datafromNotificationHub = null;


        public static RestClient SetURL(string APIUrl, string endpoint)
        {
            var url = APIUrl + endpoint;
            return client = new RestClient(url);
        }

        public static IRestResponse GetResponse()
        {
            return client.Execute(restRequest);
        }        

        public static void VerifyResponseOK1(string resellerID, string orderID, string expectedResponse, int row, int col, string dataPoint1, string dataPoint2, string dataPoint3, string dataPoint4, string dataPoint5, string dataPoint6)
        {            
            var GetOrdersResponseCode = GetResponse().StatusCode;
            var actualResponse = GetResponse().Content;

            if ((GetOrdersResponseCode == System.Net.HttpStatusCode.OK) && (actualResponse == expectedResponse))
            {
                Assert.Pass("Reseller ID: " + resellerID + " Order ID: " + orderID + Environment.NewLine + " Both actual and expected responses are same.");
            }
            else if ((GetOrdersResponseCode == System.Net.HttpStatusCode.OK) && ((actualResponse.Contains(dataPoint1)) && (actualResponse.Contains(dataPoint2)) && (actualResponse.Contains(dataPoint3)) && (actualResponse.Contains(dataPoint4)) && (actualResponse.Contains(dataPoint5)) && (actualResponse.Contains(dataPoint6))))
            {                
                actualResponse = actualResponse.ToString();
                //ReadWriteHelper.UpdateTestDataExcel(Constants.OrderDatailsTestDataDirectory, Constants.Environment, row, col, actualResponse);
                string test = "Reseller ID: " + resellerID + " Order ID: " + orderID + Environment.NewLine + " Partial data points are matched.";
                Assert.Warn(test);
            }
            else
            {
                Assert.Fail(" Reseller ID: " + resellerID + " Order ID: " + orderID + "Response Code: " + GetOrdersResponseCode + " Actual Response: " + actualResponse);
            }
        }

        public static RestRequest PostSubscribableEventsRequests(string condition1, string condition2, string authorization)
        {            
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscribableEventsBody.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace(condition1, condition2);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static void VerifyPostSubscribableEventsResponse1()
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse1 = response.Content;
            var actualResponse = Regex.Replace(actualResponse1, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            JObject SubscribableEventsResponseBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscribableEventsResponse.json"));
            string responseBody = SubscribableEventsResponseBody.ToString();
            var expectedResponse = Regex.Replace(responseBody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");


            if (!((ResponseCode == System.Net.HttpStatusCode.OK) && (actualResponse == expectedResponse)))
            {
                Assert.Fail("Response Code: " + ResponseCode);
            }
        }
        public static void VerifyPostSubscribableEventsResponse(string expectedResponse)
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse = response.Content;

            if (!((ResponseCode == System.Net.HttpStatusCode.OK) && (actualResponse.Contains(expectedResponse))))
            {
                Assert.Fail("Response Code: " + ResponseCode);
            }
        }

        public static RestRequest PostEmailConfigurationRequests(string condition1, string condition2, string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\EmailConfiguration.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace(condition1, condition2);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostEmailCreateUpdateRequests(string condition1, string condition2, string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\EmailCreateOrUpdate.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace(condition1, condition2);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostEmailCreateRequests(string authorization)
        {
            firstName = CommanMethods.GenerateString(5);
            string lastName = CommanMethods.GenerateString(5);
            string email = firstName + "." + lastName;
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\EmailCreateOrUpdate.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            requestsBody1 = content.ToString().Replace("Dineshbabu", firstName).Replace("Uvarajulu", lastName).Replace("dineshbabu.uvarajulu", email);
            var requestBody = JsonConvert.DeserializeObject(requestsBody1);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostEmailCreateRequestsAlreadyExistsSubscription(string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\EmailCreateOrUpdate.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            var requestBody = JsonConvert.DeserializeObject(content);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostEmailCreateRequestsAlreadyExists(string authorization)
        {            
            var requestsBody = requestsBody1;
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }



        public static RestRequest PostEmailCreateRequests1(string authorization)
        {
            firstName = CommanMethods.GenerateString(5);
            string lastName = CommanMethods.GenerateString(5);
            string email = firstName + "." + lastName;
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\EmailCreateOrUpdateAppIdentifier.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            requestsBody1 = content.ToString().Replace("Dineshbabu", firstName).Replace("Uvarajulu", lastName).Replace("dineshbabu.uvarajulu", email);
            var requestBody = JsonConvert.DeserializeObject(requestsBody1);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostEmailUpdateRequests(string authorization)
        {
            string firstName1 = CommanMethods.GenerateString(5);          
            string requestsBody = requestsBody1.Replace("\"" + firstName + "\"", "\"" + firstName1 + "\"");
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostSubscribeRequests(string condition1, string condition2, string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscribeBody.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace(condition1, condition2);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostSubscribeRequestsAdd(string condition1, string condition2, string condition3, string condition4, string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscribeBodyAddSingleEvent.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace(condition1, condition2).Replace(condition3, condition4);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostSubscribeRequestsAddMultiple(string condition1, string condition2, string condition3, string condition4, string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscribeBodyAddMultipleEvent.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString();
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostSubscribeRequestsRemove(string condition1, string condition2, string condition3, string condition4, string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscribeBodyAddMultipleEvent.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace(condition1, condition2).Replace(condition3, condition4);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostSubscribeAllRequests(string condition1, string condition2, string condition3, string condition4, string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscribeAllBody.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace(condition1, condition2).Replace(condition3, condition4);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static void VerifyPostSubscribeAllResponse(string expectedResponse)
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse = response.Content;

            if (!((ResponseCode == System.Net.HttpStatusCode.OK) && (actualResponse.Contains(expectedResponse))))
            {
                Assert.Fail("Response Code: " + ResponseCode);
            }
        }


        public static RestRequest PostSubscribeRequests1(string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscribeBody.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString();
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostSubscriptionViewRequests(string condition1, string condition2, string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscriptionViewBody.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace(condition1, condition2);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostSubscriptionViewRequests1(string subscriptionID, string condition1, string condition2, string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscriptionViewBody.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace(condition1, condition2).Replace("af0be4ab-6d99-42f6-9055-44210ee33ec5", subscriptionID);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostUnSubscriptionRequests(string subscriptionID, string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\UnSubscribeBody.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace("AF0BE4AB-6D99-42F6-9055-44210EE33EC5", subscriptionID);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostSubscriptionViewRequests2(string subscriptionID, string condition1, string condition2, string authorization)
        {
            userEmailConfigID1 = "920A8F78-E025-4984-8A62-8306EEB5FD6F";
            string userEmailConfigID = userEmailConfigID1.ToLower()
;           JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscriptionViewBody.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace(condition1, condition2).Replace("af0be4ab-6d99-42f6-9055-44210ee33ec5", subscriptionID).Replace(userEmailConfigID1, userEmailConfigID);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostSubscriptionSearchRequests(string condition1, string condition2, string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscriptionSearchBody.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace(condition1, condition2);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostSubscriptionSearchRequests1(string condition1, string condition2, string condition3, string condition4, string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscriptionSearchBody.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace(condition1, condition2).Replace(condition3, condition4);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static RestRequest PostSubscriptionSearchRequests2(string condition1, string condition2, string condition3, string condition4, string authorization)
        {
            string condition5 = condition4.ToLower();
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscriptionSearchBody.json"));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            string requestsBody = content.ToString().Replace(condition1, condition2).Replace(condition3, condition5);
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static void VerifyPostSubscriptionViewResponse()
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse1 = response.Content;
            var actualResponse = Regex.Replace(actualResponse1, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            JObject SubscriptionViewResponseBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscriptionViewResponse.json"));
            string responseBody = SubscriptionViewResponseBody.ToString();
            var expectedResponse = Regex.Replace(responseBody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");


            if (!((ResponseCode == System.Net.HttpStatusCode.OK) && (actualResponse == expectedResponse)))
            {
                Assert.Fail("Response Code: " + ResponseCode + "Actual Response: " + actualResponse);
            }
        }

        public static void VerifyPostSubscriptionViewResponse1(string expectedResponse)
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse1 = response.Content;
            var actualResponse = Regex.Replace(actualResponse1, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            JObject SubscriptionViewResponseBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscriptionViewResponse.json"));
            string responseBody = SubscriptionViewResponseBody.ToString();
            


            if (!((ResponseCode == System.Net.HttpStatusCode.OK) && (actualResponse.Contains(expectedResponse))))
            {
                Assert.Fail("Response Code: " + ResponseCode + "Actual Response: " + actualResponse);
            }
        }

        public static void VerifyPostSubscriptionSearchResponse()
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse1 = response.Content;
            var actualResponse = Regex.Replace(actualResponse1, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            JObject SubscriptionViewResponseBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\SubscriptionSearchResponse.json"));
            string responseBody = SubscriptionViewResponseBody.ToString();
            var expectedResponse = Regex.Replace(responseBody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");


            if (!((ResponseCode == System.Net.HttpStatusCode.OK) && (actualResponse == expectedResponse)))
            {
                Assert.Fail("Response Code: " + ResponseCode + " Actual Response: " + actualResponse);
            }
        }

        public static RestRequest PostWhitelistedVendorRequests(string condition1, string condition2, string authorization)
        {
            JObject RequestsBody = JObject.Parse(File.ReadAllText(Constants.FilePath + @"\TestData\WhitelistedVendor.json"));
            string requestbody = RequestsBody.ToString();            
            string requestBody = requestbody.Replace(condition1, condition2);
            //var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static void VerifyPostWhitelistedVendorResponse(string expectedValue, string notexpectedValue1, string notexpectedValue2, string notexpectedValue3)
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse = response.Content;
            
            if (!((ResponseCode == System.Net.HttpStatusCode.OK) && (actualResponse.Contains(expectedValue)) && (!actualResponse.Contains(notexpectedValue1)) && (!actualResponse.Contains(notexpectedValue2)) && (!actualResponse.Contains(notexpectedValue3))))
            {
                Assert.Fail("Response Code: " + ResponseCode + " Actual Response: " + actualResponse);
            }
        }

        public static void VerifyPostWhitelistedVendorInvalidResponse(string expectedValue1, string expectedValue2, string expectedValue3, string expectedValue4)
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse = response.Content;

            if (!((ResponseCode == System.Net.HttpStatusCode.OK) && (actualResponse.Contains(expectedValue1)) && (actualResponse.Contains(expectedValue2)) && (actualResponse.Contains(expectedValue3)) && (actualResponse.Contains(expectedValue4))))
            {
                Assert.Fail("Response Code: " + ResponseCode + " Actual Response: " + actualResponse);
            }
        }

        public static void VerifyPostSubscribeOKResponse()
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse = response.Content;

            if ((ResponseCode == System.Net.HttpStatusCode.OK))
            {               
                dynamic json = JsonConvert.DeserializeObject(actualResponse);
                SubscriptionID = json.SubscriptionID;                
            }
            else
            {
                Assert.Fail("Response Code: " + ResponseCode + " Actual Response: " + actualResponse);
            }
        }

        public static void VerifyPostSubscribeOKResponse1(string expectedValue)
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse = response.Content;

            if (!((ResponseCode == System.Net.HttpStatusCode.OK) && (actualResponse.Contains(expectedValue))))
            {
                Assert.Fail("Response Code: " + ResponseCode + " Actual Response: " + actualResponse);
            }
        }

        public static void VerifyPostUnSubscribeOKResponse()
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse = response.Content;

            if (!(ResponseCode == System.Net.HttpStatusCode.OK))
            {
                Assert.Fail("Response Code: " + ResponseCode + " Actual Response: " + actualResponse);
            }
        }

        public static RestRequest PostValidateRequests(string path, string authorization)
        {
            JArray RequestsBody = JArray.Parse(File.ReadAllText(Constants.FilePath + path));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");            
            string requestsBody = content.ToString().Replace("2020-07-15", DateTime.Now.AddDays(-1).ToString());
            var requestBody = JsonConvert.DeserializeObject(requestsBody);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            //restRequest.AddJsonBody(requestBody);
            //restRequest.AddBody(requestBody);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static void VerifyPostValidateResponse()
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse = response.Content;
            Console.WriteLine(actualResponse);

            if (ResponseCode == System.Net.HttpStatusCode.OK)
            {
                Thread.Sleep(120000);
                string connstring = @"Server=db-qa-app-olr-na.corporate.ingrammicro.com\QA_APP_OLR_NA;initial catalog=NotificationHub;user id=NotificationHub_APP_User;password=egzjQ4bhPXJEQF2Y;persist security info=True;Connection Timeout = 7200";
                string query = "SELECT * FROM EventAudit ea WHERE ID = '" + actualResponse + "' AND DESCRIPTION = 'Notification Sent'";
                DataBaseHelper.DBConnection = connstring;
                datafromNotificationHub = DataBaseHelper.ExecuteQuery(query, DataBaseHelper.DBConnection);
                int dBcount = datafromNotificationHub.Rows.Count;
                if (dBcount < 1)
                {
                    Assert.Fail("Notification not sent");
                }                
            }
            else
            {
                Assert.Fail("Response Code: " + ResponseCode + " Actual Response: " + actualResponse);
            }
        }

        public static void VerifyPostValidateResponseNoLines()
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse = response.Content;

            if (ResponseCode == System.Net.HttpStatusCode.OK)
            {
                Thread.Sleep(60000);
                string connstring = @"Server=db-qa-app-olr-na.corporate.ingrammicro.com\QA_APP_OLR_NA;initial catalog=NotificationHub;user id=NotificationHub_APP_User;password=egzjQ4bhPXJEQF2Y;persist security info=True;Connection Timeout = 7200";
                string query = "SELECT * FROM EventAudit ea WHERE ID = '" + actualResponse + "' AND DESCRIPTION = 'Notification Sent'";
                DataBaseHelper.DBConnection = connstring;
                datafromNotificationHub = DataBaseHelper.ExecuteQuery(query, DataBaseHelper.DBConnection);
                int dBcount = datafromNotificationHub.Rows.Count;
                if (dBcount > 0)
                {
                    Assert.Fail("Notification not sent");
                }
            }
            else
            {
                Assert.Fail("Response Code: " + ResponseCode + " Actual Response: " + actualResponse);
            }
        }
        public static RestRequest PostValidateEventDateRequests(string path, string authorization)
        {
            JArray RequestsBody = JArray.Parse(File.ReadAllText(Constants.FilePath + path));
            string requestbody = RequestsBody.ToString();
            var content = Regex.Replace(requestbody, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            //string requestsBody = content.ToString().Replace("2020-07-15", DateTime.Now.AddDays(-1).ToString());
            var requestBody = JsonConvert.DeserializeObject(content);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", authorization);
            //restRequest.AddJsonBody(requestBody);
            //restRequest.AddBody(requestBody);
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public static void VerifyPostValidateEventDateResponse()
        {
            var response = client.Execute(restRequest);
            var ResponseCode = response.StatusCode;
            var actualResponse = response.Content;
            Console.WriteLine(actualResponse);

            if (ResponseCode == System.Net.HttpStatusCode.OK)
            {
                Thread.Sleep(120000);
                string connstring = @"Server=db-qa-app-olr-na.corporate.ingrammicro.com\QA_APP_OLR_NA;initial catalog=NotificationHub;user id=NotificationHub_APP_User;password=egzjQ4bhPXJEQF2Y;persist security info=True;Connection Timeout = 7200";
                string query = "SELECT * FROM EventAudit ea WHERE ID = '" + actualResponse + "' AND DESCRIPTION LIKE '%older%'";
                DataBaseHelper.DBConnection = connstring;
                datafromNotificationHub = DataBaseHelper.ExecuteQuery(query, DataBaseHelper.DBConnection);
                int dBcount = datafromNotificationHub.Rows.Count;
                if (dBcount < 1)
                {
                    Assert.Fail("Notification not sent");
                }
            }
            else
            {
                Assert.Fail("Response Code: " + ResponseCode + " Actual Response: " + actualResponse);
            }
        }

    }
}