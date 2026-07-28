# Expected Result - EVAL-FOWLER-001

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-FOWLER-001-EXPECTED` |
| Scenario ID | `EVAL-FOWLER-001` |
| Scenario Title | `Complex business workflow implemented as procedural transaction script` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-FOWLER-001` |
| Title | `Complex business workflow implemented as procedural transaction script` |
| Category | `Fowler` |
| Scenario Type | `Warning Condition` |
| Catalogs | `Fowler`; boundary reference to `DDD` |
| Primary Rule | `FOWLER-002` |
| Supporting Rules | `FOWLER-003`, `FOWLER-005`, `DDD-013` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the textual static manifest in `evaluation/scenarios/fowler/EVAL-FOWLER-001.md`.

The scope includes the procedural renewal transaction, inline eligibility checks, discount and waiver calculations, persistence coordination, notification coordination, weak domain behavior outside the script, partial duplication evidence, and quarterly policy-change pressure.

The scope excludes executable code, full production architecture, runtime incidents, complete duplication inventory, formal DDD adoption, formal Layered/Clean/Hexagonal adoption, tests, database product behavior, and deployment.

## 4. Primary Rule Result

| Field | Expected Value |
| --- | --- |
| Rule ID | `FOWLER-002` |
| Applicability | `Applicable` |
| Outcome | `Warning` |
| Confidence | `Possible` |
| Severity | `Medium` |
| Finding Required | `Yes` |
| Finding Count | `1` |
| Evidence Strength | `Partial` |
| Result Status | `Match` |

## 5. Supporting Rule Results

| Rule ID | Applicability | Expected Outcome | Expected Confidence | Expected Severity Range | Expected Finding | Expected Evidence | Forbidden Finding | Boundary Notes | Acceptance Criteria |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `FOWLER-003` | `Applicable` or `Undetermined` | `Not Enough Evidence`, `Warning`, or no separate result | `Possible` or `Not Enough Evidence` | None unless exclusive Domain Model evidence is reported | `No` | Weak object behavior may be referenced as context. | Domain Model absence finding that restates the Transaction Script warning. | Domain Model is optional and contextual. | No separate finding unless object-model responsibility is independently evaluated. |
| `FOWLER-005` | `Applicable` or `Undetermined` | `Not Enough Evidence`, `Warning`, or no separate result | `Possible` or `Not Enough Evidence` | None unless exclusive Service Layer evidence is reported | `No` | Operation coordination may be referenced as context. | Service Layer finding that restates procedural complexity. | Preserve Service Layer boundary. | No separate finding unless service-boundary evidence is distinct. |
| `DDD-013` | `Not Applicable` or `Undetermined` | `Not Applicable`, `Not Enough Evidence`, or no separate result | `Not Enough Evidence` or not separately reported | None | `No` | Domain complexity may be mentioned as boundary context. | DDD tactical-modeling finding from the same Fowler evidence. | DDD must not own the Fowler conclusion. | DDD findings remain absent without exclusive DDD evidence. |

## 6. Expected Finding

```text
Finding ID: EVAL-FOWLER-001-F001
Rule ID: FOWLER-002
Title: Procedural renewal transaction script shows complexity pressure
Outcome: Warning
Confidence: Possible
Severity: Medium
Applicability: Applicable
Evidence: RenewContractScript coordinates several business rules, branching calculations, persistence, and notification side effects while ContractRecord remains data-shaped and duplicate eligibility checks are partially evidenced.
Architectural Impact: The Transaction Script remains a valid pattern, but concentrated procedural rules may become harder to change consistently as renewal policy varies.
Business Logic Impact: Renewal terms, discounts, and waivers can diverge across scripts if the same policies continue to be copied procedurally.
Maintenance Impact: Quarterly policy changes are likely to require repeated edits in procedural workflows.
Rationale: FOWLER-002 owns procedural request transaction organization and its warning condition covers partial, duplicated, or mixed scripts that weaken the boundary without proving failure.
Remediation: Keep Transaction Script if the workflow remains simple; otherwise incrementally extract repeated rules, split unrelated steps, or move complex policy behavior into a proportionate object model or clearer service boundary.
Related Rules: FOWLER-003, FOWLER-005, DDD-013
Boundary Notes: The finding concludes only contextual Transaction Script complexity risk. It must not become a DDD, Domain Model absence, Service Layer, Clean, Hexagonal, or Layered finding.
```

## 7. Expected Finding Evidence

Required evidence:

- request-centered procedural workflow;
- multiple inline business rules;
- branching calculations by customer segment;
- persistence coordination in the same procedure;
- side-effect coordination in the same procedure;
- weak domain behavior in `ContractRecord`;
- partial duplicate eligibility checks;
- policy-change pressure.

This evidence is behavioral and contextual. Naming alone is insufficient.

## 8. Expected Architectural Impact

The expected impact is medium maintainability risk.

The system may keep Transaction Script, but the current concentration of rules and side effects increases the risk of divergent behavior as renewal policy changes.

## 9. Expected Rationale

`FOWLER-002` applies because the reviewed material identifies procedural request transaction logic.

The expected outcome is `Warning` because evidence shows complexity pressure and partial duplication, but withheld evidence prevents a confirmed `Fail`.

## 10. Expected Remediation

Expected remediation must:

- preserve Transaction Script where it remains proportionate;
- extract duplicated eligibility checks if duplication grows;
- split unrelated side-effect coordination when it obscures business policy;
- move richer behavior into an object model only when complexity justifies it;
- remain technology-neutral and incremental.

Expected remediation must not require DDD, Domain Model, Clean, Hexagonal, microservices, CQRS, event sourcing, messaging, framework migration, or a rewrite.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- Transaction Script as inherently invalid;
- missing Domain Model;
- missing DDD;
- anemic domain model under DDD;
- missing Aggregate, Value Object, Bounded Context, or Domain Event;
- Service Layer failure;
- Clean or Hexagonal violation;
- Layered Architecture violation;
- Repository absence;
- one finding per inline rule;
- monolith, CRUD, ORM, database, deployment, CI/CD, cloud, or architecture-test absence.

## 12. Expected Applicability

Applicability is `Applicable`.

The manifest provides enough evidence to identify procedural request transaction behavior under `FOWLER-002`.

## 13. Expected Outcome

Outcome is `Warning`.

The observed result must not downgrade the complexity pressure to unqualified `Pass` or escalate to `Fail` without stronger breakdown evidence.

## 14. Expected Confidence

Confidence is `Possible`.

The conclusion is supported by partial behavioral evidence. Complete impact and duplication evidence are withheld.

## 15. Expected Severity

Severity is `Medium`.

The issue affects an important renewal workflow and recurring policy changes, but the evidence remains partial. `Low` is allowed only with explicit reduced-impact justification.

## 16. Expected Evidence Interpretation

Interpret the evidence as contextual pressure on Transaction Script, not as proof that Transaction Script is invalid. Directory and class names may support scope but must not carry the conclusion.

## 17. Expected Boundary Behavior

### Fowler x DDD

Fowler owns the warning. DDD may be mentioned only to prevent over-prescription. Domain Model and tactical DDD are not required.

### Fowler x Layered, Clean, Hexagonal, Core

Neighboring catalogs must not duplicate the same procedural complexity conclusion. They require exclusive evidence for their own concerns.

## 18. Expected Deduplication Behavior

Shared evidence is permitted. Duplicate conclusions are not.

The same procedural complexity must not appear as separate `FOWLER-003`, `FOWLER-005`, `DDD-013`, Layered, Clean, Hexagonal, or Core findings.

## 19. Expected False Positive Protection

The expected result must avoid findings based only on Transaction Script presence, procedural style, script naming, absence of Domain Model, absence of DDD, monolith structure, or simple persistence coordination.

## 20. Expected False Negative Protection

The expected result must not ignore complexity pressure simply because Transaction Script is a recognized pattern or because direct failure evidence is withheld.

## 21. Allowed Result Variations

Allowed variations:

- equivalent finding title;
- equivalent evidence ordering;
- equivalent remediation phrasing;
- `Low` severity with explicit reduced-impact reasoning;
- mention of Domain Model or Service Layer as alternatives without requiring them.

## 22. Disallowed Result Variations

Disallowed variations:

- primary outcome other than `Warning`;
- Primary Rule changed away from `FOWLER-002`;
- confidence above `Possible` without stronger evidence;
- missing required warning;
- duplicate findings for same conclusion;
- DDD finding as primary result;
- remediation requiring unrelated architecture or tools.

## 23. Comparison Method

Compare observed output against this expected result by checking identity, Primary Rule, applicability, outcome, confidence, severity, required finding, expected non-findings, evidence interpretation, boundary behavior, deduplication, remediation, and traceability.

Manual comparison is sufficient.

## 24. Acceptance Criteria

The observed result is accepted when:

- `FOWLER-002` is primary;
- applicability is `Applicable`;
- outcome is `Warning`;
- confidence is `Possible`;
- severity is `Medium` or accepted contextual `Low`;
- exactly one warning finding appears;
- expected non-findings are absent;
- boundary ownership and deduplication are preserved;
- remediation is proportional.

## 25. Failure Criteria

The observed result fails when:

- the warning is absent;
- Transaction Script is condemned categorically;
- result is `Fail` without confirmed breakdown;
- result is unqualified `Pass`;
- DDD or Domain Model absence owns the finding;
- duplicate findings appear;
- remediation is prescriptive beyond evidence.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only within the allowed variations.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/fowler/EVAL-FOWLER-001.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/FOWLER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/fowler/FOWLER-002.md` |
| Supporting Rule | `skill/rules/fowler/FOWLER-003.md` |
| Supporting Rule | `skill/rules/fowler/FOWLER-005.md` |
| Supporting Rule | `skill/rules/ddd/DDD-013.md` |
| Fowler catalog review | `skill/reviews/FOWLER_CATALOG_REVIEW.md` |
| Fowler catalog stabilization | `skill/reviews/FOWLER_CATALOG_STABILIZATION.md` |

## 28. Gold Standard Result Requirements

This expected result follows the structure of `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` and adapts it to Fowler warning behavior. It does not redefine Rule meaning or catalog ownership.

## 29. Result Change Notes

Initial expected result for `EVAL-FOWLER-001`.

Aligned with the Gold Standard expected-result structure, evaluation models, scenario catalog identity, `FOWLER-002` Primary Rule, selected supporting rules, expected `Warning` outcome, and DDD x Fowler boundary.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
