# Rule ID

LAYER-004

# Title

Presentation layer must not own application or business behavior

# Category

Layered Architecture

# Status

Active

# Intent

Ensure presentation code handles interaction concerns without containing application workflow or business rules.

# Applicability

Apply this rule when the reviewed material includes an identifiable layered architecture structure and an identifiable presentation layer or equivalent presentation responsibility that handles interaction with users, external clients, or consumers.

The rule is relevant when the reviewed scope provides enough evidence to inspect whether presentation code is limited to interaction concerns, request reception, response presentation, input and output adaptation, and delegation to the layers responsible for application workflow or business behavior.

Do not apply this rule only because files, projects, namespaces, folders, or components use presentation-like names. The rule requires enough evidence to identify presentation responsibility and to evaluate whether the behavior in that layer remains limited to interaction concerns or owns application workflow or business rules.

# Rule Statement

Presentation layer code in a layered architecture must handle interaction, input and output adaptation, and delegation without owning application workflow or business rules.

# Rationale

Layered Architecture separates presentation concerns from application and business behavior so that interaction mechanisms can change without changing workflow decisions or business rules. When presentation code owns workflow or business behavior, the system becomes harder to maintain because behavior that should be reusable beyond a specific interaction path is coupled to presentation entry points, response shaping, protocol handling, or client-facing concerns.

This risk is different from ordinary presentation responsibility. Presentation code may receive requests, validate technical input shape, adapt protocol data, transform formats, choose response representations, and delegate to another layer without becoming the owner of application workflow or business rules. The architectural concern appears when the presentation layer determines behavior that belongs to application coordination or business policy rather than merely adapting and forwarding interaction.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed layered structure, the presentation layer or equivalent presentation responsibility, the behavior implemented in presentation code, and whether that behavior is interaction handling, input or output adaptation, delegation, application workflow, or business rule logic.

Direct evidence may include project or module references, dependency declarations, namespace relationships, imports, type dependencies, constructor dependencies, method behavior, branching behavior, validation behavior, orchestration behavior, response construction behavior, reviewed code excerpts, or documentation tied to the reviewed layered structure.

Evidence must distinguish presentation interaction concerns from application workflow and business rules. Technical validations, protocol adaptation, request parsing, response formatting, transport-specific status handling, and transformation between external and internal formats do not by themselves characterize business behavior or application workflow.

Evidence should show where the relevant behavior is actually implemented and who determines the workflow or business outcome. Naming conventions, folder names, project names, layer labels, controller-like names, endpoint-like names, view-like names, or physical location may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence. Physical location alone must not produce `Confirmed` confidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible layered architecture interpretation and whether a presentation layer or equivalent presentation responsibility can be identified. Then inspect the behavior in presentation code and determine whether it remains limited to interaction handling, input and output adaptation, response presentation, and delegation, or whether it owns application workflow or business rules.

Evaluate only presentation-layer ownership of application or business behavior. Do not use this rule to evaluate general dependency direction, global layer responsibility definition, lower-level control over business policy, application or service layer responsibility, domain or business layer responsibility, data access layer responsibility, bypassing required intermediate layers, layer contract integrity, ports and adapters, Clean Architecture controllers, Hexagonal Architecture adapters, use cases, Domain-Driven Design patterns, or framework-specific conventions.

Interpret evidence conservatively. Delegation from presentation code to another layer is expected behavior and does not by itself indicate a violation. Technical validation in the presentation layer may be valid when it checks input shape, required technical fields, parseability, protocol constraints, or interaction-level preconditions. Protocol adaptation and format transformation do not by themselves characterize application workflow or business rules.

Common finding patterns include presentation code coordinating multi-step application workflows, selecting business outcomes, enforcing business rules, making domain-significant decisions, controlling state transitions, or duplicating behavior that the reviewed layered structure assigns to application, service, domain, or business layers. These patterns support findings only when corroborated by evidence that the presentation layer owns the relevant workflow or business behavior rather than merely adapting input, presenting output, or delegating.

When the reviewed material shows behavior in presentation code but does not reveal whether another layer owns the workflow or business decision, use `Not Enough Evidence` instead of speculation. Absence of evidence that another layer exists, or absence of observed delegation in an incomplete scope, must not be converted automatically into `Fail`.

Remediation guidance should focus on moving application workflow or business rules out of presentation code while preserving presentation responsibilities for interaction handling, adaptation, response presentation, and delegation. Recommendations should be derived from the finding evidence and should avoid prescribing a specific framework, technology, Clean Architecture construct, Hexagonal Architecture construct, use case model, or Domain-Driven Design pattern.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify the relevant layered structure, presentation responsibility, and behavior in presentation code, and the available evidence supports that presentation code handles interaction, input and output adaptation, response presentation, and delegation without owning application workflow or business rules.

Use `Pass` when technical validation, protocol adaptation, format transformation, response shaping, or delegation appears in presentation code and the available evidence supports that application workflow and business decisions are owned by another responsible layer within the reviewed layered structure.

# Fail Conditions

Use `Fail` when direct evidence shows that presentation code owns, determines, hides, or materially controls application workflow that belongs outside the presentation layer within the reviewed layered architecture.

Use `Fail` when direct evidence shows that presentation code owns, determines, hides, or materially controls business rules, business decisions, domain-significant state transitions, or business outcome selection that belongs outside the presentation layer.

Use `Fail` when direct evidence shows that presentation code contains behavior that the reviewed layered structure assigns to application, service, domain, or business layers in a way that makes presentation more than an interaction and adaptation boundary.

# Warning Conditions

Use `Warning` when evidence indicates partial, localized, duplicated, emerging, indirect, or ambiguous application workflow or business behavior in presentation code, but the available material does not justify a definitive `Fail`.

Use `Warning` when presentation code appears to make workflow or business decisions but the reviewed material leaves reasonable uncertainty about whether the behavior is only technical validation, protocol adaptation, format transformation, response selection, or delegated behavior.

Use `Warning` when documentation and implementation suggest different presentation responsibilities and the reviewed material shows a maintainability risk, but the evidence is not strong enough to conclude that presentation definitively owns application workflow or business rules.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include an identifiable layered architecture structure, does not include an identifiable presentation layer or equivalent presentation responsibility, or concerns material outside Layered Architecture presentation responsibility evaluation.

Use `Not Applicable` when the review question concerns general dependency direction, global layer responsibility definition, lower-level control over business policy, application or service layer coordination, domain or business rule ownership, data access responsibility, layer bypassing, layer contracts, ports and adapters, Clean Architecture controllers, Hexagonal Architecture adapters, use cases, Domain-Driven Design, or another architectural concern without requiring evaluation of presentation-layer ownership of application or business behavior.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify the layered structure, identify the presentation responsibility, inspect presentation behavior, determine where application workflow or business behavior is implemented, distinguish technical validation from business rules, distinguish protocol or format adaptation from workflow ownership, or resolve conflicting signals.

Use `Not Enough Evidence` when the only available signals are naming, folder structure, physical location, project names, namespace names, layer labels, isolated excerpts, incomplete documentation, endpoint lists, route declarations, response names, dependency existence, or absence of contrary evidence. Absence of evidence must not be converted into `Fail`.

Use `Not Enough Evidence` when presentation code is visible but the reviewed scope does not show whether observed workflow-like or rule-like behavior is actually implemented in presentation code or delegated to another responsible layer.

# Severity Guidance

Assign higher severity when presentation ownership of application workflow or business rules affects central user or client journeys, broad interaction surfaces, critical business outcomes, stable layer boundaries, many callers, or behavior that should be reusable outside a specific presentation path.

Assign lower severity when the misplaced behavior is narrow, isolated, peripheral, reversible, limited to a small interaction path, or has minor architectural impact within the reviewed scope.

Severity must reflect demonstrated architectural and maintainability impact within the reviewed scope. Do not assign severity solely from the Layered Architecture category, the name of a layer, presentation-like naming, physical location, dependency presence, or the use of interaction-oriented components.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the layered structure, the presentation layer or equivalent presentation responsibility, the behavior implemented in presentation code, and whether that behavior owns or does not own application workflow or business rules.

Use `Likely` when multiple evidence points support the evaluation but direct confirmation of behavior ownership, layer responsibility, or delegation is incomplete.

Use `Possible` when evidence is limited, indirect, partially ambiguous, or relies on weak supporting signals that suggest presentation ownership or non-ownership of application or business behavior without conclusively establishing it.

Use `Not Enough Evidence` when the available material cannot support a reliable conclusion. Naming, layer labels, folder location, project names, namespace names, physical placement, route names, endpoint names, or absence of contrary evidence alone must not produce `Confirmed` confidence.

# Dependencies

LAYER-002, LAYER-005, LAYER-006. These are conceptual dependencies for shared layer identification, application or service workflow vocabulary, and business rule ownership vocabulary, not procedural prerequisites for evaluating this rule.

# References

LAYER_CATALOG.md

# Change Notes

Initial rule content for the Layered Architecture catalog.
