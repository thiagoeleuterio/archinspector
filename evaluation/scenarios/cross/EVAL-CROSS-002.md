# EVAL-CROSS-002 - Repository contract and implementation are separated correctly

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CROSS-002` |
| Title | `Repository contract and implementation are separated correctly` |
| Category | `Cross-Catalog` |
| Scenario Type | `Cross-Catalog Boundary` |
| Catalogs | `Hexagonal Architecture`; `Clean Architecture`; `DDD`; `Fowler`; `Layered Architecture` |
| Primary Rule | `FOWLER-001` |
| Supporting Rules | `DDD-009`, `HEX-004`, `CLEAN-009` |
| Risk Level | `Medium` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/cross/EVAL-CROSS-002-EXPECTED.md` |
| Related Coverage Dimensions | Cross-catalog boundary; `Pass`; `Likely`; strong evidence; repository/gateway/port distinction; false-positive guard. |

## 2. Purpose

This scenario validates that a correctly separated repository contract and implementation is recognized without false positives across Fowler, DDD, Hexagonal, Clean, and Layered terminology.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Cross-Catalog Boundary` |
| Secondary Types | `Positive Compliance`, `False Positive Guard` |
| Primary Outcome | `Pass` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Likely` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The manifest defines an order repository contract in the domain/application boundary and a separate persistence implementation in infrastructure. Mapping and database details stay outside the contract.

## 5. Target Catalogs

`FOWLER-001` owns the repository pattern conclusion. DDD, Hexagonal, Clean, and Layered Rules are boundary references because their terms overlap but do not own the primary pass result.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `FOWLER-001` |
| Title | `Repository` |
| Category | `Fowler Patterns` |
| Status | `Active` |
| Normative File | `skill/rules/fowler/FOWLER-001.md` |
| Catalog File | `skill/rules/FOWLER_CATALOG.md` |

`FOWLER-001` is selected from the catalog because the conclusion is about repository separation. Alternatives are not primary because they evaluate domain contracts, ports, gateways, or layer placement.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `DDD-009` | Boundary reference for repository contract meaning inside the domain boundary. |
| `HEX-004` | Boundary reference for outbound ports without absorbing repository semantics. |
| `CLEAN-009` | Boundary reference for gateway isolation. |

## 8. Input Artifacts

The input is a static textual manifest.

## 9. Directory Structure

```text
orders/
  domain/OrderRepository
  infrastructure/SqlOrderRepository
  application/FindOrderUseCase
```

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `OrderRepository` | Repository contract. | Domain-facing operations, no database API. |
| `SqlOrderRepository` | Implementation. | Contains mapping and persistence details. |
| `FindOrderUseCase` | Client. | Depends on contract. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| Use case | Repository contract | Boundary dependency | Correct dependency direction. |
| Infrastructure implementation | Repository contract | Implementation dependency | Correct separation. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Collection-like access abstraction | Repository contract | Present |
| Persistence mechanics | Infrastructure implementation | Present |
| Cross-catalog terminology separation | Evaluation suite | Required |

## 13. Execution Flow

1. Use case calls repository contract.
2. Infrastructure implementation satisfies contract.
3. Mapping and persistence remain outside the contract.

## 14. Preconditions

- Evaluate only reviewed manifest evidence.
- Do not treat repository terminology as automatic infrastructure leakage.
- Do not infer complete system compliance.

## 15. Architecture State

The architecture state is positive compliance for the repository separation under `FOWLER-001`.

## 16. Evidence Provided

Strong evidence includes separated contract, separated implementation, correct dependency direction, and absence of database detail in the contract.

## 17. Evidence Withheld

Database product behavior, complete ORM mapping, performance traces, unrelated repositories, and runtime execution are withheld.

## 18. Expected Findings

No corrective finding is expected. Expected Finding Count: 0.

## 19. Expected Non-Findings

Do not report repository contract as infrastructure leakage, gateway violation, port violation, mapper violation, or layer violation.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `FOWLER-001` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Likely` because strong static evidence exists while runtime and unrelated repositories are withheld.

## 22. Expected Severity

No severity applies because no finding is expected.

## 23. False Positive Guards

Repository, gateway, mapper, adapter, and port concepts must retain separate meanings. Correct outward implementation dependency is not a violation.

## 24. False Negative Guards

Do not miss implementation leakage into the contract if concrete persistence types appear later.

## 25. Internal Boundary Expectations

Fowler repository responsibilities must remain separate from Data Mapper and Active Record pattern conclusions.

## 26. Cross-Catalog Boundary Expectations

Hexagonal, Clean, DDD, and Layered Rules may share evidence but must not duplicate or replace the `FOWLER-001` pass conclusion.

## 27. Deduplication Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Repository separation is correct | Yes | No | Yes | `Pass` under `FOWLER-001`. |
| Port/gateway compliance | No | Yes | Yes | Boundary note only. |

| Shared Evidence | Primary Catalog Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Contract/implementation split | Repository pass | DDD/Hex/Clean context | Yes | No finding. |

## 28. Expected Remediation

No remediation is expected for this non-finding scenario.

## 29. Allowed Variations

Equivalent wording is allowed if `FOWLER-001`, `Pass`, zero findings, and boundaries remain unchanged.

## 30. Disallowed Variations

Any corrective finding from correct separation, invented Rule, or global compliance claim is disallowed.

## 31. Execution Instructions

Evaluate statically. Do not generate code.

## 32. Acceptance Criteria

Accepted when `FOWLER-001` passes and forbidden false positives remain absent.

## 33. Failure Criteria

Fails when correct separation is reported as violation or boundaries are conflated.

## 34. Traceability

| Item | Trace |
| --- | --- |
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

## 35. Gold Standard Requirements

This scenario follows the Gold Standard structure and adapts semantic content only.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-CROSS-002`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `FOWLER-001`, Supporting Rules `DDD-009`, `HEX-004`, `CLEAN-009`, outcome `Pass`, and repository boundary ownership.
