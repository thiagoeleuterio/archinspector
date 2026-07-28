# Expected Result - EVAL-CROSS-001

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-CROSS-001-EXPECTED` |
| Scenario ID | `EVAL-CROSS-001` |
| Scenario Title | `Domain service directly depends on a database framework` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result for inventory correction. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-CROSS-001` |
| Title | `Domain service directly depends on a database framework` |
| Category | `Cross-Catalog` |
| Scenario Type | `Cross-Catalog Boundary` |
| Catalogs | `Core`; `Hexagonal Architecture`; `Clean Architecture`; `DDD`; `Layered Architecture` |
| Primary Rule | `HEX-001` |
| Supporting Rules | `CLEAN-004`, `LAYER-007`, `SOLID-001` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers `evaluation/scenarios/cross/EVAL-CROSS-001.md`, including direct domain-service dependency on database framework infrastructure and cross-catalog duplicate controls.

## 4. Primary Rule Result

| Field | Expected Value |
| --- | --- |
| Rule ID | `HEX-001` |
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
| `CLEAN-004` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | None unless exclusive evidence exists | `No` | Shared dependency evidence. | Clean finding that restates `HEX-001`. | Preserve Clean boundary. | No duplicate finding. |
| `LAYER-007` | `Undetermined` | Boundary context | Evidence-based | None unless exclusive evidence exists | `No` | Persistence evidence only. | Layered finding that restates direct dependency. | Preserve Layered boundary. | No duplicate finding. |
| `SOLID-001` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | None unless exclusive evidence exists | `No` | Dependency inversion context. | SOLID finding that restates `HEX-001`. | Preserve SOLID boundary. | No duplicate finding. |

## 6. Expected Finding

```text
Finding ID: EVAL-CROSS-001-F001
Rule ID: HEX-001
Title: Domain service directly depends on database framework infrastructure
Outcome: Fail
Confidence: Confirmed
Severity: High
Applicability: Applicable
Evidence: PricingDomainService imports and uses DatabaseQueryApi during domain decision logic without a port, gateway, or contract.
Architectural Impact: Domain behavior is coupled to infrastructure and cannot evolve independently from the database framework.
Rationale: Direct domain-to-infrastructure dependency satisfies HEX-001.
Remediation: Move database framework usage behind a boundary abstraction owned outside the domain dependency direction.
Related Rules: CLEAN-004, LAYER-007, SOLID-001
Boundary Notes: Neighboring catalogs must not duplicate the same conclusion.
```

## 7. Expected Finding Evidence

Required evidence is domain scope, concrete database framework dependency, persistence behavior inside domain logic, and absence of boundary abstraction.

## 8. Expected Architectural Impact

Central domain behavior is tied to infrastructure details.

## 9. Expected Rationale

`HEX-001` owns the direct dependency conclusion; related catalogs require separate exclusive evidence.

## 10. Expected Remediation

Introduce a boundary abstraction and move database framework use outside domain behavior. Do not mandate a rewrite or specific architecture style.

## 11. Expected Non-Findings

No DDD, Clean, Layered, SOLID, repository, framework-choice, microservice, cloud, or CI/CD finding is expected.

## 12. Expected Applicability

Applicability is `Applicable`.

## 13. Expected Outcome

Outcome is `Fail`.

## 14. Expected Confidence

Confidence is `Confirmed`.

## 15. Expected Severity

Severity is `High`.

## 16. Expected Evidence Interpretation

Direct import and persistence behavior are sufficient; naming is only supporting context.

## 17. Expected Boundary Behavior

`HEX-001` owns the finding; neighboring catalogs may only add non-finding boundary notes.

## 18. Expected Deduplication Behavior

The same database-framework dependency must not become multiple findings.

## 19. Expected False Positive Protection

Shared evidence must not create duplicate semantic findings.

## 20. Expected False Negative Protection

The violation must be detected despite `DomainService` naming or lack of formal Hexagonal claim.

## 21. Allowed Result Variations

Equivalent wording is allowed if ownership, outcome, confidence, severity, and finding count remain.

## 22. Disallowed Result Variations

Duplicate findings, missing finding, wrong Primary Rule, or naming-only rationale is disallowed.

## 23. Comparison Method

Compare identity, Rule, outcome, confidence, severity, finding, evidence, boundaries, deduplication, remediation, and traceability.

## 24. Acceptance Criteria

Accepted when exactly one `HEX-001` finding appears and duplicate neighboring findings are absent.

## 25. Failure Criteria

Fails when the finding is absent, duplicated, generic, or reassigned.

## 26. Result Status

Expected result status is `Match`.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/cross/EVAL-CROSS-001.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/HEX_CATALOG.md` |
| Primary Rule normative file | `skill/rules/HEX-001.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-004.md` |
| Supporting Rule | `skill/rules/layered/LAYER-007.md` |
| Supporting Rule | `skill/rules/solid/SOLID-001.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |

## 28. Gold Standard Result Requirements

This expected result follows the Gold Standard expected-result structure.

## 29. Result Change Notes

Initial expected result for `EVAL-CROSS-001`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `HEX-001`, Supporting Rules `CLEAN-004`, `LAYER-007`, `SOLID-001`, outcome `Fail`, and cross-catalog boundaries.
