# Rule ID

FOWLER-020

# Title

Registry

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether globally accessible objects are used as a known lookup point for shared services or objects.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Registry pattern, or when globally accessible lookup points appear to provide shared services or objects.

The rule is relevant when global access, lookup responsibility, registered objects, callers, lifecycle, and dependency usage can be inspected.

Do not apply this rule merely because a static name, global variable, container, service, or configuration object exists. The Fowler catalog category for this pattern is `Base Patterns`.

# Rule Statement

A Registry must provide a known globally accessible lookup point for shared services or objects without becoming generic global state, Service Layer orchestration, dependency wiring, or unrelated configuration.

# Rationale

Registry provides a well-known lookup point for shared objects. The risk appears when a declared Registry becomes uncontrolled global state, hides service orchestration, obscures dependencies, exposes unrelated configuration, or is relied on as a registry while failing to provide stable lookup semantics.

This rule does not require Registry and does not treat all global access as this pattern.

# Evidence Required

Evaluation requires traceable evidence of the globally accessible lookup point, registered objects or services, caller usage, lifecycle, ownership, and whether lookup semantics are stable.

Direct evidence may include executable implementation, access flow, contracts, dependencies, tests, and architecture decisions. Naming and documentation are supporting signals only.

# Evaluation Guidance

First distinguish Registry from Service Layer, generic global state, configuration, dependency wiring, local factory, locator-like infrastructure, equivalent lookup point, legitimate absence, and insufficient evidence.

Evaluate only globally accessible lookup of shared services or objects. Do not evaluate application operation boundaries, layer dependency direction, dependency inversion as a SOLID rule, Clean or Hexagonal ports, DDD services, messaging, architecture testing, or solution structure.

# Pass Conditions

Use `Pass` when evidence shows globally accessible objects are used as a known lookup point for shared services or objects and the Registry responsibility is coherent.

Use `Pass` for equivalent registry behavior without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Registry is declared, required, or depended on, but lookup responsibility is violated with relevant architectural impact.

Use `Fail` when a nominal Registry primarily behaves as uncontrolled global state, service orchestration, dependency wiring, configuration, or unrelated utility while callers rely on Registry semantics.

# Warning Conditions

Use `Warning` when registry behavior is partial, inconsistently scoped, mixed with adjacent responsibilities, or creates limited dependency visibility and maintainability risk without enough evidence for `Fail`.

# Not Applicable Conditions

Use `Not Applicable` when Registry is not adopted, global lookup is not relevant, another legitimate approach is used, or no shared object lookup responsibility exists in scope.

Absence of Registry must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when global accessibility, lookup behavior, registered object ownership, lifecycle, or caller dependency cannot be confirmed.

Use `Not Enough Evidence` when only names, folders, comments, documentation, static shape, or configuration references are available.

# Severity Guidance

Assign higher severity when a Registry violation affects central shared services, many callers, dependency clarity, maintainability, consistency, or evolution.

Assign lower severity when isolated, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of registry lookup behavior or violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

FOWLER-005. This is a related boundary, not a procedural prerequisite.

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Registry.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
