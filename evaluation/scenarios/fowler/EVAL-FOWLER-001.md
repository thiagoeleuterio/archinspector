# EVAL-FOWLER-001 - Complex business workflow implemented as procedural transaction script

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-FOWLER-001` |
| Title | `Complex business workflow implemented as procedural transaction script` |
| Category | `Fowler` |
| Scenario Type | `Warning Condition` |
| Catalogs | `Fowler`; boundary reference to `DDD` |
| Primary Rule | `FOWLER-002` |
| Supporting Rules | `FOWLER-003`, `FOWLER-005`, `DDD-013` |
| Risk Level | `Medium` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/fowler/EVAL-FOWLER-001-EXPECTED.md` |
| Related Coverage Dimensions | Fowler catalog coverage; `FOWLER-002` warning coverage; `Warning` outcome; `Possible` confidence; contextual `Medium` severity; partial evidence; applicability; false-positive guard; false-negative guard; DDD x Fowler boundary; deduplication; remediation. |

## 2. Purpose

This scenario validates that ArchInspector reports a contextual warning when a complex business workflow is implemented as a procedural Transaction Script and the available evidence shows complexity pressure, branching policy decisions, repeated validation, persistence coordination, and side-effect coordination in one request procedure.

The scenario protects Transaction Script from universal rejection while also protecting against false negatives when procedural organization becomes risky for a non-trivial business workflow.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Warning Condition` |
| Secondary Types | `Conflicting Evidence`, `Cross-Catalog Boundary` |
| Primary Outcome | `Warning` |
| Evidence Strength | `Partial` |
| Applicability | `Applicable` |
| Confidence | `Possible` |
| Severity | `Medium` |

## 4. Architectural Context

The evaluated system is a fictitious contract-renewal system.

The reviewed scope contains a request-centered operation named `RenewContractScript`. It validates eligibility, calculates discounts and penalty waivers, selects renewal terms, writes the renewed contract, and notifies downstream billing. The workflow is intentionally procedural and no formal DDD adoption is claimed.

The business complexity is moderate: five business rules, several conditional branches, two behavior variations by customer segment, no long-lived aggregate identity requirement beyond the contract record, limited invariants, request-level transaction coordination, visible duplication of eligibility checks, quarterly rule changes, one bounded component, expected multi-year lifetime, and medium operational risk because renewal errors affect billing.

## 5. Target Catalogs

`Fowler` owns the scenario category because the evaluated concern is the organization of business logic as Transaction Script.

`DDD` is a boundary reference because the same evidence mentions domain behavior, but the scenario must not convert a Fowler warning into a DDD failure or require tactical DDD patterns.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `FOWLER-002` |
| Title | `Transaction Script` |
| Category | `Fowler Patterns` |
| Status | `Active` |
| Normative File | `skill/rules/fowler/FOWLER-002.md` |
| Catalog File | `skill/rules/FOWLER_CATALOG.md` |

`FOWLER-002` is selected because the observable business logic is organized as procedural request transaction logic. The rule directly owns the conclusion that Transaction Script is applicable and may be risky when partial evidence shows duplicated, mixed, or complex procedural transaction responsibilities.

`FOWLER-003` is not primary because the scenario does not establish a selected Domain Model. `FOWLER-005` is not primary because the service boundary is not the evaluated responsibility. `DDD-013` and `DDD-008` are not primary because Fowler pattern suitability, not DDD modeling, owns the expected outcome.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `FOWLER-003` | Compares the absent or weak object-behavior alternative without requiring Domain Model. |
| `FOWLER-005` | Clarifies that operation coordination may exist without turning the issue into Service Layer conformance. |
| `DDD-013` | Protects the boundary between contextual Fowler pattern choice and tactical DDD expectations. |

`DDD-008` is cataloged as adjacent support but is not selected as an operative supporting rule because the scenario uses a maximum of three supporting rules.

## 8. Input Artifacts

The scenario input is a textual static manifest. It is not executable and must not be treated as compilable code.

The manifest includes:

- component inventory;
- responsibility inventory;
- operation flow;
- business rules;
- persistence coordination;
- notification coordination;
- short non-compilable pseudocode;
- withheld evidence;
- DDD x Fowler boundary map.

## 9. Directory Structure

```text
contract-renewal/
  application/
    RenewContractScript
  domain/
    ContractRecord
    RenewalPolicyNotes
  infrastructure/
    ContractStore
    BillingNotificationGateway
```

Names are supporting context only. The expected warning depends on behavioral evidence, not on the word `Script`.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `RenewContractScript` | Procedural request operation. | Contains validation, calculation, branching, persistence, and notification coordination. |
| `ContractRecord` | Data-shaped contract state. | Holds contract fields and exposes no meaningful renewal behavior. |
| `RenewalPolicyNotes` | Documented business policy. | Lists rules that are implemented procedurally in the script. |
| `ContractStore` | Persistence collaborator. | Saves renewed contract state. |
| `BillingNotificationGateway` | External side-effect collaborator. | Receives notification after renewal. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `RenewContractScript` | `ContractStore` | Persistence collaboration | Script coordinates state load and save. |
| `RenewContractScript` | `BillingNotificationGateway` | External notification collaboration | Script triggers downstream side effect. |
| `RenewContractScript` | `ContractRecord` | Data object usage | Script reads and mutates data-shaped contract state. |
| `ContractRecord` | Renewal behavior | Absence of behavior | Business decisions are not represented by object behavior. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner In Scenario | Observed Owner |
| --- | --- | --- |
| Validate renewal eligibility | Request transaction logic | `RenewContractScript` |
| Calculate discount and penalty waiver | Request transaction logic with growing complexity | `RenewContractScript` |
| Select renewal term by segment | Business behavior requiring careful change | `RenewContractScript` |
| Persist renewed contract | Persistence collaborator coordinated by script | `RenewContractScript` calls `ContractStore` |
| Notify billing | External gateway coordinated by script | `RenewContractScript` calls `BillingNotificationGateway` |
| Preserve complex invariants | Not established as Domain Model requirement | Evidence is partial and procedural |

## 13. Execution Flow

1. `RenewContractScript` receives a renewal request.
2. It loads the current `ContractRecord`.
3. It validates eligibility, overdue balance, customer segment, and regulatory hold flags.
4. It calculates discount, waiver, and renewal term inline.
5. It updates contract state.
6. It persists the contract through `ContractStore`.
7. It notifies billing through `BillingNotificationGateway`.

## 14. Preconditions

- The evaluator receives the textual manifest as complete scenario input.
- The evaluator treats pseudocode as non-compilable behavioral evidence.
- The evaluator does not assume a full production codebase, runtime traces, or team intent.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is a warning condition.

Transaction Script is applicable and can be legitimate, but the observed workflow has enough partial complexity evidence to create maintainability risk. The evidence does not confirm a breakdown severe enough for `Fail`.

## 16. Evidence Provided

Partial evidence is provided:

- request-centered procedural workflow;
- multiple inline business rules;
- repeated eligibility checks also listed in another renewal script;
- inline calculations and branching by customer segment;
- persistence and notification coordination in the same procedure;
- data-shaped domain object with little relevant behavior;
- quarterly policy changes.

Short non-compilable pseudocode:

```text
component RenewContractScript
  renew(request)
    contract = ContractStore.load(request.contractId)
    check eligibility, overdue balance, segment, regulatory hold
    discount = calculate from segment and tenure
    waiver = calculate from payment history
    contract.term = select term
    contract.amount = contract.amount - discount - waiver
    ContractStore.save(contract)
    BillingNotificationGateway.notifyRenewal(contract.id)
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- executable fixture files;
- compilable source code;
- full repository structure;
- runtime execution data;
- production incident history;
- complete duplicate script inventory;
- full domain model alternative;
- formal DDD adoption evidence;
- formal Layered, Clean, or Hexagonal architecture evidence;
- database product and framework details;
- tests and observability.

Withheld evidence prevents confirmed failure, DDD findings, global architecture conclusions, and technology-specific recommendations.

## 18. Expected Findings

Exactly one warning finding is expected.

```text
Finding ID: EVAL-FOWLER-001-F001
Rule ID: FOWLER-002
Title: Procedural renewal transaction script shows complexity pressure
Outcome: Warning
Confidence: Possible
Severity: Medium
Applicability: Applicable
Evidence: RenewContractScript coordinates several business rules, branching calculations, persistence, and notification side effects while ContractRecord remains data-shaped and duplicate eligibility checks are partially evidenced.
Architectural Impact: The Transaction Script remains a valid pattern, but concentrated procedural rules may become harder to change consistently as renewal policy varies.
Business Logic Impact: Renewal terms, discounts, and waivers can diverge across scripts if the same policies continue to be copied procedurally.
Maintenance Impact: Quarterly policy changes are likely to require repeated edits in procedural workflows.
Rationale: FOWLER-002 owns procedural request transaction organization and its warning condition covers partial, duplicated, or mixed scripts that weaken the boundary without proving failure.
Remediation: Keep Transaction Script if the workflow remains simple; otherwise incrementally extract repeated rules, split unrelated steps, or move complex policy behavior into a proportionate object model or clearer service boundary.
Related Rules: FOWLER-003, FOWLER-005, DDD-013
Boundary Notes: The finding concludes only contextual Transaction Script complexity risk. It must not become a DDD, Domain Model absence, Service Layer, Clean, Hexagonal, or Layered finding.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- Transaction Script as inherently invalid;
- mandatory Domain Model absence;
- mandatory DDD adoption;
- anemic domain model under DDD;
- absence of Aggregate, Value Object, Bounded Context, or Domain Event;
- absence of Service Layer;
- absence of Repository Pattern;
- absence of Clean Architecture or Hexagonal Architecture;
- absence of named layers;
- monolith structure;
- CRUD or procedural style alone;
- use of ORM or database choice;
- one finding per inline rule;
- notification side effect as messaging architecture finding.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `FOWLER-002` | `Applicable` | `Warning` | `Match` |
| Scenario | `Applicable` | `Warning` | `Match` |

## 21. Expected Confidence

Expected confidence is `Possible`.

The evidence is partial: it shows procedural organization and complexity pressure, but it does not provide enough direct production impact, complete duplication inventory, or runtime behavior to confirm failure.

## 22. Expected Severity

Expected severity is `Medium`.

The concern affects an important renewal workflow and recurring policy change, but the scenario does not prove broad architectural breakdown. `Low` is acceptable only if observed reasoning preserves `Warning`, `Applicable`, `Possible`, and explicitly narrows impact.

## 23. False Positive Guards

Do not report a finding based only on:

- the word `Script`;
- procedural code existing;
- a service or handler shape;
- absence of Domain Model;
- absence of DDD;
- monolithic deployment;
- simple persistence coordination;
- business vocabulary in procedural code.

## 24. False Negative Guards

Do not miss the required warning because:

- Transaction Script is a recognized Fowler pattern;
- the workflow compiles or appears straightforward;
- persistence is behind a collaborator;
- domain objects have business names;
- the operation is in one process;
- only partial duplication is shown.

## 25. Internal Boundary Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Procedural request transaction logic has complexity pressure | `FOWLER-002` | No | Yes | Emit one contextual warning. |
| Domain Model might be an alternative | No | `FOWLER-003` if separately evaluated | Yes | Mention only as possible remediation. |
| Service boundary might clarify coordination | No | `FOWLER-005` if separately evidenced | Yes | Use as boundary context. |
| DDD tactical modeling is absent | No | DDD rule with exclusive evidence | Yes | Expected non-finding. |

## 26. Cross-Catalog Boundary Expectations

### Fowler x DDD

Fowler evaluates the organization of business logic as a Transaction Script. DDD evaluates semantic modeling, invariants, and tactical domain constructs. Shared evidence is allowed, but shared conclusions are forbidden. Transaction Script does not automatically violate DDD, and Domain Model is not required by preference.

### Fowler x Layered

Layered Architecture would evaluate layer dependencies and responsibilities. This scenario does not provide a declared layered structure sufficient for Layered findings.

### Fowler x Core

Core review behavior is supported by evidence discipline and proportionality, but no `CORE-*` rule owns this finding.

### Fowler x Clean

Clean Architecture is not established. Absence of use cases or Dependency Rule evidence must not produce a Fowler or Clean finding.

### Fowler x Hexagonal

No ports/adapters conclusion is evaluated. The notification collaborator is not enough to infer a Hexagonal boundary violation.

## 27. Deduplication Expectations

| Shared Evidence | Fowler Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Inline renewal policy rules | Transaction Script complexity warning | Possible DDD modeling concern only with exclusive evidence | Yes | One `FOWLER-002` warning. |
| Data-shaped `ContractRecord` | Supports weak object behavior context | DDD anemic model not confirmed | Yes | Expected non-finding. |
| Persistence and notification coordination | Supports procedural transaction shape | Layered/Clean/Hex not established | Yes | Boundary note only. |

## 28. Expected Remediation

Expected remediation must be incremental and technology-neutral:

- preserve Transaction Script while the workflow remains understandable;
- extract duplicated eligibility checks into a shared policy component if duplication grows;
- split unrelated side-effect coordination from policy calculation when useful;
- move richer behavior into an object model only when complexity and invariants justify it;
- consider a clearer Service Layer boundary only when operation coordination becomes the primary issue.

Do not require DDD, Clean Architecture, Hexagonal Architecture, CQRS, event sourcing, microservices, messaging, ORM changes, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- equivalent names for script, handler, command, use case, or service;
- equivalent business domain such as renewal, pricing, approval, or claims;
- direct or abstracted persistence;
- different wording for the warning;
- `Low` severity if reduced impact is explicit;
- alternate existing supporting rules when boundary ownership is preserved.

## 30. Disallowed Variations

Disallowed variations:

- title, category, outcome, or Primary Rule different from the catalog;
- `Fail` without confirmed responsibility breakdown;
- `Pass` while ignoring observable complexity pressure;
- finding based only on the name `Script`;
- mandatory Domain Model or DDD;
- duplicate findings for each business rule;
- prescriptive remediation or technology mandate;
- invented Rule ID.

## 31. Execution Instructions

Evaluate the textual static manifest only.

Do not compile, run, generate, or infer executable fixture code. Treat pseudocode as non-compilable evidence. Apply `FOWLER-002` first and use supporting rules only for boundary control.

## 32. Acceptance Criteria

The scenario is accepted when:

- `FOWLER-002` is evaluated as `Applicable`;
- primary outcome is `Warning`;
- confidence is `Possible`;
- severity is `Medium` or contextually justified `Low`;
- exactly one warning finding appears;
- expected non-findings remain absent;
- DDD, Layered, Clean, Hexagonal, and Core boundaries are preserved;
- remediation is proportional;
- traceability points to the scenario catalog, models, Fowler catalog, Primary Rule, and supporting rules.

## 33. Failure Criteria

The scenario fails when:

- the warning is missing;
- Transaction Script is treated as categorically wrong;
- `Fail` is emitted without confirmed breakdown evidence;
- DDD or Domain Model absence owns the finding;
- duplicate findings repeat the same conclusion;
- naming alone is used as proof;
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
| Primary Rule normative file | `skill/rules/fowler/FOWLER-002.md` |
| Supporting Rule | `skill/rules/fowler/FOWLER-003.md` |
| Supporting Rule | `skill/rules/fowler/FOWLER-005.md` |
| Supporting Rule | `skill/rules/ddd/DDD-013.md` |
| Adjacent cataloged Rule | `skill/rules/ddd/DDD-008.md` |
| Fowler catalog review | `skill/reviews/FOWLER_CATALOG_REVIEW.md` |
| Fowler catalog stabilization | `skill/reviews/FOWLER_CATALOG_STABILIZATION.md` |
| Expected result | `evaluation/expected/fowler/EVAL-FOWLER-001-EXPECTED.md` |

## 35. Gold Standard Requirements

This scenario follows the structure of `evaluation/scenarios/core/EVAL-CORE-001.md` and adapts it to Fowler semantics. It preserves evidence discipline, contextual applicability, atomic findings, proportional remediation, false-positive protection, false-negative protection, boundary handling, deduplication, and traceability.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-FOWLER-001`.

Aligned with the Gold Standard scenario structure, evaluation models, scenario catalog identity, `FOWLER-002` as Primary Rule, selected supporting rules, expected `Warning` outcome, and DDD x Fowler boundary.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
