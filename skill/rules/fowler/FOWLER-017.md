# Rule ID

FOWLER-017

# Title

Optimistic Offline Lock

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether concurrent offline work is protected by conflict detection before committing changes.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Optimistic Offline Lock pattern, or when concurrent offline work appears protected by detecting conflicts before commit.

The rule is relevant when offline work, concurrent edits, commit flow, conflict detection, identity or version state, and caller behavior can be inspected.

Do not apply this rule merely because concurrency, versions, locks, or transactions are mentioned. The Fowler catalog category for this pattern is `Offline Concurrency Patterns`.

# Rule Statement

Optimistic Offline Lock must protect concurrent offline work by detecting conflicts before committing changes without being confused with Pessimistic Offline Lock, Unit of Work, transaction usage, or generic concurrency control.

# Rationale

Optimistic Offline Lock allows concurrent work while checking for conflicts at commit time. The risk appears when a declared optimistic lock does not detect conflicts reliably, silently overwrites concurrent changes, behaves as exclusive reservation, or hides the responsibility inside unrelated transaction coordination.

This rule does not require Optimistic Offline Lock.

# Evidence Required

Evaluation requires traceable evidence of offline work scope, concurrent access risk, conflict detection state, commit behavior, caller handling of conflicts, and persistence collaborators.

Direct evidence may include executable commit flow, version or comparison behavior, contracts, tests, dependencies, and architecture decisions. Naming and documentation are supporting signals only.

# Evaluation Guidance

First distinguish Optimistic Offline Lock from Pessimistic Offline Lock, Unit of Work, generic transactions, Identity Field, equivalent conflict detection, legitimate absence, and insufficient evidence.

Evaluate only conflict detection before commit for concurrent offline work. Do not evaluate exclusive locking, change tracking as its own responsibility, messaging idempotency, layer boundaries, DDD, Clean, Hexagonal, SOLID, architecture testing, or solution structure.

# Pass Conditions

Use `Pass` when evidence shows concurrent offline work is protected by conflict detection before committing changes.

Use `Pass` for equivalent optimistic conflict detection without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Optimistic Offline Lock is declared, required, or depended on, but conflicts are not detected before commit with relevant architectural impact.

Use `Fail` when nominal optimistic locking behaves as exclusive locking, generic transaction use, Unit of Work only, or unrelated version naming while callers rely on optimistic conflict detection.

# Warning Conditions

Use `Warning` when conflict detection is partial, inconsistently applied, ambiguous, mixed with adjacent responsibilities, or insufficiently traced for a definitive `Fail`.

# Not Applicable Conditions

Use `Not Applicable` when Optimistic Offline Lock is not adopted, concurrent offline work is not relevant, another legitimate concurrency approach is used, or the component is irrelevant.

Absence of Optimistic Offline Lock must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when offline work, concurrent conflict risk, detection state, commit behavior, or caller handling cannot be confirmed.

Use `Not Enough Evidence` when only names, folders, comments, documentation, version fields, or transaction references are available.

# Severity Guidance

Assign higher severity when an Optimistic Offline Lock violation affects central consistency, concurrent workflows, data integrity, many users or flows, maintainability, or evolution.

Assign lower severity when isolated, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of optimistic conflict detection or violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-018, FOWLER-011, FOWLER-013. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Optimistic Offline Lock.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
