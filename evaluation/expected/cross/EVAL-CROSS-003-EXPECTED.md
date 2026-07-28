# Expected Result - EVAL-CROSS-003

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-CROSS-003-EXPECTED` |
| Scenario ID | `EVAL-CROSS-003` |
| Scenario Title | `Domain event is published directly by infrastructure code` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result for inventory correction. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-CROSS-003` |
| Title | `Domain event is published directly by infrastructure code` |
| Category | `Cross-Catalog` |
| Scenario Type | `Cross-Catalog Boundary` |
| Catalogs | `DDD`; `Events & Messaging`; `Hexagonal Architecture`; `Clean Architecture` |
| Primary Rule | `MSG-003` |
| Supporting Rules | `DDD-011`, `MSG-010`, `HEX-010` |
| Execution Type | `Mixed Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers infrastructure ownership of domain-significant event publication in `evaluation/scenarios/cross/EVAL-CROSS-003.md`.

## 4. Primary Rule Result

| Field | Expected Value |
| --- | --- |
| Rule ID | `MSG-003` |
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
| `DDD-011` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | None unless exclusive evidence exists | `No` | Domain event meaning context. | DDD finding that duplicates event ownership. | Preserve DDD boundary. | No duplicate finding. |
| `MSG-010` | `Undetermined` | Boundary context | Evidence-based | None | `No` | Consistency evidence withheld. | Producer consistency finding without evidence. | Preserve producer boundary. | No finding. |
| `HEX-010` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | None unless exclusive evidence exists | `No` | Adapter boundary context. | Hexagonal finding that restates ownership. | Preserve Hex boundary. | No duplicate finding. |

## 6. Expected Finding

```text
Finding ID: EVAL-CROSS-003-F001
Rule ID: MSG-003
Title: Infrastructure code owns publication of a domain-significant event
Outcome: Warning
Confidence: Possible
Severity: Medium
Applicability: Applicable
Evidence: OrderSqlRepository creates and publishes a domain-significant event while the domain model records no event intent.
Architectural Impact: Event ownership may drift from domain meaning to infrastructure side effects.
Rationale: Partial evidence supports MSG-003 warning without confirming a broader DDD or consistency violation.
Remediation: Move event intent or publication decision to the appropriate domain/application boundary while keeping delivery mechanics in infrastructure.
Related Rules: DDD-011, MSG-010, HEX-010
Boundary Notes: Do not duplicate event meaning, ownership, and publication mechanics as one finding.
```

## 7. Expected Finding Evidence

Required evidence is infrastructure event creation, direct publication, absent domain intent, and domain-significant event meaning.

## 8. Expected Architectural Impact

Event ownership may become an infrastructure side effect rather than a domain/application decision.

## 9. Expected Rationale

`MSG-003` owns event ownership. Partial evidence supports `Warning`.

## 10. Expected Remediation

Move event intent or publication decision to the appropriate boundary; do not require event sourcing, CQRS, or broker replacement.

## 11. Expected Non-Findings

No confirmed DDD, producer consistency, Hexagonal, or Clean finding is expected.

## 12. Expected Applicability

Applicability is `Applicable`.

## 13. Expected Outcome

Outcome is `Warning`.

## 14. Expected Confidence

Confidence is `Possible`.

## 15. Expected Severity

Severity is `Medium`.

## 16. Expected Evidence Interpretation

Infrastructure publication evidence supports ownership warning but not broader confirmed failures.

## 17. Expected Boundary Behavior

DDD x Events x Hexagonal x Clean responsibilities remain separate.

## 18. Expected Deduplication Behavior

Only one `MSG-003` warning should be emitted from shared event evidence.

## 19. Expected False Positive Protection

Do not duplicate event meaning, ownership, and publication mechanics as one finding.

## 20. Expected False Negative Protection

Do not miss infrastructure ownership of domain-significant publication when evidenced.

## 21. Allowed Result Variations

Equivalent warning wording is allowed.

## 22. Disallowed Result Variations

Duplicate findings, unsupported `Fail`, `Pass`, or Primary Rule reassignment is disallowed.

## 23. Comparison Method

Compare identity, outcome, confidence, severity, finding, boundaries, non-findings, remediation, and traceability.

## 24. Acceptance Criteria

Accepted when one `MSG-003` warning appears and duplicate catalog findings are absent.

## 25. Failure Criteria

Fails when the warning is missed, over-escalated, duplicated, or reassigned.

## 26. Result Status

Expected result status is `Match`.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/cross/EVAL-CROSS-003.md` |
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

## 28. Gold Standard Result Requirements

This expected result follows the Gold Standard expected-result structure.

## 29. Result Change Notes

Initial expected result for `EVAL-CROSS-003`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `MSG-003`, Supporting Rules `DDD-011`, `MSG-010`, `HEX-010`, outcome `Warning`, and DDD x Events x Hexagonal x Clean boundaries.
