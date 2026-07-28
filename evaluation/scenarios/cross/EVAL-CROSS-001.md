# EVAL-CROSS-001 - Domain service directly depends on a database framework

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CROSS-001` |
| Title | `Domain service directly depends on a database framework` |
| Category | `Cross-Catalog` |
| Scenario Type | `Cross-Catalog Boundary` |
| Catalogs | `Core`; `Hexagonal Architecture`; `Clean Architecture`; `DDD`; `Layered Architecture` |
| Primary Rule | `HEX-001` |
| Supporting Rules | `CLEAN-004`, `LAYER-007`, `SOLID-001` |
| Risk Level | `High` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/cross/EVAL-CROSS-001-EXPECTED.md` |
| Related Coverage Dimensions | Cross-catalog boundary; `Fail`; `Confirmed`; `High`; strong evidence; Core x Hexagonal x Clean x DDD x Layered; deduplication. |

## 2. Purpose

This scenario validates that a domain service directly depending on a database framework is reported once under the owning Hexagonal Rule and is not duplicated across neighboring catalogs.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Cross-Catalog Boundary` |
| Secondary Types | `Confirmed Violation`, `Multiple Findings` |
| Primary Outcome | `Fail` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Confirmed` |
| Severity | `High` |

## 4. Architectural Context

The reviewed manifest shows `PricingDomainService` importing a database framework query type and executing persistence during domain decision logic. No port, repository contract, gateway, or equivalent boundary is present.

## 5. Target Catalogs

The scenario is Cross-Catalog because the same evidence may look relevant to Clean, DDD, Layered, and SOLID concerns. `HEX-001` owns the conclusion because the primary violation is domain code depending on infrastructure.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `HEX-001` |
| Title | `Domain layer must not depend on infrastructure` |
| Category | `Hexagonal Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/HEX-001.md` |
| Catalog File | `skill/rules/HEX_CATALOG.md` |

`HEX-001` is selected directly from `evaluation/SCENARIO_CATALOG.md`. Supporting alternatives are not primary because they would either restate dependency direction or require distinct evidence about use cases, layer ownership, or dependency inversion.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `CLEAN-004` | Boundary reference for use-case isolation without duplicating domain-to-infrastructure coupling. |
| `LAYER-007` | Boundary reference for persistence placement only if layered ownership is separately evidenced. |
| `SOLID-001` | Boundary reference for dependency inversion remediation without owning the finding. |

## 8. Input Artifacts

The input is a static textual manifest, not compilable code.

## 9. Directory Structure

```text
pricing/
  domain/PricingDomainService
  infrastructure/DatabaseQueryApi
  application/PriceQuoteWorkflow
```

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `PricingDomainService` | Domain behavior. | Imports and uses database framework query API. |
| `DatabaseQueryApi` | Infrastructure concern. | Concrete persistence framework surface. |
| `PriceQuoteWorkflow` | Application entry. | Delegates to domain behavior. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `PricingDomainService` | `DatabaseQueryApi` | Direct import/use | Domain depends on infrastructure. |
| `PricingDomainService` | database query execution | Behavior | Persistence executes inside domain decision. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Pricing decision | Domain | Domain |
| Persistence detail | Infrastructure behind boundary | Domain service |
| Cross-catalog duplicate control | Evaluation suite | Required |

## 13. Execution Flow

1. Workflow asks domain service for a price.
2. Domain service imports database API.
3. Domain service executes query during pricing decision.
4. No abstraction separates domain from infrastructure.

## 14. Preconditions

- Evaluate only the manifest.
- Use `HEX-001` as the sole Primary Rule.
- Do not infer additional Clean, DDD, Layered, or SOLID findings.

## 15. Architecture State

The architecture state is a confirmed cross-catalog boundary violation owned by `HEX-001`.

## 16. Evidence Provided

Strong evidence includes domain scope, concrete database framework dependency, persistence behavior inside domain logic, and absence of a boundary abstraction.

## 17. Evidence Withheld

Full DDD model, complete layered architecture, executable code, framework runtime details, and complete repository dependency graph are withheld.

## 18. Expected Findings

Exactly one finding is required.

```text
Finding ID: EVAL-CROSS-001-F001
Rule ID: HEX-001
Title: Domain service directly depends on database framework infrastructure
Outcome: Fail
Confidence: Confirmed
Severity: High
Applicability: Applicable
Evidence: PricingDomainService imports and uses DatabaseQueryApi during domain decision logic without a port, gateway, or contract.
Impact: Domain behavior is coupled to infrastructure and cannot evolve independently from the database framework.
Rationale: Direct domain-to-infrastructure dependency satisfies HEX-001.
Remediation: Move database framework usage behind a boundary abstraction owned outside the domain dependency direction.
Related Rules: CLEAN-004, LAYER-007, SOLID-001
Boundary Notes: Neighboring catalogs must not duplicate the same conclusion.
```

## 19. Expected Non-Findings

No confirmed findings for DDD tactical absence, use-case isolation, layer naming, repository pattern choice, SOLID design principle, or formal architecture absence are expected.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `HEX-001` | `Applicable` | `Fail` | `Match` |
| Scenario | `Applicable` | `Fail` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed` because direct dependency and behavior evidence are provided.

## 22. Expected Severity

Expected severity is `High` because central domain logic is tied to infrastructure.

## 23. False Positive Guards

Shared evidence must not create duplicate semantic findings. Do not fail based only on the service name or folder structure.

## 24. False Negative Guards

Detect the core boundary violation even if the component is named `DomainService`, the system is small, or no formal Hexagonal Architecture is claimed.

## 25. Internal Boundary Expectations

Neighboring Hexagonal Rules may share evidence, but `HEX-001` owns the direct domain-to-infrastructure conclusion.

## 26. Cross-Catalog Boundary Expectations

Core x Hexagonal x Clean x DDD x Layered boundaries must preserve one owner conclusion and forbid duplicate findings.

## 27. Deduplication Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Domain depends on database framework | Yes | No | Yes | One `HEX-001` finding. |
| Layered persistence placement | No | Yes | Yes | Non-finding unless separately evidenced. |

| Shared Evidence | Primary Catalog Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Database framework import | Hexagonal dependency violation | Clean/Layered/SOLID context | Yes | Boundary notes only. |

## 28. Expected Remediation

Remove the direct database framework dependency from domain behavior and introduce a boundary abstraction. Do not mandate microservices, DDD, a specific framework, or a rewrite.

## 29. Allowed Variations

Equivalent finding title and remediation are allowed if ownership and outcome remain unchanged.

## 30. Disallowed Variations

Duplicate findings, reassignment away from `HEX-001`, `Pass`, `Warning` only, or naming-only reasoning are disallowed.

## 31. Execution Instructions

Evaluate statically. Do not create code, tests, scripts, reviews, or stabilizations.

## 32. Acceptance Criteria

Accepted when exactly one `HEX-001` finding appears with `Fail`, `Confirmed`, `High`, proportional remediation, and no duplicate catalog findings.

## 33. Failure Criteria

Fails when the finding is missing, duplicated, generic, assigned to another Rule, or remediated with unrelated prescriptions.

## 34. Traceability

| Item | Trace |
| --- | --- |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/HEX_CATALOG.md` |
| Primary Rule normative file | `skill/rules/HEX-001.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-004.md` |
| Supporting Rule | `skill/rules/layered/LAYER-007.md` |
| Supporting Rule | `skill/rules/solid/SOLID-001.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |

## 35. Gold Standard Requirements

This scenario follows the Gold Standard structure and adapts semantic content only.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-CROSS-001`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `HEX-001`, Supporting Rules `CLEAN-004`, `LAYER-007`, `SOLID-001`, outcome `Fail`, and cross-catalog boundaries.
