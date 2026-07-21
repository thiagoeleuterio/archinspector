# Rule ID

FOWLER-001

# Title

Repository

# Category

Fowler Patterns

# Status

Active

# Intent

Evaluate whether collection-like access to domain objects mediates between domain logic and data mapping concerns.

# Applicability

Apply this rule when the reviewed material includes a component, contract, collaboration, or documented design decision that claims, depends on, or strongly suggests the Fowler Repository pattern.

The rule is relevant when the reviewed scope contains domain object access behavior that may be intended to act as a collection-like boundary between domain logic and data mapping concerns. This includes cases where the component is named as a repository, where callers treat it as a collection of domain objects, or where architectural documentation assigns it the Repository responsibility.

The rule may also be considered when an equivalent collection-like abstraction exists without Repository naming, provided the available evidence shows that it mediates access to domain objects rather than merely executing table operations, persistence mapping, transaction coordination, remote access, or application workflow orchestration.

Do not apply this rule merely because a system has persistence code, data access code, query code, storage abstractions, domain objects, or layered boundaries. The rule applies only when the Repository responsibility from the Fowler catalog entry is relevant to the reviewed scope.

The Fowler catalog category for this pattern is `Data Source Architectural Patterns`.

# Rule Statement

A Repository must provide collection-like access to domain objects while mediating between domain logic and data mapping concerns, without reducing the pattern to naming, generic persistence access, or responsibilities owned by other patterns.

# Rationale

Repository protects domain-facing code from direct data mapping concerns by presenting access to domain objects through a collection-like abstraction. When this responsibility is preserved, callers can reason about obtaining and storing domain objects without depending on the mechanics of mapping, querying, or storage representation.

The architectural risk appears when a component is declared or relied on as a Repository but does not mediate between domain logic and data mapping concerns. A nominal repository that exposes mapping mechanics, behaves primarily as a table gateway, owns transaction coordination, contains unrelated application workflow, or hides incomplete persistence behavior can create misleading boundaries and make the architecture harder to evolve.

This rule does not require every system to adopt Repository. It evaluates the pattern only when the reviewed evidence indicates that the pattern is present, intended, depended on, or relevant to the access responsibility under review.

# Evidence Required

Evaluation requires traceable evidence about the component being evaluated, the domain objects or domain-facing model it provides access to, the callers that use it, and the data mapping or persistence concerns it mediates.

Direct evidence may include executable implementation, method behavior, query and retrieval flow, save or removal flow when present, dependency relationships, contracts, caller usage, collaborator responsibilities, tests that demonstrate behavior, and architectural decisions or documentation tied to the reviewed implementation.

Evidence should establish whether the component behaves as a collection-like access point for domain objects, whether it hides or mediates data mapping concerns from domain logic, whether callers depend on Repository semantics, and whether essential collaborators are present in the reviewed scope.

Naming, folder placement, namespace labels, comments, and documentation are supporting signals only. They may indicate intent or help locate relevant material, but they must not by themselves establish that Repository is present, correctly implemented, or violated with `Confirmed` confidence.

When evidence exists across implementation, tests, structure, contracts, and documentation, prefer the following order of strength:

1. Executable implementation and observable behavior.
2. Tests that demonstrate Repository behavior.
3. Structure and flow between callers, repository component, domain objects, and mapping or persistence collaborators.
4. Contracts and architectural decisions.
5. Naming, directories, namespaces, comments, and isolated documentation as auxiliary support only.

# Evaluation Guidance

First determine whether the reviewed scope supports a defensible Repository evaluation. Distinguish absence of Repository from intention to use Repository, partial implementation, equivalent implementation, naming without behavior, legitimate variation, composition with other Fowler patterns, and violation of the pattern's central responsibility.

Evaluate only the Fowler Repository responsibility identified by `FOWLER-001`: collection-like access to domain objects that mediates between domain logic and data mapping concerns. Do not turn Repository into a universal data access requirement, a mandatory domain modeling rule, a layer responsibility rule, a transaction boundary rule, a gateway rule, a mapper rule, or an application service rule.

Interpret evidence conservatively. A component named `Repository` is not necessarily a Repository. A component without Repository naming may still implement an equivalent Repository responsibility if callers interact with it as a collection-like access point for domain objects and data mapping concerns are mediated behind that boundary. Generic persistence methods, direct table access, remote transfer, transaction scripting, or mapper behavior should not be treated as Repository unless the collection-like domain object access responsibility is supported by evidence.

Recognize legitimate composition with related Fowler patterns while keeping conclusions independent. Repository may collaborate with Data Mapper, Unit of Work, Identity Map, Lazy Load, Identity Field, Foreign Key Mapping, or other persistence patterns. Those collaborations are relevant only to the extent that they help evaluate whether Repository itself preserves its central responsibility.

Do not re-evaluate Layered Architecture, Domain-Driven Design, Clean Architecture, Hexagonal Architecture, SOLID, messaging, architecture testing, or solution-level structure. Evidence from those areas may provide context, but this rule owns only the Repository pattern condition.

Remediation guidance should be derived from the specific finding evidence. It should clarify or restore the Repository responsibility when the pattern is declared or depended on, or recommend aligning naming and documentation with the actual pattern when a different legitimate approach is being used.

# Pass Conditions

Use `Pass` when the reviewed evidence shows that the Repository pattern is present and its central responsibility is implemented coherently: callers receive collection-like access to domain objects, and data mapping concerns are mediated behind the repository boundary.

Use `Pass` when a technology-neutral equivalent implementation satisfies the Repository responsibility even if the naming differs, provided the behavior and collaboration structure are supported by direct or strongly corroborated evidence.

Use `Pass` when Repository composes with other Fowler patterns and the reviewed evidence shows that those collaborators do not replace, obscure, or contradict the Repository responsibility being evaluated.

# Fail Conditions

Use `Fail` when direct evidence shows that the system declares, depends on, or requires Repository semantics, but the implementation violates the pattern's central responsibility.

Use `Fail` when a nominal Repository exposes data mapping concerns to domain logic instead of mediating them, behaves primarily as a table or row access gateway while being depended on as a domain object collection, or delegates so completely that no Repository responsibility remains despite callers relying on it.

Use `Fail` when direct evidence shows that essential Repository behavior is misleadingly represented, such that naming, contracts, or documented architecture promise collection-like domain object access while the actual behavior provides only unrelated persistence, mapping, transaction coordination, application workflow, or remote transfer responsibilities.

# Warning Conditions

Use `Warning` when evidence indicates a partial, inconsistent, distorted, or mixed Repository implementation, but the reviewed material does not justify a definitive `Fail`.

Use `Warning` when a component appears to provide some collection-like access to domain objects but also exposes mapping concerns, table-oriented operations, application workflow, transaction control, or other responsibilities in a way that may weaken the Repository boundary.

Use `Warning` when naming, contracts, documentation, or caller expectations consistently suggest Repository, but the implementation evidence is incomplete or ambiguous enough that the central responsibility cannot be fully confirmed or rejected.

Use `Warning` when Repository is legitimately composed with other patterns but the responsibility boundary is blurred enough to create maintainability risk within the reviewed scope.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed system does not intend to use Repository and there is no relevant component whose responsibility matches the Repository problem.

Use `Not Applicable` when the architectural problem solved by Repository is outside the reviewed scope, such as material that does not include domain object access, data mapping concerns, or a relevant domain-facing collection abstraction.

Use `Not Applicable` when another legitimate pattern or architectural approach is adopted instead, and the reviewed evidence does not show that the system declares, depends on, or requires Repository semantics.

Use `Not Applicable` when the available material contains no component, contract, behavior, or decision relevant to evaluating Repository.

Absence of Repository must not automatically produce `Fail`.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when Repository may be relevant but the available material does not provide enough evidence to determine presence, intent, responsibility, behavior, or conformance.

Use `Not Enough Evidence` when there are only names, directories, namespaces, comments, or documentation suggesting Repository, without implementation, caller flow, contract behavior, tests, or collaborators sufficient to confirm the pattern.

Use `Not Enough Evidence` when essential collaborators are outside the reviewed scope, including the caller, domain object, mapping component, persistence mechanism, contract, or tests needed to trace the Repository responsibility.

Use `Not Enough Evidence` when implementation and documentation conflict and the reviewed material cannot resolve which one reflects the actual architectural behavior.

Use `Not Enough Evidence` when the behavior cannot be traced far enough to distinguish Repository from Data Mapper, Table Data Gateway, Row Data Gateway, Active Record, Unit of Work, Transaction Script, Service Layer, Remote Facade, or other adjacent responsibilities.

# Severity Guidance

Assign higher severity when a declared or depended-on Repository violation affects central domain object access, broad caller usage, important workflows, stable architectural boundaries, many repositories or equivalent components, or behavior that is difficult to correct without changing domain-facing contracts.

Assign medium severity when the Repository responsibility is meaningfully distorted or mixed in a localized area that affects maintainability, consistency, or evolution but does not dominate the reviewed architecture.

Assign lower severity when the issue is narrow, isolated, peripheral, easily renamed or clarified, or limited to weak Repository intent with little demonstrated architectural dependency.

Severity must derive from demonstrated architectural impact, dependency on the pattern, breadth of incorrect implementation, recurrence, affected flows, maintainability impact, consistency impact, evolution impact, and correction difficulty. Do not use numeric scoring and do not assign severity solely from the Fowler category, naming, or absence of the pattern.

# Confidence Guidance

Use `Confirmed` only when direct, traceable evidence establishes the Repository presence or nonconformance, the domain object access responsibility, the relevant caller behavior, and the mediation or leakage of data mapping concerns.

Use `Likely` when multiple consistent evidence points support the evaluation, but one or more direct confirmations are incomplete.

Use `Possible` when evidence is limited, indirect, partial, or suggestive, such as naming plus some structural hints without enough behavioral trace.

Use `Not Enough Evidence` when the available material cannot support a reliable conclusion about Repository presence or conformance.

Naming, folder placement, namespaces, comments, documentation, or repeated use of the word Repository must not produce `Confirmed` confidence without corroborating implementation, behavioral, structural, contractual, or test evidence.

# Dependencies

None

# References

FOWLER_CATALOG.md

Martin Fowler, *Patterns of Enterprise Application Architecture*, Repository.

# Change Notes

Initial Gold Standard rule content for the Fowler Patterns catalog.
