# Rule ID

FOWLER-005

# Title

Service Layer

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether application operations are exposed through a service boundary that coordinates domain logic and transaction control.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Service Layer pattern, or when application operations appear to be exposed through a service boundary coordinating domain behavior and transaction control.

The rule is relevant when callers interact with a boundary of application operations and the reviewed scope includes enough behavior, collaborators, transaction coordination, and domain logic interaction to assess the boundary.

Do not apply this rule merely because a component is named service or exists in a layer. The Fowler catalog category for this pattern is `Domain Logic Patterns`.

# Rule Statement

A Service Layer must expose application operations through a boundary that coordinates domain logic and transaction control without absorbing domain model behavior, procedural transaction scripts, repository access semantics, or generic layer responsibilities.

# Rationale

Service Layer defines an application operation boundary for clients and coordinates work across domain logic and transactions. The risk appears when a declared Service Layer becomes a dumping ground for domain behavior, hides persistence access responsibilities, duplicates transaction scripts without a coherent boundary, or is treated as proof of layered architecture.

This rule does not require every system to use Service Layer and does not make service naming sufficient evidence.

# Evidence Required

Evaluation requires traceable evidence of application operation contracts, callers, coordination behavior, domain logic collaboration, transaction control responsibility, persistence collaboration when relevant, and tests or decisions that clarify intent.

Direct evidence may include executable implementation, method behavior, call flow, contracts, dependencies, tests, and architectural documentation tied to implementation. Naming, folders, comments, or diagrams are supporting signals only.

# Evaluation Guidance

First distinguish an actual Service Layer from naming, declared intent, equivalent operation boundary, partial implementation, legitimate composition, legitimate absence, and insufficient evidence.

Evaluate only the Fowler Service Layer responsibility: application operations exposed through a service boundary that coordinates domain logic and transaction control. Do not re-evaluate Domain Model richness, Transaction Script procedural organization, Repository access, Unit of Work change tracking, layered dependency direction, DDD services, Clean use cases, Hexagonal ports, SOLID, messaging, architecture tests, or solution structure.

Service Layer may compose with Domain Model, Transaction Script, Repository, Unit of Work, Data Mapper, Remote Facade, or DTO. Conclusions must remain independent.

# Pass Conditions

Use `Pass` when evidence shows a coherent service boundary exposing application operations and coordinating domain logic and transaction control.

Use `Pass` when an equivalent application operation boundary preserves the responsibility without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Service Layer is declared, required, or depended on, but the service boundary does not coordinate application operations as represented.

Use `Fail` when a nominal Service Layer primarily owns unrelated domain behavior, persistence gateway behavior, remote facade responsibility, or generic utilities while callers rely on Service Layer semantics.

# Warning Conditions

Use `Warning` when service operations are partial, inconsistent, overly mixed with adjacent responsibilities, or blur application coordination enough to create maintainability risk without supporting a definitive `Fail`.

# Not Applicable Conditions

Use `Not Applicable` when Service Layer is not adopted, another legitimate approach exposes operations, transaction coordination is not relevant in the reviewed scope, or no service boundary responsibility is present.

Absence of Service Layer must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the material cannot confirm service boundary behavior, transaction coordination, domain collaboration, caller expectations, or implementation intent.

Use `Not Enough Evidence` when only service naming, folder structure, comments, or documentation is available.

# Severity Guidance

Assign higher severity when a Service Layer violation affects central application operation boundaries, many callers, transaction consistency, important workflows, maintainability, or evolution.

Assign lower severity for localized, peripheral, or easily clarified issues. Do not use numeric scoring or derive severity solely from naming, category, outcome, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of service boundary behavior or violation. Use `Likely` for multiple consistent evidence points, `Possible` for limited signals, and `Not Enough Evidence` when reliable evaluation is not supported.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-002, FOWLER-003, FOWLER-011, FOWLER-020. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Service Layer.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
