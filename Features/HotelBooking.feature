Feature: Hotel Booking Scenario

@hotelBooking
Scenario: Order T-Shirt and Verify in Order History
	Given I check the availability of a deluxe room
	When I book the room
	Then I verify the booking