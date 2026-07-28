# EVAL-FULL-001 - Modular order-processing system with mixed compliance and violations

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-FULL-001` |
| Title | `Modular order-processing system with mixed compliance and violations` |
| Category | `Full Review` |
| Scenario Type | `Multiple Findings` |
| Catalogs | `Core`; `Hexagonal Architecture`; `Clean Architecture`; `DDD`; `Layered Architecture`; `Fowler`; `Events & Messaging`; `Architecture Testing`; `SOLID`; `Solution Architecture` |
| Primary Rule | `SOL-001` |
| Supporting Rules | `HEX-001`, `CLEAN-001`, `TEST-018` |
| Risk Level | `Critical` |
| Execution Type | `Mixed Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/full/EVAL-FULL-001-EXPECTED.md` |
| Related Coverage Dimensions | Full Review; `Warning`; `Possible`; `Critical`; contradictory evidence; report consistency; determinism; regression; deduplication. |

## 2. Purpose

This scenario validates full-review report consistency when an order-processing system has mixed compliance, partial evidence, and one primary warning about architectural decisions not tied consistently to requirements and constraints.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Multiple Findings` |
| Secondary Types | `Report Consistency`, `Determinism`, `Regression`, `Conflicting Evidence`, `Manual Validation`, `Automated Validation` |
| Primary Outcome | `Warning` |
| Evidence Strength | `Contradictory` |
| Applicability | `Applicable` |
| Confidence | `Possible` |
| Severity | `Critical` |

## 4. Architectural Context

The reviewed material includes ADR excerpts, module dependency notes, partial architecture-test output, and manual observations. Some boundaries are enforced, one decision lacks explicit requirement traceability, and several catalog conclusions remain partial.

## 5. Target Catalogs

`Solution Architecture` owns the primary report-level warning through `SOL-001`. Supporting Rules represent full-review context and must not absorb the decision-traceability conclusion.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `SOL-001` |
| Title | `Decisions should address explicit requirements and constraints` |
| Category | `Solution Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/solution-architecture/SOL-001.md` |
| Catalog File | `skill/rules/solution-architecture/SOL-001.md` |

`SOL-001` is selected from the catalog because the primary full-review conclusion concerns architectural decision traceability. Alternative Rules expose specific boundaries but do not own report-level decision alignment.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `HEX-001` | Boundary reference for one possible dependency violation in the full review. |
| `CLEAN-001` | Boundary reference for policy-boundary framework leakage. |
| `TEST-018` | Boundary reference for rules that exist but may not be executed. |

## 8. Input Artifacts

The input is a mixed review manifest. It is not executable code.

## 9. Directory Structure

```text
full-review/
  docs/adr-summary.md
  architecture/dependency-notes.md
  test-output/architecture-rules.txt
  report/manual-observations.md
```

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| ADR summary | Decision evidence. | One decision lacks requirement/constraint trace. |
| Dependency notes | Static evidence. | Mixed boundary signals. |
| Test output | Automated evidence. | Partial and contradictory. |
| Manual observations | Review evidence. | Scope limits recorded. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| ADR | Requirements | Missing trace | Primary warning. |
| Modules | Boundaries | Mixed evidence | Supporting context only. |
| Test output | Rules | Partial execution | Supporting context only. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Decision traceability | `SOL-001` | Partially absent |
| Dependency findings | Rule-specific catalogs | Supporting only |
| Full report coherence | Evaluation suite | Required |

## 13. Execution Flow

1. Review ADRs, dependency notes, test output, and manual observations.
2. Identify mixed evidence and conflicts.
3. Produce one primary warning under `SOL-001`.
4. Preserve other outcomes as contextual, not duplicate findings.

## 14. Preconditions

- Evaluate the full-review manifest only.
- Do not require complete source tree.
- Keep findings atomic and rule-owned.
- Preserve unknowns and contradictory evidence.

## 15. Architecture State

The architecture state is a full-review warning with contradictory evidence.

## 16. Evidence Provided

Contradictory evidence includes partial architecture-test output, mixed dependency notes, ADRs with one untraced decision, and manual observations showing incomplete review scope.

## 17. Evidence Withheld

Complete source tree, production runtime, full CI history, all ADRs, complete dependency graph, and all operational records are withheld.

## 18. Expected Findings

Exactly one primary warning finding is required.

```text
Finding ID: EVAL-FULL-001-F001
Rule ID: SOL-001
Title: Architecture decision lacks explicit requirement and constraint traceability
Outcome: Warning
Confidence: Possible
Severity: Critical
Applicability: Applicable
Evidence: The ADR summary includes an architectural decision for module integration without explicit requirement, constraint, trade-off, or validation evidence.
Impact: Full-review conclusions may be hard to validate or govern when decision rationale is not traceable.
Rationale: Contradictory and partial review evidence supports a warning under SOL-001.
Remediation: Link the affected decision to explicit requirements, constraints, trade-offs, and validation evidence without rewriting compliant modules.
Related Rules: HEX-001, CLEAN-001, TEST-018
Boundary Notes: Specific dependency or testing findings require exclusive evidence and must not duplicate this report-level warning.
```

## 19. Expected Non-Findings

Do not report all possible catalog issues, duplicate root-cause findings, global architecture failure, or complete compliance.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `SOL-001` | `Applicable` | `Warning` | `Match` |
| Scenario | `Applicable` | `Warning` | `Match` |

## 21. Expected Confidence

Expected confidence is `Possible` because evidence is contradictory and partial.

## 22. Expected Severity

Expected severity is `Critical` in the full-review context because report coherence and decision governance affect multiple catalog conclusions.

## 23. False Positive Guards

Do not duplicate findings across catalogs or overstate mixed evidence as full-system failure.

## 24. False Negative Guards

Do not miss separate findings hidden by shared root causes when exclusive evidence is present; in this scenario only the `SOL-001` warning is required.

## 25. Internal Boundary Expectations

`SOL-001` owns decision traceability. Supporting Rules retain separate ownership for dependency, framework, or test-execution conclusions.

## 26. Cross-Catalog Boundary Expectations

Full cross-catalog deduplication and report coherence must preserve all catalog boundaries and evidence gaps.

## 27. Deduplication Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Decision lacks requirement trace | Yes | No | Yes | One `SOL-001` warning. |
| Dependency/test issues | No | Yes | Yes | Only if exclusive evidence appears. |

| Shared Evidence | Primary Catalog Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Full-review manifest | Solution decision warning | Catalog-specific context | Yes | Report coherence, no duplication. |

## 28. Expected Remediation

Incrementally add traceability from the affected decision to requirements, constraints, trade-offs, and validation evidence. Do not mandate a platform, framework, rewrite, or architecture style.

## 29. Allowed Variations

Equivalent report wording and equivalent remediation are allowed if the outcome remains `Warning` under `SOL-001`.

## 30. Disallowed Variations

Global failure, merged multi-catalog finding, hidden unknowns, duplicate findings, invented Rules, or deterministic drift are disallowed.

## 31. Execution Instructions

Evaluate the mixed manifest manually. Repeated evaluation should preserve the same result unless input changes.

## 32. Acceptance Criteria

Accepted when one `SOL-001` warning appears and report sections remain consistent with scope, evidence, unknowns, and boundaries.

## 33. Failure Criteria

Fails when report output contradicts evidence, merges unrelated findings, omits unknowns, or changes nondeterministically.

## 34. Traceability

| Item | Trace |
| --- | --- |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/solution-architecture/SOL-001.md` |
| Primary Rule normative file | `skill/rules/solution-architecture/SOL-001.md` |
| Supporting Rule | `skill/rules/HEX-001.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-001.md` |
| Supporting Rule | `skill/rules/testing/TEST-018.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |

## 35. Gold Standard Requirements

This scenario follows the Gold Standard structure and adapts semantic content only.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-FULL-001`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `SOL-001`, Supporting Rules `HEX-001`, `CLEAN-001`, `TEST-018`, outcome `Warning`, and full-review boundaries.
