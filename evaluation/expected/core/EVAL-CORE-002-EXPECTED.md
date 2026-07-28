# Expected Result - EVAL-CORE-002

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-CORE-002-EXPECTED` |
| Scenario ID | `EVAL-CORE-002` |
| Scenario Title | `Cohesive domain module with legitimate dependencies` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-CORE-002` |
| Title | `Cohesive domain module with legitimate dependencies` |
| Category | `Core` |
| Scenario Type | `Positive Compliance` |
| Catalogs | `Core`; boundary references to `Layered Architecture` and `Domain-Driven Design` |
| Primary Rule | `LAYER-002` |
| Supporting Rules | `DDD-002`, `DDD-006`, `DDD-012` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the textual static manifest in `evaluation/scenarios/core/EVAL-CORE-002.md`.

The scope includes the order domain module, order entities, domain services, domain-facing contract, legitimate internal dependencies, external infrastructure implementation, external composition, and absence of direct domain dependency on infrastructure or configuration.

The scope excludes executable code, framework-specific behavior, database-product behavior, formal architecture adoption, complete tactical DDD assessment, architecture-test assessment, CI/CD, cloud, and runtime verification.

## 4. Primary Rule Result

| Field             | Expected Value |
| ----------------- | -------------- |
| Rule ID           | `LAYER-002` |
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
| `DDD-002` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive DDD finding evidence is reported | `No` | Order terminology may support cohesive domain interpretation. | A DDD language finding that merely restates internal domain collaboration. | Preserve domain-language boundary without requiring full DDD assessment. | No separate finding unless distinct terminology inconsistency exists. |
| `DDD-006` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive DDD finding evidence is reported | `No` | `Order` and `OrderLine` lifecycle evidence may support domain cohesion. | An entity lifecycle finding based only on entity presence or absence of aggregate formalism. | Preserve entity-lifecycle boundary without duplicating `LAYER-002`. | No separate finding unless distinct lifecycle inconsistency exists. |
| `DDD-012` | `Applicable` or `Undetermined` | `Pass`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | `Not Applicable` unless exclusive DDD finding evidence is reported | `No` | Acceptance and pricing checks may support invariant ownership. | An invariant finding that merely requires Value Objects, Aggregates, or Domain Events. | Preserve invariant boundary without tactical DDD prescription. | No separate finding unless a distinct invariant enforcement issue exists. |

Supporting Rules may be mentioned as related rules, boundary references, expected non-findings, or forbidden duplicate findings. They do not require findings for this scenario.

## 6. Expected Finding

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: LAYER-002
Outcome: Pass
Confidence: Confirmed
Severity: Not Applicable
Applicability: Applicable
Evidence: Domain responsibilities are explicit and consistent; dependencies between Order, OrderLine, PricingPolicy, OrderEligibility, and OrderRepository remain within cohesive order-domain responsibility; SqlOrderRepository and SqlConnectionSettings remain outside the domain; composition is external.
Architectural Impact: No corrective impact is present because the reviewed structure preserves clear responsibilities and legitimate dependencies.
Rationale: LAYER-002 pass conditions are satisfied by explicit responsibility separation and absence of contradictory responsibility ownership.
Remediation: None.
Related Rules: DDD-002, DDD-006, DDD-012
Boundary Notes: The result concludes only that responsibilities are explicit and consistent for the reviewed Core scenario. It must not become a DDD completeness finding or a Hexagonal/Clean formalism requirement.
```

## 7. Expected Finding Evidence

Required no-finding evidence:

- domain scope is identified as order domain behavior;
- internal domain dependencies are listed and cohesive;
- layer or module responsibilities are explicit;
- infrastructure implementation is outside the domain;
- external configuration is outside the domain;
- composition is external;
- the domain-facing contract is abstract and not storage-specific;
- dependency direction does not point from domain behavior to concrete infrastructure.

This evidence is structural and behavioral. It is not naming-only evidence.

## 8. Expected Architectural Impact

The expected impact is absence of corrective architectural impact.

The reviewed responsibilities are explicit and consistent, and the internal dependencies support cohesive domain behavior rather than contradictory layer ownership.

## 9. Expected Rationale

`LAYER-002` applies because the reviewed material identifies a defensible module or layer responsibility structure.

The expected outcome is `Pass` because direct evidence shows coherent responsibilities and no contradiction in the reviewed scope. The expected confidence is `Confirmed` because the manifest includes explicit responsibility, dependency, implementation, composition, and absence-of-infrastructure-reference evidence.

## 10. Expected Remediation

No corrective remediation is expected.

Observed output must not recommend microservices, DDD adoption, event sourcing, CQRS, a specific framework, a specific persistence technology, cloud, containers, a full architecture migration, architecture tests, or a total rewrite.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- legitimate internal domain dependencies;
- use of interfaces or abstract contracts;
- infrastructure implementation depending on domain-facing contracts;
- external composition;
- existence of an infrastructure module;
- absence of Bounded Context;
- absence of Aggregate;
- absence of Value Object;
- absence of Domain Event;
- absence of messaging;
- absence of microservices;
- absence of architecture tests;
- absence of formal Hexagonal Architecture;
- absence of formal Clean Architecture;
- absence of named layers beyond reviewed responsibilities;
- use of a monolith;
- repository pattern correctness;
- database product choice;
- runtime deployment shape.

## 12. Expected Applicability

Applicability is `Applicable`.

The manifest provides enough evidence to identify the reviewed responsibility structure and evaluate whether responsibilities are explicit, consistent, and non-contradictory.

## 13. Expected Outcome

Outcome is `Pass`.

The observed result must pass the Primary Rule because direct evidence shows legitimate dependencies and cohesive responsibility ownership.

## 14. Expected Confidence

Confidence is `Confirmed`.

The conclusion is supported by direct structural and behavioral evidence. Naming alone is not used to establish confidence.

## 15. Expected Severity

Severity is `Not Applicable`.

No finding is expected, so violation severity must not be assigned.

## 16. Expected Evidence Interpretation

Internal domain references, domain services, entities, and a domain-facing contract must be interpreted as legitimate when they remain inside cohesive order-domain responsibility and do not point to concrete infrastructure.

Directory and component names may support scope identification but must not be treated as sufficient proof by themselves.

Withheld executable code and framework details must not cause failure because the textual manifest provides sufficient structural evidence for the selected Primary Rule.

## 17. Expected Boundary Behavior

### Core x Layered Architecture

The scenario is a Core scenario, but the Primary Rule remains `LAYER-002` because `evaluation/SCENARIO_CATALOG.md` states that no `CORE-*` Rule prefix exists and assigns this scenario to `LAYER-002`.

The expected no-finding result belongs to `LAYER-002`. Neighboring Layered Rules may be referenced only to preserve boundaries or explain why additional findings are not required.

### Core x Domain-Driven Design

DDD rules may provide boundary context for domain language, entity lifecycle, and invariants. They must not duplicate the `LAYER-002` result or require tactical DDD patterns without exclusive evidence.

Absence of formal DDD adoption must not produce a finding.

## 18. Expected Deduplication Behavior

Shared evidence is permitted.

The same conclusion must not appear as multiple findings.

Forbidden duplicate finding patterns include:

- `DDD-002` finding that merely restates cohesive order terminology;
- `DDD-006` finding based only on entity naming or lack of aggregate formalism;
- `DDD-012` finding that merely requires tactical DDD artifacts;
- Hexagonal or Clean finding based only on lack of formal ports, adapters, or rings;
- Architecture Testing finding based only on absence of architecture tests.

## 19. Expected False Positive Protection

The expected result must avoid findings based only on:

- internal dependencies;
- interface usage;
- entity-service collaboration;
- infrastructure module existence;
- external implementation depending on domain contracts;
- external composition;
- monolithic structure;
- absence of microservices;
- absence of formal Hexagonal Architecture;
- absence of formal Clean Architecture;
- absence of tactical DDD completeness.

Only exclusive violation evidence could support a corrective finding, and none is provided.

## 20. Expected False Negative Protection

The expected result must not pass merely because:

- folders are named `domain`;
- interfaces exist;
- documentation claims separation;
- nominal abstractions appear;
- diagrams show boxes;
- no infrastructure dependency is named in a high-level summary.

The pass is valid only because the provided manifest gives structural evidence for responsibility consistency and dependency direction.

## 21. Allowed Result Variations

Allowed variations:

- equivalent no-finding wording;
- equivalent evidence ordering;
- equivalent technology-neutral explanation of legitimate dependencies;
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
- Primary Rule changed away from `LAYER-002`;
- DDD, formal Clean Architecture, formal Hexagonal Architecture, microservice, CI/CD, cloud, or architecture-test finding without exclusive evidence;
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

- `LAYER-002` is the Primary Rule result;
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
- Primary Rule is nonexistent or reassigned away from `LAYER-002`;
- remediation is prescriptive beyond the evidence;
- boundary behavior contradicts the scenario.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only when it stays within the allowed variations and preserves the required architectural conclusion.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/core/EVAL-CORE-002.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/LAYER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/layered/LAYER-002.md` |
| Supporting Rule | `skill/rules/ddd/DDD-002.md` |
| Supporting Rule | `skill/rules/ddd/DDD-006.md` |
| Supporting Rule | `skill/rules/ddd/DDD-012.md` |
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

Initial expected result for `EVAL-CORE-002`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity, selected Primary Rule `LAYER-002`, and expected `Pass` result.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
