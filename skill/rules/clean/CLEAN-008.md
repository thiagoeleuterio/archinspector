# Rule ID

CLEAN-008

# Title

Presenters must not contain use case or entity decisions

# Category

Clean Architecture

# Status

Active

# Intent

Ensure presenters format output without owning application or enterprise business decisions.

# Applicability

Apply this rule when the reviewed material includes identifiable presenters, output adapters, response formatters, view model builders, delivery-facing output components, use case output boundaries, use case responses, entities, enterprise business rules, application business rules, or equivalent output transformation components.

# Rule Statement

Presenters must format or transform use case output for external presentation without containing use case decisions or entity decisions.

# Rationale

Presenters are interface adapter components responsible for preparing output for external presentation. When presenters contain use case or entity decisions, application or enterprise business policy becomes coupled to output mechanisms, the same policy may be duplicated across presentation paths, and changes in presentation requirements can alter business behavior.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed presenter scope, the reviewed use case or entity decision scope, and the output transformation behavior between them. Direct evidence may include project or module references, dependency declarations, package references, imports, namespace relationships, type dependencies, constructor dependencies, method signatures, output boundary interfaces, response model construction, view model construction, formatting behavior, branching behavior, business condition evaluation, entity state interpretation, or reviewed code excerpts showing whether presenters only format output or contain decisions belonging to use cases or entities.

Evidence must distinguish presentation formatting and output transformation from application business decisions and enterprise business decisions. Naming conventions, folder names, presenter labels, view model labels, or architectural intent may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible Clean Architecture distinction between presenters, use cases, and entities. Then inspect whether presenter behavior is limited to formatting, adapting, or transforming use case output into external presentation models, or whether it makes decisions that determine application workflow, use case outcomes, business policy, entity invariants, or enterprise rules.

Evaluate only presenter ownership of use case or entity decisions. Do not use this rule to evaluate controller input handling, gateway isolation, general dependency direction, general framework dependency leakage, view technology choice, or whether all output models are ideal unless that evidence directly shows a presenter containing application or enterprise business decisions.

Interpret evidence conservatively. Conditional formatting, localization, display selection, or presentation-specific transformation is not automatically a violation unless the reviewed material shows that the behavior decides application or enterprise business policy. Prefer `Not Enough Evidence` when the reviewed material does not allow the reviewer to distinguish formatting logic from use case or entity decisions.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify relevant presenters, use case output, entities or business decisions, and output transformation behavior, and the available evidence supports that presenters format or transform output without containing use case decisions or entity decisions.

# Fail Conditions

Use `Fail` when direct evidence shows that presenters contain use case decisions, application workflow decisions, application business rules, entity decisions, enterprise business rules, entity invariant enforcement, or business outcome decisions instead of receiving those decisions from use cases or entities.

# Warning Conditions

Use `Warning` when evidence indicates partial, inconsistent, duplicated, indirect, or ambiguous use case or entity decisions in presenters, but the available material does not justify a definitive `Fail`. Use `Warning` when presenter behavior appears to mix presentation transformation with limited policy-like branching that cannot be conclusively classified from the reviewed material.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include identifiable presenters, output adapters, use case output boundaries, output transformation behavior, use case decisions, entity decisions, or presentation-facing output concerns relevant to this rule.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify presenter scope, identify use case or entity decision scope, inspect output transformation behavior, distinguish presentation formatting from business decisions, or resolve conflicting signals.

# Severity Guidance

Assign higher severity when use case or entity decisions in presenters affect central business outcomes, broad output surfaces, multiple presentation paths, or stable policy boundaries. Assign lower severity when the behavior is narrow, isolated, indirect, or limited to peripheral presentation transformation. Severity must reflect the demonstrated architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the presenter scope, the use case or entity decision involved, and whether that decision is contained in presenter behavior. Use `Likely` when multiple evidence points support the evaluation but direct confirmation is incomplete. Use `Possible` when evidence is limited, indirect, or partially ambiguous. Use `Not Enough Evidence` when the material cannot support a reliable conclusion. Naming alone must not produce `Confirmed` confidence.

# Dependencies

CLEAN-003, CLEAN-005, CLEAN-006. These are conceptual dependencies for shared entity, use case, and interface adapter vocabulary, not procedural prerequisites for evaluating this rule.

# References

CA_CATALOG.md

# Change Notes

None
