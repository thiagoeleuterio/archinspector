# EVAL-HEX-003 - Framework Annotations Present Only in an Inbound Adapter

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-HEX-003` |
| Title | `Framework annotations present only in an inbound adapter` |
| Category | `Hexagonal Architecture` |
| Scenario Type | `False Positive Guard` |
| Catalogs | `Hexagonal Architecture`; boundary references to `Clean Architecture` and `Core` |
| Primary Rule | `HEX-008` |
| Supporting Rules | `HEX-002`, `HEX-003`, `CLEAN-006` |
| Risk Level | `Medium` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/hexagonal/EVAL-HEX-003-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `HEX-008`; catalog coverage for Hexagonal Architecture; `Pass` outcome; `Confirmed` confidence; no-finding severity absence; strong evidence; applicability; false-positive guard; false-negative guard; internal Hexagonal boundary; Hexagonal x Clean boundary; Hexagonal x Core boundary; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector does not report framework leakage when framework annotations or metadata appear only in an inbound adapter and do not enter the application core.

The scenario protects framework isolation analysis, inbound adapter recognition, technology-neutral core boundaries, false-positive control, false-negative control, cross-catalog boundaries, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `False Positive Guard` |
| Secondary Types | `Positive Compliance`, `Internal Boundary` |
| Primary Outcome | `Pass` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Confirmed` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious order-processing system.

The reviewed scope contains an inbound adapter that receives an external request through a framework-facing endpoint shape. Framework annotations and framework request/response metadata are present only in that adapter. The adapter converts the external request into an application input model, invokes an inbound port or use case, and converts the application result into an external response.

The application core contains the inbound port, input model, output model, and use case behavior. No framework annotation, framework request type, framework response type, framework configuration type, or framework lifecycle dependency appears in the core. The core does not depend on the inbound adapter.

The description is technology-neutral. The scenario does not name or require any specific framework, language, transport, runtime, container, or executable fixture.

## 5. Target Catalogs

`Hexagonal Architecture` owns the scenario category because the evaluated condition is whether framework concerns remain outside the core while an inbound adapter interacts with the core through the proper boundary.

`Clean Architecture` is a boundary reference because adapter translation and framework types crossing use cases are adjacent Clean concerns. Clean findings must not duplicate the Hexagonal no-finding result.

`Core` is a boundary reference because the scenario validates no-finding discipline and evidence before conclusion.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `HEX-008` |
| Title | `Framework concerns must remain outside the core` |
| Category | `Hexagonal Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/HEX-008.md` |
| Catalog File | `skill/rules/HEX_CATALOG.md` |

`HEX-008` is selected because it directly evaluates whether framework-specific APIs, configuration, attributes, or annotations remain outside application core behavior. The scenario specifically proves framework isolation rather than framework absence from the whole system.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `HEX-002` | Boundary reference for inbound entry through an application-facing port or use case. |
| `HEX-003` | Boundary reference for inbound adapter delegation rather than core business behavior ownership. |
| `CLEAN-006` | Cross-catalog boundary reference for adapter translation between external and use-case models. |

Supporting Rules may be used to explain related compliant behavior and forbidden duplicate findings. They must not turn adapter-local framework usage into a core leakage finding.

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
- explicit absence of framework concerns in the core.

## 9. Directory Structure

```text
order-processing/
  application-core/
    SubmitOrderUseCase
    SubmitOrderPort
    SubmitOrderInput
    SubmitOrderResult
  adapters/
    inbound/
      OrderEndpointAdapter
      ExternalOrderRequest
      ExternalOrderResponse
  composition/
    RuntimeBootstrap
```

The directory names are supporting context only. The expected pass must depend on explicit structural and behavioral evidence, not on names alone.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `OrderEndpointAdapter` | Inbound adapter. | Contains framework annotations and converts request/response models. |
| `ExternalOrderRequest` | External request model. | Used only by inbound adapter. |
| `ExternalOrderResponse` | External response model. | Used only by inbound adapter. |
| `SubmitOrderPort` | Core inbound boundary. | Invoked by adapter with application input. |
| `SubmitOrderUseCase` | Application core behavior. | Depends only on core input/output models. |
| `SubmitOrderInput` | Application input model. | Framework-neutral core boundary type. |
| `SubmitOrderResult` | Application output model. | Framework-neutral core boundary type. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `OrderEndpointAdapter` | framework annotations | Metadata dependency | Framework concern is outside the core. |
| `OrderEndpointAdapter` | `SubmitOrderPort` | Invocation dependency | Inbound adapter enters through core boundary. |
| `OrderEndpointAdapter` | `SubmitOrderInput` | Translation dependency | External request is converted before the port. |
| `OrderEndpointAdapter` | `ExternalOrderResponse` | Translation dependency | Core result is converted after the port. |
| `SubmitOrderUseCase` | `SubmitOrderInput` and `SubmitOrderResult` | Core model dependency | Use case boundary is framework-neutral. |

No dependency is provided from `SubmitOrderUseCase`, `SubmitOrderPort`, `SubmitOrderInput`, or `SubmitOrderResult` to framework annotations, framework request types, framework response types, or the inbound adapter.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Receive external request | Inbound adapter | `OrderEndpointAdapter` |
| Hold framework annotations | Inbound adapter or outside configuration | `OrderEndpointAdapter` only |
| Convert external request to application input | Inbound adapter | `OrderEndpointAdapter` |
| Invoke application behavior | Inbound adapter through core boundary | `OrderEndpointAdapter` invokes `SubmitOrderPort` |
| Execute order submission behavior | Application core | `SubmitOrderUseCase` |
| Convert application result to external response | Inbound adapter | `OrderEndpointAdapter` |
| Carry framework types in core | Not allowed | Absent |

## 13. Execution Flow

1. `OrderEndpointAdapter` receives an external request using framework-facing metadata.
2. `OrderEndpointAdapter` converts `ExternalOrderRequest` to `SubmitOrderInput`.
3. `OrderEndpointAdapter` invokes `SubmitOrderPort`.
4. `SubmitOrderUseCase` performs application behavior using core models only.
5. `OrderEndpointAdapter` converts `SubmitOrderResult` to `ExternalOrderResponse`.

The pass condition is present because framework concerns remain in the inbound adapter and do not shape core behavior or core contracts.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or hidden architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is positive compliance and false-positive guard.

Framework annotations are present, but only in an inbound adapter outside the core. The core remains framework-neutral. The adapter translates external models before and after the port.

## 16. Evidence Provided

Strong evidence is provided:

- inbound adapter scope: `OrderEndpointAdapter`;
- framework annotations or metadata are present only in the adapter;
- adapter converts external request to `SubmitOrderInput`;
- adapter invokes `SubmitOrderPort`;
- adapter converts `SubmitOrderResult` to external response;
- no framework annotation appears in the core;
- no framework type crosses the port;
- no external request or response type is used inside the use case;
- no core dependency points to the adapter;
- adapter contains no core business behavior beyond translation and delegation.

Short non-compilable pseudocode:

```text
component OrderEndpointAdapter
  framework_annotation external_route

  receive(externalRequest: ExternalOrderRequest)
    input = map externalRequest to SubmitOrderInput
    result = SubmitOrderPort.submit(input)
    return map result to ExternalOrderResponse

component SubmitOrderUseCase satisfies SubmitOrderPort
  submit(input: SubmitOrderInput): SubmitOrderResult
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
- claims of formal Clean Architecture adoption;
- DDD tactical model evidence;
- microservice deployment topology.

Withheld evidence prevents findings about specific framework choice, executable correctness, test coverage, runtime behavior, formal architecture adoption, or unrelated data access concerns.

## 18. Expected Findings

No corrective finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: HEX-008
Outcome: Pass
Confidence: Confirmed
Severity: Not Applicable
Applicability: Applicable
Evidence: Framework annotations and external request/response models are present only in OrderEndpointAdapter; the adapter maps to SubmitOrderInput, invokes SubmitOrderPort, maps SubmitOrderResult back to an external response, and no framework type or annotation appears in the core.
Architectural Impact: No corrective impact is present because framework concerns remain outside application core behavior.
Rationale: HEX-008 pass conditions are satisfied by direct evidence that framework concerns are isolated in the inbound adapter.
Remediation: None.
Related Rules: HEX-002, HEX-003, CLEAN-006
Boundary Notes: The result concludes only that adapter-local framework annotations are not core leakage. It must not require the whole system to be framework-free.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- annotations in the adapter;
- framework usage at the edge;
- request conversion;
- response conversion;
- external composition;
- existence of a controller, handler, endpoint, or inbound adapter;
- absence of framework-free infrastructure;
- absence of microservices;
- absence of DDD;
- absence of formal Clean Architecture;
- adapter depending on application boundary;
- adapter knowing external protocol;
- framework import localized to adapter.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `HEX-008` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed`.

Direct evidence identifies adapter-local framework annotations, request translation, port invocation, response translation, framework-neutral core models, and absence of core dependency on framework concerns.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No corrective finding is expected, so violation severity must not be assigned. The scenario risk level remains `Medium` as catalog coverage context, not as finding severity.

## 23. False Positive Guards

Do not report a finding based on:

- framework import localized in the adapter;
- annotation localized in the adapter;
- external type converted before the port;
- adapter knowledge of external protocol;
- adapter dependency on the application boundary;
- external configuration located outside the core;
- existence of a controller, handler, or endpoint adapter.

Framework at the edge is legitimate when it remains outside core behavior.

## 24. False Negative Guards

Do not approve when:

- raw external request type crosses the port;
- external response type is returned by the use case;
- annotation appears in the core;
- use case depends on the framework;
- application interface belongs to the framework;
- adapter contains core business rules;
- core instantiates the inbound adapter.

If such evidence appears, the pass must not be preserved.

## 25. Internal Boundary Expectations

`HEX-008` owns the primary result because the evaluated concern is framework concerns remaining outside the core.

Related Hexagonal rules may share evidence but must keep separate responsibilities:

- `HEX-002` covers external actors entering through an inbound port;
- `HEX-003` covers inbound adapter behavior placement;
- `HEX-007` would cover broader dependency direction if a core-to-adapter dependency existed;
- `HEX-011` would cover adapter model leakage into core contracts if external models crossed the port.

No corrective finding is required for any related Hexagonal Rule.

## 26. Cross-Catalog Boundary Expectations

### Hexagonal x Core

Hexagonal owns the framework-isolation result. Core review behavior validates evidence discipline and no-finding proportionality. The result must not become a broad approval of all core architecture beyond the reviewed framework boundary.

### Hexagonal x Clean

Clean Architecture may evaluate framework types crossing use case boundaries or adapter translation. The scenario provides evidence that external models are translated before the port and framework types do not cross into the use case. A Clean finding is forbidden when it merely reports framework annotations located in the adapter.

### Hexagonal x Layered

Layered Architecture is not a boundary catalog for this scenario. Adapter-local annotations and request/response mapping do not establish a layered bypass or layer responsibility violation without exclusive layered evidence.

## 27. Deduplication Expectations

| Shared Evidence | Hexagonal Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Annotation in inbound adapter | Framework concern remains outside core under `HEX-008` | Clean controller or framework boundary may be suspected | Yes | Emit no corrective finding. |
| Request mapped before port | Supports framework isolation | Clean adapter translation pass may be suspected | Yes | Use as supporting evidence only. |
| Use case uses core models | Supports no core framework leakage | Generic Core approval may be suspected | Yes | Do not broaden beyond reviewed scope. |
| Adapter invokes port | Supports inbound boundary | Hexagonal inbound-port pass may be suspected | Yes | No duplicate result required. |

## 28. Expected Remediation

No corrective remediation is expected.

Observed output may state that no remediation is required for the Primary Rule. It may recommend preserving adapter-local framework concerns and core-neutral port models, but it must not prescribe removal of all framework usage, a specific framework, microservices, DDD, Clean Architecture formalism, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences in wording;
- equivalent ordering of evidence items;
- equivalent neutral names for endpoint, handler, request, and response;
- omission of supporting Rule results when they would be decorative;
- supporting Rule variation using existing directly relevant Rules while preserving Primary Rule and no-finding outcome.

## 30. Disallowed Variations

Disallowed variations:

- `Fail`;
- `Warning` based only on adapter-local framework metadata;
- `Not Applicable` for the Primary Rule;
- unsupported `Not Enough Evidence`;
- any corrective finding;
- severity other than `Not Applicable`;
- finding based only on a framework annotation in the adapter;
- duplicate finding;
- nonexistent Rule ID;
- Primary Rule changed away from `HEX-008`;
- requirement for a specific framework, framework-free entire system, DDD, microservices, CI/CD, cloud, or architecture tests.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat the pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/hexagonal/EVAL-HEX-003-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `HEX-008` is evaluated as `Applicable`;
- primary outcome is `Pass`;
- confidence is `Confirmed`;
- severity is `Not Applicable`;
- no corrective finding appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Hexagonal x Core and Hexagonal x Clean boundaries are respected;
- duplicate findings are absent;
- remediation is absent or explicitly non-corrective;
- observed result comparison against `evaluation/expected/hexagonal/EVAL-HEX-003-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- any corrective finding appears;
- outcome is `Fail`, `Warning`, `Not Applicable`, or unsupported `Not Enough Evidence`;
- confidence contradicts the strong evidence;
- severity is assigned despite no finding;
- adapter-local framework concerns are treated as core leakage;
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
| Coverage dimensions | `HEX-008` false-positive guard coverage; Hexagonal catalog coverage; `Pass`; `Confirmed`; no-finding severity absence; strong evidence; applicability; false-positive protection; false-negative protection; internal Hexagonal boundary; Hexagonal x Clean boundary; Hexagonal x Core boundary; deduplication. |
| Primary Rule catalog | `skill/rules/HEX_CATALOG.md` |
| Primary Rule normative file | `skill/rules/HEX-008.md` |
| Supporting Rule | `skill/rules/HEX-002.md` |
| Supporting Rule | `skill/rules/HEX-003.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-006.md` |
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

Initial concrete scenario for `EVAL-HEX-003`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity, selected Primary Rule `HEX-008`, and expected `Pass` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
