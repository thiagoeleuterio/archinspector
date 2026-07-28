# ArchInspector Evaluation Suite

## 1. Purpose

The ArchInspector Evaluation Suite defines how future evaluation scenarios validate whether ArchInspector applies its existing rules, catalogs, outcomes, confidence guidance, severity guidance, finding contract, boundary rules, and report structure consistently.

The suite verifies evaluation behavior. It does not redefine architectural rules, create new rule responsibilities, prescribe a system architecture, introduce scoring, or replace review and stabilization artifacts.

## 2. Evaluation Principles

- Evidence before conclusion.
- Rule responsibility before finding grouping.
- Applicability before outcome.
- Legitimate absence must remain distinct from missing evidence.
- Missing, weak, partial, or conflicting evidence must remain visible.
- Severity must be contextual and proportional to demonstrated architectural impact.
- Confidence must follow the strength of evidence.
- Findings must be atomic, traceable, and tied to a primary Rule.
- Equivalent compliant designs must not be treated as violations.
- Repeated execution against the same scenario must produce the same result.

## 3. Scope

The suite covers validation of:

- violation detection;
- positive compliance;
- legitimate absence;
- insufficient evidence;
- `Fail`, `Warning`, `Pass`, `Not Applicable`, and `Not Enough Evidence`;
- `Confirmed`, `Likely`, `Possible`, and `Not Enough Evidence` confidence;
- contextual severity;
- atomic findings;
- expected non-findings;
- remediation proportionality;
- false-positive control;
- false-negative control;
- internal Rule boundaries;
- cross-catalog boundaries;
- coverage responsibilities;
- final report consistency.

## 4. Out of Scope

The suite does not:

- create concrete scenarios in this version;
- create fixtures, code samples, test projects, scripts, or execution commands;
- alter Rules, catalogs, reviews, or stabilizations;
- add new architectural review areas;
- require any programming language, framework, test tool, CI/CD system, container, cloud provider, AST parser, compiler, or automatic execution;
- define numeric scores, mandatory percentages, arbitrary thresholds, or rankings between Rules;
- decide architecture for the evaluated system.

## 5. Evaluation Layers

1. `Rule-Level Evaluation`: validates one Rule's applicability, outcome, confidence, severity, evidence interpretation, findings, and expected non-findings.
2. `Catalog-Level Evaluation`: validates coverage and consistency across Rules owned by one catalog.
3. `Cross-Catalog Evaluation`: validates that shared evidence and overlapping concerns preserve catalog ownership and do not duplicate findings.
4. `Full Review Evaluation`: validates end-to-end report consistency across scope, evidence, findings, root causes, roadmap, unknowns, and final assessment.
5. `Regression Evaluation`: validates that previously accepted expected behavior remains stable after changes to the suite, scenarios, Rules, or review process.

## 6. Scenario Categories

Future scenarios must use one of the following categories and define the required fields for that category.

| Category | Purpose | Entry Condition | Expected Behavior | Validated Risk | Expected Outcome | Minimum Evidence | Acceptance Criteria | Failure Criteria |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `Positive Compliance` | Validate compliant architecture recognition. | Evidence shows the Rule is satisfied. | ArchInspector returns a supported positive result without inventing findings. | False violation. | `Pass`. | Traceable evidence sufficient for the Rule. | Required pass and non-findings match. | A violation, warning, or unsupported uncertainty is reported. |
| `Confirmed Violation` | Validate detection of a real violation. | Direct evidence shows the Rule is violated. | ArchInspector reports an atomic finding tied to the primary Rule. | False negative. | `Fail`. | Concrete violation evidence. | Required finding, severity range, confidence, and remediation match. | Violation is missed, diluted, duplicated, or assigned to the wrong Rule. |
| `Warning Condition` | Validate partial or ambiguous risk handling. | Evidence shows risk that does not justify confirmed failure. | ArchInspector reports `Warning` without overstating certainty. | Over-escalation or under-reporting. | `Warning`. | Partial or mixed evidence. | Warning reasoning matches evidence strength. | Result becomes unsupported `Fail`, `Pass`, or `Not Enough Evidence`. |
| `Legitimate Absence` | Validate absence that is valid in context. | The Rule or architectural mechanism is outside scope or not required. | ArchInspector returns `Not Applicable` or no finding as expected. | Universal prescription. | `Not Applicable`. | Scope and context evidence showing non-applicability. | Absence is not treated as a violation. | Absence is reported as a failure without applicability evidence. |
| `Insufficient Evidence` | Validate conservative handling of missing evidence. | The Rule may apply but material is incomplete, weak, conflicting, or unavailable. | ArchInspector uses `Not Enough Evidence`. | Speculation. | `Not Enough Evidence`. | Description of missing or inadequate evidence. | Unknowns and evidence gaps are visible. | Unsupported pass, fail, warning, or not applicable is produced. |
| `False Positive Guard` | Validate protection of legitimate alternatives. | Evidence includes a structure that could be mistaken for a violation. | ArchInspector avoids prohibited findings. | False positive. | Scenario-defined. | Evidence of legitimate context or equivalent design. | Forbidden findings are absent. | A prohibited finding appears. |
| `False Negative Guard` | Validate detection despite camouflage or weak conventions. | Evidence includes a violation that could be missed. | ArchInspector detects the required violation. | False negative. | Scenario-defined, usually `Fail`. | Violation evidence plus misleading or incomplete signals. | Required finding appears under the correct Rule. | Violation is missed or assigned away from the owner Rule. |
| `Internal Boundary` | Validate boundaries between Rules in one catalog. | Evidence touches related Rules in the same catalog. | Each Rule keeps its own responsibility and finding scope. | Duplicate or blended findings. | Scenario-defined. | Shared evidence and distinct Rule responsibilities. | Findings are atomic and non-duplicative. | One Rule absorbs another Rule's responsibility. |
| `Cross-Catalog Boundary` | Validate boundaries between catalogs. | Evidence touches multiple architecture areas. | Primary concern determines Rule ownership. | Cross-catalog duplication or gap. | Scenario-defined. | Evidence relevant to multiple catalogs. | Owner Rule and supporting Rules are separated. | Wrong catalog owns the finding or duplicate findings appear. |
| `Multiple Findings` | Validate atomicity with more than one issue. | Evidence supports separate architectural concerns. | ArchInspector emits distinct findings without merging unrelated causes. | Over-grouping. | Scenario-defined. | Evidence for each expected finding. | Each finding has one primary Rule and traceable evidence. | Findings are merged, duplicated, or omitted. |
| `Conflicting Evidence` | Validate conservative interpretation of conflict. | Evidence points to incompatible conclusions. | ArchInspector reflects conflict through confidence or `Not Enough Evidence`. | Unsupported certainty. | Scenario-defined. | At least two conflicting evidence points. | Conflict affects reasoning and confidence. | Conflict is ignored or resolved by assumption. |
| `Partial Scope` | Validate limits of incomplete review material. | Scenario provides only part of the system. | ArchInspector constrains conclusions to reviewed scope. | Claiming complete coverage. | Scenario-defined. | Explicit reviewed and withheld scope. | Report states limits and avoids unsupported completeness. | Result claims broader scope than provided. |
| `Manual Validation` | Validate non-automated evaluation paths. | Scenario requires human interpretation or document review. | ArchInspector accepts manual evidence when traceable. | Automation bias. | Scenario-defined. | Documents, diagrams, review notes, or manual artifacts. | Manual basis is explicit and proportionate. | Result requires automation without contextual reason. |
| `Automated Validation` | Validate executable or tool-produced evidence. | Scenario includes executable or generated verification output. | ArchInspector uses automation as evidence without overclaiming. | Tool presence as proof. | Scenario-defined. | Verification definition and observed result. | Tool output is interpreted within scope. | Tool name or green result becomes unsupported proof. |
| `Regression` | Validate previously accepted behavior. | Scenario protects a known expected result. | ArchInspector preserves accepted outcome or records governed change. | Behavioral drift. | Scenario-defined. | Previous expected result and current observed result. | Result matches or variation is governed. | Accepted behavior changes without traceability. |
| `Exception Governance` | Validate suppressions, exclusions, and accepted deviations. | Evidence includes exception-like behavior. | ArchInspector distinguishes governed exception from hidden violation. | Permanent or broad exception hiding risk. | Scenario-defined. | Exception scope, rationale, owner, and lifecycle when available. | Exception treatment is proportional and traceable. | Exception is ignored, universalized, or treated as proof of compliance. |
| `Determinism` | Validate repeatability. | Same scenario is evaluated more than once without material change. | Results are identical or allowed variation is documented. | Flaky review behavior. | Scenario-defined. | Same input state and repeated observed results. | Outcome, findings, confidence, and report conclusions are repeatable. | Material result changes without input change. |
| `Report Consistency` | Validate final report coherence. | Scenario exercises report-level output. | Scope, evidence, findings, root causes, remediation, unknowns, and final assessment agree. | Contradictory final report. | Scenario-defined. | Complete expected result and report expectations. | No report section contradicts expected results. | Report contradicts findings, coverage, or evidence limits. |

## 7. Execution Model

An evaluation run compares a scenario definition, expected result, available artifacts, withheld artifacts, and observed ArchInspector output.

Execution may be static, executable, document-based, mixed, or manual. The suite must not require every scenario to be automated. Automated execution is valid only when the scenario's evidence and risk justify it.

Each execution must record reviewed inputs, unavailable inputs, observed outcome, observed confidence, observed severity, observed findings, observed non-findings, allowed variations, mismatches, blocked conditions, and traceability.

## 8. Evidence Model

Evidence must be concrete, traceable, and tied to the reviewed material. Future scenarios may provide:

- code fixtures;
- directory structures;
- configuration files;
- dependency graphs;
- diagrams;
- architectural documents;
- reports;
- manual observations;
- automated verification output;
- executable projects;
- mixed artifact sets.

Evidence may be strong, partial, nominal, contradictory, absent, provided, or intentionally withheld. Naming alone must not produce `Confirmed` confidence unless corroborated by stronger evidence.

## 9. Expected Outcomes

Allowed outcomes are:

- `Pass`;
- `Fail`;
- `Warning`;
- `Not Applicable`;
- `Not Enough Evidence`.

Each expected outcome must be tied to applicability and evidence. `Not Applicable` requires a legitimate absence or out-of-scope condition. `Not Enough Evidence` requires missing, incomplete, indirect, conflicting, or insufficient material.

## 10. Confidence Validation

Allowed confidence values are:

- `Confirmed`;
- `Likely`;
- `Possible`;
- `Not Enough Evidence`.

Confidence validation checks whether the observed confidence follows evidence strength. Direct and traceable evidence may support `Confirmed`. Multiple incomplete signals may support `Likely`. Weak or indirect signals may support `Possible`. Inadequate evidence must use `Not Enough Evidence`.

## 11. Severity Validation

Severity is contextual and must be derived from architectural impact inside the reviewed scope. The suite must validate expected severity ranges rather than fixed universal severity values.

Severity must not be assigned solely from Rule category, technology, file name, tool presence, percentage, sequence number, or scenario category.

## 12. Finding Validation

Finding validation checks that every expected finding is:

- atomic;
- tied to one primary Rule;
- supported by traceable evidence;
- scoped to reviewed material;
- assigned a supported outcome and confidence;
- assigned contextual severity when applicable;
- paired with proportional remediation;
- not duplicated by related Rules or catalogs.

Expected non-findings and forbidden findings must also be validated.

## 13. Rule Boundary Validation

Internal Rule boundary validation checks that a Rule evaluates only its own architectural condition.

Related Rules may share evidence, but shared evidence must not merge responsibilities, duplicate findings, or cause one Rule to absorb another Rule's outcome.

## 14. Cross-Catalog Boundary Validation

Cross-catalog validation checks that the primary architectural concern determines ownership. Supporting catalogs may provide context, but they must not duplicate the owner Rule's finding.

The suite must preserve boundaries among Hexagonal Architecture, Clean Architecture, Domain-Driven Design, SOLID, Layered Architecture, Fowler Patterns, Events and Messaging, Architecture Testing, and Solution Architecture.

## 15. False Positive Validation

False-positive validation checks that ArchInspector does not report violations when:

- the architecture is compliant;
- the Rule is legitimately not applicable;
- the evidence is insufficient;
- an alternative implementation satisfies the architectural intent;
- a naming, folder, framework, or tool signal is not supported by stronger evidence.

## 16. False Negative Validation

False-negative validation checks that ArchInspector does not miss violations when direct or sufficient evidence shows:

- a boundary violation;
- misplaced responsibility;
- duplicated or missing architectural responsibility;
- broken applicability handling;
- hidden risk behind misleading naming, broad exceptions, empty verification scope, or partial review output.

## 17. Coverage Validation

Coverage validation checks whether planned scenarios cover:

- every Rule;
- every catalog;
- every outcome;
- every confidence value;
- contextual severity ranges;
- evidence strengths and gaps;
- applicability;
- legitimate absence;
- insufficient evidence;
- false positives;
- false negatives;
- internal boundaries;
- cross-catalog boundaries;
- findings;
- remediation;
- execution types;
- regression and determinism.

Coverage gaps must remain visible and traceable.

## 18. Determinism Validation

Determinism validation checks that the same scenario, artifacts, expected result, and execution instructions produce the same observed result when no material input changes.

Allowed variation must be explicitly defined and must not alter architectural conclusion, Rule ownership, required findings, forbidden findings, or boundaries.

## 19. Regression Validation

Regression validation checks that accepted expected behavior remains stable across future changes.

A changed result is acceptable only when the change is traceable, governed, and does not silently weaken false-positive, false-negative, boundary, confidence, severity, coverage, or report guarantees.

## 20. Report Validation

Report validation checks that final review output is internally consistent:

- scope matches evidence;
- detected architecture matches evidence and confidence;
- findings match Rule results;
- detailed evidence supports findings;
- root causes are supported or qualified;
- remediation is derived from findings;
- trade-offs are present;
- unknowns expose missing evidence;
- final assessment respects coverage limits.

## 21. Acceptance Criteria

The complete suite may be considered approved only when:

- all mandatory scenario categories have expected results defined;
- all executable scenarios have observed results;
- no critical scenario is blocked;
- no critical false positive remains;
- no critical false negative remains;
- no central responsibility lacks coverage;
- no principal boundary is violated;
- no result lacks traceability;
- results are repeatable;
- the final report is consistent.

## 22. Failure Criteria

The suite fails when:

- expected results are missing for mandatory scenario categories;
- observed results are missing for executable scenarios;
- a critical false positive or false negative remains;
- a Rule or catalog responsibility has no planned coverage without explicit status;
- a boundary violation remains unresolved;
- findings are duplicated, merged incorrectly, or unsupported by evidence;
- confidence or severity contradicts evidence strength;
- legitimate absence is converted into violation;
- insufficient evidence is converted into unsupported certainty;
- report conclusions exceed the reviewed scope;
- results are nondeterministic without allowed variation.

## 23. Evaluation Governance

Evaluation assets must be versioned, reviewed, and stabilized separately from Rules and catalogs.

Changes to scenarios, expected results, coverage, or execution instructions must record why the change was made and whether it changes expected behavior. Changes must not silently alter Rule meaning, catalog ownership, official outcomes, confidence vocabulary, or report obligations.

## 24. Change Notes

Initial definition for `v0.6.0 - Evaluation Suite`.

No concrete scenarios, fixtures, scripts, Rules, catalogs, reviews, stabilizations, commits, tags, or releases are created by this document.
