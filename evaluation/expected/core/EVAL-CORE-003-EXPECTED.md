# Expected Result - EVAL-CORE-003

## 1. Result Identity

| Field | Expected Value |
| --- | --- |
| Result ID | `EVAL-CORE-003-EXPECTED` |
| Scenario ID | `EVAL-CORE-003` |
| Scenario Title | `Architectural intent documented but implementation unavailable` |
| Owner | `ArchInspector Evaluation Suite` |
| Result Status | `Match` |
| Version Context | `v0.6.0 - Evaluation Suite` |
| Gold Standard | `No` |
| Change Notes | Initial expected result. |

## 2. Scenario Reference

| Field | Expected Value |
| --- | --- |
| Scenario ID | `EVAL-CORE-003` |
| Title | `Architectural intent documented but implementation unavailable` |
| Category | `Core` |
| Scenario Type | `Insufficient Evidence` |
| Catalogs | `Core`; boundary references to `Solution Architecture` and `Architecture Testing` |
| Primary Rule | `SOL-001` |
| Supporting Rules | `TEST-002`, `TEST-003`, `TEST-001` |
| Execution Type | `Document Fixture` |
| Scenario Status | `Ready` |

## 3. Evaluation Scope

The expected result covers the document fixture in `evaluation/scenarios/core/EVAL-CORE-003.md`.

The scope includes architecture intent, conceptual module diagram, planned responsibilities, planned dependency direction, planned directory names, and written policy statements.

The scope excludes implementation files, imports, references, dependency graphs, manifests, configuration, composition evidence, execution, static analysis output, architecture-test output, contract implementations, CI/CD, cloud, and runtime verification.

## 4. Primary Rule Result

| Field             | Expected Value |
| ----------------- | -------------- |
| Rule ID           | `SOL-001` |
| Applicability     | `Undetermined` |
| Outcome           | `Not Enough Evidence` |
| Confidence        | `Not Enough Evidence` |
| Severity          | `Not Applicable` |
| Finding Required  | `No` |
| Finding Count     | `0` |
| Evidence Strength | `Nominal` |
| Result Status     | `Match` |

## 5. Supporting Rule Results

| Rule ID | Applicability | Expected Outcome | Expected Confidence | Expected Severity Range | Expected Finding | Expected Evidence | Forbidden Finding | Boundary Notes | Acceptance Criteria |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `TEST-002` | `Undetermined` or `Not Applicable` | `Not Enough Evidence`, `Not Applicable`, or no separate result | `Not Enough Evidence` or not separately reported | `Not Applicable` unless exclusive testing finding evidence is reported | `No` | Documentation may mention policy origin but no verification mechanism is provided. | An architecture-testing finding that treats missing verification as confirmed failure. | Preserve traceability boundary without requiring verification artifacts. | No separate finding unless a real verification mechanism is in scope. |
| `TEST-003` | `Undetermined` or `Not Applicable` | `Not Enough Evidence`, `Not Applicable`, or no separate result | `Not Enough Evidence` or not separately reported | `Not Applicable` unless exclusive testing finding evidence is reported | `No` | Constraint wording may be reviewed, but no implementation or verification criterion is available. | A testability finding that converts missing implementation into violation. | Preserve constraint-testability boundary. | No separate finding unless a specific verification claim exists. |
| `TEST-001` | `Not Applicable` or `Undetermined` | `Not Applicable`, `Not Enough Evidence`, or no separate result | `Not Enough Evidence` or not separately reported | `Not Applicable` unless exclusive fitness-function evidence is reported | `No` | No declared fitness function is provided. | A fitness-function finding based only on architecture documentation. | Do not treat intent as an effective validation mechanism. | No separate finding unless a declared fitness function or equivalent control exists. |

Supporting Rules may be mentioned as related rules, boundary references, expected non-findings, or forbidden duplicate findings. They do not require findings for this scenario.

## 6. Expected Finding

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: SOL-001
Outcome: Not Enough Evidence
Confidence: Not Enough Evidence
Severity: Not Applicable
Applicability: Undetermined
Evidence: Architecture intent, conceptual diagram, planned responsibilities, planned dependency direction, and written policy are available; implementation, dependency, composition, configuration, and execution evidence are unavailable.
Architectural Impact: The risk remains unresolved because the reviewed material cannot prove conformance or violation.
Rationale: Documentation alone cannot establish implemented dependency direction or responsibility placement.
Remediation: Provide structural evidence such as dependency graph, source references, manifests, composition evidence, or implementation excerpts before confirming pass or fail.
Related Rules: TEST-002, TEST-003, TEST-001
Boundary Notes: The result concludes only that evidence is insufficient. It must not become a confirmed Hexagonal, Clean, Layered, DDD, Architecture Testing, or Solution Architecture violation.
```

## 7. Expected Finding Evidence

Required evidence-gap interpretation:

- architecture intent is available;
- conceptual module diagram is available;
- planned responsibilities are available;
- planned dependency direction is available;
- real implementation is unavailable;
- real dependency graph is unavailable;
- composition evidence is unavailable;
- contract implementation evidence is unavailable;
- static or runtime verification evidence is unavailable.

This evidence is nominal and document-only. It is not structural implementation evidence.

## 8. Expected Architectural Impact

The expected impact is unresolved risk rather than confirmed violation.

The documentation may describe a sound intended architecture, but a reviewer cannot rely on intent to conclude implemented conformance or implemented failure.

## 9. Expected Rationale

`SOL-001` is relevant because the reviewed material is solution-level decision and constraint documentation.

The expected outcome is `Not Enough Evidence` because implementation evidence is unavailable. The expected confidence is `Not Enough Evidence` because the material cannot establish applicability or outcome beyond the documented intent.

## 10. Expected Remediation

Expected remediation must be non-corrective and evidence-focused:

- provide dependency graph or module references;
- provide source excerpts for contracts and implementations;
- provide composition evidence;
- provide configuration placement evidence;
- provide architecture validation evidence if it exists.

Expected remediation must not require microservices, DDD adoption, event sourcing, CQRS, a specific framework, a specific persistence technology, cloud, containers, architecture tests, CI/CD, a full architecture migration, or a total rewrite.

## 11. Expected Non-Findings

The observed result must not include confirmed findings for:

- dependency from Core to Infrastructure;
- Hexagonal Architecture violation;
- Clean Architecture violation;
- Layered Architecture violation;
- DDD absence;
- framework leakage;
- persistence inside the domain;
- absence of contracts;
- adoption or absence of microservices;
- absence of architecture tests;
- repository pattern correctness;
- database product choice;
- runtime deployment shape;
- CI/CD absence;
- cloud absence;
- solution redesign need.

## 12. Expected Applicability

Applicability is `Undetermined`.

The document-only scope is relevant to the topic but does not provide enough evidence to determine implemented applicability or conformance for the selected Primary Rule.

## 13. Expected Outcome

Outcome is `Not Enough Evidence`.

The observed result must not issue `Pass`, `Fail`, `Warning`, or `Not Applicable` as the primary conclusion.

## 14. Expected Confidence

Confidence is `Not Enough Evidence`.

The conclusion is constrained by missing structural, behavioral, dependency, composition, and execution evidence.

## 15. Expected Severity

Severity is `Not Applicable`.

No violation finding is expected, so violation severity must not be assigned.

## 16. Expected Evidence Interpretation

Architecture documents, diagrams, planned folder names, and policy statements must be interpreted as intent evidence only.

They may support an unknowns list and evidence request, but they must not support confirmed conformance or confirmed violation without implementation or structural evidence.

Withheld implementation and dependency evidence must drive `Not Enough Evidence`.

## 17. Expected Boundary Behavior

### Core x Solution Architecture

The scenario is a Core scenario, but the Primary Rule remains `SOL-001` because `evaluation/SCENARIO_CATALOG.md` states that no `CORE-*` Rule prefix exists and assigns this scenario to `SOL-001`.

The expected result belongs to `SOL-001`. It is an evidence-insufficiency result about documented intent and missing implementation, not an architectural violation.

### Core x Architecture Testing

Architecture Testing rules may provide boundary context for verification evidence gaps. They must not duplicate the `SOL-001` evidence gap as corrective testing findings when no verification mechanism is provided.

Absence of architecture tests must not produce a finding.

## 18. Expected Deduplication Behavior

Shared evidence is permitted.

The same evidence gap must not appear as multiple findings.

Forbidden duplicate finding patterns include:

- `TEST-002` finding that merely restates missing implementation evidence;
- `TEST-003` finding that merely restates missing structural evidence;
- `TEST-001` finding that treats architecture documentation as a failed fitness function;
- Hexagonal, Clean, Layered, DDD, or Architecture Testing violation based only on the diagram.

## 19. Expected False Positive Protection

The expected result must avoid findings based only on:

- infrastructure in a diagram;
- module names;
- planned folder names;
- incomplete documentation;
- inferred dependency direction;
- documentation-only contract names;
- absence of a formal named architecture style;
- missing implementation material.

Only structural evidence could support a confirmed violation, and none is provided.

## 20. Expected False Negative Protection

The expected result must not approve because:

- the document claims independence;
- boxes are separated in a diagram;
- contracts are mentioned;
- infrastructure is shown outside domain;
- the written policy is coherent;
- no violation evidence is visible.

The risk must remain unresolved and additional evidence must be requested.

## 21. Allowed Result Variations

Allowed variations:

- equivalent wording for insufficient evidence;
- equivalent ordering of evidence gaps;
- equivalent non-corrective request for structural evidence;
- omission of supporting Rule results when they would be decorative;
- a non-corrective observation requesting evidence, if not classified as `Fail`;
- result status `Acceptable Variation` only when it preserves Primary Rule, `Not Enough Evidence`, no confirmed finding, and unresolved risk.

## 22. Disallowed Result Variations

Disallowed variations:

- primary outcome other than `Not Enough Evidence`;
- applicability other than `Undetermined` unless the result still preserves insufficient evidence without confirmed conclusion;
- confidence above `Not Enough Evidence`;
- any confirmed finding;
- severity assigned as if a violation exists;
- finding based only on documentation, names, or diagram boxes;
- duplicate finding;
- nonexistent Rule ID;
- Primary Rule changed away from `SOL-001`;
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
- evidence insufficiency interpretation;
- expected non-findings;
- false-positive guards;
- false-negative guards;
- boundary behavior;
- deduplication behavior;
- remediation proportionality;
- traceability.

Manual comparison is sufficient for this document fixture.

## 24. Acceptance Criteria

The observed result is accepted when:

- `SOL-001` is the Primary Rule result;
- applicability is `Undetermined`;
- outcome is `Not Enough Evidence`;
- confidence is `Not Enough Evidence`;
- severity is `Not Applicable`;
- no confirmed violation finding is present;
- expected non-findings are absent;
- boundary ownership is preserved;
- duplicate findings are absent;
- remediation is evidence-focused and non-corrective;
- result status is `Match` or an allowed variation explicitly classified as acceptable.

## 25. Failure Criteria

The observed result fails when:

- any confirmed finding appears;
- the result is `Pass`, `Fail`, `Warning`, or unsupported `Not Applicable`;
- confidence is upgraded above `Not Enough Evidence`;
- expected non-findings appear as confirmed findings;
- missing evidence is hidden;
- Primary Rule is nonexistent or reassigned away from `SOL-001`;
- remediation is prescriptive beyond the evidence;
- boundary behavior contradicts the scenario.

## 26. Result Status

Expected result status is `Match`.

An observed result may be classified as `Acceptable Variation` only when it stays within the allowed variations and preserves the required architectural conclusion.

## 27. Traceability

| Item | Trace |
| --- | --- |
| Scenario | `evaluation/scenarios/core/EVAL-CORE-003.md` |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Primary Rule normative file | `skill/rules/solution-architecture/SOL-001.md` |
| Supporting Rule | `skill/rules/testing/TEST-002.md` |
| Supporting Rule | `skill/rules/testing/TEST-003.md` |
| Supporting Rule | `skill/rules/testing/TEST-001.md` |
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

Initial expected result for `EVAL-CORE-003`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity, selected Primary Rule `SOL-001`, and expected `Not Enough Evidence` result.

No fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this expected result.
