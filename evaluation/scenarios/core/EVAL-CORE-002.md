# EVAL-CORE-002 - Cohesive Domain Module With Legitimate Dependencies

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CORE-002` |
| Title | `Cohesive domain module with legitimate dependencies` |
| Category | `Core` |
| Scenario Type | `Positive Compliance` |
| Catalogs | `Core`; boundary references to `Layered Architecture` and `Domain-Driven Design` |
| Primary Rule | `LAYER-002` |
| Supporting Rules | `DDD-002`, `DDD-006`, `DDD-012` |
| Risk Level | `Medium` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/core/EVAL-CORE-002-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `LAYER-002`; catalog coverage for Core, Layered Architecture, and DDD; `Pass` outcome; `Confirmed` confidence; contextual absence of severity; strong evidence; applicability; false-positive guard; false-negative guard; internal boundary; Core x DDD boundary; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector recognizes a cohesive order domain module with legitimate internal dependencies and does not report corrective findings merely because domain components collaborate.

The scenario protects positive compliance, evidence discipline, proportional reporting, false-positive control, false-negative control, internal boundary behavior, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Positive Compliance` |
| Secondary Types | `False Positive Guard`, `Internal Boundary` |
| Primary Outcome | `Pass` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Confirmed` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious order-processing system.

The reviewed scope contains a domain module for order acceptance and pricing. Domain entities and domain services collaborate around order lifecycle, pricing policy, eligibility checks, and a domain-owned persistence contract. Infrastructure implementation exists outside the domain and depends on the domain contract. Composition is performed outside the domain by an application bootstrap component.

There is no direct reference from domain behavior to infrastructure. There is no external configuration, persistence client creation, framework dependency, or storage execution inside the domain module. The provided dependencies are observable and point between cohesive components within the same core responsibility or from external implementation toward a domain-facing contract.

The description is technology-neutral. The scenario does not require any programming language, framework, database product, runtime, microservice architecture, or executable fixture.

## 5. Target Catalogs

`Core` owns the scenario category because the scenario validates central ArchInspector behavior: evidence before conclusion, recognition of legitimate dependencies, proportional non-findings, boundary handling, and deduplication.

The repository does not define a `CORE-*` Rule prefix. `evaluation/SCENARIO_CATALOG.md` states that Core scenarios target existing Rules whose responsibilities exercise Core review behavior.

`Layered Architecture` is a boundary reference because `LAYER-002` is the existing Rule selected by the scenario catalog for this scenario.

`Domain-Driven Design` is a boundary reference because domain language, entity lifecycle, and invariant evidence may support the interpretation, but DDD rules must not require tactical DDD patterns or duplicate the Primary Rule conclusion.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `LAYER-002` |
| Title | `Layers must have explicit and consistent responsibilities` |
| Category | `Layered Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/layered/LAYER-002.md` |
| Catalog File | `skill/rules/LAYER_CATALOG.md` |

`LAYER-002` is selected because it evaluates whether identified layers or modules have explicit, consistent, and non-contradictory responsibilities within the reviewed scope. This scenario provides enough structural and responsibility evidence to confirm that the order domain module has a clear purpose and that its internal dependencies are cohesive.

The selection follows `evaluation/SCENARIO_CATALOG.md`, which identifies `LAYER-002` as the Primary Rule for `EVAL-CORE-002`. No `CORE-*` Rule exists, and `LAYER-002` is the most precise existing Rule for evaluating responsibility clarity and cohesion in this compliant Core scenario.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `DDD-002` | Boundary reference for consistent order-domain language across entities, services, and domain-facing contracts. |
| `DDD-006` | Boundary reference for entity identity and lifecycle behavior in `Order` and `OrderLine`. |
| `DDD-012` | Boundary reference for domain invariant enforcement during order creation, pricing, and acceptance. |

Supporting Rules may be used to explain related domain-model evidence or expected non-findings. They must not duplicate the Primary Rule conclusion or require tactical DDD structures that the scenario does not provide.

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
- explicit absence of direct infrastructure references in the domain.

## 9. Directory Structure

```text
order-processing/
  order-domain/
    Order
    OrderLine
    PricingPolicy
    OrderEligibility
    OrderRepository
  infrastructure/
    SqlOrderRepository
    SqlConnectionSettings
  application/
    SubmitOrderWorkflow
    OrderCompositionRoot
```

The directory names are supporting context only. The expected pass must depend on explicit structural and behavioral evidence, not on names alone.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `Order` | Domain entity that owns order lifecycle state. | Validates acceptance state and coordinates order-line totals. |
| `OrderLine` | Domain entity within order behavior. | Provides quantity and price contribution used by `Order`. |
| `PricingPolicy` | Domain service for cohesive pricing rules. | Depends on `Order` and `OrderLine` domain concepts only. |
| `OrderEligibility` | Domain service for acceptance rules. | Uses `PricingPolicy` and `Order` without infrastructure references. |
| `OrderRepository` | Domain-facing abstract contract. | Defines persistence need without naming storage technology or configuration. |
| `SqlOrderRepository` | External persistence implementation. | Implements `OrderRepository` outside the domain. |
| `SqlConnectionSettings` | External connection configuration. | Used only by `SqlOrderRepository` and composition. |
| `SubmitOrderWorkflow` | Application entry into order submission. | Orchestrates domain behavior and receives a repository contract from composition. |
| `OrderCompositionRoot` | External composition boundary. | Connects `SqlOrderRepository` to `OrderRepository` outside the domain. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `Order` | `OrderLine` | Internal domain reference | Legitimate collaboration inside the order domain responsibility. |
| `PricingPolicy` | `Order` | Internal domain reference | Pricing rule depends on domain concepts, not infrastructure. |
| `OrderEligibility` | `PricingPolicy` | Internal domain service dependency | Cohesive rule collaboration within the same domain core. |
| `OrderEligibility` | `OrderRepository` | Domain-facing contract dependency | Domain uses an abstract contract owned by the boundary, not a concrete adapter. |
| `SqlOrderRepository` | `OrderRepository` | Implementation dependency | Infrastructure depends on the domain-facing contract. |
| `OrderCompositionRoot` | `SqlOrderRepository` | Composition dependency | External composition wires concrete implementation outside domain behavior. |

No dependency is provided from the domain module to `SqlOrderRepository`, `SqlConnectionSettings`, database clients, framework APIs, external configuration, or infrastructure packages.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Represent order lifecycle identity | Domain | `Order` |
| Calculate order totals | Domain | `Order` and `PricingPolicy` |
| Decide whether an order can be accepted | Domain | `OrderEligibility` and `Order` |
| Define persistence need as a domain-facing contract | Core or appropriate boundary layer | `OrderRepository` |
| Implement external persistence | Infrastructure | `SqlOrderRepository` |
| Know connection configuration | Infrastructure or composition boundary | `SqlOrderRepository` and `OrderCompositionRoot` |
| Compose concrete dependencies | Application or composition boundary | `OrderCompositionRoot` |

## 13. Execution Flow

1. `SubmitOrderWorkflow` receives an order submission.
2. `SubmitOrderWorkflow` asks `OrderEligibility` to evaluate acceptance.
3. `OrderEligibility` uses `PricingPolicy` to evaluate order totals and limits.
4. `Order` performs lifecycle transition checks before acceptance.
5. `SubmitOrderWorkflow` saves the accepted order through the `OrderRepository` contract.
6. `OrderCompositionRoot` supplies `SqlOrderRepository` from outside the domain.

The pass condition is present because responsibilities remain explicit and consistent, dependencies are cohesive, and infrastructure concerns remain outside the domain.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is positive compliance.

The reviewed material identifies a domain module with clear responsibility for order business behavior. Internal domain dependencies support cohesive behavior, while the external persistence implementation and external configuration remain outside the domain. The scenario does not require isolation from all dependencies, only responsibility consistency and correct boundary interpretation.

## 16. Evidence Provided

Strong evidence is provided:

- domain scope: `order-domain` contains order entities, services, and domain-facing contract;
- explicit responsibilities: order lifecycle, pricing, eligibility, persistence contract, infrastructure implementation, and composition are separated;
- internal dependencies: `Order`, `OrderLine`, `PricingPolicy`, and `OrderEligibility` collaborate inside one cohesive domain core;
- abstract boundary: `OrderRepository` defines a domain-facing contract;
- external implementation: `SqlOrderRepository` implements the contract outside the domain;
- external composition: `OrderCompositionRoot` wires concrete infrastructure outside domain behavior;
- correct direction: infrastructure depends on the contract rather than domain depending on infrastructure;
- absence of external configuration in domain: `SqlConnectionSettings` is not referenced by domain components.

Short non-compilable pseudocode:

```text
component OrderEligibility
  uses PricingPolicy
  uses OrderRepository

  canAccept(order)
    total = PricingPolicy.calculateFor(order)
    verify order lifecycle and total limits
    return order.canMoveToAccepted(total)

component SqlOrderRepository
  implements OrderRepository
  uses SqlConnectionSettings
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
- architecture diagrams beyond the manifest;
- claims of formal Hexagonal Architecture adoption;
- claims of formal Clean Architecture adoption;
- claims of formal DDD tactical completeness;
- microservice deployment topology.

Withheld evidence prevents findings about unrelated formal architecture adoption, tactical DDD completeness, framework leakage, test coverage, runtime behavior, or global persistence strategy.

## 18. Expected Findings

No corrective finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: LAYER-002
Outcome: Pass
Confidence: Confirmed
Severity: Not Applicable
Applicability: Applicable
Evidence: Domain responsibilities are explicit and consistent; dependencies between Order, OrderLine, PricingPolicy, OrderEligibility, and OrderRepository remain within cohesive order-domain responsibility; SqlOrderRepository and SqlConnectionSettings remain outside the domain; composition is external.
Architectural Impact: No corrective impact is present because the reviewed structure preserves clear responsibilities and legitimate dependencies.
Rationale: LAYER-002 pass conditions are satisfied by explicit responsibility separation and absence of contradictory responsibility ownership.
Remediation: None.
Related Rules: DDD-002, DDD-006, DDD-012
Boundary Notes: The result concludes only that responsibilities are explicit and consistent for the reviewed Core scenario. It must not become a DDD completeness finding or a Hexagonal/Clean formalism requirement.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- legitimate internal domain dependencies;
- use of interfaces or abstract contracts;
- infrastructure implementation depending on a domain-facing contract;
- external composition;
- existence of an infrastructure module;
- absence of Bounded Context;
- absence of Aggregate;
- absence of Value Objects;
- absence of Domain Events;
- absence of messaging;
- absence of microservices;
- absence of architecture tests;
- absence of formal Hexagonal Architecture;
- absence of formal Clean Architecture;
- absence of named layers beyond the reviewed responsibilities;
- use of a monolith;
- repository pattern correctness as a separate finding;
- framework leakage;
- global persistence strategy.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `LAYER-002` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed`.

Direct evidence identifies responsibilities, internal dependencies, abstract boundary, external implementation, external composition, and absence of domain-to-infrastructure references. Naming is only supporting context.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No finding is required, so no violation severity is assigned. The scenario risk level remains `Medium` as catalog coverage context, not as finding severity.

## 23. False Positive Guards

Do not report a finding based only on:

- internal domain dependencies;
- collaboration between entities and services;
- use of interfaces;
- existence of an infrastructure module;
- infrastructure depending on a domain-facing contract;
- external composition;
- monolithic deployment;
- absence of microservices;
- absence of formal Hexagonal Architecture;
- absence of formal Clean Architecture;
- absence of tactical DDD completeness.

The expected pass depends on observable responsibility consistency and legitimate dependency direction.

## 24. False Negative Guards

Do not approve automatically based only on:

- folder names;
- class or component names;
- interface names;
- documentation labels;
- use of the word `domain`;
- nominal abstractions with no observable dependency direction;
- diagrams without dependency evidence.

If future fixture material adds a hidden dependency from domain behavior to infrastructure, the evaluator must not preserve the pass merely because the current scenario is compliant.

## 25. Internal Boundary Expectations

`LAYER-002` owns the primary result because the evaluated condition is explicit and consistent responsibility assignment.

Related Layered rules may share evidence but must keep separate responsibilities:

- `LAYER-003` would require a declared dependency direction conclusion;
- `LAYER-006` would require a domain/business rule placement conclusion;
- `LAYER-007` would require a persistence-placement conclusion inside an established layered structure.

No additional Layered finding is required unless the observed result identifies exclusive evidence and avoids restating the `LAYER-002` pass.

## 26. Cross-Catalog Boundary Expectations

### Core x Layered Architecture

Core scenario behavior is validated through the existing `LAYER-002` Rule because no `CORE-*` Rule prefix exists. The Core concern is evidence-driven recognition of legitimate responsibility cohesion. The Layered Rule owns the normative responsibility-consistency condition.

A Layered corrective finding is prohibited when it merely treats internal dependency or simple composition as an architectural violation.

### Core x Domain-Driven Design

DDD rules may provide context for domain language, entity lifecycle, and invariant enforcement. They must not require Bounded Contexts, Aggregates, Value Objects, Domain Events, or tactical DDD completeness as Core findings.

Absence of formal DDD adoption is not a violation.

## 27. Deduplication Expectations

Shared evidence is allowed.

Duplicate conclusions are not allowed.

Findings are forbidden when they only rephrase legitimate responsibility consistency under:

- `DDD-002`;
- `DDD-006`;
- `DDD-012`;
- `DDD-013`;
- `HEX-001`;
- `CLEAN-004`;
- `LAYER-007`.

Separate findings are allowed only when they identify an exclusive architectural condition beyond the provided compliant responsibility and dependency evidence.

## 28. Expected Remediation

No corrective remediation is expected.

Observed output may state that no remediation is required for the Primary Rule. It may suggest preserving current responsibility boundaries, but it must not prescribe new architecture, microservices, DDD tactical patterns, ports and adapters, architecture tests, technology migration, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences in wording;
- equivalent ordering of evidence items;
- equivalent technology-neutral explanation of legitimate dependencies;
- omission of supporting Rule results when they would be decorative;
- supporting Rule variation using existing directly relevant Rules while preserving the Primary Rule and no-finding outcome;
- `Likely` confidence only if observed evidence interpretation explicitly treats some direct evidence as incomplete while preserving `Pass` and no finding.

## 30. Disallowed Variations

Disallowed variations:

- `Fail`;
- `Warning` as the primary result;
- `Not Applicable` for the Primary Rule;
- `Not Enough Evidence` when the provided manifest is fully used;
- any corrective finding;
- severity other than `Not Applicable` for the no-finding Primary result;
- finding based only on naming;
- duplicate finding;
- nonexistent Rule ID;
- Primary Rule changed away from `LAYER-002`;
- requirement for DDD, formal Clean Architecture, formal Hexagonal Architecture, microservices, CI/CD, cloud, or architecture tests.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat the pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/core/EVAL-CORE-002-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `LAYER-002` is evaluated as `Applicable`;
- primary outcome is `Pass`;
- confidence is `Confirmed`;
- severity is `Not Applicable`;
- no corrective finding appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Core x Layered and Core x DDD boundaries are respected;
- duplicate findings are absent;
- remediation is absent or explicitly non-corrective;
- observed result comparison against `evaluation/expected/core/EVAL-CORE-002-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- any corrective finding appears;
- outcome is `Fail`, `Warning`, `Not Applicable`, or `Not Enough Evidence`;
- confidence contradicts the strong evidence;
- severity is assigned despite no finding;
- internal dependencies are treated as prohibited by existence alone;
- a finding relies only on naming;
- a duplicate DDD, Clean, Hexagonal, Architecture Testing, or Layered finding repeats the same conclusion;
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
| Coverage dimensions | `LAYER-002` positive compliance coverage; Core catalog coverage; `Pass`; `Confirmed`; no-finding severity absence; strong evidence; applicability; false-positive protection; false-negative protection; Core x Layered boundary; Core x DDD boundary; internal boundary; deduplication. |
| Primary Rule catalog | `skill/rules/LAYER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/layered/LAYER-002.md` |
| Supporting Rule | `skill/rules/ddd/DDD-002.md` |
| Supporting Rule | `skill/rules/ddd/DDD-006.md` |
| Supporting Rule | `skill/rules/ddd/DDD-012.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Gold Standard review | `evaluation/reviews/EVAL-CORE-001-REVIEW.md` |
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

Initial concrete scenario for `EVAL-CORE-002`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity, selected Primary Rule `LAYER-002`, and expected `Pass` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
