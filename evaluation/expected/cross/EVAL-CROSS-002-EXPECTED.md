# Expected Result - EVAL-CROSS-002

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-CROSS-002-EXPECTED` |
| Scenario ID | `EVAL-CROSS-002` |
| Scenario Title | `Repository contract and implementation are separated correctly` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result for inventory correction. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-CROSS-002` |
| Title | `Repository contract and implementation are separated correctly` |
| Category | `Cross-Catalog` |
| Scenario Type | `Cross-Catalog Boundary` |
| Catalogs | `Hexagonal Architecture`; `Clean Architecture`; `DDD`; `Fowler`; `Layered Architecture` |
| Primary Rule | `FOWLER-001` |
| Supporting Rules | `DDD-009`, `HEX-004`, `CLEAN-009` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the repository contract and implementation split in `evaluation/scenarios/cross/EVAL-CROSS-002.md`.

## 4. Primary Rule Result

| Field | Expected Value |
| --- | --- |
| Rule ID | `FOWLER-001` |
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
| `DDD-009` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | None | `No` | Domain contract context. | DDD finding from correct contract placement. | Preserve DDD boundary. | No finding. |
| `HEX-004` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | None | `No` | Port context. | Port finding that duplicates repository pass. | Preserve Hex boundary. | No finding. |
| `CLEAN-009` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | None | `No` | Gateway context. | Gateway finding from correct separation. | Preserve Clean boundary. | No finding. |

## 6. Expected Finding

No expected corrective finding. Expected Finding Count: 0.

## 7. Expected Finding Evidence

Positive evidence includes separated repository contract, infrastructure implementation, correct dependency direction, and no database API in the contract.

## 8. Expected Architectural Impact

The reviewed design preserves repository separation and avoids false-positive reporting.

## 9. Expected Rationale

`FOWLER-001` applies and passes because repository responsibilities are separated.

## 10. Expected Remediation

No remediation is expected.

## 11. Expected Non-Findings

No repository, gateway, port, mapper, adapter, or layer violation is expected.

## 12. Expected Applicability

Applicability is `Applicable`.

## 13. Expected Outcome

Outcome is `Pass`.

## 14. Expected Confidence

Confidence is `Likely`.

## 15. Expected Severity

Severity is `Not Applicable`.

## 16. Expected Evidence Interpretation

The contract/implementation split is strong positive evidence but does not prove global architecture compliance.

## 17. Expected Boundary Behavior

Fowler owns repository pattern fit; DDD, Hexagonal, Clean, and Layered terms remain separate.

## 18. Expected Deduplication Behavior

No findings should be emitted from the same compliant separation evidence.

## 19. Expected False Positive Protection

Repository, gateway, mapper, adapter, and port concepts must retain separate meanings.

## 20. Expected False Negative Protection

Implementation leakage into the contract must not be missed if later supplied.

## 21. Allowed Result Variations

Equivalent pass wording is allowed.

## 22. Disallowed Result Variations

Any corrective finding, invented Rule, or global compliance claim is disallowed.

## 23. Comparison Method

Compare identity, Rule, outcome, finding count, evidence, non-findings, boundaries, and traceability.

## 24. Acceptance Criteria

Accepted when `FOWLER-001` passes with zero findings.

## 25. Failure Criteria

Fails when correct repository separation is reported as a violation.

## 26. Result Status

Expected result status is `Match`.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/cross/EVAL-CROSS-002.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/FOWLER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/fowler/FOWLER-001.md` |
| Supporting Rule | `skill/rules/ddd/DDD-009.md` |
| Supporting Rule | `skill/rules/HEX-004.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-009.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |

## 28. Gold Standard Result Requirements

This expected result follows the Gold Standard expected-result structure.

## 29. Result Change Notes

Initial expected result for `EVAL-CROSS-002`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `FOWLER-001`, Supporting Rules `DDD-009`, `HEX-004`, `CLEAN-009`, outcome `Pass`, and repository boundary ownership.
