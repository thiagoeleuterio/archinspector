# Rule ID

FOWLER-013

# Title

Identity Field

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether persisted object identity is stored in a field that maps object instances to database rows.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Identity Field pattern, or when persisted object identity appears stored in a field that maps objects to rows.

The rule is relevant when object identity, persisted row identity, mapping behavior, callers, and persistence collaborators can be inspected.

Do not apply this rule merely because objects contain identifiers or data fields. The Fowler catalog category for this pattern is `Object-Relational Structural Patterns`.

# Rule Statement

An Identity Field must store persisted object identity in a field that maps object instances to database rows without becoming Identity Map tracking, Repository access, or generic identifier naming.

# Rationale

Identity Field provides the structural link between object identity and persisted row identity. The risk appears when a declared Identity Field does not consistently represent persisted identity, is confused with in-memory identity tracking, or cannot support the mapping responsibility callers and persistence collaborators depend on.

This rule does not require Identity Field when persisted object identity is not relevant or is handled by another legitimate approach.

# Evidence Required

Evaluation requires traceable evidence of object identity, persisted row identity, the identity field, mapping behavior, persistence collaboration, and caller or object lifecycle expectations.

Direct evidence may include executable behavior, mapping flow, dependencies, contracts, tests, and architecture decisions. Naming and documentation are supporting signals only.

# Evaluation Guidance

First distinguish Identity Field from generic identifiers, Identity Map, Foreign Key Mapping, Active Record, Data Mapper, Repository, equivalent identity mapping, legitimate absence, and insufficient evidence.

Evaluate only persisted object identity stored in a field mapping object instances to rows. Do not evaluate in-memory instance reuse, relationship mapping, collection-like access, domain modeling, layer boundaries, DDD, Clean, Hexagonal, SOLID, messaging, architecture testing, or solution structure.

# Pass Conditions

Use `Pass` when evidence shows persisted object identity is represented by a field that maps object instances to database rows.

Use `Pass` for equivalent identity-field behavior without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Identity Field is declared, required, or depended on, but persisted identity is not represented coherently with relevant architectural impact.

Use `Fail` when a nominal Identity Field is only naming, unrelated business identity, generic metadata, Identity Map behavior, or relationship mapping while callers rely on persisted identity mapping.

# Warning Conditions

Use `Warning` when identity field behavior is partial, inconsistent, duplicated, mixed with adjacent responsibilities, or ambiguous enough to create risk.

# Not Applicable Conditions

Use `Not Applicable` when Identity Field is not adopted, persisted object identity is not relevant, another legitimate identity approach is used, or no object-to-row mapping responsibility exists in scope.

Absence of Identity Field must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when identity semantics, mapping behavior, persistence collaboration, object lifecycle, or caller expectations cannot be confirmed.

Use `Not Enough Evidence` when only names, folders, comments, documentation, or identifier-looking fields are available.

# Severity Guidance

Assign higher severity when an Identity Field violation affects central persistence identity, object mapping consistency, important workflows, maintainability, or evolution.

Assign lower severity when isolated, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of persisted identity field mapping or violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-006, FOWLER-007, FOWLER-010, FOWLER-014. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Identity Field.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
