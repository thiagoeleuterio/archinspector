# Rule ID

LAYER-002

# Title

Layers must have explicit and consistent responsibilities

# Category

Layered Architecture

# Status

Active

# Intent

Ensure identified layers have clear responsibilities that remain consistent within the reviewed scope.

# Applicability

Apply this rule when the reviewed material includes an identifiable layered architecture structure and enough evidence to evaluate the responsibilities assigned to one or more layers within the reviewed scope.

The rule is relevant when layer responsibilities are declared, documented, or inferable from reviewed structural or behavioral evidence, and when the review can compare those responsibilities with the responsibilities actually carried by the identified layers.

Do not apply this rule only because files, projects, namespaces, folders, or components use layer-like names. The rule requires enough evidence to identify the architectural purpose of the layers and to evaluate whether their responsibilities are explicit and consistent within the reviewed material.

# Rule Statement

Identified layers in a layered architecture must have explicit responsibilities that remain consistent and non-contradictory within the reviewed scope.

# Rationale

Layered Architecture depends on layers having recognizable responsibilities so that reviewers can reason about where behavior belongs, where changes should be made, and how architectural boundaries are meant to be interpreted. When layer responsibilities are unclear, inconsistent, or contradictory, the layered structure becomes difficult to evaluate and maintain because the same concern may appear to belong to multiple layers or no layer may clearly own it.

This risk is different from disagreement about dependency direction, business decision authority, or layer-specific implementation responsibility. The concern in this rule is whether each identified layer has a clear architectural purpose and whether that purpose remains coherent across the reviewed scope.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed layered structure, the layers included in the reviewed scope, the explicit or inferable responsibilities of those layers, and the responsibilities actually carried by reviewed material inside those layers.

Direct evidence may include architecture documentation, project or module organization, dependency declarations, namespace relationships, imports, type dependencies, constructor dependencies, method behavior, reviewed code excerpts, or other reviewed material that shows what each layer is responsible for.

Evidence must distinguish explicit responsibility from naming convention alone. Layer names, folder names, project names, namespace names, or physical location may support interpretation, but they must not be treated as conclusive evidence without corroborating structural, behavioral, or documented evidence.

Evidence should show whether each layer has an identifiable architectural purpose, whether responsibilities remain coherent within the layer, and whether responsibilities assigned to different layers contradict each other within the reviewed scope.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible layered architecture interpretation and whether the layers included in scope can be identified. Then evaluate whether each relevant layer has an explicit or inferable architectural responsibility and whether the reviewed material applies those responsibilities consistently.

Evaluate only clarity and consistency of layer responsibilities. Do not use this rule to evaluate business policy decision authority, general dependency direction, presentation responsibility placement, application or service coordination, domain or business rule ownership, persistence access placement, bypassing required intermediate layers, contracts between layers, other architecture styles, domain modeling quality, object-oriented design principles, messaging behavior, testing strategy, or solution-level organization.

Interpret evidence conservatively. A layer may contain more than one related responsibility when the reviewed material supports that those responsibilities belong together within the layered structure. A layer may also collaborate with another layer without creating a responsibility contradiction. The architectural concern appears when a layer's purpose cannot be identified, changes across the reviewed scope without explanation, conflicts with another layer's stated purpose, or carries responsibilities that contradict the layered structure being evaluated.

When responsibilities are documented but reviewed implementation evidence contradicts them, evaluate the contradiction within the limits of the reviewed scope. When responsibilities are only inferable, use weaker confidence unless multiple independent evidence points support the same responsibility interpretation.

Remediation guidance should focus on making layer responsibilities explicit, consistent, and non-contradictory within the reviewed scope. Recommendations should be derived from the finding evidence and should avoid prescribing a specific framework, technology, or universal architectural style.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify the relevant layered structure and the available evidence supports that each evaluated layer has an explicit or inferable architectural purpose, responsibilities are coherent within each layer, and no responsibility contradiction between evaluated layers is present within the reviewed material.

# Fail Conditions

Use `Fail` when direct evidence shows that one or more identified layers lack an identifiable architectural purpose within a reviewed layered structure.

Use `Fail` when direct evidence shows that responsibilities assigned to a layer are materially inconsistent across the reviewed scope, or that two or more layers claim or carry contradictory responsibilities in a way that makes layer ownership unclear.

Use `Fail` when direct evidence shows that the reviewed layered structure cannot be evaluated reliably because layer responsibilities are absent, conflicting, or unstable within the scope being reviewed.

# Warning Conditions

Use `Warning` when evidence indicates partial, emerging, localized, indirect, or ambiguous inconsistency in layer responsibilities, but the available material does not justify a definitive `Fail`.

Use `Warning` when a layer has a generally identifiable purpose but some reviewed elements appear to carry responsibilities that are weakly aligned, unexplained, duplicated across layers, or inconsistent with the layer's stated or inferable responsibility.

Use `Warning` when responsibilities appear to be implied by convention rather than stated or consistently demonstrated, and the reviewed material provides enough evidence to identify a maintainability risk but not enough evidence to confirm a responsibility failure.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include an identifiable layered architecture structure, does not include identifiable layers, or concerns material outside Layered Architecture responsibility evaluation.

Use `Not Applicable` when the review question concerns dependency direction, business policy decision authority, layer bypassing, layer contracts, layer-specific responsibility placement, or another architectural concern without requiring evaluation of whether layer responsibilities are explicit and consistent.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify the layered structure, identify the layers in scope, determine each layer's architectural purpose, compare declared responsibilities with observed responsibilities, or resolve conflicting responsibility signals.

Use `Not Enough Evidence` when the only available signals are naming, folder structure, physical location, isolated excerpts, incomplete documentation, dependency existence, or absence of contrary evidence. Absence of evidence must not be converted into `Fail`.

# Severity Guidance

Assign higher severity when unclear, inconsistent, or contradictory layer responsibilities affect central architectural boundaries, broad portions of the reviewed scope, frequently changed areas, many callers, or responsibilities that many other components rely on.

Assign lower severity when the responsibility inconsistency is narrow, isolated, peripheral, locally understandable, reversible, or limited to a small area with minor architectural impact.

Severity must reflect demonstrated architectural and maintainability impact within the reviewed scope. Do not assign severity solely from the Layered Architecture category, the name of a layer, the number of layers, or the presence of dependency evidence.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the layered structure, the evaluated layers, their responsibilities, and whether those responsibilities are explicit, consistent, and non-contradictory within the reviewed scope.

Use `Likely` when multiple evidence points support the evaluation but direct confirmation of some layer responsibilities or responsibility consistency is incomplete.

Use `Possible` when evidence is limited, indirect, partially ambiguous, or relies on weak supporting signals that suggest responsibility clarity or inconsistency without conclusively establishing it.

Use `Not Enough Evidence` when the available material cannot support a reliable conclusion. Naming, layer labels, folder location, project names, namespace names, or physical placement alone must not produce `Confirmed` confidence.

# Dependencies

None

# References

LAYER_CATALOG.md

# Change Notes

Initial rule content for the Layered Architecture catalog.
