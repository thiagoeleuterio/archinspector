# Rule ID

LAYER-009

# Title

Layer contracts must preserve boundary integrity

# Category

Layered Architecture

# Status

Active

# Intent

Ensure data and service contracts between layers do not force one layer to expose or depend on responsibilities owned by another layer.

# Applicability

Apply this rule when the reviewed material includes an identifiable layered architecture structure and explicit or implicit contracts used between two or more identified layers.

The rule is relevant when contracts of input, output, public interfaces, shared types, transfer models, boundary abstractions, service operations, data models, or other cross-layer surfaces can be inspected to determine whether they preserve the responsibilities assigned to each participating layer.

Do not apply this rule only because a type is shared, a data structure crosses a boundary, a layer calls another layer, or a contract-like name appears in files, projects, namespaces, folders, or components. The rule requires enough evidence to evaluate whether the contract forces a layer to expose, know, depend on, or assume responsibilities that belong to another layer.

# Rule Statement

Contracts between layers in a layered architecture must preserve boundary integrity by allowing collaboration without exposing, depending on, or transferring responsibilities owned by another layer.

# Rationale

Layered Architecture depends on boundaries that let layers collaborate while keeping their responsibilities distinguishable. Contracts are often the visible shape of those boundaries because they define what one layer may request, return, expose, or depend on when interacting with another layer.

When a contract exposes another layer's internal representation, technical mechanism, persistence structure, domain or business internals, or responsibility-specific model in a way that consumers must understand or honor, the boundary becomes coupled through the contract. This makes layer responsibilities harder to preserve because changes inside one layer may require systematic changes in another layer even when the architectural responsibility has not changed.

This risk is different from ordinary data transfer or shared abstraction. Contracts may legitimately transport data, represent operations, encapsulate stable abstractions, hide internal details, evolve compatibly, and allow collaboration between layers without transferring responsibility.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed layered structure, the participating layers, the contract or contracts crossing the layer boundary, the responsibilities assigned to each participating layer, and whether the contract exposes, depends on, or transfers a responsibility across that boundary.

Direct evidence may include public interfaces, operation contracts, input and output models, shared types, transfer models, boundary abstractions, data models used across layers, type dependencies, constructor dependencies, method signatures, method behavior that relies on contract shape, calls between layers, architecture tests, contract tests, architecture documentation, architectural decisions, dependency declarations, or reviewed code excerpts tied to the layered structure.

Evidence should prioritize executable implementation first, structural contracts and dependency relationships second, tests third, architecture documentation and decisions fourth, and naming or physical organization only as auxiliary supporting evidence.

Evidence must distinguish an architectural contract from an internal representation, implementation detail, transport model, domain model, technical contract, service contract, persistence contract, structural dependency, and architectural responsibility. Naming conventions, folder names, project names, namespace names, layer labels, type names, interface names, or contract-like suffixes may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

Evidence should show the architectural effect of the contract, not merely the presence of a shared type or a dependency. Sharing a type, using a common contract, passing identifiers, exposing neutral values, or defining minimal integration data does not prove a boundary violation without evidence that responsibility or internal detail leaks across the layer boundary.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible layered architecture interpretation and whether the participating layers and their responsibilities can be identified. Then inspect the contracts used between those layers and determine whether the contracts preserve the boundary by exposing only the information or operations needed for collaboration, or whether they force one layer to know, expose, or depend on responsibilities owned by another layer.

Evaluate only contract integrity between layers. Do not use this rule to evaluate general direction of dependencies, lower-level control over business policy, global clarity of layer responsibilities, presentation behavior ownership, application or service coordination, domain or business rule ownership, persistence responsibility placement, bypassing required intermediate layers, ports and adapters, gateways, interface adapters, domain model quality, domain tactical patterns, enterprise application patterns, performance, serialization, protocols, or specific technologies.

Interpret evidence conservatively. A contract may be legitimate when it transports data, represents an operation, provides a stable boundary abstraction, hides internal details, permits compatible evolution, uses neutral value types, shares identifiers, or implements an architecture-declared collaboration model without moving responsibility across layers. A common contract may be valid when the reviewed architecture explicitly authorizes it or when evidence shows that it remains a minimal integration surface rather than an internal model from one layer imposed on another.

The architectural concern appears when the contract makes consumers understand another layer's internal representation, persistence structure, technical mechanism, internal domain or business structure, data access detail, or responsibility-specific model in order to use the boundary correctly. It also appears when a contract causes evolution inside one layer to require systematic changes in another layer because the contract couples consumers to responsibilities they should not own.

Do not treat names of classes, interfaces, namespaces, folders, projects, or contract types as direct proof. A name may suggest a possible concern, but `Confirmed` requires direct evidence of boundary impact. Absence of evidence that a contract leaks responsibility must not be converted into `Pass` or `Fail` unless the reviewed scope is sufficient to support that conclusion.

When a contract includes persistence-shaped data, domain-shaped data, transport-shaped data, or technical mechanism details, evaluate whether those details are legitimate boundary data or whether they transfer responsibility. The same evidence may support different conclusions under related rules: dependency direction belongs to `LAYER-003`, persistence responsibility placement belongs to `LAYER-007`, bypass of required mediation belongs to `LAYER-008`, and contract boundary integrity belongs to this rule.

Remediation guidance should focus on restoring a stable boundary contract that preserves layer responsibilities while allowing necessary collaboration. Recommendations should be derived from finding evidence and must not prescribe a specific architecture style, pattern, framework, language, technology, or implementation mechanism as a universal requirement.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify the relevant layered structure, participating layers, layer responsibilities, and contracts between those layers, and the available evidence supports that the contracts preserve responsibility boundaries while enabling collaboration.

Use `Pass` when contracts transport data, represent operations, encapsulate stable abstractions, expose minimal integration surfaces, share identifiers, use neutral values, hide internal representations, or evolve compatibly without requiring a consuming layer to know or assume another layer's responsibility.

Use `Pass` when shared contracts are explicitly authorized by the reviewed architecture and the available evidence supports that they do not expose internal details, transfer architectural responsibility, or couple one layer's evolution to another layer's internal representation.

# Fail Conditions

Use `Fail` when direct evidence shows that a contract between identified layers forces one layer to know, expose, depend on, or assume responsibilities owned by another layer within the reviewed layered architecture.

Use `Fail` when direct evidence shows that a public interface, shared type, transfer model, boundary abstraction, service contract, or data contract exposes internal representations, persistence details, technical mechanisms, domain or business internals, or responsibility-specific structures in a way that materially couples another layer to those details.

Use `Fail` when direct evidence shows that contract coupling makes changes inside one layer require systematic changes in another layer because the consuming layer depends on a representation or responsibility that should remain internal to the provider layer.

Use `Fail` when direct evidence shows that a shared contract transfers architectural responsibility across a layer boundary rather than merely enabling collaboration between the responsible layers.

# Warning Conditions

Use `Warning` when evidence indicates partial, localized, emerging, indirect, repeated, or ambiguous leakage of responsibilities through contracts, but the available material does not justify a definitive `Fail`.

Use `Warning` when a contract appears to expose another layer's internal representation, persistence detail, technical mechanism, or responsibility-specific model, but the reviewed material leaves reasonable uncertainty about whether the exposed shape is a legitimate boundary contract or an architectural leak.

Use `Warning` when contracts show consistent signs of cross-layer coupling or unstable boundary evolution, but the reviewed material does not fully establish the extent, responsibility transfer, or architectural impact.

Use `Warning` when documentation and implementation suggest different contract boundaries and the reviewed material shows a maintainability risk, but the evidence is not strong enough to conclude that contract integrity has been definitively violated.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include an identifiable layered architecture structure, does not include relevant contracts between layers, or does not include layer boundaries whose contract integrity can be evaluated.

Use `Not Applicable` when the material concerns only internal representations within a single layer, local implementation details that do not cross a layer boundary, or collaboration that does not involve an architectural contract between layers.

Use `Not Applicable` when the review question concerns dependency direction, bypass of required intermediate layers, layer responsibility ownership, lower-level control over business policy, persistence responsibility placement, presentation behavior, application or service coordination, domain or business rule ownership, ports and adapters, gateways, interface adapters, domain modeling quality, enterprise application patterns, performance, serialization, protocols, or another architectural concern without requiring evaluation of contract boundary integrity between layers.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify the layered structure, identify the participating layers, identify the contracts between them, determine layer responsibilities, inspect contract shape or usage, distinguish boundary data from internal representation, determine architectural impact, or resolve conflicting signals.

Use `Not Enough Evidence` when contracts are visible but the reviewed scope does not show whether they are public boundary contracts, internal implementation details, transport models, domain models, technical contracts, service contracts, persistence contracts, stable shared abstractions, or architecture-authorized shared types.

Use `Not Enough Evidence` when the only available signals are naming, folder structure, physical location, project names, namespace names, layer labels, type names, interface names, contract suffixes, isolated signatures, incomplete documentation, dependency existence without usage, or absence of contrary evidence. Absence of evidence must not be converted into `Fail`.

Use `Not Enough Evidence` when a shared type or contract might represent a boundary leak but the reviewed material cannot establish whether it transfers responsibility, exposes internal detail, or creates architectural coupling across layers.

# Severity Guidance

Assign higher severity when contract boundary leakage affects critical layer boundaries, central workflows, broad portions of the reviewed scope, many consumers, stable public interfaces, recurring contracts, important business or persistence responsibilities, high change propagation, reduced maintainability, or systemic coupling between layers.

Assign lower severity when the contract concern is narrow, isolated, peripheral, reversible, limited to one low-impact boundary, involves weak coupling, or is unlikely to affect broader evolution of the layered structure.

Severity must reflect demonstrated architectural and maintainability impact within the reviewed scope. Consider the criticality of the affected boundary, extent of leakage, impact on evolution, impact on maintenance, recurrence, architectural coupling created, and propagation of changes between layers. Do not assign severity solely from the Layered Architecture category, contract naming, type sharing, dependency presence, physical location, or a numeric scoring formula.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the layered structure, the participating layers, their responsibilities, the contract crossing the boundary, and whether the contract preserves or violates boundary integrity.

Use `Likely` when multiple consistent evidence points support the evaluation but direct confirmation of contract role, responsibility ownership, internal-detail exposure, or architectural impact is incomplete.

Use `Possible` when evidence is limited, indirect, partially ambiguous, or relies on weak supporting signals that suggest contract integrity or leakage without conclusively establishing responsibility transfer or boundary impact.

Use `Not Enough Evidence` when the available material cannot support a reliable conclusion. Naming, directories, namespaces, layer labels, project names, physical placement, type names, interface names, documentation alone, or absence of contrary evidence must not produce `Confirmed` confidence.

# Dependencies

LAYER-002, LAYER-003, LAYER-007, LAYER-008. These are conceptual dependencies for shared layer responsibility, dependency direction, persistence boundary, bypass, and contract vocabulary, not procedural prerequisites for evaluating this rule.

# References

LAYER_CATALOG.md

# Change Notes

Initial rule content for the Layered Architecture catalog.
