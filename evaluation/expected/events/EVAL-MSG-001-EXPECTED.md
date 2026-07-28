# Expected Result - EVAL-MSG-001

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-MSG-001-EXPECTED` |
| Scenario ID | `EVAL-MSG-001` |
| Scenario Title | `Integration event published before transaction durability` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result for inventory correction. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-MSG-001` |
| Title | `Integration event published before transaction durability` |
| Category | `Events & Messaging` |
| Scenario Type | `Confirmed Violation` |
| Catalogs | `Events & Messaging`; boundary reference to `Architecture Testing` |
| Primary Rule | `MSG-010` |
| Supporting Rules | `MSG-011`, `MSG-012`, `TEST-005` |
| Execution Type | `Mixed Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers `evaluation/scenarios/events/EVAL-MSG-001.md`. Scope includes producer flow, transaction timing, rollback path, absence of durable publication intent, and messaging consistency evidence.

## 4. Primary Rule Result

| Field | Expected Value |
| --- | --- |
| Rule ID | `MSG-010` |
| Applicability | `Applicable` |
| Outcome | `Fail` |
| Confidence | `Confirmed` |
| Severity | `High` |
| Finding Required | `Yes` |
| Finding Count | `1` |
| Evidence Strength | `Strong` |
| Result Status | `Match` |

## 5. Supporting Rule Results

| Rule ID | Applicability | Expected Outcome | Expected Confidence | Expected Severity Range | Expected Finding | Expected Evidence | Forbidden Finding | Boundary Notes | Acceptance Criteria |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `MSG-011` | `Applicable` or `Undetermined` | Boundary context or no separate result | Evidence-based | None unless exclusive evidence exists | `No` | Durable record evidence is absent. | Outbox-record finding that restates `MSG-010`. | Preserve producer consistency ownership. | No duplicate finding. |
| `MSG-012` | `Applicable` or `Undetermined` | Boundary context or no separate result | Evidence-based | None unless exclusive delivery evidence exists | `No` | Delivery evidence is outside primary scope. | Delivery finding that restates publication timing. | Preserve delivery boundary. | No duplicate finding. |
| `TEST-005` | `Undetermined` | Boundary context or no separate result | Evidence-based | None unless exclusive test evidence exists | `No` | Tests may support but do not own consistency. | Test finding that restates producer risk. | Preserve testing boundary. | No duplicate finding. |

## 6. Expected Finding

```text
Finding ID: EVAL-MSG-001-F001
Rule ID: MSG-010
Title: Integration event can be published before durable order state exists
Outcome: Fail
Confidence: Confirmed
Severity: High
Applicability: Applicable
Evidence: ApproveOrderHandler publishes OrderApproved before transaction completion; rollback can occur after publication; no durable intent or recovery path is provided.
Architectural Impact: Consumers may observe a false durable fact.
Rationale: Direct producer flow evidence satisfies MSG-010 fail conditions.
Remediation: Align commit, publication intent, send, rollback, and recovery through a durable or otherwise recoverable consistency mechanism.
Related Rules: MSG-011, MSG-012, TEST-005
Boundary Notes: Do not duplicate this as delivery, outbox-record, or test-rule finding without exclusive evidence.
```

## 7. Expected Finding Evidence

Required evidence is publication before commit, rollback after send, absence of durable intent, absence of recovery, and event dependence on persisted state.

## 8. Expected Architectural Impact

Consumers can act on an event that announces state that was not durably committed.

## 9. Expected Rationale

`MSG-010` applies because a produced message depends on durable state. The direct failure path supports `Fail` with `Confirmed` confidence.

## 10. Expected Remediation

Use an incremental consistency mechanism; do not require a named outbox, broker replacement, event sourcing, or rewrite.

## 11. Expected Non-Findings

No findings for broker choice, absence of Transactional Outbox by name, asynchronous messaging, microservices, architecture-test coverage, or delivery behavior are expected.

## 12. Expected Applicability

Applicability is `Applicable`.

## 13. Expected Outcome

Outcome is `Fail`.

## 14. Expected Confidence

Confidence is `Confirmed`.

## 15. Expected Severity

Severity is `High`.

## 16. Expected Evidence Interpretation

Publication timing, rollback behavior, and absence of recovery must be interpreted together. Naming is not sufficient by itself.

## 17. Expected Boundary Behavior

`MSG-010` owns producer consistency; supporting Rules may only protect boundaries.

## 18. Expected Deduplication Behavior

The publication-before-durability conclusion must appear once under `MSG-010`.

## 19. Expected False Positive Protection

Equivalent consistency mechanisms must be accepted. A named outbox must not be required.

## 20. Expected False Negative Protection

The violation must not be missed because publication and persistence are close together or the system is a monolith.

## 21. Allowed Result Variations

Equivalent wording and remediation are allowed if the Rule, outcome, confidence, severity, and finding count are unchanged.

## 22. Disallowed Result Variations

Changing Primary Rule, missing the finding, duplicate findings, generic findings, or prescriptive remediation is disallowed.

## 23. Comparison Method

Compare identity, applicability, outcome, confidence, severity, finding, evidence, non-findings, boundaries, deduplication, remediation, and traceability.

## 24. Acceptance Criteria

Accepted when exactly one `MSG-010` finding appears with `Fail`, `Applicable`, `Confirmed`, `High`, and no duplicate supporting findings.

## 25. Failure Criteria

Fails when the expected finding is absent, duplicated, reassigned, unsupported, or remediated beyond scope.

## 26. Result Status

Expected result status is `Match`.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/events/EVAL-MSG-001.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/EVENTS_CATALOG.md` |
| Primary Rule normative file | `skill/rules/events/MSG-010.md` |
| Supporting Rule | `skill/rules/events/MSG-011.md` |
| Supporting Rule | `skill/rules/events/MSG-012.md` |
| Supporting Rule | `skill/rules/testing/TEST-005.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |

## 28. Gold Standard Result Requirements

This expected result follows the Gold Standard expected-result structure.

## 29. Result Change Notes

Initial expected result for `EVAL-MSG-001`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `MSG-010`, Supporting Rules `MSG-011`, `MSG-012`, `TEST-005`, outcome `Fail`, and Events x Architecture Testing boundaries.
