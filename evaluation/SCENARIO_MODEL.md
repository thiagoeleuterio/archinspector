# Evaluation Scenario Model

## 1. Purpose

The Evaluation Scenario Model defines the required structure for future ArchInspector evaluation scenarios.

A scenario describes an evaluation situation, its architectural context, provided and withheld evidence, expected behavior, boundary expectations, and traceability. It must not redefine the Rule being evaluated.

## 2. Scenario Identity

Each future scenario must include:

- Scenario ID;
- Title;
- Category;
- Catalogs;
- Primary Rule;
- Supporting Rules;
- Risk Level;
- Execution Type;
- Status.

Scenario IDs must use:

```text
EVAL-<CATALOG>-<NNN>
```

Valid examples include:

```text
EVAL-CORE-001
EVAL-HEX-001
EVAL-CLEAN-001
EVAL-DDD-001
EVAL-LAYER-001
EVAL-FOWLER-001
EVAL-MSG-001
EVAL-TEST-001
EVAL-CROSS-001
EVAL-FULL-001
```

These are ID examples only and do not create scenarios.

## 3. Scenario Metadata

Scenario metadata must record ownership and lifecycle context for the scenario.

Required metadata includes category, risk level, execution type, status, source version, related expected result, related coverage dimensions, and change notes.

Allowed `Execution Type` values are:

- `Static Fixture`;
- `Executable Fixture`;
- `Document Fixture`;
- `Mixed Fixture`;
- `Manual Evaluation`.

Allowed `Status` values are:

- `Draft`;
- `Ready`;
- `Executed`;
- `Passed`;
- `Failed`;
- `Blocked`;
- `Deprecated`.

## 4. Architectural Context

The architectural context must describe the system shape, reviewed scope, relevant architecture style, known constraints, and any context needed to interpret applicability.

The context must distinguish reviewed facts from assumed or withheld information.

## 5. Target Rules

Target Rules must identify one primary Rule and any supporting Rules.

The primary Rule owns the expected result. Supporting Rules may clarify boundaries, shared evidence, or expected non-findings, but they must not duplicate the primary Rule's responsibility.

## 6. Input Artifacts

Input artifacts describe the materials available to ArchInspector during evaluation.

Allowed artifact types include code fixtures, directory structures, configuration files, dependency data, diagrams, architectural documents, review reports, manual observations, automated outputs, executable projects, and mixed artifact sets.

## 7. Preconditions

Preconditions define the state that must be true before execution.

Preconditions may describe required files, available documents, intended scope, fixture state, manual review setup, or previous expected results. They must not require a specific language, framework, test tool, CI/CD system, container, cloud provider, AST parser, compiler, or automatic execution unless the scenario itself explicitly provides that artifact type.

## 8. Architecture State

Architecture state defines the condition under evaluation.

It may represent compliance, violation, warning risk, legitimate absence, insufficient evidence, false-positive guard, false-negative guard, internal boundary, cross-catalog boundary, multiple findings, conflicting evidence, partial scope, manual validation, automated validation, regression, exception governance, determinism, or report consistency.

## 9. Evidence Provided

Evidence provided must list the concrete material available for evaluation and explain why it is relevant.

Evidence may include strong, partial, nominal, contradictory, absent, manual, automated, structural, behavioral, configuration, documentation, or report evidence.

## 10. Evidence Withheld

Evidence withheld must list intentionally unavailable material and explain how its absence affects scope, confidence, applicability, or expected outcome.

Withheld evidence prevents unsupported conclusions and supports explicit `Not Enough Evidence` or partial-scope expectations.

## 11. Expected Findings

Expected findings define the findings that must appear when the scenario is evaluated.

Each expected finding must specify primary Rule, expected outcome, expected confidence, expected severity range, scope, required evidence, reasoning expectation, and remediation expectation.

## 12. Expected Outcomes

Expected outcomes define the required status for each evaluated Rule.

Allowed values are:

- `Pass`;
- `Fail`;
- `Warning`;
- `Not Applicable`;
- `Not Enough Evidence`.

## 13. Expected Confidence

Expected confidence defines the required confidence value or accepted confidence range based on evidence strength.

Allowed values are:

- `Confirmed`;
- `Likely`;
- `Possible`;
- `Not Enough Evidence`.

## 14. Expected Severity

Expected severity defines contextual impact expectations for findings.

Severity must be expressed as a contextual expectation or allowed range. It must not be fixed universally by Rule category, technology, scenario category, sequence number, score, percentage, or arbitrary threshold.

## 15. Expected Non-Findings

Expected non-findings define violations, warnings, or findings that must not appear.

They protect legitimate absence, false-positive guards, boundary ownership, and duplicate finding control.

## 16. False Positive Guards

False-positive guards identify evidence that could be misread as a violation but must not produce a finding.

Each guard must define the prohibited finding, why it is prohibited, and the evidence that makes the absence legitimate or compliant.

## 17. False Negative Guards

False-negative guards identify evidence that could hide or soften a real violation.

Each guard must define the required finding, the misleading signal, and the evidence that requires detection.

## 18. Boundary Expectations

Boundary expectations define how internal Rule boundaries and cross-catalog boundaries must behave.

They must identify owner Rule, supporting Rules, shared evidence, prohibited duplication, and prohibited reassignment of responsibility.

## 19. Execution Instructions

Execution instructions describe how to run or perform the scenario evaluation.

Instructions may be manual, automated, static, document-based, executable, or mixed. They must remain technology-neutral unless the scenario's provided artifacts require a specific form of execution.

## 20. Acceptance Criteria

A scenario is accepted when:

- required evidence is available;
- expected findings appear;
- expected non-findings remain absent;
- outcomes match expected results;
- confidence follows evidence strength;
- severity is proportional to context;
- boundaries are preserved;
- coverage dimensions are updated;
- report expectations are satisfied when applicable;
- allowed variations stay within defined limits.

## 21. Failure Criteria

A scenario fails when:

- a required finding is missing;
- a forbidden finding appears;
- outcome, confidence, severity, applicability, or remediation contradicts expected behavior;
- insufficient evidence is treated as confirmed evidence;
- legitimate absence is treated as violation;
- Rule ownership is reassigned incorrectly;
- duplicate findings appear;
- report output contradicts scenario expectations;
- observed behavior changes without allowed variation.

## 22. Traceability

Traceability must connect scenario identity, target Rules, input artifacts, expected result, observed result, coverage dimensions, related reviews, related stabilizations, and change notes.

No result should be accepted without traceability to the evidence and expected behavior it validates.

## 23. Scenario Change Notes

Scenario change notes must record meaningful changes to identity, category, artifacts, evidence, expected findings, expected outcomes, boundary expectations, execution instructions, or acceptance criteria.

Change notes must not silently change Rule meaning, catalog ownership, official outcomes, confidence vocabulary, or report obligations.
