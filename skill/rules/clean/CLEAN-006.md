# Rule ID

CLEAN-006

# Title

Interface adapters must translate between external models and use case boundaries

# Category

Clean Architecture

# Status

Active

# Intent

Ensure adapter-facing components convert data across boundaries without exposing external models to use cases.

# Applicability

Apply this rule when the reviewed material includes identifiable Clean Architecture interface adapters, use cases, use case boundaries, boundary data structures, external models, delivery models, persistence models, transport models, framework models, external integration models, or equivalent data structures that cross between external mechanisms and application business rules.

# Rule Statement

Interface adapters must translate between external models and use case boundary models without making use cases depend on external models.

# Rationale

Interface adapters exist to convert data between the form required by external mechanisms and the form required by use cases. When external models cross directly into use case boundaries, application business rules become shaped by delivery, persistence, transport, framework, or integration details. This weakens boundary stability, makes external model changes more likely to affect use case contracts, and blurs the Clean Architecture distinction between interface adapters and application policies.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed interface adapter scope, the reviewed use case boundary scope, and the external models that may cross between them. Direct evidence may include project or module references, dependency declarations, package references, imports, namespace relationships, type dependencies, constructor dependencies, method signatures, interface definitions, boundary data structures, mapping or translation behavior, adapter method behavior, external request or response models, persistence or transport models, integration contract models, or reviewed code excerpts showing whether adapters translate external models before invoking or returning from use cases.

Evidence must distinguish external models from use case boundary models and domain-neutral data structures. Naming conventions, folder names, adapter labels, model suffixes, or architectural intent may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible Clean Architecture distinction between interface adapters, use case boundaries, and external models. Then inspect whether adapter-facing components convert incoming external data into use case boundary data before delegation and convert use case output into external-facing data after the use case boundary.

Evaluate only translation between external models and use case boundary models. Do not use this rule to evaluate controller delegation, presenter decision ownership, gateway isolation, data mapper responsibility, general source dependency direction, general framework type leakage, or full Hexagonal Architecture adapter model leakage unless that evidence directly shows whether interface adapters translate external models at a Clean Architecture use case boundary.

Interpret evidence conservatively. A type name, directory name, or model suffix is not enough to prove that a data structure is external or boundary-owned. Prefer `Not Enough Evidence` when the reviewed material does not allow the reviewer to identify the adapter role, the use case boundary, the external model, or the translation behavior.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify relevant interface adapters, external models, use case boundaries, and translation behavior, and the available evidence supports that adapters translate external models into use case boundary models and translate use case output into external-facing models without exposing external models to use cases.

# Fail Conditions

Use `Fail` when direct evidence shows that use case boundaries expose, accept, return, require, or depend on external models from delivery mechanisms, persistence mechanisms, transport mechanisms, framework mechanisms, external integration contracts, or other adapter-facing concerns instead of receiving translated boundary models.

# Warning Conditions

Use `Warning` when evidence indicates partial, inconsistent, indirect, duplicated, or ambiguous translation between external models and use case boundaries, but the available material does not justify a definitive `Fail`. Use `Warning` when a boundary model appears partly shaped by an external model, or when translation exists for some boundary paths but not others within the reviewed scope.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include identifiable interface adapters, external models, use case boundaries, boundary data structures, or data crossing between external mechanisms and use cases relevant to this rule.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify interface adapter scope, identify use case boundary scope, distinguish external models from boundary models, inspect translation behavior, determine whether external models cross the use case boundary, or resolve conflicting signals.

# Severity Guidance

Assign higher severity when external model exposure affects central use case boundaries, broad inbound or outbound surfaces, multiple external mechanisms, or stable application business rule contracts. Assign lower severity when the exposure is narrow, isolated, indirect, or limited to peripheral boundary paths. Severity must reflect the demonstrated architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the interface adapter scope, the use case boundary, the external model identity, and the presence or absence of translation across that boundary. Use `Likely` when multiple evidence points support the evaluation but direct confirmation is incomplete. Use `Possible` when evidence is limited, indirect, or partially ambiguous. Use `Not Enough Evidence` when the material cannot support a reliable conclusion. Naming alone must not produce `Confirmed` confidence.

# Dependencies

CLEAN-001, CLEAN-004. These are conceptual dependencies for shared use case boundary and technical detail vocabulary, not procedural prerequisites for evaluating this rule.

# References

CA_CATALOG.md

# Change Notes

None
