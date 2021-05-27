Feature: OSTReport

	@OSTReport
Scenario: TC2-02_Regression_Self-Service OST Report_Report Configure API (POST)_Daily_Stock_Excel_UpdateReportConfiguration_SentToSubscribers-True_E2E
    Given I have post report Daily_Stock_Excel_UpdateReportConfiguration_SentToSubscribers-True_E2E /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report request API TRUE
	Then I get report request daily API response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-03_Regression_Self-Service OST Report_Report Configure API (POST)_Daily_Stock_CSV_Update Email Only-Remove_SentToSubscribers-False_E2E
	Given I have post report Daily_Stock_CSV_Update Email Only-Remove_SentToSubscribers-False_E2E /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report request API FALSE
	Then I get report request daily API response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-06_Regression_Self-Service OST Report API_List Reports API (GET)
	Given I have get report list request endpoint /endpoint/
	When I call the get method of report list API
	Then I get report list API response

	@OSTReport
Scenario: TC2-07_Regression_Self-Service OST Report API_List Reports API (GET)_IsEditable-FALSE
	Given I have put report list IsEditable-FALSE request endpoint /endpoint/
	When I call the put method of report list API
	Then I get report API response with error

	@OSTReport
Scenario: TC2-09_Regression_Self-Service OST Report API_List Reports API (GET)_IsEditable-TRUE
	Given I have post report Daily_Stock_Excel endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have put report list IsEditable-TRUE request endpoint /endpoint/
	When I call the put method of report list API
	Then I get report API response without error
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-12_Regression_Self-Service OST Report API_Get Report API (GET)_Invalid Report ID
	Given I have get report invalid report ID endpoint /endpoint/
	When I call the get method of the reports API
	Then I get invalid report id API response

	@OSTReport
Scenario: TC2-14_Regression_Self-Service OST Report API_Delete Report API (DEL)_Invalid Report ID
	Given I have delete invalid report ID endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get invalid report (DELETE) API response

	@OSTReport
Scenario: TC2-17_Regression_Self-Service OST Report API_Report Configure API (POST)_Single Email Address
	Given I have post report Daily_Stock_Excel Single Email Address endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have the get reports endpoint /endpoint/
	When I call the get method of the reports API
	Then I see single email id in the response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-18_Regression_Self-Service OST Report API_Report Configure API (POST)_Multiple Email Addresses
	Given I have post report Daily_Stock_Excel Multiple Email Address endpoint /endpoint/
	When I call the post method of the report API Multiple Emai Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have the get reports endpoint /endpoint/
	When I call the get method of the reports API
	Then I see multiple email ids in the response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-19_Regression_Self-Service OST Report API_Report Configure API (POST)_Invalid Email Address
	Given I have post report Invalid Email Address endpoint /endpoint/
	When I call the post method of the report API
	Then I get report API response

	@OSTReport
Scenario: TC2-20_Regression_Self-Service OST Report API_Report Configure API (POST)_Remove Email Address field
	Given I have post report Remove Email Address field endpoint /endpoint/
	When I call the post method of the report API
	Then I get report API response with no email field
	Given I have the get reports endpoint /endpoint/
	When I call the get method of the reports API
	Then I see no email field in the response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-21_Regression_Self-Service OST Report API_Report Configure API (POST)_Remove Frequency field
	Given I have post report Remove Frequency field endpoint /endpoint/
	When I call the post method of the report API
	Then I get report API response

	@OSTReport
Scenario: TC2-22_Regression_Self-Service OST Report API_Report Configure API (POST)_Frequency other than daily or on_demand
	Given I have post report Frequency other than daily or on_demand endpoint /endpoint/
	When I call the post method of the report API
	Then I get report API response

	@OSTReport
Scenario: TC2-23_Regression_Self-Service OST Report API_Report Configure API (POST)_FrequencyDaily_Remove scheduledTime
	Given I have post report Remove scheduledTime endpoint /endpoint/
	When I call the post method of the report API
	Then I get report API response

	@OSTReport
Scenario: TC2-24_Regression_Self-Service OST Report API_Report Configure API (POST)_FrequencyOn-Demand_Add scheduledTime field
	Given I have post report FrequencyOn-Demand_Add scheduledTime field endpoint /endpoint/
	When I call the post method of the report API
	Then I get report API response

	@OSTReport
Scenario: TC2-25_Regression_Self-Service OST Report API_Report Configure API (POST)_Add scheduledTime value other than 00:00 to 23:00
	Given I have post report Add scheduledTime value other than 00:00 to 23:00 endpoint /endpoint/
	When I call the post method of the report API
	Then I get report API response

	@OSTReport
Scenario: TC2-26_Regression_Self-Service OST Report API_Report Configure API (POST)_Add scheduledTime value with Mins
	Given I have post report Add scheduledTime value with Mins endpoint /endpoint/
	When I call the post method of the report API
	Then I get report API response

	@OSTReport
Scenario: TC2-27_Regression_Self-Service OST Report API_Report Configure API (POST)_Remove Report Format
	Given I have post report Remove Report Format endpoint /endpoint/
	When I call the post method of the report API
	Then I get report API response

	@OSTReport
Scenario: TC2-28_Regression_Self-Service OST Report API_Report Configure API (POST)_Duplicate ID number on Fields
	Given I have post report Duplicate ID number on Fields endpoint /endpoint/
	When I call the post method of the report API
	Then I get report API response

	@OSTReport
Scenario: TC2-29_Regression_Self-Service OST Report API_Report Configure API (POST)_Configure Columns order
	Given I have post report Daily_Stock_Excel_Configure Columns order endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have put report list request endpoint /endpoint/
	When I call the put method of report list API
	Then I get report API response with column changes
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-30_Regression_Self-Service OST Report API_Report Configure API (POST)_Customized Column Names
	Given I have post report Daily_Stock_Excel_Customized Columns Names endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have put report list request endpoint /endpoint/
	When I call the put method of report list API
	Then I get report API response with column changes
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-31_Regression_Self-Service OST Report API_Report Configure API (POST)_1_S_50-848432_On_Demand
	Given I have post report Add 1_S_50-848432_On_Demand endpoint /endpoint/
	When I call the post method of the report API
	Then I get report API response

	@OSTReport
Scenario: TC2-32_Regression_Self-Service OST Report API_Report Configure API (POST)_0_D_14-291091_On_Demand
	Given I have post report On_Demand_Stock_Excel_0_D_14-291091_On_Demand endpoint /endpoint/
	When I call the post method of the report API On_Demand - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report request API.
	Then I get report request on demand API response with email
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
	Scenario: TC2-33_Regression_Self-Service OST Report API_Report Configure API (POST)_-1_S_70-811722_On_Demand
	Given I have post report On_Demand_Stock_Excel_-1_S_70-811722_On_Demand endpoint /endpoint/
	When I call the post method of the report API On_Demand - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report request API.
	Then I get report request on demand API response with email
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response
	
	@OSTReport
Scenario: TC2-34_Regression_Self-Service OST Report API_Report Configure API (POST)_-5_S_60-559472_On_Demand
	Given I have post report On_Demand_Stock_Excel_-5_S_60-559472_On_Demand endpoint. /endpoint/
	When I call the post method of the report API On_Demand - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report request API.
	Then I get report request on demand API response with email
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-35_Regression_Self-Service OST Report API_Report Configure API (POST)_-9_D_40-033473_Daily
	Given I have post report On_Demand_Stock_Excel_-9_D_40-033473_Daily endpoint. /endpoint/
	When I call the post method of the report API ReportType Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report request API.
	Then I get report request daily API response with email
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-36_Regression_Self-Service OST Report API_Report Configure API (POST)_-10_S_50-448473_On_Demand
	Given I have post report On_Demand_Stock_Excel_-10_S_50-448473_On_Demand endpoint. /endpoint/
	When I call the post method of the report API On_Demand - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report request API.
	Then I get report request on demand API response with email
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-37_Regression_Self-Service OST Report API_Report Configure API (POST)_-11_S_60-750590_Daily
	Given I have post report On_Demand_Stock_Excel_-11_S_60-750590_Daily endpoint. /endpoint/
	When I call the post method of the report API ReportType Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report request API.
	Then I get report request daily API response with email
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-38_Regression_Self-Service OST Report API_Report Configure API (POST)_-30_D_60-341520_On_Demand
	Given I have post report On_Demand_Stock_Excel_-30_D_60-341520_On_Demand endpoint. /endpoint/
	When I call the post method of the report API On_Demand - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report request API.
	Then I get report request on demand API response with email
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-39_Regression_Self-Service OST Report API_Report Configure API (POST)_-29_S_72-217944_Daily
	Given I have post report On_Demand_Stock_Excel_-29_S_72-217944_On_Daily endpoint. /endpoint/
	When I call the post method of the report API ReportType Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report request API.
	Then I get report request daily API response with email
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-40_Regression_Self-Service OST Report API_Report Configure API (POST)_-30_D_60-266956_On_Demand
	Given I have post report On_Demand_Stock_Excel_-30_D_60-266956_On_Demand endpoint. /endpoint/
	When I call the post method of the report API On_Demand - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report request API.
	Then I get report request on demand API response with email
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-41_Regression_Self-Service OST Report API_Report Configure API (POST)_-31_S_10-952850_On_Demand
	Given I have post report On_Demand_Stock_Excel_-31_S_10-952850_On_Demand endpoint. /endpoint/
	When I call the post method of the report API.
	Then I get report API response

	@OSTReport
Scenario: TC2-43_Regression_Self-Service OST Report API_Generate Reports API (POST)_Remove SendToSubscribers
	Given I have post report Daily_Stock_Excel_Remove SendToSubscribers endpoint /endpoint/	
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report remove request API
	Then I get report request daily API response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-44_Regression_Self-Service OST Report API_Generate Reports API (POST)_Remove Email Addresses field and SendToSubscribers_TRUE
	Given I have post report Daily_Stock_Excel_Remove Email Addresses field and SendToSubscribers_TRUE endpoint /endpoint/	
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report remove request API
	Then I get report request daily API response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-45_Regression_Self-Service OST Report API_Generate Reports API (POST)_Remove Email Addresses field and SendToSubscribers_FALSE
	Given I have post report Daily_Stock_Excel_Remove Email Addresses field and SendToSubscribers_FALSE endpoint /endpoint/	
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report remove request API
	Then I get report request daily API remove response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-46_Regression_Self-Service OST Report API_Generate Reports API (POST)_SendToSubscribers_TRUE
	Given I have post report Daily_Stock_Excel_SendToSubscribers_TRUE endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report SendToSubscribers_TRUE request API
	Then I get report request daily API response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-47_Regression_Self-Service OST Report API_Generate Reports API (POST)_SendToSubscribers_FALSE
	Given I have post report Daily_Stock_Excel_SendToSubscribers_FALSE endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have post report request endpoint /endpoint/
	When I call the post method of the report SendToSubscribers_FALSE request API
	Then I get report request daily API response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-48_Regression_Self-Service OST Report API_Update Report Configuration API (PUT)_Update Delivery Mechanism & Schedule
	Given I have post report Daily_Stock_Excel_Update Delivery Mechanism Schedule endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have put report list request endpoint /endpoint/
	When I call the put method of report list API
	Then I get report API response with changes
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-49_Regression_Self-Service OST Report API_Update Report Configuration API (PUT)_Update Fields
	Given I have post report Daily_Stock_Excel_Update Fields endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have put report list request endpoint /endpoint/
	When I call the put method of report list API
	Then I get report API response with changes
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-50_Regression_Self-Service OST Report API_Update Report Configuration API (PUT)_Update filters
	Given I have post report Daily_Stock_Excel_Update filters endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have put report list request endpoint /endpoint/
	When I call the put method of report list API
	Then I get report API response with changes
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-51_Regression_Self-Service OST Report API_Update Email Only (PATCH)_Invalid Path
	Given I have post report Daily_Stock_Excel_Invalid Path endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have patch report endpoint /endpoint/
	When I call the patch method of the reports API with invalid path
	Then I get report (PATCH) API bad response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-52_Regression_Self-Service OST Report API_Update Email Only (PATCH)_Add Single Email
	Given I have post report Daily_Stock_Excel_Add Single Email endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have patch report endpoint /endpoint/
	When I call the patch method of the reports API with Single Email
	Then I get report (PATCH) API valid response
	Given I have the get reports endpoint /endpoint/
	When I call the get method of the reports API
	Then I see valid email ids in the response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-53_Regression_Self-Service OST Report API_Update Email Only (PATCH)_Add multiple Email IDs
	Given I have post report Daily_Stock_Excel_Add multiple Email endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have patch report endpoint /endpoint/
	When I call the patch method of the reports API with multiple Email
	Then I get report (PATCH) API valid response
	Given I have the get reports endpoint /endpoint/
	When I call the get method of the reports API
	Then I see valid email ids in the response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-54_Regression_Self-Service OST Report API_Update Email Only (PATCH)_Add Same Email IDs
	Given I have post report Daily_Stock_Excel_Add same Email endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have patch report endpoint /endpoint/
	When I call the patch method of the reports API with same Email
	Then I get report (PATCH) API valid response
	Given I have the get reports endpoint /endpoint/
	When I call the get method of the reports API
	Then I see valid email ids in the response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-55_Regression_Self-Service OST Report API_Update Email Only (PATCH)_Add Already Subscribed Email
	Given I have post report Daily_Stock_Excel_Add Already Subscribed Email endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have patch report endpoint /endpoint/
	When I call the patch method of the reports API with Already Subscribed Email
	Then I get report (PATCH) API valid response
	Given I have the get reports endpoint /endpoint/
	When I call the get method of the reports API
	Then I see valid email ids in the response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-56_Regression_Self-Service OST Report API_Update Email Only (PATCH)_Remove Single Email
	Given I have post report Daily_Stock_Excel_Remove Single Email endpoint /endpoint/
	When I call the post method of the report API Remove Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have patch report endpoint /endpoint/
	When I call the patch method of the reports API with Remove Single Email
	Then I get report (PATCH) API valid response
	Given I have the get reports endpoint /endpoint/
	When I call the get method of the reports API
	Then I see valid email ids in the response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-57_Regression_Self-Service OST Report API_Update Email Only (PATCH)_Remove multiple Email IDs
	Given I have post report Daily_Stock_Excel_Remove multiple Email endpoint /endpoint/
	When I call the post method of the report API Remove Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have patch report endpoint /endpoint/
	When I call the patch method of the reports API with Remove multiple Email
	Then I get report (PATCH) API valid response
	Given I have the get reports endpoint /endpoint/
	When I call the get method of the reports API
	Then I see valid email ids in the response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-58_Regression_Self-Service OST Report API_Update Email Only (PATCH)_Remove Same Email IDs
	Given I have post report Daily_Stock_Excel_Remove Same Email endpoint /endpoint/
	When I call the post method of the report API Remove Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have patch report endpoint /endpoint/
	When I call the patch method of the reports API with Remove Same Email
	Then I get report (PATCH) API valid response
	Given I have the get reports endpoint /endpoint/
	When I call the get method of the reports API
	Then I see valid email ids in the response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-59_Regression_Self-Service OST Report API_Update Email Only (PATCH)_Remove Already Removed Email
	Given I have post report Daily_Stock_Excel_Remove Already Removed Email endpoint /endpoint/	
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have patch report endpoint /endpoint/
	When I call the patch method of the reports API with Remove Already Removed Email
	Then I get report (PATCH) API bad response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-60_Regression_Self-Service OST Report API_Update Email Only (PATCH)_Invalid Email Addresses
	Given I have post report Daily_Stock_Excel_Invalid Email endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have patch report endpoint /endpoint/
	When I call the patch method of the reports API with invalid path
	Then I get report (PATCH) API bad response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-61_Regression_Self-Service OST Report API_Update Email Only (PATCH)_Upper Case Email ID
	Given I have post report Daily_Stock_Excel_Add Upper Case Email endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have patch report endpoint /endpoint/
	When I call the patch method of the reports API with Upper Case Email
	Then I get report (PATCH) API valid response
	Given I have the get reports endpoint /endpoint/
	When I call the get method of the reports API
	Then I see valid email ids in the response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-62_Regression_Self-Service OST Report API_Update Email Only (PATCH)_Mixed both Upper and Lower cases Email Address
	Given I have post report Daily_Stock_Excel_Add Upper and Lower Case Email endpoint /endpoint/
	When I call the post method of the report API Daily - Excel - Stock Order
	Then I get report API response with report ID
	Given I have patch report endpoint /endpoint/
	When I call the patch method of the reports API with Upper and Lower Case Email
	Then I get report (PATCH) API valid response
	Given I have the get reports endpoint /endpoint/
	When I call the get method of the reports API
	Then I see valid email ids in the response
	Given I have delete report endpoint /endpoint/
	When I call the delete method of the reports API
	Then I get report (DELETE) API response

	@OSTReport
Scenario: TC2-63_Regression_Self-Service OST Report API_Get Report Formats API
	Given I have get report formats request endpoint /endpoint/
	When I call the get method of report formats API
	Then I get report formats API response

	@OSTReport
Scenario: TC2-64_Regression_Self-Service OST Report API_Get Report Formats For Reseller API
	Given I have get report formats for reseller request endpoint /endpoint/
	When I call the get method of report formats for reseller API
	Then I get report formats for reseller API response

	@OSTReport
Scenario: TC2-65_Regression_Self-Service OST Report API_Get Report Fields API
	Given I have get report fields request endpoint /endpoint/
	When I call the get method of report fields API
	Then I get report fields API response

	@OSTReport
Scenario: TC2-66_Regression_Self-Service OST Report API_Get Report Fields For Reseller API
	Given I have get report fields for reseller request endpoint /endpoint/
	When I call the get method of report fields for reseller API
	Then I get report fields for reseller API response