# Rule ID

FOWLER-014

# Title

Foreign Key Mapping

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether object references are mapped to foreign keys while preserving object relationship semantics.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Foreign Key Mapping pattern, or when object references appear mapped to persisted foreign keys.

The rule is relevant when object relationships, persisted foreign keys, mapping behavior, callers, and persistence collaborators can be inspected.

Do not apply this rule merely because foreign keys, identifiers, or relationships are named. The Fowler catalog category for this pattern is `Object-Relational Structural Patterns`.

# Rule Statement

Foreign Key Mapping must map object references to foreign keys while preserving object relationship semantics without absorbing Identity Field, Data Mapper, Lazy Load, Repository, or generic relationship design responsibilities.

# Rationale

Foreign Key Mapping preserves object relationships across a relational representation. The risk appears when declared mapping loses relationship semantics, treats relationships as unrelated identifiers, hides mapper behavior as the evaluated concern, or blurs structural mapping with loading and identity responsibilities.

This rule does not require Foreign Key Mapping when the persistence model or reviewed scope makes it irrelevant.

# Evidence Required

Evaluation requires traceable evidence of object references, persisted foreign keys, mapping behavior, relationship semantics, caller usage, and collaborators.

Direct evidence may include executable mapping behavior, relationship access flow, dependencies, contracts, tests, and architecture decisions. Naming and documentation are supporting signals only.

# Evaluation Guidance

First distinguish Foreign Key Mapping from Identity Field, Data Mapper, Lazy Load, Repository, Active Record, equivalent relationship mapping, legitimate absence, and insufficient evidence.

Evaluate only mapping of object references to foreign keys while preserving relationship semantics. Do not evaluate object loading strategy, in-memory identity tracking, domain aggregate design, layer direction, DDD, Clean, Hexagonal, SOLID, messaging, architecture testing, or solution structure.

# Pass Conditions

Use `Pass` when evidence shows object references are mapped to foreign keys and object relationship semantics are preserved.

Use `Pass` for equivalent relationship mapping without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Foreign Key Mapping is declared, required, or depended on, but relationship semantics are lost or incorrectly represented with relevant architectural impact.

Use `Fail` when nominal Foreign Key Mapping is only identifier storage, Identity Field mapping, Lazy Load behavior, Data Mapper mechanics, or unrelated persistence logic while callers rely on relationship mapping.

# Warning Conditions

Use `Warning` when relationship mapping is partial, inconsistent, duplicated, mixed with adjacent responsibilities, or ambiguous enough to create risk.

# Not Applicable Conditions

Use `Not Applicable` when Foreign Key Mapping is not adopted, object-reference-to-foreign-key mapping is not relevant, another legitimate relationship approach is used, or no such relationship exists in scope.

Absence of Foreign Key Mapping must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when relationship semantics, foreign key mapping, caller expectations, persistence collaboration, or loading behavior cannot be traced enough to evaluate.

Use `Not Enough Evidence` when only names, folders, comments, documentation, identifiers, or isolated schema references are available.

# Severity Guidance

Assign higher severity when a Foreign Key Mapping violation affects central object relationships, broad persistence behavior, consistency, maintainability, or evolution.

Assign lower severity when isolated, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of object-reference-to-foreign-key mapping or violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-007, FOWLER-012, FOWLER-013. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Foreign Key Mapping.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
