# Rule ID

LAYER-007

# Title

Data access layer must contain persistence access responsibilities

# Category

Layered Architecture

# Status

Active

# Intent

Ensure persistence access responsibilities remain inside the data access or infrastructure layer assigned to that concern.

# Applicability

Apply this rule when the reviewed material includes an identifiable layered architecture structure, an identifiable data access layer, infrastructure layer, or equivalent persistence responsibility, and operations that interact with persistent storage within the reviewed scope.

The rule is relevant when upper layers consume, request, coordinate, or depend on persistence operations and the reviewed scope provides enough evidence to determine where persistence details are implemented, exposed, mapped, or managed.

Do not apply this rule only because files, projects, namespaces, folders, or components use data access-like, infrastructure-like, repository-like, store-like, persistence-like, or gateway-like names. The rule requires enough evidence to identify the persistence responsibility and evaluate whether concrete persistence access remains encapsulated by the layer assigned to that concern.

# Rule Statement

Persistence access responsibilities in a layered architecture must remain inside the data access layer, infrastructure layer, or equivalent layer assigned to persistence concerns, without leaking concrete persistence mechanisms into layers that do not own those responsibilities.

# Rationale

Layered Architecture separates persistence access from presentation, application, domain, business, and other non-persistence responsibilities so that storage mechanisms can be changed, tested, optimized, and reasoned about without spreading technical storage concerns across the system. When persistence access responsibilities leak into non-responsible layers, upper layers become coupled to concrete storage details and changes to persistence behavior may require coordinated edits outside the layer assigned to that concern.

This risk is different from ordinary use of persisted data. A data access or infrastructure layer may legitimately execute reads and writes, translate operations to a persistence mechanism, map persisted data, manage connections, sessions, or equivalent technical units, handle technical persistence errors, apply technical access optimizations, paginate or order data for technical reasons, materialize results, encapsulate queries, and provide data to other layers through permitted contracts. These responsibilities do not automatically mean that the data access or infrastructure layer owns business rules.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed layered structure, the data access layer, infrastructure layer, or equivalent persistence responsibility, the persistence operations being evaluated, the upper layers that consume or request those operations, and where concrete persistence details are implemented or exposed.

Direct evidence may include implementation of data access components, references to persistence mechanisms, commands, queries, connection or session management, mappings between persisted representations and representations used by other layers, persistence-specific types used in contracts, flow between application, domain or business, infrastructure, and data access responsibilities, integration tests, architecture tests, layer documentation, architectural decisions, structural configuration, build dependencies, technical persistence error handling, or reviewed code excerpts tied to the reviewed layered structure.

Evidence should prioritize executable implementation first, structural dependencies and types used second, tests that demonstrate the data access flow third, contracts and documentation fourth, and naming or physical location only as auxiliary supporting evidence.

Evidence must distinguish persistence access from business rules, business decisions, data queries, data selection policy, technical transformation, mapping, operation coordination, transaction control, and infrastructure detail. Naming conventions, folder names, project names, namespace names, layer labels, repository-like names, store-like names, persistence-like names, or physical location may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible layered architecture interpretation and whether a data access layer, infrastructure layer, or equivalent persistence responsibility can be identified. Then inspect the persistence flow and determine whether concrete persistence access responsibilities remain inside the responsible layer or are implemented, duplicated, exposed, or managed by layers assigned to other concerns.

Evaluate only the placement and exposure of persistence access responsibilities. Do not use this rule to evaluate lower-level control over business policy decisions, general clarity of layer responsibilities, declared dependency direction, presentation behavior, application or service coordination by itself, domain or business rule ownership, layer bypassing, general layer contract integrity, repository modeling as a domain pattern, data access patterns, ports and adapters, gateways, query quality, storage performance, transactional consistency, data security, physical storage modeling, or framework-specific implementation conventions.

Interpret evidence conservatively. Use of persisted data outside the data access or infrastructure layer does not by itself indicate a violation. An upper layer may request loading or persistence through a permitted abstraction, express a need for data without knowing the persistence mechanism, coordinate a transaction while the mechanism remains encapsulated, use stable contracts between layers, pass identifiers or neutral data, or make a business decision using persisted information without owning persistence access responsibilities.

Do not equate a dependency on a permitted contract with a dependency on a concrete persistence detail. A complex query is not automatically a business rule, and a data selection policy may require separate analysis to determine whether it is technical selection, application coordination, or business behavior. Transaction control outside the data access layer does not automatically produce `Fail` when concrete persistence mechanisms remain encapsulated.

Common finding patterns include presentation code directly accessing persistence mechanisms, application code containing storage-specific commands or queries, domain or business code depending on concrete persistence details, persistent mapping logic spread across multiple layers, connection or session management outside the responsible layer, persistence-specific types crossing boundaries and conditioning behavior in other layers, storage details determining internal contracts of upper layers, duplicated persistence access in non-responsible components, and technical persistence handling mixed with business behavior. These patterns support findings only when corroborated by evidence that concrete persistence responsibility is implemented or exposed outside the responsible layer.

When technical persistence types cross a layer boundary, evaluate the impact of the exposure rather than the type name alone. A persistence-specific type may support a `Fail` or `Warning` when it couples upper-layer behavior or contracts to concrete storage details, but weak or isolated exposure may require lower confidence or `Not Enough Evidence` if the reviewed material does not show how the type is used.

Remediation guidance should focus on encapsulating concrete persistence access inside the data access layer, infrastructure layer, or equivalent persistence responsibility while preserving legitimate coordination, business decision-making, and contract usage in other layers. Recommendations should be derived from finding evidence and must not prescribe a specific framework, language, technology, data access pattern, domain modeling pattern, ports-and-adapters structure, or formal architecture style as a universal requirement.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify the relevant layered structure, persistence responsibility, persistence operations, consuming layers, and observed persistence flow, and the available evidence supports that concrete persistence mechanisms remain encapsulated inside the data access layer, infrastructure layer, or equivalent responsible layer.

Use `Pass` when presentation, application, domain, business, or other upper layers request or consume persistence through permitted abstractions, stable contracts, identifiers, neutral data, or delegated operations while concrete commands, queries, mappings, connection or session management, technical persistence errors, and storage-specific details remain inside the responsible persistence layer.

Use `Pass` when the data access or infrastructure layer contains complex queries, mapping, pagination, ordering, technical filtering, materialization, derived data storage, or technical optimizations and the available evidence supports that these remain persistence access responsibilities rather than business rule ownership.

# Fail Conditions

Use `Fail` when direct evidence shows that concrete persistence access responsibilities are implemented, exposed, duplicated, or managed by presentation, application, domain, business, or other layers that are not assigned persistence access responsibility.

Use `Fail` when direct evidence shows that upper layers contain storage-specific commands, storage-specific queries, connection or session management, persistent mapping logic, technical persistence error handling, or storage-mechanism details in a way that makes those layers responsible for persistence access.

Use `Fail` when direct evidence shows that concrete persistence-specific types or storage details cross layer boundaries and materially condition behavior, contracts, or responsibilities of layers that should not depend on those persistence details.

Use `Fail` when direct evidence shows that persistence access is duplicated across non-responsible components or mixed with business behavior in a way that disperses persistence responsibility outside the layer assigned to that concern.

# Warning Conditions

Use `Warning` when evidence indicates partial, localized, emerging, indirect, duplicated, or ambiguous leakage of persistence access responsibilities outside the data access or infrastructure layer, but the available material does not justify a definitive `Fail`.

Use `Warning` when upper-layer code appears to contain persistence-specific behavior but the reviewed material leaves reasonable uncertainty about whether the behavior is a concrete persistence detail, a permitted abstraction, operation coordination, transaction control, technical transformation, business selection policy, or delegated persistence behavior.

Use `Warning` when documentation and implementation suggest different ownership for persistence responsibilities and the reviewed material shows a maintainability risk, but the evidence is not strong enough to conclude that concrete persistence access responsibilities are definitively implemented or exposed in non-responsible layers.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include persistence, does not include interaction with a persistent mechanism, does not include operations that read from or write to persistent storage, or includes only volatile operations without storage responsibility.

Use `Not Applicable` when the reviewed scope does not include an identifiable data access layer, infrastructure layer, or equivalent persistence responsibility because the declared architecture legitimately assigns persistence access responsibility in another clearly defined way.

Use `Not Applicable` when the review question concerns lower-level control over business policy, general layer responsibility clarity, dependency direction, presentation behavior, application or service coordination, domain or business rule ownership, layer bypassing, general layer contracts, repository modeling as a domain pattern, data access pattern correctness, ports and adapters, gateways, query quality, storage performance, transactional consistency, data security, physical storage modeling, or another architectural concern without requiring evaluation of persistence responsibility placement in a layered structure.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify the layered structure, identify the data access or infrastructure responsibility, identify persistence operations, inspect the actual data access flow, distinguish a permitted abstraction from a concrete persistence detail, determine where persistence details are implemented or exposed, or resolve conflicting signals.

Use `Not Enough Evidence` when there are signs of persistence but the responsible components, contracts, mappings, concrete mechanism interactions, or consuming layers are not available in the reviewed scope.

Use `Not Enough Evidence` when the only available signals are naming, folder structure, physical location, project names, namespace names, layer labels, repository-like names, store-like names, persistence-like names, incomplete references, isolated excerpts, documentation without implementation, dependency existence without usage, or absence of contrary evidence. Absence of evidence must not be converted into `Fail`.

Use `Not Enough Evidence` when documentation and implementation conflict, when persistence-specific type exposure is visible but its behavioral impact cannot be determined, when query logic cannot be distinguished from business selection policy, or when the real data access flow cannot be traced.

# Severity Guidance

Assign higher severity when persistence responsibility leakage affects many layers, broad portions of the reviewed scope, critical persistence operations, recurring flows, duplicated access paths, upper-layer dependence on concrete storage details, difficulty replacing the persistence mechanism, reduced testability, inconsistency risk, high evolution cost, or widespread mixing of persistence behavior and business rules.

Assign lower severity when the persistence leakage is narrow, isolated, peripheral, reversible, limited to one low-impact operation, or unlikely to affect broader maintainability of the layered structure.

Severity must distinguish localized low-impact leakage from recurring coupling across multiple flows, from systemic exposure of the persistence mechanism, and from widespread mixing of persistence details with business behavior. Severity must reflect demonstrated architectural and maintainability impact within the reviewed scope. Do not assign severity solely from the Layered Architecture category, the name of a layer, the presence of a query, the complexity of a query, transaction presence, persistence-like naming, or a numeric scoring formula.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the layered structure, the data access or infrastructure responsibility, the persistence operations, the consuming layers, where concrete persistence details are implemented or exposed, and whether those details remain encapsulated by the responsible layer.

Use `Likely` when multiple consistent evidence points support the evaluation but direct confirmation of persistence responsibility, concrete mechanism exposure, contract behavior, or flow through the layers is incomplete.

Use `Possible` when evidence is limited, indirect, partially ambiguous, or relies on weak supporting signals that suggest persistence encapsulation or leakage without conclusively establishing it.

Use `Not Enough Evidence` when the available material cannot support a reliable conclusion. Naming, directories, namespaces, layer labels, project names, physical placement, repository-like names, store-like names, persistence-like names, documentation alone, or absence of contrary evidence must not produce `Confirmed` confidence.

# Dependencies

LAYER-002, LAYER-003, LAYER-005, LAYER-006, LAYER-009. These are conceptual dependencies for shared layer responsibility, dependency direction, application or service coordination, business rule ownership, and layer contract vocabulary, not procedural prerequisites for evaluating this rule.

# References

LAYER_CATALOG.md

# Change Notes

Initial rule content for the Layered Architecture catalog.
