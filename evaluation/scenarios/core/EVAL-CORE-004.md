# EVAL-CORE-004 - Small Temporary Component Without Formal Modular Constraints

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CORE-004` |
| Title | `Small temporary component without formal modular constraints` |
| Category | `Core` |
| Scenario Type | `Legitimate Absence` |
| Catalogs | `Core`; boundary references to `Architecture Testing` and `Solution Architecture` |
| Primary Rule | `TEST-020` |
| Supporting Rules | `SOL-001`, `TEST-001`, `TEST-018` |
| Risk Level | `Low` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P2` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/core/EVAL-CORE-004-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `TEST-020`; catalog coverage for Core, Architecture Testing, and Solution Architecture; `Not Applicable` outcome; `Confirmed` confidence; contextual absence of severity; partial evidence; legitimate absence; false-positive guard; false-negative guard; applicability boundary; proportionality; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector recognizes legitimate absence of formal modular constraints for a small, temporary, low-risk component and does not require disproportionate architecture validation.

The scenario protects legitimate absence, proportional reporting, false-positive control, false-negative control, boundary behavior, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Legitimate Absence` |
| Secondary Types | `False Positive Guard`, `Manual Validation` |
| Primary Outcome | `Not Applicable` |
| Evidence Strength | `Partial` |
| Applicability | `Not Applicable` |
| Confidence | `Confirmed` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious temporary component that imports one small legacy data extract, normalizes a local file, and produces a one-time summary for an internal migration team.

The reviewed scope contains a single-purpose component with a documented two-week lifetime, low operational risk, no critical external integration, no complex domain model, no regulatory impact, explicit owner, limited usage, and a discard or replacement plan. It uses simple local helper dependencies inside the same component boundary.

There is no evidence of hidden complexity, critical infrastructure dependency, multiple bounded contexts, high-volume operation, indefinite lifetime, critical integration, unavoidable growth, or regulatory exposure.

The description is technology-neutral. The scenario does not require any programming language, framework, database product, runtime, or executable fixture.

## 5. Target Catalogs

`Core` owns the scenario category because the scenario validates central ArchInspector behavior: legitimate absence, proportionality, avoidance of overengineering, evidence before conclusion, and expected non-findings.

The repository does not define a `CORE-*` Rule prefix. `evaluation/SCENARIO_CATALOG.md` states that Core scenarios target existing Rules whose responsibilities exercise Core review behavior.

`Architecture Testing` is a boundary reference because `TEST-020` is the existing Rule selected by the scenario catalog for this scenario.

`Solution Architecture` is a boundary reference because documented ownership, lifetime, constraints, and replacement plan support proportional applicability, but solution-level rules must not turn simple context into a formal architecture requirement.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `TEST-020` |
| Title | `Automated and manual validation balance` |
| Category | `Architecture Testing` |
| Status | `Active` |
| Normative File | `skill/rules/testing/TEST-020.md` |
| Catalog File | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |

`TEST-020` is selected because it explicitly supports contextual balance between automated and manual validation and allows `Not Applicable` when no recurring validation is needed, one mechanism is deliberately sufficient, or legitimate absence occurs in small, temporary, low-risk systems.

The selected result is Option A: `Applicability` is `Not Applicable`, `Outcome` is `Not Applicable`, and `Confidence` is `Confirmed`. The scenario confirms that recurring architecture validation balance is outside the reviewed context because the component is small, temporary, low risk, manually owned, and scheduled for disposal.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `SOL-001` | Boundary reference for documented requirements, constraints, ownership, lifetime, and discard plan. |
| `TEST-001` | Boundary reference for absence of a declared fitness function or architecture control claim. |
| `TEST-018` | Boundary reference for absence of recurring pipeline execution need in a low-risk temporary context. |

Supporting Rules may be used to explain proportionality and expected non-findings. They must not duplicate the Primary Rule conclusion or require architecture testing where no recurring validation need exists.

## 8. Input Artifacts

The scenario input is a textual static manifest. It is not executable and must not be treated as compilable code.

The manifest includes:

- component scope;
- component lifetime;
- owner and usage limit;
- responsibility inventory;
- dependency inventory;
- risk statement;
- discard plan;
- explicit absence of complex or critical conditions;
- short pseudocode excerpts.

## 9. Directory Structure

```text
temporary-import-summary/
  ImportSummaryTask
  LocalCsvReader
  SummaryFormatter
  DisposalNote
```

The directory names are supporting context only. The expected result must depend on scope, lifetime, ownership, risk, and absence of recurring validation need, not on names alone.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `ImportSummaryTask` | Single temporary workflow. | Reads local extract, normalizes rows, produces internal summary. |
| `LocalCsvReader` | Local helper. | Reads one provided local file format; no critical external integration. |
| `SummaryFormatter` | Local helper. | Formats non-regulatory internal output. |
| `DisposalNote` | Lifecycle note. | States removal after migration validation window. |
| `MigrationOpsOwner` | Ownership marker. | Identifies owner and limited support period. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `ImportSummaryTask` | `LocalCsvReader` | Local helper dependency | Simple dependency inside one temporary component boundary. |
| `ImportSummaryTask` | `SummaryFormatter` | Local helper dependency | Local formatting collaboration for one responsibility. |
| `DisposalNote` | `MigrationOpsOwner` | Ownership and lifecycle reference | Documents owner and discard plan. |

No dependency is provided to critical infrastructure, external service clients, production persistence mechanisms, regulated data gateways, message brokers, or long-lived platform APIs.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Read local migration extract | Temporary component | `LocalCsvReader` |
| Normalize simple rows | Temporary component | `ImportSummaryTask` |
| Produce internal summary | Temporary component | `SummaryFormatter` |
| Own support and removal | Migration owner | `MigrationOpsOwner` and `DisposalNote` |
| Define recurring architecture validation | Not required for this context | Legitimately absent |
| Define formal modules, ports, adapters, or layered constraints | Not required for this context | Legitimately absent |

## 13. Execution Flow

1. `MigrationOpsOwner` triggers the temporary import summary manually during the migration window.
2. `ImportSummaryTask` reads a local file through `LocalCsvReader`.
3. `ImportSummaryTask` normalizes simple rows.
4. `SummaryFormatter` creates an internal non-regulatory summary.
5. `DisposalNote` requires removal or replacement after the migration validation window.

The legitimate absence is present because recurring architectural validation and formal modular constraints are disproportionate for the documented scope, duration, and risk.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is legitimate absence.

The reviewed material confirms a small, temporary, low-risk component with one responsibility, local dependencies, explicit ownership, limited use, and a discard plan. Formal modular constraints and recurring architecture validation are not required by the provided context.

## 16. Evidence Provided

Partial but sufficient contextual evidence is provided:

- small scope: one temporary import summary workflow;
- temporary duration: documented two-week migration validation window;
- single responsibility: read local extract, normalize rows, produce summary;
- low risk: internal non-regulatory output;
- no critical integration: only local file input;
- no complex domain: simple row normalization;
- local dependencies only: `LocalCsvReader` and `SummaryFormatter`;
- ownership: `MigrationOpsOwner`;
- usage limit: migration team only;
- discard plan: removal or replacement after validation window.

Short non-compilable pseudocode:

```text
component ImportSummaryTask
  uses LocalCsvReader
  uses SummaryFormatter

  runOnce(localExtract)
    rows = LocalCsvReader.read(localExtract)
    normalized = normalize simple migration rows
    return SummaryFormatter.internalSummary(normalized)

component DisposalNote
  owner MigrationOpsOwner
  remove after two-week validation window
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- executable fixture files;
- compilable source code;
- concrete language syntax;
- framework annotations;
- package files;
- build outputs;
- automated test outputs;
- runtime logs;
- architecture diagrams beyond the manifest;
- formal modular architecture definition;
- architecture-test suite;
- CI/CD configuration;
- microservice deployment topology.

Withheld evidence prevents findings about executable correctness, test implementation quality, runtime behavior, formal architecture adoption, or delivery pipeline configuration.

## 18. Expected Findings

No corrective finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: TEST-020
Outcome: Not Applicable
Confidence: Confirmed
Severity: Not Applicable
Applicability: Not Applicable
Evidence: The component is small, temporary, low-risk, manually owned, limited to local input and internal summary output, has a discard plan, and has no recurring architectural validation need.
Architectural Impact: No corrective impact is present because formal validation balance is outside the reviewed context.
Rationale: TEST-020 Not Applicable conditions are satisfied by confirmed legitimate absence in a small, temporary, low-risk component.
Remediation: None.
Related Rules: SOL-001, TEST-001, TEST-018
Boundary Notes: The result concludes only that recurring automated/manual architecture validation balance is not applicable. It must not become a general approval of all architecture or hide future evidence of complexity or risk.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- absence of formal Hexagonal Architecture;
- absence of Clean Architecture;
- absence of DDD;
- absence of formal layers;
- absence of interfaces;
- absence of ports;
- absence of adapters;
- absence of microservices;
- absence of messaging;
- absence of architecture tests;
- absence of Domain Model;
- absence of advanced modularization;
- simple file count;
- monolithic structure;
- lack of CI/CD;
- lack of cloud deployment;
- lack of architecture testing tool.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `TEST-020` | `Not Applicable` | `Not Applicable` | `Match` |
| Scenario | `Not Applicable` | `Not Applicable` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed`.

The provided evidence confirms the contextual non-applicability of recurring architecture validation balance: small scope, temporary duration, low risk, local dependencies, ownership, usage limit, and discard plan.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No finding is required, so no violation severity is assigned. The scenario risk level remains `Low` as catalog coverage context, not as finding severity.

## 23. False Positive Guards

Do not report a finding based only on:

- absence of multiple modules;
- absence of interfaces;
- absence of layers;
- absence of ports;
- absence of adapters;
- absence of DDD;
- absence of architecture tests;
- absence of microservices;
- simple structure;
- small file count;
- monolithic deployment;
- manual validation.

Simplicity is legitimate because scope, duration, risk, ownership, and discard plan are explicit.

## 24. False Negative Guards

Do not use temporary status to approve automatically when evidence shows:

- indefinite duration;
- uncontrolled growth;
- critical dependency;
- complex domain behavior;
- multiple responsibilities;
- missing ownership;
- missing discard plan;
- material operational risk;
- regulatory impact;
- critical external integration;
- high volume;
- known unavoidable expansion.

The scenario makes temporary status evidence-based, not a naming excuse.

## 25. Internal Boundary Expectations

`TEST-020` owns the primary result because the evaluated condition is whether automated and manual validation mechanisms are proportionate and applicable in context.

Related Architecture Testing rules may share evidence but must keep separate responsibilities:

- `TEST-001` would require a declared fitness function or equivalent architectural control;
- `TEST-018` would require a relevant execution point for an existing or needed verification;
- `TEST-019` would require maintainability risk in a verification mechanism.

No additional Architecture Testing finding is required because recurring validation is legitimately outside this context.

## 26. Cross-Catalog Boundary Expectations

### Core x Architecture Testing

Core scenario behavior is validated through the existing `TEST-020` Rule because no `CORE-*` Rule prefix exists. The Core concern is proportionality and legitimate absence. The Architecture Testing Rule owns the validation-balance applicability condition.

Absence of architecture tests, CI/CD, or automation is not a violation in this context.

### Core x Solution Architecture

Solution Architecture may provide context through documented ownership, lifetime, constraints, usage limits, and discard plan. It must not require formal module structures, additional projects, microservices, or solution redesign without evidence of scale or risk.

Absence of formal modular architecture is not a violation.

## 27. Deduplication Expectations

Shared evidence is allowed.

Duplicate conclusions are not allowed.

Findings are forbidden when they only rephrase legitimate simplicity under:

- `SOL-001`;
- `TEST-001`;
- `TEST-018`;
- `TEST-019`;
- `LAYER-002`;
- `DDD-013`;
- `HEX-001`;
- `CLEAN-004`.

Separate findings are allowed only when future observed material identifies exclusive evidence beyond the provided temporary, low-risk scope.

## 28. Expected Remediation

No corrective remediation is expected.

Observed output may state that no remediation is required for the Primary Rule. It may suggest preserving owner, lifetime, usage limit, and discard plan visibility, but it must not prescribe architecture tests, automation, ports, adapters, layers, DDD, microservices, CI/CD, cloud, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences in wording;
- equivalent ordering of contextual evidence;
- equivalent technology-neutral explanation of legitimate absence;
- supporting Rule omission when it would be decorative;
- result status `Acceptable Variation` only when it preserves `Not Applicable`, `Confirmed`, no finding, and proportionality;
- `Pass` only if an observed result explicitly interprets `TEST-020` as satisfied by a deliberate lightweight manual validation strategy without requiring formalism.

## 30. Disallowed Variations

Disallowed variations:

- `Fail`;
- `Warning` based only on simplicity;
- `Not Enough Evidence` when the provided contextual evidence is used;
- confidence below `Confirmed` for contextual non-applicability;
- any corrective finding;
- severity other than `Not Applicable` for the no-finding Primary result;
- finding based only on naming or small size;
- duplicate finding;
- nonexistent Rule ID;
- Primary Rule changed away from `TEST-020`;
- requirement for DDD, formal Clean Architecture, formal Hexagonal Architecture, microservices, CI/CD, cloud, or architecture tests.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat the pseudocode as non-compilable evidence of structure and context. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/core/EVAL-CORE-004-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `TEST-020` is evaluated as `Not Applicable`;
- primary outcome is `Not Applicable`;
- confidence is `Confirmed`;
- severity is `Not Applicable`;
- no corrective finding appears;
- no warning appears merely because the structure is simple;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Core x Architecture Testing and Core x Solution Architecture boundaries are respected;
- duplicate findings are absent;
- remediation is absent or explicitly non-corrective;
- observed result comparison against `evaluation/expected/core/EVAL-CORE-004-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- any corrective finding appears;
- outcome is `Fail`, `Warning`, or unsupported `Not Enough Evidence`;
- confidence contradicts the contextual evidence;
- severity is assigned despite no finding;
- simplicity is treated as a violation;
- temporary status is accepted without ownership, lifetime, usage limit, and discard-plan evidence;
- a duplicate Solution, Layered, DDD, Clean, Hexagonal, or Architecture Testing finding repeats the same conclusion;
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
| Coverage dimensions | `TEST-020` legitimate absence coverage; Core catalog coverage; `Not Applicable`; `Confirmed`; no-finding severity absence; partial evidence; applicability; false-positive protection; false-negative protection; Core x Architecture Testing boundary; Core x Solution boundary; proportionality; deduplication. |
| Primary Rule catalog | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |
| Primary Rule normative file | `skill/rules/testing/TEST-020.md` |
| Supporting Rule | `skill/rules/solution-architecture/SOL-001.md` |
| Supporting Rule | `skill/rules/testing/TEST-001.md` |
| Supporting Rule | `skill/rules/testing/TEST-018.md` |
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

Initial concrete scenario for `EVAL-CORE-004`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity, selected Primary Rule `TEST-020`, and expected `Not Applicable` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
