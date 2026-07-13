# Rule Specification

## Purpose

This document defines the official structure for architectural rules in ArchInspector.

A rule describes one reusable architectural condition that can be evaluated against reviewed material. Rules must be generic enough to support evidence-driven review and specific enough to produce consistent evaluation results.

This specification governs rule documents only. It does not define knowledge content, examples, evaluation assets, scoring, report templates, or review output.

## Rule Document Requirements

Each rule must be stored as one Markdown document.

Each rule document must contain exactly one rule.

Each rule document must follow the field order defined in this specification.

Each rule document must use stable headings so that rules can be read consistently by humans and automation.

Rules must not depend on examples, report templates, evaluation scenarios, or scoring formulas to be understandable.

## Official Field Order

Rule fields must appear in this exact order:

1. Rule ID
2. Title
3. Category
4. Status
5. Intent
6. Applicability
7. Rule Statement
8. Rationale
9. Evidence Required
10. Evaluation Guidance
11. Pass Conditions
12. Fail Conditions
13. Warning Conditions
14. Not Applicable Conditions
15. Not Enough Evidence Conditions
16. Severity Guidance
17. Confidence Guidance
18. Dependencies
19. References
20. Change Notes

No additional top-level fields may appear before, between, or after the official fields.

## Required Fields

The following fields are mandatory for every rule:

- Rule ID
- Title
- Category
- Status
- Intent
- Applicability
- Rule Statement
- Rationale
- Evidence Required
- Evaluation Guidance
- Pass Conditions
- Fail Conditions
- Warning Conditions
- Not Applicable Conditions
- Not Enough Evidence Conditions
- Severity Guidance
- Confidence Guidance

Mandatory fields must not be empty.

Mandatory fields must contain rule-specific content, not placeholder text.

## Optional Fields

The following fields are optional:

- Dependencies
- References
- Change Notes

Optional fields must still appear in the official field order.

If an optional field has no content, it must contain `None`.

## Field Definitions

### Rule ID

Defines the stable identifier of the rule.

The Rule ID must be unique across the complete rule catalog.

The Rule ID must remain stable after publication. If the meaning of a rule changes substantially, create a new rule instead of reusing the same Rule ID.

### Title

Defines the human-readable name of the rule.

The title must describe the architectural condition being evaluated.

The title must be concise, specific, and neutral.

The title must not contain the Rule ID.

### Category

Defines the review area or rule family that owns the rule.

The category must match an approved rule catalog category.

The category must not introduce new review areas by itself.

### Status

Defines the lifecycle state of the rule document.

Allowed values are:

- `Draft`
- `Active`
- `Deprecated`

`Draft` means the rule is not yet part of the official review catalog.

`Active` means the rule may be selected and evaluated during reviews.

`Deprecated` means the rule is retained for traceability but must not be selected for new reviews.

### Intent

Explains why the rule exists.

The intent must describe the architectural concern the rule is meant to protect or evaluate.

The intent must not prescribe implementation details unless they are essential to the rule.

### Applicability

Defines when the rule should be considered for selection.

Applicability must describe the scope, system context, or reviewed material needed for the rule to be relevant.

Applicability must not assume facts that must instead be proven through evidence.

### Rule Statement

Defines the normative condition of the rule.

The rule statement must be direct, testable, and written as one architectural requirement.

The rule statement must avoid ambiguous qualifiers such as "proper", "good", "clean", "appropriate", or "best practice" unless they are explicitly defined inside the rule.

### Rationale

Explains the architectural reason behind the rule.

The rationale must describe the risk, maintainability concern, boundary concern, or design consequence addressed by the rule.

The rationale must not duplicate the rule statement.

### Evidence Required

Defines the evidence needed to evaluate the rule.

Evidence requirements must be concrete and traceable to reviewed material.

Evidence requirements may include structural, dependency, naming, configuration, behavioral, or documentation signals when relevant.

Evidence requirements must distinguish direct evidence from weaker supporting signals when that distinction affects confidence.

### Evaluation Guidance

Explains how to reason from evidence to a status.

Evaluation guidance must describe how evidence should be interpreted conservatively.

Evaluation guidance must identify common ambiguity points that affect status or confidence.

Evaluation guidance must not require external assumptions about team intent, undocumented conventions, or unavailable material.

### Pass Conditions

Defines the conditions that support a `Pass` evaluation.

Pass conditions must require evidence that the rule is satisfied within the reviewed scope.

Pass conditions must not rely only on absence of contrary evidence unless the reviewed scope is sufficient to support that conclusion.

### Fail Conditions

Defines the conditions that support a `Fail` evaluation.

Fail conditions must require evidence that the rule is violated or that the architectural risk described by the rule is present within the reviewed scope.

Fail conditions must be specific enough to separate a confirmed issue from a weak signal.

### Warning Conditions

Defines the conditions that support a `Warning` evaluation.

Warning conditions must describe partial, inconsistent, weak, emerging, or ambiguous risks that do not justify a definitive `Fail`.

Warning conditions must not be used as a substitute for `Not Enough Evidence`.

### Not Applicable Conditions

Defines the conditions that support a `Not Applicable` evaluation.

Not applicable conditions must explain when the rule is outside the reviewed scope, system context, or selected review area.

Not applicable conditions must not be used when the rule is relevant but evidence is missing.

### Not Enough Evidence Conditions

Defines the conditions that support a `Not Enough Evidence` evaluation.

Not enough evidence conditions must describe missing, incomplete, indirect, conflicting, or insufficient material that prevents evaluation.

Not enough evidence conditions must be preferred over speculation.

### Severity Guidance

Defines how severity should be assigned when the rule produces a finding.

Severity guidance must connect severity to architectural impact within the reviewed scope.

Severity guidance must not define numeric scoring.

Severity guidance must not assign severity solely from the rule category.

### Confidence Guidance

Defines how confidence should be assigned when evaluating the rule.

Confidence guidance must explain which evidence supports stronger or weaker confidence.

Confidence guidance must follow the official confidence levels used by ArchInspector.

Confidence guidance must not allow naming alone to produce the strongest confidence level.

### Dependencies

Lists other rules that should be considered before or alongside this rule.

Dependencies must reference rule identifiers, not file paths.

Dependencies must not create circular evaluation requirements.

Use `None` when the rule has no dependencies.

### References

Lists supporting internal references that help interpret the rule.

References may point to approved knowledge material or other rule material.

References must not be required to understand the rule's mandatory fields.

Use `None` when the rule has no references.

### Change Notes

Records meaningful changes to the rule after initial creation.

Change notes must describe what changed and why.

Change notes must not include review findings or project-specific observations.

Use `None` when there are no change notes.

## Naming Conventions

Rule IDs must use uppercase ASCII letters, digits, and hyphens only.

Rule IDs must follow this shape:

`CATEGORY-NNN`

`CATEGORY` must be the approved category prefix.

`NNN` must be a three-digit sequence number starting at `001` within the category.

Rule filenames must match the Rule ID exactly and use the `.md` extension.

Rule titles must use sentence case.

Rule field headings must match the names in this specification exactly.

Rule documents must use plain Markdown and must not require custom rendering.

## Content Restrictions

Rules must be written as reusable review criteria, not as findings.

Rules must not describe a specific project, repository, team, organization, or review result.

Rules must not include examples.

Rules must not include knowledge explanations that belong in the knowledge base.

Rules must not include report template text.

Rules must not include scoring formulas.

Rules must not include evaluation fixtures, scenarios, expected findings, or expected scores.

Rules must not introduce new supported review areas.

Rules must not require evidence that ArchInspector is not allowed to claim or inspect.

Rules must not convert naming conventions into direct proof unless corroborating evidence is also required.

## Consistency Principles

Rules must use the official status vocabulary consistently.

Rules must use the official confidence vocabulary consistently.

Rules must separate applicability from evidence.

Rules must separate evidence requirements from evaluation conclusions.

Rules must define `Pass`, `Fail`, `Warning`, `Not Applicable`, and `Not Enough Evidence` conditions explicitly.

Rules must make missing evidence visible instead of implying a result.

Rules within the same category must use consistent terminology for the same concepts.

Rules must avoid overlapping responsibilities. If two rules evaluate related concerns, each rule must define its distinct evaluation boundary.

Rules must be independently understandable without requiring another rule, except for explicitly declared dependencies.

Rules must preserve stable meaning over time.

## Editorial Validation

Before a rule is accepted into the catalog, verify that:

- all official fields appear in the required order;
- all mandatory fields contain rule-specific content;
- optional empty fields contain `None`;
- the Rule ID is unique;
- the filename matches the Rule ID;
- the category and category prefix are approved;
- the rule statement is testable;
- the rule defines all evaluation outcomes;
- evidence requirements are concrete and traceable;
- confidence guidance is conservative;
- the rule does not contain examples;
- the rule does not contain knowledge, scoring, templates, or evaluation assets;
- the rule does not modify or expand the supported review areas.
