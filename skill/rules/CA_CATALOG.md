# Clean Architecture Rule Catalog

## Catalog Scope

This catalog defines the official organization of Clean Architecture rules in ArchInspector.

It lists the rule identifiers, titles, and short objectives used to organize evidence-driven review of source dependency direction, policy boundaries, entities, use cases, interface adapters, frameworks and drivers, boundary data structures, flow of control, and architectural intent visibility.

The catalog is limited to Clean Architecture responsibilities already supported by ArchInspector. It does not define full rule content, knowledge material, examples, templates, evaluation assets, scoring, findings, or review output.

Clean Architecture rules evaluate policy direction and separation between enterprise business rules, application business rules, interface adapters, and technical details. They do not introduce Domain-Driven Design, SOLID, Layered Architecture, Fowler Patterns, Events and Messaging, Architecture Testing, or Solution Architecture rules.

## Relationship with Hexagonal Rules

Clean Architecture shares dependency and isolation principles with Hexagonal Architecture, especially around protecting core behavior from technical details and external mechanisms.

The Clean Architecture catalog does not rewrite Hexagonal Architecture rules. Hexagonal rules own concerns primarily framed around ports, adapters, and protection of the application core through inbound and outbound boundaries.

Clean Architecture rules preserve distinct responsibilities related to entities, use cases, interface adapters, frameworks and drivers, presenters, controllers, gateways, boundary data, policy direction, and flow of control.

When a Clean Architecture rule relates to a Hexagonal rule, the Clean Architecture rule must evaluate a Clean-specific responsibility rather than duplicate the full Hexagonal condition.

## Rule Ordering Principles

Rules are ordered from foundational Clean Architecture principles to more specific boundary and flow-of-control responsibilities.

The sequence begins with dependency direction and policy separation, then moves through use case isolation, entity independence, interface adapters, controllers, presenters, gateways, data mappers, boundary data structures, flow of control, and architectural intent visibility.

This order supports review consistency without making later rules procedurally dependent on earlier rules.

## Official Rules

| Rule ID | Title | Objective |
| ------- | ----- | --------- |
| CLEAN-001 | Framework types must not cross into use cases | Ensure use case boundaries remain independent from framework-specific types. |
| CLEAN-002 | Source dependencies must point toward policies | Ensure source dependencies point from technical details toward higher-level policies. |
| CLEAN-003 | Enterprise business rules must be independent from application business rules | Ensure entities are not coupled to use case orchestration or application workflow concerns. |
| CLEAN-004 | Use cases must remain isolated from delivery and infrastructure concerns | Ensure application business rules are not shaped by user interfaces, databases, frameworks, or external mechanisms. |
| CLEAN-005 | Entities must remain independent from use cases and interface adapters | Ensure enterprise business rules do not depend on application workflows or adapter concerns. |
| CLEAN-006 | Interface adapters must translate between external models and use case boundaries | Ensure adapter-facing components convert data across boundaries without exposing external models to use cases. |
| CLEAN-007 | Controllers must delegate application flow to use cases | Ensure controllers coordinate input and delegation without containing application business rules. |
| CLEAN-008 | Presenters must not contain use case or entity decisions | Ensure presenters format output without owning application or enterprise business decisions. |
| CLEAN-009 | Gateways must isolate use cases from external systems | Ensure use cases express external needs through boundary abstractions rather than concrete external mechanisms. |
| CLEAN-010 | Data mappers must not shape entities or use cases | Ensure mapping logic translates data without imposing persistence or transport structures on policies. |
| CLEAN-011 | Boundary data structures must not carry framework or adapter details | Ensure data crossing Clean Architecture boundaries is independent from frameworks, drivers, and adapter-specific models. |
| CLEAN-012 | Flow of control must cross boundaries through abstractions | Ensure runtime control flow can cross outward while source dependencies continue to point inward. |
| CLEAN-013 | Architecture must reveal use cases and business policies | Ensure the system structure makes application use cases and business policies visible as primary architectural concerns. |

## Rule Dependencies

Some rules depend conceptually on earlier rules because they reuse the same Clean Architecture vocabulary for policies, entities, use cases, interface adapters, frameworks and drivers, boundary data, and flow of control.

Rules about controllers, presenters, gateways, data mappers, and boundary data are easier to interpret after the reviewer has identified the relevant use case and policy boundaries.

These conceptual dependencies do not make one rule dependent on the execution result of another rule. Each rule remains independently selectable and independently evaluable when the reviewed material provides enough evidence for that rule.

## Catalog Stability

Rule IDs are stable once published.

New Clean Architecture rules may be added to the catalog without changing existing Rule IDs. Existing IDs must not be reused for substantially different architectural conditions.

Editorial changes may clarify titles or objectives, but changes that alter the evaluated architectural concern require a new Rule ID.
