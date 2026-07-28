# EVAL-LAYER-001 - Presentation Layer Accesses Persistence Directly

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-LAYER-001` |
| Title | `Presentation layer accesses persistence directly` |
| Category | `Layered Architecture` |
| Scenario Type | `Confirmed Violation` |
| Catalogs | `Layered Architecture`; boundary references to `Clean Architecture` |
| Primary Rule | `LAYER-008` |
| Supporting Rules | `LAYER-003`, `LAYER-004`, `LAYER-007` |
| Risk Level | `High` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Implementation Order | `19` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/layered/EVAL-LAYER-001-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `LAYER-008`; catalog coverage for Layered Architecture; `Fail` outcome; `Confirmed` confidence; contextual `High` severity; strong evidence; applicability; false-positive guard; false-negative guard; Clean x Layered boundary; internal Layered boundary; deduplication; remediation. |

## 2. Purpose

This scenario validates that ArchInspector reports a confirmed Layered Architecture violation when a presentation component directly accesses persistence and skips the required application mediation layer.

The scenario protects bypass detection, evidence discipline, atomic findings, proportional remediation, false-positive control, false-negative control, Layered x Clean boundary behavior, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Confirmed Violation` |
| Secondary Types | `False Negative Guard`, `Internal Boundary` |
| Primary Outcome | `Fail` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Confirmed` |
| Severity | `High` |

## 4. Architectural Context

The evaluated system is a fictitious order-processing administration system.

The reviewed scope identifies Presentation, Application, Domain, and Persistence responsibilities. The declared interaction policy states that Presentation must call Application workflows for order lookup and update operations, and Application mediates validation, authorization context, transaction boundary selection, and persistence access through a data access component.

The provided manifest shows an order screen handler directly referencing `OrderSqlTable`, constructing a query object, and reading and updating order records without calling `OrderApplicationService`. The bypass is not inferred from folder names. It is shown by direct reference, direct call flow, skipped mediation, and persistence behavior inside the presentation interaction.

The description is technology-neutral. The scenario does not require any programming language, web framework, database product, ORM, runtime, or executable fixture.

## 5. Target Catalogs

`Layered Architecture` owns the scenario category because the evaluated condition is whether an identified layer interaction skips required intermediate layer mediation.

`Clean Architecture` is a boundary reference because the same evidence might resemble controller or use case isolation concerns, but Clean findings must not duplicate the Layered bypass conclusion without Clean-specific use case boundary evidence.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `LAYER-008` |
| Title | `Layers must not bypass required intermediate layers` |
| Category | `Layered Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/layered/LAYER-008.md` |
| Catalog File | `skill/rules/LAYER_CATALOG.md` |

`LAYER-008` is selected because it directly evaluates whether an interaction skips required intermediate mediation in an identified layered structure. The scenario provides Presentation, Application, Domain, and Persistence responsibilities, an explicit mediation requirement, and direct Presentation-to-Persistence access.

`LAYER-003`, `LAYER-004`, and `LAYER-007` are related but not primary. Dependency direction, presentation behavior ownership, and persistence placement may share evidence, but the cataloged architectural question is the bypass of required Application mediation.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `LAYER-003` | Boundary reference for dependency direction without duplicating the bypass conclusion. |
| `LAYER-004` | Boundary reference for presentation responsibility without turning the scenario into a broad presentation-behavior finding. |
| `LAYER-007` | Boundary reference for persistence access placement without duplicating direct bypass evidence. |

Supporting Rules may explain related responsibilities and forbidden duplicate findings. They must not replace `LAYER-008` as Primary Rule.

## 8. Input Artifacts

The scenario input is a textual static manifest. It is not executable and must not be treated as compilable code.

The manifest includes:

- directory structure;
- layer map;
- component inventory;
- dependency inventory;
- responsibility inventory;
- execution flow;
- observable evidence;
- short pseudocode excerpts;
- explicit withheld material.

## 9. Directory Structure

```text
order-admin/
  presentation/
    OrderDetailsScreen
  application/
    OrderApplicationService
  domain/
    OrderPolicy
  persistence/
    OrderSqlTable
    OrderRecordMapper
```

Directory names are supporting context only. The required finding must depend on the explicit dependency and call evidence below.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `OrderDetailsScreen` | Presentation interaction handler. | Directly references persistence table and performs query/update behavior. |
| `OrderApplicationService` | Required application mediator. | Declared as the required entry for order lookup and update workflows. |
| `OrderPolicy` | Domain/business rule owner. | Provides order edit permission and status rules when reached through Application. |
| `OrderSqlTable` | Persistence mechanism. | Concrete data access surface directly called by Presentation. |
| `OrderRecordMapper` | Persistence mapping detail. | Used by the persistence table, not required by Presentation. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `OrderDetailsScreen` | `OrderSqlTable` | Direct reference or import | Presentation directly knows a persistence component. |
| `OrderDetailsScreen` | persistence query/update | Method behavior | Presentation reads and updates stored order state. |
| `OrderDetailsScreen` | `OrderApplicationService` | Required but absent delegation | Required intermediate mediation is skipped. |
| `OrderApplicationService` | `OrderPolicy` | Declared mediation path | Application coordinates domain rule evaluation when used. |

No call is provided from `OrderDetailsScreen` to `OrderApplicationService` for the direct lookup/update path.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Handle user interaction and view data | Presentation | `OrderDetailsScreen` |
| Coordinate order lookup/update workflow | Application | Skipped in the direct path |
| Apply edit permission and status rules | Domain through Application | Not reached in the direct path |
| Execute persistence queries and updates | Persistence/Data Access | `OrderSqlTable`; directly invoked by Presentation |
| Enforce required layer mediation | Application boundary | Bypassed |

## 13. Execution Flow

1. `OrderDetailsScreen` receives a request to display and update an order.
2. `OrderDetailsScreen` constructs a query against `OrderSqlTable`.
3. `OrderDetailsScreen` reads persisted order fields.
4. `OrderDetailsScreen` writes a status update through `OrderSqlTable`.
5. `OrderApplicationService` and `OrderPolicy` are not invoked on that path.

The violation is present because the Presentation layer directly reaches Persistence and skips required Application mediation.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or hidden architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is a confirmed violation.

The reviewed material identifies the participating layers, their responsibilities, the required intermediate Application layer, and the observed direct Presentation-to-Persistence path. The bypass is structural and behavioral, not naming-only.

## 16. Evidence Provided

Strong evidence is provided:

- observable layers: Presentation, Application, Domain, and Persistence;
- declared mediation policy: Presentation must call Application for order lookup/update;
- direct dependency: `OrderDetailsScreen` references `OrderSqlTable`;
- runtime call evidence: `OrderDetailsScreen` performs query and update calls;
- bypass evidence: `OrderApplicationService` is skipped;
- responsibility impact: validation and domain rule coordination are not reached on the direct path.

Short non-compilable pseudocode:

```text
component OrderDetailsScreen
  uses OrderSqlTable

  saveStatus(orderId, nextStatus)
    record = OrderSqlTable.find(orderId)
    record.status = nextStatus
    OrderSqlTable.update(record)
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
- complete domain model;
- complete transaction implementation;
- formal Clean Architecture adoption claim;
- formal Hexagonal Architecture adoption claim;
- DDD tactical model evidence.

Withheld evidence prevents findings about framework choice, Clean use case boundaries, Hexagonal ports/adapters, global DDD design, repository pattern correctness, runtime behavior, or architecture-test coverage.

## 18. Expected Findings

Exactly one corrective finding is required.

```text
Finding ID: EVAL-LAYER-001-F001
Rule ID: LAYER-008
Title: Presentation order screen bypasses application mediation and accesses persistence directly
Outcome: Fail
Confidence: Confirmed
Severity: High
Applicability: Applicable
Evidence: OrderDetailsScreen directly references OrderSqlTable and performs order query/update behavior without calling the required OrderApplicationService mediation path.
Architectural Impact: Presentation can create order read/write paths that skip application coordination and domain rule mediation, eroding the declared layered structure.
Responsibility Impact: Presentation assumes access to persistence behavior that should remain mediated by Application and Persistence responsibilities.
Dependency Impact: A direct Presentation-to-Persistence dependency skips the required intermediate Application layer.
Rationale: Direct dependency, persistence behavior, declared mediation requirement, and skipped Application path satisfy the fail condition for LAYER-008.
Remediation: Route order lookup and update requests through the application service, keep persistence access behind the assigned data access responsibility, and preserve presentation as interaction and delegation code.
Related Rules: LAYER-003, LAYER-004, LAYER-007
Boundary Notes: The finding concludes only the required-layer bypass. It must not duplicate Clean, Hexagonal, DDD, Repository Pattern, or global persistence-strategy findings.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- absence of exactly four layers;
- absence of traditional layer names;
- absence of separate projects;
- absence of interfaces between every layer;
- use of a monolith;
- use of a single database;
- absence of Clean Architecture formalism;
- absence of Hexagonal Architecture formalism;
- absence of DDD;
- absence of Repository Pattern;
- framework usage in Presentation;
- data returned to Presentation through a mediated contract;
- legitimate adjacent-layer Presentation-to-Application dependency;
- architecture-test absence;
- microservice absence.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `LAYER-008` | `Applicable` | `Fail` | `Match` |
| Scenario | `Applicable` | `Fail` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed`.

Direct evidence identifies the layered structure, the required intermediate layer, the direct dependency, the persistence call path, and the skipped mediation. Naming is supporting context only.

## 22. Expected Severity

Expected severity is `High`.

The bypass affects order update behavior and skips application/domain mediation on a stable layer boundary. `Medium` is acceptable only if an observed result explicitly justifies reduced impact while preserving `Applicable`, `Fail`, `Confirmed`, and the required finding.

## 23. False Positive Guards

Do not report a finding based only on:

- a component named `Screen`, `Controller`, `Repository`, or `Table`;
- Presentation receiving already-mediated data;
- Presentation depending on Application;
- Presentation formatting DTOs or view models;
- Persistence existing in the same deployable unit;
- lack of separate projects;
- lack of formal Layered Architecture documentation.

The required failure depends on observable direct persistence access that skips required mediation.

## 24. False Negative Guards

Do not miss the required finding because:

- the database table is in the same project;
- the path works in a small monolith;
- the screen performs only a simple query;
- the direct access is described as convenience;
- layers use unconventional names;
- Application exists elsewhere but is skipped here;
- no formal architecture style is claimed.

## 25. Internal Boundary Expectations

`LAYER-008` owns the primary finding because the evaluated concern is bypass of required intermediate layers.

Related Layered rules may share evidence but must keep separate responsibilities:

- `LAYER-003` would require a general dependency-direction conclusion;
- `LAYER-004` would require Presentation owning application or business behavior;
- `LAYER-007` would require a persistence-placement conclusion beyond the bypass.

No additional Layered finding is required unless exclusive evidence supports a distinct conclusion.

## 26. Cross-Catalog Boundary Expectations

### Layered x Clean Architecture

Layered evaluates declared layer mediation and bypass. Clean evaluates use case, controller, gateway, policy, and detail boundaries. A Clean finding is forbidden when it merely restates the Presentation-to-Persistence bypass without Clean-specific evidence.

### Layered x Hexagonal Architecture

Hexagonal evaluates inside/outside, ports, adapters, and core isolation. The direct persistence access must not become a missing-port finding unless exclusive port/adapter evidence exists.

### Layered x Core

Core review behavior validates evidence discipline and deduplication. No generic Core finding is allowed for the same bypass conclusion.

### Layered x Fowler

Fowler evaluates enterprise patterns such as Transaction Script, Repository, Service Layer, and Active Record. The bypass must not be reclassified as a Fowler pattern finding without pattern-specific evidence.

## 27. Deduplication Expectations

| Shared Evidence | Layered Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Presentation references `OrderSqlTable` | Required Application mediation is bypassed under `LAYER-008` | Clean controller or Hexagonal port issue may be suspected | Yes | Emit one `LAYER-008` finding unless exclusive neighboring evidence exists. |
| Presentation updates order state | Persistence direct access supports bypass | Persistence placement may be suspected | Yes | Use as primary evidence; no duplicate `LAYER-007` finding. |
| Application service exists but is skipped | Required intermediate layer skipped | Use case isolation may be suspected | Yes | Keep ownership with `LAYER-008`. |
| Same-process monolith | Deployment is irrelevant | Solution redesign may be suspected | Yes | No finding based on monolith shape. |

## 28. Expected Remediation

Expected remediation must be proportional and technology-neutral:

- remove direct Presentation dependency on concrete persistence access;
- route lookup and update through Application mediation;
- keep Persistence/Data Access responsible for storage operations;
- keep Presentation focused on interaction, adaptation, and delegation;
- preserve domain rule checks on mediated write paths.

The remediation must not require Clean Architecture, Hexagonal Architecture, DDD, microservices, CQRS, event sourcing, ORM replacement, separate projects, or a total rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences in wording;
- equivalent order-management component names;
- equivalent direct access evidence;
- equivalent technology-neutral remediation;
- `Medium` severity with explicit reduced-impact justification;
- omission of supporting Rule results when they would be decorative;
- alternative existing supporting Rules that preserve `LAYER-008` ownership.

## 30. Disallowed Variations

Disallowed variations:

- title different from the catalog;
- category different from the catalog;
- Primary Rule changed away from `LAYER-008`;
- `Pass`;
- `Warning` as the only primary result;
- `Not Applicable`;
- `Not Enough Evidence`;
- confidence below `Confirmed`;
- missing required finding;
- duplicate finding;
- finding based only on naming;
- remediation requiring unrelated architecture, tooling, framework, or rewrite.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat the pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/layered/EVAL-LAYER-001-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `LAYER-008` is evaluated as `Applicable`;
- primary outcome is `Fail`;
- confidence is `Confirmed`;
- severity is `High` unless explicitly reduced to justified `Medium`;
- exactly one required finding appears for Presentation bypassing Application mediation to access Persistence;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Layered x Clean, Layered x Hexagonal, Layered x Core, and Layered x Fowler boundaries are respected;
- duplicate findings are absent;
- remediation is proportional and technology-neutral;
- observed result comparison against `evaluation/expected/layered/EVAL-LAYER-001-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- the required finding is missing;
- outcome is `Pass`, `Warning` only, `Not Applicable`, or `Not Enough Evidence`;
- confidence is below `Confirmed`;
- severity contradicts the bypass impact;
- the finding is generic or unsupported;
- the finding relies only on naming;
- duplicate Clean, Hexagonal, Core, Fowler, or neighboring Layered findings repeat the same conclusion;
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
| Coverage dimensions | `LAYER-008` violation coverage; Layered catalog coverage; `Fail`; `Confirmed`; `High`; strong evidence; applicability; false-positive protection; false-negative protection; internal Layered boundary; Clean x Layered boundary; deduplication; remediation. |
| Primary Rule catalog | `skill/rules/LAYER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/layered/LAYER-008.md` |
| Supporting Rule | `skill/rules/layered/LAYER-003.md` |
| Supporting Rule | `skill/rules/layered/LAYER-004.md` |
| Supporting Rule | `skill/rules/layered/LAYER-007.md` |
| Layered catalog review | `skill/reviews/LAYER_CATALOG_REVIEW.md` |
| Layered catalog stabilization | `skill/reviews/LAYER_CATALOG_STABILIZATION.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Fowler boundary review | `skill/reviews/FOWLER_CATALOG_REVIEW.md` |
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

Initial concrete scenario for `EVAL-LAYER-001`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `LAYER-008`, selected Supporting Rules, and expected `Fail` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
