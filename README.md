# loge

.NET solution to showcase sample REST and gPRC endpoints for sending and consuming data.

The aim is to provide the enduser endpoints to create a TransportOrder, consume the state of TransportOrder and view historical TransportOrders.

* Domain-Driven-Design
* Clean Architecture
* Unit of Work
* Repository Pattern
* gRPC
* REST
* WebAPI
* EF Core

 # Additional thoughts
 The TransportOrder, which is an entity that would have it's state and perhaps content changed when being processed,
 would be an ideal candidate for Event Sourcing architectural pattern.

 Event Sourcing is a architectural pattern that saves historical changes to an entity as append-only, and thus does not change the actual entity,
 which an regular DB update would do. Instead it applies another row with the decired change.

 And since an TransportOrder is something that can change from "New"->"InProcess"->"Delivered", then these states would be applied as new rows in the DB.

 When then consuming the entity, all the rows are consumed and the entity is 


 https://learn.microsoft.com/en-us/azure/architecture/patterns/event-sourcing
