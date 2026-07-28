# EVAL-FOWLER-003 - Active Record contains persistence and domain behavior

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-FOWLER-003` |
| Title | `Active Record contains persistence and domain behavior` |
| Category | `Fowler` |
| Scenario Type | `Warning Condition` |
| Catalogs | `Fowler`; boundary references to `DDD` and `Layered Architecture` |
| Primary Rule | `FOWLER-006` |
| Supporting Rules | `FOWLER-003`, `FOWLER-007`, `DDD-006` |
| Risk Level | `Medium` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P2` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/fowler/EVAL-FOWLER-003-EXPECTED.md` |
| Related Coverage Dimensions | Fowler catalog coverage; `FOWLER-006` warning coverage; `Warning` outcome; `Possible` confidence; contextual `Medium` severity; partial evidence; applicability; false-positive guard; false-negative guard; internal Fowler boundary; DDD x Fowler boundary; Layered x Fowler boundary; deduplication; remediation. |

## 2. Purpose

This scenario validates that ArchInspector evaluates Active Record contextually when an object combines persisted data, domain behavior, and persistence operations.

The scenario protects against automatic rejection of Active Record while still detecting responsibility pressure when same-object persistence and business behavior grow together.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Warning Condition` |
| Secondary Types | `Internal Boundary`, `Cross-Catalog Boundary` |
| Primary Outcome | `Warning` |
| Evidence Strength | `Partial` |
| Applicability | `Applicable` |
| Confidence | `Possible` |
| Severity | `Medium` |

## 4. Architectural Context

The evaluated system is a fictitious subscription-management module.

The reviewed scope contains a `SubscriptionRecord` object. It stores row-shaped state, exposes domain-relevant methods such as `activate`, `suspend`, and `changePlan`, and also provides persistence operations such as `save`, `delete`, and `findById`. The object is used directly by a small admin workflow.

Business complexity is moderate: three rules, two behavior variations by plan type, identity is relevant, invariants are limited but present, transaction coordination is local, duplication is not fully proven, changes occur monthly, component scale is small-to-medium, expected lifetime is multi-year, and operational risk is medium because subscription state affects billing access.

## 5. Target Catalogs

`Fowler` owns the scenario because the evaluated concern is the Active Record pattern responsibility.

`DDD` is a boundary reference because identity and behavior appear in the object, but DDD entity semantics do not own the primary conclusion. `Layered Architecture` is a boundary reference because persistence operations exist near business behavior, but layered dependency direction is not the primary evaluated condition.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `FOWLER-006` |
| Title | `Active Record` |
| Category | `Fowler Patterns` |
| Status | `Active` |
| Normative File | `skill/rules/fowler/FOWLER-006.md` |
| Catalog File | `skill/rules/FOWLER_CATALOG.md` |

`FOWLER-006` is selected because it directly evaluates objects that combine domain data, domain behavior, and persistence operations for rows or views.

`FOWLER-003` is not primary because Domain Model behavior is a comparison boundary, not the selected pattern. `FOWLER-007` is not primary because Data Mapper separation is an alternative, not a requirement. `FOWLER-011`, `FOWLER-013`, and `FOWLER-014` are adjacent cataloged Fowler rules but do not own the Active Record conclusion. `DDD-006` is not primary because entity identity is cross-catalog context only.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `FOWLER-003` | Clarifies Domain Model boundary when object behavior grows beyond simple record behavior. |
| `FOWLER-007` | Clarifies Data Mapper as an alternative separation pattern without requiring it universally. |
| `DDD-006` | Protects entity identity analysis from replacing the Fowler Active Record result. |

`FOWLER-011`, `FOWLER-013`, and `FOWLER-014` are cataloged adjacent rules and remain boundary notes because the scenario applies max-three supporting-rule discipline.

## 8. Input Artifacts

The scenario input is a textual static manifest. It is not executable and must not be treated as compilable code.

The manifest includes:

- object responsibilities;
- persisted identity and fields;
- domain behavior;
- persistence operations;
- caller flow;
- mapping hints;
- withheld evidence;
- boundary map.

## 9. Directory Structure

```text
subscription-management/
  model/
    SubscriptionRecord
  persistence/
    subscription_table
  application/
    ChangeSubscriptionPlan
```

The structure may be flat or framework-shaped. Folder names are supporting context only.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `SubscriptionRecord` | Active Record candidate. | Holds persisted state, domain behavior, and persistence operations. |
| `subscription_table` | Stored row representation. | Provides row identity and fields mapped by the object. |
| `ChangeSubscriptionPlan` | Caller workflow. | Loads the record, calls behavior, and lets the record persist itself. |
| `PlanRules` | Small policy helper. | Supplies limited calculation data but does not own persistence. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `SubscriptionRecord` | `subscription_table` | Mapping or row-shaped persistence reference | Supports Active Record applicability. |
| `SubscriptionRecord` | persistence operations | Method behavior | Object can save or delete itself. |
| `SubscriptionRecord` | domain behavior | Method behavior | Object owns limited business behavior. |
| `ChangeSubscriptionPlan` | `SubscriptionRecord` | Caller usage | Caller relies on same object for behavior and persistence. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner In Scenario | Observed Owner |
| --- | --- | --- |
| Hold persisted subscription state | Active Record object | `SubscriptionRecord` |
| Represent persisted identity | Active Record object | `SubscriptionRecord.id` |
| Apply plan change rules | Active Record object with contextual risk | `SubscriptionRecord.changePlan` |
| Save changed state | Active Record object | `SubscriptionRecord.save` |
| Separate mapping from domain object | Not required by selected pattern | Not present |
| DDD entity invariant ownership | Not established as primary requirement | Boundary context only |

## 13. Execution Flow

1. `ChangeSubscriptionPlan` loads a `SubscriptionRecord`.
2. The caller invokes `changePlan`.
3. `SubscriptionRecord` checks allowed plan transitions and billing hold status.
4. `SubscriptionRecord` mutates its plan and effective date.
5. `SubscriptionRecord.save` persists the row.

## 14. Preconditions

- Active Record evidence is behavioral, not naming-only.
- Persistence and domain behavior appear on the same object.
- The fixture does not prove that this combination is inherently broken.
- The evaluator applies only existing Rule IDs.
- Applicability is evaluated before outcome.

## 15. Architecture State

The architecture state is a warning condition.

Active Record is applicable and may be valid, but partial evidence shows responsibility pressure because persistence behavior and growing business behavior are combined in the same object.

## 16. Evidence Provided

Partial evidence is provided:

- persisted object identity;
- row-shaped state;
- domain behavior methods;
- persistence operations on the same object;
- caller flow relying on same-object behavior and save;
- mapping hints;
- moderate change frequency;
- limited but present invariants.

Short non-compilable pseudocode:

```text
component SubscriptionRecord
  fields id, planCode, status, billingHold

  changePlan(newPlan)
    reject if billingHold
    reject if transition is not allowed
    planCode = newPlan
    status = active

  save()
    write this record to subscription_table
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- executable fixture files;
- compilable source code;
- complete ORM mapping configuration;
- transaction manager details;
- full relationship mapping;
- complete repository or mapper inventory;
- production defect history;
- full DDD model evidence;
- formal Layered, Clean, or Hexagonal architecture evidence;
- runtime logs and tests;
- deployment and database product details.

Withheld evidence prevents confirmed failure, Data Mapper prescription, DDD findings, Layered findings, and global persistence-strategy conclusions.

## 18. Expected Findings

Exactly one warning finding is expected when responsibility pressure is reported.

```text
Finding ID: EVAL-FOWLER-003-F001
Rule ID: FOWLER-006
Title: Active Record object shows growing persistence and domain responsibility pressure
Outcome: Warning
Confidence: Possible
Severity: Medium
Applicability: Applicable
Evidence: SubscriptionRecord has persisted identity and state, exposes domain behavior such as changePlan, and also owns save/delete-style persistence operations used by the caller.
Architectural Impact: Active Record remains a valid Fowler pattern, but growing same-object persistence and domain behavior may reduce clarity and make future changes harder.
Business Logic Impact: Subscription rules may become harder to evolve if richer policies continue to accumulate beside persistence operations.
Maintenance Impact: Changes to persistence mechanics and business behavior may increasingly affect the same object.
Rationale: FOWLER-006 owns the combined data, behavior, and persistence responsibility. Its warning conditions cover partial, mixed, or responsibility-pressured Active Record implementations.
Remediation: Keep Active Record if the object remains simple and coherent; if behavior grows, clarify pattern intent, keep record behavior small, or incrementally separate richer domain behavior and persistence mapping.
Related Rules: FOWLER-003, FOWLER-007, DDD-006
Boundary Notes: The finding concludes only contextual Active Record responsibility pressure. It must not require Data Mapper, DDD entities, Layered Architecture, Clean Architecture, or Hexagonal Architecture.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- Active Record as inherently wrong;
- mandatory Data Mapper absence;
- mandatory Domain Model absence;
- mandatory DDD entity violation;
- absence of Aggregate, Value Object, Bounded Context, or Domain Event;
- Layered Architecture violation from persistence methods alone;
- Clean or Hexagonal Architecture violation;
- absence of Repository Pattern;
- use of ORM;
- database choice;
- monolith structure;
- separate findings for identity field, foreign key mapping, Unit of Work, and persistence method names without exclusive evidence.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `FOWLER-006` | `Applicable` | `Warning` | `Match` |
| Scenario | `Applicable` | `Warning` | `Match` |

## 21. Expected Confidence

Expected confidence is `Possible`.

The evidence supports Active Record applicability and contextual risk, but does not prove confirmed architectural breakdown.

## 22. Expected Severity

Expected severity is `Medium`.

The issue affects a subscription flow with billing implications and multi-year evolution, but the pattern is valid and the evidence is partial.

## 23. False Positive Guards

Do not report a finding based only on:

- class name containing `Record`;
- presence of persistence methods;
- ORM annotations or mapping hints;
- entity identity;
- absence of Data Mapper;
- absence of DDD;
- Active Record pattern choice alone.

## 24. False Negative Guards

Do not miss the required warning because:

- Active Record is a recognized pattern;
- the object is small today;
- persistence methods are conventional;
- domain behavior looks simple in isolation;
- mapping details are partial;
- no formal architecture style is claimed.

## 25. Internal Boundary Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Same object combines data, behavior, and persistence with responsibility pressure | `FOWLER-006` | No | Yes | Emit one contextual warning. |
| Domain Model behavior may be an alternative | No | `FOWLER-003` if separately evaluated | Yes | Boundary/remediation context only. |
| Data Mapper could separate persistence mapping | No | `FOWLER-007` if declared or evidenced | Yes | Boundary/remediation context only. |
| Identity Field or Foreign Key Mapping exists | No | `FOWLER-013` or `FOWLER-014` with exclusive evidence | Yes | Expected non-finding here. |

## 26. Cross-Catalog Boundary Expectations

### Fowler x DDD

Fowler evaluates Active Record responsibility. DDD evaluates entity identity, invariants, and domain meaning. Active Record does not automatically violate DDD, and identity evidence does not force a DDD finding.

### Fowler x Layered

Layered Architecture evaluates layer responsibilities and dependency direction. Persistence operations on an Active Record object are not by themselves a Layered violation.

### Fowler x Core

Core proportionality supports contextual evaluation. Pattern risk does not automatically imply global architecture failure.

### Fowler x Clean

Clean Architecture is outside scope. Domain behavior plus persistence operations do not prove a Clean Dependency Rule violation without Clean-specific evidence.

### Fowler x Hexagonal

Ports and adapters are outside scope. Absence of ports or mapper separation is not a Fowler violation.

## 27. Deduplication Expectations

| Shared Evidence | Fowler Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| `SubscriptionRecord` identity and behavior | Active Record applicability and risk | Possible DDD identity context only | Yes | One `FOWLER-006` warning. |
| Persistence methods on object | Active Record combined responsibility | Possible Layered/Clean/Hex only with exclusive evidence | Yes | Boundary note only. |
| Mapping hints | Active Record context | Data Mapper/Identity Field not confirmed | Yes | Expected non-finding. |

## 28. Expected Remediation

Expected remediation must be incremental and technology-neutral:

- preserve Active Record if it remains simple and coherent;
- clarify whether Active Record is the intended pattern;
- keep persistence operations and domain behavior small enough to remain understandable;
- extract richer policy behavior only when complexity justifies it;
- consider Data Mapper or Domain Model separation only as proportional alternatives.

Do not require Data Mapper, DDD, Clean Architecture, Hexagonal Architecture, microservices, CQRS, event sourcing, ORM changes, framework migration, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- object named entity, model, record, row, or active record;
- explicit methods or framework-provided persistence operations;
- equivalent domain such as subscription, customer, order, or invoice;
- `Pass` if observed result justifies simple coherent Active Record usage;
- equivalent remediation wording.

## 30. Disallowed Variations

Disallowed variations:

- title, category, outcome, or Primary Rule different from the catalog;
- Active Record condemned categorically;
- mandatory Data Mapper or DDD;
- `Fail` without confirmed responsibility breakdown;
- duplicate findings for each persistence method, identity field, or mapping hint;
- finding based only on name or ORM annotation;
- invented Rule ID.

## 31. Execution Instructions

Evaluate the textual static manifest only.

Do not compile, run, generate, or infer executable fixture code. Apply `FOWLER-006` first and use supporting/adjacent rules only for boundaries.

## 32. Acceptance Criteria

The scenario is accepted when:

- `FOWLER-006` is `Applicable`;
- primary outcome is `Warning`;
- confidence is `Possible`;
- severity is `Medium`;
- exactly one contextual warning appears when a finding is emitted;
- expected non-findings remain absent;
- Active Record legitimacy is stated;
- DDD and Layered boundaries are preserved;
- remediation is proportional;
- traceability is complete.

## 33. Failure Criteria

The scenario fails when:

- Active Record is treated as universally wrong;
- Data Mapper or DDD is required;
- same evidence is split into duplicate findings;
- DDD or Layered findings replace the Fowler result;
- the result ignores same-object persistence and domain behavior;
- remediation prescribes unrelated architecture or tooling.

## 34. Traceability

| Item | Trace |
| --- | --- |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Input artifacts | Textual static manifest in sections 8 through 17 of this scenario. |
| Primary Rule catalog | `skill/rules/FOWLER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/fowler/FOWLER-006.md` |
| Supporting Rule | `skill/rules/fowler/FOWLER-003.md` |
| Supporting Rule | `skill/rules/fowler/FOWLER-007.md` |
| Supporting Rule | `skill/rules/ddd/DDD-006.md` |
| Adjacent cataloged Rule | `skill/rules/fowler/FOWLER-011.md` |
| Adjacent cataloged Rule | `skill/rules/fowler/FOWLER-013.md` |
| Adjacent cataloged Rule | `skill/rules/fowler/FOWLER-014.md` |
| Fowler catalog review | `skill/reviews/FOWLER_CATALOG_REVIEW.md` |
| Fowler catalog stabilization | `skill/reviews/FOWLER_CATALOG_STABILIZATION.md` |
| Expected result | `evaluation/expected/fowler/EVAL-FOWLER-003-EXPECTED.md` |

## 35. Gold Standard Requirements

This scenario follows the structure of `evaluation/scenarios/core/EVAL-CORE-001.md` and adapts it to Fowler warning behavior. It preserves structure, contextual pattern evaluation, expected non-findings, false-positive protection, false-negative protection, internal boundaries, cross-catalog boundaries, deduplication, and traceability.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-FOWLER-003`.

Aligned with the Gold Standard scenario structure, evaluation models, scenario catalog identity, `FOWLER-006` as Primary Rule, selected supporting rules, expected `Warning` outcome, and Active Record x Data Mapper x Domain Model boundary.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
