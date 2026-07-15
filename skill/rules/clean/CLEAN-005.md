# Rule ID

CLEAN-005

# Title

Entities must remain independent from use cases and interface adapters

# Category

Clean Architecture

# Status

Active

# Intent

Ensure enterprise business rules do not depend on application workflows or adapter concerns.

# Applicability

Apply this rule when the reviewed material includes identifiable entities, enterprise business rules, domain policy code, or equivalent enterprise-level business-rule components, and identifiable use cases, application workflows, interface adapters, delivery-facing components, presenter-facing components, gateway-facing components, or equivalent adapter concerns that may relate to those entities.

# Rule Statement

Entities must not depend on use cases or interface adapters.

# Rationale

Entities hold enterprise business rules and should remain independent from application workflow and adapter concerns. When entities depend on use cases or interface adapters, enterprise policy becomes structurally coupled to application-specific orchestration or external-facing translation details, reducing reuse and making changes outside the enterprise policy boundary more likely to affect entity behavior.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed entity or enterprise business rule scope, the reviewed use case scope, the reviewed interface adapter scope, and the dependency relationships between them. Direct evidence may include project or module references, dependency declarations, imports, namespace relationships, type dependencies, constructor dependencies, method signatures, method behavior, interface definitions, annotations or metadata that require adapter concerns, or reviewed code excerpts showing whether entities depend on use cases or interface adapters.

Evidence must distinguish entities and enterprise business rules from application workflow components and interface adapter components. Naming conventions, folder names, entity labels, adapter labels, or architectural intent may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible Clean Architecture distinction between entities, use cases, and interface adapters. Then inspect whether entities import, reference, instantiate, invoke, require, implement, expose, or otherwise depend on use case components, application workflow components, adapter-facing components, delivery models, presenter models, gateway implementation details, external-facing translation concerns, or other interface adapter concerns.

Evaluate only structural independence of entities from use cases and interface adapters. Do not use this rule to repeat the full evaluation of whether enterprise business rules are independent from application business rules, which belongs to `CLEAN-003`. Do not use this rule to evaluate general domain modeling quality, persistence mapping quality, framework-specific type leakage into use cases, use case isolation from infrastructure, or Hexagonal port and adapter conformance unless that evidence directly shows an entity depending on a use case or interface adapter.

Interpret evidence conservatively. A name, folder location, or conventional label is not enough to classify a dependency as an entity-to-use-case or entity-to-adapter dependency without corroborating structural or behavioral evidence. Prefer `Not Enough Evidence` when the reviewed material does not allow the reviewer to identify entities, use cases, interface adapters, or dependency direction.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify relevant entities, use cases, interface adapters, and dependency relationships, and the available evidence supports that entities do not depend on use cases or interface adapters.

# Fail Conditions

Use `Fail` when direct evidence shows that entities depend on use case components, application workflow components, application orchestration contracts, interface adapter components, delivery-facing models, presenter-facing models, gateway implementation details, external-facing translation concerns, or other adapter concerns within the reviewed scope.

# Warning Conditions

Use `Warning` when evidence indicates partial, indirect, inconsistent, cyclic, or ambiguous dependency from entities toward use cases or interface adapters, but the available material does not justify a definitive `Fail`.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include identifiable entities, enterprise business rules, use cases, interface adapters, or dependency relationships relevant to this rule.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify entity scope, identify use case scope, identify interface adapter scope, inspect dependency direction, distinguish structural dependency from incidental naming or placement, or resolve conflicting signals.

# Severity Guidance

Assign higher severity when entity dependencies on use cases or interface adapters affect central enterprise policy, broad entity surfaces, multiple workflows or adapters, or stable business-rule boundaries. Assign lower severity when the dependency is narrow, isolated, indirect, or limited to peripheral entity behavior. Severity must reflect the demonstrated architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the entity scope, the use case or interface adapter scope, and the dependency direction from entities toward use cases or adapters. Use `Likely` when multiple evidence points support the evaluation but direct confirmation is incomplete. Use `Possible` when evidence is limited, indirect, or partially ambiguous. Use `Not Enough Evidence` when the material cannot support a reliable conclusion. Naming alone must not produce `Confirmed` confidence.

# Dependencies

None

# References

CA_CATALOG.md

# Change Notes

None
