# Expected Result - EVAL-TEST-002

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-TEST-002-EXPECTED` |
| Scenario ID | `EVAL-TEST-002` |
| Scenario Title | `Architecture test detects a forbidden dependency with actionable diagnostics` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-TEST-002` |
| Title | `Architecture test detects a forbidden dependency with actionable diagnostics` |
| Category | `Architecture Testing` |
| Scenario Type | `Positive Compliance` |
| Catalogs | `Architecture Testing` |
| Primary Rule | `TEST-015` |
| Supporting Rules | `TEST-005`, `TEST-006`, `TEST-018` |
| Execution Type | `Executable Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the textual executable-fixture manifest in `evaluation/scenarios/testing/EVAL-TEST-002.md`.

The scope includes the dependency verification, selected scopes, detected seeded dependency, failure output, retained report, local execution, and documented delivery verification step.

The scope excludes compilable code, real test project files, complete dependency graph, full suite output, full CI provider configuration, runtime logs, functional coverage, and global architecture conformance.

## 4. Primary Rule Result

| Field | Expected Value |
| --- | --- |
| Rule ID | `TEST-015` |
| Applicability | `Applicable` |
| Outcome | `Pass` |
| Confidence | `Likely` |
| Severity | `Not Applicable` |
| Finding Required | `No` |
| Finding Count | `0` |
| Evidence Strength | `Strong` |
| Result Status | `Match` |

## 5. Supporting Rule Results

| Rule ID | Applicability | Expected Outcome | Expected Confidence | Expected Severity Range | Expected Finding | Expected Evidence | Forbidden Finding | Boundary Notes | Acceptance Criteria |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `TEST-005` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Likely`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive dependency-rule defect is reported | `No` | Source, target, and direction support diagnostic context. | A dependency-rule finding that merely restates adequate diagnostics. | Preserve dependency-rule coherence boundary. | No separate finding unless direction or dependency-kind evidence is independently defective. |
| `TEST-006` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Likely`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive detection defect is reported | `No` | Seeded forbidden dependency is detected. | A forbidden-detection finding that duplicates the diagnostic pass. | Preserve detection boundary. | No separate finding unless detection reliability is independently evaluated. |
| `TEST-018` | `Applicable` or `Undetermined` | `Pass`, `Warning`, `Not Enough Evidence`, or no separate result | `Possible`, `Likely`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive execution finding evidence is reported | `No` | Local and delivery execution notes support context. | A pipeline finding based only on incomplete provider details. | Preserve execution boundary without requiring universal CI. | No separate finding unless execution timing is the evaluated issue. |

Supporting Rules may be mentioned as related rules, boundary references, expected non-findings, or forbidden duplicate findings. They do not require findings for this scenario.

## 6. Expected Finding

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: TEST-015
Outcome: Pass
Confidence: Likely
Severity: Not Applicable
Applicability: Applicable
Evidence: The verification failure output names the violated constraint, source component, target component, dependency kind, result, retained report, and proportionate repair direction.
Architectural Impact: No corrective diagnostic impact is present because the failure can be understood and acted on within the reviewed scope.
Regression Risk: Diagnostics are strong enough to reduce misfix or ignored-failure risk for the demonstrated dependency rule.
Enforcement Impact: Failure output supports the enforcement mechanism but does not prove full architecture conformance.
Rationale: TEST-015 pass conditions are satisfied by actionable failure diagnostics for the reviewed forbidden dependency check.
Remediation: None. Preserve the diagnostic fields and result retention as the verification evolves.
Related Rules: TEST-005, TEST-006, TEST-018
Boundary Notes: The result concludes only diagnostic adequacy. It must not become a global pass for the underlying architecture.
```

## 7. Expected Finding Evidence

Required no-finding evidence:

- violated constraint is named;
- source component is named;
- target component is named;
- dependency kind is named;
- failure result is visible;
- output is retained;
- concise repair direction is provided;
- conclusion is limited to diagnostic quality.

## 8. Expected Architectural Impact

The expected impact is absence of corrective diagnostic impact.

The verification failure output is actionable for the reviewed dependency rule, while global architecture quality remains outside scope.

## 9. Expected Rationale

`TEST-015` applies because the verification can fail and produce output.

The expected outcome is `Pass` because the failure output identifies the violated constraint, involved elements, context, and next action sufficiently for the reviewed risk.

## 10. Expected Remediation

No corrective remediation is expected.

Observed output may recommend preserving diagnostic fields and retained reports. It must not prescribe a specific tool, CI system, report format, threshold, or architecture rewrite.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- underlying architecture conformance;
- underlying architecture violation beyond the seeded case;
- absence of a specific testing library;
- lack of a project named `ArchitectureTests`;
- incomplete full CI provider configuration;
- lack of whole-system architecture-test coverage;
- absence of Clean, Hexagonal, Layered, DDD, or microservices;
- imperfect but adequate diagnostic wording.

## 12. Expected Applicability

Applicability is `Applicable`.

The manifest provides a verification with a failure mode and observable failure output.

## 13. Expected Outcome

Outcome is `Pass`.

The observed result must pass the Primary Rule because diagnostic output is actionable in the reviewed scope.

## 14. Expected Confidence

Confidence is `Likely`.

The diagnostic output is strong, but the fixture is textual and does not include complete executable project artifacts.

## 15. Expected Severity

Severity is `Not Applicable`.

No corrective finding is expected.

## 16. Expected Evidence Interpretation

The failure output must be interpreted as evidence for diagnostic quality only.

It must not become proof that the underlying architecture is globally compliant or that the whole architecture-test suite is sufficient.

## 17. Expected Boundary Behavior

### Architecture Testing Internal Boundaries

`TEST-015` owns diagnostic adequacy. `TEST-005`, `TEST-006`, and `TEST-018` may provide context but do not own the primary no-finding result.

### Architecture Testing x Neighboring Catalogs

Underlying dependency conditions may belong to Clean, Hexagonal, or Layered rules in other scenarios. This scenario does not require such findings.

## 18. Expected Deduplication Behavior

Shared evidence is permitted.

Forbidden duplicate patterns include:

- a `TEST-005` result that repeats diagnostic adequacy;
- a `TEST-006` result that repeats detection success as diagnostic quality;
- a `TEST-018` finding based only on incomplete CI details;
- a Clean, Hexagonal, or Layered conclusion inferred from one diagnostic output.

## 19. Expected False Positive Protection

The expected result must avoid findings based only on concise output, absence of full suite data, lack of a specific tool, or lack of perfect diagnostic detail.

## 20. Expected False Negative Protection

The expected result must not pass if failure output lacks the violated rule, involved elements, retained report, or action context.

## 21. Allowed Result Variations

Allowed variations:

- equivalent diagnostic wording;
- equivalent component names;
- `Confirmed` confidence if textual output is treated as fully direct;
- omission of supporting Rule results when decorative;
- result status `Acceptable Variation` only when `Pass`, no finding, and `TEST-015` ownership remain.

## 22. Disallowed Result Variations

Disallowed variations:

- primary outcome other than `Pass`;
- applicability other than `Applicable`;
- corrective diagnostic finding;
- severity assigned as a violation;
- global architecture pass inferred from one check;
- Primary Rule changed away from `TEST-015`;
- nonexistent Rule ID;
- mandatory specific tool, CI product, or report format.

## 23. Comparison Method

Compare observed output against this expected result by checking scenario identity, Primary Rule identity, applicability, outcome, confidence, severity, required finding absence, evidence interpretation, expected non-findings, false-positive guards, false-negative guards, boundary behavior, deduplication behavior, remediation absence or proportionality, and traceability.

Manual comparison is sufficient for this textual executable-fixture scenario.

## 24. Acceptance Criteria

The observed result is accepted when:

- `TEST-015` is the Primary Rule result;
- applicability is `Applicable`;
- outcome is `Pass`;
- confidence is `Likely` or accepted stronger confidence;
- severity is `Not Applicable`;
- no corrective finding is present;
- expected non-findings are absent;
- boundary ownership is preserved;
- duplicate findings are absent;
- remediation is absent or non-corrective;
- result status is `Match` or an allowed variation explicitly classified as acceptable.

## 25. Failure Criteria

The observed result fails when:

- any corrective diagnostic finding appears;
- result is `Fail`, `Warning`, `Not Applicable`, or `Not Enough Evidence`;
- confidence contradicts evidence strength;
- expected non-findings appear;
- Primary Rule is nonexistent or reassigned;
- remediation is prescriptive beyond evidence;
- boundary behavior contradicts the scenario.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only when it stays within allowed variations and preserves the required architectural conclusion.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/testing/EVAL-TEST-002.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |
| Primary Rule normative file | `skill/rules/testing/TEST-015.md` |
| Supporting Rule | `skill/rules/testing/TEST-005.md` |
| Supporting Rule | `skill/rules/testing/TEST-006.md` |
| Supporting Rule | `skill/rules/testing/TEST-018.md` |
| Cataloged supporting Rule | `skill/rules/testing/TEST-004.md` |
| Architecture Testing catalog review | `skill/reviews/ARCHITECTURE_TESTING_CATALOG_REVIEW.md` |
| Architecture Testing catalog stabilization | `skill/reviews/ARCHITECTURE_TESTING_CATALOG_STABILIZATION.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Gold Standard stabilization | `evaluation/stabilizations/EVAL-CORE-001-STABILIZATION.md` |

## 28. Gold Standard Result Requirements

This expected result follows the gold standard reference for structure, identity, evidence interpretation, applicability, outcome, confidence, severity, required finding behavior, atomicity, remediation, expected non-findings, false-positive protection, false-negative protection, boundary behavior, deduplication, allowed variations, disallowed variations, comparison method, and traceability.

It does not redefine Rule meaning or catalog ownership.

## 29. Result Change Notes

Initial expected result for `EVAL-TEST-002`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `TEST-015`, selected Supporting Rules, and expected `Pass` result.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
