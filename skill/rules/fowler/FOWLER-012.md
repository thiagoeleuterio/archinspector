# Rule ID

FOWLER-012

# Title

Lazy Load

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether related data is deferred until it is needed while preserving the expected object interaction model.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Lazy Load pattern, or when related data appears to be deferred until first use.

The rule is relevant when object relationships, deferred loading behavior, caller interaction, loading triggers, and persistence collaborators can be inspected.

Do not apply this rule merely because data is optional, absent, cached, or loaded through separate calls. The Fowler catalog category for this pattern is `Object-Relational Behavioral Patterns`.

# Rule Statement

Lazy Load must defer related data until needed while preserving the expected object interaction model without being reduced to generic caching, explicit querying, Data Mapper behavior, or Repository access.

# Rationale

Lazy Load manages the trade-off between object interaction and loading cost by delaying related data access until needed. The risk appears when a declared Lazy Load changes expected object behavior, hides unavailable collaborators, creates inconsistent relationship semantics, or is confused with generic caching or explicit access patterns.

This rule does not require Lazy Load.

# Evidence Required

Evaluation requires traceable evidence of the related data, object interaction model, deferred loading trigger, loading behavior, caller expectations, persistence collaborators, and tests or decisions when available.

Direct evidence may include executable behavior, property or relationship access flow, tests demonstrating deferred loading, dependencies, contracts, and architectural decisions. Naming and documentation are supporting signals only.

# Evaluation Guidance

First distinguish actual Lazy Load from explicit loading, eager loading, generic caching, Repository access, Data Mapper behavior, Identity Map, equivalent deferral, legitimate absence, and insufficient evidence.

Evaluate only deferred related data loading while preserving expected object interaction. Do not evaluate mapping separation, collection-like access, identity tracking, layer boundaries, DDD aggregates, Clean or Hexagonal boundaries, SOLID, messaging, architecture testing, or solution structure.

# Pass Conditions

Use `Pass` when evidence shows related data is deferred until needed and the expected object interaction model remains coherent.

Use `Pass` for equivalent deferred loading behavior without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Lazy Load is declared, required, or depended on, but deferred loading violates expected object interaction with relevant architectural impact.

Use `Fail` when nominal Lazy Load behavior is actually generic caching, explicit querying, missing data, mapper behavior, or repository behavior while callers rely on Lazy Load semantics.

# Warning Conditions

Use `Warning` when deferred loading is partial, inconsistent, surprising to callers, mixed with adjacent responsibilities, or ambiguous enough to create risk.

# Not Applicable Conditions

Use `Not Applicable` when Lazy Load is not adopted, deferred related data is not relevant, another legitimate loading strategy is used, or no related object interaction exists in scope.

Absence of Lazy Load must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when loading triggers, object interaction, related data behavior, caller expectations, or collaborators cannot be confirmed.

Use `Not Enough Evidence` when only names, folders, comments, documentation, or isolated relationship declarations are available.

# Severity Guidance

Assign higher severity when a Lazy Load violation affects central object interactions, important workflows, consistency, performance-sensitive behavior, maintainability, or evolution.

Assign lower severity when isolated, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of deferred loading behavior or violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-007, FOWLER-010. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Lazy Load.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
