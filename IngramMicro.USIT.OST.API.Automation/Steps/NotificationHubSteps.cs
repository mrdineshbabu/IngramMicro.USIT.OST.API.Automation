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
    public sealed class NotificationHubSteps
    {
        public static string authorization = null;
        public static string type = null;
        public static string resellerID = null;
        public static string orderID = null;
        public static string shipmentID = null;
        public static DataRow[] testdataRow = null;
        public static string errormsg = null;
        public static string expectedResponse = null;
        public static string expectedResponse1 = null;
        public static string condition1 = null;
        public static string condition2 = null;
        public static string condition3 = null;
        public static string condition4 = null;

        [Given(@"I have subscribable events request - Remove Source System endpoint /endpoint/")]
        public void GivenIHaveSubscribableEventsRequest_RemoveSourceSystemEndpointEndpoint()
        {
            string testcaseID = "TC3_01";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of subscribable events API")]
        public void WhenICallThePostMethodOfSubscribableEventsAPI()
        {
            NotificationHubPage.PostSubscribableEventsRequests(condition1, condition2, authorization);
        }

        [Then(@"I get subscribable events API response with error")]
        public void ThenIGetSubscribableEventsAPIResponseWithError()
        {
            NotificationHubPage.VerifyPostSubscribableEventsResponse(expectedResponse);
        }

        [Then(@"I get subscribable events API response")]
        public void ThenIGetSubscribableEventsAPIResponse()
        {
            NotificationHubPage.VerifyPostSubscribableEventsResponse(expectedResponse);
        }


        [Given(@"I have subscribable events request - Remove UserEmailConfigurationID endpoint /endpoint/")]
        public void GivenIHaveSubscribableEventsRequest_RemoveUserEmailConfigurationIDEndpointEndpoint()
        {
            string testcaseID = "TC3_02";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Then(@"I get subscribable events API response without error")]
        public void ThenIGetSubscribableEventsAPIResponseWithoutError()
        {
            NotificationHubPage.VerifyPostSubscribableEventsResponse1();
        }

        [Given(@"I have subscribable events request - other than reseller endpoint /endpoint/")]
        public void GivenIHaveSubscribableEventsRequest_OtherThanResellerEndpointEndpoint()
        {
            string testcaseID = "TC3_03";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have emailConfiguration request SubscriberType_Reseller endpoint /endpoint/")]
        public void GivenIHaveEmailConfigurationRequestSubscriberType_ResellerEndpointEndpoint()
        {
            string testcaseID = "TC3_04";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of emailConfiguration API")]
        public void WhenICallThePostMethodOfEmailConfigurationAPI()
        {
            NotificationHubPage.PostEmailConfigurationRequests(condition1, condition2, authorization);
        }

        [Then(@"I get emailConfiguration API response")]
        public void ThenIGetEmailConfigurationAPIResponse()
        {
            NotificationHubPage.VerifyPostSubscribableEventsResponse(expectedResponse);
        }

        [Given(@"I have emailConfiguration request SubscriberType_Incorrect endpoint /endpoint/")]
        public void GivenIHaveEmailConfigurationRequestSubscriberType_IncorrectEndpointEndpoint()
        {
            string testcaseID = "TC3_05";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscribe request - Remove Both Source System & UserEmailConfigurationID endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequest_RemoveBothSourceSystemUserEmailConfigurationIDEndpointEndpoint()
        {
            string testcaseID = "TC3_06";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of subscribe API")]
        public void WhenICallThePostMethodOfSubscribeAPI()
        {
            NotificationHubPage.PostSubscribeRequests(condition1, condition2, authorization);
        }

        [Then(@"I get subscribe API response with error")]
        public void ThenIGetSubscribeAPIResponseWithError()
        {
            NotificationHubPage.VerifyPostSubscribableEventsResponse(expectedResponse);
        }

        [Given(@"I have subscribe request - Account Level_Reseller_Order Confirmation_Add Subscribe endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequest_AccountLevel_Reseller_OrderConfirmation_AddSubscribeEndpointEndpoint()
        {
            string testcaseID = "TC3_09";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscribe request - Order Level_Reseller_Order In Fulfillment_Add Subscribe endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequest_OrderLevel_Reseller_OrderInFulfillment_AddSubscribeEndpointEndpoint()
        {
            string testcaseID = "TC3_10";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscribe request - Order Level_Reseller_Order Shipped_With Subscription ID_Add Subscribe endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequest_OrderLevel_Reseller_OrderShipped_WithSubscriptionID_AddSubscribeEndpointEndpoint()
        {
            string testcaseID = "TC3_11";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscribe request - Order Level_Reseller_Order Delivered_With Subscription ID_Add Subscribe endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequest_OrderLevel_Reseller_OrderDelivered_WithSubscriptionID_AddSubscribeEndpointEndpoint()
        {
            string testcaseID = "TC3_12";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscribe request - Order Level_Reseller_Order Changed_With Subscription ID_Add Subscribe endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequest_OrderLevel_Reseller_OrderChanged_WithSubscriptionID_AddSubscribeEndpointEndpoint()
        {
            string testcaseID = "TC3_13";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }


        [When(@"I call the post method of subscribe API Add")]
        public void WhenICallThePostMethodOfSubscribeAPIAdd()
        {
            NotificationHubPage.PostSubscribeRequestsAdd(condition1, condition2, condition3, condition4, authorization);
        }

        [Given(@"I have subscribe request - Order Level_Reseller_Multiple Events_Multiple Emails_Add Subscribe endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequest_OrderLevel_Reseller_MultipleEvents_MultipleEmails_AddSubscribeEndpointEndpoint()
        {
            string testcaseID = "TC3_14";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of subscribe API Add multiple")]
        public void WhenICallThePostMethodOfSubscribeAPIAddMultiple()
        {
            NotificationHubPage.PostSubscribeRequestsAddMultiple(condition1, condition2, condition3, condition4, authorization);
        }

        [Given(@"I have subscribe request - Order Level_Reseller_Order Changed_Remove Subscribe endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequest_OrderLevel_Reseller_OrderChanged_RemoveSubscribeEndpointEndpoint()
        {
            string testcaseID = "TC3_14";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscribe request - Order Level_Reseller_Add Subscribe & Remove Subscribe_Different EmailConfigurationID endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequest_OrderLevel_Reseller_AddSubscribeRemoveSubscribe_DifferentEmailConfigurationIDEndpointEndpoint()
        {
            string testcaseID = "TC3_16";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }


        [When(@"I call the post method of subscribe API Remove")]
        public void WhenICallThePostMethodOfSubscribeAPIRemove()
        {
            NotificationHubPage.PostSubscribeRequestsRemove(condition1, condition2, condition3, condition4, authorization);
        }

        [Then(@"I get subscribe API response remove")]
        public void ThenIGetSubscribeAPIResponseRemove()
        {
            NotificationHubPage.VerifyPostSubscribeOKResponse1(expectedResponse);
        }


        [Given(@"I have subscribe request - Remove Source System endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequest_RemoveSourceSystemEndpointEndpoint()
        {
            string testcaseID = "TC3_07";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscribe request - Remove UserEmailConfigurationID endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequest_RemoveUserEmailConfigurationIDEndpointEndpoint()
        {
            string testcaseID = "TC3_08";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscribe request - Invalid Action endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequest_InvalidActionEndpointEndpoint()
        {
            string testcaseID = "TC3_20";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscription all request - Account Level_Reseller_Single Email Configuration ID endpoint /endpoint/")]
        public void GivenIHaveSubscriptionAllRequest_AccountLevel_Reseller_SingleEmailConfigurationIDEndpointEndpoint()
        {
            string testcaseID = "TC3_21";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscription all request - Order Level_Reseller_Multiple Email Configuration IDs endpoint /endpoint/")]
        public void GivenIHaveSubscriptionAllRequest_OrderLevel_Reseller_MultipleEmailConfigurationIDsEndpointEndpoint()
        {
            string testcaseID = "TC3_22";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscription all request - Account Level_Reseller_Multiple Email Configuration IDs endpoint /endpoint/")]
        public void GivenIHaveSubscriptionAllRequest_AccountLevel_Reseller_MultipleEmailConfigurationIDsEndpointEndpoint()
        {
            string testcaseID = "TC3_23";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of subscribe all API")]
        public void WhenICallThePostMethodOfSubscribeAllAPI()
        {
            NotificationHubPage.PostSubscribeAllRequests(condition1, condition2, condition3, condition4, authorization);
        }

        [Then(@"I get subscribe all API response")]
        public void ThenIGetSubscribeAllAPIResponse()
        {
            NotificationHubPage.VerifyPostSubscribeAllResponse(expectedResponse);
        }



        [Given(@"I have subscription view request - Remove Source System_View API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionViewRequest_RemoveSourceSystem_ViewAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_26";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of subscription view API")]
        public void WhenICallThePostMethodOfSubscriptionViewAPI()
        {
            NotificationHubPage.PostSubscriptionViewRequests(condition1, condition2, authorization);
        }

        [Then(@"I get subscription API response with error")]
        public void ThenIGetSubscriptionAPIResponseWithError()
        {
            NotificationHubPage.VerifyPostSubscribableEventsResponse(expectedResponse);
        }

        [Given(@"I have subscription view request - VisibilityLevel_All_View API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionViewRequest_VisibilityLevel_All_ViewAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_30";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscription view request - VisibilityLevel_Subscriber_View API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionViewRequest_VisibilityLevel_Subscriber_ViewAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_31";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }


        [Then(@"I get subscription view API response")]
        public void ThenIGetSubscriptionViewAPIResponse()
        {
            NotificationHubPage.VerifyPostSubscribableEventsResponse(expectedResponse);
        }


        [Given(@"I have subscription view request - Remove Both Source System & UserEmailConfigurationID_View API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionViewRequest_RemoveBothSourceSystemUserEmailConfigurationID_ViewAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_29";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscription view request - Remove UserEmailConfigurationID_View API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionViewRequest_RemoveUserEmailConfigurationID_ViewAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_27";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Then(@"I get subscription API response without error")]
        public void ThenIGetSubscriptionAPIResponseWithoutError()
        {
            NotificationHubPage.VerifyPostSubscriptionViewResponse1(expectedResponse);
        }

        [Given(@"I have subscription view request - Remove VisibilityLevel\(Default\)_View API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionViewRequest_RemoveVisibilityLevelDefault_ViewAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_28";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have Whitelisted Vendor API request - Order Shipped endpoint /endpoint/")]
        public void GivenIHaveWhitelistedVendorAPIRequest_OrderShippedEndpointEndpoint()
        {
            string testcaseID = "TC3_73";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();            
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of Whitelisted Vendor API")]
        public void WhenICallThePostMethodOfWhitelistedVendorAPI()
        {
            NotificationHubPage.PostWhitelistedVendorRequests(condition1, condition2, authorization);
        }

        [Then(@"I get Whitelisted Vendor API response for Order Shipped")]
        public void ThenIGetWhitelistedVendorAPIResponseforOrderShipped()
        {
            string expectedValue = "Order Shipped";
            string notexpectedValue1 = "In Fulfillment";
            string notexpectedValue2 = "Order Invoice";
            string notexpectedValue3 = "Order Delivered";
            NotificationHubPage.VerifyPostWhitelistedVendorResponse(expectedValue, notexpectedValue1, notexpectedValue2, notexpectedValue3);
        }

        [Given(@"I have Whitelisted Vendor API request - In Fulfillment endpoint /endpoint/")]
        public void GivenIHaveWhitelistedVendorAPIRequest_InFulfillmentEndpointEndpoint()
        {
            string testcaseID = "TC3_74";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Then(@"I get Whitelisted Vendor API response for In Fulfillment")]
        public void ThenIGetWhitelistedVendorAPIResponseForInFulfillment()
        {
            string expectedValue = "In Fulfillment";
            string notexpectedValue1 = "Order Shipped";
            string notexpectedValue2 = "Order Invoice";
            string notexpectedValue3 = "Order Delivered";
            NotificationHubPage.VerifyPostWhitelistedVendorResponse(expectedValue, notexpectedValue1, notexpectedValue2, notexpectedValue3);
        }

        [Given(@"I have Whitelisted Vendor API request - Order Invoice endpoint /endpoint/")]
        public void GivenIHaveWhitelistedVendorAPIRequest_OrderInvoiceEndpointEndpoint()
        {
            string testcaseID = "TC3_75";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Then(@"I get Whitelisted Vendor API response for Order Invoice")]
        public void ThenIGetWhitelistedVendorAPIResponseForOrderInvoice()
        {
            string expectedValue = "Order Invoice";
            string notexpectedValue1 = "Order Shipped";
            string notexpectedValue2 = "In Fulfillment";
            string notexpectedValue3 = "Order Delivered";
            NotificationHubPage.VerifyPostWhitelistedVendorResponse(expectedValue, notexpectedValue1, notexpectedValue2, notexpectedValue3);
        }

        [Given(@"I have Whitelisted Vendor API request - Order Delivered endpoint /endpoint/")]
        public void GivenIHaveWhitelistedVendorAPIRequest_OrderDeliveredEndpointEndpoint()
        {
            string testcaseID = "TC3_76";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Then(@"I get Whitelisted Vendor API response for Order Delivered")]
        public void ThenIGetWhitelistedVendorAPIResponseForOrderDelivered()
        {
            string expectedValue = "Order Delivered";
            string notexpectedValue1 = "Order Shipped";
            string notexpectedValue2 = "Order Invoice";
            string notexpectedValue3 = "In Fulfillment";
            NotificationHubPage.VerifyPostWhitelistedVendorResponse(expectedValue, notexpectedValue1, notexpectedValue2, notexpectedValue3);
        }

        [Given(@"I have Whitelisted Vendor API request - Invalid Notification Type endpoint /endpoint/")]
        public void GivenIHaveWhitelistedVendorAPIRequest_InvalidNotificationTypeEndpointEndpoint()
        {
            string testcaseID = "TC3_77";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Then(@"I get Whitelisted Vendor API response for Invalid Notification Type")]
        public void ThenIGetWhitelistedVendorAPIResponseForInvalidNotificationType()
        {
            string expectedValue1 = "In Fulfillment";
            string expectedValue2 = "Order Shipped";
            string expectedValue3 = "Order Invoice";
            string expectedValue4 = "Order Delivered";
            NotificationHubPage.VerifyPostWhitelistedVendorInvalidResponse(expectedValue1, expectedValue2, expectedValue3, expectedValue4);
        }

        [Given(@"I have subscription search request - Remove Source System_Search API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionSearchRequest_RemoveSourceSystem_SearchAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_38";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscription search request - Remove UserEmailConfigurationID_Search API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionSearchRequest_RemoveUserEmailConfigurationID_SearchAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_39";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscription search request - Remove VisibilityLevel\(Default\)_Search API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionSearchRequest_RemoveVisibilityLevelDefault_SearchAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_40";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscription search request - Remove Both Source System & UserEmailConfigurationID_Search API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionSearchRequest_RemoveBothSourceSystemUserEmailConfigurationID_SearchAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_41";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of subscription search API")]
        public void WhenICallThePostMethodOfSubscriptionSearchAPI()
        {
            NotificationHubPage.PostSubscriptionSearchRequests(condition1, condition2, authorization);
        }        

        [Then(@"I get subscription search API response with error")]
        public void ThenIGetSubscriptionSearchAPIResponseWithError()
        {
            NotificationHubPage.VerifyPostSubscribableEventsResponse(expectedResponse);
        }

        [Then(@"I get subscription search API response without error")]
        public void ThenIGetSubscriptionSearchAPIResponseWithoutError()
        {
            NotificationHubPage.VerifyPostSubscriptionSearchResponse();
        }

        [Given(@"I have subscription search request - VisibilityLevel_Except All_Invalid_Search API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionSearchRequest_VisibilityLevel_ExceptAll_Invalid_SearchAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_48";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }
        

        [Given(@"I have emailConfiguration request Remove Source System_createOrUpdate endpoint /endpoint/")]
        public void GivenIHaveEmailConfigurationRequestRemoveSourceSystem_CreateOrUpdateEndpointEndpoint()
        {
            string testcaseID = "TC3_49";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of emailCreateUpdate API")]
        public void WhenICallThePostMethodOfEmailCreateUpdateAPI()
        {
            NotificationHubPage.PostEmailCreateUpdateRequests(condition1, condition2, authorization);
        }

        [Given(@"I have emailConfiguration request Remove UserEmailConfigurationID_createOrUpdate endpoint /endpoint/")]
        public void GivenIHaveEmailConfigurationRequestRemoveUserEmailConfigurationID_CreateOrUpdateEndpointEndpoint()
        {
            string testcaseID = "TC3_50";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have emailConfiguration request Remove Both Source System & UserEmailConfigurationID_createOrUpdate endpoint /endpoint/")]
        public void GivenIHaveEmailConfigurationRequestRemoveBothSourceSystemUserEmailConfigurationID_CreateOrUpdateEndpointEndpoint()
        {
            string testcaseID = "TC3_51";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have emailConfiguration request createOrUpdate_Create endpoint /endpoint/")]
        public void GivenIHaveEmailConfigurationRequestCreateOrUpdate_CreateEndpointEndpoint()
        {
            string testcaseID = "TC3_52";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have emailConfiguration request createOrUpdate_Create EmailAddress is already available in NotificationHub, and it has few subscriptions attached to it endpoint /endpoint/")]
        public void GivenIHaveEmailConfigurationRequestCreateOrUpdate_CreateEmailAddressIsAlreadyAvailableInNotificationHubAndItHasFewSubscriptionsAttachedToItEndpointEndpoint()
        {
            string testcaseID = "TC3_57";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of email Create already available with subscription API")]
        public void WhenICallThePostMethodOfEmailCreateAlreadyAvailableWithSubscriptionAPI()
        {
            NotificationHubPage.PostEmailCreateRequestsAlreadyExistsSubscription(authorization);
        }


        [Given(@"I have emailConfiguration request createOrUpdate_Create already available endpoint /endpoint/")]
        public void GivenIHaveEmailConfigurationRequestCreateOrUpdate_CreateAlreadyAvailableEndpointEndpoint()
        {
            string testcaseID = "TC3_56";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of email already exists API")]
        public void WhenICallThePostMethodOfEmailAlreadyExistsAPI()
        {
            NotificationHubPage.PostEmailCreateRequestsAlreadyExists(authorization);
        }


        [When(@"I call the post method of email Create API")]
        public void WhenICallThePostMethodOfEmailCreateAPI()
        {
            NotificationHubPage.PostEmailCreateRequests(authorization);
        }

        [Given(@"I have emailConfiguration request createOrUpdate_Update endpoint /endpoint/")]
        public void GivenIHaveEmailConfigurationRequestCreateOrUpdate_UpdateEndpointEndpoint()
        {
            string testcaseID = "TC3_53";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have emailConfiguration request createOrUpdate_With Application Identifier endpoint /endpoint/")]
        public void GivenIHaveEmailConfigurationRequestCreateOrUpdate_WithApplicationIdentifierEndpointEndpoint()
        {
            string testcaseID = "TC3_54";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of email Create API request")]
        public void WhenICallThePostMethodOfEmailCreateAPIRequest()
        {
            NotificationHubPage.PostEmailCreateRequests1(authorization);
        }


        [Given(@"I have emailConfiguration request createOrUpdate_Update one endpoint /endpoint/")]
        public void GivenIHaveEmailConfigurationRequestCreateOrUpdate_UpdateOneEndpointEndpoint()
        {
            string testcaseID = "TC3_53";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse1 = testdataRow[0]["Column14"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of email Update API")]
        public void WhenICallThePostMethodOfEmailUpdateAPI()
        {
            NotificationHubPage.PostEmailUpdateRequests(authorization);
        }

        [Then(@"I get emailConfiguration update API response")]
        public void ThenIGetEmailConfigurationUpdateAPIResponse()
        {
            NotificationHubPage.VerifyPostSubscribableEventsResponse(expectedResponse1);
        }

        [Given(@"I have subscribe request endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequestEndpointEndpoint()
        {
            string testcaseID = "TC3_34";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have the unsubscribe request endpoint (.*)")]
        public void GivenIHaveTheUnsubscribeRequestEndpointEndpoint(string endpoint)
        {
            
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column6"].ToString();

            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of unsubscribe API\.")]
        public void WhenICallThePostMethodOfUnsubscribeAPI_()
        {
            string subscriptionID = NotificationHubPage.SubscriptionID;
            NotificationHubPage.PostUnSubscriptionRequests(subscriptionID, authorization);
        }

        [Then(@"I get unsubscribe API response")]
        public void ThenIGetUnsubscribeAPIResponse()
        {
            NotificationHubPage.VerifyPostUnSubscribeOKResponse();
        }


        [Given(@"I have subscribe request one endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequestOneEndpointEndpoint()
        {
            string testcaseID = "TC3_35";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscribe request two endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequestTwoEndpointEndpoint()
        {
            string testcaseID = "TC3_36";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscribe request three endpoint /endpoint/")]
        public void GivenIHaveSubscribeRequestThreeEndpointEndpoint()
        {
            string testcaseID = "TC3_37";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }


        [When(@"I call the post method of subscribe API\.")]
        public void WhenICallThePostMethodOfSubscribeAPI_()
        {
            NotificationHubPage.PostSubscribeRequests1(authorization);
        }

        [Then(@"I get subscribe API response")]
        public void ThenIGetSubscribeAPIResponse()
        {
            NotificationHubPage.VerifyPostSubscribeOKResponse();
        }

        [Given(@"I have subscription view request - VisibilityLevel_Both All & Subscribed_View API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionViewRequest_VisibilityLevel_BothAllSubscribed_ViewAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_34";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column5"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }
        
        [When(@"I call the post method of subscription view API\.")]
        public void WhenICallThePostMethodOfSubscriptionViewAPI_()
        {
            string subcriptionID = NotificationHubPage.SubscriptionID;
            NotificationHubPage.PostSubscriptionViewRequests1(subcriptionID, condition1, condition2, authorization);
        }

        [Given(@"I have subscription view request - VisibilityLevel_All_UserEmailConfiguration ID&Subscription ID_Lowercase_View API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionViewRequest_VisibilityLevel_All_UserEmailConfigurationIDSubscriptionID_Lowercase_ViewAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_35";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column5"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of subscription view API request")]
        public void WhenICallThePostMethodOfSubscriptionViewAPIRequest()
        {
            string subcriptionID = NotificationHubPage.SubscriptionID.ToLower();
            NotificationHubPage.PostSubscriptionViewRequests2(subcriptionID, condition1, condition2, authorization);
        }

        [Then(@"I get subscription API response without error\.")]
        public void ThenIGetSubscriptionAPIResponseWithoutError_()
        {
            string expectedValue = NotificationHubPage.userEmailConfigID1;
            NotificationHubPage.VerifyPostSubscribeOKResponse1(expectedValue);
        }

        [Given(@"I have subscription view request - VisibilityLevel_Subscriber_UserEmailConfiguration ID&Subscription ID_Lowercase_View API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionViewRequest_VisibilityLevel_Subscriber_UserEmailConfigurationIDSubscriptionID_Lowercase_ViewAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_36";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column5"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscription view request - Invalid / No relation between SubscriptionID and UserEmailConfigurationID_View API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionViewRequest_InvalidNoRelationBetweenSubscriptionIDAndUserEmailConfigurationID_ViewAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_37";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column5"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }
        
        [Given(@"I have subscription search request - Remove VisibilityLevel_All_Search API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionSearchRequest_RemoveVisibilityLevel_All_SearchAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_42";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of subscription search API\.")]
        public void WhenICallThePostMethodOfSubscriptionSearchAPI_()
        {
            NotificationHubPage.PostSubscriptionSearchRequests1(condition1, condition2, condition3, condition4, authorization);
        }

        [Given(@"I have subscription search request - Remove VisibilityLevel_Subscriber_Search API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionSearchRequest_RemoveVisibilityLevel_Subscriber_SearchAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_43";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscription search request - Remove VisibilityLevel_Owner_Search API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionSearchRequest_RemoveVisibilityLevel_Owner_SearchAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_44";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscription search request - Remove VisibilityLevel_Involved_Search API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionSearchRequest_RemoveVisibilityLevel_Involved_SearchAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_45";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [Given(@"I have subscription search request - Remove VisibilityLevel_All Owner Subscriber Involved_Search API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionSearchRequest_RemoveVisibilityLevel_AllOwnerSubscriberInvolved_SearchAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_46";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);            
        }

        [Given(@"I have subscription search request - Remove VisibilityLevel_All_UserEmailConfiguration ID_Lowercase_Search API endpoint /endpoint/")]
        public void GivenIHaveSubscriptionSearchRequest_RemoveVisibilityLevel_All_UserEmailConfigurationID_Lowercase_SearchAPIEndpointEndpoint()
        {
            string testcaseID = "TC3_47";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            expectedResponse = testdataRow[0]["Column14"].ToString();
            condition1 = testdataRow[0]["Column12"].ToString();
            condition2 = testdataRow[0]["Column13"].ToString();
            condition3 = testdataRow[0]["Column10"].ToString();
            condition4 = testdataRow[0]["Column11"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of subscription search API request")]
        public void WhenICallThePostMethodOfSubscriptionSearchAPIRequest()
        {
            NotificationHubPage.PostSubscriptionSearchRequests2(condition1, condition2, condition3, condition4, authorization);
        }

        [Given(@"I have validate request with API_Stock Order_Order Confirmation_Order Level endpoint /endpoint/")]
        public void GivenIHaveValidateRequestWithAPI_StockOrder_OrderConfirmation_OrderLevelEndpointEndpoint()
        {
            string testcaseID = "TC3_58";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();            
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of Stock Order_Order Confirmation_Order Level validate API request")]
        public void WhenICallThePostMethodOfStockOrder_OrderConfirmation_OrderLevelValidateAPIRequest()
        {
            NotificationHubPage.PostValidateRequests(@"\TestData\StockOrderOrderConfirmationOrderLevel.json", authorization);
        }        

        [Then(@"I get validate API response")]
        public void ThenIGetValidateAPIResponse()
        {
            NotificationHubPage.VerifyPostValidateResponse();
        }

        [Given(@"I have validate request with API_Stock Order_Order Confirmation_Order Level_No Lines endpoint /endpoint/")]
        public void GivenIHaveValidateRequestWithAPI_StockOrder_OrderConfirmation_OrderLevel_NoLinesEndpointEndpoint()
        {
            string testcaseID = "TC3_59";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of Stock Order_Order Confirmation_Order Level_No Lines validate API request")]
        public void WhenICallThePostMethodOfStockOrder_OrderConfirmation_OrderLevel_NoLinesValidateAPIRequest()
        {
            NotificationHubPage.PostValidateRequests(@"\TestData\StockOrderOrderConfirmationOrderLevelNoLines.json", authorization);
        }

        [Then(@"I get No Lines validate API response")]
        public void ThenIGetNoLinesValidateAPIResponse()
        {
            NotificationHubPage.VerifyPostValidateResponseNoLines();
        }

        [Given(@"I have validate request with API_Direct Order_Order Confirmation_Order Level endpoint /endpoint/")]
        public void GivenIHaveValidateRequestWithAPI_DirectOrder_OrderConfirmation_OrderLevelEndpointEndpoint()
        {
            string testcaseID = "TC3_60";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of Direct Order_Order Confirmation_Order Level validate API request")]
        public void WhenICallThePostMethodOfDirectOrder_OrderConfirmation_OrderLevelValidateAPIRequest()
        {
            NotificationHubPage.PostValidateRequests(@"\TestData\DirectOrderOrderConfirmationOrderLevel.json", authorization);
        }

        [Given(@"I have validate request with API_Stock Order_Order In-fulfillment_Order Level endpoint /endpoint/")]
        public void GivenIHaveValidateRequestWithAPI_StockOrder_OrderIn_Fulfillment_OrderLevelEndpointEndpoint()
        {
            string testcaseID = "TC3_61";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of Stock Order_Order In-fulfillment_Order Level validate API request")]
        public void WhenICallThePostMethodOfStockOrder_OrderIn_Fulfillment_OrderLevelValidateAPIRequest()
        {
            NotificationHubPage.PostValidateRequests(@"\TestData\StockOrderOrderInFulfillmentOrderLevel.json", authorization);
        }

        [Given(@"I have validate request with API_Stock Order_Order Shipped_Order Level endpoint /endpoint/")]
        public void GivenIHaveValidateRequestWithAPI_StockOrder_OrderShipped_OrderLevelEndpointEndpoint()
        {
            string testcaseID = "TC3_62";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of Stock Order_Order Shipped_Order Level validate API request")]
        public void WhenICallThePostMethodOfStockOrder_OrderShipped_OrderLevelValidateAPIRequest()
        {
            NotificationHubPage.PostValidateRequests(@"\TestData\StockOrderOrderShippedOrderLevel.json", authorization);
        }

        [Given(@"I have validate request with API_Direct Order_Order Shipped_Order Level endpoint /endpoint/")]
        public void GivenIHaveValidateRequestWithAPI_DirectOrder_OrderShipped_OrderLevelEndpointEndpoint()
        {
            string testcaseID = "TC3_63";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of Direct Order_Order Shipped_Order Level validate API request")]
        public void WhenICallThePostMethodOfDirectOrder_OrderShipped_OrderLevelValidateAPIRequest()
        {
            NotificationHubPage.PostValidateRequests(@"\TestData\DirectOrderOrderShippedOrderLevel.json", authorization);
        }

        [Given(@"I have validate request with API_Stock Order_Order Delivered_Order Level endpoint /endpoint/")]
        public void GivenIHaveValidateRequestWithAPI_StockOrder_OrderDelivered_OrderLevelEndpointEndpoint()
        {
            string testcaseID = "TC3_64";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of Stock Order_Order Delivered_Order Level validate API request")]
        public void WhenICallThePostMethodOfStockOrder_OrderDelivered_OrderLevelValidateAPIRequest()
        {
            NotificationHubPage.PostValidateRequests(@"\TestData\StockOrderOrderDeliveredOrderLevel.json", authorization);
        }

        [Given(@"I have validate request with API_Direct Order_Order Delivered_Order Level endpoint /endpoint/")]
        public void GivenIHaveValidateRequestWithAPI_DirectOrder_OrderDelivered_OrderLevelEndpointEndpoint()
        {
            string testcaseID = "TC3_65";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of Direct Order_Order Delivered_Order Level validate API request")]
        public void WhenICallThePostMethodOfDirectOrder_OrderDelivered_OrderLevelValidateAPIRequest()
        {
            NotificationHubPage.PostValidateRequests(@"\TestData\DirectOrderOrderDeliveredOrderLevel.json", authorization);
        }

        [Given(@"I have validate request with API_Stock Order_Product Unavailable_Order Level endpoint /endpoint/")]
        public void GivenIHaveValidateRequestWithAPI_StockOrder_ProductUnavailable_OrderLevelEndpointEndpoint()
        {
            string testcaseID = "TC3_66";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of Stock Order_Product Unavailable_Order Level validate API request")]
        public void WhenICallThePostMethodOfStockOrder_ProductUnavailable_OrderLevelValidateAPIRequest()
        {
            NotificationHubPage.PostValidateRequests(@"\TestData\StockOrderProductUnavailableOrderLevel.json", authorization);
        }

        [Given(@"I have validate request with API_Cash Order_Order Shipped_Order Level endpoint /endpoint/")]
        public void GivenIHaveValidateRequestWithAPI_CashOrder_OrderShipped_OrderLevelEndpointEndpoint()
        {
            string testcaseID = "TC3_67";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of Cash Order_Order Shipped_Order Level validate API request")]
        public void WhenICallThePostMethodOfCashOrder_OrderShipped_OrderLevelValidateAPIRequest()
        {
            NotificationHubPage.PostValidateRequests(@"\TestData\CashOrderOrderShippedOrderLevel.json", authorization);
        }

        [Given(@"I have validate request with API_Stock Order_Order Confirmation_Order Level_Event DateTime endpoint /endpoint/")]
        public void GivenIHaveValidateRequestWithAPI_StockOrder_OrderConfirmation_OrderLevel_EventDateTimeEndpointEndpoint()
        {
            string testcaseID = "TC3_71";
            testdataRow = Constants.NotificationHubTestData.Select("Column1 = '" + testcaseID + "'");
            string APIUrl = testdataRow[0]["Column3"].ToString();
            authorization = testdataRow[0]["Column8"].ToString();
            string Endpoint = testdataRow[0]["Column4"].ToString();
            NotificationHubPage.SetURL(APIUrl, Endpoint);
        }

        [When(@"I call the post method of Stock Order_Order Confirmation_Order Level_Event DateTime validate API request")]
        public void WhenICallThePostMethodOfStockOrder_OrderConfirmation_OrderLevel_EventDateTimeValidateAPIRequest()
        {
            NotificationHubPage.PostValidateEventDateRequests(@"\TestData\StockOrderOrderConfirmationOrderLevel.json", authorization);
        }

        [Then(@"I get validate Stock Order_Order Confirmation_Order Level_Event DateTime API response")]
        public void ThenIGetValidateStockOrder_OrderConfirmation_OrderLevel_EventDateTimeAPIResponse()
        {
            NotificationHubPage.VerifyPostValidateEventDateResponse();
        }


    }
}
