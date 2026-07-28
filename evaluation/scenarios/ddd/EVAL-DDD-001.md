# EVAL-DDD-001 - Entity Uses Primitive Strings for Validated Domain Concepts

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-DDD-001` |
| Title | `Entity uses primitive strings for validated domain concepts` |
| Category | `DDD` |
| Scenario Type | `Warning Condition` |
| Catalogs | `DDD`; boundary references to `Core` |
| Primary Rule | `DDD-001` |
| Supporting Rules | `DDD-012`, `DDD-013`, `DDD-006` |
| Risk Level | `Medium` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Implementation Order | `15` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/ddd/EVAL-DDD-001-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `DDD-001`; catalog coverage for DDD; `Warning` outcome; `Possible` confidence; contextual `Medium` severity; partial evidence; applicability; false-positive guard; false-negative guard; internal DDD boundary; DDD x Core boundary; deduplication; remediation. |

## 2. Purpose

This scenario validates that ArchInspector reports a constrained warning when an entity uses primitive strings for domain value concepts that appear to require validation, while avoiding a universal requirement for Value Objects.

The scenario protects contextual applicability, primitive-obsession false-positive control, invariant false-negative control, internal DDD boundaries, proportional remediation, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Warning Condition` |
| Secondary Types | `Confirmed Violation`, `Internal Boundary` |
| Primary Outcome | `Warning` |
| Evidence Strength | `Partial` |
| Applicability | `Applicable` |
| Confidence | `Possible` |
| Severity | `Medium` |

## 4. Architectural Context

The evaluated system is a fictitious membership registration system.

The reviewed scope contains a `Member` entity with lifecycle identity and several string attributes that represent validated domain concepts: `TaxId`, `EmailAddress`, and `MembershipCode`. The manifest shows validation in more than one caller and shows that the entity can be constructed with those primitive strings after caller-side checks. The evidence suggests that these concepts may be value-like domain concepts, but it does not fully prove equality semantics, complete mutation paths, or all invariant ownership.

The situation is intentionally partial. The scenario should produce a warning about value concept invariant protection, not a confirmed failure that requires a Value Object for every string.

## 5. Target Catalogs

`DDD` owns the scenario category because the evaluated concern is whether value-like domain concepts preserve meaning and invariants.

`Core` is a boundary reference because the scenario also validates evidence-before-conclusion, proportionality, and no generic finding that the system "does not use DDD".

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `DDD-001` |
| Title | `Value objects should protect invariants` |
| Category | `Domain-Driven Design` |
| Status | `Active` |
| Normative File | `skill/rules/ddd/DDD-001.md` |
| Catalog File | `skill/rules/DDD_CATALOG.md` |

`DDD-001` is selected because the scenario centers on value-like domain concepts represented as primitive strings with partial and duplicated invariant protection. The Rule owns value meaning, value identity, invalid value states, and value-owned invariant protection.

`DDD-012`, `DDD-013`, and `DDD-006` are related, but they do not own the primary conclusion: `DDD-012` owns broader domain invariant enforcement, `DDD-013` owns behavioral richness, and `DDD-006` owns entity identity and lifecycle consistency.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `DDD-012` | Boundary reference for mandatory invariant enforcement without duplicating Value Object-specific responsibility. |
| `DDD-013` | Boundary reference for behavior placement when primitive validation is externalized. |
| `DDD-006` | Boundary reference for preserving `Member` as an entity rather than confusing value identity with lifecycle identity. |

Supporting Rules may explain shared evidence and expected non-findings. They must not replace `DDD-001` as Primary Rule or produce duplicate findings for the same primitive value concept risk.

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
- explicitly withheld equality, persistence, and complete mutation evidence.

## 9. Directory Structure

```text
membership/
  domain/
    Member
    MembershipPolicy
  application/
    RegisterMember
    UpdateMemberContact
```

Directory names are supporting context only. The expected warning must depend on invariant and behavior evidence, not on names alone.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `Member` | Entity with lifecycle identity. | Stores `TaxId`, `EmailAddress`, and `MembershipCode` as strings. |
| `MembershipPolicy` | Domain policy. | Repeats format and checksum checks for `TaxId` and membership code. |
| `RegisterMember` | Application operation. | Performs caller-side validation before constructing `Member`. |
| `UpdateMemberContact` | Application operation. | Performs separate email validation before updating the entity. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `RegisterMember` | `Member` | Construction path | Caller validates primitive values before entity construction. |
| `UpdateMemberContact` | `Member` | Mutation path | Caller validates email format before changing contact data. |
| `MembershipPolicy` | `TaxId` string | Domain rule check | Domain policy repeats value-format and checksum validation. |
| `Member` | primitive strings | State representation | Value-like concepts are not protected by dedicated value semantics. |

No evidence is provided for value-based equality, complete mutation coverage, persistence materialization, or all construction paths.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Preserve member lifecycle identity | Entity | `Member` |
| Protect tax identifier format and checksum | Value concept or domain model | Split across callers and policy |
| Protect email address validity | Value concept or domain model | Caller-side checks plus entity assignment |
| Preserve membership code meaning | Value concept or domain policy | Repeated caller and policy validation |
| Prove every primitive requires a Value Object | Not required | Not asserted |

## 13. Execution Flow

1. `RegisterMember` receives primitive strings.
2. `RegisterMember` checks tax identifier and email format before creating `Member`.
3. `Member` stores the values as strings.
4. `MembershipPolicy` repeats tax identifier and membership code validation during eligibility checks.
5. `UpdateMemberContact` validates email separately before passing a new string to `Member`.

The risk is partial and contextual because validation is duplicated and value meaning appears important, but complete invalid-state creation paths are not provided.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is a warning condition.

The material suggests value-like domain concepts with partial invariant protection and duplicated validation. It does not justify `Fail Confirmed` because invalid value state is not directly demonstrated across all creation and mutation paths.

## 16. Evidence Provided

Partial evidence is provided:

- entity scope: `Member` has lifecycle identity;
- value-like concepts: tax identifier, email address, and membership code carry domain meaning;
- primitive representation: the concepts are stored as strings;
- duplicated validation: application operations and `MembershipPolicy` repeat checks;
- possible externalized invariant protection: callers validate before construction or mutation;
- incomplete direct proof: not every construction and mutation path is visible.

Short non-compilable pseudocode:

```text
component RegisterMember
  register(taxIdText, emailText, membershipCodeText)
    verify taxIdText format and checksum
    verify emailText format
    return Member.create(taxIdText, emailText, membershipCodeText)

component Member
  identity MemberId
  state TaxId text
  state EmailAddress text
  state MembershipCode text
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- executable fixture files;
- compilable source code;
- concrete language syntax;
- complete constructors and mutators;
- equality implementation;
- persistence materialization behavior;
- framework validation attributes;
- database constraints;
- automated tests;
- runtime logs;
- bounded context map;
- domain events;
- messaging publication;
- infrastructure implementation;
- formal DDD adoption claim.

Withheld evidence prevents confirmed failure, confirmed pass, repository findings, aggregate findings, event findings, Fowler pattern findings, or global DDD assessment.

## 18. Expected Findings

Exactly one warning finding is expected.

```text
Finding ID: EVAL-DDD-001-F001
Rule ID: DDD-001
Title: Validated member value concepts are represented as primitive strings with duplicated protection
Outcome: Warning
Confidence: Possible
Severity: Medium
Applicability: Applicable
Evidence: Member stores TaxId, EmailAddress, and MembershipCode as strings while RegisterMember, UpdateMemberContact, and MembershipPolicy repeat validation checks around those values.
Architectural Impact: Value meaning may be scattered across callers and policy logic, increasing the risk that future creation or mutation paths bypass value invariants.
Domain Impact: Member tax identity, contact validity, and membership code meaning may become inconsistent if primitive strings enter the model without the same checks.
Rationale: The evidence suggests value-like domain concepts and duplicated invariant protection, satisfying DDD-001 warning conditions without proving a confirmed invalid state.
Remediation: Introduce focused value concepts or equivalent domain-owned validation for the values whose invariants are meaningful, centralize creation and change rules, and keep the change proportional to demonstrated domain complexity.
Related Rules: DDD-012, DDD-013, DDD-006
Boundary Notes: The finding concludes only the value-concept invariant protection risk. It must not require Value Objects for every primitive or produce a generic DDD failure.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- absence of Value Object for every string;
- absence of Aggregate;
- absence of Aggregate Root;
- absence of Bounded Context;
- absence of Domain Events;
- absence of Event Sourcing;
- absence of CQRS;
- absence of microservices;
- absence of Hexagonal Architecture;
- absence of Clean Architecture;
- absence of named layers;
- absence of Repository Pattern;
- choice of ORM or database;
- monolithic application shape;
- absence of messaging;
- absence of architecture tests;
- `Member` being an entity;
- use of primitive strings when no domain invariant is shown.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `DDD-001` | `Applicable` | `Warning` | `Match` |
| Scenario | `Applicable` | `Warning` | `Match` |

## 21. Expected Confidence

Expected confidence is `Possible`.

The evidence is partial: it identifies value-like concepts and repeated validation, but withholds complete construction, mutation, equality, and invalid-state evidence. Naming alone is not used.

## 22. Expected Severity

Expected severity is `Medium`.

The risk affects important member identity/contact concepts, but the provided evidence is partial and does not prove broad invalid state or critical failure. `Low` is acceptable only if the observed result explicitly treats the affected values as peripheral while preserving `Warning`.

## 23. False Positive Guards

Do not report a finding based only on:

- primitive string usage;
- absence of a `ValueObject` suffix;
- public property count;
- simple attributes;
- lack of immutable record syntax;
- folder or namespace names;
- absence of formal tactical DDD;
- application input validation when no domain invariant is shown.

The warning depends on value-like domain meaning plus duplicated or partial invariant protection.

## 24. False Negative Guards

Do not miss the warning because:

- the values are called strings;
- validation exists somewhere outside the entity;
- the entity has lifecycle identity;
- the system is small;
- no class is named `ValueObject`;
- the validation appears in application operations;
- the rule is not a universal primitive ban.

Duplicated checks around domain-significant values must remain visible as a value invariant risk.

## 25. Internal Boundary Expectations

`DDD-001` owns the primary finding because the evaluated concern is value object invariant protection.

Related DDD rules may share evidence:

- `DDD-012` owns broader mandatory invariant enforcement;
- `DDD-013` owns behavioral richness when meaningful behavior belongs to the model;
- `DDD-006` owns entity identity and lifecycle consistency.

No additional DDD finding is required unless distinct evidence supports a separate conclusion.

## 26. Cross-Catalog Boundary Expectations

### DDD x Core

DDD evaluates semantic value modeling and invariant protection. Core review behavior contributes evidence discipline and proportionality. No generic Core finding is allowed for the same conclusion.

### DDD x Events and Messaging

No domain event or publication behavior is provided. Absence of events or messaging must not affect the value object warning.

### DDD x Fowler

Fowler evaluates enterprise patterns such as Transaction Script or Domain Model when pattern evidence exists. The primitive value warning must not become a Fowler pattern finding.

### DDD x Clean

Clean evaluates dependency direction and policy boundaries. The evidence does not show Clean use case boundary leakage. Application validation may be referenced only as support for DDD invariant placement.

### DDD x Hexagonal

Hexagonal evaluates ports, adapters, and core isolation. No adapter or infrastructure dependency is provided, so no Hexagonal finding is expected.

## 27. Deduplication Expectations

| Shared Evidence | DDD Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Primitive tax identifier string plus repeated checks | Possible value invariant risk under `DDD-001` | Core design concern may be suspected | Yes | Emit one `DDD-001` warning. |
| Caller-side validation | Value protection may be externalized | Clean application-service decision may be suspected | Yes | Do not duplicate without distinct use case boundary evidence. |
| `Member` lifecycle identity | Entity context supports scope | Entity lifecycle finding may be suspected | Yes | No `DDD-006` finding unless identity inconsistency appears. |
| No Value Object class | Naming/formalism absence only | Generic DDD absence may be suspected | Yes | Do not fail on absence alone. |

## 28. Expected Remediation

Expected remediation must be proportional and technology-neutral:

- centralize validation for tax identifier, email address, and membership code where domain meaning requires it;
- introduce focused value objects or equivalent domain-owned validation only for concepts with meaningful invariants;
- preserve `Member` lifecycle identity;
- avoid changing unrelated persistence, messaging, service, or deployment architecture.

The remediation must not require Value Objects for every primitive, microservices, CQRS, event sourcing, a framework, ORM changes, Clean Architecture, Hexagonal Architecture, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial wording differences;
- equivalent member-domain terminology;
- equivalent partial evidence ordering;
- `Low` or `Medium` severity when contextual impact is justified;
- supporting Rule omission when it would be decorative;
- no confirmed failure as long as the warning and boundary ownership are preserved.

## 30. Disallowed Variations

Disallowed variations:

- title different from the catalog;
- category different from the catalog;
- Primary Rule changed away from `DDD-001`;
- `Pass` as primary result;
- `Fail Confirmed` without direct invalid-state evidence;
- `Not Applicable`;
- `Not Enough Evidence` when partial risk evidence is used;
- generic "does not use DDD" finding;
- finding based only on primitive type or naming;
- duplicate invariant/model/entity findings;
- prescriptive remediation.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/ddd/EVAL-DDD-001-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `DDD-001` is evaluated as `Applicable`;
- primary outcome is `Warning`;
- confidence is `Possible`;
- severity is contextual and around `Medium`;
- exactly one warning finding appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- DDD internal and cross-catalog boundaries are respected;
- duplicate findings are absent;
- remediation is proportional and technology-neutral;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- the warning is missing;
- outcome is unsupported `Pass`, confirmed `Fail`, `Not Applicable`, or `Not Enough Evidence`;
- confidence is upgraded to `Confirmed` from partial evidence;
- a finding requires Value Objects universally;
- duplicate DDD, Clean, Hexagonal, Fowler, Events, or Core findings repeat the same conclusion;
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
| Coverage dimensions | `DDD-001` warning coverage; DDD catalog coverage; `Warning`; `Possible`; `Medium`; partial evidence; applicability; false-positive protection; false-negative protection; internal DDD boundary; DDD x Core boundary; deduplication; remediation. |
| Primary Rule catalog | `skill/rules/DDD_CATALOG.md` |
| Primary Rule normative file | `skill/rules/ddd/DDD-001.md` |
| Supporting Rule | `skill/rules/ddd/DDD-012.md` |
| Supporting Rule | `skill/rules/ddd/DDD-013.md` |
| Supporting Rule | `skill/rules/ddd/DDD-006.md` |
| DDD catalog review | `skill/reviews/DDD_CATALOG_REVIEW.md` |
| DDD Gold Standard review | `skill/reviews/DDD-001_REVIEW.md` |
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

Initial concrete scenario for `EVAL-DDD-001`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `DDD-001`, selected Supporting Rules, and expected `Warning` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
