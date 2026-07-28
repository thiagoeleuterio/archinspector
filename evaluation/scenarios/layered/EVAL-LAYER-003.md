# EVAL-LAYER-003 - Shared Utility Referenced by Multiple Layers

## 1. Scenario Identity

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-LAYER-003` |
| Title | `Shared utility referenced by multiple layers` |
| Category | `Layered Architecture` |
| Scenario Type | `Warning Condition` |
| Catalogs | `Layered Architecture`; boundary references to `Core` |
| Primary Rule | `LAYER-009` |
| Supporting Rules | `LAYER-002`, `LAYER-003`, `SOLID-001` |
| Risk Level | `Low` |
| Execution Type | `Static Fixture` |
| Status | `Ready` |
| Priority | `P2` |
| Implementation Order | `21` |
| Gold Standard | `No` |
| Source Version | `v0.6.0 - Evaluation Suite` |
| Expected Result | `evaluation/expected/layered/EVAL-LAYER-003-EXPECTED.md` |
| Related Coverage Dimensions | Rule coverage for `LAYER-009`; catalog coverage for Layered Architecture; `Warning` outcome; `Possible` confidence; contextual `Low` severity; partial evidence; applicability; false-positive guard; false-negative guard; internal Layered boundary; Core boundary; deduplication; remediation. |

## 2. Purpose

This scenario validates that ArchInspector reports a constrained warning when a shared utility contract used by multiple layers starts exposing cross-layer responsibilities, while avoiding an automatic failure for legitimate shared utilities.

The scenario protects shared-library false-positive control, contract-leak false-negative control, internal Layered boundaries, and deduplication.

## 3. Scenario Classification

| Field | Value |
| --- | --- |
| Primary Type | `Warning Condition` |
| Secondary Types | `False Positive Guard`, `Internal Boundary` |
| Primary Outcome | `Warning` |
| Evidence Strength | `Partial` |
| Applicability | `Applicable` |
| Confidence | `Possible` |
| Severity | `Low` |

## 4. Architectural Context

The evaluated system is a fictitious invoicing system.

The reviewed scope identifies Presentation, Application, Domain, Infrastructure, and a shared utility package. The shared package originally contains neutral formatting helpers, but one shared contract named `SharedInvoiceContext` now exposes UI locale, persistence record key, retry flags, and a calculated tax hint consumed by multiple layers.

The evidence is intentionally partial. It suggests contract boundary leakage but does not prove a broad systemic failure. The correct result is a low-severity warning, not an automatic failure for shared code.

## 5. Target Catalogs

`Layered Architecture` owns the scenario because the evaluated concern is whether a contract shared across layers preserves boundary integrity.

`Core` is a boundary reference because the scenario validates proportionality and no generic shared-utility finding.

## 6. Primary Rule

| Field | Value |
| --- | --- |
| Rule ID | `LAYER-009` |
| Title | `Layer contracts must preserve boundary integrity` |
| Category | `Layered Architecture` |
| Status | `Active` |
| Normative File | `skill/rules/layered/LAYER-009.md` |
| Catalog File | `skill/rules/LAYER_CATALOG.md` |

`LAYER-009` is selected because it directly evaluates whether contracts between layers expose, depend on, or transfer responsibilities owned by another layer. The shared utility is suspicious only because its contract mixes UI, persistence, retry, and business hint data across layer boundaries.

`LAYER-002`, `LAYER-003`, and `SOLID-001` are related but not primary.

## 7. Supporting Rules

| Rule ID | Boundary Purpose |
| --- | --- |
| `LAYER-002` | Boundary reference for layer responsibility clarity. |
| `LAYER-003` | Boundary reference for dependency direction without duplicating contract integrity. |
| `SOLID-001` | Supporting design reference for abstraction stability without owning the Layered finding. |

Supporting Rules may explain shared evidence and expected non-findings. They must not replace `LAYER-009`.

## 8. Input Artifacts

The scenario input is a textual static manifest. It is not executable and must not be treated as compilable code.

The manifest includes:

- directory structure;
- layer map;
- component inventory;
- dependency inventory;
- responsibility inventory;
- execution flow;
- observable evidence;
- short pseudocode excerpts;
- evidence withheld.

## 9. Directory Structure

```text
invoice-system/
  presentation/
    InvoicePage
  application/
    IssueInvoiceService
  domain/
    InvoiceTaxPolicy
  infrastructure/
    InvoiceRetrySender
    InvoiceRecordStore
  shared/
    TextFormatter
    SharedInvoiceContext
```

Directory names are supporting context only. The warning must depend on contract shape and usage.

## 10. Component Inventory

| Component | Role in Scenario | Reviewed Evidence |
| --- | --- | --- |
| `TextFormatter` | Neutral shared helper. | Used safely for simple text formatting. |
| `SharedInvoiceContext` | Shared cross-layer contract. | Exposes UI locale, persistence key, retry flag, and tax hint together. |
| `InvoicePage` | Presentation component. | Reads UI locale and also passes full shared context onward. |
| `IssueInvoiceService` | Application coordinator. | Receives full shared context and forwards it to Domain and Infrastructure. |
| `InvoiceTaxPolicy` | Domain business policy. | Reads `calculatedTaxHint` from the shared context. |
| `InvoiceRecordStore` | Persistence component. | Reads `recordKey` from the same shared context. |

## 11. Dependency Inventory

| From | To | Dependency Kind | Interpretation |
| --- | --- | --- | --- |
| `InvoicePage` | `SharedInvoiceContext` | Shared contract dependency | Presentation uses the contract and forwards all fields. |
| `IssueInvoiceService` | `SharedInvoiceContext` | Shared contract dependency | Application coordinates through a multi-responsibility contract. |
| `InvoiceTaxPolicy` | `SharedInvoiceContext.calculatedTaxHint` | Contract field dependency | Domain depends on a value shaped outside its boundary. |
| `InvoiceRecordStore` | `SharedInvoiceContext.recordKey` | Contract field dependency | Persistence detail is carried in the same shared contract. |
| Multiple layers | `TextFormatter` | Neutral helper dependency | Legitimate shared utility usage. |

No evidence proves that all shared contracts are problematic or that `TextFormatter` leaks responsibility.

## 12. Responsibility Inventory

| Responsibility | Expected Owner | Observed Owner |
| --- | --- | --- |
| Neutral text formatting | Shared utility | `TextFormatter` |
| UI locale adaptation | Presentation | Field in `SharedInvoiceContext` |
| Business tax decision | Domain/Business | Influenced by field in shared contract |
| Persistence record identity | Infrastructure/Data Access | Field in shared contract |
| Retry transport hint | Infrastructure | Field in shared contract |
| Preserve layer contract integrity | Boundary contracts | At risk in `SharedInvoiceContext` |

## 13. Execution Flow

1. `InvoicePage` creates or receives `SharedInvoiceContext`.
2. `IssueInvoiceService` passes the same context through the workflow.
3. `InvoiceTaxPolicy` reads `calculatedTaxHint`.
4. `InvoiceRecordStore` reads `recordKey`.
5. `InvoiceRetrySender` reads `retryAfterFailure`.
6. `TextFormatter` remains a neutral helper and is not part of the warning.

The warning is present because one shared contract mixes responsibilities from multiple layers and may couple their evolution.

## 14. Preconditions

- The evaluator receives the textual manifest as the complete scenario input.
- The evaluator treats the manifest as reviewed material for static evaluation.
- The evaluator does not assume additional source files, tests, diagrams, runtime behavior, or hidden architecture documentation.
- The evaluator applies only existing Rule IDs.
- The evaluator evaluates applicability before outcome.

## 15. Architecture State

The architecture state is a warning condition.

The shared utility is not automatically wrong. The risk is limited to the `SharedInvoiceContext` contract, whose shape appears to transfer UI, persistence, infrastructure retry, and business hint responsibilities across layer boundaries.

## 16. Evidence Provided

Partial evidence is provided:

- observable layers and shared package;
- legitimate neutral helper `TextFormatter`;
- shared contract `SharedInvoiceContext`;
- mixed UI, persistence, infrastructure, and business hint fields;
- multiple layers reading the same contract;
- uncertain scope of recurrence and architectural impact.

Short non-compilable pseudocode:

```text
contract SharedInvoiceContext
  uiLocale
  recordKey
  retryAfterFailure
  calculatedTaxHint

component InvoiceTaxPolicy
  calculate(invoice, context)
    use context.calculatedTaxHint
```

## 17. Evidence Withheld

The scenario intentionally withholds:

- executable fixture files;
- compilable source code;
- complete contract evolution history;
- all shared utility consumers;
- runtime logs;
- architecture diagrams beyond the manifest;
- automated test outputs;
- complete domain model;
- complete persistence implementation;
- formal Clean Architecture adoption claim;
- formal Hexagonal Architecture adoption claim;
- Fowler pattern evidence.

Withheld evidence prevents confirmed broad failure, global shared-library condemnation, Clean/Hexagonal findings, Fowler findings, or global modularity conclusions.

## 18. Expected Findings

Exactly one warning finding is expected.

```text
Finding ID: EVAL-LAYER-003-F001
Rule ID: LAYER-009
Title: Shared invoice context mixes UI, persistence, infrastructure, and business boundary data
Outcome: Warning
Confidence: Possible
Severity: Low
Applicability: Applicable
Evidence: SharedInvoiceContext is consumed by Presentation, Application, Domain, and Infrastructure and exposes uiLocale, recordKey, retryAfterFailure, and calculatedTaxHint in one shared contract.
Architectural Impact: The contract may couple layer evolution by making multiple layers understand fields owned by other responsibilities.
Responsibility Impact: Boundary-specific UI, persistence, retry, and business hint responsibilities are partially transferred through a shared type.
Dependency Impact: Multiple layers depend on a broad shared contract instead of minimal responsibility-preserving boundary data.
Rationale: The evidence satisfies LAYER-009 warning conditions because contract leakage appears plausible but scope and impact are partial.
Remediation: Split or narrow the shared contract into responsibility-preserving boundary data, keep neutral helpers shared, and move layer-specific fields to the owning layer or mediated boundary.
Related Rules: LAYER-002, LAYER-003, SOLID-001
Boundary Notes: The finding concludes only the shared contract boundary-integrity risk. It must not fail all shared utilities or duplicate dependency-direction findings.
```

## 19. Expected Non-Findings

The scenario must not produce confirmed findings for:

- all shared libraries;
- neutral `TextFormatter` usage;
- stable shared identifiers;
- shared primitive values;
- absence of separate projects;
- absence of Clean Architecture formalism;
- absence of Hexagonal Architecture formalism;
- absence of DDD;
- use of a monolith;
- dependency direction violation without exclusive evidence;
- persistence placement violation without exclusive evidence;
- SOLID violation as a duplicate;
- microservice absence;
- architecture-test absence.

## 20. Expected Outcomes

| Scope | Applicability | Outcome | Result Status |
| --- | --- | --- | --- |
| Primary Rule `LAYER-009` | `Applicable` | `Warning` | `Match` |
| Scenario | `Applicable` | `Warning` | `Match` |

## 21. Expected Confidence

Expected confidence is `Possible`.

The evidence suggests boundary leakage through a shared contract, but full recurrence, impact, and contract role evidence are withheld. Naming alone is not used.

## 22. Expected Severity

Expected severity is `Low`.

The concern is localized to one shared contract and partial impact evidence. `Medium` is acceptable only if an observed result justifies broader impact while preserving `Warning`.

## 23. False Positive Guards

Do not report a finding based only on:

- shared utility existence;
- a shared folder or package;
- neutral formatting helpers;
- shared identifiers or stable values;
- same-project organization;
- lack of formal layer packages;
- lack of interfaces.

The warning depends on a contract mixing responsibilities across layers.

## 24. False Negative Guards

Do not miss the warning because:

- the component is called a utility;
- the fields are simple strings or flags;
- every layer can technically reference the shared package;
- the system is small;
- the contract is convenient;
- no formal Layered Architecture claim is made.

## 25. Internal Boundary Expectations

`LAYER-009` owns the primary finding because the evaluated concern is contract boundary integrity.

`LAYER-002` may support responsibility context. `LAYER-003` may support dependency context. Neither should duplicate the contract-integrity warning.

## 26. Cross-Catalog Boundary Expectations

### Layered x Clean Architecture

Clean boundary data rules may be adjacent, but no Clean finding is expected without Clean use case or policy-boundary evidence.

### Layered x Hexagonal Architecture

Hexagonal adapter model leakage is not established. The finding must remain Layered contract integrity.

### Layered x Core

Core behavior validates proportional warning handling and no universal shared-library prohibition.

### Layered x Fowler

Fowler DTO or Registry findings require pattern-specific evidence and must not duplicate this Layered contract warning.

## 27. Deduplication Expectations

| Shared Evidence | Layered Conclusion | Neighboring Catalog Conclusion | Duplicate Finding Forbidden | Expected Handling |
| --- | --- | --- | --- | --- |
| Shared contract used by multiple layers | Boundary integrity warning under `LAYER-009` | SOLID abstraction concern may be suspected | Yes | Emit one Layered warning only. |
| UI and persistence fields in one contract | Responsibility leakage risk | Clean boundary data may be suspected | Yes | No Clean finding without Clean-specific boundary. |
| Neutral `TextFormatter` shared | Legitimate shared utility | Generic shared-library violation may be suspected | Yes | No finding for neutral helper. |
| `recordKey` used by persistence | Persistence detail in shared contract | `LAYER-007` may be suspected | Yes | No persistence finding without exclusive evidence. |

## 28. Expected Remediation

Expected remediation must be proportional and technology-neutral:

- keep neutral helpers shared;
- split or narrow `SharedInvoiceContext`;
- move UI, persistence, retry, and business hint data to responsibility-preserving boundaries;
- introduce abstractions only where needed to preserve contract integrity.

The remediation must not require Clean Architecture, Hexagonal Architecture, DDD, microservices, DTO patterns, a framework, project separation, or rewrite.

## 29. Allowed Variations

Allowed variations:

- small editorial wording differences;
- equivalent invoice terminology;
- equivalent partial evidence ordering;
- `Low` or justified `Medium` severity;
- supporting Rule omission when boundaries remain preserved;
- no confirmed failure as long as the warning and ownership are preserved.

## 30. Disallowed Variations

Disallowed variations:

- title different from the catalog;
- category different from the catalog;
- Primary Rule changed away from `LAYER-009`;
- `Pass` as primary result when the mixed contract risk is used;
- `Fail Confirmed` without direct broad contract leakage impact;
- `Not Applicable`;
- `Not Enough Evidence` when partial risk evidence is used;
- generic shared-library failure;
- finding based only on names or shared package location;
- duplicate finding;
- prescriptive remediation.

## 31. Execution Instructions

Evaluate the textual manifest statically.

Do not compile, run, generate, or infer executable fixture code. Treat pseudocode as non-compilable evidence of structure and behavior. Evaluate only the provided scope and withheld evidence. Apply existing Rules only.

Produce an observed result and compare it against `evaluation/expected/layered/EVAL-LAYER-003-EXPECTED.md` using the expected result comparison method.

## 32. Acceptance Criteria

The scenario is accepted when:

- `LAYER-009` is evaluated as `Applicable`;
- primary outcome is `Warning`;
- confidence is `Possible`;
- severity is contextual and around `Low`;
- exactly one warning finding appears;
- expected non-findings are absent;
- false-positive and false-negative guards are preserved;
- Layered internal and cross-catalog boundaries are respected;
- duplicate findings are absent;
- remediation is proportional and technology-neutral;
- observed result comparison against `evaluation/expected/layered/EVAL-LAYER-003-EXPECTED.md` is performed;
- traceability points to the scenario catalog, models, Primary Rule, and Supporting Rules.

## 33. Failure Criteria

The scenario fails when:

- the warning is missing;
- outcome is unsupported `Pass`, confirmed `Fail`, `Not Applicable`, or `Not Enough Evidence`;
- confidence is upgraded to `Confirmed` from partial evidence;
- all shared utilities are treated as violations;
- duplicate Layered, Clean, Hexagonal, Fowler, SOLID, or Core findings repeat the same conclusion;
- remediation prescribes unrelated architecture or tooling;
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
| Input artifacts | Textual static manifest in sections 8 through 17 of this scenario. |
| Coverage dimensions | `LAYER-009` warning coverage; Layered catalog coverage; `Warning`; `Possible`; `Low`; partial evidence; applicability; false-positive protection; false-negative protection; internal Layered boundary; Core boundary; deduplication; remediation. |
| Primary Rule catalog | `skill/rules/LAYER_CATALOG.md` |
| Primary Rule normative file | `skill/rules/layered/LAYER-009.md` |
| Supporting Rule | `skill/rules/layered/LAYER-002.md` |
| Supporting Rule | `skill/rules/layered/LAYER-003.md` |
| Supporting Rule | `skill/rules/solid/SOLID-001.md` |
| Layered catalog review | `skill/reviews/LAYER_CATALOG_REVIEW.md` |
| Layered catalog stabilization | `skill/reviews/LAYER_CATALOG_STABILIZATION.md` |
| Clean boundary review | `skill/reviews/CLEAN_CATALOG_REVIEW.md` |
| Hexagonal boundary review | `skill/reviews/HEX_CATALOG_REVIEW.md` |
| Fowler boundary review | `skill/reviews/FOWLER_CATALOG_REVIEW.md` |
| Gold Standard scenario | `evaluation/scenarios/core/EVAL-CORE-001.md` |
| Gold Standard expected result | `evaluation/expected/core/EVAL-CORE-001-EXPECTED.md` |
| Gold Standard stabilization | `evaluation/stabilizations/EVAL-CORE-001-STABILIZATION.md` |

## 35. Gold Standard Requirements

This scenario follows the stabilized Gold Standard reference for structure, identity, evidence strength, atomicity, outcomes, confidence, severity, finding specificity, remediation proportionality, expected non-findings, false-positive protection, false-negative protection, cross-catalog boundaries, deduplication, and expected result traceability.

It must not introduce requirements outside the Evaluation Suite models or redefine existing Rules.

## 36. Scenario Change Notes

Initial concrete scenario for `EVAL-LAYER-003`.

Aligned with the stabilized Gold Standard structure, the Evaluation Suite models, the scenario identity copied from `evaluation/SCENARIO_CATALOG.md`, selected Primary Rule `LAYER-009`, selected Supporting Rules, and expected `Warning` result.

No executable fixture, code, script, project, review, stabilization, Rule change, catalog change, commit, tag, or release is created by this scenario.
