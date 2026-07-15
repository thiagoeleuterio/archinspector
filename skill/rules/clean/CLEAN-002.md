# Rule ID

CLEAN-002

# Title

Source dependencies must point toward policies

# Category

Clean Architecture

# Status

Active

# Intent

Ensure source dependencies point from technical details toward higher-level policies.

# Applicability

Apply this rule when the reviewed material includes identifiable Clean Architecture policy code, such as entities, enterprise business rules, use cases, application business rules, or equivalent higher-level policy components, and identifiable technical detail code, such as interface adapters, frameworks and drivers, delivery mechanisms, infrastructure mechanisms, persistence mechanisms, messaging mechanisms, or external integration mechanisms.

# Rule Statement

Source dependencies from technical details must point toward higher-level policies, and higher-level policies must not source-depend on technical details.

# Rationale

Clean Architecture protects policies by making technical details conform to policy decisions rather than making policies depend on details. When source dependencies point outward from policies to technical details, policy code becomes coupled to volatile mechanisms, technical changes can force policy changes, and the architectural distinction between business rules and implementation details weakens.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed higher-level policy scope, the reviewed technical detail scope, and the source dependency relationships between them. Direct evidence may include project or module references, dependency declarations, package references, imports, namespace relationships, type dependencies, constructor dependencies, method behavior, interface definitions, or reviewed code excerpts showing whether technical detail code depends on policy code or policy code depends on technical detail code.

Evidence must distinguish source dependencies from runtime flow of control, configuration wiring, deployment relationships, and naming conventions. Naming conventions, folder names, architectural diagrams, or stated intent may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible Clean Architecture distinction between higher-level policies and technical details. Then inspect source dependency direction using the strongest available evidence, giving priority to project or module references before weaker local signals.

Evaluate only the direction of source dependencies between technical details and higher-level policies. Do not use this rule to evaluate the existence of ports, the ownership of ports, adapter implementation relationships, inbound adapter behavior placement, outbound adapter behavior placement, framework-specific type leakage into use case boundaries, testability, or general Hexagonal Architecture core-adapter conformance unless that evidence directly establishes source dependency direction under the Clean Architecture policy-detail framing.

Interpret evidence conservatively. A package reference, import, namespace, or type name is not enough by itself unless the evidence shows a relevant source dependency between the evaluated policy and detail scopes. Prefer `Not Enough Evidence` when the reviewed material does not allow the reviewer to identify the policy levels, identify technical details, or inspect dependency direction.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify relevant higher-level policies, technical details, and source dependencies, and the available evidence supports that source dependencies point from technical details toward higher-level policies without higher-level policies depending on technical details.

# Fail Conditions

Use `Fail` when direct evidence shows that higher-level policy code source-depends on technical detail code, including interface adapter implementations, delivery mechanisms, infrastructure mechanisms, persistence mechanisms, messaging mechanisms, external integration mechanisms, framework-specific mechanisms, or other lower-level details within the reviewed scope.

# Warning Conditions

Use `Warning` when evidence indicates partial, indirect, inconsistent, cyclic, or ambiguous source dependencies from higher-level policies toward technical details, but the available material does not justify a definitive `Fail`.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include identifiable Clean Architecture higher-level policies, technical details, or source dependency relationships relevant to this rule.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify policy scopes, identify technical detail scopes, inspect source dependency direction, distinguish source dependencies from runtime or configuration relationships, or resolve conflicting signals.

# Severity Guidance

Assign higher severity when reversed source dependencies affect central policy code, broad policy surfaces, multiple technical detail mechanisms, or stable architectural boundaries. Assign lower severity when the dependency is narrow, isolated, indirect, or limited to peripheral policy behavior. Severity must reflect the demonstrated architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the relevant policy scope, technical detail scope, and source dependency direction. Use `Likely` when multiple evidence points support the evaluation but direct confirmation is incomplete. Use `Possible` when evidence is limited, indirect, or partially ambiguous. Use `Not Enough Evidence` when the material cannot support a reliable conclusion. Naming alone must not produce `Confirmed` confidence.

# Dependencies

None

# References

CA_CATALOG.md

# Change Notes

None
