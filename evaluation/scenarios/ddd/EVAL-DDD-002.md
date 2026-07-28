# EVAL-DDD-002 - Aggregate Protects Invariants Through Domain Behavior

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-DDD-002` |
| Title | `Aggregate protects invariants through domain behavior` |
| Category | `DDD` |
| Scenario Type | `Positive Compliance` |
| Catalogs | `DDD` |
| Primary Rule | `DDD-004` |
| Supporting Rules | `DDD-005`, `DDD-012`, `DDD-010` |
| Risk Level | `Medium` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Implementation Order | `16` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/ddd/EVAL-DDD-002-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `DDD-004`; catalog coverage for DDD; `Pass` outcome; `Likely` confidence; no-finding severity absence; strong evidence; applicability; false-positive guard; false-negative guard; internal DDD boundary; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector recognizes an aggregate that protects consistency rules through domain behavior and controlled state transitions.

The scenario protects positive compliance, aggregate/invariant boundary ownership, false-positive control against overengineering claims, false-negative control for public mutation, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Positive Compliance` |
| Secondary Types | `Internal Boundary` |
| Primary Outcome | `Pass` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Likely` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious reservation system.

The reviewed scope contains a `Reservation` aggregate with `ReservationLine` members. The aggregate enforces capacity, date-range, cancellation, and total-guest invariants through domain methods. Callers cannot directly replace lines or mutate guest counts; they request changes through aggregate behavior.

The scenario does not require a specific language, ORM, database transaction implementation, event publishing, or formal DDD framework. The aggregate boundary is evidenced by consistency rules and state transitions, not by names alone.

## 5. Target Catalogs

`DDD` owns the scenario category because the evaluated condition is aggregate consistency boundary enforcement.

No additional primary catalog is needed. Related rules clarify Aggregate Root access, domain invariant enforcement, and complex creation without duplicating `DDD-004`.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `DDD-004` |
| Title | `Aggregates must enforce consistency boundaries` |
| Category | `Domain-Driven Design` |
| Status | `Active` |
| Normative File | `skill/rules/ddd/DDD-004.md` |
| Catalog File | `skill/rules/DDD_CATALOG.md` |

`DDD-004` is selected because the scenario directly evaluates whether an aggregate protects consistency rules that belong inside its transactional boundary.

`DDD-005`, `DDD-012`, and `DDD-010` are related but secondary: root access, general invariant enforcement, and complex creation support the aggregate conclusion without replacing it.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `DDD-005` | Boundary reference for Aggregate Root access control. |
| `DDD-012` | Boundary reference for mandatory invariants enforced by the domain model. |
| `DDD-010` | Boundary reference for valid aggregate creation without making factories universal. |

Supporting Rules may explain why the aggregate evidence is sufficient. They must not produce separate pass/fail findings unless distinct evidence supports their own responsibility.

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
- explicit absence of persistence and messaging details.

## 9. Directory Structure

```text
reservation-domain/
  Reservation
  ReservationLine
  ReservationFactory
  ReservationCapacityPolicy
```

Directory names are supporting context only. The expected pass depends on observable consistency behavior and controlled transitions.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `Reservation` | Aggregate and root. | Owns line collection, status, date range, and guest-count changes. |
| `ReservationLine` | Internal aggregate member. | Cannot be modified directly by callers. |
| `ReservationFactory` | Creation boundary. | Creates valid initial reservations when capacity and date rules pass. |
| `ReservationCapacityPolicy` | Domain policy collaborator. | Supplies capacity rules used by aggregate behavior. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `Reservation` | `ReservationLine` | Internal member ownership | Aggregate state is changed through the root. |
| `Reservation` | `ReservationCapacityPolicy` | Domain policy dependency | Capacity decisions are domain concerns used by aggregate behavior. |
| `ReservationFactory` | `Reservation` | Creation path | Valid construction path initializes consistent state. |
| External caller | `Reservation` | Domain method invocation | Caller requests changes through root behavior. |

No direct caller dependency to mutable `ReservationLine` state is provided.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Protect reservation capacity | Aggregate/domain policy | `Reservation` with `ReservationCapacityPolicy` |
| Keep guest count consistent with lines | Aggregate | `Reservation` |
| Control cancellation and change transitions | Aggregate Root | `Reservation` |
| Create valid initial state | Factory or equivalent creation boundary | `ReservationFactory` |
| Persist reservation | Infrastructure outside scope | Withheld |

## 13. Execution Flow

1. `ReservationFactory` creates a reservation only after date and capacity checks.
2. A caller invokes `Reservation.addLine`.
3. `Reservation` recalculates total guests and rejects capacity overflow.
4. A caller invokes `Reservation.changeDateRange`.
5. `Reservation` rejects date changes after cancellation and rechecks capacity.
6. A caller invokes `Reservation.cancel`.
7. Later line additions are rejected by aggregate behavior.

The pass condition is present because consistency rules are enforced inside the aggregate boundary.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is positive compliance.

The reviewed material identifies an aggregate-like consistency boundary and shows domain behavior that protects state transitions. The scenario does not claim global DDD completeness.

## 16. Evidence Provided

Strong evidence is provided:

- aggregate scope: `Reservation` owns related reservation state;
- consistency rules: capacity, date range, cancellation, and guest totals are identified;
- controlled transitions: changes go through `Reservation` methods;
- invalid states are rejected during creation and mutation;
- internal member mutation is not exposed to callers;
- policy collaboration remains domain-oriented.

Short non-compilable pseudocode:

```text
component Reservation
  addLine(line)
    reject when cancelled
    reject when totalGuests + line.guests exceeds capacity
    add line

  changeDateRange(range)
    reject when cancelled
    reject when range conflicts with capacity policy
    replace date range
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- executable fixture files;
- compilable source code;
- concrete language syntax;
- ORM mappings;
- database transactions;
- repository implementation;
- domain event publication;
- integration messaging;
- framework annotations;
- automated tests;
- runtime logs;
- bounded context map;
- deployment topology.

Withheld evidence prevents persistence, messaging, Clean, Hexagonal, Fowler, or global DDD findings and does not contradict the aggregate consistency conclusion.

## 18. Expected Findings

No corrective finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: DDD-004
Outcome: Pass
Confidence: Likely
Severity: Not Applicable
Applicability: Applicable
Evidence: Reservation owns related reservation state, rejects invalid capacity/date/cancellation transitions, controls line changes through domain behavior, and avoids direct caller mutation of internal lines.
Architectural Impact: No corrective impact is present because aggregate consistency boundaries are protected in the reviewed scope.
Domain Impact: Reservation state remains valid through creation and change flows represented by the manifest.
Rationale: DDD-004 pass conditions are satisfied by observable aggregate boundary and consistency enforcement.
Remediation: None.
Related Rules: DDD-005, DDD-012, DDD-010
Boundary Notes: The result concludes only that the reviewed aggregate protects its consistency boundary. It must not become a claim of complete DDD, persistence correctness, or event publication correctness.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- encapsulated aggregate behavior as overengineering;
- absence of Domain Events;
- absence of Event Sourcing;
- absence of CQRS;
- absence of Bounded Context documentation;
- absence of microservices;
- absence of Repository Pattern;
- absence of formal Hexagonal Architecture;
- absence of Clean Architecture;
- absence of named layers;
- choice of ORM or database;
- monolithic deployment;
- absence of messaging;
- absence of architecture tests;
- factory absence outside the provided creation path.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `DDD-004` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Likely`.

The manifest provides strong behavioral evidence for aggregate consistency, but executable code and complete persistence/transaction paths are withheld. Naming alone is not used.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No finding is required, so no violation severity is assigned. The scenario risk level remains `Medium` as catalog coverage context.

## 23. False Positive Guards

Do not report a finding based only on:

- presence of an aggregate root;
- use of a factory;
- encapsulated internal members;
- absence of public setters;
- absence of Domain Events;
- absence of repository implementation;
- absence of DDD framework;
- monolithic deployment.

Protected aggregate behavior must not be treated as overengineering.

## 24. False Negative Guards

Do not approve automatically if future material shows:

- public mutation of internal lines;
- capacity checks only in callers;
- cancellation rules bypassed by direct state change;
- persistence materialization creates invalid state;
- creation bypasses required date or capacity rules;
- aggregate boundary widened to unrelated consistency rules.

The pass depends on behavior, not on aggregate naming.

## 25. Internal Boundary Expectations

`DDD-004` owns the primary result because the evaluated concern is aggregate consistency boundary enforcement.

Related DDD rules may share evidence:

- `DDD-005` owns root access and modification control;
- `DDD-012` owns broader mandatory invariant enforcement;
- `DDD-010` owns complex creation protection.

No additional finding is expected.

## 26. Cross-Catalog Boundary Expectations

### DDD x Core

Core review behavior validates evidence discipline and proportional reporting. No generic Core finding or strength claim is expected.

### DDD x Events and Messaging

No domain event publication is provided. The absence of events must not invalidate aggregate consistency.

### DDD x Fowler

Fowler Domain Model may be compatible with the evidence, but Fowler pattern conformance is not the primary conclusion.

### DDD x Clean

Clean dependency direction is outside scope. Aggregate behavior does not prove Clean Architecture conformance.

### DDD x Hexagonal

Hexagonal port/adapter boundaries are outside scope. Aggregate behavior does not prove core isolation from adapters.

## 27. Deduplication Expectations

| Shared Evidence | DDD Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| `Reservation` controls line changes | Aggregate consistency pass under `DDD-004` | Aggregate Root access pass may be suspected | Yes | Use `DDD-005` only as boundary context. |
| Capacity invariant enforcement | Aggregate consistency protected | General invariant pass may be suspected | Yes | Do not duplicate `DDD-012` result without separate need. |
| Factory creates valid aggregate | Creation protection supports aggregate state | Factory pass may be suspected | Yes | Use as supporting evidence. |
| No event publication | Outside aggregate consistency | Events/Messaging finding may be suspected | Yes | No event finding. |

## 28. Expected Remediation

No corrective remediation is expected.

Observed output may state that no remediation is required for the Primary Rule. It may recommend preserving aggregate state transitions, but it must not prescribe event sourcing, CQRS, microservices, messaging, ORM changes, Clean Architecture, Hexagonal Architecture, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences;
- equivalent reservation-domain terminology;
- equivalent ordering of evidence;
- `Confirmed` confidence if an observed result treats the manifest as complete direct evidence while preserving no finding;
- supporting Rule omission when decorative;
- no separate supporting findings.

## 30. Disallowed Variations

Disallowed variations:

- title different from the catalog;
- category different from the catalog;
- Primary Rule changed away from `DDD-004`;
- `Fail`;
- `Warning` as the primary result;
- `Not Applicable`;
- `Not Enough Evidence` when the manifest is used;
- any corrective finding;
- severity assigned despite no finding;
- finding based only on names;
- duplicate DDD findings;
- remediation requiring unrelated architecture or technology.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/ddd/EVAL-DDD-002-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `DDD-004` is evaluated as `Applicable`;
- primary outcome is `Pass`;
- confidence is `Likely` or stronger if justified by the manifest;
- severity is `Not Applicable`;
- no corrective finding appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- DDD internal boundaries are respected;
- duplicate findings are absent;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- any corrective finding appears;
- outcome is `Fail`, unsupported `Warning`, `Not Applicable`, or unsupported `Not Enough Evidence`;
- confidence contradicts evidence strength;
- protected aggregate behavior is treated as overengineering;
- expected non-findings appear;
- duplicate DDD or cross-catalog findings repeat the same conclusion;
- remediation prescribes unrelated architecture or tooling;
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
| Coverage dimensions | `DDD-004` positive compliance coverage; DDD catalog coverage; `Pass`; `Likely`; no-finding severity absence; strong evidence; applicability; false-positive protection; false-negative protection; internal DDD boundary; deduplication. |
| Primary Rule catalog | `skill/rules/DDD_CATALOG.md` |
| Primary Rule normative file | `skill/rules/ddd/DDD-004.md` |
| Supporting Rule | `skill/rules/ddd/DDD-005.md` |
| Supporting Rule | `skill/rules/ddd/DDD-012.md` |
| Supporting Rule | `skill/rules/ddd/DDD-010.md` |
| DDD catalog review | `skill/reviews/DDD_CATALOG_REVIEW.md` |
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

Initial concrete scenario for `EVAL-DDD-002`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `DDD-004`, selected Supporting Rules, and expected `Pass` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
