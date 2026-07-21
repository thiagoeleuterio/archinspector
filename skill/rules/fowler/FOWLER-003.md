# Rule ID

FOWLER-003

# Title

Domain Model

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether business behavior is represented by an object model that combines state and behavior around domain concepts.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Domain Model pattern, or when business behavior appears to be represented through objects that combine state and behavior around domain concepts.

The rule is relevant when the reviewed scope includes domain-facing objects, behavior, collaborations, and callers sufficient to assess whether business behavior lives in the object model. Equivalent implementations may be evaluated without exact naming when the central responsibility is present.

Do not apply this rule merely because a system has data objects, entities, records, services, namespaces, or a layer named domain. The Fowler catalog category for this pattern is `Domain Logic Patterns`.

# Rule Statement

A Domain Model must represent business behavior through an object model that combines state and behavior around domain concepts without reducing the pattern to naming, data structures, or DDD-specific tactical requirements.

# Rationale

Domain Model protects complex business behavior by placing meaningful behavior with the objects and collaborations that represent the domain. The risk appears when a declared or depended-on Domain Model is only a passive data structure, when business behavior is displaced into unrelated procedural code, or when object responsibilities are mixed so heavily that the model no longer carries the intended domain behavior.

This rule does not require every system to use Domain Model and does not require Domain-Driven Design constructs.

# Evidence Required

Evaluation requires traceable evidence about domain objects, state, business behavior, collaborations, caller usage, and where validation, calculations, invariants, or state transitions are decided.

Direct evidence may include executable behavior, method bodies, object collaboration flow, contracts, tests that demonstrate business behavior, dependency relationships, and architectural decisions. Naming, folders, comments, diagrams, or documentation are supporting signals only.

# Evaluation Guidance

First distinguish a present Domain Model from declared intent, nominal data objects, partial behavior, equivalent object model behavior, legitimate variation, legitimate absence, and insufficient evidence.

Evaluate only the Fowler Domain Model responsibility: an object model combining state and behavior around domain concepts. Do not evaluate Service Layer orchestration, Transaction Script procedural flow, Active Record persistence operations, Data Mapper separation, Repository access, layer dependency direction, Clean Architecture entities, Hexagonal ports, SOLID principles, messaging, architecture testing, or solution structure.

Domain Model may compose with Repository, Data Mapper, Unit of Work, Identity Map, Lazy Load, Identity Field, Foreign Key Mapping, or Service Layer. These relationships must not merge the evaluated responsibilities.

# Pass Conditions

Use `Pass` when evidence shows that business behavior is represented coherently by an object model combining state and behavior around domain concepts.

Use `Pass` when an equivalent object collaboration model preserves the responsibility without using the exact pattern name.

# Fail Conditions

Use `Fail` when direct evidence shows that Domain Model is declared, required, or depended on, but the object model does not carry the business behavior it is expected to own.

Use `Fail` when business behavior is systematically displaced into procedural transaction logic, service orchestration, persistence components, or passive data structures while the architecture relies on Domain Model semantics.

# Warning Conditions

Use `Warning` for partial, anemic, inconsistent, or blurred Domain Model implementations when evidence indicates architectural risk but not enough direct support for `Fail`.

Use `Warning` when behavior is split between objects and adjacent procedural or service components in a limited way that weakens model responsibility.

# Not Applicable Conditions

Use `Not Applicable` when the system does not adopt Domain Model, when a legitimate Transaction Script or Table Module approach is used instead, when the reviewed problem does not require object-modeled business behavior, or when the component is irrelevant.

Absence of Domain Model must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the material cannot confirm domain object behavior, caller usage, state transitions, collaborators, or the intended responsibility.

Use `Not Enough Evidence` when only names, folders, documentation, or passive structures are available, or when behavior cannot be distinguished from Transaction Script, Service Layer, Active Record, Data Mapper, or Repository responsibilities.

# Severity Guidance

Assign higher severity when a violated Domain Model responsibility affects central business behavior, complex invariants, broad workflows, many domain-facing objects, maintainability, consistency, or evolution.

Assign lower severity when the issue is localized, peripheral, easily clarified, or limited to weak Domain Model intent. Do not use numeric scoring or automatic severity by outcome.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of object state and business behavior placement or violation. Use `Likely` for multiple consistent evidence points. Use `Possible` for limited signals. Use `Not Enough Evidence` when reliable evaluation is not supported.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-002, FOWLER-004, FOWLER-005, FOWLER-006, FOWLER-007. These are related boundaries, not required prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Domain Model.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
