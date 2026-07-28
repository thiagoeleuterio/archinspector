# EVAL-LAYER-002 - Application Layer Orchestrates Domain and Infrastructure Contracts

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-LAYER-002` |
| Title | `Application layer orchestrates domain and infrastructure contracts` |
| Category | `Layered Architecture` |
| Scenario Type | `Positive Compliance` |
| Catalogs | `Layered Architecture`; boundary references to `Clean Architecture` and `Hexagonal Architecture` |
| Primary Rule | `LAYER-005` |
| Supporting Rules | `LAYER-002`, `LAYER-006`, `HEX-004` |
| Risk Level | `Medium` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Implementation Order | `20` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/layered/EVAL-LAYER-002-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `LAYER-005`; catalog coverage for Layered Architecture; `Pass` outcome; `Likely` confidence; strong evidence; applicability; false-positive guard; false-negative guard; Layered x Clean boundary; Layered x Hexagonal boundary; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector recognizes legitimate application-layer orchestration when business decisions remain in domain/business responsibility and infrastructure is accessed through contracts.

The scenario protects positive compliance, orchestration false-positive control, business-rule false-negative control, cross-catalog boundaries, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Positive Compliance` |
| Secondary Types | `False Positive Guard`, `Cross-Catalog Boundary` |
| Primary Outcome | `Pass` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Likely` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious order-processing system.

The reviewed scope identifies an Application layer that coordinates order submission, a Domain layer that owns eligibility and acceptance rules, and Infrastructure implementations that satisfy application-facing contracts. The application workflow loads data through `OrderStore`, asks `OrderEligibilityPolicy` and `Order` to make business decisions, and persists the accepted order through the same contract.

The Application layer sequences the work, handles transaction boundary intent, and delegates decisions. It does not calculate discounts, decide eligibility, encode status-transition rules, or depend on concrete persistence mechanisms.

The description is technology-neutral and does not require a language, framework, database product, runtime, or executable fixture.

## 5. Target Catalogs

`Layered Architecture` owns the scenario category because the evaluated condition is application/service coordination without business rule ownership.

`Clean Architecture` and `Hexagonal Architecture` are boundary references because use case and outbound-port ideas may be adjacent, but this scenario evaluates the Layered application responsibility.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `LAYER-005` |
| Title | `Application or service layer must coordinate without owning business rules` |
| Category | `Layered Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/layered/LAYER-005.md` |
| Catalog File | `skill/rules/LAYER_CATALOG.md` |

`LAYER-005` is selected because it directly evaluates whether application/service code orchestrates work without becoming the owner of business rules. The manifest shows coordination, delegation to Domain, and access to Infrastructure through contracts.

`LAYER-002`, `LAYER-006`, and `HEX-004` are related, but they do not own the primary no-finding conclusion.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `LAYER-002` | Boundary reference for explicit layer responsibilities. |
| `LAYER-006` | Boundary reference for business rule ownership in Domain. |
| `HEX-004` | Boundary reference for outbound external-system contracts without replacing the Layered conclusion. |

Supporting Rules may explain boundary context and expected non-findings. They must not produce decorative findings.

## 8. Input Artifacts

The scenario input is a textual static manifest. It is not executable and must not be treated as compilable code.

The manifest includes:

- directory structure;
- layer map;
- component inventory;
- dependency inventory;
- responsibility inventory;
- execution flow;
- observable evidence;
- short pseudocode excerpts;
- evidence withheld.

## 9. Directory Structure

```text
order-processing/
  presentation/
    OrderEndpoint
  application/
    SubmitOrderService
    OrderStore
  domain/
    Order
    OrderEligibilityPolicy
  infrastructure/
    SqlOrderStore
```

Directory names are supporting context only. The expected pass depends on observed responsibilities and dependencies.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `SubmitOrderService` | Application orchestration. | Coordinates load, domain decision, save, and transaction intent. |
| `OrderStore` | Application-facing persistence contract. | Expresses storage need without concrete database details. |
| `Order` | Domain entity/business component. | Owns acceptance transition and invariant checks. |
| `OrderEligibilityPolicy` | Domain business policy. | Decides whether an order may be accepted. |
| `SqlOrderStore` | Infrastructure implementation. | Implements `OrderStore` outside Application and Domain. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `SubmitOrderService` | `OrderStore` | Contract dependency | Application coordinates persistence through a contract. |
| `SubmitOrderService` | `OrderEligibilityPolicy` | Delegation | Application asks Domain to decide eligibility. |
| `SubmitOrderService` | `Order` | Delegation | Application invokes domain transition behavior. |
| `SqlOrderStore` | `OrderStore` | Implementation dependency | Infrastructure satisfies application-facing contract. |

No dependency is provided from Application to `SqlOrderStore`, database settings, storage clients, or persistence mappings.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Receive order submission | Presentation | `OrderEndpoint` |
| Coordinate use of domain and persistence contracts | Application | `SubmitOrderService` |
| Decide order eligibility | Domain/Business | `OrderEligibilityPolicy` |
| Apply acceptance transition | Domain/Business | `Order` |
| Implement persistence mechanism | Infrastructure | `SqlOrderStore` |
| Know database configuration | Infrastructure or composition | Not in Application |

## 13. Execution Flow

1. `OrderEndpoint` calls `SubmitOrderService`.
2. `SubmitOrderService` loads an order through `OrderStore`.
3. `SubmitOrderService` asks `OrderEligibilityPolicy` to evaluate eligibility.
4. `Order` performs the acceptance transition.
5. `SubmitOrderService` saves through `OrderStore`.
6. `SqlOrderStore` implements the storage contract outside the Application layer.

The pass condition is present because Application coordinates without owning business rules or concrete persistence details.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or hidden architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is positive compliance.

The Application layer performs orchestration and delegates business decisions to Domain. Infrastructure is reached through a contract, and no direct concrete persistence dependency is provided.

## 16. Evidence Provided

Strong evidence is provided:

- observable Application, Domain, and Infrastructure responsibilities;
- Application orchestration through `SubmitOrderService`;
- Domain rule ownership in `OrderEligibilityPolicy` and `Order`;
- persistence access through `OrderStore`;
- infrastructure implementation `SqlOrderStore` outside Application;
- absence of concrete persistence details in Application.

Short non-compilable pseudocode:

```text
component SubmitOrderService
  uses OrderStore
  uses OrderEligibilityPolicy

  submit(orderId)
    order = OrderStore.load(orderId)
    OrderEligibilityPolicy.verify(order)
    order.accept()
    OrderStore.save(order)
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- executable fixture files;
- compilable source code;
- concrete language syntax;
- framework annotations;
- database product details;
- package files;
- build outputs;
- automated test outputs;
- runtime logs;
- complete transaction implementation;
- complete DDD tactical model;
- formal Clean Architecture adoption claim;
- formal Hexagonal Architecture adoption claim.

Withheld evidence prevents findings about framework leakage, DDD completeness, runtime behavior, architecture-test coverage, global persistence strategy, or formal architecture adoption.

## 18. Expected Findings

No corrective finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: LAYER-005
Outcome: Pass
Confidence: Likely
Severity: Not Applicable
Applicability: Applicable
Evidence: SubmitOrderService coordinates loading, domain eligibility evaluation, domain acceptance, and saving through OrderStore while business decisions remain in OrderEligibilityPolicy and Order, and SqlOrderStore remains outside Application.
Architectural Impact: No corrective impact is present because the Application layer coordinates without owning business rules.
Responsibility Impact: Application, Domain, and Infrastructure responsibilities remain distinguishable in the reviewed scope.
Dependency Impact: Application depends on a contract and domain behavior, not a concrete persistence implementation.
Rationale: LAYER-005 pass conditions are satisfied by coordination with delegated business decisions and contract-mediated infrastructure access.
Remediation: None.
Related Rules: LAYER-002, LAYER-006, HEX-004
Boundary Notes: The result concludes only application-layer coordination compliance. It must not become a Clean, Hexagonal, DDD, or Repository Pattern prescription.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- Application coordinating multiple collaborators;
- Application depending on a persistence contract;
- Application beginning or naming a transaction boundary;
- use of a monolith;
- absence of exactly four layers;
- absence of interfaces between every layer;
- absence of DDD tactical patterns;
- absence of Clean Architecture formalism;
- absence of Hexagonal Architecture formalism;
- absence of multiple adapters;
- absence of microservices;
- absence of architecture tests;
- infrastructure implementing a contract.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `LAYER-005` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Likely`.

The manifest provides consistent responsibility and dependency evidence, but full implementation and runtime details are withheld. Naming is supporting context only.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No finding is required, so no violation severity is assigned. The scenario risk level remains `Medium` as catalog coverage context.

## 23. False Positive Guards

Do not report a finding based only on:

- an Application service coordinating work;
- use of a service-like name;
- transaction boundary naming;
- dependencies on domain policies;
- use of an interface or contract;
- infrastructure implementation existing;
- lack of separate deployment units;
- lack of formal Clean or Hexagonal adoption.

The expected pass depends on observable delegation of business decisions and no concrete infrastructure dependency in Application.

## 24. False Negative Guards

Do not approve automatically if future material shows:

- Application calculating business eligibility;
- Application owning status-transition rules;
- Application duplicating domain rules;
- Application depending on concrete persistence;
- infrastructure configuration in Application logic;
- domain components reduced to passive data while rules live in Application.

## 25. Internal Boundary Expectations

`LAYER-005` owns the primary result because the evaluated concern is coordination without business rule ownership.

Related Layered rules may share evidence:

- `LAYER-002` supports responsibility clarity;
- `LAYER-006` owns the broader business-rule ownership question;
- `LAYER-003` would require a dependency-direction conclusion.

No additional finding is expected.

## 26. Cross-Catalog Boundary Expectations

### Layered x Clean Architecture

Layered evaluates application/service coordination in a layered structure. Clean evaluates use cases, policy boundaries, and source dependency direction. No Clean finding is expected without Clean-specific evidence.

### Layered x Hexagonal Architecture

Hexagonal may view `OrderStore` as an outbound port-like contract. That evidence may be boundary context, but the primary result remains `LAYER-005`.

### Layered x Core

Core review behavior validates evidence discipline and no false positives. No generic Core finding is allowed.

### Layered x Fowler

Fowler Service Layer or Transaction Script conclusions require pattern-specific evidence. Application orchestration is not automatically a Fowler finding.

## 27. Deduplication Expectations

| Shared Evidence | Layered Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| `SubmitOrderService` coordinates workflow | Application coordinates correctly under `LAYER-005` | Fowler Service Layer may be suspected | Yes | No Fowler finding without pattern-specific evaluation. |
| `OrderStore` contract used | Infrastructure access is mediated | Hexagonal outbound port may be suspected | Yes | Use as boundary context only. |
| Domain policy decides eligibility | Business rules are delegated | DDD or `LAYER-006` pass may be suspected | Yes | Do not duplicate the primary pass. |
| Infrastructure implements contract | Correct external implementation direction | Clean gateway or Hexagonal adapter pass may be suspected | Yes | No separate conclusion unless exclusive evidence exists. |

## 28. Expected Remediation

No corrective remediation is expected.

Observed output may state that current coordination should be preserved. It must not prescribe Clean Architecture, Hexagonal Architecture, DDD, microservices, CQRS, event sourcing, a framework, ORM, project separation, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences;
- equivalent order-processing terminology;
- equivalent evidence ordering;
- `Confirmed` confidence only if observed evaluation treats the manifest as complete enough;
- supporting Rule omission when non-decorative boundaries remain preserved;
- no corrective remediation.

## 30. Disallowed Variations

Disallowed variations:

- title different from the catalog;
- category different from the catalog;
- Primary Rule changed away from `LAYER-005`;
- primary outcome other than `Pass`;
- any corrective finding;
- severity assigned as if a violation exists;
- finding based only on service naming;
- duplicate Clean, Hexagonal, Fowler, Core, or Layered finding;
- remediation requiring unrelated architecture or technology.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/layered/EVAL-LAYER-002-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `LAYER-005` is evaluated as `Applicable`;
- primary outcome is `Pass`;
- confidence is `Likely` or accepted stronger confidence;
- severity is `Not Applicable`;
- no corrective finding appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Layered x Clean, Layered x Hexagonal, Layered x Core, and Layered x Fowler boundaries are respected;
- duplicate findings are absent;
- observed result comparison against `evaluation/expected/layered/EVAL-LAYER-002-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- any corrective finding appears;
- outcome is `Fail`, `Warning`, `Not Applicable`, or unsupported `Not Enough Evidence`;
- confidence contradicts the provided evidence;
- application orchestration is treated as business-rule ownership without evidence;
- duplicate Clean, Hexagonal, Fowler, Core, or Layered findings repeat the same conclusion;
- remediation prescribes unrelated architecture, technology, tooling, or rewrite;
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
| Coverage dimensions | `LAYER-005` positive-compliance coverage; Layered catalog coverage; `Pass`; `Likely`; no-finding severity absence; strong evidence; applicability; false-positive protection; false-negative protection; Layered x Clean boundary; Layered x Hexagonal boundary; deduplication. |
| Primary Rule catalog | `skill/rules/LAYER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/layered/LAYER-005.md` |
| Supporting Rule | `skill/rules/layered/LAYER-002.md` |
| Supporting Rule | `skill/rules/layered/LAYER-006.md` |
| Supporting Rule | `skill/rules/HEX-004.md` |
| Layered catalog review | `skill/reviews/LAYER_CATALOG_REVIEW.md` |
| Layered catalog stabilization | `skill/reviews/LAYER_CATALOG_STABILIZATION.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Fowler boundary review | `skill/reviews/FOWLER_CATALOG_REVIEW.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Gold Standard stabilization | `evaluation/stabilizations/EVAL-CORE-001-STABILIZATION.md` |

## 35. Gold Standard Requirements

This scenario follows the stabilized Gold Standard reference for structure, identity, evidence strength, atomicity, outcomes, confidence, severity, remediation proportionality, expected non-findings, false-positive protection, false-negative protection, cross-catalog boundaries, deduplication, and expected result traceability.

It must not introduce requirements outside the Evaluation Suite models or redefine existing Rules.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-LAYER-002`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `LAYER-005`, selected Supporting Rules, and expected `Pass` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
