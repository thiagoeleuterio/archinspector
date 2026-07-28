# Expected Result - EVAL-LAYER-003

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-LAYER-003-EXPECTED` |
| Scenario ID | `EVAL-LAYER-003` |
| Scenario Title | `Shared utility referenced by multiple layers` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-LAYER-003` |
| Title | `Shared utility referenced by multiple layers` |
| Category | `Layered Architecture` |
| Scenario Type | `Warning Condition` |
| Catalogs | `Layered Architecture`; boundary references to `Core` |
| Primary Rule | `LAYER-009` |
| Supporting Rules | `LAYER-002`, `LAYER-003`, `SOLID-001` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the textual static manifest in `evaluation/scenarios/layered/EVAL-LAYER-003.md`.

The scope includes the shared utility package, neutral `TextFormatter`, mixed `SharedInvoiceContext` contract, and cross-layer consumption of UI, persistence, retry, and business hint fields.

The scope excludes executable code, full contract evolution, all consumers, runtime behavior, formal Clean/Hexagonal adoption, Fowler pattern evidence, architecture tests, CI/CD, cloud, and global modularity assessment.

## 4. Primary Rule Result

| Field             | Expected Value |
| ----------------- | -------------- |
| Rule ID           | `LAYER-009` |
| Applicability     | `Applicable` |
| Outcome           | `Warning` |
| Confidence        | `Possible` |
| Severity          | `Low` |
| Finding Required  | `Yes` |
| Finding Count     | `1` |
| Evidence Strength | `Partial` |
| Result Status     | `Match` |

## 5. Supporting Rule Results

| Rule ID | Applicability | Expected Outcome | Expected Confidence | Expected Severity Range | Expected Finding | Expected Evidence | Forbidden Finding | Boundary Notes | Acceptance Criteria |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `LAYER-002` | `Applicable` or `Undetermined` | `Warning`, `Not Enough Evidence`, or no separate result | `Possible`, `Not Enough Evidence`, or not separately reported | None unless exclusive responsibility inconsistency is reported | `No` | Mixed contract fields may support responsibility context. | A responsibility finding that merely restates contract boundary leakage. | Preserve responsibility clarity boundary. | No separate finding unless layer responsibilities are independently contradictory. |
| `LAYER-003` | `Applicable` or `Undetermined` | `Warning`, `Not Enough Evidence`, or no separate result | `Possible`, `Not Enough Evidence`, or not separately reported | None unless exclusive dependency-direction evidence is reported | `No` | Multiple layers depend on a shared contract. | A dependency-direction finding based only on shared utility reference. | Preserve dependency direction boundary. | No separate finding unless declared direction is independently violated. |
| `SOLID-001` | `Applicable` or `Undetermined` | `Warning`, `Not Enough Evidence`, or no separate result | `Possible`, `Not Enough Evidence`, or not separately reported | None unless exclusive design-principle evidence is reported | `No` | Shared abstraction stability may support remediation context. | A SOLID finding that duplicates the Layered contract warning. | Keep SOLID as non-owning support. | No separate finding unless distinct high-level policy abstraction evidence exists. |

Supporting Rules may be mentioned as related rules, boundary references, expected non-findings, or forbidden duplicate findings.

## 6. Expected Finding

```text
Finding ID: EVAL-LAYER-003-F001
Rule ID: LAYER-009
Title: Shared invoice context mixes UI, persistence, infrastructure, and business boundary data
Outcome: Warning
Confidence: Possible
Severity: Low
Applicability: Applicable
Evidence: SharedInvoiceContext is consumed by Presentation, Application, Domain, and Infrastructure and exposes uiLocale, recordKey, retryAfterFailure, and calculatedTaxHint in one shared contract.
Architectural Impact: The contract may couple layer evolution by making multiple layers understand fields owned by other responsibilities.
Responsibility Impact: Boundary-specific UI, persistence, retry, and business hint responsibilities are partially transferred through a shared type.
Dependency Impact: Multiple layers depend on a broad shared contract instead of minimal responsibility-preserving boundary data.
Rationale: The evidence satisfies LAYER-009 warning conditions because contract leakage appears plausible but scope and impact are partial.
Remediation: Split or narrow the shared contract into responsibility-preserving boundary data, keep neutral helpers shared, and move layer-specific fields to the owning layer or mediated boundary.
Related Rules: LAYER-002, LAYER-003, SOLID-001
Boundary Notes: The finding concludes only the shared contract boundary-integrity risk. It must not fail all shared utilities or duplicate dependency-direction findings.
```

## 7. Expected Finding Evidence

Required evidence:

- shared utility package is identified;
- neutral helper is distinguished from risky contract;
- `SharedInvoiceContext` is consumed by multiple layers;
- the contract exposes UI, persistence, infrastructure retry, and business hint fields;
- recurrence and impact are partial or incomplete.

This evidence is partial and structural. It is not naming-only evidence.

## 8. Expected Architectural Impact

The expected impact is a low warning risk.

One shared contract may couple layer evolution, but the evidence does not show broad systemic leakage or a confirmed failure.

## 9. Expected Rationale

`LAYER-009` applies because an identifiable layered structure and cross-layer contract are available for review.

The expected outcome is `Warning` because evidence suggests contract leakage but does not establish broad confirmed impact. Confidence is `Possible` due to partial evidence.

## 10. Expected Remediation

Expected remediation must:

- keep neutral helpers shared;
- split or narrow `SharedInvoiceContext`;
- move layer-specific fields to the owning layer or a mediated boundary;
- preserve minimal responsibility-safe boundary data.

It must not require Clean Architecture, Hexagonal Architecture, DDD, microservices, a framework, project separation, or rewrite.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- all shared libraries;
- neutral `TextFormatter` usage;
- stable shared identifiers;
- shared primitive values;
- absence of separate projects;
- absence of formal Clean Architecture;
- absence of formal Hexagonal Architecture;
- absence of DDD;
- monolithic deployment;
- dependency direction violation without exclusive evidence;
- persistence placement violation without exclusive evidence;
- SOLID violation as a duplicate;
- microservice absence;
- architecture-test absence.

## 12. Expected Applicability

Applicability is `Applicable`.

The manifest identifies the layered structure and a cross-layer contract whose integrity can be evaluated.

## 13. Expected Outcome

Outcome is `Warning`.

The observed result must not convert the partial contract risk into automatic failure or ignore it as harmless naming.

## 14. Expected Confidence

Confidence is `Possible`.

The conclusion is constrained by partial scope and missing full consumer/evolution evidence.

## 15. Expected Severity

Severity is `Low`.

The issue is localized to one contract. `Medium` is allowed only with explicit broader-impact justification while preserving `Warning`.

## 16. Expected Evidence Interpretation

Shared utility usage must be split into legitimate neutral helper evidence and mixed-contract boundary risk evidence.

The shared folder name is not enough. The contract fields and cross-layer usage drive the warning.

## 17. Expected Boundary Behavior

### Layered x Clean Architecture

Clean boundary-data findings are forbidden without Clean-specific use case or policy boundary evidence.

### Layered x Hexagonal Architecture

Hexagonal adapter model leakage is not established by this manifest.

### Layered x Core

Core behavior validates proportional warning handling and prevents universal shared-library prohibition.

### Layered x Fowler

Fowler DTO or Registry findings require pattern-specific evidence.

## 18. Expected Deduplication Behavior

Shared evidence is permitted.

Forbidden duplicate finding patterns include:

- `LAYER-002` finding that merely restates contract leakage;
- `LAYER-003` finding based only on shared contract reference;
- `SOLID-001` finding duplicating Layered contract instability;
- Clean boundary-data finding without Clean-specific boundary evidence;
- Fowler DTO finding without transfer-pattern evidence.

## 19. Expected False Positive Protection

The expected result must avoid findings based only on:

- shared utility existence;
- a shared package name;
- neutral helpers;
- shared identifiers;
- same-project organization;
- lack of separate layers as projects.

Only the mixed responsibility contract supports the warning.

## 20. Expected False Negative Protection

The expected result must not miss the warning because:

- the contract is called shared;
- fields are simple;
- all layers can technically reference it;
- the system is small;
- the contract is convenient;
- no formal Layered Architecture claim exists.

## 21. Allowed Result Variations

Allowed variations:

- equivalent finding title specific to mixed shared contract boundary risk;
- equivalent evidence ordering;
- equivalent technology-neutral remediation phrasing;
- `Medium` severity with explicit broader-impact justification;
- supporting Rule omission when boundaries remain preserved;
- result status `Acceptable Variation` only when `Warning`, `Possible`, and one finding remain.

## 22. Disallowed Result Variations

Disallowed variations:

- primary outcome other than `Warning`;
- applicability other than `Applicable`;
- confidence upgraded to `Confirmed`;
- missing warning;
- more than one finding for the same shared-contract conclusion;
- generic shared-library failure;
- finding based only on naming;
- nonexistent Rule ID;
- Primary Rule changed away from `LAYER-009`;
- remediation requiring unrelated redesign, tooling, architecture style, or rewrite.

## 23. Comparison Method

Compare observed output against this expected result by checking scenario identity, Primary Rule identity, applicability, outcome, confidence, severity, required finding presence, finding atomicity, evidence interpretation, expected non-findings, false-positive guards, false-negative guards, boundary behavior, deduplication behavior, remediation proportionality, and traceability.

Manual comparison is sufficient for this static textual scenario.

## 24. Acceptance Criteria

The observed result is accepted when:

- `LAYER-009` is the Primary Rule result;
- applicability is `Applicable`;
- outcome is `Warning`;
- confidence is `Possible`;
- severity is `Low` or accepted contextual `Medium`;
- exactly one warning finding is present;
- expected non-findings are absent;
- boundary ownership is preserved;
- duplicate findings are absent;
- remediation is proportional and technology-neutral;
- result status is `Match` or an allowed variation explicitly classified as acceptable.

## 25. Failure Criteria

The observed result fails when:

- the required warning is absent;
- the result is unsupported `Pass`, confirmed `Fail`, `Not Applicable`, or `Not Enough Evidence`;
- confidence is upgraded without evidence;
- expected non-findings appear;
- Primary Rule is nonexistent or reassigned away from `LAYER-009`;
- remediation is prescriptive beyond the evidence;
- boundary behavior contradicts the scenario.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only when it stays within allowed variations and preserves the required architectural conclusion.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/layered/EVAL-LAYER-003.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/LAYER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/layered/LAYER-009.md` |
| Supporting Rule | `skill/rules/layered/LAYER-002.md` |
| Supporting Rule | `skill/rules/layered/LAYER-003.md` |
| Supporting Rule | `skill/rules/solid/SOLID-001.md` |
| Layered catalog review | `skill/reviews/LAYER_CATALOG_REVIEW.md` |
| Layered catalog stabilization | `skill/reviews/LAYER_CATALOG_STABILIZATION.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Fowler boundary review | `skill/reviews/FOWLER_CATALOG_REVIEW.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Gold Standard stabilization | `evaluation/stabilizations/EVAL-CORE-001-STABILIZATION.md` |

## 28. Gold Standard Result Requirements

This expected result follows the gold standard reference for structure, identity, evidence interpretation, applicability, outcome, confidence, severity, required finding, atomicity, remediation, expected non-findings, false-positive protection, false-negative protection, boundary behavior, deduplication, allowed variations, disallowed variations, comparison method, and traceability.

It does not redefine Rule meaning or catalog ownership.

## 29. Result Change Notes

Initial expected result for `EVAL-LAYER-003`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `LAYER-009`, selected Supporting Rules, and expected `Warning` result.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
