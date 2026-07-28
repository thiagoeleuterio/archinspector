# Expected Result - EVAL-LAYER-002

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-LAYER-002-EXPECTED` |
| Scenario ID | `EVAL-LAYER-002` |
| Scenario Title | `Application layer orchestrates domain and infrastructure contracts` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-LAYER-002` |
| Title | `Application layer orchestrates domain and infrastructure contracts` |
| Category | `Layered Architecture` |
| Scenario Type | `Positive Compliance` |
| Catalogs | `Layered Architecture`; boundary references to `Clean Architecture` and `Hexagonal Architecture` |
| Primary Rule | `LAYER-005` |
| Supporting Rules | `LAYER-002`, `LAYER-006`, `HEX-004` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the textual static manifest in `evaluation/scenarios/layered/EVAL-LAYER-002.md`.

The scope includes Application orchestration, Domain business decisions, Infrastructure contract implementation, contract-mediated persistence, and absence of business rule ownership or concrete persistence dependency inside Application.

The scope excludes executable code, framework behavior, database-product behavior, full DDD assessment, formal Clean Architecture adoption, formal Hexagonal Architecture adoption, architecture tests, CI/CD, cloud, and runtime verification.

## 4. Primary Rule Result

| Field             | Expected Value |
| ----------------- | -------------- |
| Rule ID           | `LAYER-005` |
| Applicability     | `Applicable` |
| Outcome           | `Pass` |
| Confidence        | `Likely` |
| Severity          | `Not Applicable` |
| Finding Required  | `No` |
| Finding Count     | `0` |
| Evidence Strength | `Strong` |
| Result Status     | `Match` |

## 5. Supporting Rule Results

| Rule ID | Applicability | Expected Outcome | Expected Confidence | Expected Severity Range | Expected Finding | Expected Evidence | Forbidden Finding | Boundary Notes | Acceptance Criteria |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `LAYER-002` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Likely`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive responsibility finding evidence is reported | `No` | Layer responsibilities are explicit enough to support `LAYER-005`. | A responsibility finding that merely restates application coordination compliance. | Preserve responsibility clarity boundary. | No separate finding unless responsibility contradiction is independently evidenced. |
| `LAYER-006` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Likely`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive business-rule ownership evidence is reported | `No` | Domain policy and entity own eligibility and acceptance decisions. | A business-rule ownership finding that duplicates the `LAYER-005` no-finding result. | Preserve domain/business ownership boundary. | No corrective finding unless rules are observed outside Domain. |
| `HEX-004` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Likely`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive Hexagonal evidence is reported | `No` | `OrderStore` may be referenced as contract-mediated external access context. | A Hexagonal outbound-port finding that replaces the Layered coordination result. | Preserve Hexagonal boundary without requiring formal ports/adapters. | No separate finding unless Hexagonal core/outbound evidence is independently evaluated. |

Supporting Rules may be mentioned as related rules, boundary references, expected non-findings, or forbidden duplicate findings.

## 6. Expected Finding

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: LAYER-005
Outcome: Pass
Confidence: Likely
Severity: Not Applicable
Applicability: Applicable
Evidence: SubmitOrderService coordinates loading, domain eligibility evaluation, domain acceptance, and saving through OrderStore while business decisions remain in OrderEligibilityPolicy and Order, and SqlOrderStore remains outside Application.
Architectural Impact: No corrective impact is present because the Application layer coordinates without owning business rules.
Responsibility Impact: Application, Domain, and Infrastructure responsibilities remain distinguishable in the reviewed scope.
Dependency Impact: Application depends on a contract and domain behavior, not a concrete persistence implementation.
Rationale: LAYER-005 pass conditions are satisfied by coordination with delegated business decisions and contract-mediated infrastructure access.
Remediation: None.
Related Rules: LAYER-002, LAYER-006, HEX-004
Boundary Notes: The result concludes only application-layer coordination compliance. It must not become a Clean, Hexagonal, DDD, or Repository Pattern prescription.
```

## 7. Expected Finding Evidence

Required no-finding evidence:

- Application layer scope is identified;
- `SubmitOrderService` coordinates workflow steps;
- business decisions are delegated to `OrderEligibilityPolicy` and `Order`;
- persistence is accessed through `OrderStore`;
- `SqlOrderStore` is outside Application;
- no concrete persistence dependency or database settings are in Application.

This evidence is structural and behavioral. It is not naming-only evidence.

## 8. Expected Architectural Impact

The expected impact is absence of corrective architectural impact.

The Application layer preserves coordination responsibility without absorbing Domain business rules or Infrastructure mechanisms.

## 9. Expected Rationale

`LAYER-005` applies because the reviewed material identifies an application/service layer and a coordinated operation involving domain and persistence responsibilities.

The expected outcome is `Pass` because evidence shows coordination and delegation rather than business rule ownership. Confidence is `Likely` because direct manifest evidence is strong but implementation details are withheld.

## 10. Expected Remediation

No corrective remediation is expected.

Observed output may recommend preserving the current boundaries, but it must not require Clean Architecture, Hexagonal Architecture, DDD, microservices, CQRS, event sourcing, a framework, ORM, project separation, cloud, containers, or a rewrite.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- Application coordinating multiple collaborators;
- Application depending on domain components;
- Application depending on a persistence contract;
- transaction boundary naming;
- infrastructure implementing a contract;
- absence of DDD tactical patterns;
- absence of Clean Architecture formalism;
- absence of Hexagonal Architecture formalism;
- absence of multiple adapters;
- absence of exactly four layers;
- monolithic deployment;
- absence of architecture tests;
- absence of microservices.

## 12. Expected Applicability

Applicability is `Applicable`.

The manifest provides enough evidence to identify the Application layer responsibility and evaluate coordination versus business rule ownership.

## 13. Expected Outcome

Outcome is `Pass`.

The observed result must pass the Primary Rule because direct evidence shows legitimate orchestration and delegation.

## 14. Expected Confidence

Confidence is `Likely`.

Multiple consistent evidence points support the conclusion. Full code, runtime, and transaction evidence are intentionally withheld.

## 15. Expected Severity

Severity is `Not Applicable`.

No finding is expected, so violation severity must not be assigned.

## 16. Expected Evidence Interpretation

Application orchestration, use of contracts, transaction boundary intent, and delegation to Domain must be interpreted as legitimate unless evidence shows Application owning business rules.

Service naming, interface naming, and layer labels are not sufficient by themselves.

## 17. Expected Boundary Behavior

### Layered x Clean Architecture

The expected result belongs to `LAYER-005`. Clean use case conclusions are forbidden unless Clean-specific boundary evidence is independently evaluated.

### Layered x Hexagonal Architecture

`OrderStore` may resemble an outbound port, but the primary conclusion is Layered orchestration compliance. Absence of formal ports/adapters is not a Layered violation.

### Layered x Core

Core review behavior contributes evidence discipline and false-positive control. No generic Core finding is allowed.

### Layered x Fowler

Fowler Service Layer or Transaction Script findings require pattern-specific evidence and must not duplicate the Layered pass.

## 18. Expected Deduplication Behavior

Shared evidence is permitted.

The same conclusion must not appear as multiple findings.

Forbidden duplicate finding patterns include:

- `LAYER-006` finding that merely restates Domain owns the business decisions;
- `HEX-004` pass or fail that replaces the Layered coordination conclusion;
- Clean use case finding based only on the existence of `SubmitOrderService`;
- Fowler Service Layer conclusion without pattern-specific evidence.

## 19. Expected False Positive Protection

The expected result must avoid findings based only on:

- Application service naming;
- orchestration logic;
- coordinating load, decide, save steps;
- dependency on a contract;
- transaction boundary mention;
- monolithic deployment;
- lack of formal Clean or Hexagonal adoption.

Only evidence that Application owns business decisions could support a corrective finding, and none is provided.

## 20. Expected False Negative Protection

The expected result must not pass if future material shows:

- eligibility rules inside `SubmitOrderService`;
- status transitions decided by Application;
- domain rules duplicated in Application;
- direct dependency on `SqlOrderStore`;
- persistence configuration inside Application;
- passive Domain with decisions elsewhere.

## 21. Allowed Result Variations

Allowed variations:

- equivalent no-finding wording;
- equivalent evidence ordering;
- equivalent technology-neutral explanation;
- `Confirmed` confidence with explicit justification;
- supporting Rule omission when boundaries remain preserved;
- result status `Acceptable Variation` only when `Pass`, no finding, and `LAYER-005` ownership remain.

## 22. Disallowed Result Variations

Disallowed variations:

- primary outcome other than `Pass`;
- applicability other than `Applicable`;
- any corrective finding;
- severity assigned as if a violation exists;
- finding based only on service naming;
- duplicate Clean, Hexagonal, Fowler, Core, or Layered finding;
- nonexistent Rule ID;
- Primary Rule changed away from `LAYER-005`;
- remediation requiring unrelated redesign, tooling, architecture style, or rewrite.

## 23. Comparison Method

Compare observed output against this expected result by checking scenario identity, Primary Rule identity, applicability, outcome, confidence, severity expectation, required finding absence, evidence interpretation, expected non-findings, false-positive guards, false-negative guards, boundary behavior, deduplication behavior, remediation absence or proportionality, and traceability.

Manual comparison is sufficient for this static textual scenario.

## 24. Acceptance Criteria

The observed result is accepted when:

- `LAYER-005` is the Primary Rule result;
- applicability is `Applicable`;
- outcome is `Pass`;
- confidence is `Likely` or accepted stronger confidence;
- severity is `Not Applicable`;
- no corrective finding is present;
- expected non-findings are absent;
- boundary ownership is preserved;
- duplicate findings are absent;
- remediation is absent or non-corrective;
- result status is `Match` or an allowed variation explicitly classified as acceptable.

## 25. Failure Criteria

The observed result fails when:

- any corrective finding appears;
- the result is `Fail`, `Warning`, `Not Applicable`, or unsupported `Not Enough Evidence`;
- confidence contradicts evidence strength;
- expected non-findings appear;
- Primary Rule is nonexistent or reassigned away from `LAYER-005`;
- remediation is prescriptive beyond the evidence;
- boundary behavior contradicts the scenario.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only when it stays within allowed variations and preserves the required architectural conclusion.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/layered/EVAL-LAYER-002.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/LAYER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/layered/LAYER-005.md` |
| Supporting Rule | `skill/rules/layered/LAYER-002.md` |
| Supporting Rule | `skill/rules/layered/LAYER-006.md` |
| Supporting Rule | `skill/rules/HEX-004.md` |
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

Initial expected result for `EVAL-LAYER-002`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `LAYER-005`, selected Supporting Rules, and expected `Pass` result.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
