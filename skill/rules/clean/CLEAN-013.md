# Rule ID

CLEAN-013

# Title

Architecture must reveal use cases and business policies

# Category

Clean Architecture

# Status

Active

# Intent

Ensure the system structure makes application use cases and business policies visible as primary architectural concerns.

# Applicability

Apply this rule when the reviewed material includes enough system structure to inspect how use cases, application business rules, enterprise business rules, entities, interface adapters, frameworks and drivers, modules, projects, namespaces, packages, or equivalent architectural units are organized and made visible.

# Rule Statement

The architecture must make use cases and business policies visible as primary structural concerns rather than hiding them behind technical mechanisms or adapter organization.

# Rationale

Clean Architecture emphasizes policies and use cases as central architectural concerns. When the system structure primarily exposes frameworks, delivery mechanisms, persistence mechanisms, transport mechanisms, or adapter groupings while use cases and business policies are hidden, scattered, or only inferable through technical code, reviewers and maintainers have weaker evidence of policy boundaries and are more likely to reason about the system through technical details instead of application behavior.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed system structure and shows how use cases and business policies are represented relative to technical mechanisms and adapters. Direct evidence may include project or module references, solution or package organization, namespace relationships, dependency declarations, type dependencies, public boundary contracts, use case or entity groupings, policy-facing module boundaries, interface adapter placement, framework and driver placement, documentation tied to reviewed structure, or reviewed code excerpts showing whether application use cases and business policies are visible as architectural units.

Evidence must distinguish architectural visibility from naming alone, folder aesthetics, documentation claims, and isolated labels. Naming conventions, folder names, project names, or stated intent may support interpretation but must not be treated as conclusive evidence without corroborating structural, dependency, boundary, or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material provides enough structural scope to reason about architectural visibility. Then inspect whether use cases and business policies appear as stable, identifiable architectural concerns through modules, boundaries, dependencies, contracts, organization, or behavior placement, and whether technical mechanisms remain secondary details around those policies.

Evaluate only whether the architecture reveals use cases and business policies as primary concerns. Do not use this rule to evaluate folder naming as an isolated aesthetic preference, to require a specific packaging style, or to duplicate specific boundary violations covered by other Clean or Hexagonal rules. A structure can support this rule through multiple valid organizational styles when evidence shows that policies and use cases are visible and not hidden by technical organization.

Interpret evidence conservatively. Names such as use case, entity, domain, application, adapter, infrastructure, or framework are not enough by themselves to produce `Pass` or `Fail`. Prefer `Not Enough Evidence` when the reviewed material is too narrow to assess system structure or when visibility cannot be distinguished from naming intent.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to inspect relevant system structure, and the available evidence supports that use cases and business policies are identifiable as primary architectural concerns through structure, boundaries, dependency relationships, contracts, or behavior placement rather than only through names.

# Fail Conditions

Use `Fail` when direct evidence shows that use cases and business policies are structurally hidden, scattered behind technical mechanisms, organized primarily by frameworks or adapters, or only accessible through delivery, persistence, transport, or infrastructure structures in a way that obscures policy boundaries within the reviewed scope.

# Warning Conditions

Use `Warning` when evidence indicates partial, inconsistent, indirect, emerging, or ambiguous visibility of use cases and business policies, but the available material does not justify a definitive `Fail`. Use `Warning` when policies are visible in some areas but hidden behind technical organization in others, or when naming suggests Clean Architecture intent but structural evidence is incomplete or inconsistent.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include enough system structure, use cases, application business rules, enterprise business rules, entities, technical mechanisms, or architectural organization relevant to this rule.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to inspect system structure, identify use cases or business policies, distinguish policy visibility from naming, compare policy organization with technical organization, or resolve conflicting signals.

# Severity Guidance

Assign higher severity when hidden use cases or business policies affect broad system comprehension, central policy boundaries, multiple technical mechanisms, or the ability to select and evaluate Clean Architecture rules reliably. Assign lower severity when visibility issues are narrow, isolated, local, or limited to peripheral organization. Severity must reflect the demonstrated architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the reviewed structural scope, the use cases or business policies, and whether they are visible or hidden as architectural concerns through more than naming alone. Use `Likely` when multiple evidence points support the evaluation but direct confirmation is incomplete. Use `Possible` when evidence is limited, indirect, or partially ambiguous. Use `Not Enough Evidence` when the material cannot support a reliable conclusion. Naming alone must not produce `Confirmed` confidence.

# Dependencies

CLEAN-002, CLEAN-003, CLEAN-004, CLEAN-005, CLEAN-006, CLEAN-007, CLEAN-008, CLEAN-009. These are conceptual dependencies for shared policy, entity, use case, interface adapter, controller, presenter, gateway, and dependency vocabulary, not procedural prerequisites for evaluating this rule.

# References

CA_CATALOG.md

# Change Notes

None
