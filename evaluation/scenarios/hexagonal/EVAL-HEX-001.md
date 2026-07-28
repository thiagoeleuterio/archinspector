# EVAL-HEX-001 - Core Depends Directly on a Database Adapter

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-HEX-001` |
| Title | `Core depends directly on a database adapter` |
| Category | `Hexagonal Architecture` |
| Scenario Type | `Confirmed Violation` |
| Catalogs | `Hexagonal Architecture`; boundary references to `Core`, `Clean Architecture`, and `Layered Architecture` |
| Primary Rule | `HEX-009` |
| Supporting Rules | `HEX-004`, `HEX-007`, `CLEAN-009` |
| Risk Level | `High` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P0` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/hexagonal/EVAL-HEX-001-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `HEX-009`; catalog coverage for Hexagonal Architecture; `Fail` outcome; `Confirmed` confidence; contextual `High` severity; strong evidence; applicability; false-positive guard; false-negative guard; Hexagonal x Core boundary; Hexagonal x Clean boundary; Hexagonal x Layered boundary; deduplication; remediation. |

## 2. Purpose

This scenario validates that ArchInspector reports a confirmed Hexagonal Architecture violation when the application core depends directly on an external database adapter instead of an application-owned outbound port.

The scenario protects dependency-direction analysis, port versus adapter distinction, inside versus outside distinction, atomic finding behavior, proportional remediation, false-positive control, false-negative control, cross-catalog boundaries, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Confirmed Violation` |
| Secondary Types | `False Negative Guard`, `Cross-Catalog Boundary` |
| Primary Outcome | `Fail` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Confirmed` |
| Severity | `High` |

## 4. Architectural Context

The evaluated system is a fictitious order-processing system.

The reviewed scope contains an application core with an order submission use case and order policy behavior. The core directly references a concrete database adapter, creates it during the use case flow, passes adapter configuration into it, and calls it to store an order. No outbound port, gateway contract, or equivalent application-owned abstraction exists between the core behavior and the database adapter.

The database adapter is an outside component. The application core is inside. The dependency direction points from inside to outside, and composition is performed inside the core instead of at an external composition boundary. The violation is structural and behavioral; it is not inferred from component names alone.

The description is technology-neutral. The scenario does not require any programming language, framework, database product, runtime, ORM, container, or executable fixture.

## 5. Target Catalogs

`Hexagonal Architecture` owns the scenario category because the evaluated condition is whether persistence concerns remain behind outbound ports and whether the core avoids depending on database adapter details.

`Core` is a boundary reference because the scenario also validates central ArchInspector behavior: evidence before conclusion, atomic findings, and no duplicated Core findings. The repository has no `CORE-*` Rule prefix.

`Clean Architecture` is a boundary reference because gateway and use case isolation may share evidence, but Clean findings must not duplicate the Hexagonal conclusion without Clean-specific evidence.

`Layered Architecture` is a boundary reference because direct database access may resemble persistence-placement leakage, but Layered findings require an established layered structure and an exclusive layered conclusion.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `HEX-009` |
| Title | `Persistence concerns must remain behind outbound ports` |
| Category | `Hexagonal Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/HEX-009.md` |
| Catalog File | `skill/rules/HEX_CATALOG.md` |

`HEX-009` is selected because it is the most specific existing Hexagonal Rule for a core persistence interaction that bypasses an outbound port and depends directly on a concrete database adapter. Its fail condition applies when domain or application core behavior depends on concrete persistence adapters or storage concerns instead of outbound ports.

`HEX-004` and `HEX-007` are directly related, but `HEX-009` owns the persistence-specific conclusion and prevents the finding from becoming a generic dependency-direction or generic outbound-port finding.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `HEX-004` | Boundary reference for the broader outbound-port requirement. |
| `HEX-007` | Boundary reference for dependency direction from adapters toward the core. |
| `CLEAN-009` | Cross-catalog boundary reference for Clean gateway isolation without duplicating the Hexagonal finding. |

Supporting Rules may be used to explain shared evidence, expected non-findings, and forbidden duplicate findings. They must not replace `HEX-009` as Primary Rule and must not produce decorative or duplicative findings.

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
- explicit absence of an outbound port.

## 9. Directory Structure

```text
order-processing/
  application-core/
    SubmitOrderUseCase
    OrderAcceptancePolicy
  adapters/
    database/
      OrderDatabaseAdapter
      DatabaseConnectionSettings
  composition/
    RuntimeBootstrap
```

The directory names are supporting context only. The required finding must depend on explicit structural and behavioral evidence, not on names alone.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `SubmitOrderUseCase` | Application core use case. | Directly creates and calls `OrderDatabaseAdapter`. |
| `OrderAcceptancePolicy` | Core order decision behavior. | Evaluates order acceptance and delegates persistence request to the use case. |
| `OrderDatabaseAdapter` | Outside persistence adapter. | Concrete adapter known by the core. |
| `DatabaseConnectionSettings` | External storage configuration. | Passed by the core into the adapter constructor. |
| `RuntimeBootstrap` | External composition location. | Exists but does not perform adapter composition for this dependency. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `SubmitOrderUseCase` | `OrderDatabaseAdapter` | Direct reference or import | Inside code knows a concrete outside adapter. |
| `SubmitOrderUseCase` | `OrderDatabaseAdapter` | Direct instantiation | Composition happens inside the core. |
| `SubmitOrderUseCase` | `DatabaseConnectionSettings` | Configuration dependency | Core knows external storage configuration. |
| `SubmitOrderUseCase` | storage operation | Method behavior | Core writes accepted order state through a concrete adapter. |

No dependency is provided from the core to an outbound port, gateway interface, repository contract, or equivalent application-owned abstraction.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Decide whether an order can be submitted | Application core | `OrderAcceptancePolicy` |
| Coordinate order submission | Application core | `SubmitOrderUseCase` |
| Define persistence need as outbound port | Application core | Absent |
| Implement database persistence | Outside adapter | `OrderDatabaseAdapter` |
| Know database connection settings | Outside adapter or composition boundary | `SubmitOrderUseCase` |
| Compose concrete adapter | External composition boundary | `SubmitOrderUseCase` |

## 13. Execution Flow

1. `SubmitOrderUseCase` receives an order command.
2. `SubmitOrderUseCase` invokes `OrderAcceptancePolicy`.
3. `OrderAcceptancePolicy` confirms the order may be submitted.
4. `SubmitOrderUseCase` reads `DatabaseConnectionSettings`.
5. `SubmitOrderUseCase` creates `OrderDatabaseAdapter`.
6. `SubmitOrderUseCase` calls the concrete adapter to store the order.

The violation is present at steps 4, 5, and 6 because application core behavior directly depends on persistence adapter details instead of an outbound port.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or hidden architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is a confirmed violation.

The application core directly depends on a concrete external database adapter. The dependency is shown through direct reference, direct instantiation, configuration knowledge, storage behavior, absence of an outbound port, and composition inside the core.

## 16. Evidence Provided

Strong evidence is provided:

- core scope: `application-core` contains `SubmitOrderUseCase` and `OrderAcceptancePolicy`;
- adapter scope: `adapters/database` contains `OrderDatabaseAdapter`;
- direct reference: `SubmitOrderUseCase` references `OrderDatabaseAdapter`;
- direct instantiation: `SubmitOrderUseCase` creates `OrderDatabaseAdapter`;
- absence of port: no outbound port, gateway contract, repository contract, or equivalent abstraction is present;
- incorrect direction: inside depends on outside;
- inappropriate composition: the concrete adapter is wired inside core behavior;
- external responsibility in inside: database connection settings are known by the use case.

Short non-compilable pseudocode:

```text
component SubmitOrderUseCase
  uses OrderAcceptancePolicy
  uses OrderDatabaseAdapter
  uses DatabaseConnectionSettings

  submit(order)
    OrderAcceptancePolicy.verify(order)
    settings = DatabaseConnectionSettings.fromExternalConfiguration
    adapter = new OrderDatabaseAdapter(settings)
    adapter.store(order)
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
- claims of formal Layered Architecture adoption;
- DDD tactical model evidence;
- messaging evidence.

Withheld evidence prevents findings about unrelated architecture styles, repository pattern correctness, framework leakage, architecture tests, runtime behavior, microservices, or global persistence strategy.

## 18. Expected Findings

Exactly one corrective finding is required.

```text
Finding ID: EVAL-HEX-001-F001
Rule ID: HEX-009
Title: Application core directly depends on an external database adapter
Outcome: Fail
Confidence: Confirmed
Severity: High
Applicability: Applicable
Evidence: SubmitOrderUseCase references OrderDatabaseAdapter, creates it with DatabaseConnectionSettings, and stores order state through the concrete adapter without an outbound port.
Architectural Impact: The application core is coupled to a concrete persistence mechanism and the dependency direction points from inside to outside.
Rationale: Direct reference, instantiation, adapter configuration knowledge, persistence behavior, and absence of an outbound port satisfy the fail condition for HEX-009.
Remediation: Define an outbound port owned by the application core, make the core depend on that port, move the concrete database implementation outside the core, perform composition externally, and invert dependency direction.
Related Rules: HEX-004, HEX-007, CLEAN-009
Boundary Notes: The finding concludes only that the application core directly depends on an external database adapter instead of an application-owned outbound port.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- absence of inbound port;
- absence of multiple adapters;
- absence of DDD;
- absence of Bounded Context;
- absence of Clean Architecture formalism;
- absence of named layers;
- absence of architecture tests;
- use of a monolith;
- database product choice;
- absence of microservices;
- absence of messaging;
- absence of Repository Pattern by name;
- global testability as a separate finding;
- generic Core violation separate from the primary finding;
- generic Clean violation separate from exclusive Clean evidence;
- generic Layered bypass separate from exclusive Layered evidence.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `HEX-009` | `Applicable` | `Fail` | `Match` |
| Scenario | `Applicable` | `Fail` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed`.

Direct evidence identifies the core, the database adapter, the direct reference, the direct instantiation, the storage operation, the missing outbound port, and the dependency direction. Naming is supporting context only.

## 22. Expected Severity

Expected severity is `High`.

The coupling affects a central order submission use case and a stable persistence boundary. `Medium` is acceptable only if an observed result explicitly justifies reduced impact while preserving `Applicable`, `Fail`, `Confirmed`, and the required finding.

## 23. False Positive Guards

Do not report a finding when:

- an adapter depends on a core-owned port;
- an external implementation depends on the core contract;
- composition occurs outside the inside boundary;
- an external factory instantiates the adapter;
- the core knows only its own contract;
- there is only one adapter;
- the system is monolithic;
- the application does not use the words `port` or `adapter`.

The required failure depends on observable direct core dependency on a concrete database adapter.

## 24. False Negative Guards

Do not miss the required finding because:

- the concrete adapter is in the same project;
- the concrete adapter is in the same process;
- there is only one database;
- the concrete class implements an external interface;
- the dependency was created for convenience;
- the system is small;
- the architecture does not claim Hexagonal Architecture;
- the adapter has a generic name.

## 25. Internal Boundary Expectations

`HEX-009` owns the primary finding because the evaluated concern is persistence-specific leakage behind outbound ports.

Related Hexagonal rules may share evidence but must keep separate responsibilities:

- `HEX-004` covers the broader outbound-port requirement;
- `HEX-007` covers general dependency direction between core and adapters;
- `HEX-005` would require adapter implementation of a port, but no port is present;
- `HEX-012` would require a distinct conclusion about evaluating core behavior without adapters.

No additional Hexagonal finding is required unless the observed result identifies exclusive evidence and avoids restating the `HEX-009` conclusion.

## 26. Cross-Catalog Boundary Expectations

### Hexagonal x Core

Hexagonal evaluates inside/outside, ports, adapters, persistence isolation, and dependency direction. Core review behavior contributes evidence discipline and atomic reporting. Shared evidence is permitted, but the same conclusion must not produce both a Hexagonal finding and a generic Core finding.

Absence of formal Hexagonal Architecture does not automatically constitute a Core violation.

### Hexagonal x Clean

Hexagonal evaluates interaction with database adapters through outbound ports. Clean Architecture evaluates use case and gateway boundaries under the policy-detail framing. A Clean finding is forbidden when it merely repeats that the core depends on a database adapter.

Clean analysis is allowed only when exclusive evidence shows a Clean-specific use case or gateway boundary conclusion. Absence of formal Clean Architecture does not constitute a Hexagonal violation.

### Hexagonal x Layered

Hexagonal evaluates ports, adapters, and inside/outside dependency direction. Layered Architecture evaluates dependencies, persistence placement, and bypassing inside an established layered structure.

The same direct database access must not be described twice with the same conclusion. A Layered finding is allowed only when a declared layered structure and exclusive bypass or persistence-placement evidence are present.

## 27. Deduplication Expectations

| Shared Evidence | Hexagonal Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Core references `OrderDatabaseAdapter` | Core depends on database adapter instead of outbound port under `HEX-009` | Clean gateway or Layered persistence concern may be suspected | Yes | Emit one `HEX-009` finding unless exclusive neighboring evidence exists. |
| Core creates adapter | Composition inside core supports `HEX-009` failure | Generic dependency-direction finding may be suspected | Yes | Use as evidence for the primary finding, not a second finding. |
| No outbound port exists | Persistence not behind outbound port | Clean gateway absence may be suspected | Yes | Do not duplicate as Clean unless use case gateway evidence is distinct. |
| Database settings in core | Persistence concern shapes core | Layered persistence leakage may be suspected | Yes | No Layered finding without established layered structure. |

## 28. Expected Remediation

Expected remediation must be proportional and technology-neutral:

- define an outbound port owned by the application core;
- make the core depend on the port;
- move the concrete database implementation outside the core;
- perform composition outside the inside boundary;
- invert dependency direction so the adapter conforms to the core-owned port.

The remediation must not require microservices, DDD, Repository Pattern by name, a framework, ORM, container, cloud, or a total rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences in wording;
- equivalent ordering of evidence items;
- equivalent neutral component names;
- equivalent technology-neutral remediation wording;
- `Medium` severity only with explicit reduced-impact justification;
- alternative existing directly related Supporting Rules within the maximum of three;
- no supporting finding when it would duplicate the Primary Rule conclusion.

## 30. Disallowed Variations

Disallowed variations:

- nonexistent Rule ID;
- non-Hexagonal Primary Rule;
- conclusion based only on naming;
- `Pass`;
- `Warning` as the only primary result;
- confidence below `Confirmed`;
- missing required finding;
- duplicate finding;
- generic Core, Clean, or Layered finding with the same conclusion;
- remediation requiring DDD, microservices, framework, ORM, cloud, or rewrite;
- universal requirement for ports in every system;
- universal requirement for multiple adapters.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat the pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/hexagonal/EVAL-HEX-001-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `HEX-009` is evaluated as `Applicable`;
- primary outcome is `Fail`;
- confidence is `Confirmed`;
- severity is `High` unless explicitly reduced to justified `Medium`;
- exactly one required finding appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Hexagonal x Core, Hexagonal x Clean, and Hexagonal x Layered boundaries are respected;
- duplicate findings are absent;
- remediation is proportional and technology-neutral;
- observed result comparison against `evaluation/expected/hexagonal/EVAL-HEX-001-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- the required finding is missing;
- outcome is `Pass`, `Warning` only, `Not Applicable`, or `Not Enough Evidence`;
- confidence is below `Confirmed`;
- severity contradicts the central boundary impact;
- the finding is generic or unsupported;
- the finding relies only on naming;
- a duplicate Core, Clean, Layered, or neighboring Hexagonal finding repeats the same conclusion;
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
| Coverage dimensions | `HEX-009` violation coverage; Hexagonal catalog coverage; `Fail`; `Confirmed`; `High`; strong evidence; applicability; false-positive protection; false-negative protection; Hexagonal x Core boundary; Hexagonal x Clean boundary; Hexagonal x Layered boundary; deduplication; remediation. |
| Primary Rule catalog | `skill/rules/HEX_CATALOG.md` |
| Primary Rule normative file | `skill/rules/HEX-009.md` |
| Supporting Rule | `skill/rules/HEX-004.md` |
| Supporting Rule | `skill/rules/HEX-007.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-009.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
| Layered boundary review | `skill/reviews/LAYER_CATALOG_REVIEW.md` |
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

Initial concrete scenario for `EVAL-HEX-001`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity, selected Primary Rule `HEX-009`, and expected `Fail` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
