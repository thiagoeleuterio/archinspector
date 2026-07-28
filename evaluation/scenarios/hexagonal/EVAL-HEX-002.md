# EVAL-HEX-002 - Multiple Adapters Implement the Same Application Port

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-HEX-002` |
| Title | `Multiple adapters implement the same application port` |
| Category | `Hexagonal Architecture` |
| Scenario Type | `Positive Compliance` |
| Catalogs | `Hexagonal Architecture`; boundary references to `Core` and `Clean Architecture` |
| Primary Rule | `HEX-005` |
| Supporting Rules | `HEX-004`, `HEX-006`, `HEX-007` |
| Risk Level | `Medium` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/hexagonal/EVAL-HEX-002-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `HEX-005`; catalog coverage for Hexagonal Architecture; `Pass` outcome; `Confirmed` confidence; no-finding severity absence; strong evidence; applicability; false-positive guard; false-negative guard; internal Hexagonal boundary; Hexagonal x Core boundary; Hexagonal x Clean boundary; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector recognizes multiple outside adapters implementing the same application-owned outbound port as compliant Hexagonal Architecture behavior.

The scenario protects positive compliance, port versus adapter distinction, adapter substitutability, correct dependency direction, false-positive control, false-negative control, boundary behavior, and deduplication.

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

The reviewed scope contains an application core that defines an outbound port for order storage. Two outside adapters satisfy the same port: one persistent adapter and one temporary in-memory adapter. The core depends only on the port. Both adapters depend on the core-owned port. Composition occurs outside the core, and no concrete adapter is instantiated by core behavior.

No external framework type, storage model, database API, adapter DTO, or adapter configuration crosses the core boundary. The two implementations are substitutable because they satisfy the same application-owned contract.

The description is technology-neutral. The scenario does not require any programming language, framework, database product, runtime, ORM, container, or executable fixture.

## 5. Target Catalogs

`Hexagonal Architecture` owns the scenario category because the evaluated condition is whether outbound adapters implement or satisfy outbound ports outside the core.

`Core` is a boundary reference because the scenario validates central no-finding behavior and evidence discipline.

`Clean Architecture` is a boundary reference because gateway isolation may be analogous, but Clean findings must not be produced merely because multiple adapters exist.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `HEX-005` |
| Title | `Outbound adapters must implement outbound ports` |
| Category | `Hexagonal Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/HEX-005.md` |
| Catalog File | `skill/rules/HEX_CATALOG.md` |

`HEX-005` is selected because it directly evaluates whether outbound adapters implement or satisfy outbound ports while remaining outside the application core. The scenario is specifically about two adapters satisfying the same port, so `HEX-005` is more precise than the broader outbound-port or dependency-direction rules.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `HEX-004` | Boundary reference for the core depending on the outbound port. |
| `HEX-006` | Boundary reference for the port being owned and shaped by the application core. |
| `HEX-007` | Boundary reference for dependency direction from adapters toward the core. |

Supporting Rules may be used to explain related compliant evidence and expected non-findings. They must not duplicate the Primary Rule result or require a single adapter implementation.

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
- explicit absence of core-to-adapter instantiation.

## 9. Directory Structure

```text
order-processing/
  application-core/
    SubmitOrderUseCase
    OrderStorePort
  adapters/
    persistent/
      PersistentOrderStoreAdapter
    temporary/
      InMemoryOrderStoreAdapter
  composition/
    RuntimeBootstrap
```

The directory names are supporting context only. The expected pass must depend on explicit structural and behavioral evidence, not on names alone.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `SubmitOrderUseCase` | Application core use case. | Depends only on `OrderStorePort`. |
| `OrderStorePort` | Core-owned outbound port. | Defines storage need in application terms. |
| `PersistentOrderStoreAdapter` | Outside persistent adapter. | Satisfies `OrderStorePort`. |
| `InMemoryOrderStoreAdapter` | Outside temporary adapter. | Satisfies `OrderStorePort`. |
| `RuntimeBootstrap` | External composition boundary. | Selects either adapter outside the core. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `SubmitOrderUseCase` | `OrderStorePort` | Constructor dependency | Core depends on an application-owned port. |
| `PersistentOrderStoreAdapter` | `OrderStorePort` | Implementation dependency | Outside adapter conforms to core contract. |
| `InMemoryOrderStoreAdapter` | `OrderStorePort` | Implementation dependency | Second outside adapter conforms to same contract. |
| `RuntimeBootstrap` | adapter choice | Composition dependency | Concrete selection occurs outside core. |

No dependency is provided from `SubmitOrderUseCase` to either concrete adapter, storage configuration, framework API, or external storage model.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Submit order application behavior | Application core | `SubmitOrderUseCase` |
| Define order storage need | Application core | `OrderStorePort` |
| Store orders persistently | Outside adapter | `PersistentOrderStoreAdapter` |
| Store orders temporarily | Outside adapter | `InMemoryOrderStoreAdapter` |
| Compose concrete implementation | External composition boundary | `RuntimeBootstrap` |
| Know adapter-specific storage details | Outside adapter | Each adapter only |

## 13. Execution Flow

1. `RuntimeBootstrap` selects an implementation of `OrderStorePort`.
2. `SubmitOrderUseCase` receives an `OrderStorePort` dependency.
3. `SubmitOrderUseCase` validates and submits an order.
4. `SubmitOrderUseCase` calls `OrderStorePort.save`.
5. Either `PersistentOrderStoreAdapter` or `InMemoryOrderStoreAdapter` performs storage outside the core.

The pass condition is present because the core depends on the port, adapters implement the port, and composition is external.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or hidden architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is positive compliance.

The core owns the outbound port and depends only on that port. Multiple outside adapters satisfy the same contract. Adapter multiplicity is an intended substitutability signal, not duplication or violation.

## 16. Evidence Provided

Strong evidence is provided:

- core scope: `application-core` contains `SubmitOrderUseCase` and `OrderStorePort`;
- outbound port: `OrderStorePort` is owned by the core;
- two outside adapters: `PersistentOrderStoreAdapter` and `InMemoryOrderStoreAdapter`;
- both adapters satisfy the same port;
- one adapter represents persistent storage;
- one adapter represents temporary or in-memory storage;
- core depends only on the port;
- composition occurs externally;
- no adapter is instantiated inside core behavior;
- no external technology type crosses the port.

Short non-compilable pseudocode:

```text
component SubmitOrderUseCase
  constructor(store: OrderStorePort)

  submit(order)
    validate order
    store.save(order)

component PersistentOrderStoreAdapter satisfies OrderStorePort
component InMemoryOrderStoreAdapter satisfies OrderStorePort
component RuntimeBootstrap wires OrderStorePort to selected adapter
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
- claims of formal Hexagonal Architecture adoption;
- claims of formal Clean Architecture adoption;
- DDD tactical model evidence;
- microservice deployment topology.

Withheld evidence prevents findings about framework leakage, database choice, DDD completeness, architecture testing, runtime behavior, or formal architecture adoption.

## 18. Expected Findings

No corrective finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: HEX-005
Outcome: Pass
Confidence: Confirmed
Severity: Not Applicable
Applicability: Applicable
Evidence: PersistentOrderStoreAdapter and InMemoryOrderStoreAdapter both satisfy the core-owned OrderStorePort outside the application core, while SubmitOrderUseCase depends only on OrderStorePort and composition occurs externally.
Architectural Impact: No corrective impact is present because the adapters remain substitutable implementations of the same application port.
Rationale: HEX-005 pass conditions are satisfied by direct evidence that outbound adapters implement or satisfy the outbound port outside the core.
Remediation: None.
Related Rules: HEX-004, HEX-006, HEX-007
Boundary Notes: The result concludes only that multiple adapters correctly satisfy the same core-owned port. It must not become a requirement for multiple adapters in every system.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- multiple adapters;
- two implementations of the same port;
- in-memory implementation;
- persistent implementation;
- external composition;
- use of an interface in the core;
- absence of microservices;
- absence of DDD;
- absence of Clean Architecture formalism;
- absence of separate deployable modules;
- monolithic application structure;
- adapter of test or temporary character;
- difference of technology between adapters.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `HEX-005` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed`.

Direct evidence identifies the outbound port, two outside adapters, implementation relationships, external composition, absence of core-to-adapter dependency, and absence of external types crossing the port.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No corrective finding is expected, so violation severity must not be assigned. The scenario risk level remains `Medium` as catalog coverage context, not as finding severity.

## 23. False Positive Guards

Do not report a finding based on:

- multiple implementations;
- presence of a test or temporary adapter;
- presence of an in-memory adapter;
- different adapter technologies;
- adapters depending on the internal contract;
- external composition;
- different adapter names;
- a monolithic deployment shape.

Multiple adapters are legitimate when they satisfy a core-owned port.

## 24. False Negative Guards

Do not produce `Pass Confirmed` based only on:

- nominal interface existence;
- classes declaring implementation without evidence;
- diagram boxes;
- names containing `Port` or `Adapter`;
- documentation claims;
- multiple classes without a common contract;
- hidden core dependency on a concrete adapter.

If future observed material shows core-to-concrete-adapter dependency, the pass must not be preserved.

## 25. Internal Boundary Expectations

`HEX-005` owns the primary result because the evaluated concern is outbound adapters satisfying outbound ports.

Related Hexagonal rules may share evidence but must keep separate responsibilities:

- `HEX-004` covers core use of outbound ports;
- `HEX-006` covers core ownership and shape of ports;
- `HEX-007` covers general dependency direction;
- `HEX-012` would cover evaluating core behavior without adapters.

No corrective finding is required for any related Hexagonal Rule.

## 26. Cross-Catalog Boundary Expectations

### Hexagonal x Core

Hexagonal owns the port-adapter compliance result. Core review behavior validates evidence discipline and no-finding proportionality. Shared evidence is permitted, but no generic Core finding or approval should exceed the reviewed scope.

### Hexagonal x Clean

Clean Architecture may describe similar behavior as gateway isolation, but no Clean finding is required. The result must not require formal Clean Architecture or use Clean gateway language to duplicate the Hexagonal no-finding result.

### Hexagonal x Layered

Layered Architecture is not a boundary catalog for this scenario. The presence of persistent and in-memory adapters must not trigger Layered findings without an established layered structure and exclusive layer responsibility evidence.

## 27. Deduplication Expectations

| Shared Evidence | Hexagonal Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Two adapters satisfy `OrderStorePort` | `HEX-005` pass | Clean gateway compliance may be suspected | Yes | Report no corrective finding. |
| Core depends on `OrderStorePort` | Supports adapter-port compliance | Generic dependency-direction compliance may be suspected | Yes | Use as supporting evidence only. |
| External composition | Supports correct boundary | Core or Clean positive claim may be suspected | Yes | Do not broaden result beyond reviewed scope. |
| In-memory adapter exists | Legitimate substitutable adapter | Test/dummy adapter risk may be suspected | Yes | Do not report as duplicate or violation. |

## 28. Expected Remediation

No corrective remediation is expected.

Observed output may state that no remediation is required for the Primary Rule. It may recommend preserving the core-owned port, external adapter implementations, and external composition, but it must not prescribe a single implementation, microservices, DDD, a framework, ORM, cloud, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences in wording;
- equivalent ordering of evidence items;
- equivalent neutral component names;
- omission of supporting Rule results when they would be decorative;
- supporting Rule variation using existing directly relevant Rules while preserving Primary Rule and no-finding outcome.

## 30. Disallowed Variations

Disallowed variations:

- `Fail`;
- `Warning` as the primary result;
- `Not Applicable` for the Primary Rule;
- `Not Enough Evidence` when the provided manifest is fully used;
- any corrective finding;
- severity other than `Not Applicable`;
- finding based only on naming;
- duplicate finding;
- nonexistent Rule ID;
- Primary Rule changed away from `HEX-005`;
- requirement for a single implementation;
- requirement for DDD, formal Clean Architecture, microservices, CI/CD, cloud, or architecture tests.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat the pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/hexagonal/EVAL-HEX-002-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `HEX-005` is evaluated as `Applicable`;
- primary outcome is `Pass`;
- confidence is `Confirmed`;
- severity is `Not Applicable`;
- no corrective finding appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Hexagonal x Core and Hexagonal x Clean boundaries are respected;
- duplicate findings are absent;
- remediation is absent or explicitly non-corrective;
- observed result comparison against `evaluation/expected/hexagonal/EVAL-HEX-002-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- any corrective finding appears;
- outcome is `Fail`, `Warning`, `Not Applicable`, or unsupported `Not Enough Evidence`;
- confidence contradicts the strong evidence;
- severity is assigned despite no finding;
- multiple adapters are treated as prohibited by existence alone;
- a finding relies only on naming;
- duplicate findings repeat the same conclusion;
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
| Coverage dimensions | `HEX-005` positive compliance coverage; Hexagonal catalog coverage; `Pass`; `Confirmed`; no-finding severity absence; strong evidence; applicability; false-positive protection; false-negative protection; internal Hexagonal boundary; Hexagonal x Core boundary; Hexagonal x Clean boundary; deduplication. |
| Primary Rule catalog | `skill/rules/HEX_CATALOG.md` |
| Primary Rule normative file | `skill/rules/HEX-005.md` |
| Supporting Rule | `skill/rules/HEX-004.md` |
| Supporting Rule | `skill/rules/HEX-006.md` |
| Supporting Rule | `skill/rules/HEX-007.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
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

Initial concrete scenario for `EVAL-HEX-002`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity, selected Primary Rule `HEX-005`, and expected `Pass` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
