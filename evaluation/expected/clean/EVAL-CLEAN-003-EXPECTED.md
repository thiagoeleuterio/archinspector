# Expected Result - EVAL-CLEAN-003

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-CLEAN-003-EXPECTED` |
| Scenario ID | `EVAL-CLEAN-003` |
| Scenario Title | `Infrastructure implementation references domain contracts` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-CLEAN-003` |
| Title | `Infrastructure implementation references domain contracts` |
| Category | `Clean Architecture` |
| Scenario Type | `False Positive Guard` |
| Catalogs | `Clean Architecture`; boundary references to `Hexagonal Architecture` and `DDD` |
| Primary Rule | `CLEAN-009` |
| Supporting Rules | `CLEAN-002`, `CLEAN-012`, `HEX-005` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the textual static manifest in `evaluation/scenarios/clean/EVAL-CLEAN-003.md`.

The scope includes the use case, gateway contract, infrastructure implementation, external client, external configuration, dependency direction from infrastructure toward the contract, external composition, and absence of use case dependency on concrete external mechanisms.

The scope excludes executable code, specific framework identity, external service product behavior, formal architecture adoption, complete DDD assessment, architecture-test assessment, CI/CD, cloud, microservices, and runtime verification.

## 4. Primary Rule Result

| Field             | Expected Value |
| ----------------- | -------------- |
| Rule ID           | `CLEAN-009` |
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
| `CLEAN-002` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive dependency finding evidence is reported | `No` | Infrastructure depends toward the policy contract; use case does not depend on implementation. | A dependency-direction finding that treats correct inward dependency as violation. | Preserve source dependency boundary without duplicating gateway pass. | No corrective finding unless policy code depends on technical details. |
| `CLEAN-012` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive flow-control finding evidence is reported | `No` | Runtime composition supplies implementation through the abstraction. | A flow-control finding that merely restates correct gateway implementation. | Preserve runtime flow boundary. | No corrective finding unless flow crosses through concrete details. |
| `HEX-005` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive Hexagonal finding evidence is reported | `No` | Infrastructure implementation satisfies the policy contract outside use case behavior. | A Hexagonal finding that treats adapter implementation of a contract as violation. | Preserve Hexagonal outbound-adapter boundary. | No corrective finding unless adapter fails to satisfy the boundary or core depends on adapter. |

Supporting Rules may be mentioned as related rules, boundary references, expected non-findings, or forbidden duplicate findings. They do not require findings for this scenario.

## 6. Expected Finding

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: CLEAN-009
Outcome: Pass
Confidence: Confirmed
Severity: Not Applicable
Applicability: Applicable
Evidence: PriceOrderUseCase depends on PricingGateway; ExternalPricingGateway implements that contract outside the use case and contains ExternalPricingClient and ExternalPricingSettings; composition occurs outside the use case.
Architectural Impact: No corrective impact is present because the gateway boundary isolates the use case from the external pricing system.
Rationale: CLEAN-009 pass conditions are satisfied by direct evidence that the use case expresses external needs through a boundary abstraction.
Remediation: None.
Related Rules: CLEAN-002, CLEAN-012, HEX-005
Boundary Notes: The result concludes only that infrastructure implementing a use-case boundary contract is legitimate. It must not become a DDD repository-pattern finding or duplicate Hexagonal port analysis.
```

## 7. Expected Finding Evidence

Required no-finding evidence:

- use case scope is identified;
- gateway abstraction is identified;
- external system interaction is identified;
- use case depends only on the gateway abstraction;
- infrastructure implements or satisfies the gateway contract;
- external client and settings remain outside use case behavior;
- composition happens outside the use case;
- no external implementation or protocol model crosses into the use case.

This evidence is structural and behavioral. It is not naming-only evidence.

## 8. Expected Architectural Impact

The expected impact is absence of corrective architectural impact.

The reviewed structure preserves use case isolation by allowing the use case to express external needs through a boundary abstraction while technical details remain outside.

## 9. Expected Rationale

`CLEAN-009` applies because the reviewed material identifies a use case, a gateway boundary, an external system interaction, and a concrete implementation outside the use case.

The expected outcome is `Pass` because direct evidence shows the use case depends on the gateway abstraction, not the external client or implementation. The expected confidence is `Confirmed` because dependency direction, implementation relationship, and composition are explicit.

## 10. Expected Remediation

No corrective remediation is expected.

Observed output must not recommend microservices, DDD adoption, event sourcing, CQRS, a specific framework, cloud, containers, architecture tests, repository pattern adoption by name, folder renaming, or a total rewrite.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- infrastructure depending on a policy contract;
- external implementation existing outside the use case;
- composition outside the use case;
- use of a gateway or interface;
- absence of multiple adapters;
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
- repository pattern correctness;
- monolithic deployment.

## 12. Expected Applicability

Applicability is `Applicable`.

The manifest provides enough evidence to identify the use case boundary, the gateway abstraction, external system interaction, implementation relationship, and dependency direction.

## 13. Expected Outcome

Outcome is `Pass`.

The observed result must pass the Primary Rule because direct evidence shows the gateway isolates the use case from the external system.

## 14. Expected Confidence

Confidence is `Confirmed`.

The conclusion is supported by direct structural and behavioral evidence. Naming alone is not used to establish confidence.

## 15. Expected Severity

Severity is `Not Applicable`.

No finding is expected, so violation severity must not be assigned.

## 16. Expected Evidence Interpretation

Infrastructure referencing a policy-owned contract must be interpreted as legitimate inward dependency when the use case depends only on the abstraction and concrete external details remain outside.

The word `Gateway` may support scope identification but must not be treated as proof by itself.

Withheld executable code and external service details must not cause failure because the textual manifest provides sufficient structural evidence for the selected Primary Rule.

## 17. Expected Boundary Behavior

### Clean x Core

The expected no-finding result belongs to `CLEAN-009`. Core review behavior validates evidence discipline and proportional no-finding behavior, but no broad Core approval should exceed the reviewed scope.

### Clean x Hexagonal Architecture

Hexagonal Architecture may describe the infrastructure implementation as an outbound adapter satisfying a port. It must not report a violation merely because infrastructure depends on a policy contract.

### Clean x Layered Architecture

Layered Architecture is outside the scenario boundary unless future observed material establishes a declared layered structure and exclusive layered evidence.

## 18. Expected Deduplication Behavior

Shared evidence is permitted.

The same conclusion must not appear as multiple findings.

Forbidden duplicate finding patterns include:

- `CLEAN-002` finding that treats correct inward dependency as violation;
- `CLEAN-012` finding that merely restates correct runtime composition through an abstraction;
- `HEX-005` finding that duplicates the Clean gateway no-finding result;
- DDD repository finding based only on a gateway contract;
- Core or Layered finding based only on monolithic structure or naming.

## 19. Expected False Positive Protection

The expected result must avoid findings based only on:

- infrastructure referencing a domain or use-case contract;
- an adapter implementing a gateway;
- a single implementation;
- composition wiring outside the use case;
- existence of external client code;
- monolithic shape;
- absence of DDD tactical patterns;
- absence of formal architecture names.

## 20. Expected False Negative Protection

The expected result must not pass when:

- the use case depends on the concrete infrastructure implementation;
- the use case creates the external client;
- external settings are read inside use case behavior;
- the gateway contract is owned or shaped by the external client;
- external protocol models cross into use case input or output;
- the dependency direction points from policy to technical detail.

## 21. Allowed Result Variations

Allowed variations:

- equivalent no-finding wording;
- equivalent evidence ordering;
- equivalent technology-neutral explanation of legitimate implementation dependency;
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
- Primary Rule changed away from `CLEAN-009`;
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

- `CLEAN-009` is the Primary Rule result;
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
- Primary Rule is nonexistent or reassigned away from `CLEAN-009`;
- remediation is prescriptive beyond the evidence;
- boundary behavior contradicts the scenario.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only when it stays within the allowed variations and preserves the required architectural conclusion.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/clean/EVAL-CLEAN-003.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/CA_CATALOG.md` |
| Primary Rule normative file | `skill/rules/clean/CLEAN-009.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-002.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-012.md` |
| Supporting Rule | `skill/rules/HEX-005.md` |
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

Initial expected result for `EVAL-CLEAN-003`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `CLEAN-009`, and expected `Pass` result.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
