# EVAL-CROSS-005 - Layered monolith uses Transaction Script appropriately

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CROSS-005` |
| Title | `Layered monolith uses Transaction Script appropriately` |
| Category | `Cross-Catalog` |
| Scenario Type | `Cross-Catalog Boundary` |
| Catalogs | `Layered Architecture`; `Fowler`; `Core` |
| Primary Rule | `FOWLER-002` |
| Supporting Rules | `LAYER-005`, `DDD-013`, `SOL-001` |
| Risk Level | `Low` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P2` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/cross/EVAL-CROSS-005-EXPECTED.md` |
| Related Coverage Dimensions | Cross-catalog boundary; `Pass`; `Likely`; low severity context; strong evidence; legitimate absence; false-positive guard. |

## 2. Purpose

This scenario validates that Transaction Script can be appropriate in a simple layered CRUD monolith without requiring DDD or richer architectural patterns.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Cross-Catalog Boundary` |
| Secondary Types | `Positive Compliance`, `Legitimate Absence`, `False Positive Guard` |
| Primary Outcome | `Pass` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Likely` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The reviewed application is a small internal CRUD system. Application scripts coordinate validation, persistence calls, and response mapping. No complex invariants, aggregate lifecycle, or domain model need is evidenced.

## 5. Target Catalogs

`FOWLER-002` owns the Transaction Script conclusion. Layered Architecture and Core provide proportionality boundaries; DDD absence is legitimate in this context.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `FOWLER-002` |
| Title | `Transaction Script` |
| Category | `Fowler Patterns` |
| Status | `Active` |
| Normative File | `skill/rules/fowler/FOWLER-002.md` |
| Catalog File | `skill/rules/FOWLER_CATALOG.md` |

`FOWLER-002` is selected from the catalog because the primary conclusion is pattern fit. Supporting alternatives do not own Transaction Script suitability.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `LAYER-005` | Boundary reference for application orchestration in layers. |
| `DDD-013` | Boundary reference for legitimate absence of tactical DDD. |
| `SOL-001` | Boundary reference for proportional architectural decisions. |

## 8. Input Artifacts

The input is a static textual manifest.

## 9. Directory Structure

```text
admin-crud/
  presentation/AdminController
  application/UpdateStatusScript
  persistence/StatusTableGateway
```

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `UpdateStatusScript` | Transaction Script. | Coordinates simple CRUD update. |
| `StatusTableGateway` | Persistence access. | Called by application script. |
| `AdminController` | Presentation entry. | Delegates to application script. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| Controller | Application script | Layer delegation | Acceptable. |
| Application script | Persistence gateway | CRUD coordination | Acceptable for simple scope. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Simple workflow coordination | Transaction Script | Present |
| Rich domain behavior | Domain Model | Legitimately absent |
| Layer mediation | Layered Architecture | Preserved |

## 13. Execution Flow

1. Controller receives update request.
2. Application script validates simple fields.
3. Script updates one table through gateway.
4. Script returns result.

## 14. Preconditions

- Evaluate current CRUD scope only.
- Do not require DDD or Domain Model universally.
- Do not ignore concrete layer bypass if later provided.

## 15. Architecture State

The architecture state is positive compliance for pattern-context fit.

## 16. Evidence Provided

Strong evidence includes simple CRUD workflow, low domain complexity, explicit layered mediation, and absence of complex invariants.

## 17. Evidence Withheld

Future roadmap complexity, non-CRUD workflows, complete production dependency graph, and performance concerns are withheld.

## 18. Expected Findings

No corrective finding is expected. Expected Finding Count: 0.

## 19. Expected Non-Findings

Do not report absence of Domain Model, aggregates, DDD patterns, microservices, architecture tests, or rich layering as violations.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `FOWLER-002` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Likely` because static scope evidence is strong while future complexity is withheld.

## 22. Expected Severity

No severity applies because no finding is expected.

## 23. False Positive Guards

Do not treat absence of Domain Model as failure in a simple layered CRUD context.

## 24. False Negative Guards

Do not miss layer bypass or accumulated business complexity if such evidence appears.

## 25. Internal Boundary Expectations

Fowler Transaction Script fit remains separate from Active Record, Repository, and Domain Model conclusions.

## 26. Cross-Catalog Boundary Expectations

Layered x Fowler x Core boundaries preserve proportionality and prevent universal DDD prescription.

## 27. Deduplication Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Transaction Script appropriate | Yes | No | Yes | `Pass` under `FOWLER-002`. |
| DDD not needed | No | No finding | Yes | Legitimate absence context. |

| Shared Evidence | Primary Catalog Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Simple CRUD workflow | Pattern fit pass | Layer/Core context | Yes | No finding. |

## 28. Expected Remediation

No remediation is expected for this non-finding scenario.

## 29. Allowed Variations

Equivalent pass wording is allowed if no DDD prescription or duplicate finding is introduced.

## 30. Disallowed Variations

Findings for lack of DDD, mandatory Domain Model, mandatory architecture tests, or invented Rules are disallowed.

## 31. Execution Instructions

Evaluate statically.

## 32. Acceptance Criteria

Accepted when `FOWLER-002` passes and proportionality is preserved.

## 33. Failure Criteria

Fails when Transaction Script is rejected without complexity evidence or layer bypass is ignored if present.

## 34. Traceability

| Item | Trace |
| --- | --- |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/FOWLER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/fowler/FOWLER-002.md` |
| Supporting Rule | `skill/rules/layered/LAYER-005.md` |
| Supporting Rule | `skill/rules/ddd/DDD-013.md` |
| Supporting Rule | `skill/rules/solution-architecture/SOL-001.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |

## 35. Gold Standard Requirements

This scenario follows the Gold Standard structure and adapts semantic content only.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-CROSS-005`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `FOWLER-002`, Supporting Rules `LAYER-005`, `DDD-013`, `SOL-001`, outcome `Pass`, and Layered x Fowler x Core boundaries.
