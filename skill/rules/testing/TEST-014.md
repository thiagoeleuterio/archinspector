# Rule ID

TEST-014

# Title

Architecture test determinism

# Category

Architecture Testing

# Status

Active

# Intent

Evaluate whether the same verifiable state produces consistent results without improper dependence on order, environment, or unstable external state.

This rule exists to keep architectural validation tied to evidence and proportionate to risk. It evaluates the verification mechanism, not the underlying architectural rule as its primary conclusion.

# Applicability

Apply this rule when architecture verification is executed or compared across runs, environments, machines, commits, branches, or delivery stages.

The rule may apply to automated checks, repeatable manual review, static analysis, dynamic validation, pipeline gates, local scripts, operational checks, documentation-supported controls, or equivalent verification mechanisms when those mechanisms are used as architectural evidence.

Use Not Applicable when verification is one-time exploratory, intentionally samples unstable external state, or determinism is outside the architectural risk. Legitimate absence may occur in small systems, prototypes, temporary systems, low-risk decisions, partial review scopes, externally governed controls, deliberately manual validation contexts, or properties that are not reasonably repeatable or automatable.

Do not apply this rule merely because a test file, architecture-testing library, naming convention, pipeline job, dashboard, comment, or architectural term exists without evidence that the mechanism performs this rule's responsibility.

# Rule Statement

An architectural verification mechanism must provide sufficient, traceable, and proportionate evidence of whether the same verifiable state produces consistent results without improper dependence on order, environment, or unstable external state, within the reviewed scope and without relying on nominal signals alone.

# Rationale

Architecture testing can create useful feedback only when the verification matches the architectural concern it claims to protect. Weak or misleading verification creates false confidence, hides drift, or causes teams to spend effort on failures that do not reflect architectural intent.

The architectural question is: Will the verification produce the same conclusion for the same architectural state? This rule does not require universal architecture tests, automation, a specific tool, CI/CD, execution on every commit, a numeric threshold, a percentage, zero exceptions, zero baselines, zero suppressions, or a particular language or framework.

# Evidence Required

Evaluation requires concrete and traceable evidence about the reviewed verification mechanism, the architectural concern it claims to validate, the selected scope, the rule logic or manual procedure, the observed or expected result, and the way that result is interpreted.

Primary evidence includes repeated execution, deterministic inputs, environment dependencies, ordering assumptions, randomization control, flaky history, network/time use, and logs. Stronger evidence includes executable or repeatable implementation, real selection of elements, effective assertions, configuration, execution results, positive and negative cases, tests of the mechanism, failure history, baselines, suppressions, ADRs, and documentation tied to the reviewed system.

Names, folders, comments, package presence, a file named ArchitectureTests, a green test result, a declared pipeline, a dashboard, or a tool installation are supporting signals only. They must not independently establish Pass, Fail, or Confirmed confidence.

# Evaluation Guidance

First establish applicability from reviewed evidence. If the rule's architectural verification concern is absent for legitimate contextual reasons, use Not Applicable. If the mechanism may exist but implementation, configuration, scope, or result is unavailable or contradictory, use Not Enough Evidence.

Then evaluate whether the verification satisfies this rule's exclusive responsibility: whether the same verifiable state produces consistent results without improper dependence on order, environment, or unstable external state. Interpret evidence conservatively and separate the verification mechanism from the underlying architecture condition. A violation of an architectural boundary, dependency rule, domain model, layer, event, SOLID principle, or solution decision belongs to that owning catalog unless the conclusion is about the adequacy of the validation mechanism.

Common finding shapes include: order-dependent result, where expected evidence is repeated runs and the problem is unstable ordering; uncontrolled environment, where expected evidence is environment inputs and logs and the problem is different conclusions for same state; flaky selector, where expected evidence is matched elements across runs and the problem is inconsistent selection.

Remediation guidance should control inputs, ordering, time, environment, and external state where proportionate; document intentional variability; isolate shared state; and avoid declaring every controlled environment dependency invalid.

Internal boundaries: TEST-018 owns when execution happens in delivery flow; TEST-019 owns maintenance fragility over time. Shared evidence may be used by neighboring rules, but this rule's conclusion remains independent and no neighboring rule is a procedural prerequisite.

Cross-catalog boundaries: do not use this rule to redefine global architecture quality, modularity, coupling, cohesion, maintainability, Hexagonal ports or adapters, Clean Architecture policy rings, DDD aggregates or bounded contexts, Layered Architecture dependencies, Fowler patterns, Events and Messaging semantics, SOLID principles, cloud topology, vendor decisions, product strategy, cost, or build-versus-buy choices. Those properties may be the thing being verified, but this rule concludes only on architectural verification adequacy.

# Pass Conditions

Use Pass when repeated execution or equivalent evidence shows the same verifiable architectural state produces consistent conclusions and any environment dependency is controlled or intentionally bounded.

Do not require a named tool, formal ADR, source-code implementation, exhaustive coverage, numeric threshold, percentage, CI/CD, execution on every commit, zero suppression, zero exception, or zero baseline for Pass.

# Fail Conditions

Use Fail only when applicability is confirmed, evidence is sufficient, and results vary for the same architectural state because of order dependence, shared state, uncontrolled time, network, environment, race conditions, or unstable selector output.

Do not use Fail merely because evidence is missing, the project lacks automation, the team uses manual validation, the repository lacks a specific tool, or the verification uses a different technology or process than expected.

# Warning Conditions

Use Warning when nondeterminism risk is plausible but intermittent, isolated, externally controlled, or not yet shown to undermine architectural feedback.

Do not use Warning as a substitute for Not Enough Evidence when the reviewed material cannot establish the relevant mechanism, scope, result, or risk.

# Not Applicable Conditions

Use Not Applicable when verification is one-time exploratory, intentionally samples unstable external state, or determinism is outside the architectural risk.

Not Applicable does not approve the underlying architecture and does not mean architectural drift, coupling, boundary weakness, or test weakness is absent.

# Not Enough Evidence Conditions

Use Not Enough Evidence when repeated execution, deterministic inputs, environment dependency evidence, flaky history, logs, or execution context are unavailable.

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

TEST-018, TEST-019. These are related Architecture Testing rules with adjacent responsibilities, not procedural prerequisites.

# References

RULE_MODEL.md

SPECIFICATION.md

TAXONOMY.md

ARCHITECTURE_TESTING_CATALOG.md

TEST-001.md

Neal Ford, Rebecca Parsons, and Patrick Kua, *Building Evolutionary Architectures*.

Mark Richards and Neal Ford, *Fundamentals of Software Architecture*.

# Change Notes

Initial creation of TEST-014.

Aligned with ARCHITECTURE_TESTING_CATALOG.md.

Aligned with the Gold Standard structure and semantic depth of TEST-001.md without copying it mechanically.

Aligned with RULE_MODEL.md.

Aligned with SPECIFICATION.md.

Aligned with TAXONOMY.md.

Stabilized Architecture Testing outcomes, common finding shapes, remediation guidance, and adjacent-rule boundaries for ARCH-TEST-CAT-REV-001 through ARCH-TEST-CAT-REV-004.
