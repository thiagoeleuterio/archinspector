# Rule ID

FOWLER-008

# Title

Row Data Gateway

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether one object represents a single database row and provides access operations for that row.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Row Data Gateway pattern, or when an object appears to represent one row and provide access operations for that row.

The rule is relevant when the reviewed scope includes row identity, row data, row access behavior, callers, and persistence collaboration sufficient to assess the responsibility.

Do not apply this rule merely because row data, records, tables, or data access methods exist. The Fowler catalog category for this pattern is `Data Source Architectural Patterns`.

# Rule Statement

A Row Data Gateway must represent a single database row and provide access operations for that row without absorbing Table Data Gateway, Active Record, Data Mapper, Repository, or domain logic responsibilities.

# Rationale

Row Data Gateway isolates access behavior for one row-shaped record. The risk appears when a declared row gateway is actually table-wide access, domain behavior, mapper separation, active record behavior, or generic persistence logic, creating misleading boundaries for callers.

This rule does not require Row Data Gateway.

# Evidence Required

Evaluation requires traceable evidence of a single-row responsibility, row identity, access operations for that row, caller usage, and persistence collaboration.

Direct evidence may include executable implementation, row access flow, contracts, dependencies, tests, and architecture decisions. Naming, folders, comments, or documentation are supporting signals only.

# Evaluation Guidance

First distinguish actual Row Data Gateway from Table Data Gateway, Active Record, Data Mapper, Repository, Table Module, equivalent row access, legitimate absence, and insufficient evidence.

Evaluate only single-row access responsibility. Do not evaluate table-wide gateway operations, domain behavior, mapper separation, repository collection semantics, layer boundaries, DDD, Clean, Hexagonal, SOLID, messaging, architecture testing, or solution structure.

# Pass Conditions

Use `Pass` when evidence shows that one object represents a single row and provides coherent access operations for that row.

Use `Pass` for equivalent row gateway behavior without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Row Data Gateway is declared, required, or depended on, but the object does not preserve single-row access responsibility with relevant architectural impact.

Use `Fail` when a nominal row gateway primarily provides table-wide access, domain model behavior, mapper behavior, repository access, or unrelated persistence behavior.

# Warning Conditions

Use `Warning` when row gateway behavior is partial, inconsistent, mixed with table-wide or domain responsibilities, or ambiguous enough to create maintainability risk.

# Not Applicable Conditions

Use `Not Applicable` when Row Data Gateway is not adopted, another legitimate access pattern is used, no single-row access responsibility exists in scope, or the component is irrelevant.

Absence of Row Data Gateway must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when row responsibility, access behavior, caller usage, identity, or collaborators cannot be confirmed.

Use `Not Enough Evidence` when only naming, folders, comments, documentation, or isolated row-shaped data is available.

# Severity Guidance

Assign higher severity when a Row Data Gateway violation affects central row access, broad persistence workflows, consistency, maintainability, or evolution.

Assign lower severity when isolated, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of single-row access responsibility or violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-004, FOWLER-006, FOWLER-007, FOWLER-009. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Row Data Gateway.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
