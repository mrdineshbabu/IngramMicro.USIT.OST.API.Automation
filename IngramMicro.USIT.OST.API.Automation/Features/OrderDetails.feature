Feature: OrderDetails

	@OrderDetails
Scenario: TC1_01_Regression_OrderDetails_Tracking API_Stock Order
    Given I have get trackings request - Stock Order endpoint /endpoint/
	When I call the get method of trackings API
	Then I get trackings API response

	@OrderDetails
Scenario: TC1_02_Regression_OrderDetails_Tracking API_Cash Order
    Given I have get trackings request - Cash Order endpoint /endpoint/
	When I call the get method of trackings API
	Then I get trackings API response

	@OrderDetails
Scenario: TC1_03_Regression_OrderDetails_Tracking API_Directship Order
    Given I have get trackings request - Directship Order endpoint /endpoint/
	When I call the get method of trackings API
	Then I get trackings API response

	@OrderDetails
Scenario: TC1_04_Regression_OrderDetails_Tracking API_ODS Order
    Given I have get trackings request - ODS Order endpoint /endpoint/
	When I call the get method of trackings API
	Then I get trackings API response

	@OrderDetails
Scenario: TC1_05_Regression_OrderDetails_Tracking API_OLR Order
    Given I have get trackings request - OLR Order endpoint /endpoint/
	When I call the get method of trackings API
	Then I get trackings API response

	@OrderDetails
Scenario: TC1_06_Regression_OrderDetails_Tracking API_Multiple Tracking #s per Line
    Given I have get trackings request - Multiple Tracking endpoint /endpoint/
	When I call the get method of trackings API
	Then I get trackings API response

	@OrderDetails
Scenario: TC1_07_Regression_OrderDetails_Tracking API_Tracking No. Not Available
    Given I have get trackings request - Tracking No. Not Available endpoint /endpoint/
	When I call the get method of trackings API
	Then I get trackings API response

	@OrderDetails
Scenario: TC1_08_Regression_OrderDetails_Serials API_Cash Order_Single Serial
	Given I have get serials request - Cash Order_Single Serial endpoint /endpoint/
	When I call the get method of serials API
	Then I get serials API response

	@OrderDetails
Scenario: TC1_09_Regression_OrderDetails_Serials API_Stock Order_Multiple Serial
	Given I have get serials request - Stock Order_Multiple Serial endpoint /endpoint/
	When I call the get method of serials API
	Then I get serials API response

	@OrderDetails
Scenario: TC1_10_Regression_OrderDetails_Serials API_Directship Order
	Given I have get serials request - Directship Order endpoint /endpoint/
	When I call the get method of serials API
	Then I get serials API response

	@OrderDetails
Scenario: TC1_11_Regression_OrderDetails_Serials API_ODS Order
	Given I have get serials request - ODS Order endpoint /endpoint/
	When I call the get method of serials API
	Then I get serials API response

	@OrderDetails
Scenario: TC1_12_Regression_OrderDetails_Serials API_OLR Order
	Given I have get serials request - OLR Order endpoint /endpoint/
	When I call the get method of serials API
	Then I get serials API response

	@OrderDetails
Scenario: TC1_13_Regression_OrderDetails_Serials API_Serials Not Present
	Given I have get serials request - Serials Not Present endpoint /endpoint/
	When I call the get method of serials API
	Then I get serials API response

	@OrderDetails
Scenario: TC1_14_Regression_OrderDetails_Licenses API
	Given I have get licenses request endpoint /endpoint/
	When I call the get method of licenses API
	Then I get licenses API response

	@OrderDetails
Scenario: TC1_15_Regression_OrderDetails_Order API_Stock Order
	Given I have get orders request - Stock Order endpoint /endpoint/
	When I call the get method of orders API
	Then I get orders API response

	@OrderDetails
Scenario: TC1_16_Regression_OrderDetails_Order API_Cash Order
	Given I have get orders request - Cash Order endpoint /endpoint/
	When I call the get method of orders API
	Then I get orders API response

	@OrderDetails
Scenario: TC1_17_Regression_OrderDetails_Order API_Direct Order
	Given I have get orders request - Direct Order endpoint /endpoint/
	When I call the get method of orders API
	Then I get orders API response

	@OrderDetails
Scenario: TC1_18_Regression_OrderDetails_Order API_ODS Order
	Given I have get orders request - ODS Order endpoint /endpoint/
	When I call the get method of orders API
	Then I get orders API response

	@OrderDetails
Scenario: TC1_19_Regression_OrderDetails_Order API_OLR Order
	Given I have get orders request - OLR Order endpoint /endpoint/
	When I call the get method of orders API
	Then I get orders API response

	@OrderDetails
Scenario: TC1_20_Regression_OrderDetails_Order Line API_Stock Order (Single Shipment)
	Given I have get lines request - Stock Order (Single Shipment) endpoint /endpoint/
	When I call the get method of lines API
	Then I get lines API response

	@OrderDetails
Scenario: TC1_21_Regression_OrderDetails_Order Line API_Cash Order
	Given I have get lines request - Cash Order endpoint /endpoint/
	When I call the get method of lines API
	Then I get lines API response

	@OrderDetails
Scenario: TC1_22_Regression_OrderDetails_Order Line API_Directship Order
	Given I have get lines request - Directship Order endpoint /endpoint/
	When I call the get method of lines API
	Then I get lines API response

	@OrderDetails
Scenario: TC1_23_Regression_OrderDetails_Order Line API_ODS Order
	Given I have get lines request - ODS Order endpoint /endpoint/
	When I call the get method of lines API
	Then I get lines API response

	@OrderDetails
Scenario: TC1_24_Regression_OrderDetails_Order Line API_OLR Order
	Given I have get lines request - OLR Order endpoint /endpoint/
	When I call the get method of lines API
	Then I get lines API response

	@OrderDetails
Scenario: TC1_25_Regression_OrderDetails_Order Line API_With Multiple Shipment
	Given I have get lines request - With Multiple Shipment endpoint /endpoint/
	When I call the get method of lines API
	Then I get lines API response

	@OrderDetails
Scenario: TC1_26_Regression_OrderDetails_Order Line API_Partially Shipped Line Status
	Given I have get lines request - Partially Shipped Line Status endpoint /endpoint/
	When I call the get method of lines API
	Then I get lines API response

	@OrderDetails
Scenario: TC1_27_Regression_OrderDetails_Order Line API_Void Line Status
	Given I have get lines request - Void Line Status endpoint /endpoint/
	When I call the get method of lines API
	Then I get lines API response

	@OrderDetails
Scenario: TC1_28_Regression_OrderDetails_Order Line API_Open Line Status
	Given I have get lines request - Open Line Status endpoint /endpoint/
	When I call the get method of lines API
	Then I get lines API response	

	@OrderDetails
Scenario: TC1_29_Regression_OrderDetails_Trackings_Shipmentlevel_Stock Order
	Given I have get tracking shipment request - Stock Order endpoint /endpoint/
	When I call the get method of tracking shipment API
	Then I get tracking shipment API response

	@OrderDetails
Scenario: TC1_30_Regression_OrderDetails_Trackings_Shipmentlevel_Cash Order
	Given I have get tracking shipment request - Cash Order endpoint /endpoint/
	When I call the get method of tracking shipment API
	Then I get tracking shipment API response

	@OrderDetails
Scenario: TC1_31_Regression_OrderDetails_Trackings_Shipmentlevel_Direct Order
	Given I have get tracking shipment request - Direct Order endpoint /endpoint/
	When I call the get method of tracking shipment API
	Then I get tracking shipment API response