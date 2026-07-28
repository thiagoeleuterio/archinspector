# EVAL-MSG-002 - Consumer handles duplicate delivery idempotently

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-MSG-002` |
| Title | `Consumer handles duplicate delivery idempotently` |
| Category | `Events & Messaging` |
| Scenario Type | `Positive Compliance` |
| Catalogs | `Events & Messaging` |
| Primary Rule | `MSG-013` |
| Supporting Rules | `MSG-012`, `MSG-014`, `MSG-020` |
| Risk Level | `Medium` |
| Execution Type | `Executable Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/events/EVAL-MSG-002-EXPECTED.md` |
| Related Coverage Dimensions | Events & Messaging coverage; `Pass`; `Likely`; strong evidence; idempotent consumer behavior; false-positive guard; delivery boundary. |

## 2. Purpose

This scenario validates that duplicate delivery is accepted as compliant when the consumer demonstrates idempotent handling.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Positive Compliance` |
| Secondary Types | `False Positive Guard` |
| Primary Outcome | `Pass` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Likely` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The reviewed consumer processes payment-captured messages that may be delivered more than once. The manifest includes repeated delivery of the same message key and shows that the side effect is applied once.

## 5. Target Catalogs

`Events & Messaging` owns the scenario. The result concerns consumer idempotency, not producer consistency or broker reliability.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `MSG-013` |
| Title | `Consumer idempotency` |
| Category | `Events and Messaging` |
| Status | `Active` |
| Normative File | `skill/rules/events/MSG-013.md` |
| Catalog File | `skill/rules/EVENTS_CATALOG.md` |

`MSG-013` is selected from the catalog because it owns duplicate-delivery consumer behavior. `MSG-012`, `MSG-014`, and `MSG-020` are alternatives only for delivery semantics, ordering, and consumer contracts.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `MSG-012` | Boundary reference for delivery expectations after producer handoff. |
| `MSG-014` | Boundary reference for ordering or sequencing if separately evidenced. |
| `MSG-020` | Boundary reference for consumer contract clarity. |

## 8. Input Artifacts

The input is an executable-fixture description with observed duplicate processing output. No executable project is created by this scenario.

## 9. Directory Structure

```text
payment-consumer/
  consumer/PaymentCapturedConsumer
  storage/ProcessedMessageStore
  output/duplicate-run.txt
```

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `PaymentCapturedConsumer` | Handles messages. | Checks message key before side effects. |
| `ProcessedMessageStore` | Idempotency record. | Stores processed message identity. |
| `duplicate-run.txt` | Execution evidence. | Same message delivered twice, one state change. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| Consumer | Idempotency store | Guard dependency | Prevents duplicate side effects. |
| Duplicate message | Consumer | Repeated delivery | Applies at-least-once delivery context. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Duplicate side-effect prevention | Consumer | Consumer |
| Delivery semantics | Messaging infrastructure | Boundary only |
| Producer consistency | Producer | Out of scope |

## 13. Execution Flow

1. Deliver message `payment-42`.
2. Consumer checks processed-message store.
3. Consumer applies side effect and records the key.
4. Deliver `payment-42` again.
5. Consumer detects prior handling and skips the side effect.

## 14. Preconditions

- Treat duplicate-run output as reviewed evidence.
- Do not infer all consumers are idempotent.
- Evaluate `MSG-013` before neighboring Rules.

## 15. Architecture State

The architecture state is positive compliance for the reviewed consumer.

## 16. Evidence Provided

Strong evidence includes duplicate delivery, stable message identity, an idempotency record, and observed single side effect after repeated delivery.

## 17. Evidence Withheld

Production broker behavior, unrelated consumers, retention policy, replay across services, and long-term operational history are withheld.

## 18. Expected Findings

No corrective finding is expected. Expected Finding Count: 0.

## 19. Expected Non-Findings

Do not report duplicate-delivery failure, mandatory exactly-once infrastructure, missing outbox, global delivery failure, or producer consistency finding.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `MSG-013` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Likely` because direct duplicate-run evidence supports the reviewed consumer while withheld production context limits global certainty.

## 22. Expected Severity

No severity applies because no finding is expected.

## 23. False Positive Guards

At-least-once delivery must not be reported as failure when idempotency is evidenced. Do not require exactly-once delivery or a specific broker feature.

## 24. False Negative Guards

Do not miss duplicated side effects outside the idempotency guard if provided later. Do not treat a stored key as sufficient if the side effect occurs before the guard.

## 25. Internal Boundary Expectations

`MSG-013` owns idempotency. Delivery, ordering, and contract Rules remain supporting boundaries only.

## 26. Cross-Catalog Boundary Expectations

No cross-catalog finding is expected. Shared evidence stays within Events & Messaging.

## 27. Deduplication Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Consumer idempotency works | Yes | No | Yes | `Pass` under `MSG-013`. |
| Broker delivery guarantee | No | Yes, with separate evidence | Yes | Do not infer. |

| Shared Evidence | Primary Catalog Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Duplicate-run output | Consumer idempotency pass | Delivery context only | Yes | No finding. |

## 28. Expected Remediation

No remediation is expected for this non-finding scenario.

## 29. Allowed Variations

Equivalent wording is allowed if `MSG-013`, `Pass`, `Applicable`, no finding, and boundary limits remain unchanged.

## 30. Disallowed Variations

Any corrective finding, exactly-once mandate, producer finding, invented Rule, or unsupported global compliance claim is disallowed.

## 31. Execution Instructions

Evaluate the described executable evidence; do not create executable fixtures.

## 32. Acceptance Criteria

Accepted when `MSG-013` returns `Pass`, `Applicable`, `Likely`, zero findings, and expected non-findings remain absent.

## 33. Failure Criteria

Fails when duplicate delivery is reported as a violation despite idempotency evidence, or when compliance is generalized beyond scope.

## 34. Traceability

| Item | Trace |
| --- | --- |
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

## 35. Gold Standard Requirements

This scenario follows the Gold Standard structure and adapts semantic content only.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-MSG-002`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `MSG-013`, Supporting Rules `MSG-012`, `MSG-014`, `MSG-020`, outcome `Pass`, and delivery-consumer boundaries.
