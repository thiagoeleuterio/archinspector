# Rule ID

FOWLER-006

# Title

Active Record

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether objects combine domain data, domain behavior, and persistence operations for rows in a database table or view.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Active Record pattern, or when objects appear to combine row-shaped data, domain behavior, and persistence operations.

The rule is relevant when the reviewed scope includes object behavior, persistence operations, row or view identity, callers, and collaborators sufficient to assess whether the combined responsibility is intentional and coherent.

Do not apply this rule merely because objects have data fields, persistence names, or database-related methods. The Fowler catalog category for this pattern is `Data Source Architectural Patterns`.

# Rule Statement

An Active Record must coherently combine domain data, domain behavior, and persistence operations for a row or view without being mistaken for Domain Model, Data Mapper, Repository, Row Data Gateway, or generic persistence access.

# Rationale

Active Record is a combined object-and-persistence pattern. Its risk appears when a declared Active Record exposes only passive data, delegates away all persistence behavior, hides mapper or repository responsibilities behind misleading object APIs, or mixes responsibilities so extensively that callers cannot rely on the intended row object behavior.

This rule does not require Active Record and does not treat absence of Active Record as a defect.

# Evidence Required

Evaluation requires traceable evidence of the object, its represented row or view identity, domain data, domain behavior, persistence operations, caller usage, and any collaborators that affect persistence or mapping.

Direct evidence may include executable implementation, method behavior, save/load/delete flow when present, contracts, dependencies, tests, and architecture decisions. Naming, folders, comments, or documentation are supporting signals only.

# Evaluation Guidance

First distinguish actual Active Record from naming, passive data objects, Domain Model objects with separate persistence, Row Data Gateway, Data Mapper, Repository, equivalent implementations, legitimate absence, and insufficient evidence.

Evaluate only the combined Fowler Active Record responsibility. Do not evaluate DDD entities, general domain model quality, mapper separation as its own rule, repository collection semantics, layer dependency direction, Clean Architecture, Hexagonal Architecture, SOLID, messaging, architecture testing, or solution structure.

Active Record may coexist with Identity Field, Foreign Key Mapping, Unit of Work, Identity Map, or Lazy Load. These relationships must remain separate conclusions.

# Pass Conditions

Use `Pass` when evidence shows that objects coherently combine row-shaped data, domain behavior, and persistence operations while preserving the Active Record responsibility.

Use `Pass` for equivalent implementations when the combined responsibility is clear without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Active Record is declared, required, or depended on, but objects do not provide the combined data, behavior, and persistence responsibility with relevant architectural impact.

Use `Fail` when nominal Active Records are only passive data, only gateways, only mappers, only repositories, or only domain objects while callers rely on Active Record semantics.

# Warning Conditions

Use `Warning` when Active Record behavior is partial, inconsistent, heavily delegated, or mixed with adjacent responsibilities in a way that weakens the pattern boundary without enough evidence for `Fail`.

# Not Applicable Conditions

Use `Not Applicable` when Active Record is not adopted, another legitimate persistence pattern is used, no row object responsibility exists in scope, or the component is irrelevant.

Absence of Active Record must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the material cannot confirm the object responsibility, persistence operations, domain behavior, caller expectations, row identity, or collaborators.

Use `Not Enough Evidence` when only names, folders, comments, documentation, or data shape is available.

# Severity Guidance

Assign higher severity when a violated Active Record responsibility affects central persistence objects, important workflows, broad callers, consistency, maintainability, or evolution.

Assign lower severity when the issue is localized, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct evidence of combined data, behavior, and persistence responsibility or its violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-003, FOWLER-007, FOWLER-008, FOWLER-013, FOWLER-014. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Active Record.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
