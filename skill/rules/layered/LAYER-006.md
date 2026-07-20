# Rule ID

LAYER-006

# Title

Domain or business layer must own business rules

# Category

Layered Architecture

# Status

Active

# Intent

Ensure business rules are located in the layer assigned to domain or business responsibility rather than scattered across other layers.

# Applicability

Apply this rule when the reviewed material includes an identifiable layered architecture structure, an identifiable domain layer, business layer, or equivalent business responsibility, and business rules or business decisions relevant to the reviewed scope.

The rule is relevant when the reviewed scope provides enough evidence to determine where business rules are implemented, delegated, duplicated, or made authoritative across the identified layers. The rule applies whether the domain or business layer is large or small, whether it uses rich or passive structures, and whether the internal business logic style is object-oriented, procedural, functional, service-oriented, or another local design approach.

Do not apply this rule only because files, projects, namespaces, folders, or components use domain-like, business-like, policy-like, rule-like, or service-like names. The rule requires enough evidence to identify the business responsibility and evaluate whether business rules remain under that responsibility rather than being dispersed across presentation, application, infrastructure, data access, or other non-responsible layers.

# Rule Statement

Business rules in a layered architecture must be owned by the layer assigned to domain or business responsibility rather than being primarily maintained, duplicated, or dispersed across layers that do not own business behavior.

# Rationale

Layered Architecture relies on business decisions having an identifiable architectural home so that business behavior can be understood, changed, tested, and reused without coordinating changes across layers that serve other responsibilities. When business rules are scattered across presentation, application, infrastructure, data access, or other non-responsible layers, the system becomes harder to reason about because the source of business authority is unclear and different execution paths may apply different behavior.

This concern is different from requiring a specific domain modeling style. A domain or business layer may legitimately contain calculations, policies, decisions, eligibility rules, restrictions, semantic validations, state transitions, business-related behavior, composed decisions, and business invariants when those concepts fit the adopted model. The architectural concern appears when those rules are not owned by the layer declared or inferable as responsible for business behavior.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed layered structure, the domain layer, business layer, or equivalent business responsibility, the business rules or business decisions being evaluated, and where those rules are implemented, delegated, duplicated, or made authoritative.

Direct evidence may include implementation of domain or business components, implementation of presentation, application, infrastructure, and data access components, method behavior, branching behavior, calculations, policies, semantic validations, state transition behavior, rule checks, decision flows, tests that demonstrate business behavior, tests that demonstrate application behavior, architectural documentation, architectural decisions, dependencies between layers, duplicated behavior, divergent behavior between flows, or change history that shows rule ownership.

Evidence should prioritize executable implementation first, tests that demonstrate the decision second, structural distribution of behavior third, architecture documentation and decisions fourth, and naming or physical location only as auxiliary supporting evidence.

Evidence must distinguish business rules from application rules, coordination, technical validation, data transformation, data access, operational policy, technical mechanisms, and domain or business responsibility. Naming conventions, folder names, project names, namespaces, layer labels, or physical location may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible layered architecture interpretation and whether a domain layer, business layer, or equivalent business responsibility can be identified. Then inspect the relevant business behavior and determine whether business rules are owned by that responsibility or are primarily implemented, duplicated, or dispersed across layers assigned to other concerns.

Evaluate only architectural ownership and distribution of business rules. Do not use this rule to evaluate lower-level control over business policy decisions, general clarity of all layer responsibilities, declared dependency direction, presentation responsibility placement, application or service layer coordination by itself, data access responsibility placement, layer bypassing, layer contract integrity, domain model quality, tactical domain modeling patterns, aggregate correctness, invariant modeling quality, bounded contexts, domain language, use case boundaries, ports and adapters, policy rings, or formal enterprise application patterns.

Interpret evidence conservatively. A business rule may be delegated without being physically implemented in the same component that exposes the business layer boundary. Physical location alone does not prove rule ownership, and naming such as domain, business, policy, rule, service, or equivalent names must not produce a `Confirmed` conclusion without corroborating behavior. The presence of conditionals outside the domain or business layer does not automatically indicate a violation because conditionals may represent coordination, technical validation, authorization, routing, data adaptation, error handling, response composition, or operational flow.

Do not require a universal internal form for the domain or business layer. The rule does not require rich entities, aggregates, value objects, domain services, repositories, domain events, an object-oriented domain model, pure functions, one class per rule, a minimum number of components, a separate project or module, or adoption of any domain modeling method. A small business layer may be legitimate when the relevant business rules remain under its authority, and the absence of rich classes, aggregates, or value objects must not be converted into `Fail`.

Common finding patterns include business rules implemented exclusively in presentation code, rules maintained only in application or service operations, business decisions embedded in persistence behavior or queries, policies determined by infrastructure components, duplicated rules across multiple layers, domain or business layers reduced to passive structures while other layers concentrate decisions, divergent behavior between flows caused by the absence of a central rule owner, and changes to a rule requiring coordinated edits across multiple non-responsible layers. These patterns support findings only when corroborated by evidence that the behavior is a business rule and that the domain or business layer does not own it.

Do not automatically treat format transformation, syntactic validation, structural validation, operational authorization checks, transaction control, technical failure handling, data access, technical filtering, response composition, routing, logging, observability, interface-specific rules, or decisions legitimately assigned to the application layer as violations. Use of data in a decision does not prove that the data access layer owns the rule, and apparent duplication requires confirmation of semantic equivalence before supporting a finding.

Remediation guidance should focus on restoring business rule ownership to the layer assigned to domain or business responsibility while preserving legitimate responsibilities of presentation, application, infrastructure, data access, and other layers. Recommendations should be derived from finding evidence and must not prescribe a specific framework, language, technology, domain modeling technique, or formal architecture style as a universal requirement.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify the relevant layered structure, the domain or business responsibility, the business rules being evaluated, and the distribution of those rules, and the available evidence supports that the relevant business rules are owned by the domain or business layer.

Use `Pass` when other layers perform interaction handling, coordination, operational authorization, transaction control, technical validation, data transformation, data access, response composition, routing, logging, observability, or other legitimate responsibilities while delegating business decisions to the responsible domain or business layer.

Use `Pass` when the domain or business layer is small, internally simple, or uses passive structures, provided the available evidence supports that business rule authority remains in that layer or in components assigned to that business responsibility.

# Fail Conditions

Use `Fail` when direct evidence shows that relevant business rules are primarily maintained, determined, hidden, or made authoritative in presentation, application, infrastructure, data access, or other layers that are not assigned domain or business responsibility.

Use `Fail` when direct evidence shows that the same business rule is duplicated across multiple layers in a way that disperses rule ownership, creates divergent behavior, or requires coordinated changes outside the responsible domain or business layer.

Use `Fail` when direct evidence shows that the domain or business layer is reduced to passive structures while business calculations, policies, eligibility decisions, semantic validations, state transitions, restrictions, or business outcome selection are concentrated in layers assigned to other responsibilities.

Use `Fail` when direct evidence shows that business behavior differs between flows because no responsible domain or business layer component owns the rule consistently within the reviewed layered architecture.

# Warning Conditions

Use `Warning` when evidence indicates partial, localized, emerging, indirect, duplicated, or ambiguous dispersion of business rules outside the domain or business layer, but the available material does not justify a definitive `Fail`.

Use `Warning` when the domain or business layer appears to be losing authority over relevant business decisions, but the reviewed material leaves reasonable uncertainty about whether the observed behavior is a business rule, an application rule, coordination, technical validation, data access, operational policy, or delegated business behavior.

Use `Warning` when documentation and implementation suggest different ownership for business rules and the reviewed material shows a maintainability risk, but the evidence is not strong enough to conclude that business rules are definitively dispersed or primarily owned by non-responsible layers.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include an identifiable layered architecture structure, does not include an identifiable domain layer, business layer, or equivalent business responsibility, or does not include relevant business rules or business decisions.

Use `Not Applicable` when the layered model adopted by the reviewed system clearly assigns business rule responsibility to another explicitly defined layer and the review question does not require evaluation of domain or business layer ownership.

Use `Not Applicable` when the review question concerns lower-level detail control over business policy, general layer responsibility clarity, dependency direction, presentation responsibility, application or service coordination, data access responsibility, layer bypassing, layer contracts, domain model quality, tactical domain modeling patterns, use case boundaries, ports and adapters, formal enterprise application patterns, or another architectural concern without requiring evaluation of where business rules are owned in the layered structure.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify the layered structure, identify the domain or business responsibility, identify relevant business rules, inspect the behavior that implements those rules, determine where the rules are authoritative, distinguish business rules from coordination or technical logic, or resolve conflicting signals.

Use `Not Enough Evidence` when the business layer is identifiable but the behavior of that layer or its collaborators is not available in the reviewed scope.

Use `Not Enough Evidence` when the only available signals are naming, folder structure, physical location, project names, namespace names, layer labels, isolated excerpts, incomplete documentation, dependency existence, call sequence without behavior, or absence of contrary evidence. Absence of evidence must not be converted into `Fail`.

Use `Not Enough Evidence` when apparent duplication cannot be confirmed as semantically equivalent, when documentation and implementation conflict, when only structural placement is visible without behavior, or when the architecture declaration does not clarify where business rules should reside.

# Severity Guidance

Assign higher severity when misplaced or dispersed business rules affect critical rules, central business behavior, broad portions of the reviewed scope, many layers, many callers, recurring policies, duplicated decisions, divergent behavior, high inconsistency risk, difficult rule evolution, reduced testability, reduced maintainability, or systemic loss of domain or business layer authority.

Assign lower severity when rule dispersion is narrow, isolated, peripheral, reversible, limited to one low-impact rule, or unlikely to affect broader maintainability of the layered structure.

Severity must distinguish a localized low-impact rule from recurring dispersion of business rules, from systemic absence of business layer authority, and from critical decisions controlled outside the responsible layer. Severity must reflect demonstrated architectural and maintainability impact within the reviewed scope. Do not assign severity solely from the Layered Architecture category, the name of a layer, the presence of conditionals, the size of the business layer, the absence of rich domain structures, or a numeric scoring formula.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the layered structure, the domain or business responsibility, the relevant business rules, where those rules are implemented or delegated, and whether the domain or business layer owns those rules.

Use `Likely` when multiple consistent evidence points support the evaluation but direct confirmation of business rule ownership, delegation, layer responsibility, or behavior distribution is incomplete.

Use `Possible` when evidence is limited, indirect, partially ambiguous, or relies on weak supporting signals that suggest business rule ownership or dispersion without conclusively establishing it.

Use `Not Enough Evidence` when the available material cannot support a reliable conclusion. Naming, directories, namespaces, layer labels, project names, physical placement, documentation alone, or absence of contrary evidence must not produce `Confirmed` confidence.

# Dependencies

LAYER-001, LAYER-002, LAYER-005, LAYER-007. These are conceptual dependencies for shared business policy authority, layer responsibility, application or service coordination, and data access boundary vocabulary, not procedural prerequisites for evaluating this rule.

# References

LAYER_CATALOG.md

# Change Notes

Initial rule content for the Layered Architecture catalog.
