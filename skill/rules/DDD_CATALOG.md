# Domain-Driven Design Rule Catalog

## Catalog Scope

This catalog defines the official organization of Domain-Driven Design rules in ArchInspector.

It lists the rule identifiers, titles, and short objectives used to organize evidence-driven review of domain language, bounded contexts, tactical domain model building blocks, domain invariants, domain events, context relationships, and domain isolation.

The catalog is limited to Domain-Driven Design responsibilities already supported by ArchInspector. It does not define full rule content, knowledge material, examples, templates, evaluation assets, scoring, findings, or review output.

Domain-Driven Design rules evaluate whether domain concepts, boundaries, and models preserve domain meaning and support evidence-based reasoning about business behavior. They do not introduce Hexagonal Architecture, Clean Architecture, SOLID, Layered Architecture, Fowler Patterns, Events and Messaging, Architecture Testing, or Solution Architecture rules.

## Relationship with Hexagonal Rules

Domain-Driven Design shares boundary and isolation concerns with Hexagonal Architecture when domain and application behavior are protected from technical mechanisms.

The Domain-Driven Design catalog does not rewrite Hexagonal Architecture rules. Hexagonal rules own concerns primarily framed around ports, adapters, dependency direction, framework leakage, persistence leakage, messaging adapters, adapter models, and core testability without adapters.

Domain-Driven Design rules preserve distinct responsibilities related to domain language, bounded contexts, aggregates, aggregate roots, entities, value objects, domain services, repositories as domain-facing model concepts, factories, domain events, invariants, model richness, context mapping, anti-corruption layers, shared kernels, published language, upstream and downstream relationships, and domain isolation.

When a Domain-Driven Design rule relates to a Hexagonal rule, the Domain-Driven Design rule must evaluate domain meaning or domain boundary integrity rather than duplicate the full Hexagonal condition.

## Relationship with Clean Architecture Rules

Domain-Driven Design shares policy and business-rule concerns with Clean Architecture when entities, use cases, application services, gateways, or boundary abstractions interact with domain code.

The Domain-Driven Design catalog does not rewrite Clean Architecture rules. Clean Architecture rules own concerns primarily framed around source dependency direction, use case isolation, enterprise and application policy separation, interface adapters, controllers, presenters, gateways, data mappers, boundary data structures, flow of control, and visibility of use cases and policies.

Domain-Driven Design rules preserve distinct responsibilities related to the quality and integrity of domain models, domain language, consistency boundaries, domain invariants, tactical modeling patterns, and relationships between bounded contexts.

When a Domain-Driven Design rule relates to a Clean Architecture rule, the Domain-Driven Design rule must evaluate the domain modeling responsibility rather than duplicate the full Clean Architecture condition.

## Rule Ordering Principles

Rules are ordered from foundational domain meaning to tactical model structure and then to relationships between bounded contexts.

The sequence begins with value objects and ubiquitous language, then moves through bounded contexts, aggregates, aggregate roots, entities, domain services, application services, repositories, factories, domain events, invariants, model richness, context relationships, anti-corruption layers, shared kernels, published language, upstream and downstream roles, and domain isolation.

This order supports review consistency without making later rules procedurally dependent on earlier rules.

## Official Rules

| Rule ID | Title | Objective |
| ------- | ----- | --------- |
| DDD-001 | Value objects should protect invariants | Ensure value objects preserve domain meaning by protecting invariants. |
| DDD-002 | Domain language must be reflected consistently | Ensure domain terminology is used consistently across the reviewed domain model and related boundaries. |
| DDD-003 | Bounded contexts must define explicit model boundaries | Ensure distinct domain models have identifiable boundaries and do not blur incompatible meanings. |
| DDD-004 | Aggregates must enforce consistency boundaries | Ensure aggregates protect the consistency rules that belong within their transactional boundary. |
| DDD-005 | Aggregate roots must control aggregate access | Ensure aggregate roots are the controlled entry point for modifying aggregate state. |
| DDD-006 | Entities must preserve identity and lifecycle consistency | Ensure entities represent domain identity and lifecycle behavior consistently. |
| DDD-007 | Domain services must contain domain behavior only when it does not belong to an entity or value object | Ensure domain services express domain operations that do not naturally belong inside entities or value objects. |
| DDD-008 | Application services must not contain domain decisions | Ensure application services coordinate domain behavior without owning domain rules or decisions. |
| DDD-009 | Repositories must represent domain collection boundaries | Ensure repositories expose domain-oriented collection access without making the domain model conform to storage concerns. |
| DDD-010 | Factories must protect complex domain creation | Ensure factories preserve valid construction when domain object creation involves non-trivial invariants or lifecycle rules. |
| DDD-011 | Domain events must express domain-significant facts | Ensure domain events represent meaningful facts from the domain model rather than technical notifications. |
| DDD-012 | Domain invariants must be enforced by the domain model | Ensure domain rules that must always hold are protected by domain behavior and state transitions. |
| DDD-013 | Domain models must preserve behavioral richness | Ensure domain models contain meaningful behavior and do not collapse into passive data structures when domain behavior is present. |
| DDD-014 | Context relationships must be explicit | Ensure relationships between bounded contexts are visible enough to support evidence-based review. |
| DDD-015 | Anti-corruption layers must protect domain models from external models | Ensure external or foreign models are translated before they shape the local domain model. |
| DDD-016 | Shared kernels must remain explicit and limited | Ensure shared domain model elements are intentionally bounded and do not create uncontrolled coupling between contexts. |
| DDD-017 | Published languages must define stable inter-context contracts | Ensure inter-context communication uses stable language owned by the publishing context. |
| DDD-018 | Upstream and downstream roles must be visible in context relationships | Ensure directional influence between bounded contexts can be identified from reviewed material. |
| DDD-019 | Domain code must remain isolated from non-domain responsibilities | Ensure domain code preserves domain meaning by avoiding responsibilities that belong to application coordination, technical mechanisms, or presentation concerns. |

## Rule Dependencies

Some rules depend conceptually on earlier rules because they reuse the same Domain-Driven Design vocabulary for domain language, bounded contexts, aggregates, value objects, entities, domain services, repositories, factories, domain events, invariants, and context relationships.

Rules about aggregates, aggregate roots, entities, domain services, repositories, factories, and invariants are easier to interpret after the reviewer has identified the relevant domain language and bounded context.

Rules about context mapping, anti-corruption layers, shared kernels, published language, and upstream or downstream roles are easier to interpret after the reviewer has identified the relevant bounded contexts and their relationship boundaries.

These conceptual dependencies do not make one rule dependent on the execution result of another rule. Each rule remains independently selectable and independently evaluable when the reviewed material provides enough evidence for that rule.

## Catalog Stability

Rule IDs are stable once published.

New Domain-Driven Design rules may be added to the catalog without changing existing Rule IDs. Existing IDs must not be reused for substantially different architectural conditions.

Editorial changes may clarify titles or objectives, but changes that alter the evaluated architectural concern require a new Rule ID.
