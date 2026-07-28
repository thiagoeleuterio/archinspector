# Expected Result - EVAL-HEX-003

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-HEX-003-EXPECTED` |
| Scenario ID | `EVAL-HEX-003` |
| Scenario Title | `Framework annotations present only in an inbound adapter` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-HEX-003` |
| Title | `Framework annotations present only in an inbound adapter` |
| Category | `Hexagonal Architecture` |
| Scenario Type | `False Positive Guard` |
| Catalogs | `Hexagonal Architecture`; boundary references to `Clean Architecture` and `Core` |
| Primary Rule | `HEX-008` |
| Supporting Rules | `HEX-002`, `HEX-003`, `CLEAN-006` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the textual static manifest in `evaluation/scenarios/hexagonal/EVAL-HEX-003.md`.

The scope includes inbound adapter framework annotations, external request and response models, conversion to application input, invocation of inbound port or use case, conversion of result to external response, framework-neutral core models, and absence of framework concerns in core behavior.

The scope excludes executable code, specific framework identity, database-product behavior, formal Clean Architecture adoption, DDD assessment, architecture-test assessment, CI/CD, cloud, microservices, and runtime verification.

## 4. Primary Rule Result

| Field             | Expected Value |
| ----------------- | -------------- |
| Rule ID           | `HEX-008` |
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
| `HEX-002` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive finding evidence is reported | `No` | Adapter invokes `SubmitOrderPort`. | A corrective inbound-port finding based only on framework annotation in adapter. | Preserve inbound boundary without duplicate result. | No corrective finding unless inbound boundary is bypassed. |
| `HEX-003` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive finding evidence is reported | `No` | Adapter translates and delegates without core business behavior. | A behavior-placement finding based only on adapter-local framework metadata. | Preserve inbound adapter responsibility boundary. | No corrective finding unless adapter owns core business behavior. |
| `CLEAN-006` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive Clean finding evidence is reported | `No` | External request is converted before the use case boundary and result after it. | A Clean translation finding that treats correct mapping as violation. | Preserve Clean adapter-translation boundary without duplicating Hexagonal result. | No corrective finding unless external models cross the use case boundary. |

Supporting Rules may be mentioned as related rules, boundary references, expected non-findings, or forbidden duplicate findings. They do not require findings for this scenario.

## 6. Expected Finding

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: HEX-008
Outcome: Pass
Confidence: Confirmed
Severity: Not Applicable
Applicability: Applicable
Evidence: Framework annotations and external request/response models are present only in OrderEndpointAdapter; the adapter maps to SubmitOrderInput, invokes SubmitOrderPort, maps SubmitOrderResult back to an external response, and no framework type or annotation appears in the core.
Architectural Impact: No corrective impact is present because framework concerns remain outside application core behavior.
Rationale: HEX-008 pass conditions are satisfied by direct evidence that framework concerns are isolated in the inbound adapter.
Remediation: None.
Related Rules: HEX-002, HEX-003, CLEAN-006
Boundary Notes: The result concludes only that adapter-local framework annotations are not core leakage. It must not require the whole system to be framework-free.
```

## 7. Expected Finding Evidence

Required no-finding evidence:

- inbound adapter scope is identified;
- framework annotations or metadata appear only in the adapter;
- external request is converted to application input before the port;
- inbound port or use case is invoked;
- application result is converted to external response after the port;
- no framework annotation appears in the core;
- no framework type crosses the port;
- no external request or response type is used by the use case;
- core does not depend on the adapter.

This evidence is structural and behavioral. It is not naming-only evidence.

## 8. Expected Architectural Impact

The expected impact is absence of corrective architectural impact.

Framework usage remains at the edge, and application core behavior is independent from framework APIs, annotations, lifecycle, request types, and response types.

## 9. Expected Rationale

`HEX-008` applies because the reviewed material includes application core behavior and framework concerns that may interact with it.

The expected outcome is `Pass` because direct evidence shows framework concerns remain outside the core. The expected confidence is `Confirmed` because the manifest explicitly identifies adapter-local metadata, translation, port invocation, framework-neutral core models, and absence of framework concerns in core behavior.

## 10. Expected Remediation

No corrective remediation is expected.

Observed output must not recommend removing all framework usage from the system, adopting a specific framework, adopting DDD, adopting Clean Architecture formally, creating microservices, adding CI/CD, adding cloud, or rewriting the system.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- annotations in the adapter;
- framework usage at the edge;
- request conversion;
- response conversion;
- external composition;
- existence of controller, handler, endpoint, or inbound adapter;
- absence of framework-free infrastructure;
- absence of microservices;
- absence of DDD;
- absence of formal Clean Architecture;
- adapter depending on application boundary;
- adapter knowing external protocol;
- framework import localized to adapter.

## 12. Expected Applicability

Applicability is `Applicable`.

The manifest provides enough evidence to identify application core behavior, framework concerns, and whether those concerns appear inside or outside the core.

## 13. Expected Outcome

Outcome is `Pass`.

The observed result must pass the Primary Rule because direct evidence shows framework concerns remain outside the application core.

## 14. Expected Confidence

Confidence is `Confirmed`.

The conclusion is supported by direct structural and behavioral evidence. Naming alone is not used to establish confidence.

## 15. Expected Severity

Severity is `Not Applicable`.

No finding is expected, so violation severity must not be assigned.

## 16. Expected Evidence Interpretation

Framework annotations in an inbound adapter must be interpreted as legitimate outside-boundary framework usage when the adapter translates external models and core behavior remains framework-neutral.

Directory and component names may support scope identification but must not be treated as sufficient proof by themselves.

Withheld concrete framework identity must not cause failure because the scenario defines framework concerns generically and locates them structurally outside the core.

## 17. Expected Boundary Behavior

### Hexagonal x Core

The expected no-finding result belongs to `HEX-008`. Core review behavior validates evidence discipline and proportional no-finding behavior, but no broad Core approval should exceed the reviewed scope.

### Hexagonal x Clean

Clean Architecture may evaluate framework-specific types crossing use case boundaries or adapter translation. The scenario shows no framework type crossing into use cases and correct translation. Clean findings are forbidden when they merely report adapter-local framework annotations.

### Hexagonal x Layered

Layered Architecture is outside the scenario boundary unless future observed material establishes a layered structure and exclusive layered evidence.

## 18. Expected Deduplication Behavior

Shared evidence is permitted.

The same conclusion must not appear as multiple findings.

Forbidden duplicate finding patterns include:

- `HEX-002` finding based only on adapter-local framework annotations;
- `HEX-003` finding based only on adapter-local annotations rather than business behavior in adapter;
- `CLEAN-006` finding that treats correct request/response conversion as violation;
- Clean framework-type finding when no framework type crosses a use case boundary;
- Core finding that broadly approves or fails framework use beyond the reviewed boundary.

## 19. Expected False Positive Protection

The expected result must avoid findings based only on:

- framework import located in adapter;
- annotation located in adapter;
- external type converted before the port;
- adapter knowing external protocol;
- adapter dependency toward application boundary;
- external configuration located outside the core.

## 20. Expected False Negative Protection

The expected result must not approve when:

- raw external request type crosses the port;
- external response type is returned by the use case;
- annotation appears in the core;
- use case depends on framework;
- application interface belongs to framework;
- adapter contains business rules;
- core instantiates the inbound adapter.

## 21. Allowed Result Variations

Allowed variations:

- equivalent no-finding wording;
- equivalent evidence ordering;
- equivalent technology-neutral explanation of framework isolation;
- omission of supporting Rule results when they would be decorative;
- result status `Acceptable Variation` only when it preserves Primary Rule, `Pass`, no finding, and boundary ownership.

## 22. Disallowed Result Variations

Disallowed variations:

- primary outcome other than `Pass`;
- applicability other than `Applicable`;
- any corrective finding;
- severity assigned as if a violation exists;
- finding based only on adapter-local annotation;
- duplicate finding;
- nonexistent Rule ID;
- Primary Rule changed away from `HEX-008`;
- requirement for framework-free entire system, DDD, formal Clean Architecture, microservices, CI/CD, cloud, or architecture tests;
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

- `HEX-008` is the Primary Rule result;
- applicability is `Applicable`;
- outcome is `Pass`;
- confidence is `Confirmed`;
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
- Primary Rule is nonexistent or reassigned away from `HEX-008`;
- remediation is prescriptive beyond the evidence;
- boundary behavior contradicts the scenario.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only when it stays within the allowed variations and preserves the required architectural conclusion.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/hexagonal/EVAL-HEX-003.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/HEX_CATALOG.md` |
| Primary Rule normative file | `skill/rules/HEX-008.md` |
| Supporting Rule | `skill/rules/HEX-002.md` |
| Supporting Rule | `skill/rules/HEX-003.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-006.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
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

Initial expected result for `EVAL-HEX-003`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity, selected Primary Rule `HEX-008`, and expected `Pass` result.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
