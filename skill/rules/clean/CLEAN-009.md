# Rule ID

CLEAN-009

# Title

Gateways must isolate use cases from external systems

# Category

Clean Architecture

# Status

Active

# Intent

Ensure use cases express external needs through boundary abstractions rather than concrete external mechanisms.

# Applicability

Apply this rule when the reviewed material includes identifiable Clean Architecture use cases, gateway interfaces, gateway implementations, boundary abstractions, external systems, external services, infrastructure mechanisms, persistence mechanisms, messaging mechanisms, integration mechanisms, or equivalent external-system interactions required by application business rules.

# Rule Statement

Gateways must isolate use cases from external systems by exposing boundary abstractions that represent use case needs rather than concrete external mechanisms.

# Rationale

Gateways allow use cases to express the need for external data or external actions without depending on the details of external systems. When use cases depend on concrete external mechanisms instead of gateway boundaries, application business rules become coupled to external APIs, storage mechanisms, messaging mechanisms, integration protocols, or infrastructure behavior. This makes external system changes more likely to alter use case contracts and weakens the Clean Architecture boundary between application policy and technical detail.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed use case scope, the gateway boundary or equivalent abstraction, the gateway implementation or external-system-facing component, and the external system interaction. Direct evidence may include project or module references, dependency declarations, package references, imports, namespace relationships, type dependencies, constructor dependencies, method signatures, interface definitions, boundary abstractions, gateway method behavior, external API usage, persistence or messaging interaction behavior, integration contract usage, configuration dependencies, or reviewed code excerpts showing whether use cases interact through gateway boundaries or depend directly on external systems.

Evidence must distinguish gateway boundary abstractions from concrete external mechanisms and adapter implementations. Naming conventions, folder names, gateway labels, repository labels, service labels, or architectural intent may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible Clean Architecture distinction between use cases, gateway boundaries, gateway implementations, and external systems. Then inspect whether use cases express external needs through boundary abstractions and whether concrete external system details remain outside the use case boundary.

Evaluate only gateway isolation of use cases from external systems. Do not use this rule to duplicate the full Hexagonal Architecture evaluation of outbound ports, adapter implementation relationships, port ownership, persistence boundaries, messaging boundaries, or general dependency direction unless that evidence directly shows whether Clean Architecture gateways isolate use cases from external systems. Do not use this rule to evaluate controller delegation, presenter decisions, or general adapter translation unless that evidence directly affects gateway isolation.

Interpret evidence conservatively. The existence of a type named as a gateway, repository, service, or client is not enough to prove isolation unless evidence shows the boundary role, dependency direction, and use case interaction. Prefer `Not Enough Evidence` when the reviewed material does not allow the reviewer to identify the use case boundary, the gateway abstraction, the external system, or the concrete interaction path.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify relevant use cases, gateway boundaries, external systems, and interaction paths, and the available evidence supports that use cases express external needs through boundary abstractions while concrete external system mechanisms remain outside use case behavior.

# Fail Conditions

Use `Fail` when direct evidence shows that use cases depend directly on concrete external systems, external APIs, infrastructure clients, persistence mechanisms, messaging mechanisms, integration protocols, gateway implementations, external configuration details, or other external mechanism details instead of gateway boundary abstractions.

# Warning Conditions

Use `Warning` when evidence indicates partial, inconsistent, indirect, implicit, or ambiguous gateway isolation, but the available material does not justify a definitive `Fail`. Use `Warning` when a gateway boundary exists but appears partly shaped by concrete external system details without enough evidence to classify the issue conclusively.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include identifiable use cases, external system interactions, gateway boundaries, gateway implementations, boundary abstractions, or external mechanisms relevant to this rule.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify use case scope, identify external system interactions, identify gateway abstractions, inspect dependency direction or interaction behavior, distinguish boundary abstractions from concrete mechanisms, or resolve conflicting signals.

# Severity Guidance

Assign higher severity when direct use case coupling to external systems affects central application behavior, broad integration surfaces, multiple external mechanisms, or stable use case boundaries. Assign lower severity when the coupling is narrow, isolated, indirect, or limited to peripheral external interactions. Severity must reflect the demonstrated architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the use case scope, the external system interaction, the gateway boundary or lack of one, and the dependency or interaction path. Use `Likely` when multiple evidence points support the evaluation but direct confirmation is incomplete. Use `Possible` when evidence is limited, indirect, or partially ambiguous. Use `Not Enough Evidence` when the material cannot support a reliable conclusion. Naming alone must not produce `Confirmed` confidence.

# Dependencies

CLEAN-004, CLEAN-006. These are conceptual dependencies for shared use case isolation, interface adapter, and boundary abstraction vocabulary, not procedural prerequisites for evaluating this rule.

# References

CA_CATALOG.md

# Change Notes

None
