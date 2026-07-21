# Rule ID

FOWLER-009

# Title

Table Data Gateway

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether one object provides access operations for all rows in a database table or view.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Table Data Gateway pattern, or when one object appears to provide access operations for all rows in a table or view.

The rule is relevant when table-wide access behavior, callers, data shape, persistence collaboration, and contracts can be inspected.

Do not apply this rule merely because a table, view, gateway name, or data access object exists. The Fowler catalog category for this pattern is `Data Source Architectural Patterns`.

# Rule Statement

A Table Data Gateway must provide access operations for all rows in one table or view without being confused with Table Module business logic, Row Data Gateway row access, Data Mapper mapping, Repository collection semantics, or generic persistence access.

# Rationale

Table Data Gateway centralizes table-wide data access. The risk appears when a declared table gateway owns business logic, behaves as a row object, hides mapping or repository responsibilities, or fails to provide the table-wide access responsibility callers rely on.

This rule does not require Table Data Gateway.

# Evidence Required

Evaluation requires traceable evidence of the table or view responsibility, access operations for all rows, caller usage, data access flow, contracts, tests, and collaborator responsibilities.

Direct implementation and behavior are strongest. Naming, folders, comments, or documentation are supporting signals only.

# Evaluation Guidance

First distinguish Table Data Gateway from Row Data Gateway, Table Module, Data Mapper, Repository, Active Record, equivalent table-wide access, legitimate absence, and insufficient evidence.

Evaluate only table-or-view-wide access operations. Do not evaluate table-centered business logic, row object behavior, object mapping separation, domain modeling, layer direction, DDD, Clean, Hexagonal, SOLID, messaging, architecture testing, or solution structure.

# Pass Conditions

Use `Pass` when evidence shows one object coherently provides access operations for all rows in a table or view.

Use `Pass` for equivalent table-wide gateway behavior without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Table Data Gateway is declared, required, or depended on, but the implementation violates table-wide access responsibility with relevant architectural impact.

Use `Fail` when a nominal table gateway primarily behaves as table business logic, single-row access, mapper, repository, active record, or unrelated persistence utility.

# Warning Conditions

Use `Warning` when table gateway behavior is partial, inconsistent, mixed with adjacent responsibilities, or ambiguous enough to weaken the boundary.

# Not Applicable Conditions

Use `Not Applicable` when Table Data Gateway is not adopted, another legitimate access pattern is used, no table-wide access responsibility exists in scope, or the component is irrelevant.

Absence of Table Data Gateway must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when table-wide access behavior, caller usage, data shape, contracts, or collaborators cannot be confirmed.

Use `Not Enough Evidence` when only names, folders, comments, documentation, or isolated table references are available.

# Severity Guidance

Assign higher severity when a Table Data Gateway violation affects central data access, many callers, broad workflows, consistency, maintainability, or evolution.

Assign lower severity when isolated, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of table-wide access responsibility or violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-004, FOWLER-007, FOWLER-008. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Table Data Gateway.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
