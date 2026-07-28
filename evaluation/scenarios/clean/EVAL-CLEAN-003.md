# EVAL-CLEAN-003 - Infrastructure Implementation References Domain Contracts

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CLEAN-003` |
| Title | `Infrastructure implementation references domain contracts` |
| Category | `Clean Architecture` |
| Scenario Type | `False Positive Guard` |
| Catalogs | `Clean Architecture`; boundary references to `Hexagonal Architecture` and `DDD` |
| Primary Rule | `CLEAN-009` |
| Supporting Rules | `CLEAN-002`, `CLEAN-012`, `HEX-005` |
| Risk Level | `Medium` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Implementation Order | `13` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/clean/EVAL-CLEAN-003-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `CLEAN-009`; Clean catalog coverage; `Pass` outcome; `Likely` or `Confirmed` confidence; no-finding severity absence; strong evidence; applicability; false-positive guard; false-negative guard; Clean x Hexagonal boundary; Clean x DDD boundary; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector does not report a Clean Architecture violation when an infrastructure implementation depends on a domain-facing gateway contract and the use case depends only on that contract.

The scenario protects correct inward dependency recognition, gateway isolation, false-positive control, false-negative control, cross-catalog boundary behavior, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `False Positive Guard` |
| Secondary Types | `Positive Compliance`, `Cross-Catalog Boundary` |
| Primary Outcome | `Pass` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Confirmed` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious order-processing system.

The reviewed scope contains a use case that needs to load pricing data from an external system. The use case depends on a gateway contract expressed in application policy terms. An infrastructure component implements that contract and performs the external call outside the use case boundary.

The dependency direction points from infrastructure toward the policy contract. Runtime composition supplies the infrastructure implementation from outside the use case. The use case does not depend on the concrete infrastructure implementation, external client, protocol model, or external configuration.

The description is technology-neutral. The scenario does not require any programming language, concrete framework, external service product, runtime, container, or executable fixture.

## 5. Target Catalogs

`Clean Architecture` owns the scenario category because the evaluated condition is whether gateways isolate use cases from external systems.

`Hexagonal Architecture` is a boundary reference because outbound adapters implementing ports are adjacent to `HEX-005`, but this scenario is framed around Clean Architecture gateway isolation.

`DDD` is a boundary reference because a domain-facing contract may resemble a repository or domain contract, but DDD rules must not duplicate the Clean no-finding result.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `CLEAN-009` |
| Title | `Gateways must isolate use cases from external systems` |
| Category | `Clean Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/clean/CLEAN-009.md` |
| Catalog File | `skill/rules/CA_CATALOG.md` |

`CLEAN-009` is selected because it directly evaluates whether use cases express external needs through boundary abstractions rather than concrete external mechanisms.

`CLEAN-002` and `CLEAN-012` are related to source dependency direction and abstraction-mediated flow. `HEX-005` is related to outbound adapter implementation. They preserve boundaries but do not replace the Clean gateway question.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `CLEAN-002` | Boundary reference for source dependencies pointing toward policies. |
| `CLEAN-012` | Boundary reference for runtime flow crossing outward through abstractions. |
| `HEX-005` | Cross-catalog boundary reference for outside adapters satisfying core-owned ports. |

Supporting Rules may be used to explain related compliant evidence and expected non-findings. They must not duplicate the Primary Rule result or require a DDD repository pattern finding.

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
- explicit absence of use case dependency on concrete external mechanisms.

## 9. Directory Structure

```text
order-processing/
  use-cases/
    PriceOrderUseCase
    PricingGateway
  infrastructure/
    ExternalPricingGateway
    ExternalPricingClient
    ExternalPricingSettings
  composition/
    RuntimeBootstrap
```

The directory names are supporting context only. The expected pass must depend on explicit structural and behavioral evidence, not on names alone.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `PriceOrderUseCase` | Application use case. | Depends on `PricingGateway` only. |
| `PricingGateway` | Use-case boundary abstraction. | Expresses pricing lookup in application terms. |
| `ExternalPricingGateway` | Infrastructure implementation. | Implements `PricingGateway` and uses the external client. |
| `ExternalPricingClient` | Concrete external system client. | Used only by infrastructure implementation. |
| `ExternalPricingSettings` | External configuration. | Used only by infrastructure and composition. |
| `RuntimeBootstrap` | Composition boundary. | Wires `PricingGateway` to `ExternalPricingGateway` outside use case behavior. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `PriceOrderUseCase` | `PricingGateway` | Constructor dependency | Use case expresses external need through a boundary abstraction. |
| `ExternalPricingGateway` | `PricingGateway` | Implementation dependency | Infrastructure depends inward on the policy contract. |
| `ExternalPricingGateway` | `ExternalPricingClient` | Concrete external dependency | External system detail remains in infrastructure. |
| `RuntimeBootstrap` | `ExternalPricingGateway` | Composition dependency | Concrete wiring occurs outside use case behavior. |

No dependency is provided from `PriceOrderUseCase` to `ExternalPricingGateway`, `ExternalPricingClient`, `ExternalPricingSettings`, external protocol models, framework APIs, or infrastructure configuration.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Calculate order price | Use case and policy behavior | `PriceOrderUseCase` |
| Express external pricing need | Use case boundary | `PricingGateway` |
| Call external pricing system | Infrastructure implementation | `ExternalPricingGateway` |
| Know external client protocol | Infrastructure | `ExternalPricingClient` and `ExternalPricingGateway` |
| Compose concrete gateway | Composition boundary | `RuntimeBootstrap` |
| Make use case depend on external client | Not allowed | Absent |

## 13. Execution Flow

1. `RuntimeBootstrap` supplies an `ExternalPricingGateway` as `PricingGateway`.
2. `PriceOrderUseCase` receives the `PricingGateway` abstraction.
3. `PriceOrderUseCase` requests pricing through application terms.
4. `ExternalPricingGateway` calls the external pricing client outside the use case boundary.
5. `ExternalPricingGateway` returns boundary data to the use case.

The pass condition is present because the use case expresses external needs through a gateway abstraction and the concrete external system remains outside the use case.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or hidden architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is positive compliance and false-positive guard.

Infrastructure depends on the domain-facing contract, which is the intended direction for this boundary. The use case is isolated from concrete external system details.

## 16. Evidence Provided

Strong evidence is provided:

- use case scope: `PriceOrderUseCase`;
- gateway boundary: `PricingGateway`;
- infrastructure implementation: `ExternalPricingGateway`;
- external mechanism: `ExternalPricingClient`;
- use case depends only on the gateway contract;
- infrastructure implements or satisfies the gateway contract;
- external client and settings remain outside the use case;
- composition occurs outside use case behavior;
- no external model or implementation crosses into the use case.

Short non-compilable pseudocode:

```text
component PriceOrderUseCase
  constructor(pricing: PricingGateway)

  price(order)
    quote = pricing.quoteFor(order.items)
    return apply pricing policy to quote

component ExternalPricingGateway satisfies PricingGateway
  uses ExternalPricingClient
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- executable fixture files;
- compilable source code;
- concrete language syntax;
- specific framework name;
- external service product details;
- package files;
- build outputs;
- automated test outputs;
- runtime logs;
- architecture diagrams beyond the manifest;
- claims of formal Clean Architecture adoption;
- claims of formal Hexagonal Architecture adoption;
- complete DDD tactical model evidence;
- microservice deployment topology.

Withheld evidence prevents findings about specific integration technology, executable correctness, architecture tests, runtime behavior, formal architecture adoption, repository pattern correctness, or DDD completeness.

## 18. Expected Findings

No corrective finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: CLEAN-009
Outcome: Pass
Confidence: Confirmed
Severity: Not Applicable
Applicability: Applicable
Evidence: PriceOrderUseCase depends on PricingGateway; ExternalPricingGateway implements that contract outside the use case and contains ExternalPricingClient and ExternalPricingSettings; composition occurs outside the use case.
Architectural Impact: No corrective impact is present because the gateway boundary isolates the use case from the external pricing system.
Rationale: CLEAN-009 pass conditions are satisfied by direct evidence that the use case expresses external needs through a boundary abstraction.
Remediation: None.
Related Rules: CLEAN-002, CLEAN-012, HEX-005
Boundary Notes: The result concludes only that infrastructure implementing a use-case boundary contract is legitimate. It must not become a DDD repository-pattern finding or duplicate Hexagonal port analysis.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- infrastructure depending on a policy contract;
- external implementation existing outside the use case;
- composition outside the use case;
- use of a gateway or interface;
- absence of multiple adapters;
- absence of DDD;
- absence of Bounded Context;
- absence of Aggregate;
- absence of Value Objects;
- absence of Domain Events;
- absence of messaging;
- absence of microservices;
- absence of architecture tests;
- absence of formal Clean Architecture adoption;
- absence of Hexagonal Architecture formalism;
- absence of named layers;
- repository pattern correctness;
- monolithic deployment.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `CLEAN-009` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed`.

Direct evidence identifies the use case, gateway abstraction, infrastructure implementation, external client, dependency direction, composition boundary, and absence of use case dependency on external mechanisms.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No corrective finding is expected, so violation severity must not be assigned. The scenario risk level remains `Medium` as catalog coverage context, not as finding severity.

## 23. False Positive Guards

Do not report a finding based only on:

- infrastructure referencing a policy contract;
- an adapter implementing a gateway;
- a single external implementation;
- composition wiring outside the use case;
- existence of external client code;
- monolithic deployment;
- lack of DDD tactical patterns;
- absence of formal Clean Architecture naming.

Infrastructure depending inward on a policy boundary is legitimate when the use case depends only on the abstraction.

## 24. False Negative Guards

Do not approve when:

- the use case depends on `ExternalPricingGateway`;
- the use case instantiates `ExternalPricingClient`;
- external settings are read inside use case behavior;
- the gateway contract is owned or shaped by the external client;
- the abstraction belongs to infrastructure rather than the policy boundary;
- external protocol models cross into use case input or output.

## 25. Internal Boundary Expectations

`CLEAN-009` owns the primary result because the evaluated concern is gateway isolation of use cases from external systems.

Related Clean rules may share evidence but must keep separate responsibilities:

- `CLEAN-002` covers source dependency direction between policies and details;
- `CLEAN-012` covers runtime flow through abstractions;
- `CLEAN-006` would cover adapter data translation if external models crossed a use case boundary.

No corrective finding is required for any related Clean Rule.

## 26. Cross-Catalog Boundary Expectations

### Clean x Core

Clean Architecture owns the gateway isolation result. Core review behavior validates evidence discipline and no-finding proportionality, but no broad Core approval should exceed the reviewed boundary.

### Clean x Hexagonal Architecture

Hexagonal Architecture may describe the infrastructure implementation as an outbound adapter satisfying a port. A Hexagonal finding is forbidden when it merely treats the correct implementation dependency as a violation.

Absence of formal Hexagonal Architecture does not constitute a Clean violation.

### Clean x Layered Architecture

Layered Architecture is outside the scenario boundary unless future observed material establishes a declared layered structure and exclusive layered evidence.

Absence of named layers does not constitute a Clean violation.

## 27. Deduplication Expectations

| Shared Evidence | Clean Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Use case depends on `PricingGateway` | Gateway isolates use case under `CLEAN-009` | Hexagonal outbound port compliance may be suspected | Yes | Report no corrective finding. |
| Infrastructure implements contract | Direction is legitimate | Generic dependency finding may be suspected | Yes | Use as supporting evidence only. |
| External client in infrastructure | External details remain outside use case | Layered persistence/integration concern may be suspected | Yes | No neighboring finding without exclusive evidence. |
| Composition outside use case | Runtime flow preserves boundary | Clean flow-control pass may be suspected | Yes | No duplicate result required. |

## 28. Expected Remediation

No corrective remediation is expected.

Observed output may state that no remediation is required for the Primary Rule. It may recommend preserving the gateway contract ownership, outward implementation, and external composition, but it must not prescribe microservices, DDD, CQRS, event sourcing, a specific framework, cloud, containers, a named folder structure, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences in wording;
- equivalent ordering of evidence items;
- equivalent neutral component names;
- omission of supporting Rule results when they would be decorative;
- supporting Rule variation using existing directly relevant Rules while preserving Primary Rule and no-finding outcome;
- `Likely` confidence only if observed evidence interpretation explicitly treats some direct evidence as incomplete while preserving `Pass` and no finding.

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
- Primary Rule changed away from `CLEAN-009`;
- requirement for DDD, formal Hexagonal Architecture, microservices, CI/CD, cloud, or architecture tests.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat the pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/clean/EVAL-CLEAN-003-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `CLEAN-009` is evaluated as `Applicable`;
- primary outcome is `Pass`;
- confidence is `Confirmed` or accepted contextual `Likely`;
- severity is `Not Applicable`;
- no corrective finding appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Clean x Core, Clean x Hexagonal, Clean x DDD, and Clean x Layered boundaries are respected;
- duplicate findings are absent;
- remediation is absent or explicitly non-corrective;
- observed result comparison against `evaluation/expected/clean/EVAL-CLEAN-003-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- any corrective finding appears;
- outcome is `Fail`, `Warning`, `Not Applicable`, or unsupported `Not Enough Evidence`;
- confidence contradicts the strong evidence;
- severity is assigned despite no finding;
- infrastructure implementing a policy contract is treated as a violation by existence alone;
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
| Coverage dimensions | `CLEAN-009` false-positive guard coverage; Clean catalog coverage; `Pass`; `Confirmed` and `Likely` confidence interpretation; no-finding severity absence; strong evidence; applicability; false-positive protection; false-negative protection; Clean x Core boundary; Clean x Hexagonal boundary; Clean x DDD boundary; Clean x Layered boundary; deduplication. |
| Primary Rule catalog | `skill/rules/CA_CATALOG.md` |
| Primary Rule normative file | `skill/rules/clean/CLEAN-009.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-002.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-012.md` |
| Supporting Rule | `skill/rules/HEX-005.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
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

Initial concrete scenario for `EVAL-CLEAN-003`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `CLEAN-009`, selected Supporting Rules, and expected `Pass` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
