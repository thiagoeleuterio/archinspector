# Rule ID

CLEAN-012

# Title

Flow of control must cross boundaries through abstractions

# Category

Clean Architecture

# Status

Active

# Intent

Ensure runtime control flow can cross outward while source dependencies continue to point inward.

# Applicability

Apply this rule when the reviewed material includes identifiable Clean Architecture boundaries, use cases, entities, interface adapters, frameworks and drivers, boundary abstractions, runtime invocation paths, composition or wiring mechanisms, or equivalent collaborations where control flow crosses between policies and technical details.

# Rule Statement

Flow of control across Clean Architecture boundaries must use abstractions so that runtime calls can cross outward without making source dependencies point away from policies.

# Rationale

Clean Architecture allows runtime control flow to move between policies and details, including outward toward presenters, gateways, adapters, or frameworks, while source dependencies continue to point toward higher-level policies. Abstractions preserve that separation by letting details satisfy policy-defined needs. When runtime flow crosses boundaries through concrete details instead of abstractions, policies become coupled to lower-level mechanisms and source dependency direction can be undermined by execution paths.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed boundary, the runtime control flow crossing it, the abstractions used or bypassed, and the source dependency relationships associated with that flow. Direct evidence may include project or module references, dependency declarations, package references, imports, namespace relationships, type dependencies, constructor dependencies, method signatures, interface definitions, callback or output boundary definitions, gateway abstractions, presenter abstractions, composition wiring, invocation paths, implementation relationships, or reviewed code excerpts showing whether runtime flow crosses boundaries through abstractions while source dependencies point toward policies.

Evidence must distinguish runtime flow of control from source dependency direction, configuration wiring, object construction, and generic dependency injection mechanisms. Naming conventions, folder names, interface suffixes, dependency injection labels, or architectural intent may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible Clean Architecture boundary and a runtime flow that crosses it. Then inspect whether the policy side depends on an abstraction that expresses policy needs, while the lower-level detail implements or satisfies that abstraction and runtime control may call outward through the abstraction.

Evaluate only boundary-crossing flow of control through abstractions together with preservation of source dependency direction toward policies. Do not use this rule to duplicate `CLEAN-002`, which evaluates structural source dependency direction by itself. Do not transform this rule into a generic evaluation of dependency injection, service location, object lifetime, container registration, or composition style unless that evidence directly establishes how control flow crosses a Clean Architecture boundary through abstractions.

Interpret evidence conservatively. The presence of an interface, factory, registration, or injected dependency is not enough by itself to prove compliant flow. Prefer `Not Enough Evidence` when the reviewed material does not allow the reviewer to identify the boundary, the runtime call path, the abstraction role, and the relevant source dependency direction.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify relevant boundary-crossing runtime flow, abstractions, and source dependencies, and the available evidence supports that flow crosses boundaries through abstractions while source dependencies continue to point toward higher-level policies.

# Fail Conditions

Use `Fail` when direct evidence shows that runtime flow from policies to lower-level details crosses Clean Architecture boundaries through concrete adapters, concrete frameworks, concrete drivers, concrete persistence or transport mechanisms, or other technical details in a way that makes policy code source-depend on those details instead of abstractions.

# Warning Conditions

Use `Warning` when evidence indicates partial, inconsistent, indirect, implicit, or ambiguous boundary-crossing flow through abstractions, but the available material does not justify a definitive `Fail`. Use `Warning` when abstractions exist but their ownership, shape, or source dependency direction appears partly influenced by concrete details without enough evidence for a confirmed violation.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include identifiable Clean Architecture boundaries, runtime control flow crossing those boundaries, boundary abstractions, source dependency relationships, or policy-to-detail collaborations relevant to this rule.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify boundary-crossing control flow, inspect source dependency direction, identify abstractions and implementations, distinguish runtime flow from source dependency, or resolve conflicting signals.

# Severity Guidance

Assign higher severity when concrete boundary-crossing control flow affects central use cases, broad policy interactions, multiple adapters or technical mechanisms, or stable policy boundaries. Assign lower severity when the issue is narrow, isolated, indirect, or limited to peripheral runtime collaboration. Severity must reflect the demonstrated architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the boundary, the runtime control flow, the abstraction or concrete detail used to cross it, and the associated source dependency direction. Use `Likely` when multiple evidence points support the evaluation but direct confirmation is incomplete. Use `Possible` when evidence is limited, indirect, or partially ambiguous. Use `Not Enough Evidence` when the material cannot support a reliable conclusion. Naming alone must not produce `Confirmed` confidence.

# Dependencies

CLEAN-002, CLEAN-004, CLEAN-009. These are conceptual dependencies for shared source dependency, use case isolation, gateway, and boundary abstraction vocabulary, not procedural prerequisites for evaluating this rule.

# References

CA_CATALOG.md

# Change Notes

None
