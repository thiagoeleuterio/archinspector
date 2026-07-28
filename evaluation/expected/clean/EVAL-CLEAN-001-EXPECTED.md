# Expected Result - EVAL-CLEAN-001

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-CLEAN-001-EXPECTED` |
| Scenario ID | `EVAL-CLEAN-001` |
| Scenario Title | `Use case exposes framework request and response types` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-CLEAN-001` |
| Title | `Use case exposes framework request and response types` |
| Category | `Clean Architecture` |
| Scenario Type | `Confirmed Violation` |
| Catalogs | `Clean Architecture`; boundary references to `Hexagonal Architecture` and `Core` |
| Primary Rule | `CLEAN-001` |
| Supporting Rules | `CLEAN-004`, `CLEAN-011`, `HEX-008` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the textual static manifest in `evaluation/scenarios/clean/EVAL-CLEAN-001.md`.

The scope includes the use case boundary, framework request type, framework response type, framework metadata read inside use case behavior, adapter delegation, and absence of framework-independent boundary translation.

The scope excludes executable code, specific framework identity, persistence behavior, formal architecture adoption, DDD assessment, architecture-test assessment, CI/CD, cloud, microservices, and runtime verification.

## 4. Primary Rule Result

| Field             | Expected Value |
| ----------------- | -------------- |
| Rule ID           | `CLEAN-001` |
| Applicability     | `Applicable` |
| Outcome           | `Fail` |
| Confidence        | `Confirmed` |
| Severity          | `High` |
| Finding Required  | `Yes` |
| Finding Count     | `1` |
| Evidence Strength | `Strong` |
| Result Status     | `Match` |

## 5. Supporting Rule Results

| Rule ID | Applicability | Expected Outcome | Expected Confidence | Expected Severity Range | Expected Finding | Expected Evidence | Forbidden Finding | Boundary Notes | Acceptance Criteria |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `CLEAN-004` | `Applicable` or `Undetermined` | `Fail`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | None unless exclusive use-case isolation evidence is reported | `No` | Framework type leakage may support boundary context. | A broad use-case isolation finding that merely restates `CLEAN-001`. | Preserve broader use-case isolation boundary without duplicating framework-type leakage. | No separate finding unless distinct delivery or infrastructure shaping evidence exists. |
| `CLEAN-011` | `Applicable` or `Undetermined` | `Fail`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | None unless exclusive boundary data evidence is reported | `No` | Framework request and response types may be referenced as boundary data context. | A boundary-data finding that merely restates the same framework request and response leakage. | Preserve boundary-data responsibility without duplicate conclusion. | No separate finding unless separate data-structure detail leakage is established. |
| `HEX-008` | `Applicable` or `Undetermined` | `Fail`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | None unless exclusive Hexagonal framework-core evidence is reported | `No` | Framework metadata inside the use case may be context only. | A Hexagonal framework finding that merely repeats the Clean use case boundary finding. | Preserve Hexagonal core-framework boundary without reassignment. | No separate finding unless an exclusive core framework-concern conclusion is shown. |

Supporting Rules may be mentioned as related rules, boundary references, expected non-findings, or forbidden duplicate findings. They do not require findings for this scenario.

## 6. Expected Finding

```text
Finding ID: EVAL-CLEAN-001-F001
Rule ID: CLEAN-001
Title: Use case boundary exposes framework request and response types
Outcome: Fail
Confidence: Confirmed
Severity: High
Applicability: Applicable
Evidence: SubmitOrderUseCase accepts FrameworkOrderRequest, reads framework metadata, and returns FrameworkOrderResponse without framework-independent boundary data.
Architectural Impact: The use case contract is coupled to delivery framework types, so framework changes can alter application business rule boundaries.
Rationale: Direct signature and behavior evidence satisfies the fail condition for CLEAN-001.
Remediation: Translate framework request and response types in the adapter, introduce framework-independent use case input and output models, and keep framework lifecycle data outside the use case boundary.
Related Rules: CLEAN-004, CLEAN-011, HEX-008
Boundary Notes: The finding concludes only that framework-specific types cross the use case boundary. It must not duplicate broader use case isolation or Hexagonal core framework findings without exclusive evidence.
```

## 7. Expected Finding Evidence

Required evidence:

- use case scope is identified;
- framework request type crosses into the use case boundary;
- framework response type crosses out of the use case boundary;
- framework metadata is read inside use case behavior;
- adapter delegates without translating to use-case-owned boundary data;
- no framework-independent input or output model exists between adapter and use case.

This evidence is structural and behavioral. It is not naming-only evidence.

## 8. Expected Architectural Impact

The expected impact is high because the framework types affect a central order submission use case boundary.

The application business rule contract becomes coupled to delivery mechanism details, making framework changes likely to affect use case signatures and behavior.

## 9. Expected Rationale

`CLEAN-001` applies because the reviewed material identifies a use case boundary and framework-specific request and response types.

The expected outcome is `Fail` because direct evidence shows framework-specific types crossing the use case boundary. The expected confidence is `Confirmed` because signatures, behavior, and missing translation are explicit.

## 10. Expected Remediation

Expected remediation must:

- translate framework request data inside the adapter;
- translate use case output into framework response data outside the use case;
- introduce framework-independent input and output models;
- remove framework lifecycle data from application business rule boundaries;
- keep the fix scoped to the violated boundary.

Expected remediation must not require microservices, DDD adoption, event sourcing, CQRS, a specific framework, cloud, containers, folder renaming, a full architecture migration, or a total rewrite.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- use of a framework at the system edge;
- existence of an inbound adapter;
- absence of formal Clean Architecture;
- absence of formal Hexagonal Architecture;
- absence of named layers;
- absence of DDD;
- absence of Bounded Context;
- absence of Aggregate;
- absence of Value Object;
- absence of Domain Event;
- absence of messaging;
- absence of microservices;
- absence of architecture tests;
- database product choice;
- monolithic deployment;
- global framework-free architecture.

## 12. Expected Applicability

Applicability is `Applicable`.

The manifest provides enough evidence to identify the use case boundary, the framework-specific types, and their crossing relationship.

## 13. Expected Outcome

Outcome is `Fail`.

The observed result must fail the Primary Rule because direct evidence shows framework request and response types in the use case boundary.

## 14. Expected Confidence

Confidence is `Confirmed`.

The conclusion is supported by direct structural and behavioral evidence. Naming alone is not used to establish confidence.

## 15. Expected Severity

Severity is `High`.

The issue affects a central order submission use case and couples application business rule contracts to delivery framework details.

`Medium` is allowed only as a contextual variation when the observed result explicitly justifies reduced blast radius while preserving `Applicable`, `Fail`, `Confirmed`, and the required finding.

## 16. Expected Evidence Interpretation

The framework request signature, framework response return type, framework metadata usage, and absence of translation must be interpreted together as strong evidence of use case boundary leakage.

Adapter and directory names may support scope identification but must not be treated as sufficient proof by themselves.

Withheld executable code and framework identity must not reduce confidence because the manifest defines the relevant framework-specific type relationship directly.

## 17. Expected Boundary Behavior

### Clean x Core

The expected finding belongs to `CLEAN-001`. Core review behavior contributes evidence discipline and no-duplication expectations, but no generic Core finding is allowed for the same conclusion.

### Clean x Hexagonal Architecture

Hexagonal Architecture may provide context for framework concerns in core behavior. It must not duplicate the `CLEAN-001` finding unless the observed result identifies a Hexagonal-specific conclusion with distinct evidence and reasoning.

### Clean x Layered Architecture

Layered Architecture must not report layer bypass, dependency direction, or responsibility findings without an established layered structure and exclusive layered evidence.

## 18. Expected Deduplication Behavior

Shared evidence is permitted.

The same conclusion must not appear as multiple findings.

Forbidden duplicate finding patterns include:

- `CLEAN-004` finding that merely restates framework-specific types crossing use case boundaries;
- `CLEAN-011` finding that merely restates the same framework request and response leakage;
- `HEX-008` finding that merely repeats the Clean use case boundary conclusion;
- generic Core or Layered finding based on the same evidence;
- evidence request duplicated as multiple corrective findings.

## 19. Expected False Positive Protection

The expected result must avoid findings based only on:

- framework usage outside the use case;
- framework annotation or import localized to an adapter;
- endpoint, controller, or handler naming;
- external request conversion when translation exists;
- monolithic shape;
- absence of formal architecture names.

Only framework types crossing the use case boundary support the required failure.

## 20. Expected False Negative Protection

The expected result must not miss the failure because:

- the adapter is named correctly;
- the framework request is called a command;
- the framework response is called a result;
- the use case and adapter run in one process;
- only one endpoint is present;
- no formal Clean Architecture adoption is claimed.

## 21. Allowed Result Variations

Allowed variations:

- equivalent finding title specific to use case boundary framework types;
- equivalent evidence ordering;
- equivalent technology-neutral remediation phrasing;
- `Medium` severity with explicit reduced-impact justification;
- supporting Rule list variation using existing semantically direct Rules within the maximum of three;
- omission of supporting Rule findings when they would duplicate the Primary Rule.

## 22. Disallowed Result Variations

Disallowed variations:

- primary outcome other than `Fail`;
- applicability other than `Applicable`;
- confidence below `Confirmed`;
- missing required finding;
- more than one finding for the same conclusion;
- generic finding title;
- finding based only on naming;
- nonexistent Rule ID;
- Primary Rule changed away from `CLEAN-001`;
- Clean, Hexagonal, Layered, Core, DDD, repository, framework-choice, testability, microservice, CI/CD, or cloud finding without exclusive evidence;
- remediation requiring unrelated redesign, tooling, platform, or total rewrite.

## 23. Comparison Method

Compare observed output against this expected result by checking:

- scenario identity;
- Primary Rule identity;
- applicability;
- outcome;
- confidence;
- severity;
- required finding presence;
- finding atomicity;
- evidence interpretation;
- expected non-findings;
- false-positive guards;
- false-negative guards;
- boundary behavior;
- deduplication behavior;
- remediation proportionality;
- traceability.

Manual comparison is sufficient for this static textual scenario.

## 24. Acceptance Criteria

The observed result is accepted when:

- `CLEAN-001` is the Primary Rule result;
- applicability is `Applicable`;
- outcome is `Fail`;
- confidence is `Confirmed`;
- severity is `High` or accepted contextual `Medium`;
- exactly one required finding is present;
- expected non-findings are absent;
- boundary ownership is preserved;
- duplicate findings are absent;
- remediation is proportional and technology-neutral;
- result status is `Match` or an allowed variation explicitly classified as acceptable.

## 25. Failure Criteria

The observed result fails when:

- the required finding is absent;
- the violation is reported only as `Warning`;
- the result is `Pass`, `Not Applicable`, or `Not Enough Evidence`;
- confidence is lower than `Confirmed`;
- the finding is generic, merged, duplicated, or unsupported;
- the Primary Rule is nonexistent or reassigned away from `CLEAN-001`;
- expected non-findings appear as confirmed findings;
- remediation is prescriptive beyond the evidence;
- boundary behavior contradicts the scenario.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only when it stays within the allowed variations and preserves the required architectural conclusion.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/clean/EVAL-CLEAN-001.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/CA_CATALOG.md` |
| Primary Rule normative file | `skill/rules/clean/CLEAN-001.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-004.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-011.md` |
| Supporting Rule | `skill/rules/HEX-008.md` |
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

Initial expected result for `EVAL-CLEAN-001`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `CLEAN-001`, and expected `Fail` result.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
