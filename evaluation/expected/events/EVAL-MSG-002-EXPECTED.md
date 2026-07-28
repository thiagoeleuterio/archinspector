# Expected Result - EVAL-MSG-002

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-MSG-002-EXPECTED` |
| Scenario ID | `EVAL-MSG-002` |
| Scenario Title | `Consumer handles duplicate delivery idempotently` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result for inventory correction. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-MSG-002` |
| Title | `Consumer handles duplicate delivery idempotently` |
| Category | `Events & Messaging` |
| Scenario Type | `Positive Compliance` |
| Catalogs | `Events & Messaging` |
| Primary Rule | `MSG-013` |
| Supporting Rules | `MSG-012`, `MSG-014`, `MSG-020` |
| Execution Type | `Executable Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers duplicate handling described in `evaluation/scenarios/events/EVAL-MSG-002.md` for one reviewed consumer.

## 4. Primary Rule Result

| Field | Expected Value |
| --- | --- |
| Rule ID | `MSG-013` |
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
| `MSG-012` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | None | `No` | Delivery context only. | Delivery failure from duplicate delivery alone. | Preserve idempotency ownership. | No finding. |
| `MSG-014` | `Undetermined` | Boundary context | Evidence-based | None | `No` | Ordering not primary. | Ordering finding without evidence. | Preserve ordering boundary. | No finding. |
| `MSG-020` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | None | `No` | Consumer contract context. | Contract finding without exclusive evidence. | Preserve contract boundary. | No finding. |

## 6. Expected Finding

No expected corrective finding. Expected Finding Count: 0.

## 7. Expected Finding Evidence

No finding evidence is required; positive evidence includes duplicate delivery, stable message key, idempotency record, and one observed side effect.

## 8. Expected Architectural Impact

The reviewed consumer avoids duplicate side effects for the provided duplicate-delivery case.

## 9. Expected Rationale

`MSG-013` applies and passes because duplicate handling is directly evidenced for the reviewed consumer.

## 10. Expected Remediation

No remediation is expected.

## 11. Expected Non-Findings

No duplicate-delivery violation, exactly-once mandate, producer consistency finding, or global delivery finding is expected.

## 12. Expected Applicability

Applicability is `Applicable`.

## 13. Expected Outcome

Outcome is `Pass`.

## 14. Expected Confidence

Confidence is `Likely`.

## 15. Expected Severity

Severity is `Not Applicable`.

## 16. Expected Evidence Interpretation

Executable duplicate-run evidence supports the reviewed consumer only and must not be generalized to all consumers.

## 17. Expected Boundary Behavior

`MSG-013` owns idempotency. Delivery, ordering, and contract Rules remain contextual.

## 18. Expected Deduplication Behavior

No finding should be created from the same duplicate-run evidence.

## 19. Expected False Positive Protection

At-least-once delivery must not be reported as failure when idempotency is evidenced.

## 20. Expected False Negative Protection

Duplicated side effects outside the guard must not be ignored if later supplied.

## 21. Allowed Result Variations

Equivalent pass wording is allowed.

## 22. Disallowed Result Variations

Any corrective finding, exactly-once mandate, or global compliance claim is disallowed.

## 23. Comparison Method

Compare identity, Rule, applicability, outcome, confidence, finding count, evidence interpretation, boundaries, and traceability.

## 24. Acceptance Criteria

Accepted when `MSG-013` returns `Pass`, `Applicable`, `Likely`, and zero findings.

## 25. Failure Criteria

Fails when duplicate delivery is treated as violation despite idempotency evidence.

## 26. Result Status

Expected result status is `Match`.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/events/EVAL-MSG-002.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/EVENTS_CATALOG.md` |
| Primary Rule normative file | `skill/rules/events/MSG-013.md` |
| Supporting Rule | `skill/rules/events/MSG-012.md` |
| Supporting Rule | `skill/rules/events/MSG-014.md` |
| Supporting Rule | `skill/rules/events/MSG-020.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |

## 28. Gold Standard Result Requirements

This expected result follows the Gold Standard expected-result structure.

## 29. Result Change Notes

Initial expected result for `EVAL-MSG-002`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `MSG-013`, Supporting Rules `MSG-012`, `MSG-014`, `MSG-020`, outcome `Pass`, and delivery-consumer boundaries.
