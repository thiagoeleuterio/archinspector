# Rule ID

CLEAN-011

# Title

Boundary data structures must not carry framework or adapter details

# Category

Clean Architecture

# Status

Active

# Intent

Ensure data crossing Clean Architecture boundaries is independent from frameworks, drivers, and adapter-specific models.

# Applicability

Apply this rule when the reviewed material includes identifiable Clean Architecture boundaries, boundary data structures, use case input or output structures, request or response models, gateway boundary structures, presenter boundary structures, controller boundary structures, interface adapters, frameworks and drivers, or equivalent data structures that cross between policies and technical details.

# Rule Statement

Boundary data structures must remain independent from framework, driver, and adapter-specific details when crossing Clean Architecture boundaries.

# Rationale

Boundary data structures carry information across Clean Architecture boundaries and should express the needs of the policy boundary rather than the details of a framework, driver, or adapter. When boundary data includes framework lifecycle types, adapter models, transport metadata, persistence annotations, driver-specific identifiers, or external mechanism concerns, policies become harder to evaluate independently and technical changes are more likely to alter boundary contracts.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed boundary, the boundary data structures crossing it, and the framework, driver, or adapter details that may be carried by those structures. Direct evidence may include project or module references, dependency declarations, package references, imports, namespace relationships, type dependencies, constructor dependencies, method signatures, interface definitions, boundary data member types, annotations or metadata, serialization or persistence attributes, adapter model references, framework base types, driver-specific types, transport or persistence metadata, or reviewed code excerpts showing whether boundary data carries technical details.

Evidence must distinguish boundary data structures from external adapter models, internal policy structures, and ordinary domain-neutral data. Naming conventions, folder names, request or response suffixes, DTO labels, or architectural intent may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible Clean Architecture boundary and a data structure that crosses it. Then inspect whether that boundary data is independent from framework, driver, and adapter-specific details, including technical annotations, external model inheritance, framework result or context types, persistence mapping concerns, transport metadata, adapter-owned identifiers, or data members whose purpose is to satisfy a technical mechanism rather than the boundary policy.

Evaluate only whether boundary data structures carry framework, driver, or adapter details. Do not use this rule to duplicate the narrower evaluation of framework-specific types crossing into use cases in `CLEAN-001`, or the Hexagonal evaluation of adapter models leaking into core contracts in `HEX-011`. Do not use this rule to evaluate general interface adapter translation, controller behavior, presenter behavior, gateway isolation, source dependency direction, or data mapper responsibility unless that evidence directly shows technical details carried by boundary data.

Interpret evidence conservatively. A data structure name, folder location, or superficial similarity to an adapter model is not enough to prove that boundary data carries adapter details. Prefer `Not Enough Evidence` when the reviewed material does not allow the reviewer to identify the boundary, inspect the data structure, or determine whether a member or annotation is technical-detail-specific.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify relevant Clean Architecture boundaries and boundary data structures, and the available evidence supports that those structures do not carry framework, driver, or adapter-specific details.

# Fail Conditions

Use `Fail` when direct evidence shows that boundary data structures crossing Clean Architecture boundaries expose, require, inherit from, annotate themselves with, or otherwise carry framework types, driver types, adapter models, persistence metadata, transport metadata, framework lifecycle concerns, external mechanism contracts, or other adapter-specific details.

# Warning Conditions

Use `Warning` when evidence indicates partial, inconsistent, indirect, emerging, or ambiguous framework, driver, or adapter detail leakage into boundary data structures, but the available material does not justify a definitive `Fail`. Use `Warning` when boundary data appears mostly independent but contains limited technical metadata or adapter-shaped members whose architectural role cannot be conclusively classified.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include identifiable Clean Architecture boundaries, boundary data structures, framework or driver concerns, adapter-specific models, or data crossing between policies and technical details relevant to this rule.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify boundary data structures, identify the Clean Architecture boundary being crossed, inspect member types or metadata, distinguish framework or adapter details from domain-neutral data, or resolve conflicting signals.

# Severity Guidance

Assign higher severity when framework, driver, or adapter details in boundary data affect central use case boundaries, broad policy contracts, multiple adapters, or stable application business rule surfaces. Assign lower severity when the leakage is narrow, isolated, indirect, or limited to peripheral boundary data. Severity must reflect the demonstrated architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the Clean Architecture boundary, the boundary data structure, the framework or adapter-specific detail, and its presence in data crossing that boundary. Use `Likely` when multiple evidence points support the evaluation but direct confirmation is incomplete. Use `Possible` when evidence is limited, indirect, or partially ambiguous. Use `Not Enough Evidence` when the material cannot support a reliable conclusion. Naming alone must not produce `Confirmed` confidence.

# Dependencies

CLEAN-001, CLEAN-004, CLEAN-006. These are conceptual dependencies for shared use case boundary, framework independence, and adapter translation vocabulary, not procedural prerequisites for evaluating this rule.

# References

CA_CATALOG.md

# Change Notes

None
