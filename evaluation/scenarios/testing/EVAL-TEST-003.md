# EVAL-TEST-003 - Architecture Exception Has Owner, Justification and Expiration

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-TEST-003` |
| Title | `Architecture exception has owner, justification and expiration` |
| Category | `Architecture Testing` |
| Scenario Type | `Exception Governance` |
| Catalogs | `Architecture Testing` |
| Primary Rule | `TEST-016` |
| Supporting Rules | `TEST-006`, `TEST-012`, `TEST-017` |
| Catalog Supporting Rules | `TEST-006`, `TEST-012`, `TEST-017`, `TEST-019` |
| Risk Level | `Medium` |
| Execution Type | `Document Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Implementation Order | `33` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/testing/EVAL-TEST-003-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `TEST-016`; catalog coverage for Architecture Testing; `Pass` outcome; expected `Likely` confidence; contextual absence of severity; partial evidence; applicability; exception governance; false-positive guard; false-negative guard; deduplication; remediation absence. |

## 2. Purpose

This scenario validates that ArchInspector accepts a governed architecture exception and does not report a failure merely because an exception, suppression, or allowed deviation exists.

The scenario protects exception governance, positive compliance, false-positive control, broad-suppression false-negative control, and proportional remediation.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Exception Governance` |
| Secondary Types | `Positive Compliance`, `False Positive Guard` |
| Primary Outcome | `Pass` |
| Evidence Strength | `Partial` |
| Applicability | `Applicable` |
| Confidence | `Likely` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious billing-support system with an architectural rule that reporting adapters must not depend directly on a legacy export package.

One temporary exception exists for `MonthlyStatementExportAdapter`. The reviewed document provides owner, justification, scope, expiration date, review cadence, and the exact dependency path allowed. The exception is narrow, time-boxed, and tied to a migration plan. No evidence shows that the exception hides new violations or disables the rule globally.

The scenario evaluates exception governance only. It does not approve or reject the underlying dependency rule globally.

## 5. Target Catalogs

`Architecture Testing` owns the scenario because the evaluated condition is governance of exceptions in architecture verification.

Neighboring architecture catalogs may own the underlying dependency condition, but the expected result belongs to `TEST-016`.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `TEST-016` |
| Title | `Architecture exception governance` |
| Category | `Architecture Testing` |
| Status | `Active` |
| Normative File | `skill/rules/testing/TEST-016.md` |
| Catalog File | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |

`TEST-016` is selected because the scenario centers on justification, ownership, scope, and lifecycle control for an accepted architecture deviation. `TEST-006`, `TEST-012`, and `TEST-017` are supporting boundaries for forbidden dependency detection, false-positive control, and regression detection.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `TEST-006` | Boundary reference for the forbidden dependency rule that the exception narrows. |
| `TEST-012` | Boundary reference for avoiding false failures when an allowed deviation is governed. |
| `TEST-017` | Boundary reference for ensuring later regressions are not silently folded into accepted state. |

`TEST-019` is cataloged as related support but is not selected as an operative supporting rule because concrete scenarios use a maximum of three supporting rules.

## 8. Input Artifacts

The scenario input is a textual document fixture. It is not executable and must not be treated as compilable code.

The document fixture includes:

- architectural rule summary;
- exception registry row;
- owner;
- justification;
- scope;
- expiration;
- review cadence;
- baseline behavior;
- evidence withheld.

## 9. Directory Structure

```text
billing-support/
  docs/
    architecture-exceptions
  verification/
    forbidden-dependencies
  reporting/
    MonthlyStatementExportAdapter
```

Directory names are supporting context only. The expected pass depends on exception metadata, not folder labels.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `ArchitectureException EX-2026-04` | Governed exception. | Contains owner, justification, expiration, scope, and review cadence. |
| `MonthlyStatementExportAdapter` | Scoped allowed deviation. | The only allowed source component. |
| `LegacyStatementExporter` | Temporary target dependency. | The only allowed target component. |
| `ForbiddenDependencyCheck` | Architecture verification. | Continues to run for all other reporting adapters. |
| `ArchitectureReviewLog` | Manual governance record. | Shows the exception is reviewed monthly until expiration. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `MonthlyStatementExportAdapter` | `LegacyStatementExporter` | Scoped accepted dependency | Temporarily allowed by `EX-2026-04`. |
| Other reporting adapters | `LegacyStatementExporter` | Forbidden dependency | Still prohibited by the verification. |
| `ForbiddenDependencyCheck` | exception registry | Exclusion lookup | Uses a narrow exception rather than disabling the rule. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Define prohibited dependency | Architecture verification | Provided |
| Approve temporary exception | Architecture review owner | Provided |
| Justify deviation | Exception registry | Provided |
| Scope allowed path | Exception registry | Provided narrowly |
| Review or expire exception | Architecture owner | Provided |
| Detect new violations | Verification and regression review | Still expected outside the exception |

## 13. Execution Flow

1. The dependency verification evaluates reporting adapters.
2. The verification encounters `MonthlyStatementExportAdapter` referencing `LegacyStatementExporter`.
3. The exception registry authorizes only that source-target pair.
4. The verification continues rejecting the same target from other adapters.
5. The review log requires monthly review and expiration on the recorded date.

## 14. Preconditions

- The evaluator receives the document fixture as the complete scenario input.
- The evaluator treats exception metadata as reviewed evidence.
- The evaluator does not assume hidden source code, execution logs, or complete history.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is governed exception compliance.

The reviewed material shows an exception mechanism and provides enough partial evidence to determine that the accepted deviation is justified, scoped, owned, and time-bound within the provided scope.

## 16. Evidence Provided

Partial evidence is provided:

- exception ID `EX-2026-04`;
- owner `Architecture Review Group`;
- specific source and target;
- migration justification;
- expiration date;
- monthly review cadence;
- statement that other reporting adapters remain blocked;
- baseline note distinguishing accepted deviation from new violations.

Short non-compilable exception registry entry:

```text
exception EX-2026-04
  rule = Reporting adapters must not reference legacy export package
  allowedSource = MonthlyStatementExportAdapter
  allowedTarget = LegacyStatementExporter
  owner = Architecture Review Group
  reason = temporary migration bridge for regulated monthly statements
  expires = 2026-10-31
  reviewCadence = monthly
  newViolations = rejected
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- executable verification files;
- compilable code;
- full dependency graph;
- complete suppression history;
- all baseline files;
- full CI configuration;
- runtime logs;
- production incidents;
- complete migration plan;
- all architecture decisions.

Withheld evidence prevents global suite approval, full regression approval, or broad architecture conformance conclusions beyond the governed exception record.

## 18. Expected Findings

No corrective finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: TEST-016
Outcome: Pass
Confidence: Likely
Severity: Not Applicable
Applicability: Applicable
Evidence: Exception EX-2026-04 has an owner, migration justification, exact source-target scope, expiration date, monthly review cadence, and explicit rejection of new violations.
Architectural Impact: No corrective exception-governance impact is present because the accepted deviation is narrow and lifecycle-controlled.
Regression Risk: Regression risk remains controlled only within the documented exception boundary and must not be generalized to all dependencies.
Enforcement Impact: The exception preserves enforcement for non-exempt dependency paths.
Rationale: TEST-016 pass conditions are satisfied by justified, scoped, owned, reviewable, and time-bound exception evidence.
Remediation: None. Preserve owner, scope, justification, expiration, and review cadence; reassess if the exception becomes broad or expired.
Related Rules: TEST-006, TEST-012, TEST-017
Boundary Notes: The result concludes only governed exception adequacy. It must not approve the underlying architecture globally.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- any exception existing;
- any baseline existing;
- lack of zero suppressions;
- lack of zero exceptions;
- absence of a specific tool;
- absence of CI/CD;
- use of manual review for exception approval;
- the underlying forbidden dependency as a separate finding;
- global architecture conformance;
- global architecture-test coverage;
- lack of DDD, Clean, Hexagonal, Layered, or microservices.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `TEST-016` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Likely`.

The exception metadata is direct for governance fields, but the scenario withholds full dependency graph and complete execution history. `Confirmed` is acceptable only if an observed result treats the registry and rejection statement as sufficient for the reviewed scope.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No corrective finding is expected. The catalog risk level remains `Medium` as coverage context.

## 23. False Positive Guards

Do not report a finding based only on:

- presence of an exception;
- non-zero suppression count;
- temporary baseline;
- manual review;
- absence of a specific exception tool;
- expiration date in the future;
- lack of CI provider details.

## 24. False Negative Guards

Do not pass exception governance if:

- the exception is ownerless;
- justification is absent;
- scope is wildcard or broad;
- expiration or review cadence is absent;
- new violations are accepted into the baseline silently;
- an expired exception remains active;
- the verification is disabled globally.

## 25. Internal Boundary Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Exception is justified, scoped, owned, and time-bound | `TEST-016` | No | Yes | Return `Pass`. |
| Forbidden dependency is detectable outside exception | No | `TEST-006` if separately evaluated | Yes | Supporting boundary only. |
| Governed exception avoids false rejection | No | `TEST-012` if separately evaluated | Yes | Boundary note only. |
| New regressions after baseline are detected | No | `TEST-017` if separately evaluated | Yes | Mention as guard. |

## 26. Cross-Catalog Boundary Expectations

### Architecture Testing x Core

Core review behavior supports evidence discipline, but no generic Core result is required.

### Architecture Testing x Hexagonal

The underlying dependency may resemble a boundary deviation, but this scenario owns only exception governance.

### Architecture Testing x Clean

Clean dependency correctness is outside the primary conclusion.

### Architecture Testing x Layered

Layered bypass or dependency direction findings require exclusive evidence beyond the exception record.

### Architecture Testing x DDD

No DDD semantic conclusion is supported.

### Architecture Testing x Events and Messaging

No delivery, retry, idempotency, or contract conclusion is supported.

## 27. Deduplication Expectations

| Shared Evidence | Testing Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Temporary forbidden dependency exception | Governed exception passes under `TEST-016` | Underlying architecture deviation may exist | Yes | No underlying finding required. |
| New violations rejected statement | Supports governance | Regression detection may be suspected | Yes | Boundary note only. |
| Exception expiration | Supports lifecycle | Maintainability may be suspected | Yes | No `TEST-019` finding without exclusive maintenance evidence. |

## 28. Expected Remediation

No corrective remediation is expected.

Observed output may recommend preserving:

- owner;
- justification;
- precise scope;
- expiration or review cadence;
- distinction between accepted baseline and new violations.

It must not require zero exceptions, a specific tool, full automation, CI/CD, or architecture rewrite.

## 29. Allowed Variations

Allowed variations:

- equivalent exception metadata names;
- equivalent review cadence or expiration language;
- `Confirmed` confidence with explicit scope limitation;
- supporting Rule omission when decorative;
- result status `Acceptable Variation` only when `Pass`, no finding, and `TEST-016` ownership remain.

## 30. Disallowed Variations

Disallowed variations:

- Primary Rule changed away from `TEST-016`;
- outcome other than `Pass`;
- finding merely because an exception exists;
- zero-exception policy requirement;
- global architecture approval;
- confidence upgrade without governance evidence;
- severity assigned as violation;
- duplicate underlying dependency finding;
- nonexistent Rule ID.

## 31. Execution Instructions

Evaluate the document fixture statically.

Do not compile, run, generate, or infer executable fixture code. Treat the exception registry excerpt as non-compilable governance evidence. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/testing/EVAL-TEST-003-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `TEST-016` is evaluated as `Applicable`;
- primary outcome is `Pass`;
- confidence is `Likely` or accepted stronger confidence with scope limitation;
- severity is `Not Applicable`;
- no corrective finding appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Architecture Testing internal and cross-catalog boundaries are respected;
- duplicate findings are absent;
- remediation is absent or non-corrective;
- observed result comparison against `evaluation/expected/testing/EVAL-TEST-003-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- a corrective finding appears merely because an exception exists;
- outcome is `Fail`, `Warning`, `Not Applicable`, or unsupported `Not Enough Evidence`;
- expected non-findings appear;
- broad or expired exception risk is ignored if reported in observed material;
- severity is assigned despite no finding;
- duplicate supporting or underlying architecture findings repeat the same evidence;
- remediation requires zero exceptions, a specific tool, CI/CD, or rewrite;
- a nonexistent Rule is used;
- existing Rules or catalogs are redefined.

## 34. Traceability

| Item | Trace |
| --- | --- |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Input artifacts | Textual document fixture in sections 8 through 17 of this scenario. |
| Coverage dimensions | `TEST-016` exception governance coverage; Architecture Testing catalog coverage; `Pass`; expected `Likely`; no-finding severity absence; partial evidence; applicability; false-positive protection; false-negative protection; deduplication; remediation absence. |
| Primary Rule catalog | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |
| Primary Rule normative file | `skill/rules/testing/TEST-016.md` |
| Supporting Rule | `skill/rules/testing/TEST-006.md` |
| Supporting Rule | `skill/rules/testing/TEST-012.md` |
| Supporting Rule | `skill/rules/testing/TEST-017.md` |
| Cataloged supporting Rule | `skill/rules/testing/TEST-019.md` |
| Architecture Testing catalog review | `skill/reviews/ARCHITECTURE_TESTING_CATALOG_REVIEW.md` |
| Architecture Testing catalog stabilization | `skill/reviews/ARCHITECTURE_TESTING_CATALOG_STABILIZATION.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Gold Standard stabilization | `evaluation/stabilizations/EVAL-CORE-001-STABILIZATION.md` |

## 35. Gold Standard Requirements

This scenario follows the stabilized Gold Standard reference for structure, identity, evidence interpretation, applicability, outcome, confidence, severity, no-finding behavior, atomicity, remediation, expected non-findings, false-positive protection, false-negative protection, boundaries, deduplication, and traceability.

It must not introduce requirements outside the Evaluation Suite models or redefine existing Rules.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-TEST-003`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `TEST-016`, selected Supporting Rules `TEST-006`, `TEST-012`, `TEST-017`, and expected `Pass` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
