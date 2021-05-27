Feature: NotificationHub

	@NotificationHub
Scenario: TC03-01_Regression_Notification Hub APIs_/subscribableEvents/get API_Remove Source System
	Given I have subscribable events request - Remove Source System endpoint /endpoint/
	When I call the post method of subscribable events API
	Then I get subscribable events API response with error

	@NotificationHub
Scenario: TC03-02_Regression_Notification Hub APIs_/subscribableEvents/get API_Remove UserEmailConfigurationID
	Given I have subscribable events request - Remove UserEmailConfigurationID endpoint /endpoint/
	When I call the post method of subscribable events API
	Then I get subscribable events API response without error

	@NotificationHub
Scenario: TC03-03_Regression_Notification Hub APIs_/subscribableEvents/get API_SubscriberType_Reseller
	Given I have subscribable events request - other than reseller endpoint /endpoint/
	When I call the post method of subscribable events API
	Then I get subscribable events API response

	@NotificationHub
Scenario: TC03-04_Regression_Notification Hub APIs_/emailConfiguration/get API_SubscriberType_Reseller
	Given I have emailConfiguration request SubscriberType_Reseller endpoint /endpoint/
	When I call the post method of emailConfiguration API
	Then I get emailConfiguration API response

	@NotificationHub
Scenario: TC03-05_Regression_Notification Hub APIs_/emailConfiguration/get API_SubscriberType_Incorrect
	Given I have emailConfiguration request SubscriberType_Incorrect endpoint /endpoint/
	When I call the post method of emailConfiguration API
	Then I get emailConfiguration API response

	@NotificationHub
Scenario: TC03-06_Regression_Notification Hub APIs_/Subscribe API_Remove Both Source System & UserEmailConfigurationID
	Given I have subscribe request - Remove Both Source System & UserEmailConfigurationID endpoint /endpoint/
	When I call the post method of subscribe API
	Then I get subscribe API response with error

	@NotificationHub
Scenario: TC03-07_Regression_Notification Hub APIs_/Subscribe API_Remove Source System
	Given I have subscribe request - Remove Source System endpoint /endpoint/
	When I call the post method of subscribe API
	Then I get subscribe API response with error

	@NotificationHub
Scenario: TC03-08_Regression_Notification Hub APIs_/Subscribe API_Remove UserEmailConfigurationID
	Given I have subscribe request - Remove UserEmailConfigurationID endpoint /endpoint/
	When I call the post method of subscribe API
	Then I get subscribe API response with error

	@NotificationHub
Scenario: TC03-09_Regression_Notification Hub APIs_/Subscribe API_Account Level_Reseller_Order Confirmation_Add Subscribe
	Given I have subscribe request - Account Level_Reseller_Order Confirmation_Add Subscribe endpoint /endpoint/
	When I call the post method of subscribe API Add
	Then I get subscribe API response
	Given I have the unsubscribe request endpoint /endpoint/
	When I call the post method of unsubscribe API.
	Then I get unsubscribe API response

	@NotificationHub
Scenario: TC03-10_Regression_Notification Hub APIs_/Subscribe API_Order Level_Reseller_Order In Fulfillment_Add Subscribe
	Given I have subscribe request - Order Level_Reseller_Order In Fulfillment_Add Subscribe endpoint /endpoint/
	When I call the post method of subscribe API Add
	Then I get subscribe API response
	Given I have the unsubscribe request endpoint /endpoint/
	When I call the post method of unsubscribe API.
	Then I get unsubscribe API response

		@NotificationHub
Scenario: TC03-11_Regression_Notification Hub APIs_/Subscribe API_Order Level_Reseller_Order Shipped_With Subscription ID_Add Subscribe
	Given I have subscribe request - Order Level_Reseller_Order Shipped_With Subscription ID_Add Subscribe endpoint /endpoint/
	When I call the post method of subscribe API Add
	Then I get subscribe API response
	Given I have the unsubscribe request endpoint /endpoint/
	When I call the post method of unsubscribe API.
	Then I get unsubscribe API response

	@NotificationHub
Scenario: TC03-12_Regression_Notification Hub APIs_/Subscribe API_Order Level_Reseller_Order Delivered_With Subscription ID_Add Subscribe
	Given I have subscribe request - Order Level_Reseller_Order Delivered_With Subscription ID_Add Subscribe endpoint /endpoint/
	When I call the post method of subscribe API Add
	Then I get subscribe API response
	Given I have the unsubscribe request endpoint /endpoint/
	When I call the post method of unsubscribe API.
	Then I get unsubscribe API response

	@NotificationHub
Scenario: TC03-13_Regression_Notification Hub APIs_/Subscribe API_Order Level_Reseller_Order Changed_With Subscription ID_Add Subscribe
	Given I have subscribe request - Order Level_Reseller_Order Changed_With Subscription ID_Add Subscribe endpoint /endpoint/
	When I call the post method of subscribe API Add
	Then I get subscribe API response
	Given I have the unsubscribe request endpoint /endpoint/
	When I call the post method of unsubscribe API.
	Then I get unsubscribe API response

		@NotificationHub
Scenario: TC03-14_Regression_Notification Hub APIs_/Subscribe API_Order Level_Reseller_Multiple Events_Multiple Emails_Add Subscribe
	Given I have subscribe request - Order Level_Reseller_Multiple Events_Multiple Emails_Add Subscribe endpoint /endpoint/
	When I call the post method of subscribe API Add multiple
	Then I get subscribe API response
	Given I have subscribe request - Order Level_Reseller_Order Changed_Remove Subscribe endpoint /endpoint/
	When I call the post method of subscribe API Remove
	Then I get subscribe API response remove
	Given I have the unsubscribe request endpoint /endpoint/
	When I call the post method of unsubscribe API.
	Then I get unsubscribe API response

	@NotificationHub
Scenario: TC03-16_Regression_Notification Hub APIs_/Subscribe API_Order Level_Reseller_Add Subscribe & Remove Subscribe_Different EmailConfigurationID
	Given I have subscribe request - Order Level_Reseller_Add Subscribe & Remove Subscribe_Different EmailConfigurationID endpoint /endpoint/
	When I call the post method of subscribe API Remove
	Then I get subscribe API response remove
	Given I have the unsubscribe request endpoint /endpoint/
	When I call the post method of unsubscribe API.
	Then I get unsubscribe API response

	@NotificationHub
Scenario: TC03-20_Regression_Notification Hub APIs_/Subscribe API_Order Level_Reseller_Invalid Action
	Given I have subscribe request - Invalid Action endpoint /endpoint/
	When I call the post method of subscribe API
	Then I get subscribe API response with error

	@NotificationHub
Scenario: TC03-21_Regression_Notification Hub APIs_/SubscribeAll API_Account Level_Reseller_Single Email Configuration ID
	Given I have subscription all request - Account Level_Reseller_Single Email Configuration ID endpoint /endpoint/
	When I call the post method of subscribe all API
	Then I get subscribe all API response

	@NotificationHub
Scenario: TC03-22_Regression_Notification Hub APIs_/SubscribeAll API_Order Level_Reseller_Multiple Email Configuration IDs
	Given I have subscription all request - Order Level_Reseller_Multiple Email Configuration IDs endpoint /endpoint/
	When I call the post method of subscribe all API
	Then I get subscribe all API response

	@NotificationHub
Scenario: TC03-23_Regression_Notification Hub APIs_/SubscribeAll API_Account Level_Reseller_Multiple Email Configuration IDs
	Given I have subscription all request - Account Level_Reseller_Multiple Email Configuration IDs endpoint /endpoint/
	When I call the post method of subscribe all API
	Then I get subscribe all API response

	@NotificationHub
Scenario: TC03-26_Regression_Notification Hub APIs_Remove Source System_View API
	Given I have subscription view request - Remove Source System_View API endpoint /endpoint/
	When I call the post method of subscription view API
	Then I get subscription API response with error

	@NotificationHub
Scenario: TC03-27_Regression_Notification Hub APIs_Remove UserEmailConfigurationID_View API
	Given I have subscription view request - Remove UserEmailConfigurationID_View API endpoint /endpoint/
	When I call the post method of subscription view API
	Then I get subscription API response without error

	@NotificationHub
Scenario: TC03-28_Regression_Notification Hub APIs_Remove VisibilityLevel(Default)_View API
	Given I have subscription view request - Remove VisibilityLevel(Default)_View API endpoint /endpoint/
	When I call the post method of subscription view API
	Then I get subscription API response without error

	@NotificationHub
Scenario: TC03-29_Regression_Notification Hub APIs_Remove Both Source System & UserEmailConfigurationID_View API
	Given I have subscription view request - Remove Both Source System & UserEmailConfigurationID_View API endpoint /endpoint/
	When I call the post method of subscription view API
	Then I get subscription API response with error

	@NotificationHub
Scenario: TC03-30_Regression_Notification Hub APIs_VisibilityLevel_All_View API
	Given I have subscription view request - VisibilityLevel_All_View API endpoint /endpoint/
	When I call the post method of subscription view API
	Then I get subscription view API response

		@NotificationHub
Scenario: TC03-31_Regression_Notification Hub APIs_VisibilityLevel_Subscriber_View API
	Given I have subscription view request - VisibilityLevel_Subscriber_View API endpoint /endpoint/
	When I call the post method of subscription view API
	Then I get subscription view API response

	@NotificationHub
Scenario: TC03-34_Regression_Notification Hub APIs_VisibilityLevel_Both All & Subscribed_View API
	Given I have subscribe request endpoint /endpoint/
	When I call the post method of subscribe API.
	Then I get subscribe API response
	Given I have subscription view request - VisibilityLevel_Both All & Subscribed_View API endpoint /endpoint/
	When I call the post method of subscription view API.
	Then I get subscription API response with error
	Given I have the unsubscribe request endpoint /endpoint/
	When I call the post method of unsubscribe API.
	Then I get unsubscribe API response

	@NotificationHub
Scenario: TC03-35_Regression_Notification Hub APIs_VisibilityLevel_All_UserEmailConfiguration ID&Subscription ID_Lowercase_View API
	Given I have subscribe request one endpoint /endpoint/
	When I call the post method of subscribe API.
	Then I get subscribe API response
	Given I have subscription view request - VisibilityLevel_All_UserEmailConfiguration ID&Subscription ID_Lowercase_View API endpoint /endpoint/
	When I call the post method of subscription view API request
	Then I get subscription API response without error.
	Given I have the unsubscribe request endpoint /endpoint/
	When I call the post method of unsubscribe API.
	Then I get unsubscribe API response

	@NotificationHub
Scenario: TC03-36_Regression_Notification Hub APIs_VisibilityLevel_Subscriber_UserEmailConfiguration ID&Subscription ID_Lowercase_View API
	Given I have subscribe request two endpoint /endpoint/
	When I call the post method of subscribe API.
	Then I get subscribe API response
	Given I have subscription view request - VisibilityLevel_Subscriber_UserEmailConfiguration ID&Subscription ID_Lowercase_View API endpoint /endpoint/
	When I call the post method of subscription view API request
	Then I get subscription API response without error.
	Given I have the unsubscribe request endpoint /endpoint/
	When I call the post method of unsubscribe API.
	Then I get unsubscribe API response

	@NotificationHub
Scenario: TC03-37_Regression_Notification Hub APIs_Invalid / No relation between SubscriptionID and UserEmailConfigurationID_View API
	Given I have subscribe request three endpoint /endpoint/
	When I call the post method of subscribe API.
	Then I get subscribe API response
	Given I have subscription view request - Invalid / No relation between SubscriptionID and UserEmailConfigurationID_View API endpoint /endpoint/
	When I call the post method of subscription view API.
	Then I get subscription API response with error
	Given I have the unsubscribe request endpoint /endpoint/
	When I call the post method of unsubscribe API.
	Then I get unsubscribe API response

	@NotificationHub
Scenario: TC03-38_Regression_Notification Hub APIs_Remove Source System_Search API
	Given I have subscription search request - Remove Source System_Search API endpoint /endpoint/
	When I call the post method of subscription search API
	Then I get subscription search API response with error

	@NotificationHub
Scenario: TC03-39_Regression_Notification Hub APIs_Remove UserEmailConfigurationID_Search API
	Given I have subscription search request - Remove UserEmailConfigurationID_Search API endpoint /endpoint/
	When I call the post method of subscription search API
	Then I get subscription API response with error

	@NotificationHub
Scenario: TC03-40_Regression_Notification Hub APIs_Remove VisibilityLevel(Default)_Search API
	Given I have subscription search request - Remove VisibilityLevel(Default)_Search API endpoint /endpoint/
	When I call the post method of subscription search API
	Then I get subscription search API response without error

	@NotificationHub
Scenario: TC03-41_Regression_Notification Hub APIs_Remove Both Source System & UserEmailConfigurationID_Search API
	Given I have subscription search request - Remove Both Source System & UserEmailConfigurationID_Search API endpoint /endpoint/
	When I call the post method of subscription search API
	Then I get subscription search API response with error

	@NotificationHub
Scenario: TC03-42_Regression_Notification Hub APIs_VisibilityLevel_All_Search API
	Given I have subscription search request - Remove VisibilityLevel_All_Search API endpoint /endpoint/
	When I call the post method of subscription search API.
	Then I get subscription search API response without error

	@NotificationHub
Scenario: TC03-43_Regression_Notification Hub APIs_VisibilityLevel_Subscriber_Search API
	Given I have subscription search request - Remove VisibilityLevel_Subscriber_Search API endpoint /endpoint/
	When I call the post method of subscription search API.
	Then I get subscription search API response without error

	@NotificationHub
Scenario: TC03-44_Regression_Notification Hub APIs_VisibilityLevel_Owner_Search API
	Given I have subscription search request - Remove VisibilityLevel_Owner_Search API endpoint /endpoint/
	When I call the post method of subscription search API.
	Then I get subscription search API response without error

	@NotificationHub
Scenario: TC03-45_Regression_Notification Hub APIs_VisibilityLevel_Involved_Search API
	Given I have subscription search request - Remove VisibilityLevel_Involved_Search API endpoint /endpoint/
	When I call the post method of subscription search API.
	Then I get subscription search API response without error

	@NotificationHub
Scenario: TC03-46_Regression_Notification Hub APIs_VisibilityLevel_All, Owner, Subscriber & Involved_Search API
	Given I have subscription search request - Remove VisibilityLevel_All Owner Subscriber Involved_Search API endpoint /endpoint/
	When I call the post method of subscription search API.
	Then I get subscription search API response with error

	@NotificationHub
Scenario: TC03-47_Regression_Notification Hub APIs_VisibilityLevel_All_UserEmailConfiguration ID_Lowercase_Search API
	Given I have subscription search request - Remove VisibilityLevel_All_UserEmailConfiguration ID_Lowercase_Search API endpoint /endpoint/
	When I call the post method of subscription search API request
	Then I get subscription search API response without error

	@NotificationHub
Scenario: TC03-48_Regression_Notification Hub APIs_VisibilityLevel_Except All_Invalid / Not related to the Order details UserEmailConfigurationID_Search API
	Given I have subscription search request - VisibilityLevel_Except All_Invalid_Search API endpoint /endpoint/
	When I call the post method of subscription search API
	Then I get subscription search API response with error

	@NotificationHub
Scenario: TC03-49_Regression_Notification Hub APIs_Remove Source System_createOrUpdate API
	Given I have emailConfiguration request Remove Source System_createOrUpdate endpoint /endpoint/
	When I call the post method of emailCreateUpdate API
	Then I get emailConfiguration API response

	@NotificationHub
Scenario: TC03-50_Regression_Notification Hub APIs_Remove UserEmailConfigurationID_createOrUpdate API
	Given I have emailConfiguration request Remove UserEmailConfigurationID_createOrUpdate endpoint /endpoint/
	When I call the post method of emailCreateUpdate API
	Then I get emailConfiguration API response

	@NotificationHub
Scenario: TC03-51_Regression_Notification Hub APIs_Remove Both Source System & UserEmailConfigurationID_createOrUpdate API
	Given I have emailConfiguration request Remove Both Source System & UserEmailConfigurationID_createOrUpdate endpoint /endpoint/	
	When I call the post method of emailCreateUpdate API
	Then I get emailConfiguration API response

	@NotificationHub
Scenario: TC03-52_Regression_Notification Hub APIs_emailConfiguration/createOrUpdate_Create
	Given I have emailConfiguration request createOrUpdate_Create endpoint /endpoint/
	When I call the post method of email Create API
	Then I get emailConfiguration API response

	@NotificationHub
Scenario: TC03-53_Regression_Notification Hub APIs_emailConfiguration/createOrUpdate_Update
	Given I have emailConfiguration request createOrUpdate_Update endpoint /endpoint/	
	When I call the post method of email Create API
	Then I get emailConfiguration API response
	Given I have emailConfiguration request createOrUpdate_Update one endpoint /endpoint/
	When I call the post method of email Update API
	Then I get emailConfiguration update API response

	@NotificationHub
Scenario: TC03-54_Regression_Notification Hub APIs_emailConfiguration/createOrUpdate_With and Without Application Identifier
	Given I have emailConfiguration request createOrUpdate_With Application Identifier endpoint /endpoint/	
	When I call the post method of email Create API request
	Then I get emailConfiguration API response
	Given I have emailConfiguration request createOrUpdate_Update one endpoint /endpoint/
	When I call the post method of email Update API
	Then I get emailConfiguration update API response
	
	@NotificationHub
Scenario: TC03-56_Regression_Notification Hub APIs_emailConfiguration/createOrUpdate_EmailConfigurationID_ToEmailAddress is already available in NotificationHub, but it doesn’t have any subscriptions attached to it
	Given I have emailConfiguration request createOrUpdate_Create endpoint /endpoint/
	When I call the post method of email Create API
	Then I get emailConfiguration API response
	Given I have emailConfiguration request createOrUpdate_Create already available endpoint /endpoint/
	When I call the post method of email already exists API
	Then I get emailConfiguration API response

	
	@NotificationHub
Scenario: TC03-57_Regression_Notification Hub APIs_emailConfiguration/createOrUpdate_EmailConfigurationID_ToEmailAddress is already available in NotificationHub, and it has few subscriptions attached to it
	Given I have emailConfiguration request createOrUpdate_Create EmailAddress is already available in NotificationHub, and it has few subscriptions attached to it endpoint /endpoint/
	When I call the post method of email Create already available with subscription API
	Then I get emailConfiguration API response

	@NotificationHub
Scenario: TC03-58_Regression_Notification Hub APIs_Validate API_Stock Order_Order Confirmation_Order Level
	Given I have validate request with API_Stock Order_Order Confirmation_Order Level endpoint /endpoint/	
	When I call the post method of Stock Order_Order Confirmation_Order Level validate API request
	Then I get validate API response
	
	@NotificationHub
Scenario: TC03-59_Regression_Notification Hub APIs_Validate API_Stock Order_Order Confirmation_Order Level_No Lines
    Given I have validate request with API_Stock Order_Order Confirmation_Order Level_No Lines endpoint /endpoint/	
	When I call the post method of Stock Order_Order Confirmation_Order Level_No Lines validate API request
	Then I get No Lines validate API response

	@NotificationHub
Scenario: TC03-60_Regression_Notification Hub APIs_Validate API_Direct Order_Order Confirmation_Order Level
	Given I have validate request with API_Direct Order_Order Confirmation_Order Level endpoint /endpoint/	
	When I call the post method of Direct Order_Order Confirmation_Order Level validate API request
	Then I get validate API response

	@NotificationHub
Scenario: TC03-61_Regression_Notification Hub APIs_Validate API_Stock Order_Order In-fulfillment_Order Level
	Given I have validate request with API_Stock Order_Order In-fulfillment_Order Level endpoint /endpoint/	
	When I call the post method of Stock Order_Order In-fulfillment_Order Level validate API request
	Then I get validate API response

	@NotificationHub
Scenario: TC03-62_Regression_Notification Hub APIs_Validate API_Stock Order_Order Shipped_Order Level
	Given I have validate request with API_Stock Order_Order Shipped_Order Level endpoint /endpoint/	
	When I call the post method of Stock Order_Order Shipped_Order Level validate API request
	Then I get validate API response

	@NotificationHub
Scenario: TC03-63_Regression_Notification Hub APIs_Validate API_Direct Order_Order Shipped_Order Level
	Given I have validate request with API_Direct Order_Order Shipped_Order Level endpoint /endpoint/	
	When I call the post method of Direct Order_Order Shipped_Order Level validate API request
	Then I get validate API response


	@NotificationHub
Scenario: TC03-64_Regression_Notification Hub APIs_Validate API_Stock Order_Order Delivered_Order Level
	Given I have validate request with API_Stock Order_Order Delivered_Order Level endpoint /endpoint/	
	When I call the post method of Stock Order_Order Delivered_Order Level validate API request
	Then I get validate API response

	@NotificationHub
Scenario: TC03-65_Regression_Notification Hub APIs_Validate API_Direct Order(IBM Only)_Order Delivered_Order Level
	Given I have validate request with API_Direct Order_Order Delivered_Order Level endpoint /endpoint/	
	When I call the post method of Direct Order_Order Delivered_Order Level validate API request
	Then I get validate API response

	@NotificationHub
Scenario: TC03-66_Regression_Notification Hub APIs_Validate API_Stock Order_Product Unavailable_Order Level
	Given I have validate request with API_Stock Order_Product Unavailable_Order Level endpoint /endpoint/	
	When I call the post method of Stock Order_Product Unavailable_Order Level validate API request
	Then I get validate API response

	@NotificationHub
Scenario: TC03-67_Regression_Notification Hub APIs_Validate API_Cash Order_Order Shipped_Order Level
	Given I have validate request with API_Cash Order_Order Shipped_Order Level endpoint /endpoint/	
	When I call the post method of Cash Order_Order Shipped_Order Level validate API request
	Then I get validate API response

	@NotificationHub
Scenario: TC03-71_Regression_Notification Hub APIs_Validate API_Stock Order_Order Confirmation_Order Level_Event DateTime_-3Days
	Given I have validate request with API_Stock Order_Order Confirmation_Order Level_Event DateTime endpoint /endpoint/	
	When I call the post method of Stock Order_Order Confirmation_Order Level_Event DateTime validate API request
	Then I get validate Stock Order_Order Confirmation_Order Level_Event DateTime API response

	@NotificationHub
Scenario: TC03-73_Regression_Notification Hub APIs_Whitelisted Vendor API_Order Shipped
	Given I have Whitelisted Vendor API request - Order Shipped endpoint /endpoint/
	When I call the post method of Whitelisted Vendor API
	Then I get Whitelisted Vendor API response for Order Shipped

	@NotificationHub
Scenario: TC03-74_Regression_Notification Hub APIs_Whitelisted Vendor API_In Fulfillment
	Given I have Whitelisted Vendor API request - In Fulfillment endpoint /endpoint/
	When I call the post method of Whitelisted Vendor API
	Then I get Whitelisted Vendor API response for In Fulfillment

	@NotificationHub
Scenario: TC03-75_Regression_Notification Hub APIs_Whitelisted Vendor API_Order Invoice
	Given I have Whitelisted Vendor API request - Order Invoice endpoint /endpoint/
	When I call the post method of Whitelisted Vendor API
	Then I get Whitelisted Vendor API response for Order Invoice

	@NotificationHub
Scenario: TC03-76_Regression_Notification Hub APIs_Whitelisted Vendor API_Order Delivered
	Given I have Whitelisted Vendor API request - Order Delivered endpoint /endpoint/
	When I call the post method of Whitelisted Vendor API
	Then I get Whitelisted Vendor API response for Order Delivered

	@NotificationHub
Scenario: TC03-77_Regression_Notification Hub APIs_Whitelisted Vendor API_Invalid Notification Type
	Given I have Whitelisted Vendor API request - Invalid Notification Type endpoint /endpoint/
	When I call the post method of Whitelisted Vendor API
	Then I get Whitelisted Vendor API response for Invalid Notification Type
