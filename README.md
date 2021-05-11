# PricingService

## About
PricingService provides multiple services to other companies for a centrain fee. This Web API contains micro-services solution that is solely responsible for calculating prices and should only be called by other services. There are three types of services; "Service A", "Service B" and "Service C". These services have different prices and they also depend on the customer, the time period for which they are charged, possible discount (Percentage of total price), free days (a type of discount based on number of free days). Customers can choose which service they want to use independently.

The user story is: **_As a calling service it should be possible to call an endpoint with customerId, start and end in PricingService to know what to charge for a specific customer_**

This Web API (PricingService) is built with appropriate endpoints and implemented the following service paymentplan:

- Base costs are as follows:
    - _Service A_ = € 0,8 / working day (monday-friday)
    - _Service B_ = € 1,4 / working day (monday-friday)
    - _Service C_ = € 2,5 / day (monday-sunday)

- Due to the abstract class for ServicePaymentplan the base prices can be overriden by customers (e.g. "Customer A" only pays € 0,5 per working day for "Service A" but pays € 1,65 per working day for "Service B")

- It is possible to store discount per Customer and service
- It is possible to store Customer start date per service 
- It is possible to store number of free days per Customer (affects all services)

Use appropriate methodology to test the following scenarios;

- "Customer X" has been a customer since 2019-09-20 and has been using "Service A" and "Service C". "Customer X" has had an active disctount of 20% between 2019-09-22 and 2019-09-24 for "Service C". What is the total price for "Customer X" up until 2019-10-01 ?

- "Customer Y" has been a customer since 2018-01-01 and has been using "Service B" and "Service C". "Customer Y" should have 200 free days and a discount of 30% for the rest of the time. What is the total price for "Customer Y" up until 2019-10-01 ?

## Demo
Run the program with Postman and call the Post method named "PostDemo" wich demostrates the functionality of this Web API.

Type this in the Postman Body and mix it up with the Customer and Discount values to try it out.
Since "PricingServiceType" is of type enum "ServiceA" = 0, "ServiceB" = 1, "ServiceC" = 2.
```
{
    "Customer": 
    {
        "Id": 23,
        "FreeDays": 2,
        "MemberPriceServiceA": 10
    },

    "Discount":
    {
        "DiscountServiceA": 0.5,
        "StartDiscount": "2021-02-01",
        "EndDiscount": "2021-02-10"
    },

    "Start" : "2021-02-01",
    "End" : "2021-02-10",
    "PricingServiceType": 0
}
```
