# EVAL-FOWLER-004 - Pattern inferred only from class names

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-FOWLER-004` |
| Title | `Pattern inferred only from class names` |
| Category | `Fowler` |
| Scenario Type | `Insufficient Evidence` |
| Catalogs | `Fowler` |
| Primary Rule | `FOWLER-003` |
| Supporting Rules | `FOWLER-001`, `FOWLER-005`, `FOWLER-006` |
| Risk Level | `Medium` |
| Execution Type | `Document Fixture` |
| Status | `Ready` |
| Priority | `P2` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/fowler/EVAL-FOWLER-004-EXPECTED.md` |
| Related Coverage Dimensions | Fowler catalog coverage; `FOWLER-003` insufficient-evidence coverage; `Not Enough Evidence` outcome; `Not Enough Evidence` confidence; nominal evidence; false-positive guard; partial scope; internal Fowler pattern boundary; deduplication; evidence discipline. |

## 2. Purpose

This scenario validates that ArchInspector returns `Not Enough Evidence` when Fowler pattern inference is based only on names such as `Repository`, `Service`, `Model`, `Record`, `Gateway`, or `Registry`.

The scenario protects against confirmed compliance, warning, or failure from naming-only evidence.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Insufficient Evidence` |
| Secondary Types | `False Positive Guard`, `Partial Scope` |
| Primary Outcome | `Not Enough Evidence` |
| Evidence Strength | `Nominal` |
| Applicability | `Undetermined` |
| Confidence | `Not Enough Evidence` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated material is a fictitious architecture inventory document.

It lists classes named `CustomerRepository`, `CustomerService`, `CustomerModel`, `CustomerRecord`, `CustomerGateway`, and `Registry`. It does not provide method bodies, dependencies, caller flow, persistence mapping, transaction coordination, object behavior, or lifecycle.

Business complexity, number of rules, behavior variation, identity, invariants, coordination, transaction need, duplication, change frequency, scale, duration, and operational risk are all undetermined because the scenario intentionally provides only nominal evidence.

## 5. Target Catalogs

`Fowler` owns the scenario because the evaluated concern is Fowler pattern evidence discipline.

No neighboring catalog owns a finding. The document fixture is intentionally insufficient for DDD, Layered, Core, Clean, or Hexagonal conclusions.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `FOWLER-003` |
| Title | `Domain Model` |
| Category | `Fowler Patterns` |
| Status | `Active` |
| Normative File | `skill/rules/fowler/FOWLER-003.md` |
| Catalog File | `skill/rules/FOWLER_CATALOG.md` |

`FOWLER-003` is selected because the catalog assigns it as Primary Rule and the nominal evidence centers on possible domain/model naming without observable domain behavior. The rule explicitly states that names, folders, documentation, or passive structures are insufficient to confirm Domain Model behavior.

`FOWLER-001`, `FOWLER-005`, and `FOWLER-006` are supporting false-positive guards for Repository, Service Layer, and Active Record naming. `FOWLER-004`, `FOWLER-007`, `FOWLER-008`, `FOWLER-009`, and `FOWLER-020` are adjacent cataloged rules that must also remain unconfirmed from names alone.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `FOWLER-001` | Prevents confirming Repository from a repository class name alone. |
| `FOWLER-005` | Prevents confirming Service Layer from a service class name alone. |
| `FOWLER-006` | Prevents confirming Active Record from record/model naming alone. |

Adjacent cataloged rules `FOWLER-004`, `FOWLER-007`, `FOWLER-008`, `FOWLER-009`, and `FOWLER-020` remain boundary references and must not produce findings from nominal evidence.

## 8. Input Artifacts

The scenario input is a textual document fixture. It is not executable and must not be treated as compilable code.

The document includes:

- class list;
- Fowler-like names;
- optional one-line descriptions;
- no behavior;
- no dependency graph;
- no persistence mapping;
- no collaboration flow;
- explicit evidence omissions.

## 9. Directory Structure

```text
document-fixture/
  architecture-inventory.txt

Classes:
  CustomerRepository
  CustomerService
  CustomerModel
  CustomerRecord
  CustomerGateway
  Registry
```

The class names are nominal evidence only.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `CustomerRepository` | Repository candidate by name. | Name only; no collection-like access behavior. |
| `CustomerService` | Service Layer candidate by name. | Name only; no operation boundary or transaction coordination. |
| `CustomerModel` | Domain Model candidate by name. | Name only; no state-and-behavior evidence. |
| `CustomerRecord` | Active Record or Row Data Gateway candidate by name. | Name only; no persistence operations. |
| `CustomerGateway` | Gateway candidate by name. | Name only; no external access behavior. |
| `Registry` | Registry candidate by name. | Name only; no global lookup behavior. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| Document inventory | Named classes | Nominal listing | Candidate evidence only. |
| Named classes | Any collaborator | Not provided | Dependency conclusions are unsupported. |
| Named classes | Persistence or domain behavior | Not provided | Pattern conclusions are unsupported. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner In Scenario | Observed Owner |
| --- | --- | --- |
| Domain behavior combining state and behavior | Unknown | Not provided |
| Repository collection-like domain access | Unknown | Not provided |
| Service operation boundary | Unknown | Not provided |
| Active Record persistence and behavior | Unknown | Not provided |
| Table Module table-centered logic | Unknown | Not provided |
| Data Mapper separation | Unknown | Not provided |
| Registry global lookup | Unknown | Not provided |

## 13. Execution Flow

No execution flow is provided.

The scenario intentionally withholds caller sequence, method behavior, transaction flow, persistence flow, and object collaboration.

## 14. Preconditions

- The evaluator receives only the document fixture.
- The evaluator must not synthesize missing code, dependencies, or behavior.
- The evaluator treats names as nominal evidence.
- The evaluator applies existing Rule IDs only.
- Applicability is `Undetermined` where behavior is required but missing.

## 15. Architecture State

The architecture state is insufficient evidence.

Fowler pattern names identify candidates for inspection, but do not establish pattern presence, conformance, violation, warning, or legitimate absence.

## 16. Evidence Provided

Nominal evidence is provided:

- class names containing Fowler-like terms;
- possible package or inventory labels;
- optional one-line descriptions with no behavior;
- no method bodies;
- no dependency information;
- no collaboration flow.

Short non-compilable document excerpt:

```text
Architecture inventory:
  CustomerRepository
  CustomerService
  CustomerModel
  CustomerRecord
  CustomerGateway
  Registry
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- executable fixture files;
- compilable source code;
- method bodies;
- caller flow;
- dependency graph;
- persistence mapping;
- transaction coordination;
- domain behavior;
- object state transitions;
- tests;
- runtime logs;
- architecture decisions tied to implementation;
- DDD, Layered, Core, Clean, or Hexagonal evidence;
- deployment, security, observability, and database details.

Withheld evidence is the reason the expected result is `Not Enough Evidence`.

## 18. Expected Findings

No architectural finding is expected.

```text
Finding ID: None
Rule ID: FOWLER-003
Title: None
Outcome: Not Enough Evidence
Confidence: Not Enough Evidence
Severity: Not Applicable
Applicability: Undetermined
Evidence: Only Fowler-like class names are provided; no behavior, dependency, persistence, collaboration, state, or transaction evidence is available.
Architectural Impact: No impact can be assigned because no pattern responsibility is proven.
Business Logic Impact: Unknown.
Maintenance Impact: Unknown.
Rationale: FOWLER-003 requires evidence of object state and business behavior placement. Naming alone cannot confirm Domain Model or any adjacent Fowler pattern.
Remediation: Request behavioral evidence such as responsibilities, methods, caller flow, dependency relationships, persistence mapping, transaction boundaries, and tests.
Related Rules: FOWLER-001, FOWLER-005, FOWLER-006
Boundary Notes: Supporting and adjacent Fowler rules remain unconfirmed candidates only.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- Domain Model;
- Repository;
- Service Layer;
- Active Record;
- Table Module;
- Data Mapper;
- Row Data Gateway;
- Table Data Gateway;
- Registry;
- missing Domain Model;
- missing Repository Pattern;
- missing Service Layer;
- DDD absence;
- Clean Architecture absence;
- Hexagonal Architecture absence;
- Layered Architecture absence;
- monolith, CRUD, ORM, database choice, or folder structure.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `FOWLER-003` | `Undetermined` | `Not Enough Evidence` | `Match` |
| Scenario | `Undetermined` | `Not Enough Evidence` | `Match` |

## 21. Expected Confidence

Expected confidence is `Not Enough Evidence`.

The provided material cannot support another confidence level because it contains names only.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No finding is expected, and severity must not be assigned to a non-finding.

## 23. False Positive Guards

Do not report a finding based only on:

- class names;
- folder names;
- package names;
- documentation labels;
- the words `Repository`, `Service`, `Model`, `Record`, `Gateway`, or `Registry`;
- pattern catalog familiarity;
- inferred team intent.

## 24. False Negative Guards

Do not let the insufficient-evidence result hide later evidence. If future material provides method behavior, dependencies, mapping, transaction flow, or object collaboration, reassess the relevant Fowler rule.

## 25. Internal Boundary Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Domain Model cannot be confirmed from names | `FOWLER-003` | No | Yes | Return `Not Enough Evidence`. |
| Repository cannot be confirmed from name | No | `FOWLER-001` if separately evaluated | Yes | Supporting false-positive guard. |
| Service Layer cannot be confirmed from name | No | `FOWLER-005` if separately evaluated | Yes | Supporting false-positive guard. |
| Active Record cannot be confirmed from name | No | `FOWLER-006` if separately evaluated | Yes | Supporting false-positive guard. |
| Other named Fowler patterns remain candidates | No | Their own rules with behavior | Yes | No findings. |

## 26. Cross-Catalog Boundary Expectations

### Fowler x DDD

Domain-like names do not prove DDD, Domain Model, entity identity, aggregates, or anemic model findings.

### Fowler x Layered

Layer names or service names do not prove layer dependency direction or responsibility placement.

### Fowler x Core

Core evidence discipline requires making the evidence gap explicit rather than producing speculative conclusions.

### Fowler x Clean

No Clean Architecture conclusion is supported by names alone.

### Fowler x Hexagonal

Gateway naming does not prove a Hexagonal port, adapter, or Fowler Gateway-like external access boundary.

## 27. Deduplication Expectations

| Shared Evidence | Fowler Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Fowler-like names | `Not Enough Evidence` for pattern inference | No neighboring conclusion supported | Yes | One insufficient-evidence result. |
| `CustomerModel` name | Domain Model candidate only | No DDD conclusion | Yes | No finding. |
| `CustomerGateway` name | Candidate only | No Hexagonal conclusion | Yes | No finding. |

## 28. Expected Remediation

Expected remediation is evidence collection only:

- request method bodies or behavioral descriptions;
- request caller flow and object collaboration;
- dependency relationships;
- persistence mapping and transaction behavior;
- tests or architecture decisions tied to implementation.

Do not prescribe Domain Model, Repository, Service Layer, Active Record, Data Mapper, Clean, Hexagonal, DDD, microservices, ORM, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- equivalent Fowler-like names;
- result wording such as insufficient evidence or not enough evidence;
- listing unconfirmed candidate patterns;
- requesting equivalent behavioral evidence;
- omitting supporting rule results when no finding is produced.

## 30. Disallowed Variations

Disallowed variations:

- confirming any Fowler pattern from names alone;
- warning or failure from names alone;
- assigning severity to a non-finding;
- inventing behavior, dependencies, mapping, or transaction flow;
- changing the cataloged title, category, Primary Rule, or outcome;
- creating multiple findings for each candidate name;
- invented Rule ID.

## 31. Execution Instructions

Evaluate the document fixture only.

Do not compile, run, generate, or infer executable fixture code. Do not synthesize missing code, dependencies, behavior, mapping, or collaboration. Apply `FOWLER-003` as the primary insufficient-evidence rule and use supporting rules only as false-positive guards.

## 32. Acceptance Criteria

The scenario is accepted when:

- `FOWLER-003` applicability is `Undetermined`;
- primary outcome is `Not Enough Evidence`;
- confidence is `Not Enough Evidence`;
- severity is absent or `Not Applicable`;
- no Fowler pattern is confirmed;
- no warning or failure is emitted;
- names are treated as nominal evidence only;
- expected non-findings remain absent;
- traceability is complete.

## 33. Failure Criteria

The scenario fails when:

- any Fowler pattern is confirmed from names alone;
- any warning or failure is emitted from names alone;
- behavior, dependencies, or persistence mapping are invented;
- multiple candidate-name findings are emitted;
- cross-catalog conclusions are produced;
- severity is assigned to a non-finding.

## 34. Traceability

| Item | Trace |
| --- | --- |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Input artifacts | Textual document fixture in sections 8 through 17 of this scenario. |
| Primary Rule catalog | `skill/rules/FOWLER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/fowler/FOWLER-003.md` |
| Supporting Rule | `skill/rules/fowler/FOWLER-001.md` |
| Supporting Rule | `skill/rules/fowler/FOWLER-005.md` |
| Supporting Rule | `skill/rules/fowler/FOWLER-006.md` |
| Adjacent cataloged Rule | `skill/rules/fowler/FOWLER-004.md` |
| Adjacent cataloged Rule | `skill/rules/fowler/FOWLER-007.md` |
| Adjacent cataloged Rule | `skill/rules/fowler/FOWLER-008.md` |
| Adjacent cataloged Rule | `skill/rules/fowler/FOWLER-009.md` |
| Adjacent cataloged Rule | `skill/rules/fowler/FOWLER-020.md` |
| Fowler catalog review | `skill/reviews/FOWLER_CATALOG_REVIEW.md` |
| Fowler catalog stabilization | `skill/reviews/FOWLER_CATALOG_STABILIZATION.md` |
| Expected result | `evaluation/expected/fowler/EVAL-FOWLER-004-EXPECTED.md` |

## 35. Gold Standard Requirements

This scenario follows the structure of `evaluation/scenarios/core/EVAL-CORE-001.md` and adapts it to Fowler insufficient-evidence behavior. It preserves evidence discipline, nominal-evidence handling, expected non-findings, false-positive protection, false-negative protection, internal boundaries, cross-catalog boundaries, deduplication, and traceability.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-FOWLER-004`.

Aligned with the Gold Standard scenario structure, evaluation models, scenario catalog identity, `FOWLER-003` as Primary Rule, selected supporting rules, expected `Not Enough Evidence` outcome, and Fowler internal pattern boundary.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
