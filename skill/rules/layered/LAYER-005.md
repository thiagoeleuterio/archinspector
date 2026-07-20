# Rule ID

LAYER-005

# Title

Application or service layer must coordinate without owning business rules

# Category

Layered Architecture

# Status

Active

# Intent

Ensure application or service layer code orchestrates work without becoming the owner of business rules.

# Applicability

Apply this rule when the reviewed material includes an identifiable layered architecture structure and an identifiable application layer, service layer, or equivalent application coordination responsibility.

The rule is relevant when that layer coordinates operations, interactions, execution flow, application-level authorization, operation boundaries, unit-of-work lifecycle, result composition, external action requests, or similar application workflow responsibilities, and the reviewed scope provides enough evidence to distinguish coordination from ownership of business rules.

Do not apply this rule only because files, projects, namespaces, folders, or components use application-like or service-like names. The rule requires enough evidence to identify application or service responsibility and to evaluate whether behavior in that layer remains coordination or becomes business rule ownership.

# Rule Statement

Application or service layer code in a layered architecture must coordinate operations and delegate business decisions without owning the business rules that determine business behavior.

# Rationale

Layered Architecture often assigns the application or service layer responsibility for coordinating operations while another responsible layer owns the business rules that determine business behavior. This separation allows operation flow, interaction sequencing, transaction boundaries, authorization checks, integration requests, and result composition to evolve without making the coordination layer the authoritative place for business policy.

This risk is different from ordinary application or service coordination. An application or service layer may select collaborators, control execution sequence, start or end a unit of work, apply application-level authorization, handle operational errors, transform data between input and output contracts, publish results, request external actions, and delegate decisions to responsible components without violating this rule. The architectural concern appears when business decisions, policies, calculations, state transitions, or domain-significant outcomes are determined directly by the application or service layer instead of being delegated to the layer or component responsible for business behavior.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed layered structure, the application layer, service layer, or equivalent coordination responsibility, the operation being coordinated, the business decision or rule being evaluated, and where that decision or rule is actually implemented.

Direct evidence may include implementation of application services, service components, operation handlers, workflow coordinators, method behavior, branching behavior, rule checks, calculations, state transition behavior, delegation to business components, flow of calls between layers, unit or integration tests, operation contracts, architecture documentation, architectural decisions, dependencies used by the layer, or reviewed code excerpts tied to the reviewed layered structure.

Evidence must distinguish coordination of an operation from business decision ownership. Coordination includes sequencing steps, selecting collaborators, delimiting operations, managing an operation lifecycle, applying application-level authorization, checking availability of required data, handling operational or integration failures, maintaining idempotency, composing responses, adapting data, logging, tracing, and delegating decisions. Business decision ownership includes determining business policy, enforcing business rules, owning business calculations, deciding domain-significant behavior, maintaining invariants only inside orchestration, or making business outcomes depend on one application flow without delegation to the responsible business layer or component.

Evidence should prioritize executable implementation, tests that demonstrate responsibility, structural flow between components, contracts, documentation, and architectural decisions. Naming conventions, folder names, project names, namespace names, service-like labels, application-like labels, or physical location may support interpretation but must not be treated as conclusive evidence without corroborating behavioral or structural evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible layered architecture interpretation and whether an application layer, service layer, or equivalent coordination responsibility can be identified. Then inspect the operation flow and determine whether the layer coordinates execution while delegating business decisions, or whether it directly owns rules that determine business behavior.

Evaluate only application or service layer ownership of business rules. Do not use this rule to evaluate whether lower-level details control business policy, whether layer responsibilities are generally clear, whether dependencies follow the declared direction, whether presentation code owns workflow or business behavior, whether the domain or business layer generally owns all business rules, whether data access responsibilities are correctly placed, whether layers bypass required intermediate layers, whether layer contracts preserve boundary integrity, whether the domain model is rich or anemic, whether aggregates enforce invariants, whether domain services are used, whether use case patterns are present, whether ports and adapters are present, or whether a named service layer pattern is formally implemented.

Interpret evidence conservatively. The size of an application service, the number of dependencies it uses, the presence of conditional logic, or complex orchestration does not by itself prove business rule ownership. A conditional may represent technical flow, operational handling, application authorization, idempotency, existence checks, collaborator selection, response composition, data adaptation, or another application concern rather than a business rule. Use `Not Enough Evidence` when the reviewed material does not allow that distinction to be made.

Delegation must be evaluated by where the decision is actually made, not by the presence of a call to a business component. Superficial delegation does not eliminate a violation when the application or service layer still selects the business outcome, performs the business calculation, or encodes the policy before or after the delegated call. Conversely, the absence of a visible domain class, business component, or separate rule object does not automatically create a `Fail` unless direct evidence shows that the application or service layer owns a business rule relevant to the reviewed layered structure.

Common finding patterns include business decisions implemented directly in application services, business calculations or policies maintained only in the coordination layer, conditionals that determine domain-significant behavior without delegation, invariants verified only during orchestration, duplicated business rules across multiple application services, behavior that depends on entering through one specific application flow, or domain or business layers reduced to passive structures while the application or service layer concentrates relevant business decisions. These patterns support findings only when corroborated by evidence that the behavior is a business rule rather than legitimate coordination.

Remediation guidance should focus on moving business decision ownership to the responsible business layer or component while preserving the application or service layer's coordination responsibilities. Recommendations should be derived from finding evidence and should avoid prescribing a specific framework, language, technology, Clean Architecture structure, Domain-Driven Design tactical pattern, or Fowler pattern as a universal requirement.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify the relevant layered structure, application or service responsibility, coordinated operation, business decisions involved, and delegation path, and the available evidence supports that the application or service layer coordinates operations without owning business rules.

Use `Pass` when the application or service layer performs sequencing, collaborator selection, operation boundary control, unit-of-work lifecycle management, application-level authorization, operational error handling, data transformation, external action requests, result composition, technical validation, idempotency control, logging, tracing, or sequential collaborator calls, and the available evidence supports that business decisions are delegated to the responsible business layer or component.

# Fail Conditions

Use `Fail` when direct evidence shows that the application or service layer owns, determines, hides, duplicates, or materially controls business rules that belong to a responsible business layer or component within the reviewed layered architecture.

Use `Fail` when direct evidence shows business calculations, business policies, domain-significant state transitions, invariant enforcement, or business outcome selection implemented directly in the application or service layer in a way that makes that layer the authoritative owner of the rule.

Use `Fail` when direct evidence shows that business behavior depends on entering through a specific application or service operation because the relevant business rule is implemented only in that operation and is not delegated to the responsible business layer or component.

# Warning Conditions

Use `Warning` when evidence indicates partial, localized, duplicated, emerging, indirect, or ambiguous concentration of business decision-making in the application or service layer, but the available material does not justify a definitive `Fail`.

Use `Warning` when application or service code appears to make business decisions but the reviewed material leaves reasonable uncertainty about whether the behavior is application flow control, technical validation, operational authorization, collaborator selection, response composition, data adaptation, or delegated business behavior.

Use `Warning` when documentation and implementation suggest different ownership for business rules and the reviewed material shows a maintainability risk, but the evidence is not strong enough to conclude that the application or service layer definitively owns the business rule.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include an identifiable layered architecture structure, does not include an identifiable application layer, service layer, or equivalent coordination responsibility, or does not include operations coordinated by that layer.

Use `Not Applicable` when the review question concerns lower-level detail control over business policy, general layer responsibility clarity, dependency direction, presentation layer responsibility, domain or business layer ownership, data access responsibility, layer bypassing, layer contracts, domain model quality, tactical domain modeling patterns, use case patterns, ports and adapters, formal service layer patterns, or another architectural concern without requiring evaluation of application or service layer ownership of business rules.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify the layered structure, identify the application or service responsibility, inspect the coordinated operation, determine where business decisions are implemented, distinguish business rules from application flow control, distinguish technical validation from business policy, verify delegation, or resolve conflicting signals.

Use `Not Enough Evidence` when the only available signals are naming, folder structure, physical location, project names, namespace names, layer labels, service-like names, handler-like names, manager-like names, dependency count, method size, isolated excerpts, incomplete documentation, call sequence without behavior, or absence of contrary evidence. Absence of evidence must not be converted into `Fail`.

Use `Not Enough Evidence` when application or service layer code is visible but the reviewed scope does not show whether rule-like behavior is actually a business decision, an application rule, a domain rule, a technical condition, or delegated behavior hidden in unavailable collaborators.

# Severity Guidance

Assign higher severity when application or service layer ownership of business rules affects critical business behavior, central workflows, many operations, stable layer boundaries, recurring policies, duplicated rule implementations, broad caller surfaces, difficult evolution paths, or decisions that create risk of inconsistent business outcomes.

Assign lower severity when the misplaced business decision is narrow, isolated, peripheral, reversible, limited to one low-impact operation, or unlikely to affect broader maintainability of the layered structure.

Severity must distinguish a localized low-impact decision from recurring concentration of business rules and from a system where the application or service layer systematically acts as the business core. Severity must reflect demonstrated architectural and maintainability impact within the reviewed scope. Do not assign severity solely from the Layered Architecture category, the name of a layer, the size of a service, the number of dependencies, the presence of conditionals, or a numeric scoring formula.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the layered structure, the application or service responsibility, the coordinated operation, the relevant business rule or decision, and whether the application or service layer owns or delegates that rule.

Use `Likely` when multiple evidence points support the evaluation but direct confirmation of business rule ownership, delegation, layer responsibility, or operation behavior is incomplete.

Use `Possible` when evidence is limited, indirect, partially ambiguous, or relies on weak supporting signals that suggest application or service layer ownership or non-ownership without conclusively establishing it.

Use `Not Enough Evidence` when the available material cannot support a reliable conclusion. Naming, layer labels, folder location, project names, namespace names, service-like names, handler-like names, manager-like names, documentation alone, or physical placement alone must not produce `Confirmed` confidence.

# Dependencies

LAYER-002, LAYER-004, LAYER-006. These are conceptual dependencies for shared layer identification, presentation boundary vocabulary, and business rule ownership vocabulary, not procedural prerequisites for evaluating this rule.

# References

LAYER_CATALOG.md

# Change Notes

Initial rule content for the Layered Architecture catalog.
