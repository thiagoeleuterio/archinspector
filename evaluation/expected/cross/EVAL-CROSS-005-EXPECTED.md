# Expected Result - EVAL-CROSS-005

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-CROSS-005-EXPECTED` |
| Scenario ID | `EVAL-CROSS-005` |
| Scenario Title | `Layered monolith uses Transaction Script appropriately` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result for inventory correction. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-CROSS-005` |
| Title | `Layered monolith uses Transaction Script appropriately` |
| Category | `Cross-Catalog` |
| Scenario Type | `Cross-Catalog Boundary` |
| Catalogs | `Layered Architecture`; `Fowler`; `Core` |
| Primary Rule | `FOWLER-002` |
| Supporting Rules | `LAYER-005`, `DDD-013`, `SOL-001` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers simple layered CRUD pattern fit in `evaluation/scenarios/cross/EVAL-CROSS-005.md`.

## 4. Primary Rule Result

| Field | Expected Value |
| --- | --- |
| Rule ID | `FOWLER-002` |
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
| `LAYER-005` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | None | `No` | Layer orchestration context. | Layer finding from acceptable script. | Preserve Layered boundary. | No finding. |
| `DDD-013` | `Not Applicable` or boundary context | Boundary context | Evidence-based | None | `No` | CRUD simplicity context. | DDD prescription finding. | Preserve DDD boundary. | No finding. |
| `SOL-001` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | None | `No` | Proportionality context. | Decision finding without evidence. | Preserve Solution boundary. | No finding. |

## 6. Expected Finding

No expected corrective finding. Expected Finding Count: 0.

## 7. Expected Finding Evidence

Positive evidence includes simple CRUD workflow, low domain complexity, layer mediation, and absence of complex invariants.

## 8. Expected Architectural Impact

The reviewed Transaction Script is proportionate to the current scope.

## 9. Expected Rationale

`FOWLER-002` applies and passes because Transaction Script fits the simple CRUD context.

## 10. Expected Remediation

No remediation is expected.

## 11. Expected Non-Findings

No DDD absence, Domain Model absence, microservice, architecture-test, or rich-layering finding is expected.

## 12. Expected Applicability

Applicability is `Applicable`.

## 13. Expected Outcome

Outcome is `Pass`.

## 14. Expected Confidence

Confidence is `Likely`.

## 15. Expected Severity

Severity is `Not Applicable`.

## 16. Expected Evidence Interpretation

Simple CRUD evidence supports pattern fit only for reviewed scope.

## 17. Expected Boundary Behavior

Layered x Fowler x Core boundaries preserve proportionality.

## 18. Expected Deduplication Behavior

No finding should be created from legitimate Transaction Script use.

## 19. Expected False Positive Protection

Absence of Domain Model must not be treated as failure.

## 20. Expected False Negative Protection

Layer bypass or accumulated complexity must not be missed if evidenced later.

## 21. Allowed Result Variations

Equivalent pass wording is allowed.

## 22. Disallowed Result Variations

Mandatory DDD, mandatory Domain Model, or corrective findings are disallowed.

## 23. Comparison Method

Compare identity, Rule, outcome, finding count, evidence, non-findings, boundaries, and traceability.

## 24. Acceptance Criteria

Accepted when `FOWLER-002` passes with zero findings and proportionality is preserved.

## 25. Failure Criteria

Fails when Transaction Script is rejected without complexity evidence.

## 26. Result Status

Expected result status is `Match`.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/cross/EVAL-CROSS-005.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/FOWLER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/fowler/FOWLER-002.md` |
| Supporting Rule | `skill/rules/layered/LAYER-005.md` |
| Supporting Rule | `skill/rules/ddd/DDD-013.md` |
| Supporting Rule | `skill/rules/solution-architecture/SOL-001.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |

## 28. Gold Standard Result Requirements

This expected result follows the Gold Standard expected-result structure.

## 29. Result Change Notes

Initial expected result for `EVAL-CROSS-005`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `FOWLER-002`, Supporting Rules `LAYER-005`, `DDD-013`, `SOL-001`, outcome `Pass`, and Layered x Fowler x Core boundaries.
