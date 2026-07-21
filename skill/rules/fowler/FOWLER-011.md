# Rule ID

FOWLER-011

# Title

Unit of Work

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether changes to objects are tracked and coordinated as a single persistence transaction.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Unit of Work pattern, or when object changes appear to be tracked and committed as a coordinated persistence transaction.

The rule is relevant when changed objects, transaction boundaries, commit behavior, callers, and persistence collaborators can be inspected.

Do not apply this rule merely because transactions, saves, sessions, or persistence components exist. The Fowler catalog category for this pattern is `Object-Relational Behavioral Patterns`.

# Rule Statement

A Unit of Work must track object changes and coordinate them as a single persistence transaction without being reduced to Repository access, Data Mapper mapping, Identity Map identity tracking, Service Layer orchestration, or generic transaction usage.

# Rationale

Unit of Work coordinates changed objects so persistence can be completed consistently. The risk appears when a declared Unit of Work does not track relevant changes, commits partial or unrelated work, hides mapper or repository responsibilities, or makes transaction scope unreliable for callers.

This rule does not require Unit of Work.

# Evidence Required

Evaluation requires traceable evidence of object change tracking, transaction scope, commit or rollback coordination when present, caller usage, persistence collaborators, and lifecycle.

Direct evidence may include executable behavior, call flow, contracts, tests, dependencies, and architecture decisions. Naming and documentation are supporting signals only.

# Evaluation Guidance

First distinguish Unit of Work from generic transaction wrappers, Repository, Data Mapper, Identity Map, Service Layer, Active Record, equivalent change coordination, legitimate absence, and insufficient evidence.

Evaluate only change tracking and coordinated persistence transaction responsibility. Do not evaluate service operation boundaries, collection-like access, mapping separation, identity caching, layer dependency direction, DDD, Clean, Hexagonal, SOLID, messaging, architecture testing, or solution structure.

# Pass Conditions

Use `Pass` when evidence shows object changes are tracked and coordinated as a coherent single persistence transaction.

Use `Pass` for equivalent change coordination without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Unit of Work is declared, required, or depended on, but change tracking or transaction coordination is violated with relevant architectural impact.

Use `Fail` when a nominal Unit of Work primarily behaves as repository, mapper, identity map, service orchestration, or unrelated transaction utility while callers rely on Unit of Work semantics.

# Warning Conditions

Use `Warning` when change tracking or transaction coordination is partial, inconsistently scoped, mixed with adjacent responsibilities, or ambiguous enough to create risk.

# Not Applicable Conditions

Use `Not Applicable` when Unit of Work is not adopted, coordinated object persistence is not relevant, another legitimate approach is used, or no changed-object transaction responsibility exists in scope.

Absence of Unit of Work must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when change tracking, transaction scope, commit behavior, caller expectations, lifecycle, or collaborators cannot be confirmed.

Use `Not Enough Evidence` when only names, folders, comments, documentation, or isolated transaction references are available.

# Severity Guidance

Assign higher severity when a Unit of Work violation affects central consistency, important workflows, many changed objects, broad persistence paths, maintainability, or evolution.

Assign lower severity when isolated, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of change tracking and coordinated persistence behavior or violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-001, FOWLER-007, FOWLER-010, FOWLER-005. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Unit of Work.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
