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

#### Value Object

#### Domain Service