# Rule ID

TEST-002

# Title

Architectural decision traceability

# Category

Architecture Testing

# Status

Active

# Intent

Evaluate whether an architectural verification has a traceable link to a real architectural decision, constraint, principle, risk, or quality attribute.

This rule exists to keep architectural validation tied to evidence and proportionate to risk. It evaluates the verification mechanism, not the underlying architectural rule as its primary conclusion.

# Applicability

Apply this rule when architectural verification is declared, implemented, or used as evidence of an architectural decision, constraint, principle, risk, or quality attribute.

The rule may apply to automated checks, repeatable manual review, static analysis, dynamic validation, pipeline gates, local scripts, operational checks, documentation-supported controls, or equivalent verification mechanisms when those mechanisms are used as architectural evidence.

Use Not Applicable when no architectural verification is claimed, the decision has no recurring validation need, the verification is exploratory, or the origin is intentionally maintained outside the reviewed scope. Legitimate absence may occur in small systems, prototypes, temporary systems, low-risk decisions, partial review scopes, externally governed controls, deliberately manual validation contexts, or properties that are not reasonably repeatable or automatable.

Do not apply this rule merely because a test file, architecture-testing library, naming convention, pipeline job, dashboard, comment, or architectural term exists without evidence that the mechanism performs this rule's responsibility.

# Rule Statement

An architectural verification mechanism must provide sufficient, traceable, and proportionate evidence of whether an architectural verification has a traceable link to a real architectural decision, constraint, principle, risk, or quality attribute, within the reviewed scope and without relying on nominal signals alone.

# Rationale

Architecture testing can create useful feedback only when the verification matches the architectural concern it claims to protect. Weak or misleading verification creates false confidence, hides drift, or causes teams to spend effort on failures that do not reflect architectural intent.

The architectural question is: Can the reviewed verification be traced to a real architectural origin rather than only to a nominal test name or local preference? This rule does not require universal architecture tests, automation, a specific tool, CI/CD, execution on every commit, a numeric threshold, a percentage, zero exceptions, zero baselines, zero suppressions, or a particular language or framework.

# Evidence Required

Evaluation requires concrete and traceable evidence about the reviewed verification mechanism, the architectural concern it claims to validate, the selected scope, the rule logic or manual procedure, the observed or expected result, and the way that result is interpreted.

Primary evidence includes ADRs, decision records, constraint text, rule documentation, verification implementation, test names corroborated by logic, review scope, risk registers, architecture principles, and change history. Stronger evidence includes executable or repeatable implementation, real selection of elements, effective assertions, configuration, execution results, positive and negative cases, tests of the mechanism, failure history, baselines, suppressions, ADRs, and documentation tied to the reviewed system.

Names, folders, comments, package presence, a file named ArchitectureTests, a green test result, a declared pipeline, a dashboard, or a tool installation are supporting signals only. They must not independently establish Pass, Fail, or Confirmed confidence.

# Evaluation Guidance

First establish applicability from reviewed evidence. If the rule's architectural verification concern is absent for legitimate contextual reasons, use Not Applicable. If the mechanism may exist but implementation, configuration, scope, or result is unavailable or contradictory, use Not Enough Evidence.

Then evaluate whether the verification satisfies this rule's exclusive responsibility: whether an architectural verification has a traceable link to a real architectural decision, constraint, principle, risk, or quality attribute. Interpret evidence conservatively and separate the verification mechanism from the underlying architecture condition. A violation of an architectural boundary, dependency rule, domain model, layer, event, SOLID principle, or solution decision belongs to that owning catalog unless the conclusion is about the adequacy of the validation mechanism.

Common finding shapes include: untraceable verification, where expected evidence is an ADR, decision record, risk statement, principle, or reviewed documentation and the problem is a check with no architectural origin; obsolete traceability, where expected evidence is current decision material and the problem is a verification tied to a superseded decision; nominal traceability, where expected evidence is implementation plus corroborating decision context and the problem is a name or comment standing in for real origin evidence.

Remediation guidance should link the verification to the actual decision, constraint, risk, principle, quality attribute, or reviewed manual process; update stale references; remove unsupported architectural claims; or document why the origin is outside scope. Do not require a formal ADR, traceability tool, automation, CI, threshold, or framework when reviewed evidence gives another proportionate trace.

Internal boundaries: TEST-001 defines the fitness function; TEST-003 owns objective constraint testability; TEST-017 owns later regression detection. Shared evidence may be used by neighboring rules, but this rule's conclusion remains independent and no neighboring rule is a procedural prerequisite.

Cross-catalog boundaries: do not use this rule to redefine global architecture quality, modularity, coupling, cohesion, maintainability, Hexagonal ports or adapters, Clean Architecture policy rings, DDD aggregates or bounded contexts, Layered Architecture dependencies, Fowler patterns, Events and Messaging semantics, SOLID principles, cloud topology, vendor decisions, product strategy, cost, or build-versus-buy choices. Those properties may be the thing being verified, but this rule concludes only on architectural verification adequacy.

# Pass Conditions

Use Pass when the reviewed verification is linked by traceable evidence to a real architectural decision, constraint, principle, risk, or quality attribute and the link is sufficient for the reviewed scope. The trace may come from ADRs, decision records, rule documentation, reviewed code or process evidence, or other explicit material; a formal ADR is not universally required.

Do not require a named tool, formal ADR, source-code implementation, exhaustive coverage, numeric threshold, percentage, CI/CD, execution on every commit, zero suppression, zero exception, or zero baseline for Pass.

# Fail Conditions

Use Fail only when applicability is confirmed, evidence is sufficient, and the verification is presented as architectural validation but has no real architectural origin, references an obsolete or unrelated decision, or cannot be connected to the risk or constraint it claims to protect.

Do not use Fail merely because evidence is missing, the project lacks automation, the team uses manual validation, the repository lacks a specific tool, or the verification uses a different technology or process than expected.

# Warning Conditions

Use Warning when the verification has a plausible architectural origin but traceability is partial, implicit, stale, fragmented, or ambiguous without enough evidence to confirm failure.

Do not use Warning as a substitute for Not Enough Evidence when the reviewed material cannot establish the relevant mechanism, scope, result, or risk.

# Not Applicable Conditions

Use Not Applicable when no architectural verification is claimed, when the decision has no recurring validation need, when verification is exploratory only, or when the architectural origin is intentionally maintained outside the reviewed scope.

Not Applicable does not approve the underlying architecture and does not mean architectural drift, coupling, boundary weakness, or test weakness is absent.

# Not Enough Evidence Conditions

Use Not Enough Evidence when the verification may be architectural but the reviewed material lacks the decision, risk, constraint, implementation, documentation, or context needed to establish traceability.

Do not convert absence of evidence into Fail. Keep uncertainty visible through status and confidence.

# Severity Guidance

Assign severity from demonstrated architectural impact in the reviewed scope. Consider the criticality of the decision, affected modules or services, recurrence, operational impact, security, regulatory or financial exposure, propagation of dependency risk, recovery difficulty, false sense of conformance, controls available elsewhere, and ability to detect problems later.

Severity may be high when weak verification protects critical boundaries or broad release/governance confidence. Severity may be medium or low when the issue is narrow, local, low-risk, experimental, easy to inspect manually, or mitigated by alternative controls.

Do not define fixed severity, scores, formulas, percentages, arbitrary thresholds, or automatic mappings from outcome to severity.

# Confidence Guidance

Use Confirmed when direct, traceable evidence establishes the mechanism, scope, relevant architectural concern, verification behavior, result, and interpretation needed to support the selected outcome.

Use Likely when multiple consistent evidence points support the evaluation but some direct confirmation is incomplete. Use Possible when evidence is limited, indirect, naming-based with partial corroboration, structurally suggestive, or enough only to identify a potential risk.

Use Not Enough Evidence when material cannot support a useful confidence level because the mechanism, scope, result, decision, or interpretation is missing, opaque, conflicting, or outside the reviewed material.

Confidence is independent from outcome and severity. Naming, folders, comments, installed tools, or green test status alone must not produce Confirmed.

# Dependencies

TEST-001, TEST-003, TEST-004, TEST-017. These are related Architecture Testing rules with adjacent responsibilities, not procedural prerequisites.

# References

RULE_MODEL.md

SPECIFICATION.md

TAXONOMY.md

ARCHITECTURE_TESTING_CATALOG.md

TEST-001.md

Neal Ford, Rebecca Parsons, and Patrick Kua, *Building Evolutionary Architectures*.

Mark Richards and Neal Ford, *Fundamentals of Software Architecture*.

# Change Notes

Initial creation of TEST-002.

Aligned with ARCHITECTURE_TESTING_CATALOG.md.

Aligned with the Gold Standard structure and semantic depth of TEST-001.md without copying it mechanically.

Aligned with RULE_MODEL.md.

Aligned with SPECIFICATION.md.

Aligned with TAXONOMY.md.

Stabilized Architecture Testing outcomes, common finding shapes, remediation guidance, and adjacent-rule boundaries for ARCH-TEST-CAT-REV-001 through ARCH-TEST-CAT-REV-004.
