# Rule ID

TEST-001

# Title

Architecture fitness function definition

# Category

Architecture Testing

# Status

Active

# Intent

Evaluate whether a declared architecture fitness function protects a real architectural characteristic through a clearly defined, verifiable, and interpretable mechanism.

# Applicability

Apply this rule when the reviewed material contains a declared fitness function, a mechanism named as a fitness function, a test claimed to be architectural, a metric used as an architectural control, an architecture gate, a recurring verification of an architectural characteristic, an automated policy, a repeatable manual control, documentation that assigns an architectural verification role to a mechanism, a claim of protection against architecture drift, or a claim of continuous architecture validation.

The rule may apply to automated or manual mechanisms. The mechanism may be static or dynamic, executable in code or performed through a repeatable process, and may use tests, metrics, analysis, observation, review, or operational evidence. Fitness function applicability depends on the declared architectural control role, not on a specific tool, framework, pipeline, programming language, or execution location.

Do not apply this rule merely because tests, metrics, dashboards, CI jobs, static analysis tools, documentation, or architectural terminology exist. The rule is relevant only when the reviewed evidence shows that a mechanism is declared, presented, or depended on as a fitness function or equivalent architectural verification control.

Use `Not Applicable` when no fitness function or equivalent architectural control is declared or alleged in the reviewed scope, when the scope does not include architecture verification mechanisms, when the architectural decision does not require repeated verification, when validation is exploratory and does not claim a control function, or when absence of a fitness function is legitimate for the reviewed context.

Legitimate absence may occur in small systems, temporary systems, prototypes, low-risk decisions, properties that are not repeatably verifiable, deliberate manual validation contexts, controls maintained outside the repository, architectural decisions that are not yet stabilized, partial review scopes, or contexts with no operational need for a recurring architectural verification. These situations are contextual signals, not automatic exemptions.

# Rule Statement

A declared architecture fitness function must identify a real architectural characteristic, state the architectural objective and protected property, define a verifiable evaluation criterion, and produce a result that can be interpreted as conformance, deviation, or need for further architectural analysis.

# Rationale

Architecture fitness functions help keep important architectural characteristics visible over time. When a mechanism is called a fitness function but does not identify the architectural property it protects, reviewers and teams can gain false confidence from tests, metrics, dashboards, or documentation that do not actually verify architectural intent.

The architectural risk is definitional and interpretive. A technical test, metric, convention, or manual check may be useful, but it becomes an architecture fitness function only when its architectural purpose, protected characteristic, verification criterion, and interpretable conclusion are clear enough to support evidence-driven review.

This rule does not require every system to have a fitness function. It does not require automation, code, a pipeline, a threshold, a metric, a static analysis tool, a test framework, execution on every commit, complete coverage, or a formal ADR. It evaluates only whether a declared or alleged fitness function is architecturally defined well enough to support a defensible conclusion.

# Evidence Required

Evaluation requires traceable evidence identifying the declared fitness function or equivalent mechanism, the architectural characteristic it claims to protect, the architectural objective, the protected property, the verification criterion, the produced result, and the intended interpretation of that result.

Primary evidence includes executable implementation of the fitness function, explicit definition of the architectural characteristic, evaluation criteria, produced results, conditions for conformance, conditions for violation, positive and negative verification cases, tests of the mechanism itself, historical executions, execution configuration, documentation of intent, related architectural decisions or ADRs, and naming only as supporting evidence.

Evidence should establish whether the mechanism evaluates an architectural property rather than only a technical behavior, whether the property is tied to a risk, decision, constraint, principle, or quality attribute, whether the criterion can be observed or repeated, and whether the output can support an architectural conclusion.

Evidence should distinguish a fitness function from ordinary unit tests, integration tests, smoke tests, style checks, generic metrics, dashboards, comments, documentation-only intentions, empty test methods, ignored tests, assertions that cannot fail, pipeline jobs without meaningful execution, and tooling installed without a defined architectural interpretation.

When evidence exists at multiple levels, prefer the following order of strength:

1. Executable or repeatable implementation of the fitness function.
2. Explicit definition of the architectural characteristic.
3. Evaluation criterion.
4. Produced or observable result.
5. Condition of conformance.
6. Condition of violation.
7. Positive verification cases.
8. Negative verification cases.
9. Tests or checks of the verification mechanism itself.
10. Historical execution records.
11. Execution configuration.
12. Documentation of architectural intent.
13. ADR or related decision record.
14. Names, folders, comments, labels, and conventions as auxiliary support only.

Naming such as `ArchitectureTests`, `FitnessFunctions`, `ArchitecturalGate`, or equivalent labels must not produce `Confirmed` confidence without corroborating evidence from implementation, criteria, execution, documentation, or decision material.

# Evaluation Guidance

First determine whether the reviewed material declares or alleges a fitness function or equivalent architectural verification control. If no such mechanism or claim exists, evaluate whether the rule is `Not Applicable` rather than treating absence as failure.

Evaluate the definition of the fitness function, not the full correctness of the underlying architecture. The central question is whether the declared mechanism protects a real architectural characteristic through a clearly defined and interpretable verification. A valid fitness function may still have weak traceability, narrow scope, unreliable selectors, false positives, false negatives, poor diagnostics, weak execution timing, or maintainability issues that belong to neighboring Architecture Testing rules.

Treat a fitness function as a mechanism that can continuously or repeatedly evaluate an architectural characteristic. It may be automated or manual, static or dynamic, executed locally, in review, in CI/CD, in operations, or at another meaningful point. It may use tests, metrics, analysis, observation, review procedure, or operational process. Do not reduce the concept to unit tests, architecture test libraries, static analysis, CI pipelines, source code, thresholds, dashboards, monitoring, or any named tool.

Determine whether the mechanism has an architectural objective and protected property. A technical test may support architecture, but this rule should not pass it as a fitness function unless the reviewed evidence connects it to an architectural characteristic, risk, decision, constraint, principle, or quality attribute and explains what the mechanism protects.

Determine whether the criterion is verifiable. A criterion may be qualitative or manual when it is repeatable enough to support consistent interpretation. Do not require a numeric threshold, percentage, metric, static rule, executable test, or automated assertion unless the reviewed architecture itself depends on that form.

Determine whether the result is interpretable. A result is interpretable when a reviewer can understand what success, failure, deviation, or need for analysis means architecturally. A raw metric, green test, dashboard value, review note, or tool report is insufficient when it lacks an architectural interpretation.

Common finding shapes include:

- Fitness function without architectural characteristic: expected evidence is a stated architectural characteristic or quality attribute; the problem is that the mechanism is called a fitness function without defining what it protects; the impact is false architectural coverage; false-positive risk is failing a low-risk mechanism whose protected property is documented elsewhere in reviewed scope; false-negative risk is accepting naming as definition; remediation is to state the protected characteristic and connect it to the mechanism.
- Technical test presented as architectural control: expected evidence is a technical test plus its architectural objective; the problem is that a common test is presented as architecture verification without a protected architectural property; the impact is misleading confidence about architecture; false-positive risk is rejecting a technical test that genuinely protects an architectural constraint; false-negative risk is accepting ordinary assertions as architectural validation; remediation is to either define the architectural property or remove the architectural claim.
- Metric without architectural interpretation: expected evidence is a metric, its architectural purpose, and interpretation rules; the problem is that measurement exists without a conclusion about conformance or deviation; the impact is unreviewable architecture control; false-positive risk is demanding a numeric threshold where qualitative interpretation is sufficient; false-negative risk is accepting a dashboard as a fitness function; remediation is to document how the metric informs architectural decisions.
- Nominal architecture test: expected evidence is a class, method, suite, or check with effective selection and assertion; the problem is architectural naming without meaningful verification; the impact is false sense of protection; false-positive risk is missing effective verification located through helpers or generated configuration; false-negative risk is accepting empty or ignored tests; remediation is to add effective verification or rename the artifact to match its real role.
- Undefined success condition: expected evidence is a condition that explains architectural conformance; the problem is execution without a defined successful architectural meaning; the impact is ambiguous pass signals; false-positive risk is failing a mechanism whose success meaning is evident in adjacent documentation; false-negative risk is accepting green execution as architectural success; remediation is to define what success means for the protected property.
- Undefined violation condition: expected evidence is a condition that explains architectural deviation; the problem is the mechanism does not define what constitutes drift or violation; the impact is missed or disputed findings; false-positive risk is requiring exhaustive violation catalogs; false-negative risk is accepting a check that cannot identify deviation; remediation is to define observable violation conditions.
- Documentation-only fitness function: expected evidence is documentation plus a repeatable verification mechanism; the problem is intent without a mechanism; the impact is architectural control that cannot be evaluated; false-positive risk is rejecting a deliberate manual control documented outside code; false-negative risk is accepting aspiration as verification; remediation is to define a repeatable manual or automated mechanism.
- Mechanism unrelated to declared objective: expected evidence is the declared objective and implemented verification behavior; the problem is that the mechanism measures or checks something different from the protected property; the impact is undetected drift in the intended characteristic; false-positive risk is overlooking indirect but valid proxy evidence; false-negative risk is accepting coherent-looking checks that protect the wrong property; remediation is to align the mechanism with the objective or restate the objective.
- Empty or ineffective assertion: expected evidence is assertion or decision logic capable of distinguishing conformance from violation; the problem is a mechanism that executes without an effective conclusion; the impact is persistent false pass results; false-positive risk is missing assertions embedded in helper code; false-negative risk is accepting always-true checks; remediation is to add effective decision logic or remove the fitness function claim.
- Uninterpretable result: expected evidence is output plus interpretation guidance; the problem is that the result exists but cannot drive an architectural conclusion; the impact is delayed or inconsistent response to drift; false-positive risk is demanding more interpretation than the reviewed risk needs; false-negative risk is accepting raw output as sufficient; remediation is to make the conclusion explicit and proportionate.

Remediation guidance should be proportional to the evidence. Suitable remediation includes explicitly stating the architectural characteristic, relating the mechanism to a real risk or decision, defining conformance, defining violation, making the result interpretable, replacing naming-only claims with effective verification, adding positive and negative cases when useful, separating metrics from their interpretation, documenting limitations, making manual validation repeatable when appropriate, preserving adequate manual controls, and avoiding artificial automation when it does not improve architectural assurance.

Do not prescribe a specific language, test framework, architecture testing tool, CI/CD platform, pipeline gate, dashboard, monitoring tool, metric type, numeric threshold, unit test, static analysis approach, formal ADR, or production-code implementation as remediation for this rule.

Keep internal Architecture Testing boundaries explicit:

- `TEST-001` evaluates whether the fitness function has a valid architectural definition; `TEST-002` evaluates traceability to a decision, constraint, risk, or principle.
- `TEST-001` evaluates the general definition of the fitness function; `TEST-003` evaluates whether a specific architectural constraint is objective and testable.
- `TEST-001` does not conclude whether the analyzed universe is complete; `TEST-004` evaluates architecture test scope.
- `TEST-001` evaluates definition; `TEST-011` evaluates whether verification has real behavioral or architectural-quality relevance beyond superficial structure.
- `TEST-001` may identify an inadequately defined mechanism; `TEST-012` systematically evaluates false-positive control.
- `TEST-001` may identify an ineffective mechanism; `TEST-013` systematically evaluates false-negative control.
- `TEST-001` does not require pipeline execution; `TEST-018` evaluates delivery-flow execution timing and context.
- `TEST-001` accepts automated and manual mechanisms; `TEST-020` evaluates the overall balance between automated and manual validation.

Keep cross-catalog boundaries explicit. Do not use this rule to conclude on global architecture quality, modularity, coupling, cohesion, maintainability, or architecture drift outside the declared verification mechanism. Do not redefine Hexagonal ports, adapters, drivers, driven actors, inside or outside boundaries, Clean Architecture dependency rules, DDD aggregates, entities, value objects, domain services, repositories, bounded contexts, Layered dependency direction, Fowler patterns, Events and Messaging semantics, SOLID principles, or Solution Architecture decisions. A fitness function may verify those properties, but this rule concludes only on whether the fitness function itself is architecturally defined, verifiable, and interpretable.

# Pass Conditions

Use `Pass` when the reviewed evidence is sufficient to identify a declared fitness function or equivalent architectural verification mechanism and supports that it protects a real architectural characteristic.

Use `Pass` when the architectural objective is explicit, the protected property can be understood, the mechanism has a verifiable criterion, the result can be interpreted, and the conclusion about conformance, deviation, or need for analysis is coherent with the reviewed evidence.

Use `Pass` when the mechanism is manual, qualitative, dynamic, static, local, operational, document-supported, or not implemented as code, provided it is repeatable enough for the reviewed context and its architectural interpretation is clear.

Do not require automation, CI/CD, a named tool, a test framework, a percentage, a numeric threshold, execution on every commit, total coverage, zero exceptions, or source-code implementation for `Pass`.

# Fail Conditions

Use `Fail` only when applicability is confirmed, evidence is sufficient, a fitness function or equivalent architectural control is declared or alleged, and direct evidence shows that the mechanism fails the central responsibility of this rule with relevant architectural impact.

Use `Fail` when the declared fitness function lacks a real architectural characteristic, lacks an architectural objective, fails to define the protected property, has no verifiable criterion, produces an uninterpretable result, is purely nominal, or cannot evaluate the property it claims to protect.

Use `Fail` when a technical test is presented as an architectural control without any defined architectural property, when a metric is treated as architectural validation without architectural interpretation, when documentation claims a fitness function but no repeatable verification mechanism exists, or when the mechanism verifies a materially different property from the declared architectural objective.

Do not use `Fail` merely because there is no automation, no pipeline, no tool, no ADR, no threshold, no architecture-testing library, no source-code implementation, no execution on every commit, no static test, or because the mechanism uses a different technology or manual process than expected.

# Warning Conditions

Use `Warning` when evidence shows a plausible fitness function or architectural control whose definition is partial, inconsistent, fragile, or ambiguous, but the material does not justify a definitive `Fail`.

Use `Warning` when the architectural intention is plausible but incomplete, the protected characteristic is implicit, the mechanism exists but the interpretation is ambiguous, criteria are only partially verifiable, documentation carries too much of the meaning, or the function has architectural value but does not yet support a robust conclusion.

Use `Warning` when there is evidence of limited risk from weak definition, unclear success or violation meaning, indirect architectural connection, or fragile interpretation, and the available evidence is strong enough to identify risk but not strong enough to confirm failure.

Do not use `Warning` as a substitute for `Not Enough Evidence`. If the reviewed material cannot establish the mechanism, property, criterion, or result well enough to identify a risk, use `Not Enough Evidence`.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope contains no declared fitness function, no alleged architecture verification mechanism, no architecture control claim, and no reviewed material that presents a test, metric, gate, dashboard, process, or policy as architectural validation.

Use `Not Applicable` when the reviewed scope does not include architecture tests or validation mechanisms, when the architectural property does not require repeated verification, when validation is purely exploratory without control intent, or when the decision under review does not justify a fitness function.

Use `Not Applicable` when absence of a fitness function is legitimate and confirmed within the reviewed context, such as a small system, temporary system, prototype, low-risk decision, non-repeatably verifiable property, deliberate manual validation approach, externally governed control, unstabilized architectural decision, partial analysis scope, or absence of operational need.

`Not Applicable` means this rule is outside the reviewed context. It does not mean the architecture is approved, complete, low-risk, or free from drift.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the reviewed material does not provide enough evidence to determine whether the declared mechanism is a fitness function, what architectural characteristic it protects, what objective it has, what property is evaluated, what criterion is applied, what result is produced, or how the result should be interpreted.

Use `Not Enough Evidence` when there is an architectural verification claim but the implementation is unavailable, the test cannot be inspected or executed when execution is necessary, the metric lacks supporting context, the real scope cannot be determined, the result is unavailable, relevant files or configuration are outside scope, or documentation and implementation signals conflict.

Use `Not Enough Evidence` when only names, folders, comments, isolated README text, tool presence, pipeline configuration without meaningful execution evidence, skipped tests, empty methods, future intentions, or convention statements are available.

Do not convert absence of evidence into `Fail`. If evidence is insufficient to confirm either a valid definition or a violated definition, keep the limitation visible through `Not Enough Evidence`.

# Severity Guidance

Assign severity from demonstrated architectural impact within the reviewed scope. Do not assign fixed severity for this rule and do not map `Fail` automatically to high severity.

Severity increases when a poorly defined or nominal fitness function concerns a critical architectural characteristic, protects a high-risk decision, creates broad false coverage, affects many modules or services, recurs across verification mechanisms, allows costly regressions, increases operational, security, regulatory, or financial risk, or becomes the organization's primary evidence of architectural conformance.

Severity also increases when alternative detection is weak, recovery from undetected drift is expensive, results are trusted for release or governance decisions, or the mechanism creates a strong false sense of conformance.

Severity may be medium or low when the mechanism is narrow, local, experimental, low-risk, easy to inspect manually, supported by other reliable controls, or weakly claimed as architectural validation with limited organizational dependence.

Informational severity may be appropriate when the issue is limited to minor wording or documentation ambiguity and the reviewed evidence still supports a clear architectural interpretation.

# Confidence Guidance

Use `Confirmed` when direct, traceable evidence establishes the declared fitness function or equivalent control, the architectural characteristic, the objective, the protected property, the verification criterion, the result, and the interpretation needed to support the selected outcome.

Use `Likely` when multiple consistent evidence points support the evaluation but some direct confirmation is incomplete, such as missing execution history, incomplete documentation, or partial visibility into implementation details that are not essential to the conclusion.

Use `Possible` when evidence is limited, indirect, naming-based with partial corroboration, structurally suggestive, or enough only to identify a potential definition problem or plausible valid mechanism.

Use `Not Enough Evidence` when the available material cannot support a useful confidence level because the mechanism, property, criterion, execution, result, interpretation, or scope is missing, opaque, conflicting, or outside the reviewed material.

Do not confuse confidence with outcome or severity. A low-severity issue may be `Confirmed`, and a potentially serious concern may remain `Possible` or `Not Enough Evidence` when evidence is incomplete. Naming, folders, comments, installed tools, or green test status alone must not produce `Confirmed` confidence.

# Dependencies

TEST-002, TEST-003, TEST-004, TEST-011, TEST-012, TEST-013, TEST-018, TEST-020. These are related Architecture Testing rules with adjacent responsibilities, not procedural prerequisites.

`TEST-002` owns traceability to a decision, constraint, risk, or principle. `TEST-003` owns objective testability of a specific architectural constraint. `TEST-004` owns architecture verification scope. `TEST-011` owns behavioral or architectural-quality relevance of the verification. `TEST-012` owns systematic false-positive control. `TEST-013` owns systematic false-negative control. `TEST-018` owns execution timing and delivery-flow integration. `TEST-020` owns the overall balance between automated and manual validation.

# References

RULE_MODEL.md

SPECIFICATION.md

TAXONOMY.md

ARCHITECTURE_TESTING_CATALOG.md

Neal Ford, Rebecca Parsons, and Patrick Kua, *Building Evolutionary Architectures*.

Mark Richards and Neal Ford, *Fundamentals of Software Architecture*.

# Change Notes

Initial creation of `TEST-001`.

Defined as the Gold Standard Rule for the Architecture Testing catalog.

Aligned with `ARCHITECTURE_TESTING_CATALOG.md`.

Aligned with `RULE_MODEL.md`.

Aligned with `SPECIFICATION.md`.

Aligned with `TAXONOMY.md`.
