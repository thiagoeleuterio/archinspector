# EVAL-TEST-001 - Architecture Test Passes Because Its Selection Is Empty

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-TEST-001` |
| Title | `Architecture test passes because its selection is empty` |
| Category | `Architecture Testing` |
| Scenario Type | `False Negative Guard` |
| Catalogs | `Architecture Testing` |
| Primary Rule | `TEST-013` |
| Supporting Rules | `TEST-004`, `TEST-010`, `TEST-005` |
| Catalog Supporting Rules | `TEST-004`, `TEST-010`, `TEST-005` |
| Risk Level | `High` |
| Execution Type | `Executable Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Implementation Order | `31` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/testing/EVAL-TEST-001-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `TEST-013`; catalog coverage for Architecture Testing; `Fail` outcome; `Confirmed` confidence; contextual `High` severity; strong evidence; applicability; false-negative guard; false-positive guard; automated validation; internal boundary `TEST-004` x `TEST-013`; deduplication; remediation. |

## 2. Purpose

This scenario validates that ArchInspector reports a confirmed Architecture Testing failure when an architecture test reports green only because its selector matches no relevant elements.

The scenario protects false-negative detection, empty-scope evidence, naming-selector caution, dependency-rule boundary handling, proportional remediation, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `False Negative Guard` |
| Secondary Types | `Confirmed Violation`, `Automated Validation` |
| Primary Outcome | `Fail` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Confirmed` |
| Severity | `High` |

## 4. Architectural Context

The evaluated system is a fictitious order-processing system with a declared rule that application code must not depend on persistence adapters.

The reviewed scope contains an architecture verification named `ApplicationMustNotReferencePersistence`. The verification is described as executable, returns a green result, and is used as release evidence. Its selector searches for components under `Order.Application.*`, but the current modules are named `Orders.App.*`. The observed matched-element list is empty, while the manifest also includes a seeded violating dependency from `SubmitOrderFlow` to `SqlOrderGateway`.

The architectural condition under test is not evaluated as the primary conclusion. The scenario evaluates the verification mechanism: it lets a relevant violation pass because the selected scope is empty.

## 5. Target Catalogs

`Architecture Testing` owns the scenario because the evaluated condition is the adequacy of an architectural verification mechanism.

No neighboring architecture catalog owns the required finding. A Clean, Layered, Hexagonal, DDD, Fowler, Events, SOLID, Core, or Solution finding would require exclusive evidence about the underlying architecture rather than the empty verification result.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `TEST-013` |
| Title | `Architecture test false-negative control` |
| Category | `Architecture Testing` |
| Status | `Active` |
| Normative File | `skill/rules/testing/TEST-013.md` |
| Catalog File | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |

`TEST-013` is selected because the direct problem is that the verification allows a relevant violation through an empty selector and a green result. `TEST-004` also sees scope evidence, but `TEST-013` owns the false-negative conclusion required by the catalog.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `TEST-004` | Boundary reference for the selected scope being empty and stale. |
| `TEST-010` | Boundary reference for naming-based selector reliability. |
| `TEST-005` | Boundary reference for the intended dependency rule direction without owning the false-negative finding. |

Supporting Rules may explain shared evidence and forbidden duplicate findings. They must not replace `TEST-013` as Primary Rule.

## 8. Input Artifacts

The scenario input is a textual executable-fixture manifest. It describes executable verification evidence without creating executable code.

The manifest includes:

- architectural decision;
- protected dependency rule;
- selector definition;
- matched-element output;
- observed green result;
- seeded violating dependency;
- expected failure condition;
- actual success condition;
- local and pipeline execution notes;
- evidence withheld.

## 9. Directory Structure

```text
order-processing/
  src/
    Orders.App/
      SubmitOrderFlow
    Orders.Persistence/
      SqlOrderGateway
  verification/
    ApplicationMustNotReferencePersistence
```

Directory names are supporting context only. The required finding depends on selector result, execution result, and seeded violation evidence.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `ApplicationMustNotReferencePersistence` | Architecture verification mechanism. | Runs and reports green. |
| `Order.Application.*` selector | Stale scope selector. | Matches zero elements. |
| `Orders.App.SubmitOrderFlow` | Current application component. | Exists outside the stale selector. |
| `Orders.Persistence.SqlOrderGateway` | Persistence adapter. | Referenced by the application component. |
| `VerificationReport` | Execution output. | Shows `matchedElements=0`, `violations=0`, `result=Pass`. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `SubmitOrderFlow` | `SqlOrderGateway` | Direct dependency in seeded violating case | Relevant violation exists inside the intended risk. |
| `ApplicationMustNotReferencePersistence` | `Order.Application.*` | Naming selector | Selector misses current application namespace. |
| `VerificationReport` | empty match list | Execution output | The green result covers no relevant application components. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Define protected dependency rule | Architecture decision or verification manifest | Provided |
| Select current application components | Architecture verification | Stale selector selects none |
| Detect forbidden persistence dependency | Architecture verification | Not detected |
| Interpret green result | Verification report | Misleading because selection is empty |
| Evaluate underlying architecture violation | Neighboring architecture catalog | Not the primary conclusion |

## 13. Execution Flow

1. The verification loads the declared forbidden dependency rule.
2. The verification applies the `Order.Application.*` selector.
3. The selector returns zero matched elements.
4. The assertion evaluates zero dependencies.
5. The verification reports green.
6. The seeded `SubmitOrderFlow` to `SqlOrderGateway` dependency remains undetected.

The failure is in the verification mechanism because a relevant violation passes through an empty selection.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats execution output and selector output as reviewed evidence.
- The evaluator does not assume source code beyond the manifest.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is a confirmed Architecture Testing violation.

The verification is applicable because it claims to detect prohibited architecture dependencies. It fails `TEST-013` because direct execution evidence shows a green result caused by an empty selector while a relevant seeded violation exists.

## 16. Evidence Provided

Strong evidence is provided:

- declared dependency rule: application must not depend on persistence adapters;
- executable verification name and purpose;
- stale selector `Order.Application.*`;
- current component namespace `Orders.App.*`;
- matched element count `0`;
- observed result `Pass`;
- seeded violation from `SubmitOrderFlow` to `SqlOrderGateway`;
- expected failure condition not triggered.

Short non-compilable verification manifest:

```text
verification ApplicationMustNotReferencePersistence
  select components matching "Order.Application.*"
  assert selected components do not reference "Orders.Persistence.*"
  execution:
    matchedElements = 0
    violations = 0
    result = Pass
  seededViolation:
    Orders.App.SubmitOrderFlow -> Orders.Persistence.SqlOrderGateway
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- compilable source code;
- real test project files;
- tool-specific syntax;
- package files;
- full dependency graph;
- complete architecture test suite;
- CI configuration details beyond the observed result;
- all functional tests;
- runtime logs;
- production incidents;
- proof of global architecture conformance or violation.

Withheld evidence prevents conclusions about the whole suite, the whole architecture, functional coverage, or pipeline governance beyond the provided verification.

## 18. Expected Findings

Exactly one corrective finding is required.

```text
Finding ID: EVAL-TEST-001-F001
Rule ID: TEST-013
Title: Architecture verification passes while selecting no application components
Outcome: Fail
Confidence: Confirmed
Severity: High
Applicability: Applicable
Evidence: ApplicationMustNotReferencePersistence runs with selector Order.Application.*, matches zero elements, reports Pass, and misses the seeded SubmitOrderFlow to SqlOrderGateway dependency.
Architectural Impact: The verification creates false assurance that prohibited application-to-persistence dependencies are blocked.
Regression Risk: Relevant architecture regressions can pass undetected whenever namespaces or modules move outside the stale selector.
Enforcement Impact: A green result cannot be trusted as enforcement because the check does not evaluate the intended scope.
Rationale: TEST-013 fail conditions are satisfied by direct evidence of empty scope, green result, and missed relevant violation.
Remediation: Make empty selection fail or be reported explicitly, align selectors with current modules, add a representative negative case, and document intentional narrow scope when it is deliberate.
Related Rules: TEST-004, TEST-010, TEST-005
Boundary Notes: The finding concludes only that the verification permits false negatives. It must not duplicate the underlying dependency violation.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- absence of a specific architecture-testing library;
- absence of a project named `ArchitectureTests`;
- absence of CI/CD;
- lack of unit test coverage;
- lack of integration tests;
- absence of microservices;
- absence of Clean Architecture;
- absence of Hexagonal Architecture;
- absence of DDD;
- the underlying application-to-persistence dependency as a separate architecture finding;
- all dependency rules in the solution;
- all pipeline checks;
- all architecture drift.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `TEST-013` | `Applicable` | `Fail` | `Match` |
| Scenario | `Applicable` | `Fail` | `Match` |

## 21. Expected Confidence

Expected confidence is `Confirmed`.

Direct execution and selector evidence establishes the verification mechanism, selected scope, relevant architectural concern, green result, and missed seeded violation. Naming is only supporting context.

## 22. Expected Severity

Expected severity is `High`.

The verification is used as release evidence for an important dependency boundary and directly permits a known violating path. `Medium` is acceptable only if observed reasoning explicitly narrows the enforcement reliance while preserving `Applicable`, `Fail`, `Confirmed`, and the required finding.

## 23. False Positive Guards

Do not report a finding based only on:

- a deliberately narrow non-empty selector;
- absence of whole-system coverage;
- use of naming selectors when matched elements and negative cases are reliable;
- lack of a specific tool;
- absence of pipeline execution;
- manual verification when proportionate.

The required failure depends on empty selection plus missed relevant violation.

## 24. False Negative Guards

Do not miss the required finding because:

- the verification result is green;
- the test name sounds architectural;
- an architecture-testing tool is installed;
- the selector looks plausible;
- the repository contains a verification folder;
- the dependency rule exists in documentation;
- no tool exception is shown.

## 25. Internal Boundary Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Green verification lets relevant violation pass | `TEST-013` | No | Yes | Emit one `TEST-013` finding. |
| Selected scope is stale or empty | No | `TEST-004` if separately evaluated | Yes | Use as evidence and boundary context. |
| Naming selector is fragile | No | `TEST-010` if separately evaluated | Yes | Mention as supporting evidence only. |
| Dependency rule direction exists | No | `TEST-005` if separately evaluated | Yes | Keep dependency-rule coherence separate. |

## 26. Cross-Catalog Boundary Expectations

### Architecture Testing x Core

Architecture Testing evaluates whether the verification provides effective enforcement evidence. Core may care about false assurance, but no separate Core Rule owns this scenario.

### Architecture Testing x Hexagonal

If the prohibited dependency resembles a port or adapter issue, the underlying Hexagonal condition remains a neighboring conclusion. The `TEST-013` finding must not duplicate it.

### Architecture Testing x Clean

Clean dependency conditions may be the protected architectural rule, but this scenario owns only the verification false negative.

### Architecture Testing x Layered

Layered dependency direction may be the protected property. A Layered finding is forbidden unless exclusive architecture evidence beyond the verification defect is evaluated.

### Architecture Testing x DDD

No DDD semantic or invariant conclusion is supported by the verification evidence.

### Architecture Testing x Events and Messaging

No delivery, idempotency, retry, or messaging contract conclusion is supported.

## 27. Deduplication Expectations

| Shared Evidence | Testing Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Seeded forbidden dependency | Verification missed a relevant violation | Underlying dependency violation may exist | Yes | One `TEST-013` finding only. |
| Empty selector | False-negative risk under `TEST-013` | Scope issue under `TEST-004` | Yes | Use as primary evidence for `TEST-013`; no second finding required. |
| Naming mismatch | Selector fragility supports miss | Naming reliability under `TEST-010` | Yes | Boundary note only unless separate result is required. |

## 28. Expected Remediation

Expected remediation must be proportional and technology-neutral:

- fail or visibly flag empty selections;
- align selectors with current modules;
- add a representative negative case or seeded violation check where useful;
- document intentionally narrow scope;
- avoid demanding exhaustive coverage or a specific test library.

## 29. Allowed Variations

Allowed variations:

- equivalent component names;
- equivalent selector mismatch;
- equivalent wording for the required finding;
- equivalent technology-neutral remediation;
- `Medium` severity with explicit reduced enforcement reliance;
- no supporting findings when they would duplicate the Primary Rule conclusion.

## 30. Disallowed Variations

Disallowed variations:

- Primary Rule changed away from `TEST-013`;
- title different from the catalog;
- category different from the catalog;
- outcome other than `Fail`;
- confidence below `Confirmed`;
- missing required finding;
- finding based only on file or test name;
- duplicate finding for the same verification defect;
- required specific tool, CI product, threshold, or project structure;
- underlying architecture violation reported as the only finding.

## 31. Execution Instructions

Evaluate the textual executable-fixture manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat the described execution output as provided evidence. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/testing/EVAL-TEST-001-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `TEST-013` is evaluated as `Applicable`;
- primary outcome is `Fail`;
- confidence is `Confirmed`;
- severity is `High` unless explicitly reduced to justified `Medium`;
- exactly one required finding appears for empty selection allowing a relevant violation through;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Architecture Testing internal and cross-catalog boundaries are respected;
- duplicate findings are absent;
- remediation is proportional and technology-neutral;
- observed result comparison against `evaluation/expected/testing/EVAL-TEST-001-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- the required finding is missing;
- outcome is `Pass`, `Warning` only, `Not Applicable`, or `Not Enough Evidence`;
- confidence is below `Confirmed`;
- severity contradicts the enforcement impact;
- green execution is accepted as proof despite empty selection;
- a duplicate scope or dependency finding repeats the same conclusion;
- remediation prescribes unrelated tools, pipelines, thresholds, or rewrite;
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
| Input artifacts | Textual executable-fixture manifest in sections 8 through 17 of this scenario. |
| Coverage dimensions | `TEST-013` false-negative coverage; Architecture Testing catalog coverage; `Fail`; `Confirmed`; `High`; strong evidence; applicability; automated validation; false-positive protection; false-negative protection; internal boundary; deduplication; remediation. |
| Primary Rule catalog | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |
| Primary Rule normative file | `skill/rules/testing/TEST-013.md` |
| Supporting Rule | `skill/rules/testing/TEST-004.md` |
| Supporting Rule | `skill/rules/testing/TEST-010.md` |
| Supporting Rule | `skill/rules/testing/TEST-005.md` |
| Architecture Testing catalog review | `skill/reviews/ARCHITECTURE_TESTING_CATALOG_REVIEW.md` |
| Architecture Testing catalog stabilization | `skill/reviews/ARCHITECTURE_TESTING_CATALOG_STABILIZATION.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Gold Standard stabilization | `evaluation/stabilizations/EVAL-CORE-001-STABILIZATION.md` |

## 35. Gold Standard Requirements

This scenario follows the stabilized Gold Standard reference for structure, identity, evidence strength, atomicity, outcomes, confidence, severity, finding specificity, remediation proportionality, expected non-findings, false-positive protection, false-negative protection, boundaries, deduplication, and expected result traceability.

It must not introduce requirements outside the Evaluation Suite models or redefine existing Rules.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-TEST-001`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `TEST-013`, selected Supporting Rules `TEST-004`, `TEST-010`, `TEST-005`, and expected `Fail` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
