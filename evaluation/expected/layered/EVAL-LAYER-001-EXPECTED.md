# Expected Result - EVAL-LAYER-001

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-LAYER-001-EXPECTED` |
| Scenario ID | `EVAL-LAYER-001` |
| Scenario Title | `Presentation layer accesses persistence directly` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-LAYER-001` |
| Title | `Presentation layer accesses persistence directly` |
| Category | `Layered Architecture` |
| Scenario Type | `Confirmed Violation` |
| Catalogs | `Layered Architecture`; boundary references to `Clean Architecture` |
| Primary Rule | `LAYER-008` |
| Supporting Rules | `LAYER-003`, `LAYER-004`, `LAYER-007` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the textual static manifest in `evaluation/scenarios/layered/EVAL-LAYER-001.md`.

The scope includes the Presentation component, required Application mediation, Domain rule mediation context, Persistence component, direct Presentation-to-Persistence dependency, query/update behavior, and absence of Application delegation on the observed path.

The scope excludes executable code, framework-specific behavior, database-product behavior, formal Clean Architecture adoption, formal Hexagonal Architecture adoption, DDD assessment, architecture-test assessment, CI/CD, cloud, microservices, and runtime verification.

## 4. Primary Rule Result

| Field             | Expected Value |
| ----------------- | -------------- |
| Rule ID           | `LAYER-008` |
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
| `LAYER-003` | `Applicable` or `Undetermined` | `Fail`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | None unless exclusive dependency-direction evidence is reported | `No` | Direct Presentation-to-Persistence dependency may support bypass context. | A dependency-direction finding that merely restates the skipped Application mediation. | Preserve direction boundary without duplicating `LAYER-008`. | No separate finding unless a broader direction violation is independently established. |
| `LAYER-004` | `Applicable` or `Undetermined` | `Fail`, `Warning`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Possible`, `Not Enough Evidence`, or not separately reported | None unless exclusive presentation-ownership evidence is reported | `No` | Presentation persistence calls may be context for responsibility drift. | A presentation-behavior finding that merely restates direct persistence access. | Preserve presentation responsibility boundary without duplicate conclusion. | No separate finding unless Presentation owns application or business behavior beyond bypass. |
| `LAYER-007` | `Applicable` or `Undetermined` | `Fail`, `Not Enough Evidence`, or no separate result | `Confirmed`, `Not Enough Evidence`, or not separately reported | None unless exclusive persistence-placement evidence is reported | `No` | Persistence access in `OrderDetailsScreen` supports bypass evidence. | A persistence-placement finding that merely repeats the `LAYER-008` bypass. | Preserve persistence placement boundary without duplicating direct bypass. | No separate finding unless concrete persistence responsibility leakage is independently concluded. |

Supporting Rules may be mentioned as related rules, boundary references, expected non-findings, or forbidden duplicate findings. They do not require separate findings for this scenario.

## 6. Expected Finding

```text
Finding ID: EVAL-LAYER-001-F001
Rule ID: LAYER-008
Title: Presentation order screen bypasses application mediation and accesses persistence directly
Outcome: Fail
Confidence: Confirmed
Severity: High
Applicability: Applicable
Evidence: OrderDetailsScreen directly references OrderSqlTable and performs order query/update behavior without calling the required OrderApplicationService mediation path.
Architectural Impact: Presentation can create order read/write paths that skip application coordination and domain rule mediation, eroding the declared layered structure.
Responsibility Impact: Presentation assumes access to persistence behavior that should remain mediated by Application and Persistence responsibilities.
Dependency Impact: A direct Presentation-to-Persistence dependency skips the required intermediate Application layer.
Rationale: Direct dependency, persistence behavior, declared mediation requirement, and skipped Application path satisfy the fail condition for LAYER-008.
Remediation: Route order lookup and update requests through the application service, keep persistence access behind the assigned data access responsibility, and preserve presentation as interaction and delegation code.
Related Rules: LAYER-003, LAYER-004, LAYER-007
Boundary Notes: The finding concludes only the required-layer bypass. It must not duplicate Clean, Hexagonal, DDD, Repository Pattern, or global persistence-strategy findings.
```

## 7. Expected Finding Evidence

Required evidence:

- Presentation scope is identified;
- Application mediation is identified as required;
- Persistence responsibility is identified;
- `OrderDetailsScreen` directly references `OrderSqlTable`;
- `OrderDetailsScreen` performs persistence query and update behavior;
- `OrderApplicationService` is skipped on the observed path;
- dependency and control flow skip the required intermediate layer.

This evidence is structural and behavioral. It is not naming-only evidence.

## 8. Expected Architectural Impact

The expected impact is high because the bypass affects order update behavior and a stable Presentation-to-Application-to-Persistence path.

The Presentation component can create read/write paths that avoid application coordination and domain rule mediation.

## 9. Expected Rationale

`LAYER-008` applies because the reviewed material identifies participating layers, a required intermediate Application layer, and an observed direct path that skips that layer.

The expected outcome is `Fail` because direct evidence shows required mediation is bypassed. The expected confidence is `Confirmed` because the dependency, call behavior, and skipped path are explicit.

## 10. Expected Remediation

Expected remediation must:

- remove direct Presentation dependency on persistence access;
- route lookup and update behavior through Application mediation;
- keep persistence access inside the assigned data access responsibility;
- preserve Presentation as interaction, adaptation, and delegation;
- keep the fix scoped to the observed bypass.

Expected remediation must not require Clean Architecture, Hexagonal Architecture, DDD, microservices, CQRS, event sourcing, a specific framework, a specific ORM, project separation, cloud, containers, or a total rewrite.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- absence of exactly four layers;
- absence of traditional layer names;
- absence of separate projects;
- absence of interfaces between every layer;
- use of a monolith;
- use of a single database;
- absence of Clean Architecture formalism;
- absence of Hexagonal Architecture formalism;
- absence of DDD;
- absence of Repository Pattern;
- framework usage in Presentation;
- data returned through a mediated contract;
- legitimate adjacent-layer dependency;
- architecture-test absence;
- microservice absence.

## 12. Expected Applicability

Applicability is `Applicable`.

The manifest provides enough evidence to identify the layered structure, required mediation, and observed bypass path.

## 13. Expected Outcome

Outcome is `Fail`.

The observed result must fail the Primary Rule because direct evidence shows Presentation bypassing Application mediation to access Persistence.

## 14. Expected Confidence

Confidence is `Confirmed`.

The conclusion is supported by direct dependency and behavior evidence. Naming alone is not used to establish confidence.

## 15. Expected Severity

Severity is `High`.

The issue affects order update behavior and skips mediation on a stable layer boundary. `Medium` is allowed only with explicit reduced-impact justification while preserving the required finding.

## 16. Expected Evidence Interpretation

Direct reference, persistence query/update behavior, declared mediation requirement, and skipped Application path must be interpreted together as strong evidence of layer bypass.

Directory and component names may support scope identification but must not be treated as sufficient proof by themselves.

Withheld executable code and framework details must not reduce confidence because the manifest provides explicit structural and behavioral evidence.

## 17. Expected Boundary Behavior

### Layered x Clean Architecture

The expected finding belongs to `LAYER-008`. Clean Architecture may provide context around controller and use case isolation, but it must not duplicate the bypass finding without exclusive Clean evidence.

### Layered x Hexagonal Architecture

Hexagonal Architecture must not report a missing-port or adapter finding from the same evidence unless ports/adapters and inside/outside evidence are independently established.

### Layered x Core

Core review behavior contributes evidence discipline and no-duplication expectations, but no generic Core finding is allowed for the same conclusion.

### Layered x Fowler

Fowler pattern findings are forbidden unless pattern-specific behavior is independently provided.

## 18. Expected Deduplication Behavior

Shared evidence is permitted.

The same conclusion must not appear as multiple findings.

Forbidden duplicate finding patterns include:

- `LAYER-003` finding that merely restates direct bypass;
- `LAYER-004` finding that merely restates persistence access from Presentation;
- `LAYER-007` finding that merely repeats the bypass as persistence leakage;
- Clean controller/use-case finding with the same conclusion;
- Hexagonal missing-port finding from the same direct access evidence;
- Fowler Repository or Transaction Script finding without pattern-specific evidence.

## 19. Expected False Positive Protection

The expected result must avoid findings based only on:

- layer-like names;
- controller or screen naming;
- repository or table naming;
- Presentation receiving mediated data;
- Presentation formatting DTOs;
- same-project deployment;
- absence of formal architecture adoption.

Only direct persistence access that skips required mediation supports the failure.

## 20. Expected False Negative Protection

The expected result must not miss the failure because:

- the direct persistence component is in the same process;
- the system is small;
- the query appears simple;
- Application exists for other flows;
- layer names are unconventional;
- no formal Layered Architecture claim is present.

## 21. Allowed Result Variations

Allowed variations:

- equivalent finding title specific to Presentation bypass and persistence access;
- equivalent evidence ordering;
- equivalent technology-neutral remediation phrasing;
- `Medium` severity with explicit reduced-impact justification;
- supporting Rule omission when boundaries remain preserved;
- result status `Acceptable Variation` only when `Fail`, `Confirmed`, and one finding remain.

## 22. Disallowed Result Variations

Disallowed variations:

- primary outcome other than `Fail`;
- applicability other than `Applicable`;
- confidence below `Confirmed`;
- missing required finding;
- more than one finding for the same conclusion;
- generic layer violation title;
- finding based only on naming;
- nonexistent Rule ID;
- Primary Rule changed away from `LAYER-008`;
- Clean, Hexagonal, Core, Fowler, DDD, repository, framework, testing, microservice, CI/CD, or cloud finding without exclusive evidence;
- remediation requiring unrelated redesign, tooling, platform, or rewrite.

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

- `LAYER-008` is the Primary Rule result;
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
- the Primary Rule is nonexistent or reassigned away from `LAYER-008`;
- expected non-findings appear as confirmed findings;
- remediation is prescriptive beyond the evidence;
- boundary behavior contradicts the scenario.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only when it stays within the allowed variations and preserves the required architectural conclusion.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/layered/EVAL-LAYER-001.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/LAYER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/layered/LAYER-008.md` |
| Supporting Rule | `skill/rules/layered/LAYER-003.md` |
| Supporting Rule | `skill/rules/layered/LAYER-004.md` |
| Supporting Rule | `skill/rules/layered/LAYER-007.md` |
| Layered catalog review | `skill/reviews/LAYER_CATALOG_REVIEW.md` |
| Layered catalog stabilization | `skill/reviews/LAYER_CATALOG_STABILIZATION.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Fowler boundary review | `skill/reviews/FOWLER_CATALOG_REVIEW.md` |
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

Initial expected result for `EVAL-LAYER-001`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `LAYER-008`, selected Supporting Rules, and expected `Fail` result.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
