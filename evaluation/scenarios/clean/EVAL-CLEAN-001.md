# EVAL-CLEAN-001 - Use Case Exposes Framework Request and Response Types

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CLEAN-001` |
| Title | `Use case exposes framework request and response types` |
| Category | `Clean Architecture` |
| Scenario Type | `Confirmed Violation` |
| Catalogs | `Clean Architecture`; boundary references to `Hexagonal Architecture` and `Core` |
| Primary Rule | `CLEAN-001` |
| Supporting Rules | `CLEAN-004`, `CLEAN-011`, `HEX-008` |
| Risk Level | `High` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Implementation Order | `11` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/clean/EVAL-CLEAN-001-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `CLEAN-001`; catalog coverage for Clean Architecture; `Fail` outcome; `Confirmed` confidence; contextual `High` severity; strong evidence; applicability; false-positive guard; false-negative guard; Clean x Hexagonal boundary; Clean x Core boundary; deduplication; remediation. |

## 2. Purpose

This scenario validates that ArchInspector reports a confirmed Clean Architecture violation when a use case exposes framework request and response types at its boundary.

The scenario protects framework-type boundary analysis, use case independence, atomic finding behavior, proportional remediation, false-positive control, false-negative control, cross-catalog boundaries, and deduplication.

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

The reviewed scope contains an application use case that receives a framework request object, reads framework-specific metadata from it, and returns a framework response object. An inbound adapter exists, but it delegates the raw framework request directly into the use case instead of translating it into framework-independent boundary data.

The use case boundary is identifiable and the framework-specific request and response types are explicitly part of the use case signature. The violation is structural and behavioral; it is not inferred from names, folders, or the mere presence of a framework at the system edge.

The description is technology-neutral. The scenario does not require any programming language, concrete framework, transport, runtime, container, or executable fixture.

## 5. Target Catalogs

`Clean Architecture` owns the scenario category because the evaluated condition is whether framework-specific types cross into use case boundaries.

`Hexagonal Architecture` is a boundary reference because framework concerns in the application core are adjacent to `HEX-008`, but this scenario is specifically about Clean Architecture use case boundary data.

`Core` is a boundary reference because the scenario validates evidence discipline, atomic reporting, and no duplicated generic findings. The repository has no `CORE-*` Rule prefix.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `CLEAN-001` |
| Title | `Framework types must not cross into use cases` |
| Category | `Clean Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/clean/CLEAN-001.md` |
| Catalog File | `skill/rules/CA_CATALOG.md` |

`CLEAN-001` is selected because it directly evaluates whether use cases expose, accept, depend on, or require framework-specific types across their boundaries.

`CLEAN-004` is broader use case isolation, `CLEAN-011` is broader boundary data detail leakage, and `HEX-008` is framed around framework concerns in application core behavior. They are related, but `CLEAN-001` is the most specific primary Rule for framework request and response types in a use case signature.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `CLEAN-004` | Boundary reference for broader use case isolation from delivery and infrastructure concerns. |
| `CLEAN-011` | Boundary reference for technical details carried by boundary data structures. |
| `HEX-008` | Cross-catalog boundary reference for framework concerns remaining outside the core. |

Supporting Rules may be used to explain related evidence, expected non-findings, and forbidden duplicate findings. They must not replace `CLEAN-001` as Primary Rule and must not produce decorative or duplicative findings.

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
- explicit absence of boundary translation.

## 9. Directory Structure

```text
order-processing/
  use-cases/
    SubmitOrderUseCase
  adapters/
    inbound/
      OrderEndpointAdapter
      FrameworkOrderRequest
      FrameworkOrderResponse
```

The directory names are supporting context only. The required finding must depend on explicit structural and behavioral evidence, not on names alone.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `SubmitOrderUseCase` | Application use case. | Public boundary accepts `FrameworkOrderRequest` and returns `FrameworkOrderResponse`. |
| `OrderEndpointAdapter` | Inbound adapter. | Delegates the raw framework request directly to the use case. |
| `FrameworkOrderRequest` | Framework request type. | Contains transport metadata and framework lifecycle context. |
| `FrameworkOrderResponse` | Framework response type. | Represents framework-specific result shape. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `SubmitOrderUseCase` | `FrameworkOrderRequest` | Method signature dependency | A framework request crosses into the use case boundary. |
| `SubmitOrderUseCase` | `FrameworkOrderResponse` | Return type dependency | A framework response crosses out of the use case boundary. |
| `SubmitOrderUseCase` | framework metadata | Method behavior | Use case behavior reads request context metadata. |
| `OrderEndpointAdapter` | `SubmitOrderUseCase` | Delegation | Adapter delegates without translating external models. |

No framework-independent use case input model, output model, request model, response model, or equivalent boundary data structure is provided.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Receive external framework request | Inbound adapter | `OrderEndpointAdapter` |
| Translate external request to use case input | Interface adapter | Absent |
| Execute order submission use case | Use case | `SubmitOrderUseCase` |
| Carry framework lifecycle data | Framework or adapter | `SubmitOrderUseCase` boundary |
| Produce framework response | Inbound adapter or presenter | `SubmitOrderUseCase` |

## 13. Execution Flow

1. `OrderEndpointAdapter` receives a framework request.
2. `OrderEndpointAdapter` passes `FrameworkOrderRequest` directly to `SubmitOrderUseCase`.
3. `SubmitOrderUseCase` reads framework metadata from the request.
4. `SubmitOrderUseCase` performs application behavior.
5. `SubmitOrderUseCase` returns `FrameworkOrderResponse` directly.

The violation is present at steps 2, 3, and 5 because framework-specific types are part of the use case boundary.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or hidden architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is a confirmed violation.

The use case boundary exposes framework request and response types. The dependency is direct and observable through the signature, returned type, metadata usage, and absence of translation into use-case-owned boundary data.

## 16. Evidence Provided

Strong evidence is provided:

- use case scope: `SubmitOrderUseCase`;
- framework request type: `FrameworkOrderRequest`;
- framework response type: `FrameworkOrderResponse`;
- direct input boundary leakage: use case accepts the framework request;
- direct output boundary leakage: use case returns the framework response;
- framework metadata usage inside use case behavior;
- missing translation: no independent input or output model exists between adapter and use case.

Short non-compilable pseudocode:

```text
component SubmitOrderUseCase
  submit(request: FrameworkOrderRequest): FrameworkOrderResponse
    tenant = request.frameworkContext.tenant
    verify order submission rules
    return FrameworkOrderResponse.created(orderId)
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

Exactly one corrective finding is required.

```text
Finding ID: EVAL-CLEAN-001-F001
Rule ID: CLEAN-001
Title: Use case boundary exposes framework request and response types
Outcome: Fail
Confidence: Confirmed
Severity: High
Applicability: Applicable
Evidence: SubmitOrderUseCase accepts FrameworkOrderRequest, reads framework metadata, and returns FrameworkOrderResponse without framework-independent boundary data.
Architectural Impact: The use case contract is coupled to delivery framework types, so framework changes can alter application business rule boundaries.
Rationale: Direct signature and behavior evidence satisfies the fail condition for CLEAN-001.
Remediation: Translate framework request and response types in the adapter, introduce framework-independent use case input and output models, and keep framework lifecycle data outside the use case boundary.
Related Rules: CLEAN-004, CLEAN-011, HEX-008
Boundary Notes: The finding concludes only that framework-specific types cross the use case boundary. It must not duplicate broader use case isolation or Hexagonal core framework findings without exclusive evidence.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- use of a framework at the system edge;
- existence of an inbound adapter;
- absence of formal Clean Architecture adoption;
- absence of Hexagonal Architecture formalism;
- absence of named layers;
- absence of DDD;
- absence of Bounded Context;
- absence of Aggregate;
- absence of Value Objects;
- absence of Domain Events;
- absence of messaging;
- absence of microservices;
- absence of architecture tests;
- database product choice;
- monolithic deployment;
- repository pattern correctness;
- global framework-free architecture.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `CLEAN-001` | `Applicable` | `Fail` | `Match` |
| Scenario | `Applicable` | `Fail` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed`.

Direct evidence identifies the use case boundary, the framework-specific types, their input and output positions, framework metadata usage, and the absence of boundary translation. Naming is supporting context only.

## 22. Expected Severity

Expected severity is `High`.

The issue affects a central order submission use case and a stable application boundary. `Medium` is acceptable only if an observed result explicitly justifies reduced impact while preserving `Applicable`, `Fail`, `Confirmed`, and the required finding.

## 23. False Positive Guards

Do not report a finding based only on:

- framework annotations or request types located only in adapters;
- framework package existence;
- endpoint, controller, or handler naming;
- external request conversion when translation protects the use case;
- presence of framework-specific response formatting outside the use case;
- monolithic deployment;
- absence of formal Clean Architecture.

The required failure depends on framework-specific types crossing the use case boundary.

## 24. False Negative Guards

Do not miss the required finding because:

- the adapter is named cleanly;
- the framework request is called a command;
- the framework response is called a result;
- the use case runs in the same process as the adapter;
- only one endpoint uses the use case;
- no formal architecture style is claimed;
- framework metadata is used for convenience.

## 25. Internal Boundary Expectations

`CLEAN-001` owns the primary finding because the evaluated concern is framework-specific type leakage into a use case boundary.

Related Clean rules may share evidence but must keep separate responsibilities:

- `CLEAN-004` covers broader delivery or infrastructure concerns shaping use cases;
- `CLEAN-011` covers boundary data structures carrying framework, driver, or adapter details;
- `CLEAN-006` would cover translation failure if external models cross boundaries as a separate adapter-translation conclusion.

No additional Clean finding is required unless the observed result identifies exclusive evidence and avoids restating the `CLEAN-001` conclusion.

## 26. Cross-Catalog Boundary Expectations

### Clean x Core

Clean Architecture owns the normative finding. Core review behavior validates evidence discipline, atomicity, and no duplicated generic findings.

No generic Core finding is allowed for the same framework-type boundary conclusion.

### Clean x Hexagonal Architecture

Clean evaluates framework types crossing use case boundaries. Hexagonal evaluates framework concerns inside application core behavior. A Hexagonal finding is forbidden when it merely repeats the Clean use case boundary finding without an exclusive core-framework conclusion.

Absence of formal Hexagonal Architecture does not constitute a Clean violation.

### Clean x Layered Architecture

Layered Architecture evaluates declared layer responsibilities, dependency direction, and bypassing. This scenario provides no declared layered structure or exclusive layer bypass evidence, so a Layered finding is forbidden when it merely restates framework type leakage.

Absence of named layers does not constitute a Clean violation.

## 27. Deduplication Expectations

| Shared Evidence | Clean Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Use case accepts `FrameworkOrderRequest` | Framework type crosses use case boundary under `CLEAN-001` | Hexagonal framework leakage may be suspected | Yes | Emit one `CLEAN-001` finding unless exclusive Hexagonal evidence exists. |
| Use case returns `FrameworkOrderResponse` | Framework response crosses use case boundary | Boundary data leakage may be suspected | Yes | Use as primary evidence; no duplicate `CLEAN-011` finding. |
| Adapter delegates raw request | Missing translation supports `CLEAN-001` | Adapter translation failure may be suspected | Yes | Do not duplicate without separate translation conclusion. |
| Framework metadata in use case | Use case depends on framework concern | Generic Core coupling may be suspected | Yes | No generic Core finding. |

## 28. Expected Remediation

Expected remediation must be proportional and technology-neutral:

- translate framework request data inside the adapter;
- translate use case output into framework response data outside the use case;
- introduce framework-independent use case input and output models;
- keep framework lifecycle and metadata concerns outside application business rules;
- preserve use case behavior and avoid a full architecture rewrite.

The remediation must not require microservices, DDD, CQRS, event sourcing, a specific framework, cloud, containers, a named folder structure, or total rewrite.

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
- non-Clean Primary Rule;
- title different from the catalog title;
- category different from the catalog category;
- conclusion based only on naming;
- `Pass`;
- `Warning` as the only primary result;
- `Not Applicable`;
- `Not Enough Evidence`;
- confidence below `Confirmed`;
- missing required finding;
- duplicate finding;
- generic framework finding;
- remediation requiring DDD, microservices, framework replacement, cloud, or rewrite.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat the pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/clean/EVAL-CLEAN-001-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `CLEAN-001` is evaluated as `Applicable`;
- primary outcome is `Fail`;
- confidence is `Confirmed`;
- severity is `High` unless explicitly reduced to justified `Medium`;
- exactly one required finding appears for framework types crossing the use case boundary;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Clean x Core, Clean x Hexagonal, and Clean x Layered boundaries are respected;
- duplicate findings are absent;
- remediation is proportional and technology-neutral;
- observed result comparison against `evaluation/expected/clean/EVAL-CLEAN-001-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- the required finding is missing;
- outcome is `Pass`, `Warning` only, `Not Applicable`, or `Not Enough Evidence`;
- confidence is below `Confirmed`;
- severity contradicts the central boundary impact;
- the finding is generic or unsupported;
- the finding relies only on naming;
- a duplicate Clean, Hexagonal, Layered, or Core finding repeats the same conclusion;
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
| Coverage dimensions | `CLEAN-001` violation coverage; Clean catalog coverage; `Fail`; `Confirmed`; `High`; strong evidence; applicability; false-positive protection; false-negative protection; Clean x Core boundary; Clean x Hexagonal boundary; Clean x Layered boundary; deduplication; remediation. |
| Primary Rule catalog | `skill/rules/CA_CATALOG.md` |
| Primary Rule normative file | `skill/rules/clean/CLEAN-001.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-004.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-011.md` |
| Supporting Rule | `skill/rules/HEX-008.md` |
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

Initial concrete scenario for `EVAL-CLEAN-001`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `CLEAN-001`, selected Supporting Rules, and expected `Fail` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
