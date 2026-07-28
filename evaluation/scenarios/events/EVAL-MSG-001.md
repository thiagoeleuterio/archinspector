# EVAL-MSG-001 - Integration event published before transaction durability

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-MSG-001` |
| Title | `Integration event published before transaction durability` |
| Category | `Events & Messaging` |
| Scenario Type | `Confirmed Violation` |
| Catalogs | `Events & Messaging`; boundary reference to `Architecture Testing` |
| Primary Rule | `MSG-010` |
| Supporting Rules | `MSG-011`, `MSG-012`, `TEST-005` |
| Risk Level | `High` |
| Execution Type | `Mixed Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/events/EVAL-MSG-001-EXPECTED.md` |
| Related Coverage Dimensions | Events & Messaging coverage; `Fail`; `Confirmed`; `High`; strong evidence; producer consistency; false-positive guard; false-negative guard; Events x Architecture Testing boundary; deduplication; remediation. |

## 2. Purpose

This scenario validates that ArchInspector reports a confirmed producer-consistency violation when an integration event can be published before the durable transaction it announces is committed.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Confirmed Violation` |
| Secondary Types | `Warning Condition`, `Cross-Catalog Boundary` |
| Primary Outcome | `Fail` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Confirmed` |
| Severity | `High` |

## 4. Architectural Context

The evaluated system processes order approval. The reviewed manifest shows one command handler that writes order state and publishes `OrderApproved` as part of the same business operation.

The event is sent before durable transaction completion. A rollback path is shown after publication, and no durable publication intent, recovery process, or equivalent consistency mechanism is provided.

## 5. Target Catalogs

`Events & Messaging` owns the Primary Rule because the main conclusion concerns producer-side consistency between durable state and message publication.

`Architecture Testing` is a boundary catalog because tests may expose the flow, but a test mechanism does not own the messaging consistency finding.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `MSG-010` |
| Title | `Producer-persistence consistency` |
| Category | `Events and Messaging` |
| Status | `Active` |
| Normative File | `skill/rules/events/MSG-010.md` |
| Catalog File | `skill/rules/EVENTS_CATALOG.md` |

`MSG-010` is selected directly from `evaluation/SCENARIO_CATALOG.md`. It is the most specific Rule for publication-before-durability risk. Alternatives `MSG-011`, `MSG-012`, and `TEST-005` are supporting only because durable publication records, delivery behavior, and dependency-rule tests do not own this producer consistency conclusion.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `MSG-011` | Boundary reference for durable publication records when an outbox-like mechanism is adopted. |
| `MSG-012` | Boundary reference for delivery semantics after producer handoff. |
| `TEST-005` | Boundary reference for validation evidence without converting tests into the owner finding. |

## 8. Input Artifacts

The input is a mixed static/document manifest. It is not executable code.

## 9. Directory Structure

```text
order-messaging/
  application/ApproveOrderHandler
  persistence/OrderTransaction
  messaging/EventPublisher
  docs/failure-path.md
```

Directory names are not proof; the explicit flow and rollback notes are the evidence.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `ApproveOrderHandler` | Coordinates approval. | Calls publisher before commit completes. |
| `OrderTransaction` | Durable state boundary. | Can roll back after publication. |
| `EventPublisher` | Message producer. | Publishes `OrderApproved`. |
| `failure-path.md` | Document evidence. | States no recovery for published-before-rollback event. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `ApproveOrderHandler` | `EventPublisher` | Direct send before commit | Event can escape before durable fact exists. |
| `ApproveOrderHandler` | `OrderTransaction` | Transaction control | Rollback after send creates inconsistency. |
| Reviewed scope | Durable intent record | Absent | No recovery evidence is present. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Keep state and publication consistent | Producer architecture | Unprotected handler flow |
| Delivery after handoff | Messaging delivery mechanism | Out of primary scope |
| Dependency rule verification | Architecture Testing | Supporting evidence only |

## 13. Execution Flow

1. Handler validates order approval.
2. Handler starts a transaction.
3. Handler saves order state.
4. Handler publishes `OrderApproved`.
5. The transaction can fail or roll back.
6. No durable intent or recovery path reconciles the published message.

## 14. Preconditions

- Evaluate only the manifest and failure-path note.
- Apply `MSG-010` before considering supporting Rules.
- Do not require Transactional Outbox by name.
- Do not infer runtime behavior beyond the provided flow.

## 15. Architecture State

The architecture state is a confirmed violation. Strong evidence shows a message can announce a durable fact before that fact is durable.

## 16. Evidence Provided

Strong evidence includes publication before commit, rollback after send, absence of durable publication intent, absence of recovery, and the event depending on persisted order state.

## 17. Evidence Withheld

Broker transactions, executable code, production logs, incident history, full automated tests, and complete runtime configuration are withheld. This prevents claims about broker-specific delivery, global reliability, or testing maturity.

## 18. Expected Findings

Exactly one finding is required.

```text
Finding ID: EVAL-MSG-001-F001
Rule ID: MSG-010
Title: Integration event can be published before durable order state exists
Outcome: Fail
Confidence: Confirmed
Severity: High
Applicability: Applicable
Evidence: ApproveOrderHandler publishes OrderApproved before transaction completion; rollback can occur after publication; no durable intent or recovery path is provided.
Impact: Consumers may observe a false durable fact or act on an order state that was rolled back.
Rationale: Direct producer flow evidence satisfies MSG-010 fail conditions.
Remediation: Align commit, publication intent, send, rollback, and recovery through a durable or otherwise recoverable consistency mechanism.
Related Rules: MSG-011, MSG-012, TEST-005
Boundary Notes: Do not duplicate this as a delivery, outbox-record, or test-rule finding without exclusive evidence.
```

## 19. Expected Non-Findings

Do not report findings for absence of a named Transactional Outbox, broker choice, asynchronous messaging by itself, lack of microservices, folder names, or architecture-test coverage unless exclusive evidence supports those conclusions.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `MSG-010` | `Applicable` | `Fail` | `Match` |
| Scenario | `Applicable` | `Fail` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed` because direct flow and rollback evidence are present.

## 22. Expected Severity

Expected severity is `High` because consumers may observe false durable order facts.

## 23. False Positive Guards

Do not require Transactional Outbox when an equivalent consistency strategy exists. Do not report based only on event naming, use of a broker, or absence of a specific tool.

## 24. False Negative Guards

Do not miss the violation because publication and persistence are close together, the application is a monolith, tests are green, or the event name sounds domain-correct.

## 25. Internal Boundary Expectations

`MSG-010` owns producer consistency. `MSG-011` and `MSG-012` may explain boundaries but cannot restate the same failure.

## 26. Cross-Catalog Boundary Expectations

Events x Architecture Testing: test evidence may support confidence, but testing Rules do not own the producer consistency finding.

## 27. Deduplication Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Published before durable state | Yes | No | Yes | One `MSG-010` finding. |
| Delivery quality after handoff | No | Only with separate delivery evidence | Yes | Non-finding here. |

| Shared Evidence | Primary Catalog Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Publication flow | Producer consistency failure | Test or delivery context | Yes | Keep ownership under `MSG-010`. |

## 28. Expected Remediation

Use a durable or recoverable consistency mechanism. Remediation must be incremental, technology-neutral, and must not require a named outbox, broker replacement, event sourcing, or a rewrite.

## 29. Allowed Variations

Equivalent wording and remediation are allowed if `MSG-010`, `Fail`, `Applicable`, `Confirmed`, one finding, and the boundary limits remain unchanged.

## 30. Disallowed Variations

`Pass`, `Warning` as the only result, `Not Enough Evidence`, duplicate findings, invented Rules, named-tool mandates, or ignoring rollback evidence are disallowed.

## 31. Execution Instructions

Evaluate the mixed manifest manually/staticly. Do not compile, run, or create fixture code.

## 32. Acceptance Criteria

Accepted when one `MSG-010` finding appears with `Fail`, `Applicable`, `Confirmed`, `High`, correct evidence, proportional remediation, and no duplicate supporting findings.

## 33. Failure Criteria

Fails when the finding is missing, duplicated, reassigned, generic, based only on naming, or paired with prescriptive remediation.

## 34. Traceability

| Item | Trace |
| --- | --- |
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

## 35. Gold Standard Requirements

This scenario preserves the Gold Standard structure, evidence discipline, atomicity, deduplication, remediation proportionality, and traceability.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-MSG-001`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `MSG-010`, Supporting Rules `MSG-011`, `MSG-012`, `TEST-005`, outcome `Fail`, and Events x Architecture Testing boundaries.
