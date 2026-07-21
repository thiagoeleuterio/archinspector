# Rule ID

FOWLER-007

# Title

Data Mapper

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether persistence mapping is separated from domain objects so the domain model remains independent of database access mechanics.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Data Mapper pattern, or when persistence mapping appears separated from domain objects.

The rule is relevant when the reviewed scope includes domain objects, mapping components, persistence mechanics, callers, and collaboration flow sufficient to assess separation.

Do not apply this rule merely because data access code, mapping names, database access, or domain objects exist. The Fowler catalog category for this pattern is `Data Source Architectural Patterns`.

# Rule Statement

A Data Mapper must separate persistence mapping from domain objects so the domain model remains independent of database access mechanics without becoming a Repository, gateway, Active Record, or generic layer rule.

# Rationale

Data Mapper protects domain objects from persistence mapping mechanics. The risk appears when a declared mapper leaks database access behavior into domain objects, behaves mainly as a repository or gateway, hides transaction coordination as its primary responsibility, or leaves mapping responsibilities scattered so the separation cannot be relied on.

This rule does not require Data Mapper when another legitimate pattern is used.

# Evidence Required

Evaluation requires traceable evidence of domain objects, mapper responsibility, persistence mapping behavior, caller flow, storage collaboration, and whether domain objects depend on or remain independent from database access mechanics.

Direct evidence may include executable implementation, mapping flow, dependencies, contracts, tests, and architecture decisions. Naming, folders, comments, or documentation are supporting signals only.

# Evaluation Guidance

First distinguish actual Data Mapper from Repository, Active Record, Row Data Gateway, Table Data Gateway, Unit of Work, Identity Map, nominal mapping names, equivalent separation, legitimate absence, and insufficient evidence.

Evaluate only mapper separation between domain objects and persistence mechanics. Do not evaluate Repository collection-like access, Active Record combined persistence behavior, gateway access operations, transaction coordination, layer dependency direction, DDD, Clean, Hexagonal, SOLID, messaging, architecture testing, or solution structure.

Data Mapper may collaborate with Repository, Unit of Work, Identity Map, Lazy Load, Identity Field, and Foreign Key Mapping. Shared evidence must not merge responsibilities.

# Pass Conditions

Use `Pass` when evidence shows that persistence mapping is separated from domain objects and the domain model remains independent of database access mechanics.

Use `Pass` for equivalent mapping separation without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Data Mapper is declared, required, or depended on, but persistence mapping is not separated from domain objects with relevant architectural impact.

Use `Fail` when a nominal mapper primarily behaves as Repository, gateway, Active Record, Unit of Work, or unrelated persistence utility while callers rely on Data Mapper separation.

# Warning Conditions

Use `Warning` when mapping separation is partial, inconsistent, blurred, or mixed with adjacent responsibilities but direct evidence does not justify `Fail`.

# Not Applicable Conditions

Use `Not Applicable` when Data Mapper is not adopted, another legitimate data source pattern is used, the reviewed scope lacks domain objects or persistence mapping, or the component is irrelevant.

Absence of Data Mapper must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the material cannot confirm mapping behavior, domain object independence, persistence mechanics, caller flow, or collaborator responsibilities.

Use `Not Enough Evidence` when only names, folders, comments, documentation, or isolated structural hints are available.

# Severity Guidance

Assign higher severity when a Data Mapper violation affects central domain object independence, broad persistence flows, many mapped objects, maintainability, consistency, or evolution.

Assign lower severity when the issue is localized, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of mapping separation or leakage. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-001, FOWLER-006, FOWLER-010, FOWLER-011, FOWLER-012. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Data Mapper.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
