# Rule ID

FOWLER-004

# Title

Table Module

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether business logic is organized around one class per database table or view rather than around individual domain objects.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Table Module pattern, or when business logic appears to be organized around a table or view rather than individual domain objects.

The rule is relevant when a component represents behavior for a table-shaped data set and the reviewed scope includes enough behavior, data shape, caller flow, and persistence collaboration to assess the responsibility.

Do not apply this rule merely because tables, views, modules, datasets, or data access components exist. The Fowler catalog category for this pattern is `Domain Logic Patterns`.

# Rule Statement

A Table Module must organize business logic around one table or view shaped responsibility without being reduced to generic table access, row access, persistence mapping, or object-domain behavior.

# Rationale

Table Module centralizes business behavior for table-oriented data when the system works naturally with record sets rather than individual domain objects. The risk appears when a declared Table Module becomes only a gateway, hides unrelated persistence mechanics, splits table-level behavior across inconsistent components, or is confused with Domain Model, Active Record, Row Data Gateway, or Table Data Gateway responsibilities.

This rule does not require Table Module where another legitimate domain logic pattern is used.

# Evidence Required

Evaluation requires traceable evidence of the table or view responsibility, business logic associated with that table-shaped data, callers, data access collaboration, and whether behavior is table-level rather than row-object or domain-object behavior.

Direct evidence may include executable implementation, method behavior, data set handling flow, tests, contracts, dependencies, and architectural decisions. Naming and documentation are supporting signals only.

# Evaluation Guidance

First determine whether Table Module is present, intended, equivalent, partial, mixed, legitimately absent, or unsupported. Evaluate only table-or-view-centered business logic.

Do not evaluate Table Data Gateway access operations, Row Data Gateway row operations, Domain Model object behavior, Transaction Script request procedures, Active Record persistence operations, layer boundaries, DDD, Clean, Hexagonal, SOLID, messaging, tests as a requirement, or solution structure.

Table Module may collaborate with gateways, mappers, or transaction coordination. Such composition is legitimate only when the Table Module responsibility remains distinct.

# Pass Conditions

Use `Pass` when evidence shows that business logic is coherently organized around one table or view shaped module and the central responsibility is preserved.

Use `Pass` for equivalent table-oriented business modules even when the exact name is absent.

# Fail Conditions

Use `Fail` when direct evidence shows Table Module is declared, required, or depended on, but its table-level business behavior responsibility is violated with relevant architectural impact.

Use `Fail` when a nominal Table Module is only a persistence gateway, row wrapper, mapper, service workflow, or unrelated utility while callers rely on Table Module semantics.

# Warning Conditions

Use `Warning` when table-level business behavior is partial, duplicated, mixed with gateway or row responsibilities, or inconsistently distributed without enough direct evidence for `Fail`.

# Not Applicable Conditions

Use `Not Applicable` when Table Module is not adopted, another legitimate domain logic pattern is used, no table-shaped business responsibility exists in scope, or the reviewed component is irrelevant.

Absence of Table Module must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the material cannot confirm table-level business behavior, table or view responsibility, caller expectations, collaborators, or whether observed code is merely data access.

Use `Not Enough Evidence` when only names, folders, comments, or documentation suggest Table Module.

# Severity Guidance

Assign higher severity when a Table Module violation affects central table-oriented business behavior, broad workflows, repeated modules, data consistency, maintainability, or future evolution.

Assign lower severity when the issue is isolated, peripheral, or easily clarified. Do not use numeric scoring or severity solely from naming, category, outcome, or absence.

# Confidence Guidance

Use `Confirmed` only with direct evidence of table-oriented business behavior or its violation. Use `Likely` for multiple consistent signals, `Possible` for limited signals, and `Not Enough Evidence` when evaluation cannot be supported.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-003, FOWLER-008, FOWLER-009. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Table Module.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
