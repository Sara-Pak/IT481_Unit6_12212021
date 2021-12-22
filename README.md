# IT481_Unit6_12212021
A clothing company is building a new store. They want to determine the optimum (but fixed) number of dressing rooms they should install in this location.
You must create a scenario in which a group of customers will be waiting to use the dressing rooms.

Each customer may take up to six clothing items into a dressing room.

Each item of clothing is estimated to take 1 to 3 minutes to try on.

Once the customer has attempted to fit into each of the items, the customer will leave the dressing room.

Leaving the dressing room makes the room available for another customer.

In each scenario, use variables to determine the number of customers and dressing rooms.

Use a random number function to determine the number of items for each customer.

DressingRooms will be a class, and there will only be one instance of DressingRooms.

The default constructor will use three rooms as the default.
The constructor takes a parameter that sets the number of rooms available.
Use a semaphore object to control access to the rooms.
Supply a public RequestRoom() method that the customer will use to gain access.
A RequestRoom method waits for an available room.
Customer will be implemented as a thread.

Allow for a parameter named NumberOfItems .
ClothingItems = 0 will indicate the use of a random number.
ClothingItems = 1 – 20 will allow for load testing by forcing a specific number of items.
The store policy is a maximum of six items, but this may be modified during a test.
Scenario will be a class.

Create a constructor that accepts:
The number of rooms available.
The number of customers.
Create rooms as specified.
Create customers as specified
Create each scenario to execute in a routine called scenarioXXwhere XX is a number.

Each scenario will record a start time and an end time.
The elapsed time will be calculated from those variables.
Calculate the number of customers.
Calculate the average number of items.
Calculate the average usage time of the room.
Calculate the time spent waiting for a room.
