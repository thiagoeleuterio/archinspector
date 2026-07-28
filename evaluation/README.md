# ArchInspector Evaluation

## Purpose

This directory defines the ArchInspector Evaluation Suite for `v0.6.0 - Evaluation Suite`.

The suite validates whether ArchInspector applies existing Rules, catalogs, outcomes, confidence guidance, severity guidance, finding expectations, boundaries, coverage expectations, and report obligations correctly.

## Documents

- `EVALUATION_SUITE.md`: defines evaluation purpose, principles, layers, categories, validation areas, acceptance criteria, and governance.
- `SCENARIO_MODEL.md`: defines the model for future evaluation scenarios.
- `EXPECTED_RESULT_MODEL.md`: defines the model for expected results used as comparison standards.
- `COVERAGE_MODEL.md`: defines how coverage dimensions, gaps, and status are tracked.
- `README.md`: defines directory purpose, workflow, lifecycle, naming conventions, rules, status, and next steps.

## Directory Structure

```text
evaluation/
├── README.md
├── EVALUATION_SUITE.md
├── SCENARIO_MODEL.md
├── EXPECTED_RESULT_MODEL.md
└── COVERAGE_MODEL.md
```

## Evaluation Workflow

```text
Evaluation Suite Definition
↓
Scenario Catalog Definition
↓
Gold Standard Scenario
↓
Gold Scenario Review
↓
Gold Scenario Stabilization
↓
Catalog Scenarios
↓
Evaluation Execution
↓
Coverage Review
↓
Regression Suite
↓
Commit
```

## Scenario Lifecycle

Future scenarios move through `Draft`, `Ready`, `Executed`, `Passed`, `Failed`, `Blocked`, or `Deprecated`.

A scenario must define identity, category, target Rules, artifacts, evidence provided, evidence withheld, expected findings, expected outcomes, expected non-findings, guards, boundaries, execution instructions, acceptance criteria, failure criteria, and traceability.

## Result Lifecycle

Future expected results define the gold standard for scenario comparison.

Observed results may be classified as `Match`, `Acceptable Variation`, `Mismatch`, `Blocked`, or `Not Executed`.

## Coverage Lifecycle

Coverage tracks planned, partial, complete, blocked, and intentionally external coverage across Rules, catalogs, outcomes, confidence, severity, evidence, applicability, absence, insufficient evidence, false positives, false negatives, boundaries, findings, remediation, execution, regression, and determinism.

Allowed coverage statuses are `Not Planned`, `Planned`, `Partially Covered`, `Covered`, `Blocked`, and `Intentionally External`.

## Naming Conventions

Future scenario IDs must use:

```text
EVAL-<CATALOG>-<NNN>
```

Valid future ID shapes include `EVAL-CORE-001`, `EVAL-HEX-001`, `EVAL-CLEAN-001`, `EVAL-DDD-001`, `EVAL-LAYER-001`, `EVAL-FOWLER-001`, `EVAL-MSG-001`, `EVAL-TEST-001`, `EVAL-CROSS-001`, and `EVAL-FULL-001`.

These examples do not create concrete scenarios.

## Execution Rules

Evaluation may use static fixtures, executable fixtures, document fixtures, mixed fixtures, or manual evaluation.

The suite must not universally require C#, .NET, Java, TypeScript, any framework, any test tool, CI/CD, containers, cloud, AST, compilation, automatic execution, scoring, percentages, arbitrary thresholds, or Rule rankings.

The suite must not create or alter Rules, catalogs, reviews, stabilizations, concrete scenarios, fixtures, scripts, tags, releases, or commits.

## Current Status

- Evaluation Suite: `Defined`;
- Scenario Model: `Defined`;
- Expected Result Model: `Defined`;
- Coverage Model: `Defined`;
- Concrete Scenarios: `Not Started`;
- Execution: `Not Started`;
- Regression Suite: `Not Started`.

## Next Steps

- Define the future scenario catalog.
- Create a gold standard scenario in a later step.
- Review and stabilize the gold scenario before adding catalog scenarios.
- Execute evaluation only after scenarios and expected results exist.
- Review coverage gaps before forming a regression suite.
