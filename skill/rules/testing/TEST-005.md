# Rule ID

TEST-005

# Title

Dependency rule verification

# Category

Architecture Testing

# Status

Active

# Intent

Evaluate whether a dependency rule coherently verifies origin, destination, direction, and contextual conditions.

This rule exists to keep architectural validation tied to evidence and proportionate to risk. It evaluates the verification mechanism, not the underlying architectural rule as its primary conclusion.

# Applicability

Apply this rule when a test or check verifies dependency direction, allowed references, forbidden references, project references, package references, namespaces, or type dependencies.

The rule may apply to automated checks, repeatable manual review, static analysis, dynamic validation, pipeline gates, local scripts, operational checks, documentation-supported controls, or equivalent verification mechanisms when those mechanisms are used as architectural evidence.

Use Not Applicable when no dependency rule is claimed, dependency verification is irrelevant to the selected architecture, or another control intentionally covers the risk. Legitimate absence may occur in small systems, prototypes, temporary systems, low-risk decisions, partial review scopes, externally governed controls, deliberately manual validation contexts, or properties that are not reasonably repeatable or automatable.

Do not apply this rule merely because a test file, architecture-testing library, naming convention, pipeline job, dashboard, comment, or architectural term exists without evidence that the mechanism performs this rule's responsibility.

# Rule Statement

An architectural verification mechanism must provide sufficient, traceable, and proportionate evidence of whether a dependency rule coherently verifies origin, destination, direction, and contextual conditions, within the reviewed scope and without relying on nominal signals alone.

# Rationale

Architecture testing can create useful feedback only when the verification matches the architectural concern it claims to protect. Weak or misleading verification creates false confidence, hides drift, or causes teams to spend effort on failures that do not reflect architectural intent.

The architectural question is: Does the dependency verification actually check the intended source, target, direction, and conditions? This rule does not require universal architecture tests, automation, a specific tool, CI/CD, execution on every commit, a numeric threshold, a percentage, zero exceptions, zero baselines, zero suppressions, or a particular language or framework.

# Evidence Required

Evaluation requires concrete and traceable evidence about the reviewed verification mechanism, the architectural concern it claims to validate, the selected scope, the rule logic or manual procedure, the observed or expected result, and the way that result is interpreted.

Primary evidence includes dependency graph query, source selectors, target selectors, direction assertion, indirect dependency handling, conditions, exceptions, and execution result. Stronger evidence includes executable or repeatable implementation, real selection of elements, effective assertions, configuration, execution results, positive and negative cases, tests of the mechanism, failure history, baselines, suppressions, ADRs, and documentation tied to the reviewed system.

Names, folders, comments, package presence, a file named ArchitectureTests, a green test result, a declared pipeline, a dashboard, or a tool installation are supporting signals only. They must not independently establish Pass, Fail, or Confirmed confidence.

# Evaluation Guidance

First establish applicability from reviewed evidence. If the rule's architectural verification concern is absent for legitimate contextual reasons, use Not Applicable. If the mechanism may exist but implementation, configuration, scope, or result is unavailable or contradictory, use Not Enough Evidence.

Then evaluate whether the verification satisfies this rule's exclusive responsibility: whether a dependency rule coherently verifies origin, destination, direction, and contextual conditions. Interpret evidence conservatively and separate the verification mechanism from the underlying architecture condition. A violation of an architectural boundary, dependency rule, domain model, layer, event, SOLID principle, or solution decision belongs to that owning catalog unless the conclusion is about the adequacy of the validation mechanism.

Common finding shapes include: inverted direction, where expected evidence is source and target selectors and the problem is checking the opposite relationship; wrong dependency kind, where expected evidence is project, package, namespace, or type graph and the problem is analyzing a different dependency level; condition mismatch, where expected evidence is allowed context and exceptions and the problem is ignoring contextual rules.

Remediation guidance should correct origin and destination selectors, state dependency direction explicitly, include relevant dependency kinds, document contextual conditions, and route forbidden, allowed, cycle, or module-boundary concerns to adjacent Rules when those are the primary issue.

Internal boundaries: TEST-006 owns explicitly forbidden dependencies; TEST-007 owns precision of allowed sets; TEST-008 owns cycles; TEST-009 owns module boundaries. Shared evidence may be used by neighboring rules, but this rule's conclusion remains independent and no neighboring rule is a procedural prerequisite.

Cross-catalog boundaries: do not use this rule to redefine global architecture quality, modularity, coupling, cohesion, maintainability, Hexagonal ports or adapters, Clean Architecture policy rings, DDD aggregates or bounded contexts, Layered Architecture dependencies, Fowler patterns, Events and Messaging semantics, SOLID principles, cloud topology, vendor decisions, product strategy, cost, or build-versus-buy choices. Those properties may be the thing being verified, but this rule concludes only on architectural verification adequacy.

# Pass Conditions

Use Pass when dependency verification identifies the intended origin, destination, direction, dependency kind, and relevant conditions or exceptions with enough evidence to support the architectural conclusion.

Do not require a named tool, formal ADR, source-code implementation, exhaustive coverage, numeric threshold, percentage, CI/CD, execution on every commit, zero suppression, zero exception, or zero baseline for Pass.

# Fail Conditions

Use Fail only when applicability is confirmed, evidence is sufficient, and the verification checks the wrong direction, origin, destination, dependency kind, or condition, or cannot distinguish allowed from disallowed dependency relationships.

Do not use Fail merely because evidence is missing, the project lacks automation, the team uses manual validation, the repository lacks a specific tool, or the verification uses a different technology or process than expected.

# Warning Conditions

Use Warning when dependency verification is partly coherent but indirect dependencies, conditions, exception handling, or selector boundaries are incomplete or ambiguous without confirmed architectural failure.

Do not use Warning as a substitute for Not Enough Evidence when the reviewed material cannot establish the relevant mechanism, scope, result, or risk.

# Not Applicable Conditions

Use Not Applicable when no dependency rule is claimed, dependency verification is irrelevant to the selected architecture, or another proportionate control intentionally covers the risk.

Not Applicable does not approve the underlying architecture and does not mean architectural drift, coupling, boundary weakness, or test weakness is absent.

# Not Enough Evidence Conditions

Use Not Enough Evidence when the dependency graph, source selector, target selector, rule logic, execution result, exception context, or architectural decision is unavailable or too narrow to evaluate coherence.

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

TEST-006, TEST-007, TEST-008, TEST-009. These are related Architecture Testing rules with adjacent responsibilities, not procedural prerequisites.

# References

RULE_MODEL.md

SPECIFICATION.md

TAXONOMY.md

ARCHITECTURE_TESTING_CATALOG.md

TEST-001.md

Neal Ford, Rebecca Parsons, and Patrick Kua, *Building Evolutionary Architectures*.

Mark Richards and Neal Ford, *Fundamentals of Software Architecture*.

# Change Notes

Initial creation of TEST-005.

Aligned with ARCHITECTURE_TESTING_CATALOG.md.

Aligned with the Gold Standard structure and semantic depth of TEST-001.md without copying it mechanically.

Aligned with RULE_MODEL.md.

Aligned with SPECIFICATION.md.

Aligned with TAXONOMY.md.

Stabilized Architecture Testing outcomes, common finding shapes, remediation guidance, and adjacent-rule boundaries for ARCH-TEST-CAT-REV-001 through ARCH-TEST-CAT-REV-004.
