# Rule ID

CLEAN-003

# Title

Enterprise business rules must be independent from application business rules

# Category

Clean Architecture

# Status

Active

# Intent

Ensure entities are not coupled to use case orchestration or application workflow concerns.

# Applicability

Apply this rule when the reviewed material includes identifiable enterprise business rules, entities, domain policy code, or equivalent business-rule components, and identifiable application business rules, use cases, application workflows, orchestration components, or equivalent application-level coordination code.

# Rule Statement

Enterprise business rules must remain independent from application business rules, use case orchestration, and application workflow decisions.

# Rationale

Enterprise business rules represent policies that should remain stable across application workflows and delivery choices. When enterprise rules depend on use case orchestration or application workflow decisions, core business policy becomes tied to particular application flows, reducing reuse across use cases and making application-level change more likely to alter enterprise behavior.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed enterprise business rule scope, the reviewed application business rule scope, and the relationships between them. Direct evidence may include project or module references, dependency declarations, imports, namespace relationships, type dependencies, constructor dependencies, method behavior, method signatures, interface definitions, workflow coordination logic, orchestration dependencies, or reviewed code excerpts showing whether enterprise business rules depend on application business rules or are shaped by application workflow decisions.

Evidence must distinguish enterprise business decisions from application orchestration decisions. Naming conventions, folder names, entity labels, use case labels, or architectural intent may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible distinction between enterprise business rules and application business rules. Then inspect whether enterprise policy code depends on, invokes, requires, or is shaped by application workflows, use case orchestration, application-specific control flow, application transaction scripts, application request handling, or use case coordination decisions.

Evaluate only the independence of enterprise business rules from application business rules. Do not use this rule to evaluate general source dependency direction between technical details and policies, all entity dependencies on interface adapters, framework-specific type leakage into use cases, domain modeling quality, or whether use cases are isolated from infrastructure unless that evidence directly shows enterprise business rules coupled to application business rules.

Interpret evidence conservatively. A type name, folder name, or conventional label is not enough to classify code as an enterprise business rule or application business rule without corroborating evidence from dependencies, behavior, signatures, or reviewed excerpts. Prefer `Not Enough Evidence` when the reviewed material does not allow the reviewer to distinguish enterprise policy from application orchestration.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify relevant enterprise business rules and application business rules, and the available evidence supports that enterprise business rules do not depend on, require, invoke, or become shaped by use case orchestration or application workflow decisions.

# Fail Conditions

Use `Fail` when direct evidence shows that enterprise business rules depend on application business rules, use case classes, application workflow coordinators, application-specific orchestration decisions, application request or response flow, or other use case concerns within the reviewed scope.

# Warning Conditions

Use `Warning` when evidence indicates partial, inconsistent, indirect, duplicated, or ambiguous coupling between enterprise business rules and application business rules, but the available material does not justify a definitive `Fail`.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include identifiable enterprise business rules, entities, application business rules, use cases, application workflows, or orchestration concerns relevant to this rule.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify enterprise business rule scope, identify application business rule scope, inspect dependencies or behavior between them, distinguish business policy from application workflow, or resolve conflicting signals.

# Severity Guidance

Assign higher severity when coupling to application business rules affects central enterprise policy, multiple entities, broad use case families, or stable business-rule boundaries. Assign lower severity when the coupling is narrow, isolated, indirect, or limited to peripheral enterprise behavior. Severity must reflect the demonstrated architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the enterprise business rule scope, the application business rule scope, and the dependency or shaping relationship between them. Use `Likely` when multiple evidence points support the evaluation but direct confirmation is incomplete. Use `Possible` when evidence is limited, indirect, or partially ambiguous. Use `Not Enough Evidence` when the material cannot support a reliable conclusion. Naming alone must not produce `Confirmed` confidence.

# Dependencies

None

# References

CA_CATALOG.md

# Change Notes

None
