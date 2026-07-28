# EVAL-LAYER-004 - Layer Names Exist Without Observable Dependency Information

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-LAYER-004` |
| Title | `Layer names exist without observable dependency information` |
| Category | `Layered Architecture` |
| Scenario Type | `Insufficient Evidence` |
| Catalogs | `Layered Architecture` |
| Primary Rule | `LAYER-002` |
| Supporting Rules | `LAYER-001`, `LAYER-003`, `LAYER-008` |
| Risk Level | `Medium` |
| Execution Type | `Document Fixture` |
| Status | `Ready` |
| Priority | `P2` |
| Implementation Order | `22` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/layered/EVAL-LAYER-004-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `LAYER-002`; catalog coverage for Layered Architecture; `Not Enough Evidence` outcome; `Not Enough Evidence` confidence; nominal evidence; undetermined applicability; naming-only false-positive protection; false-negative protection; partial scope; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector returns `Not Enough Evidence` when layer-like names and documentation exist without observable dependency, responsibility, call-flow, or behavior evidence.

The scenario protects naming-only false-positive control, false-negative control for missing implementation evidence, partial-scope reporting, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Insufficient Evidence` |
| Secondary Types | `Partial Scope` |
| Primary Outcome | `Not Enough Evidence` |
| Evidence Strength | `Nominal` |
| Applicability | `Undetermined` |
| Confidence | `Not Enough Evidence` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious order-processing system described only through documentation.

The reviewed scope contains labels named Presentation, Application, Domain, and Infrastructure, plus a diagram saying dependencies should flow downward through those labels. No imports, project references, type dependencies, constructor dependencies, call sequences, method behavior, contracts, source excerpts, composition evidence, tests, static analysis output, or runtime traces are available.

The documentation may describe a valid layered intent, but it cannot prove responsibility consistency, dependency direction, required mediation, bypass, persistence placement, or business rule ownership. The correct result keeps the architecture question unresolved.

## 5. Target Catalogs

`Layered Architecture` owns the scenario category because the evaluated condition is whether identified layers have explicit and consistent responsibilities.

No additional primary catalog is needed. Related Layered rules explain missing decision, dependency, and bypass evidence but must not convert names into confirmed findings.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `LAYER-002` |
| Title | `Layers must have explicit and consistent responsibilities` |
| Category | `Layered Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/layered/LAYER-002.md` |
| Catalog File | `skill/rules/LAYER_CATALOG.md` |

`LAYER-002` is selected because it is the Layered rule that evaluates whether layer responsibilities are explicit and consistent. In this scenario, only labels and intent are available, so applicability and outcome remain undetermined due to insufficient evidence.

`LAYER-001`, `LAYER-003`, and `LAYER-008` are supporting rules because their decision-control, dependency-direction, and bypass evidence is also unavailable.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `LAYER-001` | Boundary reference for missing business-policy decision control evidence. |
| `LAYER-003` | Boundary reference for missing dependency direction evidence. |
| `LAYER-008` | Boundary reference for missing required-mediation and bypass evidence. |

Supporting Rules may be used to explain evidence gaps and expected non-findings. They must not turn layer names into confirmed conclusions.

## 8. Input Artifacts

The scenario input is a textual document fixture. It is not executable and must not be treated as compilable code.

The document fixture includes:

- layer-name list;
- conceptual diagram;
- planned responsibilities;
- intended dependency policy;
- explicit absence of implementation evidence;
- explicit absence of dependency graph;
- explicit absence of call-flow evidence.

## 9. Directory Structure

```text
planned-order-processing/
  presentation/      (documented label only)
  application/       (documented label only)
  domain/            (documented label only)
  infrastructure/    (documented label only)
```

The directory names are nominal evidence only. They are not proof of implemented layer responsibilities or dependencies.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `Presentation` label | Claimed interaction layer. | Documentation label only. |
| `Application` label | Claimed coordination layer. | Documentation label only. |
| `Domain` label | Claimed business layer. | Documentation label only. |
| `Infrastructure` label | Claimed technical detail layer. | Documentation label only. |
| `Layer Diagram` | Conceptual architecture picture. | Boxes and arrows without implementation references. |
| `Architecture Note` | Stated intent. | Says dependencies should follow layers, but provides no structural evidence. |

No concrete type, module reference, import, call, contract, implementation, or behavior is provided.

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `Presentation` | `Application` | Planned dependency | Documentation-only statement. |
| `Application` | `Domain` | Planned dependency | Documentation-only statement. |
| `Application` | `Infrastructure` | Planned dependency | Documentation-only statement. |
| Layer diagram | arrows | Conceptual diagram | Nominal planning evidence only. |

No real dependency graph, source dependency, project reference, package reference, constructor dependency, method signature, or code excerpt is provided.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Prove presentation responsibility | Implementation or structural evidence | Not provided |
| Prove application coordination | Implementation or behavioral evidence | Not provided |
| Prove domain business rules | Implementation or behavioral evidence | Not provided |
| Prove infrastructure detail isolation | Dependency and behavior evidence | Not provided |
| Prove responsibilities are consistent | Comparative evidence | Not provided |

## 13. Execution Flow

1. The document lists layer names.
2. The diagram shows intended dependency arrows.
3. The note states that responsibilities should be separated.
4. The document provides no actual references, imports, contracts, calls, or behavior.

The flow is naming and intent evidence only. It cannot confirm pass or fail.

## 14. Preconditions

- The evaluator receives the document fixture as the complete scenario input.
- The evaluator treats the document as reviewed material for document-based evaluation.
- The evaluator does not assume implementation files, dependency graphs, tests, runtime behavior, or hidden manifests.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is insufficient evidence.

Layer names suggest Layered Architecture intent, but no reviewed material proves responsibility consistency, contradiction, dependency direction, or bypass. Both conformance and violation remain unconfirmed.

## 16. Evidence Provided

Nominal evidence is provided:

- layer-like labels;
- conceptual diagram;
- planned responsibility labels;
- intended dependency policy;
- architecture intent note;
- explicit absence of implementation and dependency evidence.

Short non-compilable documentation excerpt:

```text
Architecture intent:
  presentation -> application -> domain
  application -> infrastructure for technical details
  layer responsibilities should remain separated
  implementation dependency graph: unavailable
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- real source files;
- project or module references;
- imports;
- type dependencies;
- constructor dependencies;
- method signatures;
- call sequences;
- contracts;
- composition evidence;
- persistence behavior;
- business rule behavior;
- static analysis output;
- automated test outputs;
- runtime logs.

Withheld evidence prevents confirmed findings about layer responsibility consistency, dependency direction, lower-level policy control, bypass, persistence placement, Clean Architecture, Hexagonal Architecture, DDD, Fowler patterns, or architecture testing.

## 18. Expected Findings

No confirmed violation finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: LAYER-002
Outcome: Not Enough Evidence
Confidence: Not Enough Evidence
Severity: Not Applicable
Applicability: Undetermined
Evidence: Layer names, a conceptual diagram, planned responsibilities, and intended dependency policy are available; implementation, dependency, contract, call-flow, behavior, test, and static analysis evidence are unavailable.
Architectural Impact: The risk remains unresolved because naming and documentation alone cannot prove responsibility consistency or violation.
Responsibility Impact: Layer responsibilities are claimed but not observable.
Dependency Impact: Dependency direction and bypass cannot be evaluated from the provided material.
Rationale: LAYER-002 requires more than names or stated intent to confirm pass or fail.
Remediation: Provide structural evidence such as dependency graph, module references, contracts, representative source excerpts, call flows, or architecture-test output before confirming conformance or violation.
Related Rules: LAYER-001, LAYER-003, LAYER-008
Boundary Notes: The result concludes only that evidence is insufficient. It must not become a confirmed Layered, Clean, Hexagonal, Core, DDD, or Fowler finding.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- Layered Architecture conformance;
- Layered Architecture violation;
- dependency direction violation;
- required layer bypass;
- lower-level control over business policy;
- presentation behavior ownership;
- application business-rule ownership;
- persistence placement violation;
- Clean Architecture violation;
- Hexagonal Architecture violation;
- DDD absence;
- Fowler pattern issue;
- absence of exactly four layers;
- absence of separate projects;
- monolithic deployment;
- directory naming style;
- absence of architecture tests.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `LAYER-002` | `Undetermined` | `Not Enough Evidence` | `Match` |
| Scenario | `Undetermined` | `Not Enough Evidence` | `Match` |

## 21. Expected Confidence

Expected confidence is `Not Enough Evidence`.

The available material is naming-only and documentation-only. It can identify possible architectural intent but cannot establish structure, responsibilities, dependencies, contracts, or behavior placement.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No violation finding is confirmed, so no violation severity is assigned. The scenario risk level remains `Medium` as catalog coverage context.

## 23. False Positive Guards

Do not:

- fail based on layer names;
- fail because dependency evidence is missing;
- infer that implementation violates Layered Architecture;
- treat missing graph as proof of wrong direction;
- require exactly four layers;
- require separate projects;
- convert absence of evidence into violation.

Documentation incompleteness must remain insufficient evidence.

## 24. False Negative Guards

Do not approve because:

- folders are named like layers;
- documentation says responsibilities are separated;
- arrows are drawn in a plausible order;
- no violation evidence is visible;
- the system might be a monolith and still layered.

The observed result must request structural evidence and keep risk unresolved.

## 25. Internal Boundary Expectations

`LAYER-002` owns the primary result because the evaluated concern is explicit and consistent responsibilities.

Related Layered rules may share evidence gaps:

- `LAYER-001` would require business decision control evidence;
- `LAYER-003` would require dependency direction evidence;
- `LAYER-008` would require mandatory mediation and interaction-path evidence.

No Layered pass or violation is confirmed.

## 26. Cross-Catalog Boundary Expectations

### Layered x Clean Architecture

Clean Architecture evaluates policy boundaries, use cases, and source dependency direction. Layer names do not prove Clean conformance or violation.

### Layered x Hexagonal Architecture

Hexagonal Architecture evaluates ports, adapters, inside/outside boundaries, and core isolation. Layer names do not prove ports or adapters.

### Layered x Core

Core review behavior validates evidence-before-conclusion and unresolved-risk handling. No generic Core finding is allowed for the same evidence gap.

### Layered x Fowler

Fowler evaluates enterprise application patterns from behavior and responsibility evidence. Pattern inference from class or layer names alone is forbidden.

## 27. Deduplication Expectations

| Shared Evidence | Layered Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Layer labels exist | Evidence insufficient for `LAYER-002` | Clean or Hexagonal conformance may be suspected | Yes | Return `Not Enough Evidence`; no confirmed finding. |
| Diagram arrows show intended direction | Intent only | `LAYER-003` pass may be suspected | Yes | Do not approve without dependency graph. |
| Dependency graph unavailable | Evidence gap | Direction violation may be suspected | Yes | Do not convert missing evidence into `Fail`. |
| No implementation provided | Evidence gap | DDD, Fowler, or testing findings may be suspected | Yes | No neighboring finding. |

## 28. Expected Remediation

No corrective remediation is expected because no violation is confirmed.

Observed output may include a non-corrective evidence request:

- provide dependency graph or module references;
- provide representative source excerpts;
- provide contracts and call flows;
- provide responsibility inventories tied to implementation;
- provide static analysis or architecture-test output if available.

The remediation must not prescribe Clean Architecture, Hexagonal Architecture, DDD, microservices, architecture tests, CI/CD, a framework, folder names, project splits, or rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences;
- equivalent evidence-gap ordering;
- equivalent non-corrective request for structural evidence;
- observation classified separately as non-corrective if not a finding;
- supporting Rule omission when decorative;
- result status `Acceptable Variation` only when it preserves `Not Enough Evidence`, no confirmed finding, and unresolved risk.

## 30. Disallowed Variations

Disallowed variations:

- title different from the catalog;
- category different from the catalog;
- Primary Rule changed away from `LAYER-002`;
- `Pass Confirmed`;
- `Fail Confirmed`;
- `Warning` as the primary result;
- confidence other than `Not Enough Evidence`;
- any confirmed violation finding;
- any confirmed compliance conclusion;
- severity assigned as if a violation exists;
- finding based only on documentation, names, or diagram boxes;
- duplicate finding;
- remediation requiring unrelated redesign, tooling, platform, formal architecture, or rewrite.

## 31. Execution Instructions

Evaluate the document fixture statically.

Do not compile, run, generate, or infer executable fixture code. Treat the documentation excerpt as non-compilable evidence of intent only. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/layered/EVAL-LAYER-004-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `LAYER-002` is evaluated as `Undetermined`;
- primary outcome is `Not Enough Evidence`;
- confidence is `Not Enough Evidence`;
- severity is `Not Applicable`;
- no confirmed violation finding appears;
- no confirmed compliance conclusion appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- internal Layered boundaries are respected;
- Layered x Clean, Layered x Hexagonal, Layered x Core, and Layered x Fowler boundaries are respected;
- duplicate findings are absent;
- evidence request is proportional and non-corrective;
- observed result comparison against `evaluation/expected/layered/EVAL-LAYER-004-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- a confirmed violation finding appears;
- outcome is `Pass`, `Fail`, `Warning`, or `Not Applicable`;
- confidence is upgraded above `Not Enough Evidence`;
- severity is assigned despite no confirmed finding;
- names are treated as implementation proof;
- missing evidence is hidden;
- duplicate Layered, Clean, Hexagonal, Core, DDD, Fowler, or Testing findings repeat the same evidence gap;
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
| Coverage dimensions | `LAYER-002` insufficient-evidence coverage; Layered catalog coverage; `Not Enough Evidence`; `Not Enough Evidence` confidence; no-finding severity absence; nominal evidence; undetermined applicability; naming-only false-positive protection; false-negative protection; partial scope; internal Layered boundary; deduplication. |
| Primary Rule catalog | `skill/rules/LAYER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/layered/LAYER-002.md` |
| Supporting Rule | `skill/rules/layered/LAYER-001.md` |
| Supporting Rule | `skill/rules/layered/LAYER-003.md` |
| Supporting Rule | `skill/rules/layered/LAYER-008.md` |
| Layered catalog review | `skill/reviews/LAYER_CATALOG_REVIEW.md` |
| Layered catalog stabilization | `skill/reviews/LAYER_CATALOG_STABILIZATION.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Fowler boundary review | `skill/reviews/FOWLER_CATALOG_REVIEW.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Gold Standard stabilization | `evaluation/stabilizations/EVAL-CORE-001-STABILIZATION.md` |

## 35. Gold Standard Requirements

This scenario follows the stabilized Gold Standard reference for structure, identity, evidence strength, atomicity, outcomes, confidence, severity, finding specificity, remediation proportionality, expected non-findings, false-positive protection, false-negative protection, cross-catalog boundaries, deduplication, and expected result traceability.

It must not introduce requirements outside the Evaluation Suite models or redefine existing Rules.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-LAYER-004`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `LAYER-002`, selected Supporting Rules, and expected `Not Enough Evidence` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
