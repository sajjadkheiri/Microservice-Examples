# Microservice-Examples

## What is Monolith

## What is Microservice

## Why we should choose Microservice

## Advantageous and Disadvantageous of Microservice

## Microservice Architecture Pattern Language

## Communication in Microservice

### Interaction Styles

1. Sync
    - One to one : Request & Response

2. Async
    - One to one : Async Request & Response / One way notification
    - One to many : Pub-Sub / Pub-Async response

### API

### Messaging Format

### Partial failure (Circuit Breaker)

### Service Discovery

#### Service Registry

### Messaging

#### Idempotent Consumer

#### Transactional Outbox Pattern

1. Pooling Publisher (recommend)
2. Transaction Log Tailing

## Managing Transactions

### ACID Transaction

### Trouble With Distributed Transaction

### Saga Pattern

### Types of Transactions

1. Compensation
2. Retriable
3. Pivotal

### Coordinating in Saga

1. Choreography
2. Orchestration

### Anomaly

#### Lost Update :

One Saga overwrites without reading changes made by another Saga

#### Dirty Read :

A transaction reads the updates made by a Saga that has not yet completed those updates

#### NonRepeatable Read :

Two different steps of Saga read the same data and get different results because another saga has made updates

### Countermeasure for handling the lack of isolation

#### Semantic Lock :

#### Commutative Update :

#### Pessimistic View :

#### Reread Value :

#### Version File :

#### By Value :

## Domain Modeling & Building Blocks

### Patterns

#### Entity

> [!Tip]
> Every entity has an identity property (Id) that It doesn't modify the value.
<br />
> If two object have the same Id, we have a same object.

```c#
    public class Person
    {
        public int Id { get; private set;}
        public string FirstName { get; private set;}
        public string LastName { get; private set;}
        
        public Person(int id,string firstName,string lastName)
        {
            if(string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameOf(firstName))
            
            if(string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameOf(lastName))
            
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        
        public void SetFirstName(string firstName)
        {
            if(string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameOf(firstName))
            
            FirstName = firstName;
        }
        
        public void SetLastName(string lastName)
        {
            if(string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameOf(lastName))
            
            LastName = lastName;
        }
        
        public override bool Equals(object? obj)
        {
            var other = obj as Person;
            if (other == null)
                return false;
            
            return this.Id == other.Id;
        }
    }
```

#### Value Object

```c#
   public class FirstName
   {
       public string Value { get; private set;}
       
       public FirstName(string value)
       {
         if(string.IsNullOrEmpty(firstName))
            throw new ArgumentNullException(nameOf(firstName))
            
            Value = value
       }
       
       public FirstName SetFirstName(string value)
       {
           return new FirstName(value);
       }
       
       public override Equals(object? obj)
       {
           var other = obj as FirstName;
           if(other == null)
                return false;
           
           return Value == other.value;
       }
   }    
```

```c#
    public class Person
    {
        public int Id { get; private set;}
        public FirstName FirstName { get; private set;}
        public LastName LastName { get; private set;}
        
        public Person(int id,FirstName firstName,LastName lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        
        public void SetFirstName(FirstName firstName)
        {           
            FirstName = FirstName.SetFirstName(firstName);
        }
        
        public void SetLastName(LastName lastName)
        {           
            LastName = LastName.SetLastName(lastName);
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Person;
            if (other == null)
                return false;
            
            return this.Id == other.Id;
        }
    }
```

#### Domain Service

Domain service is a business logic that is independent and stateless. It increases
cohesion and low coupling. It means that a method must have the input parameters
that calculate logic and finally return output.

#### Module

#### Lifecycle pattern

##### Aggregate
- Aggregate root
- Don't have relationship between objects just use object's id
- You don't access to use objects under aggregate root directly like order/OrderLines
##### Factory

##### Repository

The approach of repository in Microservice is , you should behave like a repository
in an Aggregation scope.


## Value Object

### Advantage of Value Object

- Identity less
- Attribute-Base
- Behaviour rich
- Cohesive

- Immutable : When you instantiate an object, you cannot change the value of object
in the whole life

- Combinable
- Self-validating
- Testable

### Common pattern in value object

- Factory method
- Tiny/Micro type
- Collection of value object

### Value object in Entity Framework

#### What is Owned Type
#### What is Value Conversion


## Entity

//TODO : Please come back and learn this concept.

## Domain Event

### Raise, Handler and Dispatch Events

#### Raise Event

#### Handler Event

#### Dispatch Event

### Dispatch Events by writing framework

### Dispatch Events by DbContext

### Transactional OutBox pattern

## Aggregate

### What is Single Traversal Direction

## Repository

## Event Source

## CQRS