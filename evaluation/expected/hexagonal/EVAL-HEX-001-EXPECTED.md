# Expected Result - EVAL-HEX-001

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-HEX-001-EXPECTED` |
| Scenario ID | `EVAL-HEX-001` |
| Scenario Title | `Core depends directly on a database adapter` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-HEX-001` |
| Title | `Core depends directly on a database adapter` |
| Category | `Hexagonal Architecture` |
| Scenario Type | `Confirmed Violation` |
| Catalogs | `Hexagonal Architecture`; boundary references to `Core`, `Clean Architecture`, and `Layered Architecture` |
| Primary Rule | `HEX-009` |
| Supporting Rules | `HEX-004`, `HEX-007`, `CLEAN-009` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the textual static manifest in `evaluation/scenarios/hexagonal/EVAL-HEX-001.md`.

The scope includes the application core, order submission use case, concrete database adapter, direct reference, direct instantiation, database settings known by the core, storage behavior, absence of an outbound port, and composition inside the core.

The scope excludes executable code, framework-specific behavior, database-product behavior, formal architecture adoption, tactical DDD assessment, architecture-test assessment, CI/CD, cloud, microservices, and runtime verification.

## 4. Primary Rule Result

| Field             | Expected Value |
| ----------------- | -------------- |
| Rule ID           | `HEX-009` |
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
| `HEX-004` | `Applicable` or `Undetermined` | `Fail`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | None unless exclusive outbound-port finding evidence is reported | `No` | Absence of outbound port supports `HEX-009`. | A generic outbound-port finding that merely restates the database-adapter dependency. | Preserve broader outbound-port boundary without duplicating persistence-specific conclusion. | No separate finding unless distinct non-persistence outbound evidence exists. |
| `HEX-007` | `Applicable` or `Undetermined` | `Fail`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | None unless exclusive dependency-direction evidence is reported | `No` | Direct core-to-adapter dependency supports `HEX-009`. | A dependency-direction finding that merely restates the same core-to-database-adapter dependency. | Preserve general direction boundary without duplicating `HEX-009`. | No separate finding unless a broader dependency-direction issue is independently established. |
| `CLEAN-009` | `Applicable` or `Undetermined` | `Not Enough Evidence` or no separate result | `Not Enough Evidence` or not separately reported | None unless exclusive Clean gateway evidence is reported | `No` | Missing port may be boundary context only. | A Clean gateway finding that merely restates the Hexagonal missing outbound port. | Preserve Clean gateway boundary without duplicate finding. | No separate finding unless Clean use-case gateway evidence and reasoning are distinct. |

Supporting Rules may be mentioned as related rules, boundary references, expected non-findings, or forbidden duplicate findings. They do not require findings for this scenario.

## 6. Expected Finding

```text
Finding ID: EVAL-HEX-001-F001
Rule ID: HEX-009
Title: Application core directly depends on an external database adapter
Outcome: Fail
Confidence: Confirmed
Severity: High
Applicability: Applicable
Evidence: SubmitOrderUseCase references OrderDatabaseAdapter, creates it with DatabaseConnectionSettings, and stores order state through the concrete adapter without an outbound port.
Architectural Impact: The application core is coupled to a concrete persistence mechanism and the dependency direction points from inside to outside.
Rationale: Direct reference, instantiation, adapter configuration knowledge, persistence behavior, and absence of an outbound port satisfy the fail condition for HEX-009.
Remediation: Define an outbound port owned by the application core, make the core depend on that port, move the concrete database implementation outside the core, perform composition externally, and invert dependency direction.
Related Rules: HEX-004, HEX-007, CLEAN-009
Boundary Notes: The finding concludes only that the application core directly depends on an external database adapter instead of an application-owned outbound port.
```

## 7. Expected Finding Evidence

Required evidence:

- application core scope is identified;
- database adapter scope is identified;
- `SubmitOrderUseCase` directly references `OrderDatabaseAdapter`;
- `SubmitOrderUseCase` directly creates the adapter;
- `SubmitOrderUseCase` uses database settings;
- `SubmitOrderUseCase` performs storage through the concrete adapter;
- no outbound port or equivalent abstraction exists;
- dependency direction points from inside to outside.

This evidence is structural and behavioral. It is not naming-only evidence.

## 8. Expected Architectural Impact

The expected impact is high because the coupling affects central order submission behavior and a stable persistence boundary.

The application core decision and concrete database adapter lifecycle are bound together. A change to the adapter or its connection configuration can force changes in core behavior.

## 9. Expected Rationale

`HEX-009` applies because the reviewed material identifies application core behavior, a persistence concern, and an outbound interaction with a concrete database adapter.

The expected outcome is `Fail` because direct evidence shows persistence concerns are not behind an outbound port. The expected confidence is `Confirmed` because direct reference, instantiation, configuration knowledge, persistence behavior, and absence of a port are all explicit.

## 10. Expected Remediation

Expected remediation must:

- define an outbound port belonging to the application core;
- make the core depend on the port;
- move the concrete database implementation outside the core;
- perform composition externally;
- invert dependency direction so the adapter depends on the core-owned port.

Expected remediation must not require microservices, DDD adoption, Repository Pattern by name, event sourcing, CQRS, a specific framework, ORM, cloud, containers, a full architecture migration, or a total rewrite.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- absence of inbound port;
- absence of multiple adapters;
- absence of DDD;
- absence of Bounded Context;
- absence of Clean Architecture formalism;
- absence of named layers;
- absence of architecture tests;
- use of monolith;
- database product choice;
- absence of microservices;
- absence of messaging;
- absence of Repository Pattern by name;
- global testability as a separate finding;
- generic Core violation;
- duplicate Clean gateway failure;
- duplicate Layered persistence or bypass failure.

## 12. Expected Applicability

Applicability is `Applicable`.

The manifest provides enough evidence to identify the application core, concrete database adapter, persistence interaction, missing outbound port, and dependency direction.

## 13. Expected Outcome

Outcome is `Fail`.

The observed result must fail the Primary Rule because direct evidence shows the application core depends on a concrete persistence adapter instead of an outbound port.

## 14. Expected Confidence

Confidence is `Confirmed`.

The conclusion is supported by direct structural and behavioral evidence. Naming alone is not used to establish confidence.

## 15. Expected Severity

Severity is `High`.

The issue affects central order submission behavior and couples core behavior to a concrete database adapter and external connection configuration.

`Medium` is allowed only as a contextual variation when the observed result explicitly justifies reduced blast radius while preserving `Applicable`, `Fail`, `Confirmed`, and the required finding.

## 16. Expected Evidence Interpretation

Direct reference, direct instantiation, storage behavior, external configuration knowledge, and absence of an outbound port must be interpreted together as strong evidence of persistence concern leakage into the core boundary.

Directory and component names may support scope identification but must not be treated as sufficient proof by themselves.

Withheld executable code, framework details, and database-specific details must not reduce confidence because the manifest provides explicit structural and behavioral evidence for the evaluated condition.

## 17. Expected Boundary Behavior

### Hexagonal x Core

The expected finding belongs to `HEX-009`. Core review behavior contributes evidence discipline and no-duplication expectations, but no generic Core finding is allowed for the same conclusion.

### Hexagonal x Clean

Clean Architecture rules may provide boundary context for gateway isolation. They must not duplicate the `HEX-009` finding unless the observed result identifies a Clean-specific conclusion with distinct evidence and reasoning.

### Hexagonal x Layered

Layered Architecture rules may provide boundary context for persistence placement or layer bypassing. They must not duplicate the `HEX-009` finding unless a layered structure and exclusive layered conclusion are established.

## 18. Expected Deduplication Behavior

Shared evidence is permitted.

The same conclusion must not appear as multiple findings.

Forbidden duplicate finding patterns include:

- `HEX-004` finding that merely restates missing outbound port for the database adapter;
- `HEX-007` finding that merely restates the same core-to-adapter dependency;
- `CLEAN-009` finding that merely restates missing gateway/port abstraction;
- Layered finding that merely restates direct database access without a distinct layered structure;
- Core finding that restates the Hexagonal violation.

## 19. Expected False Positive Protection

The expected result must avoid findings when:

- adapter depends on port;
- external implementation depends on core contract;
- composition occurs outside the core;
- external factory instantiates adapter;
- core knows only a core-owned contract;
- there is only one adapter;
- system is monolithic;
- system lacks `port` or `adapter` naming.

Only direct core dependency on a concrete database adapter supports the required failure.

## 20. Expected False Negative Protection

The expected result must not miss the failure because:

- adapter is in the same project;
- adapter is in the same process;
- there is only one database;
- concrete class implements an external interface;
- direct dependency was convenient;
- system is small;
- Hexagonal Architecture is not formally declared;
- adapter has a generic name.

## 21. Allowed Result Variations

Allowed variations:

- equivalent finding title specific to core and external database adapter;
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
- Primary Rule changed away from `HEX-009`;
- Clean, Layered, Core, DDD, repository, framework, testability, microservice, CI/CD, or cloud finding without exclusive evidence;
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

- `HEX-009` is the Primary Rule result;
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
- the Primary Rule is nonexistent or reassigned away from `HEX-009`;
- expected non-findings appear as confirmed findings;
- remediation is prescriptive beyond the evidence;
- boundary behavior contradicts the scenario.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only when it stays within the allowed variations and preserves the required architectural conclusion.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/hexagonal/EVAL-HEX-001.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/HEX_CATALOG.md` |
| Primary Rule normative file | `skill/rules/HEX-009.md` |
| Supporting Rule | `skill/rules/HEX-004.md` |
| Supporting Rule | `skill/rules/HEX-007.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-009.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
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

Initial expected result for `EVAL-HEX-001`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity, selected Primary Rule `HEX-009`, and expected `Fail` result.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
