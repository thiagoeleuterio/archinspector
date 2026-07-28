# EVAL-CLEAN-004 - Package Names Suggest Layers but Dependency Graph Is Unavailable

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CLEAN-004` |
| Title | `Package names suggest layers but dependency graph is unavailable` |
| Category | `Clean Architecture` |
| Scenario Type | `Insufficient Evidence` |
| Catalogs | `Clean Architecture` |
| Primary Rule | `CLEAN-013` |
| Supporting Rules | `CLEAN-002`, `CLEAN-004`, `CLEAN-005` |
| Risk Level | `Medium` |
| Execution Type | `Document Fixture` |
| Status | `Ready` |
| Priority | `P2` |
| Implementation Order | `14` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/clean/EVAL-CLEAN-004-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `CLEAN-013`; Clean catalog coverage; `Not Enough Evidence` outcome; `Not Enough Evidence` confidence; no-finding severity absence; nominal evidence; undetermined applicability; naming-only evidence guard; partial scope; false-positive protection; false-negative protection; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector does not infer Clean Architecture conformance or violation from package names alone when the dependency graph and implementation evidence are unavailable.

The scenario protects insufficient-evidence handling, naming-versus-structure distinction, false-positive control, false-negative control, boundary behavior, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Insufficient Evidence` |
| Secondary Types | `Partial Scope`, `False Negative Guard` |
| Primary Outcome | `Not Enough Evidence` |
| Evidence Strength | `Nominal` |
| Applicability | `Undetermined` |
| Confidence | `Not Enough Evidence` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious order-processing system described only through package names and a short architecture note.

The reviewed scope contains names such as `entities`, `usecases`, `adapters`, and `frameworks`, plus a document saying the team intends to follow Clean Architecture. No dependency graph, imports, source excerpts, module references, boundary contracts, type signatures, responsibility inventory from implementation, or behavior evidence is available.

The names are plausible but cannot prove that use cases and business policies are visible as primary structural concerns. They also cannot prove that policies are hidden. The correct result keeps the architecture question unresolved.

The description is technology-neutral. The scenario does not require any programming language, framework, database product, runtime, container, or executable fixture.

## 5. Target Catalogs

`Clean Architecture` owns the scenario category because the evaluated condition is whether architecture reveals use cases and business policies through more than naming alone.

No additional primary catalog is needed. Related Clean rules may explain the missing dependency, use case, and entity evidence, but they must not convert names into confirmed findings.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `CLEAN-013` |
| Title | `Architecture must reveal use cases and business policies` |
| Category | `Clean Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/clean/CLEAN-013.md` |
| Catalog File | `skill/rules/CA_CATALOG.md` |

`CLEAN-013` is selected because it directly evaluates whether use cases and business policies are visible as primary architectural concerns through structure, boundaries, dependencies, contracts, or behavior placement, not through naming alone.

`CLEAN-002`, `CLEAN-004`, and `CLEAN-005` are supporting rules because their dependency, use case, and entity evidence would be needed to strengthen or refute the visibility claim, but that evidence is unavailable in this scenario.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `CLEAN-002` | Boundary reference for missing source dependency direction evidence. |
| `CLEAN-004` | Boundary reference for missing use case isolation evidence. |
| `CLEAN-005` | Boundary reference for missing entity dependency evidence. |

Supporting Rules may be used to explain evidence gaps and expected non-findings. They must not turn package names into confirmed Clean Architecture conclusions.

## 8. Input Artifacts

The scenario input is a textual document fixture. It is not executable and must not be treated as compilable code.

The document fixture includes:

- package-name list;
- short architecture intent note;
- planned package responsibilities;
- stated dependency policy;
- explicit absence of implementation evidence;
- explicit absence of dependency graph.

## 9. Directory Structure

```text
planned-order-processing/
  entities/      (name only)
  usecases/      (name only)
  adapters/      (name only)
  frameworks/    (name only)
```

The directory names are nominal evidence only. They are not proof of implemented Clean Architecture boundaries, dependency direction, use case visibility, or policy placement.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `entities` package | Claimed enterprise policy location. | Package name only. |
| `usecases` package | Claimed application policy location. | Package name only. |
| `adapters` package | Claimed adapter location. | Package name only. |
| `frameworks` package | Claimed technical detail location. | Package name only. |
| `Architecture Note` | Stated intent. | Says dependencies should point inward, but provides no structural evidence. |

No concrete type, method signature, dependency, import, implementation, behavior, or boundary contract is provided.

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `usecases` | `entities` | Claimed intended dependency | Documentation-only statement. |
| `adapters` | `usecases` | Claimed intended dependency | Documentation-only statement. |
| `frameworks` | `adapters` | Claimed intended dependency | Documentation-only statement. |
| package names | package names | Naming heuristic | Nominal evidence only. |

No real dependency graph, source dependency, import list, project reference, package reference, constructor dependency, method signature, or code excerpt is provided.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Reveal use cases as primary concerns | Architecture structure | Claimed by package name only |
| Reveal business policies as primary concerns | Architecture structure | Claimed by package name only |
| Show policy-to-detail dependency direction | Dependency evidence | Not provided |
| Show use case isolation | Structural and behavioral evidence | Not provided |
| Show entity independence | Structural dependency evidence | Not provided |
| Prove technical mechanisms are secondary | Structural and behavioral evidence | Not provided |

## 13. Execution Flow

1. The document lists packages named `entities`, `usecases`, `adapters`, and `frameworks`.
2. The document states that dependencies should point inward.
3. The document does not provide actual dependency relationships.
4. The document does not provide type signatures, contracts, implementation behavior, or composition evidence.

The flow is naming and intent evidence only. It cannot confirm pass or fail because structural and dependency evidence is unavailable.

## 14. Preconditions

- The evaluator receives the document fixture as the complete scenario input.
- The evaluator treats the document as reviewed material for document-based evaluation.
- The evaluator does not assume implementation files, dependency graphs, tests, runtime behavior, or hidden manifests.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is insufficient evidence.

The package names suggest Clean Architecture intent, but no reviewed material proves that use cases and business policies are visible through structure, boundaries, dependencies, contracts, or behavior placement. The correct result keeps both conformance and violation unconfirmed.

## 16. Evidence Provided

Nominal evidence is provided:

- package names resembling Clean Architecture roles;
- short architecture intent note;
- planned responsibility labels;
- intended dependency policy;
- no implementation structure beyond names;
- no dependency graph.

Short non-compilable documentation excerpt:

```text
Architecture intent:
  packages: entities, usecases, adapters, frameworks
  dependency policy: dependencies should point inward
  implementation dependency graph: unavailable
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- real source files;
- type definitions;
- use case signatures;
- entity implementations;
- adapter implementations;
- framework integration code;
- imports;
- references;
- dependency graph;
- package files;
- composition evidence;
- source excerpts;
- execution output;
- static analysis output;
- automated test outputs;
- runtime logs.

Withheld evidence prevents confirmed findings about use case visibility, policy visibility, dependency direction, use case isolation, entity independence, framework leakage, Layered bypass, Hexagonal ports, or DDD model quality.

## 18. Expected Findings

No confirmed violation finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: CLEAN-013
Outcome: Not Enough Evidence
Confidence: Not Enough Evidence
Severity: Not Applicable
Applicability: Undetermined
Evidence: Package names and architecture intent are available; structural, dependency, contract, signature, behavior, composition, implementation, test, and static analysis evidence are unavailable.
Architectural Impact: The risk remains unresolved because naming alone cannot prove that use cases and business policies are visible or hidden as architectural concerns.
Rationale: CLEAN-013 requires more than names or stated intent to confirm pass or fail.
Remediation: Provide dependency graph, module references, use case contracts, policy-facing structure, implementation excerpts, or other structural evidence before confirming conformance or violation.
Related Rules: CLEAN-002, CLEAN-004, CLEAN-005
Boundary Notes: The result concludes only that evidence is insufficient. It must not become a confirmed Clean, Hexagonal, Core, Layered, or DDD finding.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- Clean Architecture conformance;
- Clean Architecture violation;
- dependency rule violation;
- use case isolation violation;
- entity independence violation;
- framework leakage;
- absence of DDD;
- absence of Hexagonal Architecture formalism;
- absence of Layered Architecture formalism;
- absence of microservices;
- absence of architecture tests;
- absence of Domain Events;
- absence of messaging;
- package names `entities`, `usecases`, `adapters`, or `frameworks`;
- monolithic deployment;
- directory naming style;
- lack of formal Clean Architecture circles.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `CLEAN-013` | `Undetermined` | `Not Enough Evidence` | `Match` |
| Scenario | `Undetermined` | `Not Enough Evidence` | `Match` |

## 21. Expected Confidence

Expected confidence is `Not Enough Evidence`.

The available material is naming-only and documentation-only. It can identify possible architectural intent but cannot establish structure, boundaries, dependencies, contracts, or behavior placement.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No violation finding is confirmed, so no violation severity is assigned. The scenario risk level remains `Medium` as catalog coverage context, not as finding severity.

## 23. False Positive Guards

Do not:

- fail because dependency evidence is missing;
- fail based on package names;
- fail because names look conventional or unconventional;
- infer that implementation violates Clean Architecture;
- treat missing graph as proof of wrong dependency direction;
- require formal Clean Architecture circles, folders, or project splits;
- convert absence of evidence into violation.

Naming and documentation incompleteness must remain insufficient evidence, not confirmed violation.

## 24. False Negative Guards

Do not approve because:

- packages are named `entities`, `usecases`, `adapters`, or `frameworks`;
- documentation says dependencies point inward;
- a diagram or note sounds coherent;
- no violation evidence is visible;
- folder names look like Clean Architecture;
- a monolith can still use Clean Architecture.

The observed result must request structural evidence and keep risk unresolved.

## 25. Internal Boundary Expectations

`CLEAN-013` owns the primary result because the evaluated concern is architectural visibility of use cases and business policies.

Related Clean rules may share evidence gaps but must keep separate responsibilities:

- `CLEAN-002` would require source dependency direction evidence;
- `CLEAN-004` would require use case isolation evidence;
- `CLEAN-005` would require entity dependency evidence;
- `CLEAN-001` would require framework type crossing evidence.

No Clean violation or pass is confirmed.

## 26. Cross-Catalog Boundary Expectations

### Clean x Core

Clean Architecture owns the insufficient-evidence result for `CLEAN-013`. Core review behavior validates evidence-before-conclusion and unresolved-risk handling.

No generic Core finding is allowed for the same evidence gap.

### Clean x Hexagonal Architecture

Hexagonal Architecture evaluates ports, adapters, inside/outside dependency direction, and core isolation. Package names resembling adapters or frameworks do not prove Hexagonal conformance or violation.

Absence of formal Hexagonal Architecture does not constitute a Clean violation.

### Clean x Layered Architecture

Layered Architecture evaluates declared layers and dependency behavior in a layered structure. Names that resemble layers do not prove layered dependency direction, bypass, or responsibility placement.

Absence of named layers or Clean circles does not constitute a Layered violation.

## 27. Deduplication Expectations

| Shared Evidence | Clean Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Package names suggest Clean roles | Evidence insufficient for `CLEAN-013` | Layered or Hexagonal conformance may be suspected | Yes | Return `Not Enough Evidence`; no confirmed finding. |
| Documentation says dependencies point inward | Intent only | Dependency Rule pass may be suspected | Yes | Do not approve without dependency graph. |
| Dependency graph unavailable | Evidence gap | Dependency violation may be suspected | Yes | Do not convert missing evidence into `Fail`. |
| No implementation provided | Evidence gap | DDD or architecture-test finding may be suspected | Yes | No neighboring finding. |

## 28. Expected Remediation

No corrective remediation is expected because no violation is confirmed.

Observed output may include a non-corrective evidence request:

- provide dependency graph or module references;
- provide representative use case and entity source excerpts;
- provide boundary contracts and type signatures;
- provide adapter and framework integration excerpts;
- provide composition evidence;
- provide static analysis or architecture-test output if available.

The remediation must not prescribe microservices, DDD, Clean Architecture adoption, Hexagonal formalism, architecture tests, CI/CD, a tool, a framework, folder names, project splits, or a rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial differences in wording;
- equivalent ordering of evidence gaps;
- equivalent non-corrective request for structural evidence;
- observation classified separately as non-corrective if the model distinguishes observations from findings;
- supporting Rule omission when it would be decorative;
- result status `Acceptable Variation` only when it preserves `Not Enough Evidence`, no confirmed finding, and unresolved risk.

## 30. Disallowed Variations

Disallowed variations:

- `Pass Confirmed`;
- `Fail Confirmed`;
- `Warning` as the primary result;
- confidence other than `Not Enough Evidence`;
- any confirmed violation finding;
- any confirmed compliance conclusion;
- severity assigned as if a violation exists;
- finding based only on documentation, names, or diagram boxes;
- duplicate finding;
- nonexistent Rule ID;
- non-Clean Primary Rule;
- remediation requiring unrelated redesign, tooling, platform, formal architecture, or total rewrite.

## 31. Execution Instructions

Evaluate the document fixture statically.

Do not compile, run, generate, or infer executable fixture code. Treat the documentation excerpt as non-compilable evidence of intent only. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/clean/EVAL-CLEAN-004-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `CLEAN-013` is evaluated as `Undetermined`;
- primary outcome is `Not Enough Evidence`;
- confidence is `Not Enough Evidence`;
- severity is `Not Applicable`;
- no confirmed violation finding appears;
- no confirmed compliance conclusion appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- internal Clean boundaries are respected;
- Clean x Core, Clean x Hexagonal, and Clean x Layered boundaries are respected;
- duplicate findings are absent;
- evidence request is proportional and non-corrective;
- observed result comparison against `evaluation/expected/clean/EVAL-CLEAN-004-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- a confirmed violation finding appears;
- outcome is `Pass`, `Fail`, `Warning`, or `Not Applicable`;
- confidence is upgraded above `Not Enough Evidence`;
- severity is assigned despite no confirmed finding;
- names are treated as implementation proof;
- missing evidence is hidden;
- a duplicate Clean, Hexagonal, Core, Layered, or DDD finding repeats the same evidence gap;
- remediation prescribes unrelated architecture, technology, tooling, or rewrite;
- a nonexistent Rule is used;
- existing Rules or catalogs are redefined.

## 34. Traceability

| Item | Trace |
| --- | --- |
| Scenario catalog | `evaluation/SCENARIO_CATALOG.md` |
| Scenario model | `evaluation/SCENARIO_MODEL.md` |
| Expected result model | `evaluation/EXPECTED_RESULT_MODEL.md` |
| Coverage model | `evaluation/COVERAGE_MODEL.md` |
| Evaluation suite | `evaluation/EVALUATION_SUITE.md` |
| Input artifacts | Document fixture in sections 8 through 17 of this scenario. |
| Coverage dimensions | `CLEAN-013` insufficient-evidence coverage; Clean catalog coverage; `Not Enough Evidence`; `Not Enough Evidence` confidence; no-finding severity absence; nominal evidence; undetermined applicability; naming-only false-positive protection; false-negative protection; partial scope; internal Clean boundary; Clean x Core boundary; Clean x Hexagonal boundary; Clean x Layered boundary; deduplication. |
| Primary Rule catalog | `skill/rules/CA_CATALOG.md` |
| Primary Rule normative file | `skill/rules/clean/CLEAN-013.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-002.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-004.md` |
| Supporting Rule | `skill/rules/clean/CLEAN-005.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Layered boundary review | `skill/reviews/LAYER_CATALOG_REVIEW.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Gold Standard stabilization | `evaluation/stabilizations/EVAL-CORE-001-STABILIZATION.md` |

## 35. Gold Standard Requirements

This scenario follows the stabilized Gold Standard reference for:

- structure;
- identity;
- level of detail;
- evidence strength;
- atomicity;
- outcomes;
- confidence;
- severity;
- finding specificity;
- remediation proportionality;
- expected non-findings;
- false-positive protection;
- false-negative protection;
- cross-catalog boundaries;
- deduplication;
- expected result traceability.

It must not introduce requirements outside the Evaluation Suite models or redefine existing Rules.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-CLEAN-004`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `CLEAN-013`, selected Supporting Rules, and expected `Not Enough Evidence` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
