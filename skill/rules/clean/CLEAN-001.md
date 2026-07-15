# Rule ID

CLEAN-001

# Title

Framework types must not cross into use cases

# Category

Clean Architecture

# Status

Active

# Intent

Evaluate whether application use cases remain independent from framework-specific types at their input, output, dependency, and boundary data structures.

# Applicability

Apply this rule when the reviewed material includes identifiable Clean Architecture use cases, application business rules, use case interfaces, interactors, handlers, boundary data structures, or equivalent application-level orchestration components, and one or more framework-specific types from interface adapters, frameworks and drivers, delivery mechanisms, persistence mechanisms, messaging mechanisms, or external integration mechanisms may interact with those use cases.

# Rule Statement

Use cases must not expose, accept, depend on, or require framework-specific types across their boundaries.

# Rationale

In Clean Architecture, use cases represent application business rules and should remain independent from frameworks and drivers. When framework-specific types cross into use case boundaries, application behavior becomes coupled to technical details such as web frameworks, persistence APIs, messaging libraries, UI frameworks, runtime configuration, or external integration contracts. This weakens policy direction, makes use cases harder to evaluate independently, and forces technical framework changes to affect application business rules.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed use case scope and the framework-specific types that may cross into it. Direct evidence may include project or module references, package references, imports, namespace relationships, type dependencies, constructor dependencies, method signatures, interface definitions, boundary data structures, attributes or annotations, configuration types, framework base classes, framework result types, request or response types, persistence context types, messaging context types, or reviewed code excerpts showing whether a use case exposes, accepts, depends on, or requires a framework-specific type.

Evidence must distinguish framework-specific types from language, runtime, or domain-neutral types. Naming conventions, folder names, or architectural intent may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible Clean Architecture distinction between use cases, interface adapters, and frameworks and drivers. Then inspect the use case boundary, including public methods, handlers, constructors, interfaces, command or response models, boundary data structures, and dependencies required to execute application business rules.

Evaluate only whether framework-specific types cross into use cases. Do not use this rule to evaluate general port ownership, adapter model leakage, dependency direction across all core code, persistence design, messaging design, controller behavior, presenter behavior, or testing strategy unless that evidence directly shows framework-specific types crossing a use case boundary.

Interpret evidence conservatively. A framework package reference, import, annotation, or type name is not enough by itself unless the evidence shows that the framework-specific type is part of the use case boundary or required by use case behavior. Prefer `Not Enough Evidence` when the reviewed material does not allow the reviewer to identify use case boundaries or determine whether a type is framework-specific.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify relevant use case boundaries and the available evidence supports that use cases expose, accept, depend on, and require only framework-independent boundary data structures, abstractions, or domain-neutral types.

# Fail Conditions

Use `Fail` when direct evidence shows that a use case boundary exposes, accepts, depends on, or requires framework-specific types, including framework request or response objects, controller or presenter framework types, persistence context or entity framework types, messaging framework types, UI framework types, framework configuration types, framework lifecycle types, framework result types, or framework-specific attributes or annotations that shape use case behavior.

# Warning Conditions

Use `Warning` when evidence indicates partial, inconsistent, indirect, or ambiguous framework-type leakage into use case boundaries, but the available material does not justify a definitive `Fail`. Use `Warning` when a boundary data structure is mostly framework-independent but appears partially shaped by framework-specific concerns, or when framework-specific metadata is present near use case code without enough evidence that it is required by the use case boundary.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include identifiable use cases, application business rules, use case boundaries, boundary data structures, or framework-specific types relevant to this rule.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify use case boundaries, distinguish use cases from interface adapters or frameworks and drivers, inspect signatures or dependencies at the boundary, determine whether a type is framework-specific, or resolve conflicting signals.

# Severity Guidance

Assign higher severity when framework-specific types cross central use case boundaries, affect broad application business rule surfaces, force multiple use cases to depend on the same framework, or make framework and driver changes likely to alter use case contracts. Assign lower severity when the leakage is narrow, isolated, indirect, or limited to peripheral use case behavior. Severity must reflect the demonstrated architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the use case boundary, the framework-specific identity of the type, and its exposure, acceptance, dependency, or requirement by the use case. Use `Likely` when multiple evidence points support the evaluation but direct confirmation is incomplete. Use `Possible` when evidence is limited, indirect, or partially ambiguous. Use `Not Enough Evidence` when the material cannot support a reliable conclusion. Naming alone must not produce `Confirmed` confidence.

# Dependencies

None

# References

CA_CATALOG.md

# Change Notes

Expanded the rule into the official specification format while preserving the architectural condition that framework types must not cross into use cases.
