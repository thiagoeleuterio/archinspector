# Rule ID

LAYER-001

# Title

Lower-level details must not control business policy

# Category

Layered Architecture

# Status

Active

# Intent

Ensure lower-level technical or detail layers do not control business policy decisions.

# Applicability

Apply this rule when the reviewed material includes an identifiable layered architecture structure, an identifiable domain, business, policy, or equivalent higher-level business responsibility, and one or more lower-level technical or detail layers that may influence business decisions.

The rule is relevant only when the reviewed scope provides enough evidence to inspect whether a business decision remains under the authority of the business policy layer or is controlled, conditioned, or determined by a lower-level detail such as infrastructure, persistence, integration, data access, presentation, or another technical mechanism.

Do not apply this rule only because a lower-level layer supplies data, executes technical work, participates in runtime collaboration, or is physically located near business policy code. The rule requires a policy decision whose ownership can be evaluated within the declared or inferable layered structure.

# Rule Statement

Lower-level technical or detail layers must not control decisions that belong to business policy in a layered architecture.

# Rationale

Layered Architecture separates responsibilities so that business policy remains authoritative over business decisions while lower-level layers provide supporting technical capabilities. When a lower-level detail controls a business decision, the system becomes harder to reason about because business behavior changes according to infrastructure, persistence, integration, presentation, or other technical concerns rather than the layer responsible for business policy.

This risk is different from ordinary collaboration between layers. A lower-level layer may provide mechanisms, data, persistence access, integration results, or presentation input without owning the business decision that uses them. The architectural concern appears when the decision itself is transferred to, hidden inside, or improperly conditioned by a lower-level detail.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed layered structure, the business policy layer or equivalent business responsibility, the lower-level technical or detail layer involved, and the business decision whose authority is being evaluated.

Direct evidence may include project or module references, dependency declarations, namespace relationships, imports, type dependencies, constructor dependencies, method behavior, branching behavior, rule checks, state transition behavior, configuration or data-driven decision behavior, reviewed code excerpts, or documentation tied to the reviewed layered structure.

Evidence must distinguish a business policy decision from technical execution, data retrieval, persistence mapping, integration transport, presentation input handling, configuration wiring, runtime flow, and ordinary collaboration between layers. Naming conventions, folder names, project names, layer labels, or physical location may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

Evidence should show who determines the business outcome, not merely who supplies data or executes a technical step. A dependency from a business policy layer to a lower-level layer is not sufficient by itself to prove that the lower-level layer controls the business decision.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible layered architecture interpretation and whether the relevant higher-level business policy responsibility and lower-level detail responsibility can be identified. Then inspect the decision path and determine whether the business outcome is decided by the business policy layer or by a lower-level technical detail.

Evaluate only lower-level control over business policy decisions. Do not use this rule to evaluate the existence of layers, the complete responsibility set of each layer, the general direction of every dependency between layers, layer bypassing, layer contract design, ports and adapters, Clean Architecture source dependency direction, Clean Architecture flow of control, Domain-Driven Design model quality, or generic placement of all business logic.

Interpret evidence conservatively. Runtime dependence on infrastructure, persistence, integration, or presentation does not automatically mean the detail layer controls business policy. A lower-level layer may return data, persist state, call an external system, adapt input, or provide technical status while the business policy layer remains responsible for deciding what that information means. Collaboration between layers is not automatically a violation.

Common finding patterns include business outcomes decided inside lower-level technical components, business rules encoded in persistence or integration behavior instead of policy behavior, presentation or infrastructure paths selecting business outcomes that the business layer only accepts, or domain or business policy objects whose decisions are effectively dictated by detail-layer mechanisms. These patterns support findings only when corroborated by evidence that the lower-level layer controls a decision belonging to business policy.

Remediation guidance should preserve the business decision in the business policy layer while allowing lower-level layers to continue supplying technical capabilities or data. Recommendations should be derived from the finding evidence and should avoid prescribing a specific framework, technology, or universal architectural style.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify the relevant layered structure, business policy decision, and lower-level detail interaction, and the available evidence supports that the business policy layer retains authority over the decision while lower-level layers provide only supporting mechanisms, data, or technical execution.

# Fail Conditions

Use `Fail` when direct evidence shows that a lower-level technical or detail layer controls, determines, owns, hides, or improperly conditions a business decision that belongs to the business policy layer within the reviewed layered architecture.

Use `Fail` when direct evidence shows that business rules are effectively encoded in infrastructure behavior, persistence behavior, integration behavior, data access behavior, presentation behavior, or another lower-level detail in a way that causes the business policy layer to accept rather than decide the business outcome.

# Warning Conditions

Use `Warning` when evidence indicates partial, inconsistent, indirect, duplicated, emerging, or ambiguous lower-level influence over business policy decisions, but the available material does not justify a definitive `Fail`.

Use `Warning` when a lower-level layer appears to shape a business decision but the reviewed material does not fully establish whether the decision belongs to business policy, whether the lower-level behavior is merely technical support, or whether the business policy layer retains final authority.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include an identifiable layered architecture structure, an identifiable business policy layer or equivalent business responsibility, a lower-level technical or detail layer, or a business decision relevant to this rule.

Use `Not Applicable` when the reviewed material concerns only layer existence, layer naming, general dependency direction, layer bypassing, contracts between layers, ports and adapters, Clean Architecture boundaries, Domain-Driven Design model quality, or technical implementation details without a business policy decision controlled by a lower-level layer.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify the layered structure, identify the business policy responsibility, identify the lower-level detail responsibility, inspect the decision path, distinguish technical support from business decision control, or resolve conflicting signals.

Use `Not Enough Evidence` when the only available signals are naming, folder structure, physical location, dependency existence, runtime execution order, or absence of contrary evidence. Absence of evidence must not be converted into `Fail`.

# Severity Guidance

Assign higher severity when lower-level control affects central business policy decisions, broad business behavior, critical workflows, stable layer boundaries, many callers, or decisions that are difficult to change without modifying technical details.

Assign lower severity when the lower-level control is narrow, isolated, peripheral, reversible, or limited to a small decision with minor architectural impact.

Severity must reflect demonstrated architectural and maintainability impact within the reviewed scope. Do not assign severity solely from the Layered Architecture category, the name of a layer, or the presence of a dependency.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the layered structure, the business policy decision, the lower-level detail layer, and the fact that the lower-level detail controls or does not control that decision.

Use `Likely` when multiple evidence points support the evaluation but direct confirmation of decision ownership or layer responsibility is incomplete.

Use `Possible` when evidence is limited, indirect, partially ambiguous, or relies on weak supporting signals that suggest lower-level influence without conclusively establishing decision control.

Use `Not Enough Evidence` when the available material cannot support a reliable conclusion. Naming, layer labels, folder location, project names, or physical placement alone must not produce `Confirmed` confidence.

# Dependencies

LAYER-002, LAYER-003, LAYER-005, LAYER-006. These are conceptual dependencies for shared layer responsibility, dependency direction, application or service coordination, and business rule ownership vocabulary, not procedural prerequisites for evaluating this rule.

# References

LAYER_CATALOG.md

# Change Notes

Initial Gold Standard rule content for the Layered Architecture catalog.
