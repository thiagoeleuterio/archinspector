# EVAL-CLEAN-002 - Interface Adapter Maps External Models Into Use-Case Models

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CLEAN-002` |
| Title | `Interface adapter maps external models into use-case models` |
| Category | `Clean Architecture` |
| Scenario Type | `Positive Compliance` |
| Catalogs | `Clean Architecture` |
| Primary Rule | `CLEAN-006` |
| Supporting Rules | `CLEAN-001`, `CLEAN-004`, `CLEAN-011` |
| Risk Level | `Medium` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Implementation Order | `12` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/clean/EVAL-CLEAN-002-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `CLEAN-006`; Clean catalog coverage; `Pass` outcome; `Confirmed` confidence; no-finding severity absence; strong evidence; applicability; false-positive guard; false-negative guard; internal Clean boundary; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector recognizes adapter-local mapping from external models into use-case boundary models as compliant Clean Architecture behavior.

The scenario protects positive compliance, adapter translation responsibility, framework and adapter model isolation, false-positive control, false-negative control, internal Rule boundaries, and deduplication.

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

The reviewed scope contains an inbound interface adapter that receives an external order request, translates it into use-case input data, invokes the use case, and translates the use-case output into an external response. The use case accepts and returns framework-independent boundary models only.

External request and response models remain outside the use case boundary. Mapping code is present, but it is located in the adapter and exists to protect the use case boundary rather than shape it.

The description is technology-neutral. The scenario does not require any programming language, concrete framework, transport, runtime, container, or executable fixture.

## 5. Target Catalogs

`Clean Architecture` owns the scenario category because the evaluated condition is whether interface adapters translate between external models and use case boundary models.

No additional primary catalog is needed. Related Clean rules may share evidence for use case isolation and boundary data independence, but they must not turn correct adapter translation into a violation.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `CLEAN-006` |
| Title | `Interface adapters must translate between external models and use case boundaries` |
| Category | `Clean Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/clean/CLEAN-006.md` |
| Catalog File | `skill/rules/CA_CATALOG.md` |

`CLEAN-006` is selected because it directly evaluates whether adapters convert external models before crossing into use case boundaries and convert use case output back to external-facing models.

`CLEAN-001`, `CLEAN-004`, and `CLEAN-011` are related, but they do not own the primary result. They preserve the boundaries around framework type leakage, broader use case isolation, and technical details carried by boundary data.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `CLEAN-001` | Boundary reference for framework-specific types not crossing into use cases. |
| `CLEAN-004` | Boundary reference for use cases remaining isolated from delivery concerns. |
| `CLEAN-011` | Boundary reference for boundary data structures remaining independent from adapter details. |

Supporting Rules may be used to explain compliant evidence and expected non-findings. They must not duplicate the Primary Rule result or require a different adapter pattern.

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
- explicit absence of external model leakage into use cases.

## 9. Directory Structure

```text
order-processing/
  use-cases/
    SubmitOrderUseCase
    SubmitOrderInput
    SubmitOrderOutput
  adapters/
    inbound/
      OrderRequestAdapter
      ExternalOrderRequest
      ExternalOrderResponse
```

The directory names are supporting context only. The expected pass must depend on explicit structural and behavioral evidence, not on names alone.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `OrderRequestAdapter` | Interface adapter. | Maps external request to input model and output model to external response. |
| `ExternalOrderRequest` | External adapter model. | Used only by adapter. |
| `ExternalOrderResponse` | External adapter model. | Created only after use case result returns. |
| `SubmitOrderUseCase` | Application use case. | Accepts `SubmitOrderInput` and returns `SubmitOrderOutput`. |
| `SubmitOrderInput` | Use-case input boundary model. | Framework-independent data structure. |
| `SubmitOrderOutput` | Use-case output boundary model. | Framework-independent data structure. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `OrderRequestAdapter` | `ExternalOrderRequest` | Adapter model dependency | External model remains outside use case. |
| `OrderRequestAdapter` | `SubmitOrderInput` | Mapping dependency | Adapter translates inbound external model. |
| `OrderRequestAdapter` | `SubmitOrderUseCase` | Delegation | Adapter invokes application business rule boundary. |
| `OrderRequestAdapter` | `ExternalOrderResponse` | Mapping dependency | Adapter translates outbound use case result. |
| `SubmitOrderUseCase` | `SubmitOrderInput`, `SubmitOrderOutput` | Boundary model dependency | Use case sees only use-case-owned models. |

No dependency is provided from the use case to `ExternalOrderRequest`, `ExternalOrderResponse`, framework lifecycle types, adapter metadata, transport metadata, persistence models, or driver-specific details.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Receive external request | Interface adapter | `OrderRequestAdapter` |
| Translate external request | Interface adapter | `OrderRequestAdapter` |
| Execute order submission use case | Use case | `SubmitOrderUseCase` |
| Define use case input and output | Use case boundary | `SubmitOrderInput`, `SubmitOrderOutput` |
| Translate use case output to external response | Interface adapter | `OrderRequestAdapter` |
| Carry external model into use case | Not allowed | Absent |

## 13. Execution Flow

1. `OrderRequestAdapter` receives `ExternalOrderRequest`.
2. `OrderRequestAdapter` maps external fields into `SubmitOrderInput`.
3. `OrderRequestAdapter` invokes `SubmitOrderUseCase`.
4. `SubmitOrderUseCase` returns `SubmitOrderOutput`.
5. `OrderRequestAdapter` maps the output into `ExternalOrderResponse`.

The pass condition is present because external models are translated at the adapter boundary and never become use case boundary types.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or hidden architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is positive compliance and false-positive guard.

The adapter contains mapping code, but that mapping is the expected Clean Architecture responsibility for an interface adapter. Use case boundary models remain independent from external transport and framework details.

## 16. Evidence Provided

Strong evidence is provided:

- adapter scope: `OrderRequestAdapter`;
- external models: `ExternalOrderRequest` and `ExternalOrderResponse`;
- use case scope: `SubmitOrderUseCase`;
- boundary models: `SubmitOrderInput` and `SubmitOrderOutput`;
- inbound translation before use case invocation;
- outbound translation after use case result;
- no external model dependency inside the use case;
- no framework or adapter details in boundary data.

Short non-compilable pseudocode:

```text
component OrderRequestAdapter
  receive(external: ExternalOrderRequest)
    input = SubmitOrderInput.fromNeutralValues(external.customerRef, external.lines)
    output = SubmitOrderUseCase.submit(input)
    return ExternalOrderResponse.from(output)

component SubmitOrderUseCase
  submit(input: SubmitOrderInput): SubmitOrderOutput
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- executable fixture files;
- compilable source code;
- concrete language syntax;
- specific framework name;
- database product details;
- package files;
- build outputs;
- automated test outputs;
- runtime logs;
- architecture diagrams beyond the manifest;
- claims of formal Clean Architecture adoption;
- claims of formal Hexagonal Architecture adoption;
- DDD tactical model evidence;
- microservice deployment topology.

Withheld evidence prevents findings about specific framework choice, executable correctness, test coverage, runtime behavior, formal architecture adoption, persistence strategy, or DDD completeness.

## 18. Expected Findings

No corrective finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: CLEAN-006
Outcome: Pass
Confidence: Confirmed
Severity: Not Applicable
Applicability: Applicable
Evidence: OrderRequestAdapter maps ExternalOrderRequest into SubmitOrderInput, invokes SubmitOrderUseCase, and maps SubmitOrderOutput into ExternalOrderResponse; the use case depends only on framework-independent boundary models.
Architectural Impact: No corrective impact is present because adapter translation protects the use case boundary.
Rationale: CLEAN-006 pass conditions are satisfied by direct evidence that external models are translated before and after the use case boundary.
Remediation: None.
Related Rules: CLEAN-001, CLEAN-004, CLEAN-011
Boundary Notes: The result concludes only that adapter translation protects the reviewed use case boundary. It must not become a universal requirement for a specific DTO naming style.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- mapping code in an adapter;
- external request or response models outside use cases;
- adapter dependency on the use case boundary;
- use-case-owned input and output models;
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
- monolithic deployment;
- naming of request, response, command, input, or output models.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `CLEAN-006` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed`.

Direct evidence identifies the adapter, external models, use case boundary models, translation behavior, use case invocation, and absence of external model leakage into the use case. Naming is supporting context only.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No corrective finding is expected, so violation severity must not be assigned. The scenario risk level remains `Medium` as catalog coverage context, not as finding severity.

## 23. False Positive Guards

Do not report a finding based only on:

- external models existing in adapters;
- mapping code near a framework boundary;
- adapter dependency on use case input or output models;
- similar fields between external models and boundary models;
- use of request or response names;
- monolithic deployment;
- absence of formal Clean Architecture.

Mapping code in the adapter is compliant when it protects use case boundaries.

## 24. False Negative Guards

Do not approve when:

- `ExternalOrderRequest` is passed directly to the use case;
- `ExternalOrderResponse` is returned by the use case;
- framework lifecycle types appear in `SubmitOrderInput` or `SubmitOrderOutput`;
- the use case depends on the adapter;
- mapping is only documented and not structurally shown;
- names suggest translation but no translation behavior is provided.

## 25. Internal Boundary Expectations

`CLEAN-006` owns the primary result because the evaluated concern is adapter translation between external models and use case boundary models.

Related Clean rules may share evidence but must keep separate responsibilities:

- `CLEAN-001` covers framework-specific type leakage into use cases;
- `CLEAN-004` covers broader use case shaping by delivery or infrastructure;
- `CLEAN-011` covers boundary data carrying framework, driver, or adapter details.

No corrective finding is required for any related Clean Rule.

## 26. Cross-Catalog Boundary Expectations

### Clean x Core

Clean Architecture owns the adapter translation result. Core review behavior validates evidence discipline and proportional no-finding behavior, but no broad Core approval should exceed the reviewed boundary.

### Clean x Hexagonal Architecture

Hexagonal Architecture may use the same adapter and boundary evidence to reason about ports and adapters. A Hexagonal finding is forbidden when it merely treats correct adapter translation as a violation.

Absence of formal Hexagonal Architecture does not constitute a Clean violation.

### Clean x Layered Architecture

Layered Architecture is outside the scenario boundary unless future observed material establishes a declared layered structure and exclusive layered evidence.

Absence of named layers does not constitute a Clean violation.

## 27. Deduplication Expectations

| Shared Evidence | Clean Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Adapter maps request to input | `CLEAN-006` pass | Clean framework leakage or Hex adapter result may be suspected | Yes | Report no corrective finding. |
| Use case accepts `SubmitOrderInput` | External model does not cross boundary | Framework-type pass may be suspected | Yes | Use as supporting evidence only. |
| Adapter maps output to response | Boundary translation is compliant | Presenter or response-shape finding may be suspected | Yes | No separate finding without exclusive evidence. |
| Similar fields in external and boundary models | Translation preserves needed data | Mapper shaping may be suspected | Yes | Do not fail on field similarity alone. |

## 28. Expected Remediation

No corrective remediation is expected.

Observed output may state that no remediation is required for the Primary Rule. It may recommend preserving adapter-local mapping and framework-independent use case boundary models, but it must not prescribe microservices, DDD, CQRS, event sourcing, a specific framework, cloud, containers, a named folder structure, or a rewrite.

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
- Primary Rule changed away from `CLEAN-006`;
- requirement for DDD, formal Hexagonal Architecture, microservices, CI/CD, cloud, or architecture tests.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat the pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/clean/EVAL-CLEAN-002-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `CLEAN-006` is evaluated as `Applicable`;
- primary outcome is `Pass`;
- confidence is `Confirmed` or accepted contextual `Likely`;
- severity is `Not Applicable`;
- no corrective finding appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- internal Clean boundaries are respected;
- Clean x Core, Clean x Hexagonal, and Clean x Layered boundaries are respected;
- duplicate findings are absent;
- remediation is absent or explicitly non-corrective;
- observed result comparison against `evaluation/expected/clean/EVAL-CLEAN-002-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- any corrective finding appears;
- outcome is `Fail`, `Warning`, `Not Applicable`, or unsupported `Not Enough Evidence`;
- confidence contradicts the strong evidence;
- severity is assigned despite no finding;
- mapping code is treated as a violation by existence alone;
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
| Coverage dimensions | `CLEAN-006` positive compliance coverage; Clean catalog coverage; `Pass`; `Confirmed`; no-finding severity absence; strong evidence; applicability; false-positive protection; false-negative protection; internal Clean boundary; Clean x Core boundary; Clean x Hexagonal boundary; Clean x Layered boundary; deduplication. |
| Primary Rule catalog | `skill/rules/CA_CATALOG.md` |
| Primary Rule normative file | `skill/rules/clean/CLEAN-006.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-001.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-004.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-011.md` |
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

Initial concrete scenario for `EVAL-CLEAN-002`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `CLEAN-006`, selected Supporting Rules, and expected `Pass` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
