# EVAL-DDD-003 - Repository Contract Is Defined Inside the Domain Boundary

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-DDD-003` |
| Title | `Repository contract is defined inside the domain boundary` |
| Category | `DDD` |
| Scenario Type | `False Positive Guard` |
| Catalogs | `DDD`; boundary references to `Hexagonal Architecture` and `Clean Architecture` |
| Primary Rule | `DDD-009` |
| Supporting Rules | `HEX-005`, `CLEAN-009`, `FOWLER-001` |
| Risk Level | `Medium` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Implementation Order | `17` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/ddd/EVAL-DDD-003-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `DDD-009`; catalog coverage for DDD; `Pass` outcome; `Likely` confidence; no-finding severity absence; strong evidence; applicability; false-positive guard; false-negative guard; DDD x Hexagonal boundary; DDD x Clean boundary; DDD x Fowler boundary; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector does not report a repository contract inside the domain boundary as infrastructure leakage when the contract represents a domain collection boundary.

The scenario protects false-positive control, repository semantic ownership, cross-catalog boundaries, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `False Positive Guard` |
| Secondary Types | `Positive Compliance`, `Cross-Catalog Boundary` |
| Primary Outcome | `Pass` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Likely` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious order domain.

The reviewed scope contains an `OrderRepository` contract inside the domain boundary. Its operations speak in aggregate and domain collection language, such as finding an order by domain identity and storing an order aggregate. A concrete `SqlOrderRepository` exists outside the domain and implements the contract. The domain contract does not expose SQL, connection settings, table names, ORM query objects, transport DTOs, or infrastructure lifecycle concerns.

The repository contract is domain-facing. The scenario should pass `DDD-009` and must not treat the contract's location inside the domain as automatic infrastructure leakage.

## 5. Target Catalogs

`DDD` owns the scenario category because the evaluated concern is repository as a domain collection boundary.

`Hexagonal Architecture` is a boundary reference because outbound adapter implementation evidence is adjacent. `Clean Architecture` is a boundary reference because gateway isolation is adjacent. `Fowler Patterns` is a boundary reference because Fowler Repository has related collection semantics.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `DDD-009` |
| Title | `Repositories must represent domain collection boundaries` |
| Category | `Domain-Driven Design` |
| Status | `Active` |
| Normative File | `skill/rules/ddd/DDD-009.md` |
| Catalog File | `skill/rules/DDD_CATALOG.md` |

`DDD-009` is selected because it directly evaluates whether repositories expose domain-oriented collection access without making the domain model conform to storage concerns.

`HEX-005`, `CLEAN-009`, and `FOWLER-001` are related but not primary. They own adapter implementation, Clean gateway isolation, and Fowler Repository pattern conformance respectively.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `HEX-005` | Boundary reference for infrastructure adapter implementation of a domain-facing contract. |
| `CLEAN-009` | Boundary reference for use case gateway isolation without duplicating DDD repository semantics. |
| `FOWLER-001` | Boundary reference for Fowler Repository pattern semantics without replacing DDD repository ownership. |

Supporting Rules may explain why no neighboring finding is expected. They must not convert a legitimate domain-facing repository contract into infrastructure leakage.

## 8. Input Artifacts

The scenario input is a textual static manifest. It is not executable and must not be treated as compilable code.

The manifest includes:

- directory structure;
- component inventory;
- dependency inventory;
- responsibility inventory;
- execution flow;
- observable evidence;
- short pseudocode excerpts;
- explicit absence of storage-shaped contract members.

## 9. Directory Structure

```text
order-processing/
  domain/
    Order
    OrderId
    OrderRepository
  infrastructure/
    SqlOrderRepository
    SqlOrderMapper
  application/
    SubmitOrder
```

Directory names are supporting context only. The expected pass depends on contract shape and dependency behavior.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `Order` | Aggregate collected by repository. | Exposes domain state and behavior independently from storage structures. |
| `OrderId` | Domain identity value. | Used by repository contract as domain identity. |
| `OrderRepository` | Domain-facing collection contract. | Defines `get(OrderId)`, `add(Order)`, and `remove(Order)` style operations. |
| `SqlOrderRepository` | Infrastructure implementation. | Implements the domain contract outside the domain boundary. |
| `SqlOrderMapper` | Persistence mapper. | Converts between storage rows and `Order` outside the domain. |
| `SubmitOrder` | Application operation. | Uses the repository contract without knowing SQL details. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `OrderRepository` | `Order` | Contract type | Repository collects a domain aggregate. |
| `OrderRepository` | `OrderId` | Contract type | Repository uses domain identity. |
| `SubmitOrder` | `OrderRepository` | Domain-facing contract dependency | Application flow depends on the contract, not implementation. |
| `SqlOrderRepository` | `OrderRepository` | Implementation dependency | Infrastructure conforms to domain-facing boundary. |
| `SqlOrderRepository` | `SqlOrderMapper` | Persistence mapping dependency | Storage concern remains outside domain contract. |

No dependency is provided from `OrderRepository` to SQL connection settings, table names, query builders, ORM sessions, or persistence DTOs.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Express domain collection access | Domain repository contract | `OrderRepository` |
| Define storage implementation | Infrastructure | `SqlOrderRepository` |
| Map storage rows to domain objects | Infrastructure mapper | `SqlOrderMapper` |
| Coordinate use case persistence need | Application | `SubmitOrder` through contract |
| Expose storage-shaped API to domain | Not expected | Absent |

## 13. Execution Flow

1. `SubmitOrder` receives an order command.
2. `SubmitOrder` creates or obtains an `Order`.
3. `SubmitOrder` calls `OrderRepository.add(Order)`.
4. At composition time, `SqlOrderRepository` is supplied as the implementation.
5. `SqlOrderRepository` maps storage rows outside the domain boundary.

The pass condition is present because the contract expresses domain collection semantics and storage mechanics remain outside the domain.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is a false-positive guard with positive compliance.

The domain repository contract is legitimate because it is shaped by domain collection needs rather than storage concerns.

## 16. Evidence Provided

Strong evidence is provided:

- repository scope: `OrderRepository` is a domain-facing contract;
- collected elements: `Order` aggregate and `OrderId`;
- domain-oriented operations: get/add/remove around domain objects;
- infrastructure implementation exists outside the domain;
- mapping stays outside the domain contract;
- no storage-shaped members are exposed by the contract;
- application flow depends on the contract, not concrete storage.

Short non-compilable pseudocode:

```text
contract OrderRepository
  get(id: OrderId) -> Order
  add(order: Order)
  remove(order: Order)

component SqlOrderRepository
  implements OrderRepository
  uses SqlOrderMapper
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- executable fixture files;
- compilable source code;
- concrete language syntax;
- ORM configuration;
- database product details;
- transaction implementation;
- complete mapping code;
- runtime logs;
- automated tests;
- domain events;
- messaging publication;
- formal Hexagonal Architecture claim;
- formal Clean Architecture claim.

Withheld evidence prevents findings about ORM correctness, gateway completeness, adapter testability, messaging, or global pattern conformance.

## 18. Expected Findings

No corrective finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: DDD-009
Outcome: Pass
Confidence: Likely
Severity: Not Applicable
Applicability: Applicable
Evidence: OrderRepository uses Order and OrderId in domain-oriented collection operations while SqlOrderRepository and SqlOrderMapper keep storage concerns outside the domain contract.
Architectural Impact: No corrective impact is present because the repository contract preserves a domain collection boundary in the reviewed scope.
Domain Impact: Order collection access is expressed in domain language without forcing the domain model to expose storage concerns.
Rationale: DDD-009 pass conditions are satisfied by domain-oriented repository contract shape and absence of storage-shaped domain API.
Remediation: None.
Related Rules: HEX-005, CLEAN-009, FOWLER-001
Boundary Notes: The result concludes only that the repository contract represents a DDD domain collection boundary. It must not become a Hexagonal, Clean, or Fowler finding unless exclusive evidence supports those responsibilities.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- repository contract inside domain as infrastructure leakage;
- absence of concrete repository in domain;
- absence of Repository Pattern by Fowler unless pattern evidence is separately evaluated;
- absence of ORM abstraction;
- database product choice;
- absence of Bounded Context;
- absence of Aggregate formalism beyond `Order`;
- absence of Domain Events;
- absence of messaging;
- absence of microservices;
- absence of formal Hexagonal Architecture;
- absence of Clean Architecture;
- absence of architecture tests;
- monolithic application shape.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `DDD-009` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Likely`.

The manifest provides strong contract and dependency evidence, but implementation details and complete mapping behavior are withheld. Naming alone is not used.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No finding is required, so no violation severity is assigned. The scenario risk level remains `Medium` as catalog coverage context.

## 23. False Positive Guards

Do not report a finding based only on:

- the word `Repository`;
- the repository contract living in the domain;
- infrastructure implementing a domain contract;
- absence of storage-specific methods;
- monolithic deployment;
- lack of formal Hexagonal or Clean terminology;
- lack of a specific ORM or database abstraction.

The contract is legitimate when it expresses domain collection access.

## 24. False Negative Guards

Do not approve automatically if future material shows:

- SQL terms in repository methods;
- table, row, cursor, ORM session, or connection types crossing the domain contract;
- repository operations shaped by storage schema rather than domain collection meaning;
- domain aggregate fields added only for persistence mapping;
- application flow depending directly on `SqlOrderRepository`.

The pass depends on storage concerns remaining outside the domain contract.

## 25. Internal Boundary Expectations

`DDD-009` owns the primary result because the evaluated concern is DDD repository collection-boundary semantics.

Related DDD rules may share evidence:

- `DDD-004` may identify collected aggregates;
- `DDD-006` may identify entity identity;
- `DDD-019` may be relevant only if domain code assumes non-domain responsibilities.

No additional DDD finding is expected.

## 26. Cross-Catalog Boundary Expectations

### DDD x Core

Core review behavior validates legitimate dependency interpretation and no generic finding for the same evidence.

### DDD x Events and Messaging

No event or messaging behavior is provided. Repository semantics do not prove or require event publication.

### DDD x Fowler

Fowler `Repository` is related but owns Fowler pattern conformance. `DDD-009` owns the DDD domain collection boundary and should not be replaced by `FOWLER-001`.

### DDD x Clean

Clean `CLEAN-009` owns use case gateway isolation. The same contract may support Clean boundary context, but no Clean finding is required without exclusive use case/external-system evidence.

### DDD x Hexagonal

Hexagonal `HEX-005` owns outbound adapter implementation of ports. A domain-facing repository contract is not automatically adapter leakage or Hexagonal conformance.

## 27. Deduplication Expectations

| Shared Evidence | DDD Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| `OrderRepository` contract uses `Order` | Domain collection boundary passes under `DDD-009` | Fowler Repository pass may be suspected | Yes | Keep Fowler as boundary context unless pattern comparison is explicit. |
| `SqlOrderRepository` implements contract | Storage implementation outside domain | Hexagonal adapter pass may be suspected | Yes | Do not create separate Hexagonal finding. |
| `SubmitOrder` depends on contract | Application uses domain-facing boundary | Clean gateway pass may be suspected | Yes | No Clean result unless use case evidence is separately evaluated. |
| No SQL terms in contract | Repository not storage-shaped | Generic persistence finding may be suspected | Yes | No persistence strategy finding. |

## 28. Expected Remediation

No corrective remediation is expected.

Observed output may state that no remediation is required for the Primary Rule. It may recommend preserving domain-oriented contract language, but it must not prescribe microservices, Clean Architecture, Hexagonal formalism, specific ORM, event sourcing, CQRS, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences;
- equivalent order-domain terminology;
- equivalent repository operation names that remain domain-oriented;
- `Confirmed` confidence if the manifest is treated as sufficient direct contract evidence;
- supporting Rule omission when decorative;
- no separate supporting findings.

## 30. Disallowed Variations

Disallowed variations:

- title different from the catalog;
- category different from the catalog;
- Primary Rule changed away from `DDD-009`;
- `Fail`;
- `Warning` based only on repository contract location;
- `Not Applicable`;
- `Not Enough Evidence` when the manifest is used;
- any corrective finding;
- severity assigned despite no finding;
- finding based only on naming;
- duplicate Hexagonal, Clean, Fowler, or Core findings;
- remediation requiring unrelated architecture or technology.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/ddd/EVAL-DDD-003-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `DDD-009` is evaluated as `Applicable`;
- primary outcome is `Pass`;
- confidence is `Likely` or stronger if justified;
- severity is `Not Applicable`;
- no corrective finding appears;
- no finding treats the domain contract as infrastructure leakage;
- expected non-findings are absent;
- DDD x Hexagonal, DDD x Clean, and DDD x Fowler boundaries are respected;
- duplicate findings are absent;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- any corrective finding appears;
- outcome is `Fail`, unsupported `Warning`, `Not Applicable`, or unsupported `Not Enough Evidence`;
- repository location alone is treated as violation;
- expected non-findings appear;
- duplicate Hexagonal, Clean, Fowler, Core, or DDD findings repeat the same conclusion;
- remediation prescribes unrelated architecture or tooling;
- a nonexistent Rule is used;
- existing Rules or catalogs are redefined.

## 34. Traceability

| Item | Trace |
| --- | --- |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Input artifacts | Textual static manifest in sections 8 through 17 of this scenario. |
| Coverage dimensions | `DDD-009` false-positive guard coverage; DDD catalog coverage; `Pass`; `Likely`; no-finding severity absence; strong evidence; applicability; DDD x Hexagonal boundary; DDD x Clean boundary; DDD x Fowler boundary; deduplication. |
| Primary Rule catalog | `skill/rules/DDD_CATALOG.md` |
| Primary Rule normative file | `skill/rules/ddd/DDD-009.md` |
| Supporting Rule | `skill/rules/HEX-005.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-009.md` |
| Supporting Rule | `skill/rules/fowler/FOWLER-001.md` |
| DDD catalog review | `skill/reviews/DDD_CATALOG_REVIEW.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
| Fowler boundary review | `skill/reviews/FOWLER_CATALOG_REVIEW.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Gold Standard stabilization | `evaluation/stabilizations/EVAL-CORE-001-STABILIZATION.md` |

## 35. Gold Standard Requirements

This scenario follows the stabilized Gold Standard reference for:

- structure;
- identity;
- level of detail;
- evidence strength;
- atomicity;
- outcomes;
- confidence;
- severity;
- finding specificity;
- remediation proportionality;
- expected non-findings;
- false-positive protection;
- false-negative protection;
- cross-catalog boundaries;
- deduplication;
- expected result traceability.

It must not introduce requirements outside the Evaluation Suite models or redefine existing Rules.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-DDD-003`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `DDD-009`, selected Supporting Rules, and expected `Pass` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
