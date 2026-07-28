# Layered Architecture Evidence Catalog

## Catalog Purpose

This catalog describes evidence that can help the Architecture Analyzer recognize, qualify, and explain Layered Architecture. It is a correlation aid, not a rule engine, metric set, scoring model, or architectural quality judgment.

The catalog supports traceable interpretation of observable facts. It helps the Analyzer distinguish explicit adoption, implicit adoption, partial adoption, valid variations, inconsistencies, and contradictory evidence without relying only on folder names or nominal conventions.

## Architectural Definition

Layered Architecture organizes responsibilities into distinguishable logical layers, usually with an expected dependency direction between them. Common layers include presentation, application, domain or business logic, and infrastructure, although exact naming, number of layers, physical packaging, and allowed dependency paths vary by system.

Each layer has a distinct responsibility. Presentation handles interaction surfaces, application coordinates use cases, domain or business logic represents core rules and decisions, and infrastructure provides technical capabilities such as persistence, messaging, external integrations, and framework-specific adapters.

Layered Architecture can exist physically across projects, packages, assemblies, or deployable components, or logically inside a single project through namespaces, modules, visibility boundaries, and dependency discipline. Layers do not have to be separate projects to be architecturally meaningful.

Layered Architecture is not equivalent to Clean Architecture. Clean Architecture may include layered elements, but it adds specific dependency and policy expectations centered on inner and outer circles. Layered Architecture is also not equivalent to an anemic architecture. A layered system may have rich domain behavior, procedural application services, or a mix of both depending on context.

Layered Architecture can coexist with Domain-Driven Design, CQRS, event-driven integrations, modular monoliths, feature folders, and other organizing approaches when responsibilities and dependency expectations remain understandable. General separation of concerns, common web framework structure, or vertical feature grouping should be treated as leads for analysis, not as proof that the system uses Layered Architecture.

## Scope and Boundaries

This catalog applies to evidence about architectural organization, responsibility placement, boundary behavior, and dependency direction associated with Layered Architecture.

It does not define executable checks, project templates, rule identifiers, quality gates, numeric weights, or migration advice. It does not determine whether Layered Architecture is better or worse than another architecture style.

The catalog should be used only with reviewed material, prior rule results, findings, source code, dependency information, documentation, or other traceable artifacts.

## Evidence Interpretation Principles

- Directory names are weak evidence when isolated.
- Namespaces are complementary evidence, not proof.
- Project references and module references are strong structural evidence when dependency direction is visible.
- Code dependencies are more relevant than naming conventions.
- Layer flow should be evaluated systemically across the reviewed scope.
- One isolated exception does not invalidate the whole architecture.
- Consistent repetition across comparable components increases confidence.
- Evidence derived from the same origin must not be counted as independent corroboration.
- A hybrid architecture may be intentional and coherent.
- Absence of a nominal layer does not prove absence of Layered Architecture.
- Explicit architectural documentation should be compared with implementation evidence.
- Responsibility placement is more important than the presence of familiar class names.

## Evidence Strength Model

| Strength | Definition | Example Sources | Permitted Use | Limitations | Correlation Guidance |
| --- | --- | --- | --- | --- | --- |
| Strong | Directly verifiable evidence of dependency direction, boundary enforcement, responsibility placement, or repeated interaction flow with adequate reviewed scope. | Project references with verified direction, imports, constructor dependencies, method calls, visibility boundaries, architecture tests, reviewed rule results. | Can materially support, weaken, or contradict a layered interpretation when correlated with scope and responsibility evidence. | Does not create an automatic conclusion and may still be local, partial, or explained by a valid variation. | Prefer independent strong evidence from different sources over repetitions of the same observation. |
| Moderate | Evidence with architectural relevance but partial coverage, indirect meaning, or limited scope. | Repeated controller delegation, application service orchestration, persistence encapsulation, contracts between layers, focused tests. | Can support a hypothesis when correlated with stronger or independent complementary evidence. | May reflect framework conventions, local implementation choices, or partial adoption rather than system architecture. | Multiple moderate items improve confidence only when they cover distinct facts and representative scope. |
| Weak | Naming, folder, namespace, suffix, or convention evidence when observed in isolation. | Folders named Controllers or Services, class suffixes, DTO names, namespace labels. | Can provide leads for further analysis or minor corroboration. | Must not confirm Layered Architecture without stronger evidence. | Multiple weak signals do not become strong by accumulation unless independent dependency or responsibility evidence is added. |
| Contextual | Background information that frames interpretation but should not drive conclusions alone. | Architecture diagrams, README statements, team conventions, framework usage, dependency injection setup. | Can explain intent, vocabulary, expected boundaries, or why a variation may be valid. | May be outdated, aspirational, generic, or disconnected from implementation. | Contextual evidence is relevant for calibration, but implementation evidence should decide confidence when the two diverge. |

Evidence strength is not a final score. It indicates relative usefulness for correlation and explanation only. Strength and confidence are different concepts: a strong observation can have low confidence if scope is narrow, and a weak observation can be highly reliable as a narrow fact.

## Positive Evidence

| ID | Evidence | Type | Strength | Direction | Interpretation | Limitations |
| --- | --- | --- | --- | --- | --- | --- |
| LAYER-EV-001 | Projects or modules separate presentation, application, domain, and infrastructure responsibilities, with responsibilities verified beyond names. | Structural | Moderate | supports | The repository organization is consistent with layered responsibility separation. | Physical or nominal separation alone is insufficient; dependency direction and implemented responsibilities must be checked. |
| LAYER-EV-002 | Project or module references follow an expected direction and the referenced modules have verified layer responsibilities. | Dependency | Strong | supports | Dependency direction and responsibility ownership support a layered organization. | Must account for chosen variation, such as open, closed, or relaxed layering, and should not rely on reference direction without responsibility review. |
| LAYER-EV-003 | Controllers, endpoints, pages, or handlers delegate use-case work to application services. | Dependency | Moderate | supports | Presentation appears to act as an entry point rather than the main workflow owner. | Delegation may be superficial if application services are pass-through wrappers. |
| LAYER-EV-004 | Application services coordinate use cases, transactions, authorization checks, or orchestration without owning low-level framework details. | Boundary | Strong | supports | Application responsibilities are distinguishable from presentation and infrastructure. | Some framework interaction may be acceptable depending on stack conventions. |
| LAYER-EV-005 | Domain or business logic does not depend on presentation frameworks, web abstractions, UI models, or controllers. | Dependency | Strong | supports | Inner business responsibilities are insulated from presentation concerns. | A system without a nominal domain layer may still use application-layer business logic. |
| LAYER-EV-006 | Infrastructure components encapsulate persistence access, external clients, file systems, queues, or platform APIs. | Persistence | Strong | supports | Technical concerns are separated from application or domain policy. | Encapsulation must be checked through actual call paths and dependency direction. |
| LAYER-EV-007 | Contracts, interfaces, ports, or abstractions mediate dependencies between application/domain code and infrastructure implementations. | Boundary | Moderate | supports | The system uses explicit boundaries between policy and technical implementation. | Interfaces can be mechanical and may not create meaningful architectural separation. |
| LAYER-EV-008 | Transport models, request models, application commands, domain models, and persistence models are mapped intentionally. | Boundary | Moderate | supports | Model translation suggests layer-specific responsibilities. | Excessive mapping may be incidental or caused by framework requirements. |
| LAYER-EV-009 | Composition root, dependency injection registration, or bootstrapping is centralized near application startup and does not spread wiring through business code. | Framework | Contextual | supports | Object graph composition may be separated from most business and use-case code. | Dependency injection and centralized composition are common in many styles and do not uniquely identify Layered Architecture. |
| LAYER-EV-010 | Tests are organized around layers, such as controller tests, application service tests, domain tests, and infrastructure integration tests. | Testing | Moderate | supports | Test structure can complement production evidence that responsibilities are separated. | Test organization can lag behind production architecture, follow tooling defaults, or mirror naming without enforcing boundaries. |
| LAYER-EV-011 | Dependency policies are documented and reflected in project references, package rules, or architecture tests. | Testing | Strong | supports | Stated layer constraints are backed by verifiable implementation evidence. | Documentation and tests may cover only part of the repository. |
| LAYER-EV-012 | A single project contains logical layers through namespaces, modules, internal visibility, or disciplined dependency flow. | Structural | Moderate | supports | Layered Architecture may be implemented logically within one deployable unit. | Requires code-level verification because physical separation is absent. |
| LAYER-EV-013 | Technical concerns such as persistence, transport, logging, serialization, and external APIs are kept separate from business rules across representative flows. | Boundary | Moderate | supports | Separation of technical concerns and business policy is consistent with layered organization when it repeats beyond isolated files. | Some cross-cutting concerns may legitimately appear in multiple layers, and the same separation can appear in other styles. |
| LAYER-EV-014 | Comparable features use consistent boundaries between entry points, use-case coordination, business behavior, and technical adapters. | Boundary | Strong | supports | Repetition across the system increases confidence in a coherent layered style. | Similarity must be independent across features, not copied from one generated template. |
| LAYER-EV-015 | Lower-level business or domain code exposes stable operations consumed by application code instead of depending on callers. | Dependency | Moderate | supports | Dependency direction and responsibility ownership are compatible with layers. | The same shape can also appear in other architecture styles. |
| LAYER-EV-016 | Infrastructure implementations depend on contracts or abstractions owned outside infrastructure rather than being called directly everywhere. | Dependency | Moderate | supports | Infrastructure is treated as a replaceable technical layer. | Direction expectations vary in traditional versus dependency-inverted layering. |
| LAYER-EV-017 | Feature folders exist within each layer while layer boundaries remain visible and consistently followed. | Structural | Moderate | supports | Feature organization can coexist with a layered architecture. | Feature folder naming may obscure layer boundaries if dependencies are not reviewed. |
| LAYER-EV-018 | Architecture review findings repeatedly describe clear responsibility placement and low concern leakage across layer boundaries. | Boundary | Strong | supports | Prior reviewed evidence supports coherent layered adoption when findings are independent and representative. | Findings must be traceable and not derived from the same single observation or template-generated repetition. |

## Weak or Ambiguous Evidence

Weak or ambiguous evidence identifies leads for analysis. These items should not be treated as independent confirmation unless correlated with observable dependency direction, implemented responsibilities, and representative scope.

| ID | Evidence | Type | Strength | Direction | Interpretation | Limitations |
| --- | --- | --- | --- | --- | --- | --- |
| LAYER-WEAK-001 | Folders named Controllers, Services, or Repositories. | Naming | Weak | neutral | Folder names may indicate where to inspect for layered responsibilities. | Folders can be visual organization only and do not prove boundaries, dependencies, or responsibility placement. |
| LAYER-WEAK-002 | Namespaces containing layer terms such as Presentation, Application, Domain, or Infrastructure. | Naming | Weak | neutral | Namespace labels may describe intended vocabulary. | Namespaces may not represent real dependency direction, visibility constraints, or runtime behavior. |
| LAYER-WEAK-003 | Class suffixes such as Service, Repository, Manager, Handler, or Provider. | Naming | Weak | neutral | Suffixes may hint at intended roles. | Suffixes do not show whether responsibilities are cohesive, pass-through, misplaced, or layered. |
| LAYER-WEAK-004 | Presence of DTOs, commands, requests, responses, or view models. | Structural | Weak | neutral | Separate data shapes may suggest translation points worth reviewing. | DTOs can appear in many styles and may be used without meaningful architectural separation. |
| LAYER-WEAK-005 | Presence of interfaces or abstractions. | Boundary | Weak | neutral | Interfaces may be candidates for boundary review. | Interfaces may be generated, framework-driven, unused, or unrelated to dependency inversion or layer boundaries. |
| LAYER-WEAK-006 | Multiple projects or packages exist in the solution. | Structural | Weak | neutral | Physical separation may provide candidate architectural units. | Multiple projects can be organizational, deployment, test, or tooling separation without coherent layer direction. |
| LAYER-WEAK-007 | Diagrams show layers but cannot be matched to code or dependency evidence. | Structural | Contextual | neutral | Diagrams may explain intended vocabulary or target structure. | Diagrams may be outdated, aspirational, simplified, or inconsistent with implementation. |
| LAYER-WEAK-008 | Documentation declares Layered Architecture. | Structural | Contextual | neutral | Stated intent can frame how implementation evidence should be interpreted. | Documentation is not implementation evidence and may diverge from actual dependencies or responsibilities. |
| LAYER-WEAK-009 | The system uses MVC or a similar web framework. | Framework | Weak | neutral | MVC may provide presentation organization and entry points to inspect. | MVC is an interaction pattern and framework organization, not sufficient proof of system-level Layered Architecture. |
| LAYER-WEAK-010 | Dependency injection is configured. | Framework | Contextual | neutral | Dependency injection can show where composition and dependency relationships may be inspected. | Dependency injection is a wiring mechanism and does not prove dependency inversion, boundaries, or layered responsibilities. |

## Negative Evidence

Negative evidence weakens a layered interpretation without necessarily proving that Layered Architecture is absent.

| ID | Evidence | Type | Strength | Direction | Interpretation | Limitations |
| --- | --- | --- | --- | --- | --- | --- |
| LAYER-NEG-001 | Components communicate broadly without identifiable boundaries or expected dependency direction across representative production scope. | Dependency | Strong | weakens | The system may be organized around ad hoc dependencies rather than layers. | Scope may miss boundary conventions enforced outside reviewed material; isolated communication paths should be classified as local exceptions. |
| LAYER-NEG-002 | Presentation, business rules, persistence, and integration responsibilities are repeatedly mixed in the same components. | Boundary | Strong | weakens | Responsibility separation appears limited or inconsistent. | Local modules may intentionally collapse layers for simple workflows; repetition and breadth are needed before treating this as systemic. |
| LAYER-NEG-003 | Direct persistence access is widespread across controllers, UI components, handlers, and domain objects. | Persistence | Strong | weakens | Persistence is not clearly encapsulated in an infrastructure, data access, or framework-supported persistence boundary. | Direct persistence may be acceptable in some simple, generated, active record, or administrative contexts and should be judged by frequency, scope, and architectural claims. |
| LAYER-NEG-004 | Business rules are dispersed across controllers, handlers, repositories, and integration clients. | Domain Model | Strong | weakens | Business responsibility placement is not predictable. | Requires distinguishing validation, mapping, orchestration, protocol translation, and local policy from core business decisions. |
| LAYER-NEG-005 | Dependencies cross between nominal layers in multiple directions without a documented or repeated rationale. | Dependency | Strong | weakens | Layer direction is unclear or inconsistently applied. | Relaxed and open layering may permit some bypasses when intentionally constrained and consistently applied. |
| LAYER-NEG-006 | No verifiable logical separation of responsibilities is visible in code, dependencies, or reviewed artifacts. | Structural | Moderate | weakens | Available evidence is insufficient to support a layered interpretation. | Absence of evidence may reflect limited analysis scope and should not be reported as proof that Layered Architecture is absent. |

## Contradictory Evidence

Evidence that weakens makes a layered interpretation less plausible. Evidence that contradicts directly conflicts with an asserted or previously suggested layered classification. A local exception is narrow, isolated, and may be acceptable. A systemic contradiction is repeated across modules or central flows and should materially reduce confidence. A single inverted dependency, documented bypass, or open-layer dependency should usually be recorded as a scoped exception or weakening signal unless it conflicts with declared boundaries or repeats broadly.

| ID | Evidence | Type | Strength | Direction | Interpretation | Limitations |
| --- | --- | --- | --- | --- | --- | --- |
| LAYER-CONTRA-001 | Domain or core business code repeatedly depends on presentation frameworks, controllers, UI models, or web request abstractions. | Dependency | Strong | contradicts | This conflicts with a common layered expectation that business code is independent of presentation. | Some systems do not define a separate domain layer; isolated framework annotations or shared primitives may only weaken confidence. |
| LAYER-CONTRA-002 | Controllers or UI entry points directly access databases or ORM contexts recurrently across important flows. | Persistence | Strong | contradicts | Recurring direct persistence from presentation contradicts a layered separation claim. | Isolated administrative endpoints, scaffolding, or simple CRUD paths may be local exceptions depending on stated architecture. |
| LAYER-CONTRA-003 | Infrastructure components contain use-case orchestration or business workflows across representative flows. | Boundary | Strong | contradicts | Infrastructure is acting as an application or business layer rather than a technical layer. | Some integration adapters may contain protocol-specific orchestration that does not own business policy. |
| LAYER-CONTRA-004 | Application services contain extensive framework, transport, persistence, or infrastructure implementation details across multiple use cases. | Framework | Strong | contradicts | Application boundaries are being bypassed or overloaded by technical concerns. | Limited framework attributes, transaction annotations, mediator plumbing, or validation adapters may be acceptable when contained. |
| LAYER-CONTRA-005 | Recurring cyclic dependencies exist between production layers or layer-named projects. | Dependency | Strong | contradicts | Cycles directly conflict with expected directional dependency control. | Generated artifacts, test projects, build tooling, and explicitly documented open-layer policies should be separated from production analysis. |
| LAYER-CONTRA-006 | Declared boundaries are systematically ignored by imports, references, or call paths. | Boundary | Strong | contradicts | Implementation evidence conflicts with the stated layered intent and indicates architectural incoherence in the reviewed scope. | Documentation may describe a target state rather than current implementation; narrow deviations should be scoped as local exceptions. |

## Architectural Variations

| Variation | Characteristics | Expected Evidence | Misclassification Risks |
| --- | --- | --- | --- |
| Three-layer architecture | Usually separates presentation, business/application, and data/infrastructure responsibilities. | Directed dependencies, entry point delegation, persistence encapsulation. | Mistaking every MVC application for a coherent three-layer architecture. |
| Four-layer architecture | Commonly separates presentation, application, domain/business, and infrastructure. | Distinct use-case coordination, business behavior, and technical adapters. | Assuming every missing nominal layer disproves layering. |
| Logical layers in a monolith | Layers exist inside one deployable unit through namespaces, modules, visibility, and conventions. | Consistent imports, responsibility placement, and boundary discipline. | Treating a single project as insufficient evidence by default. |
| Physical layers across projects | Layers are represented by separate projects, packages, assemblies, or modules. | Project references and package dependencies with expected direction. | Treating separate projects as proof without checking responsibility. |
| Layered modular monolith | Each module may contain internal layers while deployment remains unified. | Module boundaries plus internal presentation/application/domain/infrastructure separation. | Confusing module boundaries with layer boundaries. |
| Layered architecture with DDD | Domain layer may include entities, value objects, aggregates, domain services, and events. | Domain behavior isolated from presentation and infrastructure concerns. | Treating DDD as incompatible with Layered Architecture. |
| Layered architecture with CQRS | Command/query handlers may reside in application layer, with separate read/write flows. | Handler dependencies follow layer expectations and infrastructure remains adapter-like. | Interpreting every handler structure as non-layered. |
| Layered architecture with event-driven integrations | Events and adapters support integration while core layer responsibilities remain distinct. | Publishers/subscribers isolated through application or infrastructure boundaries, with broker details kept outside core business decisions. | Confusing messaging adapters with the main architectural style or assuming events eliminate Layered Architecture. |
| Layered architecture with feature folders | Features group files vertically while internal responsibilities still map to layers. | Feature-level boundaries, consistent imports, and separated technical concerns. | Rejecting layering because folders are feature-oriented. |
| Relaxed layering | Some layers may bypass intermediate layers by convention or documented exception. | Documented allowed dependencies and repeated controlled bypasses. | Treating every bypass as a contradiction without context. |
| Closed layering | Each layer depends only on the next layer below or inward. | Strict reference chains and absence of layer skipping. | Assuming closed layering is the only valid layered form. |
| Open layering | Higher layers may use selected lower layers directly under explicit constraints. | Clear policy for allowed direct dependencies and limited concern leakage. | Treating every layer skip as incoherent or assuming open layering has the same constraints as closed layering. |

## Coherence Indicators

- Dependency direction is consistent across comparable modules.
- Responsibilities are predictable from code behavior, not only names.
- Boundaries are respected by imports, references, calls, and ownership of models.
- Exceptions are documented, localized, and proportionate.
- Technical concerns leak minimally into business and use-case code.
- Responsibilities are easy to locate without following many unrelated call paths.
- Tests align with layer responsibilities and boundary expectations.
- Composition is centralized near application startup or module startup.
- Coupling between presentation and infrastructure is low.
- Documentation, code structure, and dependency evidence tell a compatible story.

## Inconsistency Indicators

- A nominal layer exists but has no distinct responsibility.
- Services accumulate workflow, business rules, persistence, integration, mapping, and framework details.
- Controllers or UI entry points orchestrate complex workflows directly.
- Repositories implement business policy rather than persistence access or data mapping.
- Cross-layer dependencies are frequent and directionally inconsistent.
- Shared models are used indiscriminately across transport, application, domain, and persistence boundaries.
- A layer is used mainly as pass-through indirection without architectural responsibility.
- Abstractions exist without boundary function, alternate implementations, or dependency direction value.
- Equivalent modules apply different layering approaches without documented rationale.
- Framework-specific concerns dominate inner business or application code.

## Adoption Levels

| Adoption Level | Criteria | Expected Confidence | Recommended Diagnostic Language | Language to Avoid |
| --- | --- | --- | --- | --- |
| Explicit and Coherent | Documentation or naming declares layered intent, and independent structural, dependency, and responsibility evidence align. | High when scope is broad and contradictions are limited. | "The repository shows strong evidence of a layered organization." | "The architecture is correct." |
| Explicit but Inconsistent | Layered intent is visible, but implementation evidence shows uneven responsibilities, bypassed boundaries, or conflicting dependencies. | Medium when inconsistencies are localized; lower when systemic. | "The implementation is consistent with a layered architecture, although some boundaries are applied unevenly." | "The system failed Layered Architecture." |
| Implicit and Coherent | No explicit declaration exists, but dependency direction and responsibility placement consistently match layered expectations. | Medium to High depending on independence and repetition of evidence. | "The system appears to use logical layers within a single deployable unit." | "The team intended Layered Architecture." |
| Partial Adoption | Some modules or flows show layered structure while others use different or unclear organization. | Medium when scope boundaries are clear. | "The evidence suggests partial adoption rather than a repository-wide layered architecture." | "The repository is not layered." |
| Superficial Layering | Layer names, folders, or suffixes exist, but responsibilities and dependency direction diverge from the nominal boundaries. | Low to Medium depending on contradiction strength. | "Layered naming conventions are present, but structural evidence does not confirm coherent layering." | "The layers are fake." |
| Insufficient Evidence | Available material lacks enough independent structural, dependency, or responsibility evidence. | Insufficient Evidence. | "Layered naming conventions are present, but the available structural evidence is insufficient to confirm a layered architecture." | "Layered Architecture is absent." |

Explicit evidence does not automatically mean coherent adoption, and implicit evidence does not imply low quality. Partial adoption should be distinguished from incomplete implementation: partial adoption describes observed scope, while incomplete implementation requires evidence of intended work not yet realized. Hybrid architecture should be classified as inconsistent only when evidence shows conflicting responsibilities, unclear boundaries, or dependency conflicts.

## Evidence Correlation Patterns

| Pattern | Independent Evidence | Supported Interpretation | Possible Diagnosis | Confidence Considerations | Contradictory Evidence to Check | Limitations |
| --- | --- | --- | --- | --- | --- | --- |
| Physical layered structure | Separate projects for presentation, application, domain, and infrastructure; directed project references; clear responsibility placement in representative components. | Physical Layered Architecture is likely present in the reviewed scope. | Explicit or implicit coherent layered adoption. | Confidence increases when evidence comes from independent files, references, and reviewed flows. | Cycles, bidirectional dependencies, or responsibilities that contradict nominal project roles. | Does not prove team intent or architectural quality. |
| Layered vocabulary without dependency evidence | Folders named Controllers, Services, and Repositories; layer-like namespaces; no verifiable dependency direction. | Layered vocabulary is present. | Insufficient evidence or superficial layering. | Confidence should remain low until code dependencies and responsibilities are reviewed. | Broad responsibility mixing or ignored declared boundaries. | Naming cannot establish architecture by itself. |
| Representative layered runtime flow | Controllers delegate use cases; application services coordinate workflows; infrastructure encapsulates persistence. | Runtime flow is consistent with layered responsibilities. | Coherent layered implementation in reviewed flows. | Stronger when the pattern repeats across multiple features and services are not pass-through wrappers. | Direct persistence from presentation or application services overloaded with infrastructure details. | May describe only selected flows rather than the repository as a whole. |
| Systemic directional conflict | Cyclic dependencies between layer-named projects; responsibilities mixed across entry points and repositories; no documented exception policy. | Declared layers are not enforcing directional boundaries. | Systemic inconsistency with a layered classification. | Confidence depends on whether cycles affect production code or only tests, generated code, or tooling. | Documented relaxed or open layering policies and scoped exceptions. | Correlation does not identify root cause without additional evidence. |
| Declared architecture diverges from implementation | Documentation declares Layered Architecture; implementation dependencies bypass declared boundaries; responsibilities contradict documented layer roles. | Stated intent diverges from implementation evidence. | Explicit but inconsistent adoption. | Documentation is contextual; implementation evidence should carry more force when they conflict. | Current diagrams, architecture tests, or module policies that explain controlled exceptions. | Does not prove negligence, decision quality, or historical intent. |
| Logical layers in one deployable unit | Single project structure; consistent namespace or module boundaries; imports and call paths follow expected layer direction. | Logical layers exist within one deployable unit. | Implicit and coherent layered adoption. | Confidence improves with broad feature coverage and low concern leakage. | Shared models used indiscriminately or dependencies crossing in multiple directions. | A single project does not prove or disprove Layered Architecture. |
| Layered architecture with rich domain behavior | Layered project or module structure; domain entities contain business behavior; application services coordinate rather than own domain decisions. | Layered Architecture can coexist with a rich domain model. | Layered architecture with DDD influence. | Confidence depends on whether domain behavior is isolated from presentation and infrastructure concerns. | Domain code depending on transport, ORM, or presentation details without a valid boundary rationale. | Rich domain behavior is not proof of Layered Architecture by itself. |
| Layered architecture with event integrations | Layered structure; messaging publishers/subscribers or adapters; core use cases remain separated from broker-specific details. | Event-driven integrations can coexist with layered responsibilities. | Layered architecture with event-driven integration boundaries. | Distinguish infrastructure transport details from application event semantics. | Message handlers that own broad business workflows inside infrastructure or broker-specific code leaking into core use cases. | Messaging adapters are not proof of Hexagonal Architecture or a replacement for layer analysis. |

## Misclassification Risks

- Confusing MVC with Layered Architecture.
- Confusing folder organization with architectural boundaries.
- Classifying Clean Architecture as only Layered Architecture because layers are visible.
- Classifying Hexagonal Architecture as Layered Architecture only because projects are separated.
- Considering every Infrastructure to Application dependency erroneous without checking dependency inversion or composition context.
- Assuming a nominal Domain layer must exist for Layered Architecture.
- Treating passage through multiple layers as automatic architectural quality.
- Assuming more layers means better architecture.
- Interpreting artificial abstractions as real decoupling.
- Treating a single-project system as lacking architecture by default.
- Treating feature folders as absence of layers without reviewing internal responsibilities.
- Treating shared models as automatic boundary violations without checking ownership, mutability, and usage.
- Ignoring intentional hybrid architecture when boundaries remain coherent.
- Treating one local exception as a systemic contradiction.

## Analyzer Guidance

The Analyzer should use this sequence:

1. Collect observable facts from files, projects, namespaces, dependencies, call paths, rule results, findings, documentation, and reviewed artifacts.
2. Classify evidence types using the Analyzer evidence model.
3. Evaluate dependency direction before relying on names.
4. Evaluate actual responsibilities implemented by each component.
5. Identify repetition and scope across comparable modules or flows.
6. Identify exceptions and determine whether they are local, documented, or systemic.
7. Compare declared and implemented architecture.
8. Correlate independent evidence only when sources and observations are distinct.
9. Record contradictory evidence explicitly.
10. Assign confidence separately from evidence strength.
11. State limitations, including partial scope and unavailable dependency data.
12. Produce a calibrated interpretation that distinguishes observation from diagnosis.

Evidence should be correlated only when it is sufficiently independent. Contradictory evidence should be recorded explicitly and used to narrow confidence or scope. Conclusions should be calibrated, traceable, and non-binary.

The Analyzer should declare limitations when scope is partial, dependencies are unavailable, generated code may distort structure, or documentation cannot be matched to implementation. It should not recommend automatic migration to Clean Architecture, Hexagonal Architecture, or any other style merely because layered evidence is weak or inconsistent.

Examples of calibrated language:

- "The repository shows strong evidence of a layered organization."
- "The implementation is consistent with a layered architecture, although some boundaries are applied unevenly."
- "Layered naming conventions are present, but the available structural evidence is insufficient to confirm a layered architecture."
- "The system appears to use logical layers within a single deployable unit."
- "The evidence suggests partial adoption rather than a coherent layered architecture."
- "The reviewed module shows localized inconsistency with the declared layer boundaries."

## Known Limitations

- This catalog does not execute analysis.
- This catalog does not replace rules.
- This catalog does not calculate a score.
- This catalog does not determine architectural quality in isolation.
- This catalog does not know the business context.
- This catalog does not confirm team intent.
- This catalog depends on the evidence provided to the Analyzer.
- This catalog does not evaluate performance, security, operations, reliability, or cost by itself.
- This catalog cannot decide whether a hybrid architecture is intentional without supporting artifacts.
- This catalog cannot infer dependency direction when dependency evidence is unavailable.

## Traceability

Each evidence item produced from this catalog should point to the most specific available source:

- Repository or reviewed analysis scope.
- Project, package, assembly, or module when available.
- File path when available.
- Namespace, type, method, symbol, or component when available.
- Dependency relationship, import, reference, call path, or registration when relevant.
- Line or interval when available.
- Related rule result when applicable.
- Related finding when applicable.
- Evidence source, such as source code, dependency graph, rule output, review finding, document, diagram, or report section.
- Limitation of the observation, including scope, uncertainty, generated code, missing dependency graph, unsupported source fields, or conflicting evidence.

Traceability should preserve the distinction between the observed fact and the architectural interpretation supported by that fact.

The minimum usable evidence record must identify the reviewed scope, evidence source, observed fact, evidence type, direction, strength, supported interpretation, and limitations. More specific fields such as line ranges, symbols, dependency edges, rule results, and findings should be included when the source supports them, but they should not be invented or treated as mandatory for sources that cannot provide them.
