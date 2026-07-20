# Rule ID

LAYER-008

# Title

Layers must not bypass required intermediate layers

# Category

Layered Architecture

# Status

Active

# Intent

Ensure layer interactions do not skip required intermediate layers when the declared layered structure requires mediation.

# Applicability

Apply this rule when the reviewed material includes an identifiable layered architecture structure, at least three relevant layers or an explicitly mediated relationship between layers, and an interaction that could pass through an intermediate layer assigned a required mediation responsibility for the analyzed flow.

The rule is relevant when the reviewed scope provides enough evidence to compare the declared or clearly established layer interaction path with the path that is actually executed, referenced, configured, or otherwise used by the system.

Do not apply this rule only because two layers interact directly, because layers are not adjacent, because a layer exists physically between two other layers, or because a conventional layered architecture might often use an intermediate layer. The rule requires evidence that the intermediate mediation is mandatory for the specific layered structure and relevant flow being evaluated.

# Rule Statement

Layer interactions in a layered architecture must not bypass an intermediate layer whose mediation is required by the declared or clearly established layered structure for the flow being evaluated.

# Rationale

Layered Architecture uses intermediate layers to preserve assigned responsibilities such as coordination, policy application, validation, authorization, business operation mediation, data access mediation, infrastructure delegation, or other boundary responsibilities. When a required intermediate layer is bypassed, the executed path may avoid responsibilities that the architecture depends on for consistency, maintainability, and predictable behavior.

This concern is different from direct interaction by itself. A layered architecture may be open, may permit non-adjacent access, may define different paths for different flows, or may combine styles that authorize a direct contract between layers. The architectural risk appears only when a direct or alternate interaction skips a mediation responsibility that is mandatory and relevant for the analyzed flow.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed layered structure, the interacting layers, the intermediate layer or layers that may mediate the interaction, the declared or clearly established interaction path, the observed interaction path, and the responsibility that would be bypassed if mediation is skipped.

Direct evidence may include executable call flows, method behavior, handler or route configuration, project or module references, dependency declarations, type dependencies, constructor dependencies, contracts between layers, architecture tests, integration tests, traces or execution evidence, sequence diagrams, architectural documentation, architectural decisions, build rules, configuration that constrains layer paths, alternate paths for the same operation, or reviewed code excerpts tied to the layered structure.

Evidence must distinguish permitted dependency, direct interaction, bypass, mandatory mediation, optional mediation, internal call, delegation, cross-cutting access, exceptional flow, and legitimate composition between layers. Naming conventions, folder names, project names, namespace names, layer labels, diagrams, or documentation may support interpretation but must not be treated as conclusive evidence without corroborating structural, behavioral, or execution evidence.

Evidence should prioritize executable flows and traceable calls first, tests and traces that demonstrate the path second, structural dependencies third, architectural documentation and decisions fourth, and naming, directories, or diagrams without confirmation only as auxiliary supporting evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible layered architecture interpretation and whether the layers participating in the interaction can be identified. Then establish whether the intermediate layer has a mandatory mediation responsibility for the analyzed flow. Only after that compare the declared or expected interaction path with the observed path.

Evaluate only bypass of required intermediate layers. Do not use this rule to evaluate whether layer responsibilities are generally clear, whether dependencies follow the declared direction, whether presentation owns application or business behavior, whether an application or service layer owns business rules, whether business rules are located in the domain or business layer, whether persistence responsibilities are encapsulated, whether layer contracts preserve boundary integrity, ports and adapters, Clean Architecture dependency direction, Clean Architecture flow of control, Domain-Driven Design model quality, authorization security as an independent concern, observability, performance, or technology-specific implementation choices.

Interpret evidence conservatively. Non-adjacent access does not prove bypass, a direct dependency does not prove execution, and the physical existence of an intermediate layer does not make its participation mandatory in every flow. A direct interaction may be legitimate when the architecture declares open layers, the intermediate mediation is optional, the access is part of an explicitly permitted flow, the intermediate layer has no relevant responsibility for that interaction, an architectural exception is documented and consistent, the contact occurs through an authorized contract, the flow represents internal composition of the same architectural responsibility, or the architecture combines styles and defines a different path for that case.

When documentation and implementation conflict, make the conflict explicit and evaluate the strength of the available evidence. Documentation alone should not produce `Confirmed` confidence, and a documented exception should not be treated as automatically legitimate when traceable implementation evidence shows that it contradicts the architecture's applied mediation rules or creates inconsistent paths for the same responsibility.

Common finding patterns include direct access from an interaction layer to persistence when an application, service, data access, or infrastructure layer is required to mediate; direct invocation of business behavior when application coordination is mandatory; direct access to a concrete persistence or infrastructure mechanism that bypasses the layer assigned to that mediation; alternate administrative, asynchronous, batch, or privileged paths that avoid mediation used by main flows; endpoints or handlers that avoid validation, authorization, coordination, or policy responsibilities assigned to an intermediate layer; multiple paths for the same operation with inconsistent mediation; and temporary direct access that becomes a recurring architectural path. These patterns support findings only when corroborated by evidence that the skipped mediation is mandatory and relevant.

Remediation guidance should focus on restoring the required mediation path, clarifying whether the direct path is permitted, removing inconsistent alternate paths, or documenting and constraining legitimate exceptions. Recommendations should be derived from finding evidence and must not prescribe a universal strict layered model, a specific architecture style, or technology-specific implementation.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify the layered structure, the relevant interaction, the declared or clearly established mediation requirement, and the observed path, and the available evidence supports that required intermediate layers participate in the flow being evaluated.

Use `Pass` when direct interactions, non-adjacent interactions, callbacks, inversion of control, asynchronous communication, administrative paths, optimized reads, internal composition, or cross-cutting access are supported by evidence showing that mediation is optional, explicitly permitted, not relevant to the interaction, consistently excepted, or preserved through an authorized contract.

# Fail Conditions

Use `Fail` when direct evidence shows that an interaction between layers skips an intermediate layer whose mediation is mandatory for the analyzed flow and thereby bypasses a relevant architectural responsibility.

Use `Fail` when direct evidence shows that an alternate path performs the same or equivalent operation while avoiding validation, authorization, coordination, policy application, business operation mediation, data access mediation, infrastructure delegation, or another responsibility assigned to a required intermediate layer.

Use `Fail` when direct evidence shows recurring, privileged, administrative, asynchronous, batch, or temporary paths that have become effective architectural paths and bypass required mediation in a way that creates inconsistent behavior or boundary erosion.

# Warning Conditions

Use `Warning` when evidence indicates partial, localized, emerging, indirect, recurring, or inconsistent bypass of a potentially required intermediate layer, but the available material does not justify a definitive `Fail`.

Use `Warning` when direct interaction appears to skip a mediator and creates a maintainability or consistency risk, but the reviewed material leaves reasonable uncertainty about whether the mediation is mandatory, whether the intermediate layer has responsibility relevant to the interaction, or whether the observed path is an authorized exception.

Use `Warning` when documentation and implementation suggest different interaction paths and the reviewed material shows a risk of bypass or inconsistent mediation, but the evidence is not strong enough to conclude that a required intermediate layer has been definitively ignored.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include an identifiable layered architecture structure, does not include at least three relevant layers or another relationship with declared mediation, or does not include an interaction potentially subject to intermediate-layer mediation.

Use `Not Applicable` when the architecture does not require intermediate mediation for the analyzed flow, uses open layers for that interaction, explicitly permits the direct path, has fewer than three relevant layers, contains no cross-layer flow in scope, or assigns no relevant responsibility to the potentially intermediate layer.

Use `Not Applicable` when the review question concerns layer responsibility clarity, dependency direction, presentation behavior ownership, application or service rule ownership, domain or business rule ownership, persistence responsibility placement, layer contract integrity, ports and adapters, Clean Architecture flow, Domain-Driven Design modeling, security authorization as an independent concern, performance, or another architectural concern without requiring evaluation of bypassed intermediate-layer mediation.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify the layered structure, identify the interacting layers, establish whether intermediate mediation is mandatory, trace the observed interaction path, determine the responsibility of the intermediate layer, compare declared and executed paths, or resolve conflicting signals.

Use `Not Enough Evidence` when layers are identifiable but the reviewed material cannot determine whether mediation is required, when the flow cannot be traced, when documentation and implementation conflict without enough evidence to decide which path governs, when direct access appears only through naming or incomplete dependencies, when a claimed exception cannot be confirmed, or when intermediate components are unavailable for review.

Use `Not Enough Evidence` when the only available signals are naming, folder structure, physical location, project names, namespace names, layer labels, diagrams without confirmation, documentation alone, dependency existence without usage, incomplete call sequences, or absence of contrary evidence. Absence of evidence must not be converted into `Fail`.

# Severity Guidance

Assign higher severity when bypass skips a central mediation responsibility, affects critical flows, recurs across multiple paths, creates inconsistent behavior for the same operation, avoids validation, authorization, coordination, or policy responsibilities, expands direct access broadly, makes divergent behavior easy to introduce, or erodes an essential architectural layer systemically.

Assign lower severity when the bypass is narrow, isolated, peripheral, reversible, limited to a low-impact interaction, does not affect important mediation responsibilities, or is unlikely to affect broader maintainability of the layered structure.

Severity must distinguish localized low-impact bypass from recurring bypass in relevant flows, from multiple inconsistent paths, and from systemic bypass of an essential architectural layer. Severity must reflect demonstrated architectural and maintainability impact within the reviewed scope and must not use numeric scoring.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the layered structure, the interacting layers, the mandatory intermediate mediation, the observed interaction path, and whether the path respects or bypasses that mediation.

Use `Likely` when multiple consistent evidence points support the evaluation but direct confirmation of the mediation requirement, observed flow, exception status, or intermediate responsibility is incomplete.

Use `Possible` when evidence is limited, indirect, partially ambiguous, or relies on weak supporting signals that suggest conformance or bypass without conclusively establishing the required mediation and actual path.

Use `Not Enough Evidence` when the available material cannot support a reliable conclusion. Naming, directories, namespaces, layer labels, project names, physical placement, documentation alone, diagrams alone, or absence of contrary evidence must not produce `Confirmed` confidence.

# Dependencies

LAYER-002, LAYER-003, LAYER-004, LAYER-005, LAYER-007, LAYER-009. These are conceptual dependencies for shared layer responsibility, dependency direction, presentation boundary, application or service mediation, persistence responsibility, and contract vocabulary, not procedural prerequisites for evaluating this rule.

# References

LAYER_CATALOG.md

# Change Notes

Initial rule content for the Layered Architecture catalog.
