# Rule ID

CLEAN-007

# Title

Controllers must delegate application flow to use cases

# Category

Clean Architecture

# Status

Active

# Intent

Ensure controllers coordinate input and delegation without containing application business rules.

# Applicability

Apply this rule when the reviewed material includes identifiable controllers, delivery-facing entry points, request handlers, user interaction handlers, inbound adapter components, use cases, interactors, application business rules, or equivalent application-level flow components that receive input and initiate application behavior.

# Rule Statement

Controllers must receive input, coordinate boundary adaptation, and delegate application flow to use cases without owning application business rules.

# Rationale

In Clean Architecture, controllers are interface adapter components that handle incoming interaction concerns and pass control to use cases. When controllers own application flow decisions or application business rules instead of delegating them to use cases, application behavior becomes coupled to delivery mechanisms, reuse across entry points decreases, and the use case boundary becomes less visible and less stable.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed controller scope, the reviewed use case scope, and the control flow between them. Direct evidence may include project or module references, dependency declarations, package references, imports, namespace relationships, type dependencies, constructor dependencies, method signatures, interface definitions, request handling behavior, input adaptation behavior, delegation calls, branching or orchestration behavior, transaction or workflow coordination behavior, or reviewed code excerpts showing whether controllers delegate application flow to use cases or contain application business rules themselves.

Evidence must distinguish controller input coordination from use case orchestration and application business decisions. Naming conventions, folder names, controller labels, handler labels, or architectural intent may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible Clean Architecture distinction between controllers and use cases. Then inspect whether controllers limit their responsibility to receiving input, performing boundary adaptation, selecting the relevant use case when supported by evidence, and delegating application flow to the use case boundary.

Evaluate only controller responsibility for input coordination and delegation to use cases. Do not use this rule to evaluate output formatting, presenter behavior, persistence behavior, gateway behavior, entity decisions, general framework dependency leakage, or general source dependency direction unless that evidence directly shows whether controllers own application flow instead of delegating it.

Interpret evidence conservatively. Branching, validation, or coordination in a controller is not automatically a violation unless the reviewed material shows that the behavior represents application business rules or application flow decisions that should be owned by a use case. Prefer `Not Enough Evidence` when the reviewed material does not allow the reviewer to distinguish delivery coordination from use case orchestration.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify relevant controllers, use cases, and control flow, and the available evidence supports that controllers receive input, adapt it to use case boundaries, and delegate application flow to use cases without containing application business rules.

# Fail Conditions

Use `Fail` when direct evidence shows that controllers contain application business rules, central application flow decisions, use case orchestration, workflow policy, or application-specific decision logic instead of delegating that behavior to use cases.

# Warning Conditions

Use `Warning` when evidence indicates partial, inconsistent, duplicated, indirect, or ambiguous application flow behavior in controllers, but the available material does not justify a definitive `Fail`. Use `Warning` when controllers mostly delegate to use cases but also contain limited behavior that appears to influence application flow without enough evidence to classify it conclusively.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include identifiable controllers, inbound adapter components, delivery-facing entry points, use cases, application business rules, or controller-to-use-case control flow relevant to this rule.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify controller scope, identify use case scope, inspect delegation behavior, distinguish delivery coordination from application business rules, determine where application flow is owned, or resolve conflicting signals.

# Severity Guidance

Assign higher severity when application flow or business rules in controllers affect central use cases, broad delivery surfaces, multiple entry points, or stable application behavior boundaries. Assign lower severity when the behavior is narrow, isolated, indirect, or limited to peripheral input coordination. Severity must reflect the demonstrated architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the controller scope, the use case scope, and whether application flow is delegated or owned by the controller. Use `Likely` when multiple evidence points support the evaluation but direct confirmation is incomplete. Use `Possible` when evidence is limited, indirect, or partially ambiguous. Use `Not Enough Evidence` when the material cannot support a reliable conclusion. Naming alone must not produce `Confirmed` confidence.

# Dependencies

CLEAN-004, CLEAN-006. These are conceptual dependencies for shared use case isolation and boundary adaptation vocabulary, not procedural prerequisites for evaluating this rule.

# References

CA_CATALOG.md

# Change Notes

None
