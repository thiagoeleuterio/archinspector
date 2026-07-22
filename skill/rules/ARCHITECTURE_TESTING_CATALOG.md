# Architecture Testing Rule Catalog

## 1. Identity

Catalog: `Architecture Testing`

Official category: `Architecture Testing`

Official prefix: `TEST`

Rule range: `TEST-001` through `TEST-020`

Total planned Rules: 20

Future Rule directory: `skill/rules/testing/`

`TAXONOMY.md` defines `Architecture Testing` as the official category and `TEST` as the official prefix. No alternate prefix is used by this catalog.

This catalog is an inventory and planning artifact. It does not create complete Rule documents, findings, recommendations, examples, evaluation assets, templates, production code, reviews, stabilizations, or numeric ratings.

## 2. Purpose

This catalog defines the planned official Architecture Testing rules for ArchInspector.

The catalog identifies candidate rule identities, titles, responsibilities, evidence expectations, overlap boundaries, and coverage responsibilities for evidence-driven review of architecture tests, architecture fitness functions, structural conformance checks, dependency rules, boundary checks, exceptions, baselines, regression detection, and validation workflows.

Architecture Testing evaluates how an architectural decision, constraint, principle, or risk is verified. It does not re-evaluate the underlying architectural decision as its primary conclusion.

## 3. Scope

Architecture Testing rules evaluate verification mechanisms for architectural constraints, including:

- architecture fitness functions;
- architecture tests;
- dependency rules;
- structural constraints;
- module boundaries;
- namespace boundaries;
- forbidden dependencies;
- allowed dependencies;
- cyclic dependency detection;
- architecture test reliability;
- architecture test scope;
- architecture test evidence;
- pipeline integration;
- failure reporting;
- exception governance;
- baseline management;
- regression detection;
- test maintainability;
- test ownership;
- architecture conformance drift;
- balance between automated and manual validation.

This catalog does not make architecture tests, automation, a pipeline gate, a specific tool, a framework, a language, a coverage percentage, a minimum number of tests, a zero-baseline policy, a zero-suppression policy, or a fixed execution frequency universally required.

## 4. Principles

Rules in this catalog must remain:

- atomic: each rule evaluates one architecture-verification concern;
- evidence-driven: conclusions must be supported by reviewed material;
- technology-neutral: no rule requires ArchUnit, NetArchTest, dependency-cruiser, Sonar, NDepend, a specific CI product, or any equivalent named tool;
- context-aware: absence of an architecture test can be legitimate and may be `Not Applicable`;
- proportionate: verification expectations must follow architectural risk and review scope;
- independently evaluable: shared evidence may exist, but each rule must produce its own conclusion;
- outcome-complete: each future rule must support `Pass`, `Fail`, `Warning`, `Not Applicable`, and `Not Enough Evidence`;
- stable: published rule meaning must not shift to absorb the underlying architecture rule being verified.

Automation is not universally superior to manual analysis. Some architectural properties are not statically checkable. A green test does not prove conformance when the tested constraint, scope, selection, or assertion is incomplete.

## 5. Applicability Model

An Architecture Testing rule may be applicable when the reviewed material contains or claims:

- a declared fitness function;
- an architecture test;
- a structural test;
- a dependency test;
- an automated conformance check;
- an architecture-related pipeline gate;
- an architectural baseline;
- a suppression, exclusion, or exception;
- an automated architectural exception mechanism;
- a claim of automated architectural validation;
- an architectural decision whose risk justifies repeatable verification.

A rule may be `Not Applicable` when:

- no architecture verification mechanism is adopted in the reviewed scope;
- the architectural property is not reasonably automatable;
- the system does not have the corresponding architectural risk;
- manual validation is deliberate and sufficient for the reviewed risk;
- the reviewed scope does not include architecture tests or validation mechanisms;
- the architectural decision does not require recurring execution;
- absence of verification is legitimate and justified.

Absence of an architecture test is not an automatic failure.

## 6. Evidence Model

Future rules in this catalog must prioritize concrete, traceable evidence in this order when available:

1. Executable architecture test or fitness function.
2. Implemented rule logic.
3. Real selection of types, modules, namespaces, projects, dependencies, or flows.
4. Execution result.
5. Delivery-flow configuration for the verification when relevant.
6. Failure history.
7. Baselines.
8. Suppressions and exclusions.
9. Tests of the verification mechanism itself.
10. Positive and negative verification cases.
11. Architectural decisions or ADRs.
12. Documentation tied to the reviewed system.
13. Naming as supporting evidence only.

Presence of an architecture-testing library does not prove conformance. A file named `ArchitectureTests` does not prove coverage. A green architecture test in isolation does not prove that the rule represents the intended architectural decision.

## 7. Outcome Model

Each future rule must define distinct conditions for:

- `Pass`: reviewed evidence supports that the verification mechanism satisfies the rule responsibility within the relevant scope.
- `Fail`: reviewed evidence confirms that the verification mechanism is absent, misleading, ineffective, or unsafe where the rule is applicable and the architectural risk justifies the conclusion.
- `Warning`: reviewed evidence shows partial, inconsistent, fragile, or emerging verification risk that does not justify definitive failure.
- `Not Applicable`: the rule responsibility is legitimately outside the reviewed scope, system context, adopted validation approach, or architectural risk.
- `Not Enough Evidence`: the rule may be relevant, but reviewed material is missing, incomplete, indirect, conflicting, or too narrow.

`Warning` must not hide missing evidence. `Not Applicable` must not be used when the rule applies but material is unavailable.

## 8. Confidence Model

Confidence must follow the official ArchInspector confidence levels:

- `Confirmed`: direct, traceable evidence establishes the verification mechanism, scope, selected elements, execution behavior, and conclusion.
- `Likely`: multiple consistent evidence points support the evaluation, but some direct confirmation is incomplete.
- `Possible`: evidence is limited, indirect, naming-based with partial corroboration, or structurally suggestive.
- `Not Enough Evidence`: material cannot support a reliable conclusion.

Naming, folder layout, test class names, comments, tool presence, or isolated documentation must not produce `Confirmed` confidence without corroborating implementation, execution, configuration, or decision evidence.

## 9. Severity Model

Severity must be derived from demonstrated architectural impact in the reviewed scope.

Severity increases when weak verification can allow important boundary violations, dependency regressions, false delivery confidence, repeated architectural drift, uncontrolled exceptions, unreliable gates, or costly late discovery in critical areas.

Severity decreases when the verification concern is narrow, local, low-risk, intentionally manual, not recurring, or easy to inspect without automation.

No rule in this catalog assigns severity solely from category, tool choice, file name, execution location, failure count, percentage, fixed numeric limit, or rule sequence.

## 10. Internal Boundaries

Architecture Testing evaluates the verification mechanism, not the underlying architecture condition.

For example:

- a Layered Architecture rule owns which dependencies are allowed between layers;
- an Architecture Testing rule may evaluate whether a verification mechanism checks that dependency rule when the risk justifies it;
- a Hexagonal Architecture rule owns the boundary between core and adapters;
- an Architecture Testing rule may evaluate whether the claimed verification represents that boundary correctly;
- an Events and Messaging rule owns idempotency semantics;
- an Architecture Testing rule may evaluate whether a test or fitness function that claims to verify idempotency actually verifies the intended property.

The catalog must keep definition, traceability, testability, scope, dependency direction, forbidden dependency, allowed dependency precision, cycles, module boundaries, naming reliability, behavioral relevance, false positives, false negatives, determinism, diagnostics, exceptions, regression detection, pipeline timing, maintainability, and manual/automated balance as separate conclusions.

## 11. Cross-Catalog Boundaries

Core owns broad architectural quality, modularity, coupling, cohesion, maintainability, and drift outside a validation mechanism.

Hexagonal Architecture owns ports, adapters, inside/outside boundaries, driver and driven actors, and core isolation. Architecture Testing owns the adequacy of a verification mechanism for those decisions.

Clean Architecture owns the Dependency Rule, Entities, Use Cases, Interface Adapters, Frameworks and Drivers, gateways, presenters, controllers, boundary data, and flow of control. Architecture Testing owns verification of those constraints when verification is the primary concern.

Domain-Driven Design owns aggregates, entities, value objects, domain services, repositories, bounded contexts, context relationships, domain events as domain-model concepts, invariants, and domain language. Architecture Testing owns verification quality when a DDD constraint is tested or claimed as covered.

Layered Architecture owns layers, allowed dependency direction, bypassing, Presentation, Application, Domain, Infrastructure, data access, and layer contracts. Architecture Testing owns validation mechanisms for those layer rules.

Fowler Patterns owns Transaction Script, Domain Model, Table Module, Service Layer, Data Mapper, Repository, Unit of Work, Active Record, DTO, locking, and other Fowler pattern responsibilities. Architecture Testing owns verification of claimed conformance only when the test mechanism is the evaluated condition.

Events and Messaging owns Domain Events, Integration Events, delivery semantics, idempotency, ordering, retries, dead-letter handling, replay, publication consistency, and message contracts. Architecture Testing owns verification mechanisms for those claims.

SOLID owns SRP, OCP, LSP, ISP, DIP, responsibility boundaries, substitutability, interface segregation, and dependency inversion when the object-oriented principle is the primary condition.

Solution Architecture owns solution-level organization, project composition, deployment-relevant structure, cloud or vendor topology, enterprise integration, product selection, cost, and build-versus-buy decisions.

## 12. Rule Catalog

| ID | Title | Responsibility | Primary Evidence | Main False Positive Risk | Main False Negative Risk | Related Rules |
| --- | --- | --- | --- | --- | --- | --- |
| TEST-001 | Architecture fitness function definition | Evaluate whether a declared fitness function represents a relevant architectural characteristic, has a verifiable objective, and defines what it protects. | Fitness function definition, intended architectural property, executable or documented check, ADR. | Treating every architectural concern as requiring a fitness function. | Accepting a named fitness function that has no objective or protected property. | TEST-002, TEST-003, TEST-011 |
| TEST-002 | Architectural decision traceability | Evaluate whether an architectural verification has a traceable link to a real decision, constraint, principle, or risk. | ADRs, rule documentation, test names plus implementation, decision references, review scope. | Requiring a formal ADR for every useful verification. | Accepting a test with no architectural origin or risk connection. | TEST-001, TEST-003, TEST-004 |
| TEST-003 | Testable architectural constraint | Evaluate whether the verified architectural constraint is objective enough to produce a repeatable conclusion. | Constraint statement, expected outcome, selection criteria, assertion logic. | Rejecting valid manual or judgment-based constraints that are not statically checkable. | Accepting vague constraints that cannot be consistently evaluated. | TEST-001, TEST-002, TEST-004 |
| TEST-004 | Architecture test scope | Evaluate whether verification scope matches the systems, modules, components, dependencies, or flows covered by the architectural decision. | Selected projects, modules, namespaces, types, dependency graph, documented scope. | Failing a deliberately narrow test for not covering the whole system. | Green test with empty, stale, or incomplete selection. | TEST-002, TEST-003, TEST-005, TEST-009 |
| TEST-005 | Dependency rule verification | Evaluate whether dependency rules are verified with coherent direction, origin, destination, and exceptions. | Dependency rule implementation, graph query, source and target selectors, exception list. | Treating any dependency outside a simplistic direction as prohibited. | Missing indirect or incorrectly selected dependencies. | TEST-006, TEST-007, TEST-008, TEST-009 |
| TEST-006 | Forbidden dependency detection | Evaluate whether relevant forbidden dependencies can be detected beyond convention or informal review when risk justifies automation. | Forbidden dependency list, detection rule, failing case, dependency graph, exclusions. | Requiring automation for every forbidden dependency regardless of risk. | Undetected prohibited reference due to missing selector, ignored project, or weak convention. | TEST-005, TEST-009, TEST-016 |
| TEST-007 | Allowed dependency precision | Evaluate whether allowed dependency rules are not so broad that verification becomes ineffective. | Allow rules, selector breadth, dependency graph, examples of permitted and rejected dependencies. | Treating broad but intentional extension points as violations. | Rule permits effectively any dependency and hides violations. | TEST-005, TEST-012, TEST-013 |
| TEST-008 | Cyclic dependency detection | Evaluate whether architecturally relevant cycles are detected at the correct level without confusing legitimate implementation cycles with structural violations. | Cycle detection output, project/module graph, package/type graph, declared architecture level. | Failing technical cycles that are irrelevant to the architectural boundary. | Missing module-level or project-level cycles due to wrong analysis level. | TEST-005, TEST-004, TEST-013 |
| TEST-009 | Module boundary verification | Evaluate whether module, component, or architectural-unit boundaries are verified according to the defined architecture. | Module map, boundary rule, dependency or API checks, owned namespaces, public contracts. | Requiring a specific module packaging style. | New module or boundary-crossing path omitted from the verification. | TEST-004, TEST-005, TEST-006, TEST-010 |
| TEST-010 | Naming-based rule reliability | Evaluate whether checks based on namespaces, packages, folders, names, or textual patterns are reliable enough and do not replace stronger structural evidence when needed. | Naming selectors, namespace/package conventions, matched element list, structural corroboration. | Failing legitimate naming variations where structural evidence is stronger. | Test passes because names changed, selectors missed elements, or only text was checked. | TEST-009, TEST-012, TEST-013 |
| TEST-011 | Architecture test behavioral relevance | Evaluate whether architectural verification protects real behavior or architectural quality, not only superficial structure without impact. | Decision risk, affected behavior or quality attribute, test assertion, failure consequence. | Requiring every structural check to prove direct runtime behavior. | Accepting tests that check shape but do not protect the intended architectural risk. | TEST-001, TEST-002, TEST-019 |
| TEST-012 | Architecture test false-positive control | Evaluate whether verification avoids rejecting legitimate implementations that satisfy architectural intent differently. | Failing cases, exception rationale, equivalent patterns, assertion logic, reviewed alternatives. | Over-permissive acceptance of real violations as alternative implementations. | Undiagnosed brittle test rejects valid architecture and undermines trust. | TEST-010, TEST-013, TEST-016 |
| TEST-013 | Architecture test false-negative control | Evaluate whether verification does not allow relevant violations through scope gaps, fragile filters, incomplete conventions, or superficial evidence. | Negative cases, selector results, assertion strength, mutation or seeded violation checks, baseline behavior. | Demanding exhaustive detection beyond the stated risk and scope. | Green test with empty scope, no assertion, excessive exclusion, or missed violation. | TEST-007, TEST-010, TEST-012, TEST-017 |
| TEST-014 | Architecture test determinism | Evaluate whether execution produces consistent results for the same verifiable state without inappropriate dependence on order, environment, or unstable external state. | Repeated execution, deterministic inputs, environment dependencies, flaky failure history. | Treating any environment-dependent verification as invalid when dependency is controlled. | Flaky checks hide real regressions or create intermittent false failures. | TEST-018, TEST-019 |
| TEST-015 | Architecture test failure diagnostics | Evaluate whether failures provide enough context to identify the violated constraint, involved elements, and required action. | Failure message, report output, violated rule name, source and target elements, remediation context. | Requiring perfect diagnostic detail for low-risk local checks. | Failure is ignored or misfixed because output lacks actionable context. | TEST-018, TEST-019 |
| TEST-016 | Architecture exception governance | Evaluate whether exceptions, suppressions, exclusions, baselines, and allowed deviations have justification, ownership, scope, and lifecycle control. | Suppression list, baseline file, exception metadata, owner, expiry or review process, rationale. | Requiring zero exceptions or zero baseline. | Permanent or broad suppressions hide new architectural violations. | TEST-006, TEST-012, TEST-017 |
| TEST-017 | Architecture regression detection | Evaluate whether verification detects relevant architectural regressions introduced after an accepted state. | Baseline comparison, historical results, failing regression case, changed dependency graph. | Treating every deviation from baseline as a regression when baseline change was governed. | Baseline or pipeline accepts new violations silently. | TEST-013, TEST-016, TEST-018 |
| TEST-018 | Architecture test pipeline execution | Evaluate whether relevant architecture verifications run at an appropriate point in the delivery flow, consistent with risk and feedback needs. | CI configuration, local check scripts, release gate, documented cadence, execution logs. | Requiring every architecture check to run on every commit. | Verification exists but is not run where regressions can be caught. | TEST-014, TEST-015, TEST-017 |
| TEST-019 | Architecture test maintainability | Evaluate whether verifications can evolve with the architecture without excessive duplication, fragility, improper coupling, or disproportionate cost. | Test code structure, helper reuse, selector design, change history, duplicated rules, ownership. | Penalizing intentionally explicit tests as duplication without maintenance impact. | Fragile or duplicated checks become stale and stop protecting architecture. | TEST-011, TEST-014, TEST-015, TEST-020 |
| TEST-020 | Automated and manual validation balance | Evaluate whether automatable and non-automatable properties are validated through suitable mechanisms without false confidence in total automated coverage. | Verification strategy, manual review records, automated checks, ADRs, risk assessment, review cadence. | Treating manual validation as inferior by default. | Assuming automated checks cover properties that require human architectural judgment. | TEST-019, TEST-001, TEST-018 |

## 13. Coverage Matrix

| Capability | Primary Rule | Supporting Rules | Coverage Status |
| --- | --- | --- | --- |
| Fitness function definition | TEST-001 | TEST-002, TEST-003, TEST-011 | Covered |
| Decision traceability | TEST-002 | TEST-001, TEST-004 | Covered |
| Objective constraint | TEST-003 | TEST-001, TEST-002 | Covered |
| Test scope | TEST-004 | TEST-003, TEST-005, TEST-009 | Covered |
| Dependency direction | TEST-005 | TEST-006, TEST-007, TEST-008 | Covered |
| Forbidden dependency | TEST-006 | TEST-005, TEST-016 | Covered |
| Allowed dependency precision | TEST-007 | TEST-005, TEST-013 | Covered |
| Cyclic dependency | TEST-008 | TEST-005, TEST-004 | Covered |
| Module boundary | TEST-009 | TEST-004, TEST-005, TEST-010 | Covered |
| Naming-based verification | TEST-010 | TEST-009, TEST-012, TEST-013 | Covered |
| Behavioral relevance | TEST-011 | TEST-001, TEST-002 | Covered |
| False-positive control | TEST-012 | TEST-010, TEST-016 | Covered |
| False-negative control | TEST-013 | TEST-007, TEST-010, TEST-017 | Covered |
| Determinism | TEST-014 | TEST-018, TEST-019 | Covered |
| Failure diagnostics | TEST-015 | TEST-018, TEST-019 | Covered |
| Exception governance | TEST-016 | TEST-006, TEST-012, TEST-017 | Covered |
| Regression detection | TEST-017 | TEST-013, TEST-016, TEST-018 | Covered |
| Pipeline execution | TEST-018 | TEST-014, TEST-015, TEST-017 | Covered |
| Test maintainability | TEST-019 | TEST-011, TEST-014, TEST-015 | Covered |
| Manual validation | TEST-020 | TEST-002, TEST-011, TEST-019 | Covered |
| Automated validation | TEST-001 | TEST-003, TEST-018, TEST-020 | Covered |
| Architecture drift | TEST-017 | TEST-004, TEST-016, TEST-018 | Covered |
| Baseline | TEST-016 | TEST-017, TEST-013 | Covered |
| Suppression | TEST-016 | TEST-006, TEST-012 | Covered |
| Structural conformance | TEST-005 | TEST-004, TEST-008, TEST-009 | Covered |
| Dynamic architectural properties | TEST-020 | TEST-001, TEST-011 | Partially Covered |

Dynamic architectural properties are partially covered because this catalog evaluates the suitability of validation mechanisms, not the runtime architectural property itself.

## 14. Overlap Matrix

| Rule A | Rule B | Shared Evidence | Rule A Conclusion | Rule B Conclusion | Boundary |
| --- | --- | --- | --- | --- | --- |
| TEST-001 | TEST-002 | Fitness function text, ADR, stated risk. | Fitness function is well-defined. | Verification is traceable to an architectural origin. | Clear |
| TEST-002 | TEST-003 | ADR, constraint text, verification description. | Origin of the verification is traceable. | Constraint is objective enough to verify repeatably. | Clear |
| TEST-003 | TEST-004 | Constraint statement, selected elements. | Constraint is testable. | Verification scope matches the decision. | Clear |
| TEST-005 | TEST-006 | Dependency graph, selectors, exception list. | Dependency rule has coherent direction, origin, and destination. | Forbidden dependency detection is adequate. | Clear |
| TEST-005 | TEST-007 | Dependency graph, allow rules. | Dependency rule direction is represented correctly. | Allowed dependency set is precise enough. | Clear |
| TEST-005 | TEST-008 | Dependency graph, analysis level. | Dependency direction is verified. | Cycles are detected at the right architectural level. | Clear |
| TEST-006 | TEST-009 | Forbidden paths, module map, boundary rules. | Prohibited dependency can be detected. | Module boundary is verified. | Minor Shared Evidence |
| TEST-009 | TEST-010 | Namespaces, packages, folders, module selectors. | Real module boundary is represented. | Naming-based selector is reliable enough. | Clear |
| TEST-010 | TEST-012 | Selector logic, failing cases, naming conventions. | Naming-based evidence is reliable. | Legitimate implementations are not wrongly rejected. | Clear |
| TEST-010 | TEST-013 | Selector results, matched element lists, negative cases. | Naming selector is not too fragile. | Relevant violations are not missed. | Clear |
| TEST-011 | TEST-001 | Fitness function objective, protected quality, risk. | Verification protects real architectural behavior or quality. | Fitness function definition is coherent. | Clear |
| TEST-012 | TEST-013 | Test cases, assertions, examples of accepted and rejected structures. | Legitimate implementations are not rejected. | Relevant violations are not accepted. | Clear |
| TEST-014 | TEST-018 | Execution logs, environment, delivery flow. | Result is deterministic for the same verifiable state. | Execution occurs at the right delivery moment. | Clear |
| TEST-015 | TEST-018 | Failure output, pipeline logs. | Failure is diagnosable. | Verification runs in the appropriate flow. | Clear |
| TEST-016 | TEST-017 | Baselines, suppressions, historical results. | Accepted deviations are governed. | New regressions are detected after accepted state. | Clear |
| TEST-017 | TEST-018 | Historical results, delivery checks, execution logs. | Regression can be detected. | Verification is executed in the delivery flow when needed. | Clear |
| TEST-019 | TEST-020 | Validation strategy, test design, maintenance records. | Verification remains maintainable over time. | Automated and manual mechanisms are balanced. | Clear |

## 15. Known False-Positive Risks

The catalog must avoid findings caused by:

- requiring architecture tests in every system;
- requiring pipeline execution for every verification;
- requiring a specific tool, library, framework, language, or vendor product;
- requiring automation for properties better validated manually;
- treating naming variation as a violation without stronger evidence;
- failing legitimate architecture not representable by the selected tool;
- treating allowed dependencies as prohibited;
- treating legitimate technical cycles as architectural cycles;
- failing intentional, governed exceptions;
- requiring execution on every commit;
- requiring percentage coverage;
- requiring zero suppressions or zero baselines;
- requiring a single validation mechanism.

## 16. Known False-Negative Risks

The catalog must detect or expose risk from:

- green tests with empty scope;
- selectors that match no relevant elements;
- renamed namespaces not reflected in tests;
- tests that verify names only;
- allow rules that permit every dependency;
- excessive exclusions;
- permanent suppressions;
- baselines that accept new violations;
- checks not executed in any meaningful flow;
- ignored tests;
- non-deterministic tests;
- failures without diagnostic context;
- checks that do not represent the ADR;
- indirect dependencies outside analysis;
- cycles not detected at the relevant level;
- new modules outside scope;
- local-only tool configuration;
- tests without effective assertions;
- discarded results;
- dynamic properties treated as covered by static checks.

## 17. Future Extensions

Future modules may create individual Rule documents for the entries in this catalog using the official 20-field structure from `SPECIFICATION.md`.

Potential future extensions must not be added silently as extra entries in this catalog. They should first be checked for atomicity, taxonomy ownership, overlap with existing entries, evidence availability, outcome completeness, legitimate absence handling, and cross-catalog boundary safety.

## 18. References

Internal references:

- `README.md`
- `.archinspector/AI_CONTEXT.md`
- `.archinspector/ARCHITECTURE.md`
- `.archinspector/DECISIONS.md`
- `skill/instructions.md`
- `skill/rules/RULE_MODEL.md`
- `skill/rules/SPECIFICATION.md`
- `skill/rules/TAXONOMY.md`
- `skill/rules/EVENTS_CATALOG.md`
- `skill/reviews/EVENTS_CATALOG_REVIEW.md`
- `skill/reviews/EVENTS_CATALOG_STABILIZATION.md`

External references:

- Neal Ford, Rebecca Parsons, and Patrick Kua, *Building Evolutionary Architectures*.
- Mark Richards and Neal Ford, *Fundamentals of Software Architecture*.
- Michael Feathers, *Working Effectively with Legacy Code*.
- Robert C. Martin, architecture and test principles where directly related to architectural verification.
- Official documentation for architecture-testing tools may be used only as non-normative examples of possible evidence mechanisms.

## 19. Change Notes

Initial Architecture Testing catalog created.

Aligned to `RULE_MODEL.md`.

Aligned to `SPECIFICATION.md`.

Aligned to `TAXONOMY.md`.

Defined 20 planned Rules from `TEST-001` through `TEST-020`.

Preserved cross-catalog boundaries with Core, Hexagonal Architecture, Clean Architecture, Domain-Driven Design, Layered Architecture, Fowler Patterns, Events and Messaging, SOLID, and Solution Architecture.
