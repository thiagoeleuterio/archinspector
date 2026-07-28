# EVAL-CROSS-003 - Domain event is published directly by infrastructure code

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CROSS-003` |
| Title | `Domain event is published directly by infrastructure code` |
| Category | `Cross-Catalog` |
| Scenario Type | `Cross-Catalog Boundary` |
| Catalogs | `DDD`; `Events & Messaging`; `Hexagonal Architecture`; `Clean Architecture` |
| Primary Rule | `MSG-003` |
| Supporting Rules | `DDD-011`, `MSG-010`, `HEX-010` |
| Risk Level | `Medium` |
| Execution Type | `Mixed Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/cross/EVAL-CROSS-003-EXPECTED.md` |
| Related Coverage Dimensions | Cross-catalog boundary; `Warning`; `Possible`; partial evidence; DDD x Events x Hexagonal x Clean; deduplication. |

## 2. Purpose

This scenario validates warning-level ownership when infrastructure directly publishes a domain-significant event.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Cross-Catalog Boundary` |
| Secondary Types | `Warning Condition`, `Multiple Findings` |
| Primary Outcome | `Warning` |
| Evidence Strength | `Partial` |
| Applicability | `Applicable` |
| Confidence | `Possible` |
| Severity | `Medium` |

## 4. Architectural Context

Infrastructure persistence code creates and publishes a domain-significant event after saving an aggregate. The domain model does not record event intent, and ownership rationale is absent.

## 5. Target Catalogs

`MSG-003` owns event ownership. DDD, Hexagonal, and Clean Rules may provide context but must not duplicate event ownership or publication mechanics.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `MSG-003` |
| Title | `Event ownership` |
| Category | `Events and Messaging` |
| Status | `Active` |
| Normative File | `skill/rules/events/MSG-003.md` |
| Catalog File | `skill/rules/EVENTS_CATALOG.md` |

`MSG-003` is selected from the catalog because the main conclusion concerns ownership of event publication. `DDD-011`, `MSG-010`, and `HEX-010` are alternatives only for domain event meaning, producer consistency, and ported messaging boundaries.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `DDD-011` | Boundary reference for domain event meaning. |
| `MSG-010` | Boundary reference for producer consistency if separately evidenced. |
| `HEX-010` | Boundary reference for messaging adapter boundary. |

## 8. Input Artifacts

The input is a mixed fixture manifest with static flow and document notes.

## 9. Directory Structure

```text
order-events/
  domain/Order
  infrastructure/OrderSqlRepository
  messaging/EventPublisher
```

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `OrderSqlRepository` | Infrastructure persistence. | Creates and publishes domain-significant event. |
| `Order` | Domain model. | No event intent recorded. |
| `EventPublisher` | Messaging adapter. | Publishes event created by infrastructure. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| Infrastructure repository | Event publisher | Direct publication | Infrastructure owns publication decision. |
| Domain model | Event intent | Absent | Domain ownership is not evidenced. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Domain-significant event decision | Domain/application boundary | Infrastructure |
| Delivery mechanics | Messaging adapter | Infrastructure |
| Event meaning | DDD boundary | Partial only |

## 13. Execution Flow

1. Repository saves order state.
2. Repository constructs `OrderApproved`.
3. Repository publishes through `EventPublisher`.
4. Domain model has no recorded event intent.

## 14. Preconditions

- Evaluate only the mixed manifest.
- Do not infer producer consistency failure unless durability evidence is added.
- Keep DDD and messaging conclusions separate.

## 15. Architecture State

The architecture state is a warning condition because ownership risk is visible, but full domain lifecycle and consistency evidence are withheld.

## 16. Evidence Provided

Partial evidence includes infrastructure event creation, direct publication, absent domain event intent, and event name with domain meaning.

## 17. Evidence Withheld

Complete domain lifecycle, transaction behavior, consumer contracts, organization ownership records, and runtime traces are withheld.

## 18. Expected Findings

Exactly one warning finding is required.

```text
Finding ID: EVAL-CROSS-003-F001
Rule ID: MSG-003
Title: Infrastructure code owns publication of a domain-significant event
Outcome: Warning
Confidence: Possible
Severity: Medium
Applicability: Applicable
Evidence: OrderSqlRepository creates and publishes a domain-significant event while the domain model records no event intent.
Impact: Event ownership may drift from domain meaning to infrastructure side effects.
Rationale: Partial evidence supports MSG-003 warning without confirming a broader DDD or consistency violation.
Remediation: Move event intent or publication decision to the appropriate domain/application boundary while keeping delivery mechanics in infrastructure.
Related Rules: DDD-011, MSG-010, HEX-010
Boundary Notes: Do not duplicate event meaning, ownership, and publication mechanics as one finding.
```

## 19. Expected Non-Findings

Do not report confirmed DDD event failure, producer consistency failure, Hexagonal adapter failure, or Clean use-case failure without exclusive evidence.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `MSG-003` | `Applicable` | `Warning` | `Match` |
| Scenario | `Applicable` | `Warning` | `Match` |

## 21. Expected Confidence

Expected confidence is `Possible` due partial and mixed evidence.

## 22. Expected Severity

Expected severity is `Medium` because event ownership risk is material but not confirmed as system-wide failure.

## 23. False Positive Guards

Do not duplicate event meaning, ownership, and publication mechanics as one finding or fail infrastructure delivery mechanics by default.

## 24. False Negative Guards

Do not miss infrastructure ownership of domain-significant publication when evidenced by event creation and direct publication.

## 25. Internal Boundary Expectations

`MSG-003` owns ownership. `MSG-010` requires separate producer consistency evidence.

## 26. Cross-Catalog Boundary Expectations

DDD x Events x Hexagonal x Clean responsibilities remain separate; shared event evidence does not permit duplicate findings.

## 27. Deduplication Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Infrastructure owns event publication | Yes | No | Yes | One `MSG-003` warning. |
| Producer consistency failure | No | Yes | Yes | Non-finding here. |

| Shared Evidence | Primary Catalog Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Event construction in repository | Event ownership warning | DDD/Hex/Clean context | Yes | Boundary notes only. |

## 28. Expected Remediation

Move event intent or publication decision to the domain/application boundary. Do not require event sourcing, CQRS, or a specific broker.

## 29. Allowed Variations

Equivalent warning language is allowed if ownership stays with `MSG-003`.

## 30. Disallowed Variations

Duplicate DDD/Event findings, unsupported `Fail`, `Pass`, invented Rules, or mandatory architectural style changes are disallowed.

## 31. Execution Instructions

Evaluate the mixed manifest only.

## 32. Acceptance Criteria

Accepted when one `MSG-003` warning appears with proper boundaries and no duplicate findings.

## 33. Failure Criteria

Fails when the warning is missed, over-escalated, duplicated, or reassigned.

## 34. Traceability

| Item | Trace |
| --- | --- |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/EVENTS_CATALOG.md` |
| Primary Rule normative file | `skill/rules/events/MSG-003.md` |
| Supporting Rule | `skill/rules/ddd/DDD-011.md` |
| Supporting Rule | `skill/rules/events/MSG-010.md` |
| Supporting Rule | `skill/rules/HEX-010.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |

## 35. Gold Standard Requirements

This scenario follows the Gold Standard structure and adapts semantic content only.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-CROSS-003`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `MSG-003`, Supporting Rules `DDD-011`, `MSG-010`, `HEX-010`, outcome `Warning`, and DDD x Events x Hexagonal x Clean boundaries.
