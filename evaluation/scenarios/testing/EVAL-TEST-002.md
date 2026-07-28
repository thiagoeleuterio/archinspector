# EVAL-TEST-002 - Architecture Test Detects a Forbidden Dependency With Actionable Diagnostics

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-TEST-002` |
| Title | `Architecture test detects a forbidden dependency with actionable diagnostics` |
| Category | `Architecture Testing` |
| Scenario Type | `Positive Compliance` |
| Catalogs | `Architecture Testing` |
| Primary Rule | `TEST-015` |
| Supporting Rules | `TEST-005`, `TEST-006`, `TEST-018` |
| Catalog Supporting Rules | `TEST-005`, `TEST-006`, `TEST-004`, `TEST-018` |
| Risk Level | `Medium` |
| Execution Type | `Executable Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Implementation Order | `32` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/testing/EVAL-TEST-002-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `TEST-015`; catalog coverage for Architecture Testing; `Pass` outcome; expected `Likely` confidence; contextual absence of severity; strong evidence; applicability; automated validation; report consistency; false-positive guard; false-negative guard; Clean x Architecture Testing boundary; diagnostics; deduplication. |

## 2. Purpose

This scenario validates that ArchInspector recognizes an architecture verification that detects a forbidden dependency and reports enough diagnostic context to act.

The scenario protects positive compliance, diagnostic quality, tool-output caution, boundary ownership, and no unsupported conclusion about the underlying architecture beyond the tested scope.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Positive Compliance` |
| Secondary Types | `Automated Validation`, `Report Consistency` |
| Primary Outcome | `Pass` |
| Evidence Strength | `Strong` |
| Applicability | `Applicable` |
| Confidence | `Likely` |
| Severity | `Not Applicable` |

## 4. Architectural Context

The evaluated system is a fictitious order-processing system with a declared constraint that application components must not directly depend on persistence adapters.

The reviewed scope contains an executable architecture verification that selects current application components, evaluates dependencies against persistence adapters, is run locally and in the documented verification step, and includes a seeded failing case. The failure output names the violated constraint, source component, target component, dependency kind, and concise repair direction.

The scenario does not conclude that the full architecture is correct. It concludes only that the failure diagnostics of the provided verification are adequate for the reviewed risk.

## 5. Target Catalogs

`Architecture Testing` owns the scenario because the evaluated condition is failure diagnostic quality in an architectural verification mechanism.

`Clean Architecture` is a boundary reference through the catalog coverage matrix because the protected dependency condition may resemble Clean dependency constraints. The scenario must not convert tool output into proof of the underlying Clean Architecture beyond the tested dependency scope.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `TEST-015` |
| Title | `Architecture test failure diagnostics` |
| Category | `Architecture Testing` |
| Status | `Active` |
| Normative File | `skill/rules/testing/TEST-015.md` |
| Catalog File | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |

`TEST-015` is selected because the cataloged scenario is specifically about actionable diagnostics when a forbidden dependency is detected. `TEST-005`, `TEST-006`, and `TEST-018` are supporting because dependency-rule coherence, forbidden-dependency detection, and execution context are relevant but not primary.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `TEST-005` | Boundary reference for dependency rule origin, destination, and direction. |
| `TEST-006` | Boundary reference for reliable forbidden dependency detection. |
| `TEST-018` | Boundary reference for execution evidence without making pipeline execution the primary conclusion. |

`TEST-004` is cataloged as related support but is not selected as an operative supporting rule because concrete scenarios use a maximum of three supporting rules.

## 8. Input Artifacts

The scenario input is a textual executable-fixture manifest. It describes verification and output evidence without creating executable code.

The manifest includes:

- architectural decision;
- forbidden dependency rule;
- selected scope;
- verification result;
- failure diagnostics;
- local execution;
- documented delivery execution;
- evidence withheld.

## 9. Directory Structure

```text
order-processing/
  src/
    Orders.Application/
      SubmitOrderFlow
    Orders.Persistence/
      SqlOrderGateway
  verification/
    NoApplicationToPersistenceDependency
    verification-output
```

Directory names are supporting context only. The expected pass depends on diagnostic output and verification evidence.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `NoApplicationToPersistenceDependency` | Architecture verification. | Defines the forbidden dependency rule and assertion. |
| `SubmitOrderFlow` | Source component in failing case. | Reported as the violating source. |
| `SqlOrderGateway` | Target persistence adapter. | Reported as the forbidden target. |
| `VerificationOutput` | Failure report. | Includes constraint, source, target, dependency kind, and action. |
| `VerificationStep` | Execution evidence. | Shows the verification is run in the documented verification command. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `NoApplicationToPersistenceDependency` | application selector | Selection logic | Selects current application components. |
| `NoApplicationToPersistenceDependency` | persistence selector | Target logic | Identifies forbidden persistence adapters. |
| `SubmitOrderFlow` | `SqlOrderGateway` | Seeded direct dependency | Produces a diagnostic failure. |
| `VerificationOutput` | failure report | Diagnostic evidence | Provides actionable context. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Define forbidden dependency direction | Verification mechanism | Provided |
| Detect representative forbidden dependency | Verification mechanism | Provided |
| Explain violated constraint | Failure output | Provided |
| Identify involved elements | Failure output | Provided |
| Define required action | Failure output | Provided proportionately |
| Prove underlying architecture globally | Not expected | Not claimed |

## 13. Execution Flow

1. The verification selects `Orders.Application.*`.
2. The verification evaluates references to `Orders.Persistence.*`.
3. A seeded `SubmitOrderFlow` to `SqlOrderGateway` dependency is detected.
4. The verification fails.
5. The failure output names the rule, source, target, dependency kind, and repair direction.
6. The output is retained in the verification report.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats described execution and diagnostic output as reviewed evidence.
- The evaluator does not infer full architecture conformance from one verification.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is positive compliance for diagnostic quality.

The verification has a failure mode and the provided output is actionable enough for the reviewed risk. No corrective finding is expected under `TEST-015`.

## 16. Evidence Provided

Strong evidence is provided:

- explicit violated constraint name;
- selected source and target scopes;
- detected dependency from `SubmitOrderFlow` to `SqlOrderGateway`;
- failure status;
- failure output naming source and target;
- dependency kind;
- concise remediation direction;
- retained report output;
- documented local and delivery verification step.

Short non-compilable verification output:

```text
verification NoApplicationToPersistenceDependency
  result = Fail
  violatedConstraint = Application components must not reference persistence adapters
  source = Orders.Application.SubmitOrderFlow
  target = Orders.Persistence.SqlOrderGateway
  dependencyKind = Direct reference
  action = Replace concrete adapter dependency with application-owned boundary contract
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- compilable source code;
- real test project files;
- tool-specific syntax;
- full dependency graph;
- all architecture verification results;
- full CI provider configuration;
- production runtime logs;
- functional test coverage;
- proof of whole-system Clean, Hexagonal, Layered, or DDD conformance.

Withheld evidence prevents overclaiming global architecture quality, global dependency coverage, complete suite health, or pipeline governance beyond the provided check.

## 18. Expected Findings

No corrective finding is expected.

```text
Expected Finding Count: 0
Expected Corrective Finding: None
Rule ID: TEST-015
Outcome: Pass
Confidence: Likely
Severity: Not Applicable
Applicability: Applicable
Evidence: The verification failure output names the violated constraint, source component, target component, dependency kind, result, retained report, and proportionate repair direction.
Architectural Impact: No corrective diagnostic impact is present because the failure can be understood and acted on within the reviewed scope.
Regression Risk: Diagnostics are strong enough to reduce misfix or ignored-failure risk for the demonstrated dependency rule.
Enforcement Impact: Failure output supports the enforcement mechanism but does not prove full architecture conformance.
Rationale: TEST-015 pass conditions are satisfied by actionable failure diagnostics for the reviewed forbidden dependency check.
Remediation: None. Preserve the diagnostic fields and result retention as the verification evolves.
Related Rules: TEST-005, TEST-006, TEST-018
Boundary Notes: The result concludes only diagnostic adequacy. It must not become a global pass for the underlying architecture.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- underlying architecture conformance or violation beyond the seeded case;
- absence of a specific testing library;
- absence of a project named `ArchitectureTests`;
- absence of full pipeline enforcement;
- lack of unit test coverage;
- lack of integration tests;
- absence of Clean Architecture;
- absence of Hexagonal Architecture;
- absence of DDD;
- monolithic deployment;
- incomplete whole-system architecture-test coverage;
- perfect diagnostic detail beyond the reviewed risk.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `TEST-015` | `Applicable` | `Pass` | `Match` |
| Scenario | `Applicable` | `Pass` | `Match` |

## 21. Expected Confidence

Expected confidence is `Likely`.

The diagnostic output is direct and strong for the demonstrated check, but the fixture is textual and does not provide the complete executable project or full retained artifact history.

## 22. Expected Severity

Expected severity is `Not Applicable`.

No corrective finding is expected. The catalog risk level remains `Medium` as coverage context, not finding severity.

## 23. False Positive Guards

Do not report a finding based only on:

- missing perfect diagnostic detail;
- lack of a named tool;
- lack of full suite output;
- lack of complete CI provider configuration;
- a concise remediation message;
- detection of a real failure.

## 24. False Negative Guards

Do not pass diagnostics if:

- the output says only `architecture test failed`;
- source and target elements are missing;
- the violated constraint is unnamed;
- output is discarded;
- the failure cannot be mapped to an action;
- the result is green despite the seeded dependency.

## 25. Internal Boundary Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Failure output is actionable | `TEST-015` | No | Yes | Return `Pass` for diagnostic quality. |
| Dependency rule direction is coherent | No | `TEST-005` if separately evaluated | Yes | Supporting boundary only. |
| Forbidden dependency can be detected | No | `TEST-006` if separately evaluated | Yes | Supporting boundary only. |
| Verification runs in delivery flow | No | `TEST-018` if separately evaluated | Yes | Use as context, not primary conclusion. |

## 26. Cross-Catalog Boundary Expectations

### Architecture Testing x Clean

Clean may own the dependency rule being protected, but this scenario evaluates only diagnostic adequacy of the verification. Tool output must not prove Clean Architecture globally.

### Architecture Testing x Hexagonal

Ports or adapters may be the underlying protected property in another scenario. They are not primary here.

### Architecture Testing x Layered

Layer dependency rules may be verified by similar checks, but this scenario owns only failure diagnostics.

### Architecture Testing x Core

Core evidence discipline requires limiting the conclusion to reviewed output and avoiding global pass language.

### Architecture Testing x DDD

No DDD semantic or invariant conclusion is supported.

### Architecture Testing x Events and Messaging

No messaging delivery or contract conclusion is supported.

## 27. Deduplication Expectations

| Shared Evidence | Testing Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Detected forbidden dependency | Diagnostics are actionable under `TEST-015` | Underlying dependency may belong elsewhere | Yes | No underlying architecture finding required. |
| Verification execution result | Supports diagnostic evidence | Pipeline execution may be relevant | Yes | Do not duplicate as `TEST-018` unless execution timing is separately evaluated. |
| Failure message remediation | Diagnostic pass | Architecture remediation may be suspected | Yes | Keep remediation non-corrective for `TEST-015`. |

## 28. Expected Remediation

No corrective remediation is expected.

Observed output may recommend preserving:

- violated constraint name;
- source and target elements;
- dependency kind;
- retained failure report;
- concise action guidance.

It must not prescribe a specific tool, CI product, threshold, full suite redesign, or architecture rewrite.

## 29. Allowed Variations

Allowed variations:

- equivalent diagnostic wording;
- equivalent source and target names;
- `Confirmed` confidence if the observed result treats the textual execution evidence as fully direct;
- supporting Rule omission when decorative;
- result status `Acceptable Variation` only when `Pass`, no finding, and `TEST-015` ownership remain.

## 30. Disallowed Variations

Disallowed variations:

- Primary Rule changed away from `TEST-015`;
- outcome other than `Pass`;
- any corrective finding for diagnostic quality;
- severity assigned as a violation;
- finding based only on missing perfect diagnostics;
- global architecture pass inferred from one check;
- required specific architecture-test library, CI system, or report format;
- nonexistent Rule ID.

## 31. Execution Instructions

Evaluate the textual executable-fixture manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat the described failure output as provided evidence. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/testing/EVAL-TEST-002-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `TEST-015` is evaluated as `Applicable`;
- primary outcome is `Pass`;
- confidence is `Likely` or accepted stronger confidence;
- severity is `Not Applicable`;
- no corrective finding appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Architecture Testing internal and cross-catalog boundaries are respected;
- duplicate findings are absent;
- remediation is absent or non-corrective;
- observed result comparison against `evaluation/expected/testing/EVAL-TEST-002-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- a corrective diagnostic finding appears;
- outcome is `Fail`, `Warning`, `Not Applicable`, or `Not Enough Evidence`;
- confidence contradicts the provided diagnostic evidence;
- severity is assigned despite no finding;
- output is treated as proof of global architecture conformance;
- expected non-findings appear;
- duplicate supporting findings repeat the diagnostic conclusion;
- remediation prescribes unrelated tools, platforms, thresholds, or rewrite;
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
| Coverage dimensions | `TEST-015` positive compliance coverage; Architecture Testing catalog coverage; `Pass`; expected `Likely`; no-finding severity absence; strong evidence; applicability; automated validation; report consistency; false-positive protection; false-negative protection; Clean x Architecture Testing boundary; deduplication. |
| Primary Rule catalog | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |
| Primary Rule normative file | `skill/rules/testing/TEST-015.md` |
| Supporting Rule | `skill/rules/testing/TEST-005.md` |
| Supporting Rule | `skill/rules/testing/TEST-006.md` |
| Supporting Rule | `skill/rules/testing/TEST-018.md` |
| Cataloged supporting Rule | `skill/rules/testing/TEST-004.md` |
| Architecture Testing catalog review | `skill/reviews/ARCHITECTURE_TESTING_CATALOG_REVIEW.md` |
| Architecture Testing catalog stabilization | `skill/reviews/ARCHITECTURE_TESTING_CATALOG_STABILIZATION.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Gold Standard stabilization | `evaluation/stabilizations/EVAL-CORE-001-STABILIZATION.md` |

## 35. Gold Standard Requirements

This scenario follows the stabilized Gold Standard reference for structure, identity, evidence interpretation, applicability, outcome, confidence, severity, required finding behavior, atomicity, remediation, expected non-findings, false-positive protection, false-negative protection, boundaries, deduplication, and traceability.

It must not introduce requirements outside the Evaluation Suite models or redefine existing Rules.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-TEST-002`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `TEST-015`, selected Supporting Rules `TEST-005`, `TEST-006`, `TEST-018`, and expected `Pass` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
