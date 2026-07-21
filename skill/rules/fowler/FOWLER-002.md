# Rule ID

FOWLER-002

# Title

Transaction Script

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether business logic is organized as procedural transactions that coordinate validation, calculation, and persistence for a request.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Transaction Script pattern, or when request handling appears to organize business behavior as procedural transaction operations.

The rule is relevant when a unit of work for a request coordinates validation, calculation, state changes, and persistence flow directly in a procedural operation. It may also apply to an equivalent implementation without Transaction Script naming when the reviewed evidence shows the same responsibility.

Do not apply this rule merely because a system has services, handlers, procedures, application operations, or simple methods. The Fowler catalog category for this pattern is `Domain Logic Patterns`.

# Rule Statement

A Transaction Script must organize business logic as procedural transaction operations for requests without being mistaken for a domain object model, service boundary, persistence gateway, mapper, or generic layer rule.

# Rationale

Transaction Script is useful when business behavior is naturally expressed as request-centered procedures. The architectural risk appears when a system declares or relies on this pattern but scatters the transaction responsibility, hides domain behavior behind misleading objects, mixes persistence mechanics into unrelated responsibilities, or accidentally combines several domain logic styles without a clear boundary.

This rule does not require Transaction Script. It evaluates the pattern only when evidence indicates adoption, intent, dependency, or an equivalent procedural transaction responsibility.

# Evidence Required

Evaluation requires traceable evidence of the request operation, the business logic it coordinates, caller flow, validation or calculation behavior, persistence collaboration, and transaction boundary when relevant.

Direct evidence may include executable implementation, method behavior, call flow, contracts, tests that demonstrate request behavior, collaborator responsibilities, and architectural decisions. Naming, directory structure, comments, or documentation are supporting signals only and must not by themselves produce `Confirmed` confidence.

# Evaluation Guidance

First determine whether Transaction Script is present, intended, equivalent, partial, mixed, legitimately absent, or unsupported by evidence. Evaluate only procedural organization of business logic for request transactions.

Do not use this rule to evaluate Domain Model richness, Service Layer boundaries, Repository access, Data Mapper separation, Unit of Work coordination, layer dependency direction, DDD tactical modeling, Clean Architecture use cases, Hexagonal ports, SOLID principles, messaging behavior, architecture tests, or solution structure.

Recognize legitimate composition with Service Layer, Repository, Data Mapper, Unit of Work, and other patterns when each keeps its own responsibility. Shared evidence may be considered, but conclusions must remain anchored to Transaction Script.

# Pass Conditions

Use `Pass` when evidence shows that business behavior for a request is coherently organized as procedural transaction logic and the pattern's central responsibility is preserved.

Use `Pass` for equivalent implementations when request-centered procedural coordination is clear even without exact pattern naming.

# Fail Conditions

Use `Fail` when direct evidence shows that Transaction Script is declared, required, or depended on, but the request transaction responsibility is architecturally violated.

Use `Fail` when procedural transaction logic is misleadingly represented while essential validation, calculation, persistence coordination, or request behavior is fragmented across unrelated responsibilities with relevant architectural impact.

# Warning Conditions

Use `Warning` when evidence shows partial, inconsistent, duplicated, or mixed transaction scripts that weaken the procedural transaction boundary but do not justify `Fail`.

Use `Warning` when Transaction Script is blended with Domain Model, Service Layer, gateway, mapper, or transaction coordination responsibilities in a way that creates localized ambiguity.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed system does not adopt Transaction Script, when another legitimate domain logic pattern solves the responsibility, when the reviewed scope has no relevant request transaction logic, or when the component is irrelevant.

Absence of Transaction Script must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when Transaction Script may be relevant but implementation, caller flow, behavior, collaborators, tests, or decisions are insufficient to determine presence or conformance.

Use `Not Enough Evidence` when only names, folders, comments, or documentation suggest procedural transactions, or when the material cannot distinguish Transaction Script from Domain Model, Service Layer, Repository, gateway, mapper, or Unit of Work responsibilities.

# Severity Guidance

Assign higher severity when a violated Transaction Script responsibility affects central request behavior, important workflows, broad caller usage, transaction consistency, maintainability, or evolution.

Assign lower severity when the issue is narrow, local, easily clarified, or has limited architectural dependency. Do not use numeric scoring or derive severity solely from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of procedural request transaction behavior or violation. Use `Likely` for multiple consistent signals with incomplete confirmation. Use `Possible` for limited or indirect signals. Use `Not Enough Evidence` when the material cannot support a reliable conclusion.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-003, FOWLER-005. These are related domain logic boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Transaction Script.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
