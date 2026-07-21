# Rule ID

FOWLER-016

# Title

Data Transfer Object

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether data is transferred across process or network boundaries through objects designed for transfer rather than domain behavior.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Data Transfer Object pattern, or when data appears transferred across process or network boundaries through transfer-focused objects.

The rule is relevant when a process or network boundary, transferred data shape, caller or receiver use, and distinction from domain behavior can be inspected.

Do not apply this rule merely because objects contain data or have a suffix suggesting transfer. The Fowler catalog category for this pattern is `Distribution Patterns`.

# Rule Statement

A Data Transfer Object must carry data across process or network boundaries as a transfer object rather than a domain behavior object without becoming a Remote Facade, domain model, message, or generic data structure rule.

# Rationale

Data Transfer Object separates transfer shape from domain behavior across distribution boundaries. The risk appears when a declared DTO carries domain behavior, exposes misleading object semantics across a boundary, is confused with a remote facade operation, or is treated as proof of a broader architecture style.

This rule does not require DTOs where no such boundary or transfer responsibility is relevant.

# Evidence Required

Evaluation requires traceable evidence of the process or network boundary, transferred data object, caller and receiver usage, absence or presence of domain behavior, contracts, and related remote collaboration.

Direct evidence may include executable flow, contracts, serialization or transfer behavior when available, tests, dependencies, and architecture decisions. Naming and documentation are supporting signals only.

# Evaluation Guidance

First distinguish DTO from domain objects, value carriers without a boundary, Remote Facade, messages, view models, equivalent transfer objects, legitimate absence, and insufficient evidence.

Evaluate only transfer-focused data objects across process or network boundaries. Do not evaluate remote operation granularity, domain model quality, messaging semantics, layer boundaries, Clean or Hexagonal boundary DTO rules, DDD, SOLID, architecture testing, or solution structure.

# Pass Conditions

Use `Pass` when evidence shows data crosses a process or network boundary through objects designed for transfer rather than domain behavior.

Use `Pass` for equivalent transfer objects without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows DTO is declared, required, or depended on, but transfer objects carry domain behavior or fail to serve the transfer boundary with relevant architectural impact.

Use `Fail` when a nominal DTO is actually a domain object, remote facade, message responsibility, or unrelated data structure while callers rely on DTO semantics.

# Warning Conditions

Use `Warning` when DTO responsibilities are partial, inconsistent, mixed with domain behavior, blurred with remote facade or message responsibilities, or ambiguous enough to create risk.

# Not Applicable Conditions

Use `Not Applicable` when DTO is not adopted, no process or network transfer boundary is relevant, another legitimate transfer approach is used, or the component is irrelevant.

Absence of DTO must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when transfer boundary, object usage, data shape, behavior, callers, or receivers cannot be confirmed.

Use `Not Enough Evidence` when only names, folders, comments, documentation, or passive data structures are available.

# Severity Guidance

Assign higher severity when a DTO violation affects central distributed interaction, broad contracts, many callers, compatibility, maintainability, or evolution.

Assign lower severity when isolated, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of transfer-object behavior or violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-015. This is a related distribution boundary, not a procedural prerequisite.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Data Transfer Object.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
