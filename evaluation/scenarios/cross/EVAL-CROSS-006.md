# EVAL-CROSS-006 - Insufficient evidence across multiple architectural catalogs

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CROSS-006` |
| Title | `Insufficient evidence across multiple architectural catalogs` |
| Category | `Cross-Catalog` |
| Scenario Type | `Insufficient Evidence` |
| Catalogs | `Core`; `Hexagonal Architecture`; `Clean Architecture`; `DDD`; `Layered Architecture`; `Fowler`; `Events & Messaging`; `Architecture Testing` |
| Primary Rule | `TEST-010` |
| Supporting Rules | `HEX-002`, `CLEAN-013`, `MSG-006` |
| Risk Level | `High` |
| Execution Type | `Document Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/cross/EVAL-CROSS-006-EXPECTED.md` |
| Related Coverage Dimensions | Cross-catalog insufficiency; `Not Enough Evidence`; absent evidence; naming-based reliability; report consistency; false-positive and false-negative guards. |

## 2. Purpose

This scenario validates that names, labels, and partial diagrams across several catalogs produce `Not Enough Evidence` rather than inferred violations or compliance.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Insufficient Evidence` |
| Secondary Types | `Cross-Catalog Boundary`, `Report Consistency`, `Conflicting Evidence`, `Partial Scope` |
| Primary Outcome | `Not Enough Evidence` |
| Evidence Strength | `Absent` |
| Applicability | `Undetermined` |
| Confidence | `Not Enough Evidence` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The document fixture contains package names such as `domain`, `adapter`, `usecase`, and `events`, plus a partial diagram. No implementation, dependency graph, execution output, or behavioral evidence is supplied.

## 5. Target Catalogs

`TEST-010` owns the conclusion because the main risk is naming-based rule unreliability. Other catalogs are boundary references whose conclusions are not supportable.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `TEST-010` |
| Title | `Naming-based rule reliability` |
| Category | `Architecture Testing` |
| Status | `Active` |
| Normative File | `skill/rules/testing/TEST-010.md` |
| Catalog File | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |

`TEST-010` is selected from the catalog because it is the most specific Rule for guarding against architecture conclusions based on names alone. Supporting alternatives need implementation evidence not present here.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `HEX-002` | Boundary reference for ports named in documents but not implemented. |
| `CLEAN-013` | Boundary reference for package names without dependency graph. |
| `MSG-006` | Boundary reference for event semantics documented without behavior. |

## 8. Input Artifacts

The input is a document-only fixture.

## 9. Directory Structure

```text
architecture-notes/
  packages.txt
  partial-context-diagram.md
  glossary.md
```

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `packages.txt` | Naming list. | Labels only. |
| `partial-context-diagram.md` | Diagram. | No dependencies or behavior. |
| `glossary.md` | Terminology. | No implementation evidence. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| Names | Architecture conclusions | Unsupported | Insufficient evidence. |
| Diagram | Runtime behavior | Absent | No confirmed conclusion. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Evidence reliability | `TEST-010` | Primary |
| Catalog-specific conclusions | Neighboring catalogs | Undetermined |
| Report limits | Evaluation suite | Required |

## 13. Execution Flow

1. Review names and partial diagram.
2. Identify missing implementation and dependency evidence.
3. Preserve unknowns across catalogs.
4. Produce no corrective finding.

## 14. Preconditions

- Do not infer architecture from naming.
- Do not upgrade confidence without implementation evidence.
- Keep cross-catalog unknowns explicit.

## 15. Architecture State

The architecture state is insufficient evidence across multiple catalogs.

## 16. Evidence Provided

Absent or nominal evidence includes labels, package names, diagram boxes, and glossary terms without behavior.

## 17. Evidence Withheld

Source code, dependency graph, executable architecture tests, message flows, domain model behavior, runtime evidence, and complete documents are withheld.

## 18. Expected Findings

No corrective finding is expected. Expected Finding Count: 0.

## 19. Expected Non-Findings

Do not report Hexagonal, Clean, DDD, Layered, Fowler, Events, Testing, SOLID, or Solution findings from names alone.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `TEST-010` | `Undetermined` | `Not Enough Evidence` | `Match` |
| Scenario | `Undetermined` | `Not Enough Evidence` | `Match` |

## 21. Expected Confidence

Expected confidence is `Not Enough Evidence`.

## 22. Expected Severity

No severity applies because no finding is expected.

## 23. False Positive Guards

Naming and catalog labels must not create cross-catalog violations or compliance claims.

## 24. False Negative Guards

Do not hide missing implementation and dependency evidence behind good-looking labels or diagrams.

## 25. Internal Boundary Expectations

`TEST-010` owns reliability of naming-based evidence. Catalog-specific Rules remain undetermined.

## 26. Cross-Catalog Boundary Expectations

All catalog conclusions are withheld unless their own evidence exists. Cross-catalog report language must expose unknowns.

## 27. Deduplication Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Names are insufficient | Yes | No | Yes | `Not Enough Evidence`. |
| Specific catalog violation | No | Yes | Yes | Forbidden without evidence. |

| Shared Evidence | Primary Catalog Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Package names | Evidence insufficiency | No catalog-specific conclusion | Yes | Unknowns only. |

## 28. Expected Remediation

No corrective remediation is expected. Requesting dependency, implementation, or execution evidence for future evaluation is allowed.

## 29. Allowed Variations

Equivalent unknown wording is allowed if no confirmed finding appears.

## 30. Disallowed Variations

Any confirmed pass, fail, warning, duplicate finding, invented Rule, or hidden evidence gap is disallowed.

## 31. Execution Instructions

Review documents manually. Do not infer missing implementation.

## 32. Acceptance Criteria

Accepted when outcome is `Not Enough Evidence`, confidence is `Not Enough Evidence`, and no catalog-specific finding is produced.

## 33. Failure Criteria

Fails when names or diagrams become confirmed architecture evidence.

## 34. Traceability

| Item | Trace |
| --- | --- |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |
| Primary Rule normative file | `skill/rules/testing/TEST-010.md` |
| Supporting Rule | `skill/rules/HEX-002.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-013.md` |
| Supporting Rule | `skill/rules/events/MSG-006.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |

## 35. Gold Standard Requirements

This scenario follows the Gold Standard structure and adapts semantic content only.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-CROSS-006`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `TEST-010`, Supporting Rules `HEX-002`, `CLEAN-013`, `MSG-006`, outcome `Not Enough Evidence`, and full cross-catalog insufficiency boundaries.
