# Rule ID

FOWLER-018

# Title

Pessimistic Offline Lock

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether concurrent offline work is protected by acquiring exclusive access before changes are made.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Pessimistic Offline Lock pattern, or when concurrent offline work appears protected by exclusive access acquired before changes.

The rule is relevant when offline work, concurrent edit risk, lock acquisition, lock ownership, release behavior, caller flow, and persistence collaboration can be inspected.

Do not apply this rule merely because locks, transactions, concurrency, or reservations are named. The Fowler catalog category for this pattern is `Offline Concurrency Patterns`.

# Rule Statement

Pessimistic Offline Lock must protect concurrent offline work by acquiring exclusive access before changes are made without being confused with Optimistic Offline Lock, Unit of Work, generic transactions, or generic synchronization.

# Rationale

Pessimistic Offline Lock prevents conflicting offline work by granting exclusive access before changes occur. The risk appears when a declared pessimistic lock does not actually reserve access, has unclear ownership or release behavior, behaves as optimistic conflict detection, or hides the responsibility inside unrelated transaction handling.

This rule does not require Pessimistic Offline Lock.

# Evidence Required

Evaluation requires traceable evidence of offline work scope, lock acquisition before change, exclusive ownership, release or expiration behavior, caller handling, and persistence collaborators.

Direct evidence may include executable flow, contracts, tests, dependencies, and architecture decisions. Naming and documentation are supporting signals only.

# Evaluation Guidance

First distinguish Pessimistic Offline Lock from Optimistic Offline Lock, Unit of Work, generic transactions, runtime synchronization, equivalent exclusive access, legitimate absence, and insufficient evidence.

Evaluate only exclusive access acquired before offline changes. Do not evaluate commit-time conflict detection, change tracking, messaging coordination, layer boundaries, DDD, Clean, Hexagonal, SOLID, architecture testing, or solution structure.

# Pass Conditions

Use `Pass` when evidence shows concurrent offline work is protected by acquiring exclusive access before changes are made.

Use `Pass` for equivalent exclusive offline access without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Pessimistic Offline Lock is declared, required, or depended on, but exclusive access is not acquired or enforced before changes with relevant architectural impact.

Use `Fail` when nominal pessimistic locking is only optimistic conflict detection, generic transaction use, Unit of Work, or unrelated synchronization while callers rely on pessimistic lock semantics.

# Warning Conditions

Use `Warning` when exclusive locking is partial, inconsistently applied, ambiguously scoped, mixed with adjacent responsibilities, or release behavior creates limited architectural risk.

# Not Applicable Conditions

Use `Not Applicable` when Pessimistic Offline Lock is not adopted, concurrent offline work is not relevant, another legitimate concurrency approach is used, or the component is irrelevant.

Absence of Pessimistic Offline Lock must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when offline work, lock acquisition, exclusivity, ownership, release behavior, or caller flow cannot be confirmed.

Use `Not Enough Evidence` when only names, folders, comments, documentation, lock fields, or transaction references are available.

# Severity Guidance

Assign higher severity when a Pessimistic Offline Lock violation affects central consistency, concurrent workflows, data integrity, many users or flows, maintainability, or evolution.

Assign lower severity when isolated, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of exclusive offline locking or violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-017, FOWLER-011. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Pessimistic Offline Lock.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
