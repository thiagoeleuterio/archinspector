# EVAL-TEST-004 - Architecture Rule Exists but Is Never Executed

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-TEST-004` |
| Title | `Architecture rule exists but is never executed` |
| Category | `Architecture Testing` |
| Scenario Type | `False Negative Guard` |
| Catalogs | `Architecture Testing` |
| Primary Rule | `TEST-018` |
| Supporting Rules | `TEST-001`, `TEST-002`, `TEST-014` |
| Catalog Supporting Rules | `TEST-001`, `TEST-002`, `TEST-014`, `TEST-017`, `TEST-020` |
| Risk Level | `Medium` |
| Execution Type | `Mixed Fixture` |
| Status | `Ready` |
| Priority | `P1` |
| Implementation Order | `34` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/testing/EVAL-TEST-004-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `TEST-018`; catalog coverage for Architecture Testing; `Warning` outcome; `Possible` confidence; contextual `Medium` severity; contradictory evidence; applicability; manual validation; automated validation; partial scope; false-positive guard; false-negative guard; deduplication; proportional remediation. |

## 2. Purpose

This scenario validates that ArchInspector reports a warning when an architecture verification exists and is relevant, but available evidence shows it is never executed in any meaningful local, review, or delivery flow.

The scenario protects against accepting dormant checks as effective verification while avoiding a universal requirement that every architecture check run in every pipeline.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `False Negative Guard` |
| Secondary Types | `Manual Validation`, `Automated Validation`, `Partial Scope` |
| Primary Outcome | `Warning` |
| Evidence Strength | `Contradictory` |
| Applicability | `Applicable` |
| Confidence | `Possible` |
| Severity | `Medium` |

## 4. Architectural Context

The evaluated system is a fictitious claims-processing system with a declared architecture rule that inbound adapters must not call persistence modules directly.

The reviewed scope contains a documented architecture verification named `NoInboundToPersistenceRule`, a clear architectural decision, and a test-like definition. However, the local verification command excludes the rule group, the delivery pipeline invokes only functional tests, and the manual review checklist does not reference the rule. A README still states that architecture checks exist, producing contradictory evidence: the rule exists, but execution is not demonstrated where regressions could be caught.

The expected result is a warning, not an automatic failure, because the scenario does not prove critical release reliance or confirmed missed regression. It also is not a pass, because the provided evidence does not show meaningful execution.

## 5. Target Catalogs

`Architecture Testing` owns the scenario because the evaluated condition is execution timing and context of an architectural verification.

Neighboring catalogs may own the underlying inbound-to-persistence rule. This scenario concludes only on whether the verification runs proportionately to the demonstrated risk.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `TEST-018` |
| Title | `Architecture test pipeline execution` |
| Category | `Architecture Testing` |
| Status | `Active` |
| Normative File | `skill/rules/testing/TEST-018.md` |
| Catalog File | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |

`TEST-018` is selected because the direct issue is that a relevant architecture verification exists but is not run at a meaningful feedback point. `TEST-001`, `TEST-002`, and `TEST-014` are supporting boundaries for definition, traceability, and determinism.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `TEST-001` | Boundary reference for the verification being defined as an architectural control. |
| `TEST-002` | Boundary reference for traceability to the adapter-to-persistence decision. |
| `TEST-014` | Boundary reference for determinism, which cannot substitute for missing execution. |

`TEST-017` and `TEST-020` are cataloged as related support but are not selected as operative supporting rules because concrete scenarios use a maximum of three supporting rules.

## 8. Input Artifacts

The scenario input is a textual mixed-fixture manifest. It is not executable and must not be treated as compilable code.

The manifest includes:

- architecture rule definition;
- decision trace;
- local command description;
- pipeline step description;
- manual review checklist excerpt;
- contradictory README claim;
- execution evidence gap;
- evidence withheld.

## 9. Directory Structure

```text
claims-processing/
  docs/
    architecture-decisions
    review-checklist
  verification/
    NoInboundToPersistenceRule
  delivery/
    pipeline-summary
```

Directory names are supporting context only. The warning depends on execution and exclusion evidence.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `NoInboundToPersistenceRule` | Architecture verification definition. | Exists and is traceable to a decision. |
| `LocalVerificationCommand` | Local execution path. | Excludes architecture rule group. |
| `DeliveryPipelineSummary` | Delivery-flow evidence. | Runs functional tests only. |
| `ReviewChecklist` | Manual validation path. | Does not include the architecture rule. |
| `ArchitectureReadme` | Contradictory documentation. | States architecture checks exist without execution proof. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `NoInboundToPersistenceRule` | adapter-to-persistence decision | Decision trace | The verification is architecturally relevant. |
| `LocalVerificationCommand` | architecture rule group | Exclusion | Local execution does not run the rule. |
| `DeliveryPipelineSummary` | functional test suite | Pipeline execution | Pipeline evidence omits architecture verification. |
| `ReviewChecklist` | architecture rule | Manual review omission | Manual path does not compensate for missing execution. |

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Define architecture rule | Architecture verification | Provided |
| Trace rule to decision | Decision documentation | Provided |
| Execute verification locally or in review | Local command or review process | Not demonstrated |
| Execute verification in delivery flow when proportionate | Delivery flow | Not demonstrated |
| Retain result | Execution mechanism | Not provided |
| Prove underlying architecture violation | Neighboring catalog | Not provided |

## 13. Execution Flow

1. The architecture decision defines an adapter-to-persistence dependency constraint.
2. `NoInboundToPersistenceRule` is documented as the verification.
3. The local command runs non-architecture checks and excludes the rule group.
4. The pipeline summary runs functional tests only.
5. The manual review checklist omits the architecture rule.
6. No retained execution result for the architecture rule is provided.

The risk is a dormant verification that may create false confidence but is not proven to have missed a specific release regression.

## 14. Preconditions

- The evaluator receives the mixed textual fixture as the complete scenario input.
- The evaluator treats contradictory documentation and execution summaries as reviewed evidence.
- The evaluator does not infer hidden execution.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is a warning condition.

The verification exists and is architecturally relevant, so `TEST-018` is applicable. Evidence of execution is contradictory and weak: the rule is documented, but local, pipeline, and manual paths do not run it. This supports `Warning` rather than `Pass` or confirmed `Fail`.

## 16. Evidence Provided

Contradictory evidence is provided:

- architecture verification exists;
- rule has a decision trace;
- README claims architecture checks exist;
- local command excludes the architecture group;
- pipeline summary lists only functional checks;
- manual review checklist omits the architecture rule;
- no retained result for the rule is available.

Short non-compilable mixed fixture:

```text
rule NoInboundToPersistenceRule
  protects ADR-012: inbound adapters must not call persistence modules

local command:
  run checks --groups functional,smoke
  excluded groups: architecture

pipeline summary:
  steps: restore, build, functional-tests
  architecture checks: not listed

manual checklist:
  items: deployment risk, database migration, operational logs
  architecture dependency rule: not listed
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- real pipeline configuration;
- executable code;
- test project files;
- full command history;
- scheduled job evidence;
- full manual review records;
- complete dependency graph;
- failed regression case;
- production incidents;
- all architecture verification output.

Withheld evidence prevents a confirmed `Fail`, global pipeline judgment, underlying architecture findings, or full regression conclusions.

## 18. Expected Findings

Exactly one warning finding is expected.

```text
Finding ID: EVAL-TEST-004-F001
Rule ID: TEST-018
Title: Architecture verification is defined but no meaningful execution path is shown
Outcome: Warning
Confidence: Possible
Severity: Medium
Applicability: Applicable
Evidence: NoInboundToPersistenceRule exists and traces to ADR-012, but local command excludes architecture checks, pipeline summary lists only functional tests, manual checklist omits the rule, and no retained execution result is provided.
Architectural Impact: The organization may believe the adapter-to-persistence rule is protected while the verification is dormant.
Regression Risk: Regressions against the dependency rule may escape feedback until manual discovery.
Enforcement Impact: Enforcement is weak because existence of the rule is not matched by observed execution.
Rationale: TEST-018 warning conditions are satisfied by plausible but incomplete execution evidence without confirmed missed regression or critical delivery reliance.
Remediation: Add a proportionate execution point, such as a local review command, scheduled check, manual review step, or delivery step matching the risk, and retain results.
Related Rules: TEST-001, TEST-002, TEST-014
Boundary Notes: The finding concludes only weak execution of the verification. It must not require every architecture check to run in every pipeline.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- lack of a specific CI/CD product;
- absence of every-commit execution;
- absence of a dedicated architecture-test project;
- absence of a specific architecture-testing library;
- lack of unit test coverage;
- lack of integration tests;
- underlying adapter-to-persistence violation;
- all architecture checks being invalid;
- lack of Clean Architecture;
- lack of Hexagonal Architecture;
- lack of DDD;
- lack of microservices;
- manual validation as inferior by default.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `TEST-018` | `Applicable` | `Warning` | `Match` |
| Scenario | `Applicable` | `Warning` | `Match` |

## 21. Expected Confidence

Expected confidence is `Possible`.

The evidence is contradictory and partial: it shows a relevant rule and multiple non-execution signals, but withholds full command history and full pipeline configuration.

## 22. Expected Severity

Expected severity is `Medium`.

The rule protects a material dependency constraint, but the evidence supports weak execution rather than confirmed missed release regression. `Low` is acceptable only with explicit reduced risk and preserved warning.

## 23. False Positive Guards

Do not report a finding based only on:

- absence of CI/CD;
- lack of every-commit execution;
- manual validation;
- local-only execution when proportionate;
- one-time low-risk verification;
- absence of a named architecture-test tool.

The warning depends on a relevant defined rule plus absence of any meaningful observed execution path.

## 24. False Negative Guards

Do not pass execution when:

- a rule exists but is excluded from commands;
- pipeline claims are generic and omit the rule;
- manual checklist omits the verification;
- no retained result is available;
- README text claims checks exist without execution evidence;
- optional jobs are habitually ignored.

## 25. Internal Boundary Expectations

| Candidate Conclusion | Primary Rule Owns Conclusion | Separate Rule Required | Duplicate Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Relevant verification is not observed in execution flow | `TEST-018` | No | Yes | Emit one warning. |
| Verification is architecturally defined | No | `TEST-001` if separately evaluated | Yes | Supporting context only. |
| Verification traces to a decision | No | `TEST-002` if separately evaluated | Yes | Supporting context only. |
| Repeated execution is deterministic | No | `TEST-014` if separately evaluated | Yes | Not established by this scenario. |

## 26. Cross-Catalog Boundary Expectations

### Architecture Testing x Core

Core evidence discipline requires exposing the dormant verification risk without overclaiming full review failure.

### Architecture Testing x Hexagonal

The underlying dependency condition may be Hexagonal in a different scenario, but no underlying violation is provided here.

### Architecture Testing x Clean

Clean dependency rule correctness is outside the primary conclusion.

### Architecture Testing x Layered

Layer dependency direction is not evaluated.

### Architecture Testing x DDD

No semantic model conclusion is supported.

### Architecture Testing x Events and Messaging

No messaging delivery, retry, idempotency, or event contract conclusion is supported.

## 27. Deduplication Expectations

| Shared Evidence | Testing Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Rule exists but no execution result | Weak execution under `TEST-018` | Fitness-function definition may be suspected | Yes | One `TEST-018` warning only. |
| Decision trace exists | Supports applicability | Traceability under `TEST-002` | Yes | Use as context, not a second finding. |
| Local and pipeline omissions | Execution risk | Regression detection may be suspected | Yes | No `TEST-017` finding without accepted-state regression evidence. |

## 28. Expected Remediation

Expected remediation must be proportional and technology-neutral:

- define where and when the architecture verification runs;
- add a local, review, scheduled, or delivery execution point proportionate to risk;
- retain execution results;
- document manual cadence if manual validation is adequate;
- avoid requiring CI/CD, every-commit gates, named tools, thresholds, or full suite redesign universally.

## 29. Allowed Variations

Allowed variations:

- equivalent execution-flow evidence;
- equivalent warning title;
- `Low` severity with explicit low-risk justification;
- supporting Rule omission when decorative;
- `Fail` only if observed output adds confirmed missed regression or critical delivery reliance;
- result status `Acceptable Variation` only when warning ownership remains clear.

## 30. Disallowed Variations

Disallowed variations:

- Primary Rule changed away from `TEST-018`;
- primary outcome `Pass`;
- unsupported `Fail`;
- `Not Applicable`;
- `Not Enough Evidence` when contradictory execution evidence is used;
- finding requiring CI/CD or every-commit execution universally;
- finding based only on test file existence;
- duplicate findings for definition, traceability, regression, or pipeline;
- underlying architecture violation as the only finding;
- nonexistent Rule ID.

## 31. Execution Instructions

Evaluate the mixed textual fixture statically.

Do not compile, run, generate, or infer executable fixture code. Treat local-command, pipeline-summary, README, and manual-checklist excerpts as provided evidence. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/testing/EVAL-TEST-004-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `TEST-018` is evaluated as `Applicable`;
- primary outcome is `Warning`;
- confidence is `Possible`;
- severity is `Medium` or contextually justified `Low`;
- exactly one warning finding appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Architecture Testing internal and cross-catalog boundaries are respected;
- duplicate findings are absent;
- remediation is proportional and technology-neutral;
- observed result comparison against `evaluation/expected/testing/EVAL-TEST-004-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- the warning is missing;
- primary outcome is `Pass`, unsupported `Fail`, `Not Applicable`, or `Not Enough Evidence`;
- confidence is upgraded without execution evidence;
- severity contradicts the scoped risk;
- absence of CI/CD alone owns the finding;
- expected non-findings appear;
- duplicate findings repeat the same dormant-verification conclusion;
- remediation prescribes a specific tool, CI product, every-commit gate, threshold, or rewrite;
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
| Input artifacts | Textual mixed fixture in sections 8 through 17 of this scenario. |
| Coverage dimensions | `TEST-018` warning coverage; Architecture Testing catalog coverage; `Warning`; `Possible`; `Medium`; contradictory evidence; applicability; manual validation; automated validation; partial scope; false-positive protection; false-negative protection; deduplication; remediation. |
| Primary Rule catalog | `skill/rules/ARCHITECTURE_TESTING_CATALOG.md` |
| Primary Rule normative file | `skill/rules/testing/TEST-018.md` |
| Supporting Rule | `skill/rules/testing/TEST-001.md` |
| Supporting Rule | `skill/rules/testing/TEST-002.md` |
| Supporting Rule | `skill/rules/testing/TEST-014.md` |
| Cataloged supporting Rule | `skill/rules/testing/TEST-017.md` |
| Cataloged supporting Rule | `skill/rules/testing/TEST-020.md` |
| Architecture Testing catalog review | `skill/reviews/ARCHITECTURE_TESTING_CATALOG_REVIEW.md` |
| Architecture Testing catalog stabilization | `skill/reviews/ARCHITECTURE_TESTING_CATALOG_STABILIZATION.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Gold Standard stabilization | `evaluation/stabilizations/EVAL-CORE-001-STABILIZATION.md` |

## 35. Gold Standard Requirements

This scenario follows the stabilized Gold Standard reference for structure, identity, evidence interpretation, applicability, outcome, confidence, severity, finding specificity, remediation proportionality, expected non-findings, false-positive protection, false-negative protection, boundaries, deduplication, and traceability.

It must not introduce requirements outside the Evaluation Suite models or redefine existing Rules.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-TEST-004`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `TEST-018`, selected Supporting Rules `TEST-001`, `TEST-002`, `TEST-014`, and expected `Warning` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
