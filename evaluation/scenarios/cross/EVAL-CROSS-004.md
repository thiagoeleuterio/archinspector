# EVAL-CROSS-004 - Architecture test validates a Clean Architecture dependency rule

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CROSS-004` |
| Title | `Architecture test validates a Clean Architecture dependency rule` |
| Category | `Cross-Catalog` |
| Scenario Type | `Cross-Catalog Boundary` |
| Catalogs | `Clean Architecture`; `Architecture Testing` |
| Primary Rule | `TEST-005` |
| Supporting Rules | `CLEAN-004`, `TEST-015`, `TEST-018` |
| Risk Level | `Medium` |
| Execution Type | `Executable Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/cross/EVAL-CROSS-004-EXPECTED.md` |
| Related Coverage Dimensions | Cross-catalog boundary; `Pass`; `Likely`; strong executable evidence; Clean x Architecture Testing; report consistency. |

## 2. Purpose

This scenario validates that an architecture test can correctly verify a Clean Architecture dependency rule while test quality and Clean compliance remain separate conclusions.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Cross-Catalog Boundary` |
| Secondary Types | `Automated Validation`, `Report Consistency` |
| Primary Outcome | `Pass` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Likely` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The fixture describes an executable architecture test that targets use-case dependency direction, includes a seeded forbidden dependency, and produces diagnostics when the seed is present.

## 5. Target Catalogs

`Architecture Testing` owns the primary conclusion because the scenario validates the test mechanism. Clean Architecture is the target domain of the rule under test, not the owner of the test-quality pass.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `TEST-005` |
| Title | `Dependency rule verification` |
| Category | `Architecture Testing` |
| Status | `Active` |
| Normative File | `skill/rules/testing/TEST-005.md` |
| Catalog File | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |

`TEST-005` is selected from the catalog because the primary result concerns whether the architecture test verifies a dependency rule. Clean supporting Rules are not primary because they do not own test mechanism validation.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `CLEAN-004` | Boundary reference for the Clean dependency condition under test. |
| `TEST-015` | Boundary reference for actionable diagnostics. |
| `TEST-018` | Boundary reference for execution, not merely rule declaration. |

## 8. Input Artifacts

The input is an executable-fixture description and observed output. No executable fixture is created here.

## 9. Directory Structure

```text
architecture-tests/
  rules/use-case-dependencies.test
  samples/allowed
  samples/forbidden
  output/diagnostics.txt
```

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `use-case-dependencies.test` | Architecture rule. | Selects use-case dependency target. |
| `samples/forbidden` | Negative control. | Violates Clean dependency direction. |
| `diagnostics.txt` | Output. | Reports the seeded violation. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| Test rule | Clean dependency target | Verification | Rule targets the intended dependency. |
| Test output | Seeded violation | Diagnostic | Test can fail usefully. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Verify dependency rule | `TEST-005` | Present |
| Clean architectural condition | Clean catalog | Target only |
| Diagnostic quality | `TEST-015` | Supporting |

## 13. Execution Flow

1. Architecture test selects use-case dependencies.
2. Positive sample passes.
3. Seeded forbidden dependency fails.
4. Diagnostics identify the dependency path.

## 14. Preconditions

- Treat observed output as execution evidence.
- Do not infer full Clean compliance.
- Do not confuse rule target with test mechanism ownership.

## 15. Architecture State

The architecture state is positive compliance for `TEST-005`.

## 16. Evidence Provided

Strong evidence includes target selection, positive/negative controls, execution output, and actionable diagnostics.

## 17. Evidence Withheld

Complete production dependency graph, full Clean Architecture adoption, unrelated test suites, and CI history are withheld.

## 18. Expected Findings

No corrective finding is expected. Expected Finding Count: 0.

## 19. Expected Non-Findings

Do not report Clean compliance for the whole system, missing tests outside scope, unexecuted rule, or diagnostic failure.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `TEST-005` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Likely` because executable evidence is strong but global coverage is withheld.

## 22. Expected Severity

No severity applies because no finding is expected.

## 23. False Positive Guards

Passing architecture test must not become unsupported proof of complete Clean compliance.

## 24. False Negative Guards

Do not miss test scope mismatch or non-execution if such evidence is present.

## 25. Internal Boundary Expectations

`TEST-005` owns dependency rule verification; diagnostics and execution Rules remain supporting boundaries.

## 26. Cross-Catalog Boundary Expectations

Clean x Architecture Testing responsibilities remain separate: Clean defines the architectural target; Architecture Testing validates the mechanism.

## 27. Deduplication Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Dependency test is valid | Yes | No | Yes | `Pass` under `TEST-005`. |
| Whole-system Clean compliance | No | Yes | Yes | Do not infer. |

| Shared Evidence | Primary Catalog Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Test output | Architecture test pass | Clean target context | Yes | Boundary note only. |

## 28. Expected Remediation

No remediation is expected for this non-finding scenario.

## 29. Allowed Variations

Equivalent pass wording is allowed if `TEST-005`, `Pass`, zero findings, and boundaries remain unchanged.

## 30. Disallowed Variations

Unsupported Clean compliance, corrective findings, invented Rules, or ignoring execution evidence are disallowed.

## 31. Execution Instructions

Evaluate described executable evidence only; do not create tests.

## 32. Acceptance Criteria

Accepted when `TEST-005` passes and no whole-system Clean finding is produced.

## 33. Failure Criteria

Fails when test mechanism and Clean rule ownership are conflated.

## 34. Traceability

| Item | Trace |
| --- | --- |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |
| Primary Rule normative file | `skill/rules/testing/TEST-005.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-004.md` |
| Supporting Rule | `skill/rules/testing/TEST-015.md` |
| Supporting Rule | `skill/rules/testing/TEST-018.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |

## 35. Gold Standard Requirements

This scenario follows the Gold Standard structure and adapts semantic content only.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-CROSS-004`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `TEST-005`, Supporting Rules `CLEAN-004`, `TEST-015`, `TEST-018`, outcome `Pass`, and Clean x Architecture Testing boundaries.
