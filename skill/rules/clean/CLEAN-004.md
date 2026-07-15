# Rule ID

CLEAN-004

# Title

Use cases must remain isolated from delivery and infrastructure concerns

# Category

Clean Architecture

# Status

Active

# Intent

Ensure application business rules are not shaped by user interfaces, databases, frameworks, or external mechanisms.

# Applicability

Apply this rule when the reviewed material includes identifiable Clean Architecture use cases, application business rules, interactors, handlers, application services, or equivalent application-level orchestration components, and identifiable delivery mechanisms, infrastructure mechanisms, databases, frameworks, external systems, or other external mechanisms that may interact with those use cases.

# Rule Statement

Use cases must remain isolated from delivery mechanisms, infrastructure mechanisms, databases, frameworks, and external mechanisms.

# Rationale

Use cases represent application business rules and should express application-specific policy independently from technical mechanisms. When use cases are shaped by delivery, infrastructure, database, framework, or external mechanism concerns, application behavior becomes harder to reason about independently, technical changes can alter use case behavior, and the use case boundary loses stability.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed use case scope and the delivery, infrastructure, database, framework, or external mechanism concerns that may shape it. Direct evidence may include project or module references, dependency declarations, package references, imports, namespace relationships, type dependencies, constructor dependencies, method behavior, method signatures, boundary interfaces, configuration dependencies, persistence interactions, external mechanism interactions, or reviewed code excerpts showing whether use cases are isolated from or shaped by those concerns.

Evidence must distinguish use case behavior and application business rules from adapter translation, delivery coordination, infrastructure implementation, configuration wiring, and external mechanism details. Naming conventions, folder names, architectural intent, or repeated labels may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible Clean Architecture distinction between use cases and delivery or infrastructure concerns. Then inspect whether use case behavior, dependencies, contracts, control flow, or boundary decisions are shaped by user interface mechanisms, database mechanisms, framework mechanisms, external system mechanisms, infrastructure configuration, delivery-specific control flow, or technical integration concerns.

Evaluate only use case isolation from delivery and infrastructure concerns. Do not use this rule to duplicate the narrower evaluation of framework-specific types crossing into use case boundaries, which belongs to `CLEAN-001`. Do not use this rule to evaluate general port ownership, adapter implementation conformance, all source dependency direction between policies and details, presenter responsibilities, controller responsibilities, gateway responsibilities, or testing strategy unless that evidence directly shows delivery or infrastructure concerns shaping use cases.

Interpret evidence conservatively. The presence of a delivery or infrastructure package near use case code is not enough by itself unless the evidence shows that the concern shapes use case behavior, dependencies, contracts, or execution requirements. Prefer `Not Enough Evidence` when the reviewed material does not allow the reviewer to identify use cases or determine whether technical concerns shape them.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify relevant use cases and delivery or infrastructure concerns, and the available evidence supports that use cases remain isolated from user interfaces, databases, frameworks, infrastructure mechanisms, external systems, and other external mechanisms.

# Fail Conditions

Use `Fail` when direct evidence shows that use cases depend on, require, invoke directly, or are shaped by delivery mechanisms, infrastructure mechanisms, database mechanisms, framework mechanisms, external system mechanisms, infrastructure configuration, technical lifecycle concerns, or external integration details within the reviewed scope.

# Warning Conditions

Use `Warning` when evidence indicates partial, inconsistent, indirect, emerging, or ambiguous delivery or infrastructure influence on use cases, but the available material does not justify a definitive `Fail`.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include identifiable use cases, application business rules, delivery mechanisms, infrastructure mechanisms, databases, frameworks, external mechanisms, or related interactions relevant to this rule.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify use case scope, identify delivery or infrastructure concerns, inspect dependencies or behavior at the use case boundary, determine whether technical concerns shape use cases, or resolve conflicting signals.

# Severity Guidance

Assign higher severity when delivery or infrastructure concerns shape central use cases, broad application business rule surfaces, multiple technical mechanisms, or stable use case boundaries. Assign lower severity when the influence is narrow, isolated, indirect, or limited to peripheral use case behavior. Severity must reflect the demonstrated architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the use case scope, the delivery or infrastructure concern, and the dependency or shaping relationship between them. Use `Likely` when multiple evidence points support the evaluation but direct confirmation is incomplete. Use `Possible` when evidence is limited, indirect, or partially ambiguous. Use `Not Enough Evidence` when the material cannot support a reliable conclusion. Naming alone must not produce `Confirmed` confidence.

# Dependencies

None

# References

CA_CATALOG.md

# Change Notes

None
