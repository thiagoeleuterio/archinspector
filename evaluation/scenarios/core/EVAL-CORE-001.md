# EVAL-CORE-001 — Domain Logic Coupled to External Infrastructure

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CORE-001` |
| Title | `Domain logic coupled to external infrastructure` |
| Category | `Core` |
| Scenario Type | `Confirmed Violation` |
| Catalogs | `Core`; boundary references to `Hexagonal Architecture` and `Clean Architecture` |
| Primary Rule | `HEX-001` |
| Supporting Rules | `CLEAN-004`, `CLEAN-009`, `LAYER-001`, `LAYER-007`, `SOLID-001` |
| Risk Level | `High` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P0` |
| Gold Standard | `Yes` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `HEX-001`; catalog coverage for Core, Hexagonal Architecture, and Clean Architecture; `Fail` outcome; `Confirmed` confidence; contextual `High` severity; strong evidence; applicability; false-positive guard; false-negative guard; cross-catalog boundary; deduplication; remediation; regression. |

## 2. Purpose

This scenario validates that ArchInspector reports a confirmed architectural violation when order domain logic depends directly on an external infrastructure concern.

The scenario is the Core gold standard for evidence discipline, atomic findings, proportional remediation, false-positive control, false-negative control, cross-catalog boundary behavior, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Confirmed Violation` |
| Secondary Types | `False Negative Guard`, `Cross-Catalog Boundary`, `Regression` |
| Primary Outcome | `Fail` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Confirmed` |
| Severity | `High` |

## 4. Architectural Context

The evaluated system is a fictitious order-processing system.

The reviewed scope contains a domain module for orders. A domain service or entity evaluates business rules such as order acceptance, total validation, and status transition. During that same business operation, the domain component directly references an external persistence client, creates that client, passes connection configuration to it, and writes order state through it.

There is no intermediate abstraction owned by the domain or application core. There is no outbound contract, port, gateway, or equivalent boundary between the domain behavior and the persistence mechanism. The dependency direction points from domain behavior toward infrastructure.

The description is technology-neutral. The scenario does not require any programming language, framework, database product, runtime, or executable fixture.

## 5. Target Catalogs

`Core` owns the scenario category because the scenario validates central ArchInspector behavior: evidence before conclusion, architectural coupling detection, proportional remediation, expected non-findings, boundary handling, and deduplication.

The repository does not define a `CORE-*` Rule prefix. `evaluation/SCENARIO_CATALOG.md` states that Core scenarios target existing Rules whose responsibilities exercise Core review behavior.

`Hexagonal Architecture` is a boundary reference because `HEX-001` is the existing Rule selected by the scenario catalog for this gold scenario.

`Clean Architecture` is a boundary reference because similar evidence may be relevant to use-case or gateway isolation, but Clean rules must not duplicate the Primary Rule finding without Clean-specific evidence.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `HEX-001` |
| Title | `Domain layer must not depend on infrastructure` |
| Category | `Hexagonal Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/HEX-001.md` |
| Catalog File | `skill/rules/HEX_CATALOG.md` |

`HEX-001` is selected because it directly evaluates whether domain code depends on infrastructure. Its fail condition applies when direct evidence shows that domain code depends on infrastructure code, infrastructure abstractions, or infrastructure concerns within the reviewed scope.

The selection follows `evaluation/SCENARIO_CATALOG.md`, which identifies `HEX-001` as the Primary Rule for `EVAL-CORE-001` because no `CORE-*` Rule prefix exists and this Rule directly evaluates the intended domain-to-infrastructure dependency.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `CLEAN-004` | Boundary reference for use case isolation from delivery and infrastructure concerns. |
| `CLEAN-009` | Boundary reference for gateway isolation when use cases interact with external systems. |
| `LAYER-001` | Boundary reference for lower-level details controlling business policy in a layered structure. |
| `LAYER-007` | Boundary reference for persistence responsibility placement in a layered structure. |
| `SOLID-001` | Supporting design reference for high-level policy depending on abstractions. |

Supporting Rules may be used to explain related responsibilities or expected non-findings. They must not duplicate the Primary Rule conclusion unless separate evidence supports an exclusive finding under their own responsibility.

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
- explicit absence of relevant abstractions.

## 9. Directory Structure

```text
order-processing/
  order-domain/
    OrderPolicy
    OrderLifecycle
  infrastructure/
    ExternalPersistenceClient
    PersistenceConnectionSettings
  application/
    SubmitOrderWorkflow
```

The directory names are supporting context only. The required finding must depend on the explicit structural and behavioral evidence below, not on names alone.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `OrderPolicy` | Domain behavior that validates and accepts orders. | Contains business checks and direct persistence interaction. |
| `OrderLifecycle` | Domain state transition behavior. | Calls `OrderPolicy` during order acceptance. |
| `ExternalPersistenceClient` | Infrastructure mechanism for storing order records. | Referenced and instantiated by `OrderPolicy`. |
| `PersistenceConnectionSettings` | External connection configuration. | Read by `OrderPolicy` before creating the client. |
| `SubmitOrderWorkflow` | Application entry into order submission. | Delegates to domain behavior and is not the source of the violation. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `OrderPolicy` | `ExternalPersistenceClient` | Direct reference or import | Domain code directly knows an infrastructure client. |
| `OrderPolicy` | `PersistenceConnectionSettings` | Direct configuration dependency | Domain code knows external connection configuration. |
| `OrderPolicy` | persistence operation | Method behavior | Domain logic executes a store operation during business rule evaluation. |
| `SubmitOrderWorkflow` | `OrderLifecycle` | Delegation | Application flow reaches the domain and does not by itself prove violation. |

No dependency is provided from the domain module to an outbound port, gateway, repository contract, or equivalent abstraction.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Validate order business rules | Domain | Domain |
| Decide whether an order can be accepted | Domain | Domain |
| Persist accepted order state | Infrastructure behind a boundary | Domain |
| Know external connection configuration | Infrastructure or composition boundary | Domain |
| Provide an outbound persistence contract | Core or appropriate boundary layer | Absent |
| Implement external persistence | Infrastructure | Infrastructure component exists, but is directly used by domain |

## 13. Execution Flow

1. `SubmitOrderWorkflow` receives an order submission.
2. `SubmitOrderWorkflow` invokes `OrderLifecycle`.
3. `OrderLifecycle` delegates the acceptance decision to `OrderPolicy`.
4. `OrderPolicy` evaluates business rules.
5. `OrderPolicy` reads external persistence connection settings.
6. `OrderPolicy` creates `ExternalPersistenceClient`.
7. `OrderPolicy` stores the accepted order through the concrete client.

The violation is present at steps 5, 6, and 7 because domain behavior directly depends on and executes an infrastructure mechanism.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is a confirmed violation.

The domain module contains central order business behavior and directly depends on an external infrastructure concern. The dependency is not inferred from directory names. It is shown by explicit reference, instantiation, configuration knowledge, and persistence behavior inside the domain component.

## 16. Evidence Provided

Strong evidence is provided:

- domain scope: `order-domain` contains `OrderPolicy` and `OrderLifecycle`;
- infrastructure concern: `ExternalPersistenceClient` and `PersistenceConnectionSettings`;
- direct reference: `OrderPolicy` references `ExternalPersistenceClient`;
- direct instantiation: `OrderPolicy` creates `ExternalPersistenceClient`;
- persistence behavior: `OrderPolicy` stores accepted order state;
- external configuration knowledge: `OrderPolicy` reads connection settings;
- missing boundary: no outbound port, gateway, contract, or equivalent abstraction is present;
- dependency direction: domain depends on infrastructure.

Short non-compilable pseudocode:

```text
component OrderPolicy
  uses ExternalPersistenceClient
  uses PersistenceConnectionSettings

  decideAndAccept(order)
    verify order total and acceptance rules
    settings = PersistenceConnectionSettings.fromExternalConfiguration
    client = new ExternalPersistenceClient(settings)
    client.store(order)
    mark order accepted
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
- DDD tactical model evidence.

Withheld evidence prevents findings about unrelated architecture styles, tactical modeling, framework leakage, test coverage, runtime behavior, or global persistence strategy.

## 18. Expected Findings

Exactly one finding is required.

```text
Finding ID: EVAL-CORE-001-F001
Rule ID: HEX-001
Title: Domain order logic directly depends on external persistence infrastructure
Outcome: Fail
Confidence: Confirmed
Severity: High
Applicability: Applicable
Evidence: OrderPolicy references ExternalPersistenceClient, creates it using PersistenceConnectionSettings, and stores order state during domain rule execution without a port, gateway, or contract.
Architectural Impact: Central order domain behavior is coupled to an external infrastructure concern and cannot be reasoned about independently from that persistence mechanism.
Rationale: Direct reference, instantiation, configuration knowledge, and persistence behavior inside the domain satisfy the fail condition for HEX-001.
Remediation: Remove the direct infrastructure dependency from domain logic, define an abstraction owned by the core or appropriate boundary layer, move the external persistence implementation outside the domain, and invert the dependency direction.
Related Rules: CLEAN-004, CLEAN-009, LAYER-001, LAYER-007, SOLID-001
Boundary Notes: The finding concludes only that domain logic directly depends on external infrastructure. It must not duplicate separate Clean, Layered, DDD, repository, framework, testing, or persistence-strategy conclusions.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- absence of Bounded Context;
- absence of Aggregate;
- absence of Value Object;
- absence of Domain Event;
- absence of messaging;
- absence of formal Hexagonal Architecture;
- absence of formal Clean Architecture;
- absence of named layers;
- absence of architecture tests;
- use of Transaction Script;
- use of Active Record;
- absence of microservices;
- absence of CI/CD;
- absence of cloud;
- framework leakage;
- global persistence strategy;
- repository pattern correctness;
- testability as a separate required finding.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `HEX-001` | `Applicable` | `Fail` | `Match` |
| Scenario | `Applicable` | `Fail` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed`.

Direct evidence identifies the domain scope, the infrastructure concern, the dependency direction, the direct instantiation, the persistence operation, and the absence of an intermediate abstraction. Naming is only supporting context.

## 22. Expected Severity

Expected severity is `High`.

The coupling affects central order domain behavior and a stable architectural boundary. The domain behavior both decides business state and performs external persistence through a concrete infrastructure mechanism.

`Medium` is acceptable only if an observed result explicitly justifies reduced impact while preserving `Applicable`, `Fail`, `Confirmed`, and the required finding.

## 23. False Positive Guards

Do not report a finding based only on:

- directory name;
- class or component name;
- existence of an infrastructure package;
- legitimate use of an abstraction;
- infrastructure implementation depending on domain contracts;
- documentation without implementation evidence;
- configuration located outside the domain;
- the mere presence of persistence concepts.

The required failure depends on the observable direct reference from domain behavior to infrastructure.

## 24. False Negative Guards

Do not miss the required finding because:

- persistence is treated as an irrelevant detail;
- direct instantiation is accepted as convenience;
- external configuration knowledge inside domain is ignored;
- the dependency is considered legitimate because it runs in one process;
- the system has only one adapter;
- the system is described as a monolith;
- directory names suggest a clean domain module;
- no formal architecture style is claimed.

## 25. Internal Boundary Expectations

`HEX-001` owns the primary finding because the violation is domain code depending on infrastructure.

Related Hexagonal rules may share evidence but must keep separate responsibilities:

- `HEX-004` would require a conclusion about application core outbound ports for external systems;
- `HEX-007` would require a broader core-to-adapter dependency direction conclusion;
- `HEX-009` would require a persistence-specific outbound-port conclusion;
- `HEX-012` would require evidence about evaluating core behavior without adapters.

No additional Hexagonal finding is required unless the observed result identifies exclusive evidence and avoids restating the `HEX-001` conclusion.

## 26. Cross-Catalog Boundary Expectations

### Core × Hexagonal Architecture

Core scenario behavior is validated through the existing `HEX-001` Rule because no `CORE-*` Rule prefix exists. The Core concern is evidence-driven detection of central architectural coupling. The Hexagonal Rule owns the normative architectural condition.

A Hexagonal supporting finding is prohibited when it merely repeats that domain logic depends directly on infrastructure. A separate Hexagonal finding is allowed only if it reaches an exclusive ports-and-adapters conclusion using distinct reasoning.

### Core × Clean Architecture

Clean rules may be referenced for boundary discipline around use cases, gateways, and dependency direction. They must not produce a duplicate finding unless the observed evidence separately establishes a Clean-specific conclusion, such as a use case boundary shaped by infrastructure or a gateway boundary failure.

Absence of formal Clean Architecture adoption is not a violation.

## 27. Deduplication Expectations

Shared evidence is allowed.

Duplicate conclusions are not allowed.

The required finding belongs to `HEX-001`. Findings are forbidden when they only rephrase the same conclusion under:

- `CLEAN-004`;
- `CLEAN-009`;
- `LAYER-001`;
- `LAYER-007`;
- `SOLID-001`;
- `HEX-004`;
- `HEX-007`;
- `HEX-009`;
- `HEX-012`.

Separate findings are allowed only when they identify an exclusive architectural condition beyond direct domain-to-infrastructure dependency.

## 28. Expected Remediation

Expected remediation must be proportional and technology-neutral:

- remove direct infrastructure reference from domain logic;
- define an abstraction owned by the core or appropriate boundary layer;
- move the external persistence implementation outside the domain;
- make infrastructure depend on the abstraction rather than the domain depending on infrastructure;
- keep business rules independent from external persistence configuration and client lifecycle.

The remediation must not require microservices, event sourcing, CQRS, cloud, containers, a specific framework, a specific storage technology, a new full architecture, or a total rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences in wording;
- equivalent ordering of evidence items;
- equivalent technology-neutral remediation wording;
- `Medium` severity only when reduced contextual impact is explicit and justified;
- different supporting Rules if they exist and preserve boundary ownership;
- no supporting finding when it would duplicate the Primary Rule conclusion.

## 30. Disallowed Variations

Disallowed variations:

- `Pass`;
- `Warning` as the only primary result;
- `Not Applicable`;
- `Not Enough Evidence`;
- confidence below `Confirmed`;
- finding based only on naming;
- generic finding title;
- duplicate finding;
- merged finding that adds unrelated conclusions;
- prescriptive remediation;
- nonexistent Rule ID;
- external Rule replacing `HEX-001` as the catalog-defined Primary Rule;
- finding requiring DDD, formal Clean Architecture, formal Hexagonal Architecture, microservices, CI/CD, cloud, or architecture tests.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat the pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `HEX-001` is evaluated as `Applicable`;
- primary outcome is `Fail`;
- confidence is `Confirmed`;
- severity is `High` unless explicitly reduced to justified `Medium`;
- exactly one required finding appears for direct domain-to-infrastructure dependency;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Core x Hexagonal and Core x Clean boundaries are respected;
- duplicate findings are absent;
- remediation is proportional and technology-neutral;
- observed result comparison against `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- the required finding is missing;
- outcome is `Pass`, `Warning` only, `Not Applicable`, or `Not Enough Evidence`;
- confidence is below `Confirmed`;
- severity contradicts the central boundary impact;
- the finding is generic or unsupported;
- the finding relies only on naming;
- a duplicate Clean, Layered, SOLID, or neighboring Hexagonal finding repeats the same conclusion;
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
| Coverage dimensions | `HEX-001` violation coverage; Core catalog gold standard coverage; `Fail`; `Confirmed`; `High`; strong evidence; applicability; false-positive protection; false-negative protection; Core x Hexagonal boundary; Core x Clean boundary; deduplication; remediation; regression. |
| Primary Rule catalog | `skill/rules/HEX_CATALOG.md` |
| Primary Rule normative file | `skill/rules/HEX-001.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-004.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-009.md` |
| Supporting Rule | `skill/rules/layered/LAYER-001.md` |
| Supporting Rule | `skill/rules/layered/LAYER-007.md` |
| Supporting Rule | `skill/rules/solid/SOLID-001.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
| Stabilization | `evaluation/stabilizations/EVAL-CORE-001-STABILIZATION.md` |

## 35. Gold Standard Requirements

This scenario is the gold standard reference for future scenarios in:

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

Initial concrete scenario for `EVAL-CORE-001`.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
