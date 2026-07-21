# Rule ID

FOWLER-019

# Title

Client Session State

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether session state is stored on the client side when that distribution of state is relevant to the system design.

# Applicability

Apply this rule when reviewed material claims, depends on, or strongly suggests the Fowler Client Session State pattern, or when session state appears stored on the client side as part of the architecture.

The rule is relevant when session state ownership, client-side storage, server interaction, state reconstruction or validation, caller flow, and architectural decisions can be inspected.

Do not apply this rule merely because clients, sessions, tokens, identifiers, or user context exist. The Fowler catalog category for this pattern is `Session State Patterns`.

# Rule Statement

Client Session State must store session state on the client side when that distribution is part of the design without being reduced to generic client data, authentication, caching, messaging, or presentation concerns.

# Rationale

Client Session State places session data with the client to distribute state responsibility. The risk appears when a declared client session state design hides authoritative state elsewhere, stores unrelated data as if it were session state, loses consistency or trust boundaries, or is confused with generic client caching or presentation state.

This rule does not require Client Session State.

# Evidence Required

Evaluation requires traceable evidence of session state, client-side storage responsibility, server interaction, state validation or reconstruction when relevant, caller flow, contracts, tests, and architectural decisions.

Direct implementation and behavior are strongest. Naming, folders, comments, diagrams, or documentation are supporting signals only.

# Evaluation Guidance

First distinguish Client Session State from server session state, database session state, client cache, authentication token, presentation state, message state, equivalent client-side session responsibility, legitimate absence, and insufficient evidence.

Evaluate only the distribution of session state to the client side. Do not evaluate UI design, authentication policy, messaging delivery, layer boundaries, Clean or Hexagonal boundaries, DDD, SOLID, architecture testing, or solution structure.

# Pass Conditions

Use `Pass` when evidence shows session state is stored on the client side and that state distribution is coherent with the reviewed design.

Use `Pass` for equivalent client-side session state without exact naming.

# Fail Conditions

Use `Fail` when direct evidence shows Client Session State is declared, required, or depended on, but the state is not actually client-side or the distribution violates the intended responsibility with relevant architectural impact.

Use `Fail` when nominal client session state is only generic cache, authentication data, presentation state, message state, or server-owned state while callers rely on Client Session State semantics.

# Warning Conditions

Use `Warning` when client session state is partial, inconsistent, ambiguously authoritative, mixed with adjacent responsibilities, or creates limited architectural risk.

# Not Applicable Conditions

Use `Not Applicable` when Client Session State is not adopted, session state distribution is not relevant, another legitimate session state pattern or approach is used, or the component is irrelevant.

Absence of Client Session State must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when session state ownership, client-side storage, server interaction, validation, or caller flow cannot be confirmed.

Use `Not Enough Evidence` when only names, folders, comments, documentation, tokens, or isolated client data are available.

# Severity Guidance

Assign higher severity when a Client Session State violation affects central state consistency, trust boundaries, important workflows, many clients, maintainability, or evolution.

Assign lower severity when isolated, peripheral, or easily clarified. Do not use numeric scoring or automatic severity from outcome, category, naming, or absence.

# Confidence Guidance

Use `Confirmed` only with direct traceable evidence of client-side session state responsibility or violation. Use `Likely`, `Possible`, or `Not Enough Evidence` according to evidence completeness.

Naming alone must not produce `Confirmed`.

# Dependencies

None

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Client Session State.

# Change Notes

Initial rule created from `FOWLER_CATALOG.md`, aligned with the `FOWLER-001` Gold Standard structure. No global version or stabilization has been performed.
