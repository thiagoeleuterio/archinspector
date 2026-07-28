# Expected Result - EVAL-MSG-003

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-MSG-003-EXPECTED` |
| Scenario ID | `EVAL-MSG-003` |
| Scenario Title | `Retry exists without dead-letter or terminal handling` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result for inventory correction. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-MSG-003` |
| Title | `Retry exists without dead-letter or terminal handling` |
| Category | `Events & Messaging` |
| Scenario Type | `Warning Condition` |
| Catalogs | `Events & Messaging` |
| Primary Rule | `MSG-016` |
| Supporting Rules | `MSG-017`, `MSG-018`, `MSG-013` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers retry behavior and absent terminal handling in `evaluation/scenarios/events/EVAL-MSG-003.md`.

## 4. Primary Rule Result

| Field | Expected Value |
| --- | --- |
| Rule ID | `MSG-016` |
| Applicability | `Applicable` |
| Outcome | `Warning` |
| Confidence | `Possible` |
| Severity | `Medium` |
| Finding Required | `Yes` |
| Finding Count | `1` |
| Evidence Strength | `Partial` |
| Result Status | `Match` |

## 5. Supporting Rule Results

| Rule ID | Applicability | Expected Outcome | Expected Confidence | Expected Severity Range | Expected Finding | Expected Evidence | Forbidden Finding | Boundary Notes | Acceptance Criteria |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `MSG-017` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | None unless exclusive evidence exists | `No` | Dead-letter absence supports primary warning. | Duplicate dead-letter finding. | Preserve retry ownership. | No duplicate finding. |
| `MSG-018` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | None unless exclusive evidence exists | `No` | Poison-message context only. | Duplicate poison-message finding. | Preserve retry ownership. | No duplicate finding. |
| `MSG-013` | `Undetermined` | Boundary context | Evidence-based | None | `No` | Idempotency evidence withheld. | Idempotency finding without evidence. | Preserve idempotency boundary. | No finding. |

## 6. Expected Finding

```text
Finding ID: EVAL-MSG-003-F001
Rule ID: MSG-016
Title: Retry has no observable terminal handling for poison messages
Outcome: Warning
Confidence: Possible
Severity: Medium
Applicability: Applicable
Evidence: Retry requeues failed messages repeatedly, while no dead-letter, quarantine, expiration, or manual terminal path is provided.
Architectural Impact: Poison messages may consume processing capacity or block recovery.
Rationale: Partial evidence supports warning under MSG-016 without proving confirmed failure.
Remediation: Add bounded terminal handling appropriate to the messaging mechanism and operational ownership.
Related Rules: MSG-017, MSG-018, MSG-013
Boundary Notes: Do not duplicate as dead-letter or idempotency findings without exclusive evidence.
```

## 7. Expected Finding Evidence

Required evidence is retry requeue behavior plus absent terminal handling.

## 8. Expected Architectural Impact

Poison messages may repeatedly consume operational capacity.

## 9. Expected Rationale

`MSG-016` applies because retry behavior is present. Partial evidence supports `Warning`, not confirmed `Fail`.

## 10. Expected Remediation

Add bounded terminal handling. Do not mandate a specific dead-letter product.

## 11. Expected Non-Findings

No confirmed outage, mandatory technology, idempotency finding, or duplicate dead-letter finding is expected.

## 12. Expected Applicability

Applicability is `Applicable`.

## 13. Expected Outcome

Outcome is `Warning`.

## 14. Expected Confidence

Confidence is `Possible`.

## 15. Expected Severity

Severity is `Medium`.

## 16. Expected Evidence Interpretation

Retry and absent terminal handling support a warning while withheld runtime data limits certainty.

## 17. Expected Boundary Behavior

`MSG-016` owns retry strategy; supporting Rules remain boundary context.

## 18. Expected Deduplication Behavior

One warning only; do not create separate duplicate dead-letter or poison-message findings.

## 19. Expected False Positive Protection

Do not require a specific dead-letter technology or fixed retry count.

## 20. Expected False Negative Protection

Do not hide poison-message risk simply because retry exists.

## 21. Allowed Result Variations

Equivalent warning wording is allowed.

## 22. Disallowed Result Variations

Automatic `Fail`, `Pass`, duplicate findings, or mandatory product remediation is disallowed.

## 23. Comparison Method

Compare Rule, applicability, outcome, confidence, severity, finding, evidence, boundaries, and remediation.

## 24. Acceptance Criteria

Accepted when one `MSG-016` warning appears with no duplicate supporting findings.

## 25. Failure Criteria

Fails when warning is missed, over-escalated, duplicated, or reassigned.

## 26. Result Status

Expected result status is `Match`.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/events/EVAL-MSG-003.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/EVENTS_CATALOG.md` |
| Primary Rule normative file | `skill/rules/events/MSG-016.md` |
| Supporting Rule | `skill/rules/events/MSG-017.md` |
| Supporting Rule | `skill/rules/events/MSG-018.md` |
| Supporting Rule | `skill/rules/events/MSG-013.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |

## 28. Gold Standard Result Requirements

This expected result follows the Gold Standard expected-result structure.

## 29. Result Change Notes

Initial expected result for `EVAL-MSG-003`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `MSG-016`, Supporting Rules `MSG-017`, `MSG-018`, `MSG-013`, outcome `Warning`, and retry/dead-letter boundaries.
