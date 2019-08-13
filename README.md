# learning-project

The idea of this project is to use one of the three technology in each project:
- CQRS, DDD, Event Sourcing
and see what benefits or difficulties we encounter along the way.

[DDD + ES](https://github.com/mkcoder/learning-project/tree/master/dddwithes)

![Architecture diagram](https://github.com/mkcoder/learning-project/blob/master/how%20to.jpg?raw=true)

Steps:
1. A client will post an Event to a controller
2. Controller will place this event on a Queue use [MediatR](https://github.com/jbogard/MediatR)
3. These events will then be persisted to a store
4. Aggregates will be listening to these events on the Queue
5. Aggregates will then call the respective models to change the SQL database
