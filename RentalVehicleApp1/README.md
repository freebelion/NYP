## RentalVehicleApp1

- This project is intended as a sample project
  for the upcoming term project assignment.

- It is a toy project which imitates the operations
  of a vehicle rental company.

- It has three classes:\
`RentalVehicle`\
`RentalRequest`\
`RentalContract`

- I cannot claim I have designed them in the best possible ways,
  but here I will summarize the simple principles I have followed.

- To start with, a class should package the attributes
  of a real-life object that identify it.

  - What we call an "attribute" is actually an identifying
    piece of information about the object.

  - Such information are stored in member variables of a class
    and exposed through public properties in controlled ways.

  - For example, my `RentalVehicle` class has **PlateNumber**
    as the vehicle's -obviously- most identifying attribute.
    - I defined it as an auto-property for simplifying my work;
      it does serve as a member variable which stores
      the vehicle's identifying information.
    - You may have noted the **init** block of that property
      (and of some other properties).
      That is a special feature of relatively new C# versions;
      it lets the property value initialized only once,
      within the class constructor.
    - This way the class `RentalVehicle` perfectly imitates
      the real life. In a real-life application,
      a vehicle would have its plate number recorded
      only when it was acquired by the company,
      which would be the time an object of this class
      would be created to represent that new vehicle.

- Then come the property definitions:
  - **Type** is another auto-property which serves
    as an identifying attribute.
  - **DailyRate**, **KilometerRate** and **IsRented**
    are *operational properties*; they are not the identifying
    attributes of a vehicle, but they store information
    about the "state" of the vehicle.
  - In summary, the properties in a class definition
    must store the temporary information about
    the object's operational qualities and status.

- While designing classes, you should keep to bare minimums,
  especially in simple applications that you develop
  for testing purposes.
  - Your member variable and property definitions
    should only store the attributes and status updates
    that your application will require.
  - Yes, in a comprehensive real-world application,
    a rental vehicle's record would need to include
    its VIN, registration info, some technical stuff
    about its engine and parts, etc. but such extra details
    would most probably be left in database records
    and only accessed in very special circumstances.
  - A rental vehicle management application would certainly
    not ever look into such technical details.\
    Even if a vehicle had to be sent out for maintenance,
    or if the vehicle's registration had to be changed,
    such operations would be performed by outside modules.
    The rental vehicle app would only be informed that
    certain vehicles were "unavailable" during those operations.

- Another important point is that, a class definition
  should only contain the definitions of attributes
  and properties that will need to be stored
  (in files or database tables).
  - That 's certainly the case with `RentalVehicle` class.
  - I have designed the `RentalRequest` class
    with the same principle in mind.
    Think: what would you need to know about the request
    for renting a vehicle?
    Just the type of the requested vehicle.
  - Then you would need to record the time of the request
    assign the request a number.

- Okay, but what about the information about the rented vehicle?
  Shouldn't they also be stored in a `RentalRequest` object?
  - Definitely no. A request is just that: a request.
    In real life, someone making a request would not know
    what item they would get until making a contract.
 
- In this application, the "contract" is represented
  by the class `RentalContract`.
  - An object of this type will represent a temporary contract
    between a renter and the company which does the renting.
  - This class also has the bare minimum information
    about the contract it will represent:\
    the number of the request it honors,
    and the identifying information about the rented vehicle.
  - Again, a real-life application may have to store
    more details. For example, if a different type of vehicle
    (a sedan auto instead of a compact auto) was assigned,
    *for whatever reason*,
    that would have to be recorded in a separate property,
    maybe **AssignedType**.
  - In a real-life application, the exact rental period may not
    be known at the time of the contract.
    I made up a fake time period just to test my toy application.

- You may have noted that the class `RentalContract`
  actually associates a `RentalRequest` object
  and a `RentalVehicle` object.
  - In that case, maybe you are wondering why that class
    doesn't have properties to store the references
    of those two objects.
  - Storing the object references would certainly help
    a `RentalContract` object look up the request number,
    vehicle plate number, and any other extra details
    whenever it needed.
  - However, storing object references would also enable
    a `RentalContract` object look up the properties
    it wouldn't or shouldn't need.
  - Think of the situation of a visitor registering
    at a hotel desk. The receptionist could ask for
    an ID/Passport and maybe a credit card number
    for ensuring future payment,
    but the visitor should not need to let the receptionist
    keep those sensitive cards or documents.
  - If the `RentalContract` class had the properties
    to store the references to `RentalRequest` and
    `RentalVehicle` objects,
    those objects would be re-recorded any time
    a `RentalContract` object were recorded.
  - To prevent clutter in data files or database tables
    *which I am not yet using*, I have only defined
    properties to store the information which had to be stored.

- Finally, a real-world application would need to employ
  a "manager class" to handle the real-life operations.
  - I have let the `Program` class handle the operations,
    but this was not the right way, even for this toy application.
  - The reason is that, when you develop an application,
    you should design "portable" classes;
    others should be able to import your classes
    and make them work in desktop or mobile applications
    which will do the same or similar work.
  - Of course, portability requirement also applies
    to the "manager class".
  - In short, my **Program** object should have created
    an object of `RentalManager` class
    and let it create/load/save objects
    and perform the operations.
  - In WPF-based visual applications or
    .NET MAUI cross-platform applications,
    **ViewModel** classes handle the operations
    and help visualize the outcomes or results
    in **View**s, the application window and
    the visual controls it contains.
  - The classes like the ones I defined here are **Model** classes;
    they are only for storing the objects' attributes
    and properties.
  - The visualizations of the information or state
    of **Model** classes on **View**s are hendled
    by **ViewModel** classes.\
    This method of application development is known as
    the ""MVVM arhictecture"".
  - To have some ideas about the MVVM architecture,
    look at the WPF-based visual application examples in my repo
    [SWE305](https://github.com/freebelion/SWE305)