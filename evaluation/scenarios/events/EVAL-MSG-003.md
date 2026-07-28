# EVAL-MSG-003 - Retry exists without dead-letter or terminal handling

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-MSG-003` |
| Title | `Retry exists without dead-letter or terminal handling` |
| Category | `Events & Messaging` |
| Scenario Type | `Warning Condition` |
| Catalogs | `Events & Messaging` |
| Primary Rule | `MSG-016` |
| Supporting Rules | `MSG-017`, `MSG-018`, `MSG-013` |
| Risk Level | `Medium` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/events/EVAL-MSG-003-EXPECTED.md` |
| Related Coverage Dimensions | Events & Messaging coverage; `Warning`; `Possible`; `Medium`; partial evidence; retry boundary; false-negative guard. |

## 2. Purpose

This scenario validates warning-level handling when retry is present but terminal poison-message handling is not observable.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Warning Condition` |
| Secondary Types | `False Negative Guard`, `Internal Boundary` |
| Primary Outcome | `Warning` |
| Evidence Strength | `Partial` |
| Applicability | `Applicable` |
| Confidence | `Possible` |
| Severity | `Medium` |

## 4. Architectural Context

The reviewed consumer catches processing failures and returns the message for retry. The manifest does not show a maximum retry count, quarantine, dead-letter path, expiration, or manual terminal handling.

## 5. Target Catalogs

`Events & Messaging` owns the risk because retry strategy and poison-message termination belong to messaging operations.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `MSG-016` |
| Title | `Retry strategy` |
| Category | `Events and Messaging` |
| Status | `Active` |
| Normative File | `skill/rules/events/MSG-016.md` |
| Catalog File | `skill/rules/EVENTS_CATALOG.md` |

`MSG-016` is the cataloged Primary Rule and the most specific owner of retry strategy. `MSG-017`, `MSG-018`, and `MSG-013` are supporting boundaries for dead-letter handling, poison-message treatment, and idempotency.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `MSG-017` | Boundary reference for dead-letter or quarantine handling. |
| `MSG-018` | Boundary reference for poison-message operational handling. |
| `MSG-013` | Boundary reference for idempotency when retries duplicate delivery. |

## 8. Input Artifacts

The input is a static code-fixture manifest. It is descriptive and non-compilable.

## 9. Directory Structure

```text
consumer-retry/
  consumer/InvoiceConsumer
  retry/RetryPolicy
  docs/operations.md
```

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `InvoiceConsumer` | Message handler. | Throws processing failure to retry. |
| `RetryPolicy` | Retry mechanism. | Requeues without terminal bound. |
| `operations.md` | Manual notes. | No quarantine or dead-letter path listed. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| Consumer | RetryPolicy | Failure handling | Retry exists. |
| RetryPolicy | Terminal handling | Absent | Warning risk remains. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Retry behavior | Messaging architecture | Present |
| Terminal handling | Messaging operations | Not observed |
| Idempotency | Consumer | Boundary only |

## 13. Execution Flow

1. Message processing fails.
2. Consumer asks retry policy to redeliver.
3. Retry repeats.
4. No terminal route or owner is provided for repeated failure.

## 14. Preconditions

- Use only the static manifest.
- Do not require a specific dead-letter technology.
- Do not escalate to `Fail` without confirmed operational impact.

## 15. Architecture State

The architecture state is a warning condition because partial evidence shows retry risk but not enough confirmed impact for failure.

## 16. Evidence Provided

Partial evidence includes a retry path, repeated redelivery behavior, and absent terminal handling in reviewed files.

## 17. Evidence Withheld

Runtime failure rates, broker configuration, incident records, operations dashboards, and complete runbooks are withheld.

## 18. Expected Findings

Exactly one warning finding is required.

```text
Finding ID: EVAL-MSG-003-F001
Rule ID: MSG-016
Title: Retry has no observable terminal handling for poison messages
Outcome: Warning
Confidence: Possible
Severity: Medium
Applicability: Applicable
Evidence: Retry requeues failed messages repeatedly, while no dead-letter, quarantine, expiration, or manual terminal path is provided.
Impact: Poison messages may consume processing capacity or block operational recovery.
Rationale: Partial evidence supports warning under MSG-016 without proving a confirmed failure.
Remediation: Add bounded terminal handling appropriate to the messaging mechanism and operational ownership.
Related Rules: MSG-017, MSG-018, MSG-013
Boundary Notes: Do not duplicate as dead-letter or idempotency findings without exclusive evidence.
```

## 19. Expected Non-Findings

Do not report missing specific dead-letter technology, global reliability failure, idempotency failure, or confirmed outage.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `MSG-016` | `Applicable` | `Warning` | `Match` |
| Scenario | `Applicable` | `Warning` | `Match` |

## 21. Expected Confidence

Expected confidence is `Possible` because evidence is partial and operational runtime data is withheld.

## 22. Expected Severity

Expected severity is `Medium` because the risk can affect operations but impact is not confirmed as severe.

## 23. False Positive Guards

Do not require a specific dead-letter technology, fixed retry count, or broker feature.

## 24. False Negative Guards

Do not miss infinite retry or hidden poison-message risk because retry exists or because no incident history is provided.

## 25. Internal Boundary Expectations

`MSG-016` owns retry strategy. Dead-letter, poison-message, and idempotency Rules are supporting boundaries only.

## 26. Cross-Catalog Boundary Expectations

No cross-catalog finding is expected. Operational evidence remains inside Events & Messaging.

## 27. Deduplication Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Retry lacks terminal handling | Yes | No | Yes | One `MSG-016` warning. |
| Idempotency unknown | No | Yes | Yes | Evidence withheld, no finding. |

| Shared Evidence | Primary Catalog Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Retry flow | Retry warning | Dead-letter context | Yes | Boundary note only. |

## 28. Expected Remediation

Add bounded terminal handling, such as quarantine, dead-letter routing, expiration, or manual recovery. Do not mandate a specific product or framework.

## 29. Allowed Variations

Equivalent warning wording is allowed if `MSG-016`, `Warning`, `Possible`, and one finding remain.

## 30. Disallowed Variations

Automatic `Fail`, automatic `Pass`, duplicate findings, invented Rules, or mandatory product remediation are disallowed.

## 31. Execution Instructions

Evaluate the static manifest only. Do not create executable fixtures.

## 32. Acceptance Criteria

Accepted when one `MSG-016` warning appears and no forbidden findings are produced.

## 33. Failure Criteria

Fails when the warning is missed, escalated without evidence, duplicated, or remediated prescriptively.

## 34. Traceability

| Item | Trace |
| --- | --- |
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

## 35. Gold Standard Requirements

This scenario follows the Gold Standard structure and adapts semantic content only.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-MSG-003`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `MSG-016`, Supporting Rules `MSG-017`, `MSG-018`, `MSG-013`, outcome `Warning`, and retry/dead-letter boundaries.
