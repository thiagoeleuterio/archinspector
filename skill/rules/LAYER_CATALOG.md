# Layered Architecture Rule Catalog

## Catalog Scope

This catalog defines the official organization of Layered Architecture rules in ArchInspector.

It lists the rule identifiers, titles, and short objectives used to organize evidence-driven review of layer responsibilities, allowed dependency direction, cross-layer access, business logic placement, infrastructure isolation, data access boundaries, and layer boundary integrity.

The catalog is limited to Layered Architecture responsibilities already supported by ArchInspector. It does not define full rule content, knowledge material, examples, templates, evaluation assets, scoring, findings, or review output.

Layered Architecture rules evaluate whether responsibilities and dependencies across explicitly identified layers remain consistent with the selected layered structure. They do not introduce Hexagonal Architecture, Clean Architecture, Domain-Driven Design, SOLID, Fowler Patterns, Events and Messaging, Architecture Testing, or Solution Architecture rules.

## Relationship with Hexagonal Architecture

Layered Architecture shares boundary and dependency concerns with Hexagonal Architecture, especially when infrastructure or delivery code must not control business behavior.

The Layered Architecture catalog does not rewrite Hexagonal Architecture rules. Hexagonal rules own concerns primarily framed around ports, adapters, inbound boundaries, outbound boundaries, adapter model leakage, dependency direction toward the core, and core behavior testability without adapters.

Layered Architecture rules preserve distinct responsibilities related to conventional presentation, application, domain, infrastructure, service, and data access layers; declared layer dependency direction; layer bypassing; and responsibility placement within a layered structure.

When a Layered Architecture rule relates to a Hexagonal rule, the Layered Architecture rule must evaluate layer responsibility or layer dependency conformance rather than duplicate a ports-and-adapters condition.

## Relationship with Clean Architecture

Layered Architecture shares policy separation and dependency direction concerns with Clean Architecture when higher-level behavior must remain independent from lower-level technical details.

The Layered Architecture catalog does not rewrite Clean Architecture rules. Clean Architecture rules own concerns primarily framed around entities, use cases, interface adapters, frameworks and drivers, boundary data structures, policy direction, gateways, presenters, controllers, and flow of control across Clean Architecture boundaries.

Layered Architecture rules preserve distinct responsibilities related to declared layers and their conventional roles, especially whether presentation, application or service, domain or business, infrastructure, and data access responsibilities stay within their assigned layer boundaries.

When a Layered Architecture rule relates to a Clean Architecture rule, the Layered Architecture rule must evaluate conformance to a layered structure rather than duplicate Clean Architecture policy-ring or use-case-boundary conditions.

## Relationship with Domain-Driven Design

Layered Architecture can coexist with Domain-Driven Design when domain code appears inside a domain or business layer.

The Layered Architecture catalog does not rewrite Domain-Driven Design rules. Domain-Driven Design rules own concerns primarily framed around domain language, bounded contexts, aggregates, entities, value objects, domain services, application services, repositories as domain-facing abstractions, factories, domain events, invariants, model richness, context relationships, and domain isolation.

Layered Architecture rules preserve distinct responsibilities related to where business logic is placed in a layered structure and whether other layers assume responsibilities assigned to the domain or business layer.

When a Layered Architecture rule relates to a Domain-Driven Design rule, the Layered Architecture rule must evaluate layer placement and layer boundary integrity rather than domain model quality, domain meaning, or tactical DDD pattern correctness.

## Rule Ordering Principles

Rules are ordered from foundational layer definition to dependency direction, layer-specific responsibility placement, and boundary integrity.

The sequence begins with protection of business policy from lower-level details, then establishes explicit layer responsibilities and allowed dependency direction. It then moves through presentation, application or service, domain or business, and data access responsibilities. The sequence ends with cross-layer bypassing and layer contract integrity because those concerns depend conceptually on the reviewer first identifying the participating layers and their responsibilities.

This order supports review consistency without making later rules procedurally dependent on earlier rules.

## Official Rules

| Rule ID | Title | Objective |
| ------- | ----- | --------- |
| LAYER-001 | Lower-level details must not control business policy | Ensure lower-level technical or detail layers do not control business policy decisions. |
| LAYER-002 | Layers must have explicit and consistent responsibilities | Ensure identified layers have clear responsibilities that remain consistent within the reviewed scope. |
| LAYER-003 | Dependencies must follow the declared layer direction | Ensure dependencies between layers conform to the direction defined by the layered structure. |
| LAYER-004 | Presentation layer must not own application or business behavior | Ensure presentation code handles interaction concerns without containing application workflow or business rules. |
| LAYER-005 | Application or service layer must coordinate without owning business rules | Ensure application or service layer code orchestrates work without becoming the owner of business rules. |
| LAYER-006 | Domain or business layer must own business rules | Ensure business rules are located in the layer assigned to domain or business responsibility rather than scattered across other layers. |
| LAYER-007 | Data access layer must contain persistence access responsibilities | Ensure persistence access responsibilities remain inside the data access or infrastructure layer assigned to that concern. |
| LAYER-008 | Layers must not bypass required intermediate layers | Ensure layer interactions do not skip required intermediate layers when the declared layered structure requires mediation. |
| LAYER-009 | Layer contracts must preserve boundary integrity | Ensure data and service contracts between layers do not force one layer to expose or depend on responsibilities owned by another layer. |

## Rule Dependencies

Some rules depend conceptually on earlier rules because they reuse the same Layered Architecture vocabulary for identified layers, declared dependency direction, layer responsibilities, and boundary integrity.

Rules about presentation, application or service, domain or business, infrastructure, and data access responsibilities are easier to interpret after the reviewer has identified the relevant layers and their assigned responsibilities.

Rules about cross-layer bypassing and layer contracts are easier to interpret after the reviewer has established the declared layer direction and the layer responsibilities being crossed.

These conceptual dependencies do not make one rule dependent on the execution result of another rule. Each rule remains independently selectable and independently evaluable when the reviewed material provides enough evidence for that rule.

## Catalog Stability

Rule IDs are stable once published.

New Layered Architecture rules may be added to the catalog without changing existing Rule IDs. Existing IDs must not be reused for substantially different architectural conditions.

Editorial changes may clarify titles or objectives, but changes that alter the evaluated architectural concern require a new Rule ID.
