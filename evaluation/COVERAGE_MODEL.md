# Evaluation Coverage Model

## 1. Purpose

The Evaluation Coverage Model defines how future evaluation scenarios track coverage across Rules, catalogs, outcomes, confidence, severity, evidence, applicability, absence, insufficient evidence, false positives, false negatives, boundaries, findings, remediation, execution types, regression, and determinism.

Coverage makes gaps visible. It does not create numeric scoring, mandatory percentages, arbitrary thresholds, or rankings between Rules.

## 2. Coverage Dimensions

Coverage must be tracked for:

- each Rule;
- each catalog;
- each outcome;
- each confidence value;
- each contextual severity range;
- strong evidence;
- partial evidence;
- nominal evidence;
- contradictory evidence;
- absence of evidence;
- applicability;
- legitimate absence;
- insufficient evidence;
- false positive;
- false negative;
- shared evidence;
- overlap;
- gap;
- internal boundary;
- cross-catalog boundary;
- remediation;
- regression;
- determinism.

## 3. Rule Coverage

Rule coverage records whether each Rule has planned and executed scenarios for compliance, violation, warning, non-applicability, insufficient evidence, false-positive control, false-negative control, and boundary behavior.

| Rule | Positive | Violation | Warning | N/A | NEE | False Positive | False Negative | Boundary | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |

## 4. Catalog Coverage

Catalog coverage records whether each catalog has scenario coverage across its Rule responsibilities and boundaries.

| Catalog | Rules | Planned Scenarios | Executed Scenarios | Passed | Failed | Blocked | Status |
| --- | --- | --- | --- | --- | --- | --- | --- |

## 5. Outcome Coverage

Outcome coverage records whether scenarios exist and have been executed for every official outcome.

| Outcome | Planned Scenarios | Executed Scenarios | Status |
| --- | --- | --- | --- |

Required outcomes are `Pass`, `Fail`, `Warning`, `Not Applicable`, and `Not Enough Evidence`.

## 6. Confidence Coverage

Confidence coverage records whether scenarios validate every official confidence value.

Required confidence values are `Confirmed`, `Likely`, `Possible`, and `Not Enough Evidence`.

Coverage must verify that confidence follows evidence strength and that naming alone does not create `Confirmed` confidence.

## 7. Severity Coverage

Severity coverage records whether scenarios validate contextual severity assignment.

Coverage must include low, medium, high, or equivalent contextual severity expectations when supported by existing report vocabulary, without defining universal severity for any Rule, catalog, technology, or scenario category.

## 8. Evidence Coverage

Evidence coverage records whether scenarios cover:

- strong direct evidence;
- partial evidence;
- nominal or naming-based evidence;
- contradictory evidence;
- absent evidence;
- provided evidence;
- withheld evidence;
- manual evidence;
- automated evidence;
- document evidence;
- mixed evidence.

## 9. Applicability Coverage

Applicability coverage records whether scenarios validate:

- `Applicable`;
- `Not Applicable`;
- `Undetermined`;
- applicability before outcome;
- legitimate non-selection;
- relevant Rule with insufficient material.

## 10. Legitimate Absence Coverage

Legitimate absence coverage records scenarios where absence of an artifact, architecture style, pattern, test, automation, framework, technology, or mechanism is valid in context.

These scenarios protect ArchInspector from universal prescriptions.

## 11. Insufficient Evidence Coverage

Insufficient evidence coverage records scenarios where available material cannot support a conclusion.

These scenarios must validate `Not Enough Evidence`, explicit unknowns, withheld material, partial scope, weak evidence, and conflicting evidence.

## 12. False Positive Coverage

False-positive coverage records scenarios where ArchInspector must avoid reporting prohibited findings.

Coverage must include compliant alternatives, legitimate absence, partial scope, weak naming signals, governed exceptions, and cross-catalog overlap.

## 13. False Negative Coverage

False-negative coverage records scenarios where ArchInspector must detect required findings despite misleading or incomplete signals.

Coverage must include hidden boundary violations, broad exceptions, empty or incomplete verification scope, naming camouflage, and shared evidence.

## 14. Internal Boundary Coverage

Internal boundary coverage records scenarios where related Rules within one catalog share evidence but retain distinct responsibilities.

| Boundary | Scenario | Expected Behavior | Status |
| --- | --- | --- | --- |

## 15. Cross-Catalog Boundary Coverage

Cross-catalog boundary coverage records scenarios where multiple catalogs may be relevant but one primary Rule owns the finding.

Coverage must preserve boundaries among Hexagonal Architecture, Clean Architecture, Domain-Driven Design, SOLID, Layered Architecture, Fowler Patterns, Events and Messaging, Architecture Testing, and Solution Architecture.

## 16. Finding Coverage

Finding coverage records whether scenarios validate:

- atomic findings;
- required findings;
- forbidden findings;
- expected non-findings;
- duplicate prevention;
- correct primary Rule;
- evidence traceability;
- scope;
- reasoning;
- impact;
- recommendation;
- trade-offs;
- references.

## 17. Remediation Coverage

Remediation coverage records whether scenarios validate proportional, evidence-derived remediation.

Coverage must ensure remediation avoids unrelated redesign, mandatory technology, mandatory automation, fixed thresholds, universal prescriptions, and recommendations without findings.

## 18. Execution Coverage

Execution coverage records whether scenarios cover allowed execution types:

- `Static Fixture`;
- `Executable Fixture`;
- `Document Fixture`;
- `Mixed Fixture`;
- `Manual Evaluation`.

No execution type is universally required for every Rule.

## 19. Regression Coverage

Regression coverage records scenarios that protect previously accepted expected behavior.

Coverage must track whether changes to expected results, scenario artifacts, or evaluation behavior are traceable, reviewed, and stabilized.

## 20. Coverage Gaps

Coverage gaps must be recorded explicitly.

| Gap ID | Dimension | Description | Impact | Priority | Planned Scenario | Status |
| --- | --- | --- | --- | --- | --- | --- |

Gaps may be planned, blocked, intentionally external, or unresolved. A gap must not be hidden by scoring or percentage summaries.

## 21. Coverage Status

Allowed coverage status values are:

- `Not Planned`;
- `Planned`;
- `Partially Covered`;
- `Covered`;
- `Blocked`;
- `Intentionally External`.

Coverage status must be assigned per dimension and must remain traceable to scenarios and expected results.

## 22. Change Notes

Coverage change notes must record meaningful changes to dimensions, scenario mappings, gap inventory, status, or accepted external exclusions.

Change notes must not silently remove coverage obligations or redefine Rule and catalog responsibilities.
