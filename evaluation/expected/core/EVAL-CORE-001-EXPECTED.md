# Expected Result — EVAL-CORE-001

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-CORE-001-EXPECTED` |
| Scenario ID | `EVAL-CORE-001` |
| Scenario Title | `Domain logic coupled to external infrastructure` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `Yes` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-CORE-001` |
| Title | `Domain logic coupled to external infrastructure` |
| Category | `Core` |
| Scenario Type | `Confirmed Violation` |
| Catalogs | `Core`; boundary references to `Hexagonal Architecture` and `Clean Architecture` |
| Primary Rule | `HEX-001` |
| Supporting Rules | `CLEAN-004`, `CLEAN-009`, `LAYER-001`, `LAYER-007`, `SOLID-001` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the textual static manifest in `evaluation/scenarios/core/EVAL-CORE-001.md`.

The scope includes the order domain module, order business behavior, direct reference to external persistence infrastructure, direct instantiation of the external client, persistence behavior inside domain logic, external connection configuration knowledge inside the domain, and absence of an outbound abstraction.

The scope excludes executable code, framework-specific behavior, database-product behavior, formal architecture adoption, tactical DDD assessment, architecture-test assessment, CI/CD, cloud, and runtime verification.

## 4. Primary Rule Result

| Field             | Expected Value |
| ----------------- | -------------- |
| Rule ID           | `HEX-001` |
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
| `CLEAN-004` | `Applicable` or `Undetermined` | `Not Enough Evidence` or no separate result | `Not Enough Evidence` or not separately reported | None unless exclusive Clean use-case evidence is reported | `No` | Shared domain-to-infrastructure evidence may be referenced only as boundary context. | A Clean use-case isolation finding that merely restates `HEX-001`. | Preserve use-case isolation boundary without duplicating `HEX-001`. | No separate finding unless distinct Clean use-case evidence and reasoning are present. |
| `CLEAN-009` | `Applicable` or `Undetermined` | `Not Enough Evidence` or no separate result | `Not Enough Evidence` or not separately reported | None unless exclusive Clean gateway evidence is reported | `No` | Absence of a port, gateway, or contract may support `HEX-001` but does not by itself establish a Clean gateway failure. | A gateway finding that merely restates absence of abstraction or domain dependency on infrastructure. | Preserve gateway boundary responsibility without duplicating `HEX-001`. | No separate finding unless distinct Clean gateway evidence and reasoning are present. |
| `LAYER-001` | `Undetermined` or `Not Applicable` | `Not Enough Evidence` or `Not Applicable` | `Not Enough Evidence` or not separately reported | None unless exclusive layered policy-control evidence is reported | `No` | Shared persistence evidence does not prove lower-level control over business policy without an established layered decision path. | A layered policy finding that merely restates infrastructure dependency. | Avoid converting domain-to-infrastructure dependency into lower-level policy control without exclusive evidence. | No separate finding unless layered structure and lower-level decision control are established. |
| `LAYER-007` | `Undetermined` or `Not Applicable` | `Not Enough Evidence` or `Not Applicable` | `Not Enough Evidence` or not separately reported | None unless exclusive layered persistence-placement evidence is reported | `No` | Persistence behavior in domain supports `HEX-001`; layered persistence placement requires a defensible layered structure. | A persistence-placement finding that merely restates persistence access in domain. | Avoid duplicating persistence placement under a layered structure not formally established. | No separate finding unless layered persistence responsibility and leakage are independently established. |
| `SOLID-001` | `Applicable` or `Undetermined` | `Warning`, `Not Enough Evidence`, or no separate result | `Possible`, `Not Enough Evidence`, or not separately reported | None unless exclusive design-principle evidence is reported | `No` | Dependency-inversion reasoning may support remediation but does not own the architectural finding. | A SOLID finding that merely restates the same direct dependency as `HEX-001`. | Support abstraction and dependency-inversion reasoning without owning the architectural finding. | No separate finding unless distinct high-level policy dependency evidence is present. |

Supporting Rules may be mentioned as related rules, boundary references, expected non-findings, or forbidden duplicate findings. They do not require findings for this scenario.

## 6. Expected Finding

```text
Finding ID: EVAL-CORE-001-F001
Rule ID: HEX-001
Title: Domain order logic directly depends on external persistence infrastructure
Outcome: Fail
Confidence: Confirmed
Severity: High
Applicability: Applicable
Evidence: OrderPolicy references ExternalPersistenceClient, creates it using PersistenceConnectionSettings, and stores order state during domain rule execution without a port, gateway, or contract.
Architectural Impact: Central order domain behavior is coupled to an external infrastructure concern and cannot be reasoned about independently from that persistence mechanism.
Rationale: Direct reference, instantiation, configuration knowledge, and persistence behavior inside the domain satisfy the fail condition for HEX-001.
Remediation: Remove the direct infrastructure dependency from domain logic, define an abstraction owned by the core or appropriate boundary layer, move the external persistence implementation outside the domain, and invert the dependency direction.
Related Rules: CLEAN-004, CLEAN-009, LAYER-001, LAYER-007, SOLID-001
Boundary Notes: The finding concludes only that domain logic directly depends on external infrastructure. It must not duplicate separate Clean, Layered, DDD, repository, framework, testing, or persistence-strategy conclusions.
```

## 7. Expected Finding Evidence

Required evidence:

- domain scope is identified as order domain behavior;
- infrastructure concern is identified as external persistence;
- `OrderPolicy` directly references `ExternalPersistenceClient`;
- `OrderPolicy` directly creates the external client;
- `OrderPolicy` reads or uses external connection settings;
- `OrderPolicy` executes a persistence operation during business rule execution;
- no port, gateway, contract, or equivalent abstraction exists between domain and infrastructure;
- dependency direction points from domain to infrastructure.

This evidence is structural and behavioral. It is not naming-only evidence.

## 8. Expected Architectural Impact

The expected impact is high because the coupling affects central order domain behavior and a stable boundary between business rules and external persistence concerns.

The domain decision and the infrastructure operation are bound together. A change to the external persistence mechanism or its connection configuration can force changes in domain logic.

## 9. Expected Rationale

`HEX-001` applies because the reviewed material identifies both a domain scope and an infrastructure concern.

The expected outcome is `Fail` because direct evidence shows domain code depending on infrastructure concerns. The expected confidence is `Confirmed` because the manifest includes direct reference, instantiation, configuration knowledge, persistence behavior, and absence of an abstraction.

## 10. Expected Remediation

Expected remediation must:

- remove direct infrastructure dependency from domain behavior;
- define an abstraction owned by the core or appropriate boundary layer;
- move the concrete external persistence implementation outside the domain;
- invert dependency direction so infrastructure conforms to the abstraction;
- keep business rules independent from external persistence configuration and client lifecycle.

Expected remediation must not require microservices, DDD adoption, event sourcing, CQRS, a specific framework, a specific persistence technology, cloud, containers, a full architecture migration, or a total rewrite.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- absence of Bounded Context;
- absence of Aggregate;
- absence of Value Object;
- absence of Domain Event;
- absence of messaging;
- absence of formal Hexagonal Architecture;
- absence of formal Clean Architecture;
- absence of named layers;
- absence of architecture tests;
- use of Transaction Script;
- use of Active Record;
- absence of microservices;
- absence of CI/CD;
- absence of cloud;
- framework leakage;
- global persistence strategy;
- repository pattern correctness;
- testability as a separate finding;
- database product choice;
- runtime deployment shape.

## 12. Expected Applicability

Applicability is `Applicable`.

The manifest provides enough evidence to identify the domain scope, the infrastructure concern, and the dependency direction between them.

## 13. Expected Outcome

Outcome is `Fail`.

The observed result must fail the Primary Rule because direct evidence shows domain logic coupled to external infrastructure.

## 14. Expected Confidence

Confidence is `Confirmed`.

The conclusion is supported by direct structural and behavioral evidence. Naming alone is not used to establish confidence.

## 15. Expected Severity

Severity is `High`.

The issue affects central domain behavior in an order-processing flow and couples business rules to an external persistence mechanism and connection configuration.

`Medium` is allowed only as a contextual variation when the observed result explicitly justifies reduced blast radius while preserving `Applicable`, `Fail`, `Confirmed`, and the required finding.

## 16. Expected Evidence Interpretation

The direct reference, direct instantiation, persistence operation, external configuration knowledge, and absence of a boundary abstraction must be interpreted together as strong evidence of domain-to-infrastructure dependency.

The directory and component names may support scope identification but must not be treated as sufficient proof by themselves.

Withheld executable code, framework details, and database-specific details must not reduce confidence because the manifest provides explicit structural and behavioral evidence for the evaluated condition.

## 17. Expected Boundary Behavior

### Core × Hexagonal Architecture

The scenario is a Core gold standard scenario, but the Primary Rule remains `HEX-001` because `evaluation/SCENARIO_CATALOG.md` states that no `CORE-*` Rule prefix exists and assigns this scenario to `HEX-001`.

The expected finding belongs to `HEX-001`. Neighboring Hexagonal Rules may be referenced only to preserve boundaries or explain why additional findings are not required.

### Core × Clean Architecture

Clean Architecture rules may provide boundary context for use-case and gateway isolation. They must not duplicate the `HEX-001` finding unless the observed result identifies a Clean-specific conclusion with distinct evidence and reasoning.

Absence of formal Clean Architecture adoption must not produce a finding.

## 18. Expected Deduplication Behavior

Shared evidence is permitted.

The same conclusion must not appear as multiple findings.

Forbidden duplicate finding patterns include:

- `CLEAN-004` finding that merely restates domain logic depends on infrastructure;
- `CLEAN-009` finding that merely restates absence of an outbound abstraction;
- `LAYER-001` finding that merely restates infrastructure dependency without proving lower-level control over policy;
- `LAYER-007` finding that merely restates persistence access without establishing layered responsibility;
- `SOLID-001` finding that merely restates the same dependency inversion concern;
- `HEX-004`, `HEX-007`, `HEX-009`, or `HEX-012` findings that repeat the `HEX-001` conclusion without exclusive scope.

## 19. Expected False Positive Protection

The expected result must avoid findings based only on:

- naming;
- folders;
- package existence;
- documentation labels;
- infrastructure code existing near domain code;
- legitimate abstractions;
- infrastructure depending on core contracts;
- configuration located outside domain behavior;
- absence of a formal named architecture style.

Only the explicit domain reference to infrastructure supports the required failure.

## 20. Expected False Negative Protection

The expected result must not miss the failure because:

- persistence is considered an implementation detail;
- direct client creation is treated as harmless convenience;
- external configuration knowledge inside domain is ignored;
- the system is a monolith;
- there is only one persistence mechanism;
- adapter multiplicity is absent;
- package names suggest separation;
- formal architecture adoption is not declared.

## 21. Allowed Result Variations

Allowed variations:

- equivalent finding title that remains specific to domain logic and external persistence infrastructure;
- equivalent evidence ordering;
- equivalent remediation phrasing;
- `Medium` severity with explicit reduced-impact justification;
- supporting Rule list variation using existing semantically direct Rules;
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
- Primary Rule changed away from `HEX-001`;
- Clean, Layered, DDD, repository, framework, testability, microservice, CI/CD, or cloud finding without exclusive evidence;
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

- `HEX-001` is the Primary Rule result;
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
- the Primary Rule is nonexistent or reassigned away from `HEX-001`;
- expected non-findings appear as confirmed findings;
- remediation is prescriptive beyond the evidence;
- boundary behavior contradicts the scenario.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only when it stays within the allowed variations and preserves the required architectural conclusion.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/HEX_CATALOG.md` |
| Primary Rule normative file | `skill/rules/HEX-001.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-004.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-009.md` |
| Supporting Rule | `skill/rules/layered/LAYER-001.md` |
| Supporting Rule | `skill/rules/layered/LAYER-007.md` |
| Supporting Rule | `skill/rules/solid/SOLID-001.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |

## 28. Gold Standard Result Requirements

This expected result is the gold standard reference for future expected results in:

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

Initial expected result for `EVAL-CORE-001`.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
