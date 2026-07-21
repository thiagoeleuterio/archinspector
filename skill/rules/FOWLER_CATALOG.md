# Fowler Enterprise Patterns Catalog

## Catalog Scope

This catalog defines the official Fowler Enterprise Patterns that may be evaluated by ArchInspector in future Fowler Patterns rules.

The catalog only identifies candidate rules for evidence-driven review of patterns described by Martin Fowler in *Patterns of Enterprise Application Architecture*. It does not make any Fowler pattern universally required.

This catalog does not define findings, evidence, severity, confidence, applicability, remediation, detailed references, scoring, examples, templates, or complete rule documents.

## Rule Catalog

| Rule ID | Title | Objective | Category |
| --- | --- | --- | --- |
| FOWLER-001 | Repository | Evaluate whether collection-like access to domain objects mediates between domain logic and data mapping concerns. | Data Source Architectural Patterns |
| FOWLER-002 | Transaction Script | Evaluate whether business logic is organized as procedural transactions that coordinate validation, calculation, and persistence for a request. | Domain Logic Patterns |
| FOWLER-003 | Domain Model | Evaluate whether business behavior is represented by an object model that combines state and behavior around domain concepts. | Domain Logic Patterns |
| FOWLER-004 | Table Module | Evaluate whether business logic is organized around one class per database table or view rather than around individual domain objects. | Domain Logic Patterns |
| FOWLER-005 | Service Layer | Evaluate whether application operations are exposed through a service boundary that coordinates domain logic and transaction control. | Domain Logic Patterns |
| FOWLER-006 | Active Record | Evaluate whether objects combine domain data, domain behavior, and persistence operations for rows in a database table or view. | Data Source Architectural Patterns |
| FOWLER-007 | Data Mapper | Evaluate whether persistence mapping is separated from domain objects so the domain model remains independent of database access mechanics. | Data Source Architectural Patterns |
| FOWLER-008 | Row Data Gateway | Evaluate whether one object represents a single database row and provides access operations for that row. | Data Source Architectural Patterns |
| FOWLER-009 | Table Data Gateway | Evaluate whether one object provides access operations for all rows in a database table or view. | Data Source Architectural Patterns |
| FOWLER-010 | Identity Map | Evaluate whether loaded objects are tracked so repeated access to the same identity returns the same in-memory object instance. | Object-Relational Behavioral Patterns |
| FOWLER-011 | Unit of Work | Evaluate whether changes to objects are tracked and coordinated as a single persistence transaction. | Object-Relational Behavioral Patterns |
| FOWLER-012 | Lazy Load | Evaluate whether related data is deferred until it is needed while preserving the expected object interaction model. | Object-Relational Behavioral Patterns |
| FOWLER-013 | Identity Field | Evaluate whether persisted object identity is stored in a field that maps object instances to database rows. | Object-Relational Structural Patterns |
| FOWLER-014 | Foreign Key Mapping | Evaluate whether object references are mapped to foreign keys while preserving object relationship semantics. | Object-Relational Structural Patterns |
| FOWLER-015 | Remote Facade | Evaluate whether remote access is provided through a coarse-grained facade that minimizes distributed interaction costs. | Distribution Patterns |
| FOWLER-016 | Data Transfer Object | Evaluate whether data is transferred across process or network boundaries through objects designed for transfer rather than domain behavior. | Distribution Patterns |
| FOWLER-017 | Optimistic Offline Lock | Evaluate whether concurrent offline work is protected by conflict detection before committing changes. | Offline Concurrency Patterns |
| FOWLER-018 | Pessimistic Offline Lock | Evaluate whether concurrent offline work is protected by acquiring exclusive access before changes are made. | Offline Concurrency Patterns |
| FOWLER-019 | Client Session State | Evaluate whether session state is stored on the client side when that distribution of state is relevant to the system design. | Session State Patterns |
| FOWLER-020 | Registry | Evaluate whether globally accessible objects are used as a known lookup point for shared services or objects. | Base Patterns |

## Catalog Stability

Rule IDs are stable once published.

New Fowler Patterns rules may be added to the catalog without changing existing Rule IDs. Existing IDs must not be reused for substantially different architectural conditions.

Editorial changes may clarify titles or objectives, but changes that alter the evaluated architectural concern require a new Rule ID.
