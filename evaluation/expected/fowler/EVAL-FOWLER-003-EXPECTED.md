# Expected Result - EVAL-FOWLER-003

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-FOWLER-003-EXPECTED` |
| Scenario ID | `EVAL-FOWLER-003` |
| Scenario Title | `Active Record contains persistence and domain behavior` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-FOWLER-003` |
| Title | `Active Record contains persistence and domain behavior` |
| Category | `Fowler` |
| Scenario Type | `Warning Condition` |
| Catalogs | `Fowler`; boundary references to `DDD` and `Layered Architecture` |
| Primary Rule | `FOWLER-006` |
| Supporting Rules | `FOWLER-003`, `FOWLER-007`, `DDD-006` |
| Execution Type | `Static Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the textual static manifest in `evaluation/scenarios/fowler/EVAL-FOWLER-003.md`.

The scope includes one persisted object, row-shaped state, persisted identity, domain behavior methods, persistence operations on the same object, caller usage, mapping hints, limited invariants, and moderate change pressure.

The scope excludes executable code, complete ORM mapping, full transaction management, production defects, complete DDD model evidence, formal Layered/Clean/Hexagonal architecture, tests, runtime logs, deployment, and database product behavior.

## 4. Primary Rule Result

| Field | Expected Value |
| --- | --- |
| Rule ID | `FOWLER-006` |
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
| `FOWLER-003` | `Applicable` or `Undetermined` | `Not Enough Evidence`, `Warning`, or no separate result | `Possible` or `Not Enough Evidence` | None unless exclusive Domain Model evidence is reported | `No` | Domain behavior may be referenced as boundary context. | Domain Model finding that restates Active Record responsibility pressure. | Domain Model is an alternative, not a requirement. | No separate finding without exclusive object-model conclusion. |
| `FOWLER-007` | `Applicable` or `Undetermined` | `Not Enough Evidence`, `Warning`, or no separate result | `Possible` or `Not Enough Evidence` | None unless exclusive Data Mapper evidence is reported | `No` | Persistence coupling may be referenced as comparison context. | Data Mapper absence finding. | Data Mapper is not required universally. | No separate finding unless mapper separation is independently evaluated. |
| `DDD-006` | `Applicable` or `Undetermined` | `Not Enough Evidence`, `Warning`, or no separate result | `Possible` or `Not Enough Evidence` | None unless exclusive DDD entity evidence is reported | `No` | Identity may be referenced as context. | DDD entity finding that restates Active Record identity and behavior. | DDD identity semantics do not own the Fowler pattern result. | No DDD finding without exclusive DDD evidence. |

## 6. Expected Finding

```text
Finding ID: EVAL-FOWLER-003-F001
Rule ID: FOWLER-006
Title: Active Record object shows growing persistence and domain responsibility pressure
Outcome: Warning
Confidence: Possible
Severity: Medium
Applicability: Applicable
Evidence: SubscriptionRecord has persisted identity and state, exposes domain behavior such as changePlan, and also owns save/delete-style persistence operations used by the caller.
Architectural Impact: Active Record remains a valid Fowler pattern, but growing same-object persistence and domain behavior may reduce clarity and make future changes harder.
Business Logic Impact: Subscription rules may become harder to evolve if richer policies continue to accumulate beside persistence operations.
Maintenance Impact: Changes to persistence mechanics and business behavior may increasingly affect the same object.
Rationale: FOWLER-006 owns the combined data, behavior, and persistence responsibility. Its warning conditions cover partial, mixed, or responsibility-pressured Active Record implementations.
Remediation: Keep Active Record if the object remains simple and coherent; if behavior grows, clarify pattern intent, keep record behavior small, or incrementally separate richer domain behavior and persistence mapping.
Related Rules: FOWLER-003, FOWLER-007, DDD-006
Boundary Notes: The finding concludes only contextual Active Record responsibility pressure. It must not require Data Mapper, DDD entities, Layered Architecture, Clean Architecture, or Hexagonal Architecture.
```

## 7. Expected Finding Evidence

Required evidence:

- persisted object identity;
- row-shaped persisted state;
- domain behavior methods;
- persistence operations on the same object;
- caller flow using same-object behavior and persistence;
- mapping hints;
- limited invariants and moderate change pressure.

This evidence is behavioral and responsibility-based. Naming alone is insufficient.

## 8. Expected Architectural Impact

The expected impact is medium maintainability risk.

Active Record remains legitimate, but the same object may become harder to evolve when persistence mechanics and growing business behavior change together.

## 9. Expected Rationale

`FOWLER-006` applies because the reviewed material identifies an object combining domain data, domain behavior, and persistence operations.

The expected outcome is `Warning` because the evidence shows responsibility pressure but not confirmed pattern breakdown.

## 10. Expected Remediation

Expected remediation must:

- preserve Active Record where simple and coherent;
- clarify the selected persistence pattern;
- keep Active Record behavior small enough to remain understandable;
- extract richer behavior or persistence mapping only when complexity justifies it;
- remain technology-neutral and incremental.

Expected remediation must not require Data Mapper, DDD, Clean, Hexagonal, microservices, CQRS, event sourcing, ORM changes, framework migration, or a rewrite.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- Active Record as inherently invalid;
- missing Data Mapper;
- missing Domain Model;
- DDD entity violation;
- missing Aggregate, Value Object, Bounded Context, or Domain Event;
- Layered violation from persistence methods alone;
- Clean or Hexagonal violation;
- missing Repository;
- ORM or database choice;
- monolith structure;
- separate Unit of Work, Identity Field, or Foreign Key Mapping findings without exclusive evidence.

## 12. Expected Applicability

Applicability is `Applicable`.

The manifest provides enough evidence to identify the Active Record responsibility under `FOWLER-006`.

## 13. Expected Outcome

Outcome is `Warning`.

`Pass` is acceptable only when observed reasoning explicitly shows simple coherent Active Record usage. `Fail` requires confirmed responsibility breakdown.

## 14. Expected Confidence

Confidence is `Possible`.

The conclusion is supported by partial behavioral evidence, not a complete implementation review.

## 15. Expected Severity

Severity is `Medium`.

The risk affects subscription behavior with billing implications, but the evidence remains partial and the pattern is legitimate.

## 16. Expected Evidence Interpretation

Interpret same-object persistence and domain behavior as Active Record evidence. Do not interpret it as automatic DDD, Layered, Clean, or Hexagonal failure.

## 17. Expected Boundary Behavior

### Fowler Internal Boundaries

`FOWLER-006` owns the primary result. Domain Model, Data Mapper, Unit of Work, Identity Field, and Foreign Key Mapping may be mentioned only as adjacent boundaries or proportional alternatives.

### Fowler x DDD and Layered

DDD and Layered findings require exclusive evidence. They must not duplicate Active Record responsibility pressure.

## 18. Expected Deduplication Behavior

Shared evidence is permitted. Duplicate conclusions are not.

The same object responsibility pressure must not appear as separate `FOWLER-003`, `FOWLER-007`, `DDD-006`, Layered, Clean, or Hexagonal findings.

## 19. Expected False Positive Protection

The expected result must avoid automatic violation language for Active Record and must not require Data Mapper, DDD, or layered separation by default.

## 20. Expected False Negative Protection

The expected result must not ignore same-object mixed responsibilities when behavior and persistence operations are explicitly provided.

## 21. Allowed Result Variations

Allowed variations:

- equivalent finding title;
- equivalent evidence ordering;
- equivalent remediation phrasing;
- `Pass` when the observed result justifies simple coherent Active Record usage;
- mention of Data Mapper or Domain Model as alternatives without requiring them.

## 22. Disallowed Result Variations

Disallowed variations:

- Primary Rule changed away from `FOWLER-006`;
- Active Record condemned categorically;
- mandatory Data Mapper or DDD;
- `Fail` without confirmed breakdown;
- duplicate findings for persistence methods, identity, mapping, or behavior;
- finding based only on class name or ORM annotation.

## 23. Comparison Method

Compare observed output against this expected result by checking identity, Primary Rule, applicability, outcome, confidence, severity, required finding, expected non-findings, evidence interpretation, boundary behavior, deduplication, remediation, and traceability.

Manual comparison is sufficient.

## 24. Acceptance Criteria

The observed result is accepted when:

- `FOWLER-006` is primary;
- applicability is `Applicable`;
- outcome is `Warning` or accepted contextual `Pass`;
- confidence is `Possible` for warning;
- severity is `Medium` for warning;
- at most one Active Record finding appears;
- expected non-findings are absent;
- boundary ownership is preserved;
- remediation is proportional.

## 25. Failure Criteria

The observed result fails when:

- Active Record is treated as universally wrong;
- Data Mapper or DDD is required;
- the same evidence is split into duplicate findings;
- DDD or Layered findings replace the Fowler result;
- same-object persistence and behavior are ignored;
- remediation is prescriptive beyond evidence.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only within the allowed variations.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/fowler/EVAL-FOWLER-003.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule catalog | `skill/rules/FOWLER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/fowler/FOWLER-006.md` |
| Supporting Rule | `skill/rules/fowler/FOWLER-003.md` |
| Supporting Rule | `skill/rules/fowler/FOWLER-007.md` |
| Supporting Rule | `skill/rules/ddd/DDD-006.md` |
| Adjacent cataloged Rule | `skill/rules/fowler/FOWLER-011.md` |
| Adjacent cataloged Rule | `skill/rules/fowler/FOWLER-013.md` |
| Adjacent cataloged Rule | `skill/rules/fowler/FOWLER-014.md` |
| Fowler catalog review | `skill/reviews/FOWLER_CATALOG_REVIEW.md` |
| Fowler catalog stabilization | `skill/reviews/FOWLER_CATALOG_STABILIZATION.md` |

## 28. Gold Standard Result Requirements

This expected result follows the structure of `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` and adapts it to Fowler Active Record warning behavior. It does not redefine Rule meaning or catalog ownership.

## 29. Result Change Notes

Initial expected result for `EVAL-FOWLER-003`.

Aligned with the Gold Standard expected-result structure, evaluation models, scenario catalog identity, `FOWLER-006` Primary Rule, selected supporting rules, expected `Warning` outcome, and Active Record x Data Mapper x Domain Model boundary.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
