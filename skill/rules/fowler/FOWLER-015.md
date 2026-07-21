# Rule ID

FOWLER-015

# Title

Remote Facade

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether remote access is provided through a coarse-grained facade that minimizes distributed interaction costs.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Remote Facade pattern, or when remote access appears exposed through coarse-grained operations.

The rule is relevant when a remote boundary, caller interaction, operation granularity, transfer collaboration, and distributed interaction cost can be inspected.

Do not apply this rule merely because a service, endpoint, facade, or interface exists. The Fowler catalog category for this pattern is `Distribution Patterns`.

# Rule Statement

A Remote Facade must provide coarse-grained remote access that minimizes distributed interaction costs without being confused with Service Layer, Data Transfer Object, Repository, or generic API design.

# Rationale

Remote Facade reduces the cost and fragility of distributed calls by providing coarse-grained operations across a remote boundary. The risk appears when a declared remote facade exposes chatty fine-grained interactions, leaks domain object interaction models across process boundaries, or absorbs transfer object and service-layer responsibilities without a clear boundary.

This rule does not require Remote Facade when remote access is absent or solved by another legitimate approach.

# Evidence Required

Evaluation requires traceable evidence of the remote boundary, operation granularity, caller flow, distributed interaction pattern, transfer data when relevant, and collaborators.

Direct evidence may include executable behavior, call flow, contracts, tests, dependencies, and architecture decisions. Naming and documentation are supporting signals only.

# Evaluation Guidance

First distinguish Remote Facade from Service Layer, Data Transfer Object, Repository, gateway access, local facade, equivalent coarse-grained remote boundary, legitimate absence, and insufficient evidence.

Evaluate only coarse-grained remote access and distributed interaction cost. Do not evaluate generic service boundaries, DTO structure as its own concern, layer direction, messaging delivery, Clean or Hexagonal boundaries, DDD, SOLID, architecture testing, or solution structure.

# Pass Conditions

Use `Pass` when evidence shows remote access is exposed through coarse-grained operations that reduce distributed interaction costs.

Use `Pass` for equivalent remote facade behavior without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Remote Facade is declared, required, or depended on, but remote access remains fine-grained or chatty with relevant architectural impact.

Use `Fail` when a nominal Remote Facade primarily behaves as local service layer, DTO container, repository, gateway, or unrelated API while callers rely on Remote Facade semantics.

# Warning Conditions

Use `Warning` when remote facade behavior is partial, inconsistent, too fine-grained in limited areas, mixed with adjacent responsibilities, or ambiguous enough to create risk.

# Not Applicable Conditions

Use `Not Applicable` when Remote Facade is not adopted, no remote boundary is relevant, another legitimate remote interaction model is used, or the component is irrelevant.

Absence of Remote Facade must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when remote boundary, operation granularity, caller flow, distributed costs, or collaborators cannot be confirmed.

Use `Not Enough Evidence` when only names, folders, comments, documentation, or interface shape is available.

# Severity Guidance

Assign higher severity when a Remote Facade violation affects central remote workflows, many callers, distributed cost, maintainability, consistency, or evolution.

Assign lower severity when isolated, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of remote interaction granularity or violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-005, FOWLER-016. These are related boundaries, not procedural prerequisites.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Remote Facade.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
