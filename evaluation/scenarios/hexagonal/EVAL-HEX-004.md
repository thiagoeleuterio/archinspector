# EVAL-HEX-004 - Port Exists Only in Documentation

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-HEX-004` |
| Title | `Port exists only in documentation` |
| Category | `Hexagonal Architecture` |
| Scenario Type | `Insufficient Evidence` |
| Catalogs | `Hexagonal Architecture`; boundary references to `Core` and `Clean Architecture` |
| Primary Rule | `HEX-004` |
| Supporting Rules | `HEX-006`, `HEX-007`, `CLEAN-009` |
| Risk Level | `Medium` |
| Execution Type | `Document Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/hexagonal/EVAL-HEX-004-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `HEX-004`; catalog coverage for Hexagonal Architecture; `Not Enough Evidence` outcome; `Not Enough Evidence` confidence; no-finding severity absence; nominal evidence; undetermined applicability; insufficient evidence; false-positive guard; false-negative guard; Hexagonal x Core boundary; Hexagonal x Clean boundary; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector does not accept a documented port as implemented architecture and does not report a confirmed violation when no implementation or dependency evidence is available.

The scenario protects insufficient-evidence handling, documentation-versus-implementation distinction, evidence discipline, false-positive control, false-negative control, boundary behavior, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Insufficient Evidence` |
| Secondary Types | `False Negative Guard`, `Partial Scope` |
| Primary Outcome | `Not Enough Evidence` |
| Evidence Strength | `Nominal` |
| Applicability | `Undetermined` |
| Confidence | `Not Enough Evidence` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious order-processing system described only through architecture documentation.

The reviewed scope contains a document declaring use of ports and adapters, a conceptual diagram with core, port, and adapter boxes, written intent about dependency inversion, and planned names for contracts and adapters. No interface, implementation, import list, dependency tree, composition evidence, configuration, source code, static analysis result, execution evidence, or tests are available.

The documentation is plausible, but it cannot prove that the core depends only on a port, that adapters implement the port, or that dependency direction is correct. It also cannot prove a violation. The risk remains open.

The description is technology-neutral. The scenario does not require any programming language, framework, database product, runtime, container, or executable fixture.

## 5. Target Catalogs

`Hexagonal Architecture` owns the scenario category because the evaluated condition is whether the application core uses outbound ports for external systems.

`Core` is a boundary reference because the scenario validates evidence-before-conclusion and unresolved-risk handling.

`Clean Architecture` is a boundary reference because documented gateway intent may be adjacent to Clean gateway isolation, but Clean findings must not duplicate the evidence gap.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `HEX-004` |
| Title | `Application core must use outbound ports for external systems` |
| Category | `Hexagonal Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/HEX-004.md` |
| Catalog File | `skill/rules/HEX_CATALOG.md` |

`HEX-004` is selected because it directly evaluates whether core outbound interactions depend on ports instead of concrete external systems. In this scenario, the only available material is documentation claiming such a port, so applicability and outcome must remain undetermined due to insufficient evidence.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `HEX-006` | Boundary reference for port ownership if a real port becomes observable. |
| `HEX-007` | Boundary reference for dependency direction if real dependencies become observable. |
| `CLEAN-009` | Cross-catalog boundary reference for Clean gateway isolation without duplicating the evidence gap. |

Supporting Rules may be used to explain missing evidence and expected non-findings. They must not convert documentation-only intent into confirmed compliance or confirmed violation.

## 8. Input Artifacts

The scenario input is a textual document fixture. It is not executable and must not be treated as compilable code.

The document fixture includes:

- architecture intent;
- conceptual diagram;
- planned port names;
- planned adapter names;
- planned responsibilities;
- intended dependency direction;
- policy statements for ports and adapters;
- explicit absence of implementation evidence.

## 9. Directory Structure

```text
planned-order-processing/
  core/       (documented)
  ports/      (documented)
  adapters/   (documented)
```

The directory names are documented labels only. They are not evidence of implemented modules, real ports, adapter implementations, or dependency direction.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `Order Core` | Planned owner of order behavior. | Described in documentation only. |
| `OrderStoragePort` | Planned outbound port. | Named in text and diagram only. |
| `DatabaseOrderAdapter` | Planned outbound adapter. | Shown as a diagram box only. |
| `Composition Boundary` | Planned wiring location. | Mentioned in text without structural evidence. |
| `Architecture Diagram` | Conceptual architecture picture. | Shows boxes and arrows but no real dependency graph. |
| `Ports Policy` | Written intent. | States that core should depend on ports. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `Order Core` | `OrderStoragePort` | Planned dependency | Documentation states intended dependency, but implementation is unavailable. |
| `DatabaseOrderAdapter` | `OrderStoragePort` | Planned implementation dependency | Documentation states intended direction, but no reference can be inspected. |
| `Composition Boundary` | `DatabaseOrderAdapter` | Planned composition dependency | Documentation states intended wiring, but no composition evidence exists. |
| `Architecture Diagram` | boxes and arrows | Conceptual diagram | Nominal planning evidence only. |

No real interface, implementation, import list, project reference, type dependency, constructor dependency, composition manifest, static analysis output, or execution evidence is provided.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Define order behavior | Application core | Planned in documentation only |
| Define outbound storage port | Application core | Planned in documentation only |
| Implement external storage | Outside adapter | Planned in documentation only |
| Compose concrete implementation | External composition boundary | Planned in documentation only |
| Prove core depends only on port | Structural evidence | Not provided |
| Prove adapter implements port | Structural evidence | Not provided |

## 13. Execution Flow

1. The document states that order behavior lives in the core.
2. The document states that the core uses `OrderStoragePort`.
3. The diagram shows `DatabaseOrderAdapter` outside the core.
4. The document states that the adapter implements the port.
5. The document states that composition wires the adapter externally.

The flow is intended behavior only. It cannot confirm pass or fail because no implementation, structural reference, composition evidence, or execution evidence is available.

## 14. Preconditions

- The evaluator receives the document fixture as the complete scenario input.
- The evaluator treats the document as reviewed material for document-based evaluation.
- The evaluator does not assume implementation files, dependency graphs, tests, runtime behavior, or hidden manifests.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is insufficient evidence.

The documented port is plausible, but no reviewed material proves that the port exists as an implemented contract, that the core depends on it, that the adapter implements it, or that composition happens outside the core. The correct result keeps both compliance and violation unconfirmed.

## 16. Evidence Provided

Nominal evidence is provided:

- architectural intent;
- conceptual diagram;
- planned port name;
- planned adapter name;
- planned responsibilities;
- intended dependencies;
- policy of ports and adapters;
- written statement of dependency inversion.

Short non-compilable documentation excerpt:

```text
Architecture intent:
  Order Core depends on OrderStoragePort.
  DatabaseOrderAdapter implements OrderStoragePort outside the core.
  Composition wires adapters externally.
  Dependency inversion is the intended policy.
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- real interface;
- real implementation;
- imports;
- references;
- dependency graph;
- compiled dependencies;
- composition code or manifest;
- configuration;
- source code;
- execution output;
- tests;
- static analysis output;
- package files;
- runtime logs.

Withheld evidence prevents confirmed findings about implementation conformance, implementation violation, dependency direction, framework leakage, Clean gateway isolation, Layered bypass, or adapter implementation.

## 18. Expected Findings

No confirmed violation finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: HEX-004
Outcome: Not Enough Evidence
Confidence: Not Enough Evidence
Severity: Not Applicable
Applicability: Undetermined
Evidence: Architecture intent, diagram, conceptual port name, planned responsibilities, intended dependency direction, and ports policy are available; implementation, dependency, composition, configuration, code, execution, tests, and static analysis evidence are unavailable.
Architectural Impact: The risk remains unresolved because the reviewed material cannot prove conformance or violation.
Rationale: Documentation alone cannot establish that the application core uses an implemented outbound port for external systems.
Remediation: Provide structural evidence such as real interfaces, implementation references, dependency graph, composition evidence, or source excerpts before confirming pass or fail.
Related Rules: HEX-006, HEX-007, CLEAN-009
Boundary Notes: The result concludes only that evidence is insufficient. It must not become a confirmed Hexagonal, Clean, Core, or Layered violation.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- core depending on adapter;
- absence of port;
- inside/outside boundary violation;
- framework leakage;
- Clean Architecture violation;
- Core violation;
- Layered bypass;
- absence of DDD;
- absence of architecture tests;
- absence of Repository Pattern;
- database product choice;
- use or absence of microservices.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `HEX-004` | `Undetermined` | `Not Enough Evidence` | `Match` |
| Scenario | `Undetermined` | `Not Enough Evidence` | `Match` |

## 21. Expected Confidence

Expected confidence is `Not Enough Evidence`.

The available material is documentation-only and nominal. It can identify architectural intent but cannot establish implementation state, dependency direction, port ownership, adapter implementation, or composition behavior.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No violation finding is confirmed, so no violation severity is assigned. The scenario risk level remains `Medium` as catalog coverage context, not as finding severity.

## 23. False Positive Guards

Do not:

- fail because the port is not proven;
- infer that implementation does not exist;
- fail based on adapter name;
- fail based on incomplete diagram;
- transform absence of evidence into violation;
- treat missing implementation files as proof of missing architecture.

Documentation incompleteness must remain insufficient evidence, not a confirmed violation.

## 24. False Negative Guards

Do not approve because:

- the diagram contains a hexagon;
- a box is called `Port`;
- documentation says `dependency inversion`;
- arrows are drawn correctly;
- intention sounds coherent;
- no violation evidence is visible.

The observed result must request structural evidence and keep risk unresolved.

## 25. Internal Boundary Expectations

`HEX-004` owns the primary result because the evaluated concern is core use of outbound ports for external systems.

Related Hexagonal rules may share evidence but must keep separate responsibilities:

- `HEX-006` would require real evidence of where the port is owned and how it is shaped;
- `HEX-007` would require real dependency direction evidence;
- `HEX-005` would require real adapter implementation evidence;
- `HEX-009` would require real persistence interaction evidence.

No Hexagonal violation or pass is confirmed.

## 26. Cross-Catalog Boundary Expectations

### Hexagonal x Core

Hexagonal evaluates inside/outside, ports, adapters, and dependency direction. Core review behavior validates evidence insufficiency and unresolved risk. Shared documentation evidence is permitted, but the same evidence gap must not produce duplicate findings.

Absence of implementation evidence must not become a generic Core violation.

### Hexagonal x Clean

Hexagonal evaluates outbound ports and adapters. Clean Architecture evaluates gateways and use case isolation under the policy-detail framing. A Clean finding is forbidden when it merely restates that the documented port is unproven.

Absence of formal Clean Architecture does not constitute a Hexagonal violation.

### Hexagonal x Layered

Hexagonal evaluates ports, adapters, and inside/outside direction. Layered Architecture evaluates dependencies and bypassing in an established layered structure. A Layered finding is forbidden because the scenario provides no real layered dependency path or bypass evidence.

## 27. Deduplication Expectations

| Shared Evidence | Hexagonal Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Diagram shows core, port, adapter | Evidence insufficient for `HEX-004` | Clean gateway compliance or violation may be suspected | Yes | Return `Not Enough Evidence`; no confirmed finding. |
| Documentation says dependency inversion | Intent only | Core or Clean approval may be suspected | Yes | Do not approve without structural evidence. |
| No implementation provided | Evidence gap | Absence-of-port violation may be suspected | Yes | Do not convert missing evidence into `Fail`. |
| Planned adapter name exists | Nominal evidence only | Layered persistence concern may be suspected | Yes | No neighboring finding. |

## 28. Expected Remediation

No corrective remediation is expected because no violation is confirmed.

Observed output may include a non-corrective evidence request:

- provide real interface or equivalent contract;
- provide implementation evidence;
- provide imports, references, or dependency graph;
- provide composition evidence;
- provide configuration evidence;
- provide source excerpts, execution evidence, tests, or static analysis output if available.

The remediation must not prescribe microservices, DDD, Clean Architecture, Hexagonal formalism, architecture tests, CI/CD, a tool, a framework, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences in wording;
- equivalent ordering of evidence gaps;
- equivalent non-corrective request for structural evidence;
- observation classified separately as non-corrective if the model distinguishes observations from findings;
- supporting Rule omission when it would be decorative;
- result status `Acceptable Variation` only when it preserves `Not Enough Evidence`, no confirmed finding, and unresolved risk.

## 30. Disallowed Variations

Disallowed variations:

- `Pass Confirmed`;
- `Fail Confirmed`;
- `Warning` as the primary result;
- confidence other than `Not Enough Evidence`;
- any confirmed violation finding;
- any confirmed compliance conclusion;
- severity assigned as if a violation exists;
- finding based only on documentation, names, or diagram boxes;
- duplicate finding;
- nonexistent Rule ID;
- non-Hexagonal Primary Rule;
- remediation requiring unrelated redesign, tooling, platform, formal architecture, or total rewrite.

## 31. Execution Instructions

Evaluate the document fixture statically.

Do not compile, run, generate, or infer executable fixture code. Treat the documentation excerpt as non-compilable evidence of intent only. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/hexagonal/EVAL-HEX-004-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `HEX-004` is evaluated as `Undetermined`;
- primary outcome is `Not Enough Evidence`;
- confidence is `Not Enough Evidence`;
- severity is `Not Applicable`;
- no confirmed violation finding appears;
- no confirmed compliance conclusion appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Hexagonal x Core, Hexagonal x Clean, and Hexagonal x Layered boundaries are respected;
- duplicate findings are absent;
- evidence request is proportional and non-corrective;
- observed result comparison against `evaluation/expected/hexagonal/EVAL-HEX-004-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- a confirmed violation finding appears;
- outcome is `Pass`, `Fail`, `Warning`, or `Not Applicable`;
- confidence is upgraded above `Not Enough Evidence`;
- severity is assigned despite no confirmed finding;
- documentation is treated as implementation proof;
- missing evidence is hidden;
- a duplicate Hexagonal, Clean, Core, or Layered finding repeats the same evidence gap;
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
| Coverage dimensions | `HEX-004` insufficient-evidence coverage; Hexagonal catalog coverage; `Not Enough Evidence`; `Not Enough Evidence` confidence; no-finding severity absence; nominal evidence; undetermined applicability; false-positive protection; false-negative protection; Hexagonal x Core boundary; Hexagonal x Clean boundary; partial scope; deduplication. |
| Primary Rule catalog | `skill/rules/HEX_CATALOG.md` |
| Primary Rule normative file | `skill/rules/HEX-004.md` |
| Supporting Rule | `skill/rules/HEX-006.md` |
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

Initial concrete scenario for `EVAL-HEX-004`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity, selected Primary Rule `HEX-004`, and expected `Not Enough Evidence` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
