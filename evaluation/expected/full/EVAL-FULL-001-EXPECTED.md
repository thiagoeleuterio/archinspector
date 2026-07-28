# Expected Result - EVAL-FULL-001

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-FULL-001-EXPECTED` |
| Scenario ID | `EVAL-FULL-001` |
| Scenario Title | `Modular order-processing system with mixed compliance and violations` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result for inventory correction. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-FULL-001` |
| Title | `Modular order-processing system with mixed compliance and violations` |
| Category | `Full Review` |
| Scenario Type | `Multiple Findings` |
| Catalogs | `Core`; `Hexagonal Architecture`; `Clean Architecture`; `DDD`; `Layered Architecture`; `Fowler`; `Events & Messaging`; `Architecture Testing`; `SOLID`; `Solution Architecture` |
| Primary Rule | `SOL-001` |
| Supporting Rules | `HEX-001`, `CLEAN-001`, `TEST-018` |
| Execution Type | `Mixed Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers full-review mixed evidence in `evaluation/scenarios/full/EVAL-FULL-001.md`, including ADR excerpts, dependency notes, partial test output, manual observations, and withheld global evidence.

## 4. Primary Rule Result

| Field | Expected Value |
| --- | --- |
| Rule ID | `SOL-001` |
| Applicability | `Applicable` |
| Outcome | `Warning` |
| Confidence | `Possible` |
| Severity | `Critical` |
| Finding Required | `Yes` |
| Finding Count | `1` |
| Evidence Strength | `Contradictory` |
| Result Status | `Match` |

## 5. Supporting Rule Results

| Rule ID | Applicability | Expected Outcome | Expected Confidence | Expected Severity Range | Expected Finding | Expected Evidence | Forbidden Finding | Boundary Notes | Acceptance Criteria |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `HEX-001` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | Contextual only | `No` unless exclusive evidence exists | Dependency notes only. | Dependency finding that duplicates report-level warning. | Preserve Hex boundary. | No duplicate finding. |
| `CLEAN-001` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | Contextual only | `No` unless exclusive evidence exists | Framework boundary context. | Clean finding without exclusive evidence. | Preserve Clean boundary. | No duplicate finding. |
| `TEST-018` | `Applicable` or `Undetermined` | Boundary context | Evidence-based | Contextual only | `No` unless exclusive evidence exists | Partial execution output. | Test execution finding that restates report warning. | Preserve Testing boundary. | No duplicate finding. |

## 6. Expected Finding

```text
Finding ID: EVAL-FULL-001-F001
Rule ID: SOL-001
Title: Architecture decision lacks explicit requirement and constraint traceability
Outcome: Warning
Confidence: Possible
Severity: Critical
Applicability: Applicable
Evidence: The ADR summary includes an architectural decision for module integration without explicit requirement, constraint, trade-off, or validation evidence.
Architectural Impact: Full-review conclusions may be hard to validate or govern when decision rationale is not traceable.
Rationale: Contradictory and partial review evidence supports a warning under SOL-001.
Remediation: Link the affected decision to explicit requirements, constraints, trade-offs, and validation evidence without rewriting compliant modules.
Related Rules: HEX-001, CLEAN-001, TEST-018
Boundary Notes: Specific dependency or testing findings require exclusive evidence and must not duplicate this report-level warning.
```

## 7. Expected Finding Evidence

Required evidence is an ADR decision lacking requirement/constraint traceability within a mixed full-review manifest.

## 8. Expected Architectural Impact

Report coherence and governance are weakened across multiple evaluated catalogs.

## 9. Expected Rationale

`SOL-001` owns decision traceability; contradictory evidence supports `Warning` with `Possible` confidence.

## 10. Expected Remediation

Add requirement, constraint, trade-off, and validation traceability for the affected decision. Do not rewrite compliant modules.

## 11. Expected Non-Findings

Do not report all possible catalog issues, duplicate root-cause findings, full-system failure, complete compliance, or unscoped dependency findings.

## 12. Expected Applicability

Applicability is `Applicable`.

## 13. Expected Outcome

Outcome is `Warning`.

## 14. Expected Confidence

Confidence is `Possible`.

## 15. Expected Severity

Severity is `Critical` due report-level breadth.

## 16. Expected Evidence Interpretation

Contradictory evidence must constrain confidence and preserve unknowns.

## 17. Expected Boundary Behavior

`SOL-001` owns the report-level warning; supporting Rules keep exclusive catalog ownership.

## 18. Expected Deduplication Behavior

Do not split one decision-traceability issue into multiple catalog findings.

## 19. Expected False Positive Protection

Do not duplicate findings across catalogs or overstate mixed evidence.

## 20. Expected False Negative Protection

Do not miss separate findings hidden by shared root causes when exclusive evidence is present; here only one primary warning is required.

## 21. Allowed Result Variations

Equivalent report wording and remediation are allowed if `SOL-001`, `Warning`, `Possible`, `Critical`, and one finding remain.

## 22. Disallowed Result Variations

Global failure, merged multi-catalog finding, hidden unknowns, duplicate findings, invented Rules, or nondeterministic drift is disallowed.

## 23. Comparison Method

Compare report identity, Rule ownership, outcome, confidence, severity, finding, non-findings, evidence limits, boundaries, remediation, determinism, and traceability.

## 24. Acceptance Criteria

Accepted when one `SOL-001` warning appears and the report remains consistent with scope, evidence, unknowns, and boundaries.

## 25. Failure Criteria

Fails when report output contradicts evidence, merges unrelated findings, omits unknowns, duplicates findings, or changes nondeterministically.

## 26. Result Status

Expected result status is `Match`.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/full/EVAL-FULL-001.md` |
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

## 28. Gold Standard Result Requirements

This expected result follows the Gold Standard expected-result structure.

## 29. Result Change Notes

Initial expected result for `EVAL-FULL-001`.

Created to correct the incomplete Evaluation Suite inventory, with identity copied from `evaluation/SCENARIO_CATALOG.md`, aligned to the Gold Standard, using Primary Rule `SOL-001`, Supporting Rules `HEX-001`, `CLEAN-001`, `TEST-018`, outcome `Warning`, and full-review boundaries.
