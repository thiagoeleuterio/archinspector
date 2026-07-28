# Expected Result - EVAL-CLEAN-002

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-CLEAN-002-EXPECTED` |
| Scenario ID | `EVAL-CLEAN-002` |
| Scenario Title | `Interface adapter maps external models into use-case models` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-CLEAN-002` |
| Title | `Interface adapter maps external models into use-case models` |
| Category | `Clean Architecture` |
| Scenario Type | `Positive Compliance` |
| Catalogs | `Clean Architecture` |
| Primary Rule | `CLEAN-006` |
| Supporting Rules | `CLEAN-001`, `CLEAN-004`, `CLEAN-011` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the textual static manifest in `evaluation/scenarios/clean/EVAL-CLEAN-002.md`.

The scope includes the interface adapter, external request and response models, use case input and output models, translation behavior before and after the use case boundary, use case invocation, and absence of external model leakage into the use case.

The scope excludes executable code, specific framework identity, persistence behavior, formal architecture adoption, DDD assessment, architecture-test assessment, CI/CD, cloud, microservices, and runtime verification.

## 4. Primary Rule Result

| Field             | Expected Value |
| ----------------- | -------------- |
| Rule ID           | `CLEAN-006` |
| Applicability     | `Applicable` |
| Outcome           | `Pass` |
| Confidence        | `Confirmed` |
| Severity          | `Not Applicable` |
| Finding Required  | `No` |
| Finding Count     | `0` |
| Evidence Strength | `Strong` |
| Result Status     | `Match` |

## 5. Supporting Rule Results

| Rule ID | Applicability | Expected Outcome | Expected Confidence | Expected Severity Range | Expected Finding | Expected Evidence | Forbidden Finding | Boundary Notes | Acceptance Criteria |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `CLEAN-001` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive finding evidence is reported | `No` | Use case accepts and returns framework-independent models. | A framework-type finding when no framework type crosses the use case boundary. | Preserve framework-type boundary without duplicating translation pass. | No corrective finding unless framework-specific types cross the use case boundary. |
| `CLEAN-004` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive finding evidence is reported | `No` | Use case is not shaped by the external request or response model. | A broad use-case isolation finding based only on adapter-local mapping. | Preserve use case isolation boundary. | No corrective finding unless delivery or infrastructure concerns shape use case behavior. |
| `CLEAN-011` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive finding evidence is reported | `No` | Boundary models are framework-independent. | A boundary-data finding based only on similar field names. | Preserve boundary data independence without requiring naming style. | No corrective finding unless boundary data carries framework, driver, or adapter details. |

Supporting Rules may be mentioned as related rules, boundary references, expected non-findings, or forbidden duplicate findings. They do not require findings for this scenario.

## 6. Expected Finding

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: CLEAN-006
Outcome: Pass
Confidence: Confirmed
Severity: Not Applicable
Applicability: Applicable
Evidence: OrderRequestAdapter maps ExternalOrderRequest into SubmitOrderInput, invokes SubmitOrderUseCase, and maps SubmitOrderOutput into ExternalOrderResponse; the use case depends only on framework-independent boundary models.
Architectural Impact: No corrective impact is present because adapter translation protects the use case boundary.
Rationale: CLEAN-006 pass conditions are satisfied by direct evidence that external models are translated before and after the use case boundary.
Remediation: None.
Related Rules: CLEAN-001, CLEAN-004, CLEAN-011
Boundary Notes: The result concludes only that adapter translation protects the reviewed use case boundary. It must not become a universal requirement for a specific DTO naming style.
```

## 7. Expected Finding Evidence

Required no-finding evidence:

- interface adapter scope is identified;
- external request and response models are identified;
- use case input and output boundary models are identified;
- external request is translated before use case invocation;
- use case output is translated after the use case returns;
- use case does not depend on external models;
- boundary models carry no framework or adapter details.

This evidence is structural and behavioral. It is not naming-only evidence.

## 8. Expected Architectural Impact

The expected impact is absence of corrective architectural impact.

The reviewed adapter translation keeps the use case boundary stable and independent from external transport, framework, and adapter model changes.

## 9. Expected Rationale

`CLEAN-006` applies because the reviewed material identifies an interface adapter, external models, use case boundary models, and data crossing the boundary.

The expected outcome is `Pass` because direct evidence shows translation before and after the use case boundary. The expected confidence is `Confirmed` because the manifest includes explicit mapping behavior and absence of external model leakage.

## 10. Expected Remediation

No corrective remediation is expected.

Observed output must not recommend microservices, DDD adoption, event sourcing, CQRS, a specific framework, cloud, containers, architecture tests, folder renaming, or a total rewrite.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- mapping code in an adapter;
- external request or response models outside use cases;
- adapter dependency on the use case boundary;
- use-case-owned input and output models;
- similar fields between external and boundary models;
- absence of DDD;
- absence of Bounded Context;
- absence of Aggregate;
- absence of Value Object;
- absence of Domain Event;
- absence of messaging;
- absence of microservices;
- absence of architecture tests;
- absence of formal Clean Architecture;
- absence of formal Hexagonal Architecture;
- absence of named layers;
- monolithic deployment.

## 12. Expected Applicability

Applicability is `Applicable`.

The manifest provides enough evidence to identify interface adapter scope, external models, use case boundary scope, and translation behavior.

## 13. Expected Outcome

Outcome is `Pass`.

The observed result must pass the Primary Rule because direct evidence shows external models are translated before crossing the use case boundary.

## 14. Expected Confidence

Confidence is `Confirmed`.

The conclusion is supported by direct structural and behavioral evidence. Naming alone is not used to establish confidence.

## 15. Expected Severity

Severity is `Not Applicable`.

No finding is expected, so violation severity must not be assigned.

## 16. Expected Evidence Interpretation

Adapter mapping must be interpreted as compliant boundary protection when the use case sees only use-case-owned input and output models.

Similar field names between external and boundary models may support semantic continuity but must not be treated as evidence of adapter leakage.

Withheld executable code and framework details must not cause failure because the textual manifest provides sufficient structural evidence for the selected Primary Rule.

## 17. Expected Boundary Behavior

### Clean x Core

The expected no-finding result belongs to `CLEAN-006`. Core review behavior validates evidence discipline and proportional no-finding behavior, but no broad Core approval should exceed the reviewed scope.

### Clean x Hexagonal Architecture

Hexagonal Architecture may use the same adapter and boundary evidence to reason about ports and adapters. It must not report a violation merely because external models exist outside the use case.

### Clean x Layered Architecture

Layered Architecture is outside the scenario boundary unless future observed material establishes a declared layered structure and exclusive layered evidence.

## 18. Expected Deduplication Behavior

Shared evidence is permitted.

The same conclusion must not appear as multiple findings.

Forbidden duplicate finding patterns include:

- `CLEAN-001` finding when no framework type crosses the use case boundary;
- `CLEAN-004` finding that treats correct adapter mapping as delivery concern leakage;
- `CLEAN-011` finding based only on similar field names;
- Hexagonal finding based only on external model existence in an adapter;
- Core or Layered finding based only on monolithic structure or naming.

## 19. Expected False Positive Protection

The expected result must avoid findings based only on:

- external models existing in adapters;
- mapping code near a framework boundary;
- adapter dependency on use case input or output models;
- similar fields between external and boundary models;
- request, response, command, input, or output names;
- monolithic shape;
- absence of formal architecture names.

## 20. Expected False Negative Protection

The expected result must not pass merely because:

- names suggest input and output translation;
- an adapter package exists;
- documentation claims mapping;
- a use case name is present;
- no external model dependency is shown in a high-level summary.

If external models cross the use case boundary, the pass must not be preserved.

## 21. Allowed Result Variations

Allowed variations:

- equivalent no-finding wording;
- equivalent evidence ordering;
- equivalent technology-neutral explanation of translation;
- omission of supporting Rule results when they would be decorative;
- `Likely` confidence only with explicit explanation of incomplete direct evidence while preserving no finding;
- result status `Acceptable Variation` only when it preserves Primary Rule, `Pass`, no finding, and boundary ownership.

## 22. Disallowed Result Variations

Disallowed variations:

- primary outcome other than `Pass`;
- applicability other than `Applicable`;
- any corrective finding;
- severity assigned as if a violation exists;
- finding based only on naming;
- duplicate finding;
- nonexistent Rule ID;
- Primary Rule changed away from `CLEAN-006`;
- DDD, formal Hexagonal Architecture, microservice, CI/CD, cloud, or architecture-test finding without exclusive evidence;
- remediation requiring unrelated redesign, tooling, platform, or total rewrite.

## 23. Comparison Method

Compare observed output against this expected result by checking:

- scenario identity;
- Primary Rule identity;
- applicability;
- outcome;
- confidence;
- severity expectation;
- required finding absence;
- evidence interpretation;
- expected non-findings;
- false-positive guards;
- false-negative guards;
- boundary behavior;
- deduplication behavior;
- remediation absence or proportionality;
- traceability.

Manual comparison is sufficient for this static textual scenario.

## 24. Acceptance Criteria

The observed result is accepted when:

- `CLEAN-006` is the Primary Rule result;
- applicability is `Applicable`;
- outcome is `Pass`;
- confidence is `Confirmed` or accepted contextual `Likely`;
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
- expected non-findings appear as confirmed findings;
- Primary Rule is nonexistent or reassigned away from `CLEAN-006`;
- remediation is prescriptive beyond the evidence;
- boundary behavior contradicts the scenario.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only when it stays within the allowed variations and preserves the required architectural conclusion.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/clean/EVAL-CLEAN-002.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/CA_CATALOG.md` |
| Primary Rule normative file | `skill/rules/clean/CLEAN-006.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-001.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-004.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-011.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Layered boundary review | `skill/reviews/LAYER_CATALOG_REVIEW.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Gold Standard stabilization | `evaluation/stabilizations/EVAL-CORE-001-STABILIZATION.md` |

## 28. Gold Standard Result Requirements

This expected result follows the gold standard reference for:

- structure;
- identity;
- evidence interpretation;
- applicability;
- outcome;
- confidence;
- severity;
- required finding;
- atomicity;
- remediation;
- expected non-findings;
- false-positive protection;
- false-negative protection;
- boundary behavior;
- deduplication;
- allowed variations;
- disallowed variations;
- comparison method;
- traceability.

It does not redefine Rule meaning or catalog ownership.

## 29. Result Change Notes

Initial expected result for `EVAL-CLEAN-002`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `CLEAN-006`, and expected `Pass` result.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
