# Expected Evaluation Result Model

## 1. Purpose

The Expected Evaluation Result Model defines how future scenarios record the result ArchInspector is expected to produce.

Expected results are the gold standard for comparison. They validate correct application of existing Rules and catalogs; they do not redefine those Rules.

## 2. Result Identity

Each expected result must have a stable identity tied to one scenario.

The identity must record result ID, scenario ID, version, owner, status, and change notes.

## 3. Scenario Reference

Each expected result must reference the scenario it evaluates.

The reference must include scenario ID, title, category, catalogs, primary Rule, supporting Rules, execution type, and scenario status.

## 4. Expected Rule Results

Each Rule evaluated by the scenario must register:

- Rule ID;
- Applicability;
- Expected Outcome;
- Expected Confidence;
- Expected Severity Range;
- Expected Finding;
- Expected Evidence;
- Forbidden Finding;
- Boundary Notes;
- Acceptance Criteria.

## 5. Expected Findings

Expected findings define the findings that must appear in the observed result.

Each expected finding must be atomic, tied to one primary Rule, supported by concrete evidence, scoped to reviewed material, and paired with proportional remediation and trade-offs.

## 6. Expected Non-Findings

Expected non-findings define findings that must not appear.

They protect against false positives, duplicate findings, boundary leakage, unsupported certainty, and conversion of legitimate absence or insufficient evidence into violations.

## 7. Expected Outcomes

Allowed outcome values are:

- `Pass`;
- `Fail`;
- `Warning`;
- `Not Applicable`;
- `Not Enough Evidence`.

The expected outcome must follow applicability and evidence strength.

## 8. Expected Confidence

Allowed confidence values are:

- `Confirmed`;
- `Likely`;
- `Possible`;
- `Not Enough Evidence`.

Expected confidence must follow the available evidence. Naming alone cannot justify `Confirmed` confidence without corroborating evidence.

## 9. Expected Severity

Expected severity must be contextual.

The expected result may define an accepted severity range or qualitative expectation tied to architectural impact, affected scope, risk, reversibility, recurrence, and consequence. It must not define a universal severity for a Rule, catalog, technology, or scenario category.

## 10. Expected Evidence Interpretation

Expected evidence interpretation defines how provided and withheld evidence should influence applicability, outcome, confidence, severity, findings, non-findings, and report language.

It must distinguish direct evidence, supporting evidence, weak nominal evidence, contradictory evidence, unavailable evidence, and evidence that is intentionally outside scope.

## 11. Expected Applicability

Allowed applicability values are:

- `Applicable`;
- `Not Applicable`;
- `Undetermined`.

Applicability must be determined before outcome. `Not Applicable` requires legitimate absence or out-of-scope context. `Undetermined` is used when evidence is insufficient to decide applicability.

## 12. Expected Legitimate Absence

Expected legitimate absence defines when the absence of a structure, mechanism, pattern, test, automation, artifact, or technology must not be treated as a violation.

Legitimate absence must be supported by scope, context, architectural style, risk, or reviewed material.

## 13. Expected Evidence Insufficiency

Expected evidence insufficiency defines when available material is too weak, incomplete, indirect, conflicting, or narrow to support a conclusion.

The expected result must state what evidence is missing and which unsupported outcomes or findings are forbidden.

## 14. Expected Boundary Behavior

Expected boundary behavior defines internal Rule ownership and cross-catalog ownership.

It must identify the owner Rule, supporting Rules, shared evidence, allowed references, prohibited duplication, and prohibited reassignment of findings.

## 15. Expected Remediation

Expected remediation must be derived from expected findings and proportional to the observed risk.

Remediation must not introduce universal prescriptions, unrelated redesigns, mandatory tools, mandatory automation, fixed thresholds, or architecture decisions unsupported by the scenario evidence.

## 16. Allowed Variations

Variation is allowed only when it does not:

- alter the architectural conclusion;
- change the primary Rule;
- introduce a forbidden finding;
- omit a required finding;
- transform legitimate absence into violation;
- transform insufficient evidence into confirmed violation;
- compromise atomicity;
- violate a boundary.

Allowed variation may include wording differences, equivalent evidence ordering, equivalent remediation phrasing, or accepted severity range when the architectural conclusion remains unchanged.

## 17. Disallowed Variations

Disallowed variations include:

- unsupported outcome changes;
- unsupported confidence upgrades;
- fixed severity outside the contextual expectation;
- missing required findings;
- unexpected forbidden findings;
- duplicate findings;
- merged unrelated findings;
- wrong primary Rule;
- wrong catalog ownership;
- report conclusions that exceed scope;
- hidden evidence gaps;
- unsupported scoring, percentages, thresholds, or rankings.

## 18. Comparison Method

Comparison must evaluate observed result against expected result by:

- scenario identity;
- Rule applicability;
- outcome;
- confidence;
- severity expectation;
- required findings;
- forbidden findings;
- evidence interpretation;
- boundary behavior;
- remediation;
- allowed variations;
- report consistency.

Comparison may be manual, automated, or mixed depending on scenario execution type.

## 19. Acceptance Criteria

An expected result is accepted when:

- Rule results match or stay within allowed variation;
- required findings appear;
- forbidden findings are absent;
- expected non-findings remain absent;
- confidence follows evidence strength;
- severity remains contextual and proportional;
- legitimate absence and insufficient evidence are handled correctly;
- boundaries are preserved;
- remediation is proportional;
- report output is consistent when applicable.

## 20. Failure Criteria

An expected result fails when:

- required Rule results mismatch;
- required findings are missing;
- forbidden findings appear;
- confidence contradicts evidence strength;
- severity contradicts contextual impact;
- legitimate absence is treated as violation;
- insufficient evidence is treated as confirmed evidence;
- boundary ownership is violated;
- remediation is unrelated or universally prescriptive;
- report output contradicts expected behavior.

## 21. Result Status

Allowed result status values are:

- `Match`;
- `Acceptable Variation`;
- `Mismatch`;
- `Blocked`;
- `Not Executed`.

`Match` means observed behavior matches expected behavior. `Acceptable Variation` means differences remain within allowed variation. `Mismatch` means observed behavior violates expected behavior. `Blocked` means execution could not be completed. `Not Executed` means no observed result exists yet.

## 22. Result Change Notes

Result change notes must record meaningful changes to expected outcomes, expected confidence, expected severity, required findings, forbidden findings, allowed variations, comparison method, or acceptance criteria.

Change notes must preserve traceability and must not silently change Rule meaning or catalog ownership.
