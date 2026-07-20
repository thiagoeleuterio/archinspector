# Rule ID

LAYER-003

# Title

Dependencies must follow the declared layer direction

# Category

Layered Architecture

# Status

Active

# Intent

Ensure dependencies between layers conform to the direction defined by the layered structure.

# Applicability

Apply this rule when the reviewed material includes an identifiable layered architecture structure, at least two identified layers participate in a dependency relationship, and the expected direction of dependency between those layers is declared, documented, or sufficiently inferable from the reviewed scope.

The rule is relevant when structural references between modules, components, or other architectural units can be compared with the dependency direction established for the layered structure. The established direction may come from architecture documentation, dependency rules, build configuration, module relationships, architectural decisions, tests, or consistent structural evidence.

Do not apply this rule only because files, folders, namespaces, components, or modules use layer-like names. Naming and physical organization may support interpretation, but the rule requires enough evidence to establish both the participating layers and the expected dependency direction between them.

# Rule Statement

Dependencies between identified layers in a layered architecture must follow the dependency direction declared or clearly established for the reviewed system.

# Rationale

Layered Architecture depends on predictable dependency direction so that layer boundaries remain understandable, changes can be localized, and responsibilities do not become coupled in ways that contradict the selected layered structure. When dependencies point against the declared direction, form incompatible bidirectional relationships, or create cycles that defeat the expected direction, the layered structure becomes harder to reason about and maintain.

This concern is specific to structural dependency direction between layers. It is different from whether layer responsibilities are well defined, whether a lower-level detail controls business policy, whether an interaction bypasses a required intermediate layer, or whether another architecture style would impose a different dependency rule.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed layered structure, the participating layers, the dependency relationships between those layers, and the declared, documented, or sufficiently inferable direction expected by the layered structure.

Direct evidence may include project or module references, dependency declarations, build rules, namespace relationships, imports or includes, type dependencies, constructor dependencies, contracts used across layers, architecture tests, configuration that constrains structure, architecture diagrams, dependency documentation, reviewed code excerpts, or architectural decision records tied to the reviewed layered structure.

Evidence must distinguish structural dependency from runtime execution, data flow, control flow, collaboration sequence, naming convention, and physical location. A runtime call sequence does not necessarily establish a structural dependency direction, and a structural dependency is not automatically invalid unless the expected direction for the relevant layers is established.

Evidence should prioritize executable, structural, or documented constraints over naming and convention. Naming, folders, namespaces, project labels, or layer labels alone must not be treated as conclusive proof of the expected direction or of a violation.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible layered architecture interpretation and whether the layers participating in the dependency relationship can be identified. Then establish the expected dependency direction from documentation, architecture decisions, dependency rules, build configuration, architecture tests, or consistent structural evidence. Only after that compare observed dependencies with the expected direction.

Evaluate only dependency direction between layers. Do not use this rule to evaluate whether layer responsibilities are explicit and consistent, whether lower-level details control business policy decisions, presentation responsibility placement, application or service coordination, domain or business rule ownership, data access responsibility placement, bypassing required intermediate layers, layer contract integrity, ports and adapters, Clean Architecture dependency rules, flow of control, Domain-Driven Design model quality, or framework and technology usage.

Interpret evidence conservatively. A dependency can be considered invalid only when the expected direction is established for the reviewed layered structure and the observed dependency contradicts that direction within the reviewed scope. When the expected direction is undocumented but strongly inferable, assign confidence according to the strength and independence of the evidence. When the expected direction cannot be established, use `Not Enough Evidence` rather than speculating.

Do not assume a universal layer model. This rule does not require all dependencies to point toward a domain layer, does not require only downward dependencies, does not prohibit every dependency on abstractions defined in another layer, and does not treat every reverse-looking dependency as automatically invalid. Callbacks, abstractions, and inversion of control may preserve the declared architectural direction when the structural dependency relationship supports that interpretation.

When documentation and implementation conflict, make the conflict explicit. A documented direction contradicted by structural evidence may support `Fail`, `Warning`, or `Not Enough Evidence` depending on the strength, scope, and consistency of the evidence. Cycles and bidirectional dependencies should be evaluated by their impact on the declared direction, not by their shape alone.

Common finding patterns include direct dependencies that point against the declared layer direction, dependency cycles that make the declared direction unenforceable, bidirectional dependencies between layers where only one direction is permitted, and dependency relationships that contradict documented or tested layer constraints. These patterns support findings only when the expected direction and the observed dependency are both supported by traceable evidence.

Remediation guidance should focus on realigning structural dependencies with the declared layered direction, clarifying the expected direction when it is ambiguous, or introducing an appropriate boundary mechanism only when the reviewed evidence shows that such a change would address the specific dependency violation. Recommendations must be derived from evidence and must not prescribe a universal layer model or another architecture style.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify the relevant layered structure, participating layers, expected dependency direction, and observed dependency relationships, and the available evidence supports that dependencies between the evaluated layers conform to the declared or clearly established direction.

Use `Pass` when apparent reverse runtime collaboration, callbacks, abstractions, or inversion of control are supported by structural evidence showing that the architectural dependency direction remains consistent with the declared layered structure.

# Fail Conditions

Use `Fail` when direct evidence shows that a dependency between identified layers contradicts the declared or clearly established dependency direction for the reviewed layered structure.

Use `Fail` when direct evidence shows that cyclic or bidirectional dependencies between layers make the declared dependency direction unenforceable or materially contradicted within the reviewed scope.

Use `Fail` when implementation dependencies clearly conflict with documented, tested, configured, or otherwise established layer dependency constraints and the available evidence is sufficient to determine that the implementation is violating the expected direction.

# Warning Conditions

Use `Warning` when evidence indicates partial, localized, emerging, inconsistent, indirect, or ambiguous drift from the expected dependency direction, but the available material does not justify a definitive `Fail`.

Use `Warning` when dependencies appear to contradict the expected direction but the direction is only partially inferable, the dependency relationship is indirect, the scope is narrow, or the evidence leaves reasonable uncertainty about whether a boundary abstraction preserves the architectural direction.

Use `Warning` when documentation and implementation suggest different dependency directions and the reviewed material shows a maintainability risk, but the evidence is not strong enough to conclude that the declared layered direction has been definitively violated.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include an identifiable layered architecture structure, does not include at least two layers participating in a dependency relationship, or concerns material outside Layered Architecture dependency direction evaluation.

Use `Not Applicable` when the review question concerns layer responsibility clarity, lower-level control over business policy, layer bypassing, layer contract integrity, layer-specific responsibility placement, ports and adapters, Clean Architecture policy direction, Domain-Driven Design modeling, or another architectural concern without requiring evaluation of dependency direction between layers.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify the layered structure, identify the participating layers, establish the expected dependency direction, trace observed dependencies, distinguish structural dependency from runtime collaboration, or resolve conflicting signals.

Use `Not Enough Evidence` when the only available signals are naming, folder structure, physical location, project names, namespace names, layer labels, isolated excerpts, incomplete documentation, runtime execution order, or absence of contrary evidence. Absence of evidence must not be converted into `Fail`.

Use `Not Enough Evidence` when dependencies are visible but the declared or inferable direction of dependency for the reviewed layered structure cannot be established with enough confidence to evaluate conformance.

# Severity Guidance

Assign higher severity when dependency direction violations affect central layer boundaries, broad portions of the reviewed scope, many callers, stable architectural constraints, core change paths, or cycles that make the declared layered structure difficult to preserve.

Assign lower severity when the direction concern is narrow, isolated, peripheral, reversible, limited to a small dependency relationship, or unlikely to affect the broader maintainability of the layered structure.

Severity must reflect demonstrated architectural and maintainability impact within the reviewed scope. Do not assign severity solely from the Layered Architecture category, the name of a layer, the number of layers, the existence of a dependency, or a universal assumption about how layers should point.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the layered structure, the participating layers, the expected dependency direction, the observed dependency relationship, and whether that relationship conforms to or violates the expected direction.

Use `Likely` when multiple evidence points support the evaluation but direct confirmation of the expected direction, dependency relationship, or layer identity is incomplete.

Use `Possible` when evidence is limited, indirect, partially ambiguous, or relies on weak supporting signals that suggest dependency direction conformance or violation without conclusively establishing it.

Use `Not Enough Evidence` when the available material cannot support a reliable conclusion. Naming, layer labels, folder location, project names, namespace names, physical placement, runtime execution order, or absence of contrary evidence alone must not produce `Confirmed` confidence.

# Dependencies

LAYER-002, LAYER-008. These are conceptual dependencies for shared layer identification, layer responsibility vocabulary, and bypass boundary distinction, not procedural prerequisites for evaluating this rule.

# References

LAYER_CATALOG.md

# Change Notes

Initial rule content for the Layered Architecture catalog.
