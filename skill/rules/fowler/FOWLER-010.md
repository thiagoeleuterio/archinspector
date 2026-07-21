# Rule ID

FOWLER-010

# Title

Identity Map

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether loaded objects are tracked so repeated access to the same identity returns the same in-memory object instance.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Identity Map pattern, or when loaded objects appear to be tracked by identity to preserve in-memory object instance identity.

The rule is relevant when identity, object loading, repeated access behavior, callers, and lifecycle scope can be inspected.

Do not apply this rule merely because identifiers, caches, maps, or collections exist. The Fowler catalog category for this pattern is `Object-Relational Behavioral Patterns`.

# Rule Statement

An Identity Map must track loaded objects so repeated access to the same identity returns the same in-memory object instance within the relevant scope without becoming a generic cache, Unit of Work, Data Mapper, or Repository rule.

# Rationale

Identity Map preserves object identity and avoids inconsistent duplicate in-memory instances for the same persisted identity. The risk appears when a declared identity map behaves as a generic cache, has unclear lifecycle scope, duplicates instances, or hides responsibilities belonging to Unit of Work, Data Mapper, or Repository.

This rule does not require Identity Map.

# Evidence Required

Evaluation requires traceable evidence of persisted identity, object loading, tracking scope, repeated access behavior, instance reuse, caller usage, and collaborators.

Direct evidence may include executable behavior, lookup and load flow, tests demonstrating same-instance behavior, contracts, dependencies, and decisions. Naming and documentation are supporting signals only.

# Evaluation Guidance

First distinguish Identity Map from generic caching, Unit of Work change tracking, Data Mapper mapping, Repository access, Identity Field mapping, Lazy Load behavior, equivalent identity tracking, legitimate absence, and insufficient evidence.

Evaluate only in-memory identity tracking for loaded objects. Do not evaluate persistence transaction coordination, mapping separation, collection-like access, object identity fields, layer boundaries, DDD, Clean, Hexagonal, SOLID, messaging, architecture testing, or solution structure.

# Pass Conditions

Use `Pass` when evidence shows loaded objects are tracked so repeated access to the same identity returns the same in-memory object instance within the intended scope.

Use `Pass` for equivalent identity tracking without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Identity Map is declared, required, or depended on, but repeated access can produce inconsistent duplicate instances with relevant architectural impact.

Use `Fail` when a nominal Identity Map primarily behaves as generic cache, repository, mapper, or Unit of Work while callers rely on identity map semantics.

# Warning Conditions

Use `Warning` when identity tracking is partial, inconsistently scoped, mixed with adjacent responsibilities, or ambiguous enough to create risk without direct evidence for `Fail`.

# Not Applicable Conditions

Use `Not Applicable` when Identity Map is not adopted, object identity reuse is not relevant, another legitimate approach is used, or no loaded object identity responsibility exists in scope.

Absence of Identity Map must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when identity, loaded object lifecycle, repeated access behavior, scope, or collaborators cannot be confirmed.

Use `Not Enough Evidence` when only names, folders, comments, documentation, or identifier fields are available.

# Severity Guidance

Assign higher severity when an Identity Map violation affects central object identity consistency, important workflows, broad loading paths, maintainability, or evolution.

Assign lower severity when isolated, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of identity tracking behavior or violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-007, FOWLER-011, FOWLER-012, FOWLER-013. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Identity Map.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
