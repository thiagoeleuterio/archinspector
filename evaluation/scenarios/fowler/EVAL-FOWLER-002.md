# EVAL-FOWLER-002 - Simple CRUD workflow implemented with Transaction Script

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-FOWLER-002` |
| Title | `Simple CRUD workflow implemented with Transaction Script` |
| Category | `Fowler` |
| Scenario Type | `Positive Compliance` |
| Catalogs | `Fowler`; boundary reference to `Core` |
| Primary Rule | `FOWLER-002` |
| Supporting Rules | `DDD-013`, `LAYER-005` |
| Risk Level | `Low` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/fowler/EVAL-FOWLER-002-EXPECTED.md` |
| Related Coverage Dimensions | Fowler catalog coverage; `FOWLER-002` positive compliance; `Pass` outcome; `Confirmed` confidence; low/no-finding severity expectation; strong evidence; legitimate absence; false-positive guard; DDD x Fowler boundary; Layered x Fowler boundary; deduplication; remediation. |

## 2. Purpose

This scenario validates that ArchInspector accepts a simple CRUD workflow implemented as Transaction Script when the evidence shows narrow request-centered behavior and no meaningful domain complexity.

The scenario protects against overengineering, Domain Model prescription, and false-positive findings based solely on procedural style.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Positive Compliance` |
| Secondary Types | `False Positive Guard`, `Legitimate Absence` |
| Primary Outcome | `Pass` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Confirmed` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious customer-admin module.

The reviewed scope contains a simple `UpdateCustomerContactScript`. It validates required fields, loads one record, updates contact details, saves the record, and returns a result. There is one basic rule, no meaningful behavioral variation, no invariant beyond required contact data, no identity lifecycle beyond the stored record, low duplication, rare rule changes, small component scale, expected ordinary maintenance lifetime, and low operational risk.

No formal DDD, Clean, Hexagonal, microservice, or advanced persistence pattern adoption is claimed or required.

## 5. Target Catalogs

`Fowler` owns the scenario because the evaluated concern is legitimate Transaction Script usage.

`Core` is a boundary reference because the scenario validates proportionality and legitimate absence of richer architecture. DDD and Layered supporting rules are used only as guards against overreach.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `FOWLER-002` |
| Title | `Transaction Script` |
| Category | `Fowler Patterns` |
| Status | `Active` |
| Normative File | `skill/rules/fowler/FOWLER-002.md` |
| Catalog File | `skill/rules/FOWLER_CATALOG.md` |

`FOWLER-002` is selected because the observable behavior is procedural request transaction logic. It is primary because the scenario validates that Transaction Script can be coherent and proportionate for simple CRUD.

`DDD-013` is not primary because absence of rich domain behavior is the expected legitimate absence. `LAYER-005` is not primary because application orchestration is not being evaluated as a Layered Architecture finding.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `DDD-013` | Protects against requiring tactical DDD or rich domain behavior in a simple CRUD scope. |
| `LAYER-005` | Protects simple application orchestration from being misread as misplaced business logic. |

No additional supporting rules are required.

## 8. Input Artifacts

The scenario input is a textual static manifest. It is not executable and must not be treated as compilable code.

The manifest includes:

- component inventory;
- responsibilities;
- simple operation flow;
- persistence access;
- explicit absence of complex rules;
- false-positive guard evidence;
- boundary map.

## 9. Directory Structure

```text
customer-admin/
  application/
    UpdateCustomerContactScript
  records/
    CustomerContactRecord
  persistence/
    CustomerContactStore
```

The directory names are context only. The pass depends on straight-line behavior and simple scope.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `UpdateCustomerContactScript` | Simple Transaction Script. | Performs basic validation, load, update, save, and result mapping. |
| `CustomerContactRecord` | Data record. | Holds contact fields without meaningful domain behavior. |
| `CustomerContactStore` | Persistence collaborator. | Loads and saves one record. |
| `UpdateResult` | Response data. | Reports success or validation failure. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `UpdateCustomerContactScript` | `CustomerContactStore` | Persistence collaboration | Acceptable for narrow CRUD transaction. |
| `UpdateCustomerContactScript` | `CustomerContactRecord` | Data record usage | Supports simple procedural update. |
| `UpdateCustomerContactScript` | validation helper | Basic validation | Not evidence of complex domain policy. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner In Scenario | Observed Owner |
| --- | --- | --- |
| Validate required email and phone fields | Transaction Script | `UpdateCustomerContactScript` |
| Load one customer contact record | Persistence collaborator coordinated by script | `CustomerContactStore` |
| Update contact fields | Transaction Script | `UpdateCustomerContactScript` |
| Save one record | Persistence collaborator coordinated by script | `CustomerContactStore` |
| Enforce complex business invariant | Not required | Not present |

## 13. Execution Flow

1. `UpdateCustomerContactScript` receives a contact update request.
2. It checks required fields and simple format.
3. It loads the existing contact record.
4. It assigns the new email and phone.
5. It saves the record.
6. It returns a success or validation result.

## 14. Preconditions

- The operation is simple and request-centered.
- Strong evidence shows no complex branching, repeated policies, or rich invariants.
- The evaluator does not assume unprovided workflows.
- The evaluator applies only existing Rule IDs.
- Applicability is evaluated before outcome.

## 15. Architecture State

The architecture state is positive compliance.

Transaction Script is applicable and coherent for the simple CRUD context. The absence of Domain Model, DDD, or additional service boundaries is legitimate.

## 16. Evidence Provided

Strong evidence is provided:

- narrow CRUD operation;
- one record loaded and saved;
- basic validation only;
- straight-line flow;
- no complex domain branching;
- no duplicated business policy;
- no meaningful invariants;
- no declared DDD requirement.

Short non-compilable pseudocode:

```text
component UpdateCustomerContactScript
  update(request)
    require request.email
    require request.phone
    record = CustomerContactStore.load(request.customerId)
    record.email = request.email
    record.phone = request.phone
    CustomerContactStore.save(record)
    return UpdateResult.success
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- executable fixture files;
- compilable source code;
- framework details;
- database product details;
- non-CRUD workflows;
- runtime logs;
- full application topology;
- formal DDD adoption claims;
- formal Layered, Clean, or Hexagonal architecture claims;
- architecture tests;
- security and deployment details.

Withheld evidence prevents global architecture conclusions and does not undermine the primary pass because the manifest explicitly provides simple CRUD behavior.

## 18. Expected Findings

No corrective finding is expected.

```text
Finding ID: None
Rule ID: FOWLER-002
Title: None
Outcome: Pass
Confidence: Confirmed
Severity: Not Applicable
Applicability: Applicable
Evidence: UpdateCustomerContactScript performs a narrow create/update-style transaction with basic validation, one persistence load/save, and no complex branching or repeated domain policy.
Architectural Impact: No negative impact is expected from using Transaction Script in this simple scope.
Business Logic Impact: Business behavior is minimal and proportionate to procedural organization.
Maintenance Impact: The workflow can remain easy to understand unless future rules accumulate.
Rationale: FOWLER-002 pass conditions allow coherent request-centered procedural transaction logic.
Remediation: No remediation required; reassess only if business complexity, duplication, or invariants emerge.
Related Rules: DDD-013, LAYER-005
Boundary Notes: The result must not prescribe Domain Model, DDD, Service Layer, Clean, Hexagonal, or microservices.
```

## 19. Expected Non-Findings

The scenario must not produce findings for:

- missing Domain Model;
- anemic Domain Model;
- absence of DDD;
- absence of Aggregate, Value Object, Bounded Context, or Domain Event;
- absence of Service Layer;
- absence of Repository Pattern;
- absence of Clean Architecture;
- absence of Hexagonal Architecture;
- absence of named layers;
- simple monolith structure;
- procedural code as such;
- CRUD application shape;
- direct or abstracted persistence as such;
- ORM or database choice;
- absence of architecture tests.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `FOWLER-002` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed`.

The manifest directly identifies the request transaction, the behavior performed, the persistence collaboration, and the absence of complexity. Naming is not the basis for confidence.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No finding is expected. Severity must not be invented for a pass result.

## 23. False Positive Guards

Do not report a finding based only on:

- Transaction Script pattern presence;
- procedural flow;
- CRUD operation;
- absence of Domain Model;
- absence of DDD;
- class names such as service, script, handler, command, or use case;
- simple persistence coordination.

## 24. False Negative Guards

Do not let the simple scope hide future violations if later evidence shows:

- repeated policies across scripts;
- complex branching;
- state invariants;
- divergent calculations;
- transaction consistency risk;
- responsibility mixing beyond CRUD.

## 25. Internal Boundary Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Simple Transaction Script is coherent | `FOWLER-002` | No | Yes | Return `Pass`. |
| Domain Model absent | No | `FOWLER-003` only if claimed or required | Yes | Expected non-finding. |
| Application orchestration exists | No | `LAYER-005` with layer evidence | Yes | Boundary support only. |

## 26. Cross-Catalog Boundary Expectations

### Fowler x DDD

Fowler validates Transaction Script suitability. DDD must not require rich domain modeling when no meaningful domain complexity exists.

### Fowler x Layered

Layered Architecture must not report a violation from simple application orchestration without an established layer responsibility problem.

### Fowler x Core

Core proportionality is validated by accepting lightweight design where evidence supports it.

### Fowler x Clean

Clean Architecture is outside scope. Absence of use cases or Dependency Rule evidence is not a violation.

### Fowler x Hexagonal

Ports and adapters are outside scope. Absence of ports is not a Fowler violation.

## 27. Deduplication Expectations

| Shared Evidence | Fowler Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Straight-line CRUD flow | Valid Transaction Script | No DDD or Layered issue | Yes | `Pass` with no finding. |
| Data-shaped record | Legitimate in simple CRUD | No anemic model finding | Yes | Expected non-finding. |
| Persistence call | Part of simple transaction | No Hex/Clean/Layered conclusion | Yes | Boundary note only. |

## 28. Expected Remediation

No remediation is expected.

Optional guidance may say to revisit the pattern only if complexity, duplicated business rules, invariants, or operational risk increases. It must not prescribe DDD, Domain Model, Clean, Hexagonal, microservices, CQRS, event sourcing, messaging, ORM, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- create, read, update, or delete operation;
- component named handler, service, command, endpoint, use case, or script;
- persistence direct or abstracted;
- equivalent result wording;
- explanatory note about future complexity.

## 30. Disallowed Variations

Disallowed variations:

- warning from procedural organization alone;
- required Domain Model behavior;
- DDD, Layered, Clean, or Hexagonal finding without exclusive evidence;
- `Not Enough Evidence` when simple CRUD behavior is explicit;
- invented severity for a non-finding;
- invented Rule ID.

## 31. Execution Instructions

Evaluate the textual static manifest only.

Do not compile, run, generate, or infer executable fixture code. Apply `FOWLER-002` to determine Transaction Script applicability and use supporting rules only to protect cross-catalog boundaries.

## 32. Acceptance Criteria

The scenario is accepted when:

- `FOWLER-002` is `Applicable`;
- primary outcome is `Pass`;
- confidence is `Confirmed`;
- no finding is emitted;
- severity is absent or `Not Applicable` according to result format;
- expected non-findings remain absent;
- legitimate absence of Domain Model and DDD is explicit;
- remediation is absent or limited to future reassessment;
- traceability is complete.

## 33. Failure Criteria

The scenario fails when:

- any corrective finding is emitted from procedural style alone;
- Domain Model or DDD is required;
- outcome is `Warning`, `Fail`, or `Not Enough Evidence` despite explicit simplicity;
- supporting rules replace the Primary Rule;
- remediation prescribes unrelated architecture.

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
| Primary Rule normative file | `skill/rules/fowler/FOWLER-002.md` |
| Supporting Rule | `skill/rules/ddd/DDD-013.md` |
| Supporting Rule | `skill/rules/layered/LAYER-005.md` |
| Fowler catalog review | `skill/reviews/FOWLER_CATALOG_REVIEW.md` |
| Fowler catalog stabilization | `skill/reviews/FOWLER_CATALOG_STABILIZATION.md` |
| Expected result | `evaluation/expected/fowler/EVAL-FOWLER-002-EXPECTED.md` |

## 35. Gold Standard Requirements

This scenario follows the structure of `evaluation/scenarios/core/EVAL-CORE-001.md` and adapts it to Fowler positive compliance. It preserves structure, evidence discipline, legitimate absence, expected non-findings, false-positive protection, boundaries, deduplication, and traceability.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-FOWLER-002`.

Aligned with the Gold Standard scenario structure, evaluation models, scenario catalog identity, `FOWLER-002` as Primary Rule, selected supporting rules, expected `Pass` outcome, and Fowler x DDD absence boundary.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
