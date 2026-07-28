# EVAL-CORE-003 - Architectural Intent Documented But Implementation Unavailable

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CORE-003` |
| Title | `Architectural intent documented but implementation unavailable` |
| Category | `Core` |
| Scenario Type | `Insufficient Evidence` |
| Catalogs | `Core`; boundary references to `Solution Architecture` and `Architecture Testing` |
| Primary Rule | `SOL-001` |
| Supporting Rules | `TEST-002`, `TEST-003`, `TEST-001` |
| Risk Level | `Medium` |
| Execution Type | `Document Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/core/EVAL-CORE-003-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `SOL-001`; catalog coverage for Core, Solution Architecture, and Architecture Testing; `Not Enough Evidence` outcome; `Not Enough Evidence` confidence; contextual absence of severity; nominal evidence; undetermined applicability; insufficient evidence; false-positive guard; false-negative guard; manual validation; partial scope; document x implementation boundary; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector does not transform documented architectural intent into proof of implemented architecture when implementation evidence is unavailable.

The scenario protects insufficient-evidence handling, evidence discipline, explicit unknowns, false-positive control, false-negative control, boundary behavior, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Insufficient Evidence` |
| Secondary Types | `Manual Validation`, `Partial Scope` |
| Primary Outcome | `Not Enough Evidence` |
| Evidence Strength | `Nominal` |
| Applicability | `Undetermined` |
| Confidence | `Not Enough Evidence` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious order-processing system described only through planning documentation.

The reviewed scope contains an architecture document, a conceptual module diagram, planned responsibilities, directory names, and statements that the domain is independent and infrastructure implements contracts. No implementation tree, dependency graph, imports, references, build output, manifest, composition evidence, or executable behavior is available.

The documentation is coherent and may describe a desirable design, but it is not sufficient to confirm conformance or violation. The risk remains unresolved because the evaluator cannot inspect whether the implementation follows the stated intent.

The description is technology-neutral. The scenario does not require any programming language, framework, database product, runtime, or executable fixture.

## 5. Target Catalogs

`Core` owns the scenario category because the scenario validates central ArchInspector behavior: evidence before conclusion, conservative handling of missing implementation, explicit unknowns, and proportional non-findings.

The repository does not define a `CORE-*` Rule prefix. `evaluation/SCENARIO_CATALOG.md` states that Core scenarios target existing Rules whose responsibilities exercise Core review behavior.

`Solution Architecture` is a boundary reference because `SOL-001` is the existing Rule selected by the scenario catalog for this scenario.

`Architecture Testing` is a boundary reference because the scenario touches documentation, decisions, and testability of validation claims, but testing rules must not convert missing implementation into confirmed pass or fail results.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `SOL-001` |
| Title | `Decisions should address explicit requirements and constraints` |
| Category | `Solution Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/solution-architecture/SOL-001.md` |
| Catalog File | `None found` |

`SOL-001` is selected because the reviewed material is limited to documented architecture decisions, requirements, constraints, and intent. The Rule is applicable to the topic, but the provided evidence is not sufficient to decide whether the implementation satisfies or violates the documented decision.

The selection follows `evaluation/SCENARIO_CATALOG.md`, which identifies `SOL-001` as the Primary Rule for `EVAL-CORE-003`. No `CORE-*` Rule exists, and the scenario is intentionally document-only.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `TEST-002` | Boundary reference for traceability between documented validation claims and real architectural decisions. |
| `TEST-003` | Boundary reference for whether documented constraints are objective enough to verify when implementation becomes available. |
| `TEST-001` | Boundary reference for avoiding treatment of documentation-only intent as a declared effective fitness function. |

Supporting Rules may be used to explain evidence gaps and expected non-findings. They must not duplicate the Primary Rule result or require architecture testing where no verification mechanism is provided.

## 8. Input Artifacts

The scenario input is a textual document fixture. It is not executable and must not be treated as compilable code.

The document fixture includes:

- architecture document summary;
- conceptual module diagram;
- planned component names;
- declared responsibilities;
- intended dependency direction;
- written policy statements;
- explicit absence of implementation evidence;
- explicit absence of structural verification evidence.

## 9. Directory Structure

```text
planned-order-processing/
  domain/          (planned)
  application/     (planned)
  infrastructure/  (planned)
  composition/     (planned)
```

The directory names are planned labels only. They are not evidence of implemented modules, dependency direction, or responsibility placement.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `Domain Module` | Planned owner of order business rules. | Described in documentation only. |
| `Application Module` | Planned owner of orchestration. | Described in documentation only. |
| `Infrastructure Module` | Planned owner of external persistence. | Shown as a diagram box only. |
| `OrderRepository Contract` | Planned abstraction for persistence. | Mentioned in text without implementation. |
| `Composition Module` | Planned dependency wiring location. | Mentioned in text without structural evidence. |
| `Module Diagram` | Conceptual architecture picture. | Shows boxes and arrows but no real dependency graph. |
| `Architecture Policy` | Written intent. | States that domain should not reference infrastructure. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `Domain Module` | `OrderRepository Contract` | Planned dependency | Documentation states intended dependency, but implementation is unavailable. |
| `Infrastructure Module` | `OrderRepository Contract` | Planned implementation dependency | Documentation states intended direction, but no reference can be inspected. |
| `Composition Module` | `Infrastructure Module` | Planned composition dependency | Documentation states intended wiring, but no composition evidence exists. |
| `Module Diagram` | module boxes | Conceptual diagram | Nominal planning evidence only. |

No real dependency graph, import list, project reference, package reference, type dependency, constructor dependency, method behavior, or code excerpt is provided.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Define order business rules | Domain | Planned in documentation only |
| Coordinate workflows | Application | Planned in documentation only |
| Implement external persistence | Infrastructure | Planned in documentation only |
| Define domain-facing contracts | Domain or appropriate boundary layer | Planned in documentation only |
| Compose implementations | Composition boundary | Planned in documentation only |
| Verify dependency direction | Review or architecture validation mechanism | Not provided |

## 13. Execution Flow

1. The architecture document states that order submission enters the application module.
2. The document states that the application module invokes domain behavior.
3. The document states that the domain uses a contract for persistence.
4. The document states that infrastructure implements the contract.
5. The document states that composition wires the implementation externally.

The flow is intended behavior only. It cannot confirm pass or fail because no implementation, structural reference, or execution evidence is available.

## 14. Preconditions

- The evaluator receives the document fixture as the complete scenario input.
- The evaluator treats the document as reviewed material for document-based evaluation.
- The evaluator does not assume implementation files, dependency graphs, tests, runtime behavior, or hidden manifests.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is insufficient evidence.

The documented intent is coherent, but the reviewed material cannot establish whether the implementation exists, whether it matches the diagram, whether dependencies point in the intended direction, whether contracts are implemented, or whether composition is external. The correct result keeps both compliance and violation unconfirmed.

## 16. Evidence Provided

Nominal evidence is provided:

- declared architecture document;
- conceptual module diagram;
- planned responsibilities;
- intended dependency direction;
- intended domain independence statement;
- intended infrastructure implementation statement;
- planned directory names;
- written architecture policy.

Short non-compilable documentation excerpt:

```text
Architecture intent:
  Domain contains order rules and does not depend on infrastructure.
  Infrastructure implements domain-facing contracts.
  Composition wires implementations outside the domain.
  Planned folders: domain, application, infrastructure, composition.
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- imports;
- references;
- dependency graph;
- compiled dependencies;
- real manifest;
- source code;
- configuration;
- composition code or manifest;
- execution output;
- static analysis output;
- automated test outputs;
- architecture test definitions;
- implementation of contracts;
- package files;
- runtime logs.

Withheld evidence prevents confirmed findings about implementation conformance, implementation violation, dependency direction, framework leakage, persistence placement, or validation coverage.

## 18. Expected Findings

No confirmed violation finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: SOL-001
Outcome: Not Enough Evidence
Confidence: Not Enough Evidence
Severity: Not Applicable
Applicability: Undetermined
Evidence: Architecture intent, conceptual diagram, planned responsibilities, planned dependency direction, and written policy are available; implementation, dependency, composition, configuration, and execution evidence are unavailable.
Architectural Impact: The risk remains unresolved because the reviewed material cannot prove conformance or violation.
Rationale: Documentation alone cannot establish implemented dependency direction or responsibility placement.
Remediation: Provide structural evidence such as dependency graph, source references, manifests, composition evidence, or implementation excerpts before confirming pass or fail.
Related Rules: TEST-002, TEST-003, TEST-001
Boundary Notes: The result concludes only that evidence is insufficient. It must not become a confirmed Hexagonal, Clean, Layered, DDD, Architecture Testing, or Solution Architecture violation.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- dependency from Core to Infrastructure;
- Hexagonal Architecture violation;
- Clean Architecture violation;
- Layered Architecture violation;
- DDD absence;
- framework leakage;
- persistence inside the domain;
- absence of contracts;
- adoption or absence of microservices;
- absence of architecture tests;
- repository pattern correctness;
- global persistence strategy;
- runtime deployment shape;
- CI/CD absence;
- cloud absence.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `SOL-001` | `Undetermined` | `Not Enough Evidence` | `Match` |
| Scenario | `Undetermined` | `Not Enough Evidence` | `Match` |

## 21. Expected Confidence

Expected confidence is `Not Enough Evidence`.

The available material is documentation-only and nominal. It can identify architectural intent but cannot establish implementation state, dependency direction, composition behavior, or structural conformance.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No violation finding is confirmed, so no violation severity is assigned. The scenario risk level remains `Medium` as catalog coverage context, not as finding severity.

## 23. False Positive Guards

Do not report a finding based only on:

- infrastructure appearing in a diagram;
- planned module names;
- planned directory names;
- absence of formal architecture pattern evidence;
- incomplete documentation;
- inferred dependency direction;
- documentation-only contract names;
- lack of implementation material.

Documentation incompleteness must remain insufficient evidence, not a confirmed violation.

## 24. False Negative Guards

Do not approve automatically because:

- the document claims domain independence;
- boxes are separated in a diagram;
- contracts are mentioned;
- infrastructure is shown outside domain in planned diagrams;
- the written policy sounds coherent;
- folder names are plausible;
- no violation evidence is visible.

The observed result must request additional structural evidence and keep risk unresolved.

## 25. Internal Boundary Expectations

`SOL-001` owns the primary result because the evaluated material is solution-level decision and constraint documentation.

Architecture Testing supporting rules may share evidence but must keep separate responsibilities:

- `TEST-002` would require a conclusion about traceability of a verification mechanism;
- `TEST-003` would require a conclusion about objective testability of a specific verified constraint;
- `TEST-001` would require a declared fitness function or equivalent validation mechanism.

No Architecture Testing finding is required because no verification mechanism is provided.

## 26. Cross-Catalog Boundary Expectations

### Core x Solution Architecture

Core scenario behavior is validated through the existing `SOL-001` Rule because no `CORE-*` Rule prefix exists. The Core concern is evidence discipline around architectural intent. The Solution Architecture Rule owns the documented decision and constraint context.

The scenario must not convert a documented decision into proof of implemented architecture.

### Core x Architecture Testing

Architecture Testing rules may explain what validation evidence is missing. They must not require automation, architecture tests, CI/CD, or a fitness function as a corrective finding when the scenario provides only documentation and no validation mechanism claim.

Absence of architecture tests is not a confirmed violation.

## 27. Deduplication Expectations

Shared evidence is allowed.

Duplicate conclusions are not allowed.

Findings are forbidden when they only rephrase insufficient evidence under:

- `TEST-002`;
- `TEST-003`;
- `TEST-001`;
- `HEX-001`;
- `CLEAN-004`;
- `LAYER-002`;
- `DDD-019`.

Separate findings are allowed only when future observed material identifies exclusive evidence beyond the document-only scope.

## 28. Expected Remediation

No corrective remediation is expected because no violation is confirmed.

The observed result may include a non-corrective evidence request:

- provide dependency graph or project/module references;
- provide source excerpts showing contracts and implementations;
- provide composition evidence;
- provide configuration placement evidence;
- provide architecture-test or review evidence if it exists.

The remediation must not prescribe microservices, DDD, Clean Architecture, Hexagonal Architecture, architecture tests, CI/CD, a tool, a framework, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences in wording;
- equivalent ordering of evidence gaps;
- equivalent non-corrective request for structural evidence;
- supporting Rule omission when it would be decorative;
- observation classified separately as non-corrective if the model distinguishes observations from findings;
- result status `Acceptable Variation` only when it preserves `Not Enough Evidence`, no confirmed finding, and unresolved risk.

## 30. Disallowed Variations

Disallowed variations:

- `Pass`;
- `Fail`;
- `Warning` as the primary result;
- `Not Applicable` for the Primary Rule when the evidence gap is the reason evaluation cannot proceed;
- confidence other than `Not Enough Evidence`;
- any confirmed violation finding;
- any confirmed compliance conclusion;
- severity assigned as if a violation exists;
- finding based only on documentation, names, or diagram boxes;
- duplicate finding;
- nonexistent Rule ID;
- Primary Rule changed away from `SOL-001`;
- requirement for DDD, formal Clean Architecture, formal Hexagonal Architecture, microservices, CI/CD, cloud, or architecture tests.

## 31. Execution Instructions

Evaluate the document fixture statically.

Do not compile, run, generate, or infer executable fixture code. Treat the documentation excerpt as non-compilable evidence of intent only. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/core/EVAL-CORE-003-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `SOL-001` is evaluated as `Undetermined`;
- primary outcome is `Not Enough Evidence`;
- confidence is `Not Enough Evidence`;
- severity is `Not Applicable`;
- no confirmed violation finding appears;
- no confirmed compliance conclusion appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Core x Solution Architecture and Core x Architecture Testing boundaries are respected;
- duplicate findings are absent;
- evidence request is proportional and non-corrective;
- observed result comparison against `evaluation/expected/core/EVAL-CORE-003-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- a confirmed violation finding appears;
- outcome is `Pass`, `Fail`, `Warning`, or `Not Applicable`;
- confidence is upgraded above `Not Enough Evidence`;
- severity is assigned despite no confirmed finding;
- documentation is treated as implementation proof;
- missing evidence is hidden;
- a duplicate Architecture Testing, Hexagonal, Clean, DDD, or Layered finding repeats the same evidence gap;
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
| Input artifacts | Document fixture in sections 8 through 17 of this scenario. |
| Coverage dimensions | `SOL-001` insufficient-evidence coverage; Core catalog coverage; `Not Enough Evidence`; `Not Enough Evidence` confidence; no-finding severity absence; nominal evidence; undetermined applicability; false-positive protection; false-negative protection; Core x Solution boundary; Core x Architecture Testing boundary; partial scope; manual validation; deduplication. |
| Primary Rule normative file | `skill/rules/solution-architecture/SOL-001.md` |
| Supporting Rule | `skill/rules/testing/TEST-002.md` |
| Supporting Rule | `skill/rules/testing/TEST-003.md` |
| Supporting Rule | `skill/rules/testing/TEST-001.md` |
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

Initial concrete scenario for `EVAL-CORE-003`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity, selected Primary Rule `SOL-001`, and expected `Not Enough Evidence` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
