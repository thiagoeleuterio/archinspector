# Rule Taxonomy

## Purpose

This document defines the official taxonomy for the ArchInspector rule catalog.

The taxonomy defines the approved rule categories, their responsibilities, their boundaries, and the conventions used to classify rules consistently over time.

This document does not define architectural rules, knowledge content, examples, evaluation assets, scoring, report templates, or concrete rule identifiers.

## Scope

The rule taxonomy is limited to the supported review areas defined in the ArchInspector master instructions.

The official rule categories are:

- Hexagonal Architecture
- Clean Architecture
- Domain-Driven Design
- SOLID
- Layered Architecture
- Fowler Patterns
- Events and Messaging
- Architecture Testing
- Solution Architecture

The catalog of supported review areas is closed. This taxonomy must not add, rename, remove, merge, or split supported review areas.

## Official Rule Categories

Each category defines the architectural area that owns a rule.

A category is responsible for grouping rules that evaluate the same kind of architectural concern. It is not responsible for defining findings, recommendations, examples, knowledge explanations, scoring formulas, or project-specific interpretations.

Category ownership must be based on the primary architectural concern evaluated by the rule, not on incidental terminology, implementation details, or where a violation happens to appear in a reviewed system.

## Hexagonal Architecture

### Official Name

Hexagonal Architecture

### Official Prefix

HEX

### Purpose

Rules in this category evaluate whether a system protects application and domain behavior from infrastructure, delivery mechanisms, and external systems through explicit ports, adapters, and dependency direction.

### Scope

This category covers architectural concerns related to ports, adapters, inbound boundaries, outbound boundaries, dependency direction, isolation from frameworks, and separation between core behavior and technical integration code.

### When to Use

Use this category when the rule primarily evaluates whether external actors, infrastructure dependencies, persistence mechanisms, messaging systems, or user interface mechanisms interact with the application through appropriate boundary abstractions.

Use this category when the main concern is the direction and shape of dependencies between the application core and adapters.

### When Not to Use

Do not use this category when the primary concern is use case orchestration, enterprise policy separation, or dependency rules specific to Clean Architecture.

Do not use this category when the rule primarily evaluates domain modeling, SOLID design principles, layered dependency constraints, messaging semantics, testing strategy, or solution-level structure.

### Relation With Other Categories

Hexagonal Architecture overlaps conceptually with Clean Architecture and Layered Architecture because all three address boundaries and dependencies. Classify a rule here only when ports, adapters, and protection of the core from external mechanisms are the primary evaluation concern.

If the rule evaluates use case boundaries or policy direction, prefer Clean Architecture. If the rule evaluates conventional presentation, application, domain, and infrastructure layer constraints, prefer Layered Architecture.

## Clean Architecture

### Official Name

Clean Architecture

### Official Prefix

CLEAN

### Purpose

Rules in this category evaluate whether source dependencies, policy boundaries, and application use cases follow Clean Architecture principles.

### Scope

This category covers architectural concerns related to entities, use cases, interface adapters, frameworks, dependency direction toward higher-level policies, and separation between business rules and technical details.

### When to Use

Use this category when the rule primarily evaluates dependency direction across Clean Architecture rings or boundaries.

Use this category when the main concern is whether business rules and use cases are independent from frameworks, databases, user interfaces, or delivery mechanisms.

### When Not to Use

Do not use this category when the rule is specifically about ports and adapters as the primary abstraction model.

Do not use this category when the rule primarily evaluates domain language, aggregates, SOLID principles, messaging behavior, testing architecture, or solution-level organization.

### Relation With Other Categories

Clean Architecture is related to Hexagonal Architecture because both protect core behavior from technical details. Classify a rule here when the evaluation is framed around policy direction, use cases, entities, and framework independence.

If the rule evaluates a general layer dependency in a conventional layered system, prefer Layered Architecture.

## Domain-Driven Design

### Official Name

Domain-Driven Design

### Official Prefix

DDD

### Purpose

Rules in this category evaluate whether domain concepts, boundaries, and models preserve domain meaning and support evidence-based reasoning about business behavior.

### Scope

This category covers architectural concerns related to domain models, aggregates, entities, value objects, bounded contexts, ubiquitous language, domain services, repositories as domain-facing abstractions, and separation of domain behavior from technical concerns.

### When to Use

Use this category when the rule primarily evaluates the modeling of business concepts or the preservation of domain boundaries.

Use this category when the main concern is whether code structure and behavior reflect domain meaning rather than technical organization alone.

### When Not to Use

Do not use this category when the rule primarily evaluates generic dependency direction, adapter boundaries, SOLID object design, messaging infrastructure, testing architecture, or solution packaging.

Do not classify a rule here only because it mentions entities, services, or repositories if the primary concern is not domain modeling or domain boundary integrity.

### Relation With Other Categories

Domain-Driven Design may interact with Clean Architecture, Hexagonal Architecture, and Layered Architecture when domain code is protected by architectural boundaries. Classify a rule here only when the domain model or bounded context is the primary concern.

If the rule evaluates how technical dependencies point toward or away from domain code, the owning category may be Clean Architecture, Hexagonal Architecture, or Layered Architecture depending on the architectural framing.

## SOLID

### Official Name

SOLID

### Official Prefix

SOLID

### Purpose

Rules in this category evaluate object-oriented design principles that affect architectural maintainability, substitutability, extensibility, dependency management, and responsibility boundaries.

### Scope

This category covers concerns related to single responsibility, open/closed design, substitutability, interface segregation, dependency inversion, abstractions, and coupling at type or component boundaries when those concerns have architectural relevance.

### When to Use

Use this category when the rule primarily evaluates a SOLID principle and its architectural impact.

Use this category when the concern is local or component-level design quality that affects broader architecture through coupling, volatility, dependency direction, or change isolation.

### When Not to Use

Do not use this category when the rule primarily evaluates a named architecture style, domain modeling pattern, messaging architecture, test architecture, or solution structure.

Do not classify a rule here only because dependency inversion appears in the implementation if the primary concern is a Clean Architecture, Hexagonal Architecture, or Layered Architecture boundary.

### Relation With Other Categories

SOLID rules may support other architectural categories, especially when dependency inversion or responsibility separation helps enforce architectural boundaries. Classify a rule here only when the SOLID principle itself is the primary condition being evaluated.

If the rule evaluates an architectural boundary rather than an object-oriented design principle, prefer the category that owns that boundary.

## Layered Architecture

### Official Name

Layered Architecture

### Official Prefix

LAYER

### Purpose

Rules in this category evaluate whether responsibilities and dependencies across architectural layers remain consistent with the selected layered structure.

### Scope

This category covers concerns related to presentation, application, domain, infrastructure, persistence, service, and other explicitly identified layers; allowed dependency direction; layer bypassing; cross-layer coupling; and responsibility placement within layers.

### When to Use

Use this category when the rule primarily evaluates layer responsibility or dependency constraints between layers.

Use this category when the reviewed system is organized around layers and the rule checks whether those layers are respected within the available evidence.

### When Not to Use

Do not use this category when the primary concern is ports and adapters, Clean Architecture policy rings, domain model integrity, SOLID design principles, messaging behavior, testing strategy, or solution-level repository organization.

Do not classify a rule here only because a violation appears inside a layer. The rule belongs here only when the layer boundary or responsibility is the primary evaluation concern.

### Relation With Other Categories

Layered Architecture is related to Clean Architecture and Hexagonal Architecture through dependency management and separation of concerns. Classify a rule here when the architectural framing is layers and layer responsibilities.

If the rule evaluates core isolation through ports and adapters, prefer Hexagonal Architecture. If it evaluates policy direction and use case boundaries, prefer Clean Architecture.

## Fowler Patterns

### Official Name

Fowler Patterns

### Official Prefix

FOWLER

### Purpose

Rules in this category evaluate architecture and enterprise application patterns associated with Martin Fowler's pattern catalog when those patterns are relevant to the reviewed system.

### Scope

This category covers concerns related to recognized Fowler patterns, their responsibilities, their boundaries, their intended trade-offs, and the risks of inconsistent or partial pattern application.

### When to Use

Use this category when the rule primarily evaluates whether a Fowler pattern is present, applied consistently, or used within its intended architectural boundary.

Use this category when the main concern is the responsibility or interaction model defined by a Fowler pattern rather than a broader architecture style.

### When Not to Use

Do not use this category when the rule primarily evaluates Clean Architecture, Hexagonal Architecture, Layered Architecture, Domain-Driven Design, SOLID, messaging architecture, testing architecture, or solution structure.

Do not classify a rule here only because a Fowler pattern could be mentioned as background knowledge. The pattern itself must be the primary evaluation concern.

### Relation With Other Categories

Fowler Patterns may appear inside layered, clean, hexagonal, or domain-driven systems. Classify a rule here only when the pattern responsibility is the rule owner.

If the rule evaluates an architectural style boundary instead of the pattern's own responsibility, prefer the architecture style category.

## Events and Messaging

### Official Name

Events and Messaging

### Official Prefix

MSG

### Purpose

Rules in this category evaluate architectural concerns related to events, messages, asynchronous communication, integration flows, and message-driven boundaries.

### Scope

This category covers concerns related to domain events, integration events, commands, message handlers, publishers, subscribers, brokers, queues, topics, idempotency, delivery assumptions, coupling through messages, and consistency boundaries.

### When to Use

Use this category when the rule primarily evaluates communication through events or messages.

Use this category when the main concern is message semantics, message ownership, asynchronous boundaries, or architectural risks introduced by messaging.

### When Not to Use

Do not use this category when the rule primarily evaluates application boundaries, domain modeling, SOLID design principles, layer dependencies, test strategy, or solution structure.

Do not classify a rule here only because messaging technology appears as infrastructure for a Hexagonal Architecture adapter or Clean Architecture interface adapter. In that case, classify by the primary concern.

### Relation With Other Categories

Events and Messaging may interact with Hexagonal Architecture, Clean Architecture, Domain-Driven Design, and Solution Architecture. Classify a rule here when the message or event communication model is the primary concern.

If the rule evaluates adapter isolation around a broker, prefer Hexagonal Architecture. If it evaluates domain meaning of events, prefer Domain-Driven Design.

## Architecture Testing

### Official Name

Architecture Testing

### Official Prefix

TEST

### Purpose

Rules in this category evaluate whether architectural assumptions, boundaries, and constraints are supported by tests or test-like verification mechanisms.

### Scope

This category covers concerns related to architecture tests, boundary tests, dependency tests, contract tests, approval of architectural constraints, and test coverage for architectural rules or invariants.

### When to Use

Use this category when the rule primarily evaluates verification of architecture rather than the architecture condition itself.

Use this category when the main concern is whether a boundary, dependency rule, or architectural constraint is protected by tests or automated checks.

### When Not to Use

Do not use this category when the rule evaluates the boundary or dependency rule directly. In that case, classify the rule under the category that owns the architectural condition.

Do not classify a rule here only because tests are used as evidence. Tests can provide evidence for any category.

### Relation With Other Categories

Architecture Testing can verify constraints from any other category. Classify a rule here only when the existence, scope, reliability, or adequacy of architectural verification is the primary evaluation concern.

If a rule evaluates both a boundary and its test coverage, it must be split or classified by the primary concern. A rule in this category should not become a duplicate of the underlying architectural rule.

## Solution Architecture

### Official Name

Solution Architecture

### Official Prefix

SOLN

### Purpose

Rules in this category evaluate solution-level organization, project composition, dependency structure, deployment-relevant boundaries, and cross-cutting architectural consistency across the reviewed material.

### Scope

This category covers concerns related to solution structure, project boundaries, module ownership, dependency graphs, package organization, cross-cutting dependencies, configuration placement, and high-level architectural consistency across projects or modules.

### When to Use

Use this category when the rule primarily evaluates the architecture of the solution as a whole rather than a specific architectural style or local design principle.

Use this category when the main concern is project or module organization, dependency topology, or cross-cutting consistency visible at solution level.

### When Not to Use

Do not use this category when the rule primarily evaluates Hexagonal Architecture, Clean Architecture, Domain-Driven Design, SOLID, Layered Architecture, Fowler patterns, messaging, or architecture testing.

Do not classify a rule here only because the evidence is collected from project files or solution files. Evidence location does not determine category ownership.

### Relation With Other Categories

Solution Architecture provides the broadest structural view and may supply evidence for all other categories. Classify a rule here only when the solution-level structure is the primary concern.

If a rule evaluates a specific architecture style using solution-level evidence, classify it under that architecture style instead.

## Category Independence

Each Rule belongs to exactly one category.

A Rule must have one owning category even when its evaluation affects or references multiple architectural areas. The owning category is the category that best represents the primary architectural condition being evaluated.

Related categories may be mentioned in rationale, guidance, dependencies, or references when useful, but those relationships do not create shared ownership.

If a proposed Rule cannot be assigned to one category without ambiguity, its evaluated condition is probably too broad. The Rule should be narrowed, split, or rewritten before entering the catalog.

## Prefix Conventions

Rule ID prefixes identify the owning category of a Rule.

Each Rule ID must use the official prefix of its category followed by the catalog sequence format defined in the rule specification.

The prefix must not be selected for readability, familiarity, severity, implementation technology, or expected report grouping. It must reflect category ownership only.

Sequence numbers are scoped to the category prefix. A sequence number has no meaning outside its prefix and must not imply priority, maturity, severity, or evaluation order.

Changing the category of a published Rule changes its identity. If a published Rule was assigned to the wrong category and the correction changes the Rule ID, the catalog must preserve traceability according to the rule lifecycle and stability principles.

## Classification Principles

Classify a Rule by the primary architectural concern it evaluates.

Use the following principles when assigning a category:

- Prefer the category that owns the normative condition of the Rule.
- Do not classify by where evidence is found.
- Do not classify by technology names, framework names, or implementation details unless they define the architectural concern.
- Do not classify by the category most likely to produce a finding.
- Do not classify by the recommendation that may follow from a finding.
- Do not classify by secondary concepts mentioned in rationale or evidence guidance.
- Use the narrowest supported category that fully owns the evaluated condition.
- Keep architecture testing separate from the underlying architectural condition being tested.
- Use Solution Architecture only when the primary concern is solution-level organization or cross-project structure.
- Prefer `Not Enough Evidence` during review when category applicability cannot be supported by reviewed material.

A Rule should be rewritten before publication if its statement evaluates multiple unrelated conditions, depends on more than one owning category, or cannot produce a single category without relying on subjective preference.

## Consistency Rules

The rule catalog must remain consistent over time.

To preserve consistency:

- Categories must remain aligned with the supported review areas.
- Category names and prefixes must remain stable after publication.
- New Rules must use only approved categories and prefixes.
- Rules within the same category must use consistent terminology for the same concepts.
- Rules must avoid duplicate ownership of the same architectural condition.
- Related Rules must define distinct evaluation boundaries.
- Rule classification must be based on the Rule statement and evaluation intent.
- Editorial changes must not change a Rule's category unless the original classification was incorrect.
- Substantial changes to a Rule's meaning, scope, or category require a new Rule identity.
- A category must not become a container for examples, knowledge, scoring, templates, or review output.

When two categories appear to overlap, the catalog maintainer must identify the primary evaluated condition and assign the Rule to one category only. If no single primary condition can be identified, the proposed Rule is not atomic enough for the catalog.
