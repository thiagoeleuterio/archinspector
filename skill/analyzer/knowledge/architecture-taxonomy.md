# Architecture Taxonomy

## Taxonomy Purpose

This taxonomy defines the conceptual reference used by the Architecture Analyzer to relate architectural styles, patterns, modeling approaches, application-flow patterns, integration strategies, data strategies, deployment choices, and governance practices.

It supports calibrated architectural interpretation. It helps the Analyzer avoid conflicting labels, reduce duplicate concepts across future evidence catalogs, distinguish predominant architecture from secondary influences, and preserve traceability between observed facts, evidence, diagnosis, confidence, and limitations.

This taxonomy is documentary. It does not create evidence catalogs, executable rules, metrics, scoring models, templates, or analyzer contracts.

## Taxonomy Principles

- Architectural concepts may operate in different dimensions, including structure, dependency direction, domain modeling, application flow, integration, data consistency, deployment, runtime communication, modularity, and governance.
- Approaches in different dimensions may coexist within the same repository, system, module, or transition scope.
- Coexistence does not imply equivalence, dependency, architectural quality, or complete adoption.
- Predominance depends on the observed scope and the dimension being classified.
- A classification may be predominant in one dimension and secondary, local, partial, or unsupported in another dimension.
- Naming, folder structure, suffixes, diagrams, and framework conventions are weak signals unless corroborated by repeated and verifiable implementation evidence.
- Frameworks influence architecture but do not define architecture in isolation.
- Architecture must be inferred from repeated, observable, and verifiable structural, dependency, behavioral, operational, and governance evidence.
- Hybrid architecture is not automatically incoherent; incoherence requires evidence of conflicting responsibilities, dependency contradictions, unclear boundaries, or missing governance that affects the reviewed scope.
- Partial adoption is not automatically failure; bounded and coherent adoption may be a valid architectural choice.
- Architectural classification does not determine quality, maturity, fitness, maintainability, or team competence.
- No recognized approach is universally superior.
- Explicit documentation increases confidence when aligned with implementation evidence, but it does not prevail over contradictory implementation evidence.
- Absence of a named approach does not imply absence of architecture.
- Classification must preserve uncertainty when evidence is partial, local, indirect, contradictory, generated, unavailable, or outside the reviewed scope.

## Classification Dimensions

Architectural classification is multidimensional. A repository may be layered in structural organization, domain-oriented in modeling, event-driven in integration, monolithic in deployment, and partially governed by architecture tests at the same time. The Analyzer should classify each dimension separately before correlating them into a broader diagnosis.

| Dimension | Purpose | Examples of Observable Evidence | Commonly Associated Concepts | Classification Limitations |
| --- | --- | --- | --- | --- |
| Structural organization | Identify how responsibilities are arranged in projects, packages, modules, folders, namespaces, or components. | Solution structure, module boundaries, package layout, namespace grouping, responsibility placement across files. | Layered Architecture, Clean Architecture, Onion Architecture, Modular Monolith, MVC, Vertical Slice Architecture. | Structure alone is not architecture; folder and namespace names are weak unless dependency direction and responsibilities are visible. Structural organization describes arrangement, while modularity describes change and ownership boundaries. |
| Dependency direction | Identify which components depend on which other components and whether policy depends on details or details depend on policy. | Project references, imports, constructor dependencies, method calls, interface ownership, dependency cycles, architecture test results. | Hexagonal Architecture, Ports and Adapters, Clean Architecture, Onion Architecture, Layered Architecture. | Direction must be evaluated in production scope and may vary by valid architectural variation. Dependency direction describes allowed dependency flow, while application flow describes runtime or use-case coordination. |
| Domain organization | Identify how domain concepts, business behavior, boundaries, and language are represented. | Entities, value objects, aggregates, domain services, domain events, ubiquitous language, bounded-context-like module boundaries. | Domain-Driven Design, Domain Model, Transaction Script, Active Record. | Tactical patterns do not prove full DDD adoption, and weak domain naming does not prove domain modeling maturity. |
| Application flow | Identify how use cases, commands, queries, requests, controllers, handlers, and services coordinate work. | Controllers delegating to services, command/query handlers, use-case classes, service orchestration, vertical feature flows. | Service Layer, CQRS, MVC, Vertical Slice Architecture, Transaction Script. | Local handler or service patterns may not define repository-wide architecture. Application flow does not by itself prove dependency inversion, deployment topology, or domain modeling depth. |
| Integration style | Identify how the system integrates with external systems, services, brokers, APIs, and shared resources. | API clients, gateways, message publishers, subscribers, queues, topics, adapters, integration contracts, external resource ownership. | Event-Driven Architecture, SOA, Microservices, Hexagonal Architecture, Ports and Adapters. | Event usage, API calls, or adapters alone do not establish a system-level integration style. Integration style describes collaboration with external boundaries; runtime communication describes the mechanisms and interaction modes used during execution. |
| Data consistency | Identify how writes, reads, history, transactions, ownership, and consistency boundaries are organized. | Shared database access, separate schemas, read models, event streams, transaction boundaries, eventual consistency mechanisms, source-of-truth evidence. | CQRS, Event Sourcing, Shared Database, Database per Service, Active Record, Repository. | Data patterns may be local, infrastructure-driven, or framework-driven and should not override structural classification automatically. Persistence mechanisms such as ORM usage or repositories are not enough to classify consistency strategy. |
| Deployment topology | Identify how deployable units, runtime processes, services, and infrastructure boundaries are arranged. | Deployment manifests, service hosts, containers, process boundaries, independent deployment pipelines, runtime configuration. | Modular Monolith, Microservices, SOA, Database per Service, Shared Database. | Deployment style does not automatically define code structure, dependency direction, domain modeling approach, or quality. A repository can contain multiple deployables without microservice autonomy. |
| Runtime communication | Identify how components interact at runtime across process, module, or service boundaries. | HTTP calls, RPC clients, message brokers, synchronous requests, asynchronous messages, pub-sub flows, retries, idempotency mechanisms. | Event-Driven Architecture, Microservices, SOA, CQRS. | Communication mechanism does not prove architectural intent, autonomy, ownership, or quality. Runtime communication is about interaction mode; integration style is about the broader architectural role of those interactions. |
| Modularity | Identify how change boundaries, ownership boundaries, and internal component isolation are shaped. | Module APIs, internal visibility, bounded modules, feature boundaries, separate packages, dependency constraints. | Modular Monolith, Microservices, DDD, Vertical Slice Architecture, Layered Architecture. | Modular packaging may be nominal, partial, or unrelated to runtime deployment. Modularity may exist inside layered, vertical-slice, monolithic, or distributed structures. |
| Governance and enforcement | Identify how architectural decisions, boundaries, and conventions are documented, reviewed, or enforced. | Architecture documentation, dependency tests, review findings, contracts, conventions, build checks, diagrams aligned with code. | Architecture tests, fitness functions, coding standards, documented architecture decisions. | Governance is transversal. It supports confidence and coherence assessment but does not override implementation evidence when they conflict. |

## Architectural Categories

| Category | Definition | Examples | Must Not Be Inferred Automatically | Coexistence Model |
| --- | --- | --- | --- | --- |
| Architectural Style | A broad organizing approach that shapes system structure, dependency expectations, modularity, runtime boundaries, or deployment. | Layered Architecture, Hexagonal Architecture, Clean Architecture, Onion Architecture, Event-Driven Architecture, Microservices, Modular Monolith, SOA. | Quality, maturity, team intent, complete adoption, or universal applicability. | May coexist with patterns, domain approaches, deployment styles, and governance practices when dimensions differ or boundaries are explicit. Some approaches listed as styles also have strong secondary category relevance. |
| Architectural Pattern | A recurring solution shape for responsibilities, dependencies, boundaries, or collaboration. | Ports and Adapters, Repository, Service Layer, MVC, Vertical Slice Architecture. | Repository-wide predominance, architectural quality, or full adoption of a related style. | May implement, support, specialize, or locally influence a broader style. A pattern can be primary in a local scope and secondary in repository-level classification. |
| Domain Modeling Approach | A way of representing business concepts, behavior, language, and domain boundaries. | Domain-Driven Design, Domain Model, Transaction Script, Active Record. | Rich domain quality, bounded context maturity, strategic DDD adoption, or business correctness from tactical names alone. | May coexist with structural styles, application patterns, data patterns, deployment styles, and governance practices. |
| Application Pattern | A way of organizing use-case flow, request handling, commands, queries, orchestration, and application responsibilities. | CQRS, MVC, Service Layer, Vertical Slice Architecture, Transaction Script. | Deployment topology, domain modeling depth, dependency inversion, or complete architecture. | May coexist with styles such as Layered, Clean, Hexagonal, Modular Monolith, or Microservices. |
| Integration Pattern | A way of coordinating communication with external systems, services, brokers, APIs, adapters, or shared integration resources. | Event-Driven Architecture, messaging, API gateway, adapters, SOA service contracts. | That the entire application architecture is event-driven or service-oriented. | May coexist with structural, domain, data, deployment, and runtime communication categories. |
| Data Pattern | A way of organizing persistence, read/write models, historical state, ownership, and consistency. | Event Sourcing, Shared Database, Database per Service, Repository, Active Record. | Architectural quality, DDD adoption, CQRS adoption, service autonomy, or deployment topology without corroborating evidence. | May coexist with application, deployment, integration, and domain categories. |
| Deployment Style | A way of packaging and operating runtime units. | Modular Monolith, Microservices, SOA deployments, single deployable applications. | Code-level architecture, dependency inversion, modular quality, organizational independence, or service autonomy from packaging alone. | May coexist with structural styles and application patterns while remaining a separate dimension. |
| Organizational or Governance Practice | A practice used to document, constrain, review, or evolve architecture. | Architecture decision records, dependency policies, architecture tests, ownership rules, review processes. | Implementation conformance, quality, team intent, or architectural maturity by itself. | May increase confidence when aligned with implementation evidence and may coexist with any category. |

## Recognized Architectural Approaches

| Approach | Primary Category | Primary Dimensions | May Coexist With | Must Not Be Assumed From | Notes |
| --- | --- | --- | --- | --- | --- |
| Layered Architecture | Architectural Style | Structural organization; dependency direction; application flow | DDD, MVC, CQRS, Event-Driven Architecture, Modular Monolith, Vertical Slice Architecture | Folders named Controllers, Services, or Repositories; framework conventions | Organizes responsibilities into logical layers with expected responsibility separation. Dependency direction varies by closed, open, relaxed, or dependency-inverted layering. |
| Hexagonal Architecture | Architectural Style | Dependency direction; integration style; structural organization | DDD, CQRS, Event-Driven Architecture, Modular Monolith, Microservices, Repository | Separate projects; interfaces; adapters by name | Centers the application core and externalizes inbound and outbound adapters through ports. Often equivalent or near-equivalent with Ports and Adapters depending on source terminology. |
| Clean Architecture | Architectural Style | Dependency direction; structural organization; application flow | DDD, CQRS, Repository, Event-Driven Architecture, Modular Monolith, Onion Architecture | Project rings, use-case naming, dependency injection | Emphasizes inward dependency direction and separation between policies and details. Strongly overlaps with Onion Architecture but is not strict equivalent terminology. |
| Onion Architecture | Architectural Style | Dependency direction; structural organization; domain organization | DDD, Repository, Service Layer, CQRS, Modular Monolith, Clean Architecture | Concentric diagram names; domain folder presence | Emphasizes domain-centered dependency direction. Strongly overlaps with Clean Architecture but has distinct terminology and emphasis. |
| Domain-Driven Design | Domain Modeling Approach | Domain organization; modularity; governance and enforcement | Layered Architecture, Hexagonal Architecture, Clean Architecture, CQRS, Event Sourcing, Microservices, Modular Monolith | Entities, repositories, aggregates, or domain folder names alone | DDD is not a complete structural style by itself. It may be strategic, tactical, partial, or local; tactical patterns do not prove full adoption. Secondary categories may include governance and modularity practice. |
| CQRS | Application Pattern | Application flow; data consistency; runtime communication | DDD, Event Sourcing, Event-Driven Architecture, Layered Architecture, Clean Architecture, Microservices | Handler classes, MediatR-style pipelines, commands and queries by name | Separates command and query responsibilities. It is not a complete architecture and does not require Event Sourcing. Secondary category may be Data Pattern when read and write models have distinct persistence concerns. |
| Event-Driven Architecture | Integration Pattern | Integration style; runtime communication; data consistency | Microservices, Modular Monolith, CQRS, Event Sourcing, Layered Architecture, Hexagonal Architecture | Publishing one event, using callbacks, or having event-named classes | Requires event-driven collaboration to materially shape system behavior or integration. It does not depend on microservices and may exist inside monoliths. Secondary category may be Architectural Style when events shape system-level organization. |
| Modular Monolith | Deployment Style | Deployment topology; modularity; structural organization | Layered Architecture, DDD, CQRS, Event-Driven Architecture, Clean Architecture, Vertical Slice Architecture | Single deployable unit alone; multiple folders or projects | Uses one deployable unit with meaningful internal module boundaries. Multiple modules alone do not prove modularity. Secondary category may be Architectural Style when modular boundaries shape code organization. |
| Microservices | Deployment Style | Deployment topology; runtime communication; integration style; data consistency | DDD, CQRS, Event-Driven Architecture, Database per Service, Hexagonal Architecture | Multiple projects, multiple APIs, containers, service naming, or separate repositories alone | Requires independently deployable services with meaningful runtime, ownership, and data boundaries in the reviewed scope. Secondary category may be Architectural Style when service boundaries shape system organization. |
| Service-Oriented Architecture | Architectural Style | Integration style; runtime communication; deployment topology | Microservices, Shared Database, Event-Driven Architecture, Layered Architecture | Any service class, API endpoint, or remote call | Organizes capabilities as services, often with enterprise integration and contract concerns. It is adjacent to Microservices but does not imply the same granularity, autonomy, or data ownership. |
| MVC | Application Pattern | Application flow; structural organization | Layered Architecture, Modular Monolith, Microservices, Service Layer | Web framework usage alone | Primarily organizes presentation interaction and request handling, not the whole application architecture by itself. |
| Vertical Slice Architecture | Application Pattern | Application flow; structural organization; modularity | CQRS, Modular Monolith, Layered Architecture, Clean Architecture, DDD | Feature folders alone | Organizes behavior around features or use cases. It may coexist with local layering inside slices or compete with repository-wide layer-first organization in the same scope. |
| Ports and Adapters | Architectural Pattern | Dependency direction; integration style; structural organization | Hexagonal Architecture, DDD, CQRS, Event-Driven Architecture, Clean Architecture | Interfaces, adapters, gateway suffixes, dependency injection | Often equivalent or near-equivalent terminology with Hexagonal Architecture depending on source. Treat source vocabulary and observed port ownership as distinguishing evidence. |
| Transaction Script | Domain Modeling Approach | Application flow; domain organization | Layered Architecture, MVC, Service Layer, Modular Monolith | Services with procedural code alone | Organizes business logic as procedural scripts per transaction; may be coherent in simple domains and is not automatically inferior. Secondary category may be Application Pattern. |
| Domain Model | Domain Modeling Approach | Domain organization; application flow | DDD, Layered Architecture, Clean Architecture, Onion Architecture, Hexagonal Architecture | Entity classes or ORM models alone | Represents business concepts and behavior. It is not equivalent to full DDD and does not prove strategic modeling. |
| Active Record | Data Pattern | Data consistency; domain organization; application flow | MVC, Layered Architecture, Transaction Script, Modular Monolith | ORM usage alone | Combines data access behavior with domain-like objects; may conflict with strict persistence isolation when applied to inner policy code. Secondary category may be Domain Modeling Approach in simple domains. |
| Service Layer | Application Pattern | Application flow; structural organization | Layered Architecture, MVC, DDD, CQRS, Modular Monolith | Classes suffixed Service | Defines application operations and coordinates use cases or transactions. It does not prove Layered Architecture when service classes are pass-through or purely nominal. |
| Repository | Data Pattern | Data consistency; dependency direction; domain organization | DDD, Layered Architecture, Clean Architecture, Hexagonal Architecture, Onion Architecture | Repository interfaces, CRUD wrappers, ORM sets, or naming alone | Can abstract persistence access, but does not prove DDD, Clean Architecture, Hexagonal Architecture, or dependency inversion by itself. Secondary category may be Architectural Pattern when it acts as a boundary pattern. |
| Event Sourcing | Data Pattern | Data consistency; runtime communication; domain organization | CQRS, DDD, Event-Driven Architecture, Microservices, Modular Monolith | Audit logs, event tables, message brokers, or domain events alone | Stores state changes as events used to reconstruct state. It is often associated with CQRS but is not equivalent to CQRS. |
| Shared Database | Data Pattern | Data consistency; deployment topology; integration style | Layered Architecture, SOA, Modular Monolith, some Microservices transitions | Multiple modules using one database name | Indicates shared persistence ownership only when access and ownership evidence are visible. It is primarily a data and deployment concern, not a complete architecture. |
| Database per Service | Data Pattern | Data consistency; deployment topology; runtime communication | Microservices, Event-Driven Architecture, CQRS, Event Sourcing | Separate schemas, connection strings, repositories, or database names alone | Supports service autonomy when ownership, access boundaries, and runtime deployment align. It is primarily a data and deployment concern, not a complete architecture. |

## Relationship Model

| Relationship Type | Direction or Symmetry | Meaning | Permitted Use | Distinction From Adjacent Types | Example |
| --- | --- | --- | --- | --- | --- |
| Equivalent terminology | Symmetric within a named source tradition or documented context. | Two names are used for substantially the same concept in the relevant context. | Use cautiously when evidence or source terminology supports treating labels as interchangeable for the reviewed scope. | Stronger than conceptual overlap; should not be used only because two approaches share techniques. | Hexagonal Architecture and Ports and Adapters may be equivalent or near-equivalent depending on source. |
| Conceptual overlap | Symmetric. | Two concepts share important ideas but keep distinct histories, emphasis, or classification boundaries. | Use when approaches can look similar but should not be collapsed into one label. | Weaker than equivalent terminology and broader than implementation variant. | Clean Architecture and Onion Architecture have strong overlap but are not strict equivalents. |
| Specialization | Directional from narrower concept to broader concept. | One concept narrows, refines, or specializes another broader concept. | Use only when the narrower concept inherits the broader concept's central concern and adds constraints. | Different from implementation variant because the narrower concept changes conceptual scope, not only implementation form. | A strict form of layered architecture can specialize general layered organization. |
| Implementation variant | Directional from variant to implemented concept. | One concept is a specific way to implement, express, or operationalize another concept without becoming a conceptual subtype. | Use when the relationship is about realization technique or physical expression. | Different from specialization because it describes how a concept is implemented, not a narrower architectural concept. | Physical layers across projects can be an implementation variant of Layered Architecture. |
| Complementary | Usually symmetric. | Concepts address different dimensions and can reinforce each other without being dependent. | Use when both can be true and each adds separate explanatory value. | Stronger than independent because the concepts can mutually support interpretation. | Layered Architecture and DDD may be complementary. |
| Commonly coexisting | Symmetric. | Concepts are often observed together but neither proves, requires, or implements the other. | Use for frequent pairings where co-occurrence should not become inference. | Weaker than complementary because coexistence may be historical or practical rather than mutually reinforcing. | DDD and CQRS commonly coexist but are not dependent. |
| Potentially conflicting | Usually symmetric within the same scope and dimension. | Concepts may create tension when their expectations are applied to the same dimension without clear boundaries. | Use when coexistence is possible but requires scoping, boundary clarity, or explicit trade-offs. | Does not mean absolute incompatibility and should not be reported as failure by default. | Active Record may conflict with strict Clean Architecture when persistence concerns enter inner policy code. |
| Context-dependent conflict | Usually symmetric, scope-sensitive. | Concepts may be compatible or conflicting depending on scope, dependency direction, deployment, or boundary organization. | Use when the same pair can be coherent in one scope and competing in another. | Broader and more conditional than potentially conflicting. | Vertical Slice and Layered may coexist or compete depending on boundary organization. |
| Independent | Symmetric. | Concepts operate on unrelated dimensions or do not materially influence each other in the reviewed scope. | Use when one classification should not affect the other. | Does not mean coexistence is impossible; it means there is no meaningful relationship for classification. | A local presentation MVC pattern may be independent from a database ownership pattern in another service. |

Additional examples:

- CQRS and Event Sourcing: commonly associated, not equivalent.
- Modular Monolith and Microservices: context-dependent conflict or usually alternative when they describe the same deployment scope.
- MVC and Layered Architecture: commonly coexisting but not equivalent.
- Repository and DDD: complementary or commonly coexisting, not proof of DDD.
- Event-Driven Architecture and Microservices: commonly coexisting, not dependent.
- Shared Database and Database per Service: usually alternative data ownership strategies at the same scope.

## Coexistence Matrix

Legend:

- `Common`: Frequently observed together and usually conceptually compatible.
- `Compatible`: Can coexist when dimensions and boundaries are clear.
- `Context-Dependent`: May coexist or compete depending on scope, dependency direction, or boundary organization.
- `Tension`: May pull design decisions in different directions and requires careful scoping.
- `Usually Alternative`: Usually different choices for the same dimension or scope, though localized or transitional coexistence may occur.
- `Not Applicable`: Same concept compared with itself.

| Concept | Layered | Hexagonal | Clean | Onion | DDD | CQRS | Event-Driven | Modular Monolith | Microservices | MVC | Vertical Slice |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Layered | Not Applicable | Context-Dependent | Context-Dependent | Context-Dependent | Common | Common | Compatible | Common | Compatible | Common | Context-Dependent |
| Hexagonal | Context-Dependent | Not Applicable | Compatible | Compatible | Common | Common | Common | Compatible | Common | Compatible | Compatible |
| Clean | Context-Dependent | Compatible | Not Applicable | Common | Common | Common | Compatible | Compatible | Compatible | Compatible | Compatible |
| Onion | Context-Dependent | Compatible | Common | Not Applicable | Common | Common | Compatible | Compatible | Compatible | Compatible | Compatible |
| DDD | Common | Common | Common | Common | Not Applicable | Common | Common | Common | Common | Compatible | Compatible |
| CQRS | Common | Common | Common | Common | Common | Not Applicable | Common | Compatible | Common | Compatible | Common |
| Event-Driven | Compatible | Common | Compatible | Compatible | Common | Common | Not Applicable | Compatible | Common | Compatible | Compatible |
| Modular Monolith | Common | Compatible | Compatible | Compatible | Common | Compatible | Compatible | Not Applicable | Usually Alternative | Compatible | Common |
| Microservices | Compatible | Common | Compatible | Compatible | Common | Common | Common | Usually Alternative | Not Applicable | Compatible | Compatible |
| MVC | Common | Compatible | Compatible | Compatible | Compatible | Compatible | Compatible | Compatible | Compatible | Not Applicable | Context-Dependent |
| Vertical Slice | Context-Dependent | Compatible | Compatible | Compatible | Compatible | Common | Compatible | Common | Compatible | Context-Dependent | Not Applicable |

The matrix is a starting point for interpretation, not a list of absolute compatibility claims. Context, scope, evidence quality, and dimension separation decide the final language. `Usually Alternative` should be used only when the approaches normally represent alternative choices in the same dimension and scope; it does not exclude localized, transitional, or multi-scope coexistence.

## Predominance Model

Predominant architecture is the approach that most strongly shapes the reviewed scope across repeated structural and behavioral evidence within a specific dimension. Predominance does not mean exclusivity.

The Analyzer should consider:

- Breadth across the reviewed repository or declared analysis scope.
- Repetition across comparable modules, features, services, or flows.
- Dependency direction and dependency exceptions.
- Consistency of boundaries and responsibility placement.
- Influence on application flow.
- Influence on module organization and change boundaries.
- Integration style and deployment topology evaluated separately.
- Declared intent when aligned with implementation evidence.
- Contradictory evidence and its severity for the reviewed scope.
- Scope, frequency, and explanation of exceptions.

Classification guidance:

- A pattern should not be called predominant when it affects only one local component or a narrow flow.
- Deployment topology should not automatically override structural organization.
- DDD tactical patterns alone should not create predominance for DDD.
- Naming, suffixes, folders, framework conventions, and diagrams do not create predominance without stronger evidence.
- Predominance may be assigned only within a specific dimension, such as structural organization, deployment topology, or integration style.
- `Insufficient Evidence` is valid when available facts do not support a reliable classification.
- Confidence must reflect quality, independence, contradiction level, and coverage of evidence.
- Predominance should narrow when exceptions are systemic, unexplained, or central to important flows.

Possible outputs:

- `Predominant`: The approach shapes the primary organization of the reviewed scope in a named dimension with broad, repeated, coherent, and verifiable evidence.
- `Strong Secondary Influence`: The approach materially affects multiple modules, important flows, or key decisions but does not control the main classification dimension.
- `Secondary Influence`: The approach is visible and meaningful but limited to specific dimensions, modules, flows, or concerns.
- `Localized Pattern`: The approach is present in a narrow area and should not be generalized to the repository.
- `Partial Adoption`: The approach appears in a bounded scope but is not consistently or completely applied across the expected boundary; it may be coherent or incomplete depending on evidence.
- `Insufficient Evidence`: Available evidence does not support a reliable classification.

## Secondary Influence Model

A secondary influence is an approach that changes design decisions without becoming the main architectural classification for the reviewed scope.

Distinctions:

- `Strong Secondary Influence`: Repeated and material influence across multiple modules, key flows, or a major dimension, while another approach remains predominant.
- `Secondary Influence`: Meaningful influence in a limited dimension, concern, or subset of modules, without controlling the global model.
- `Localized Pattern`: A pattern visible in a narrow area, feature, adapter, module, or flow.
- `Partial Adoption`: An approach applied to part of its expected boundary; it may be coherent, incomplete, experimental, legacy, superficial, abandoned, or unsupported by enough evidence.

Criteria include:

- The influence affects real design decisions, not only names.
- The influence may be limited to certain dimensions.
- The influence does not control the global model.
- The influence may complement the predominant architecture.
- The influence may be intentional or emergent.
- Evidence should appear in more than one occurrence unless the reviewed scope is explicitly narrow.
- Confidence should narrow when evidence is local, indirect, or contradicted.

Recommended calibrated language:

- "The repository is predominantly layered, with a strong secondary influence from Domain-Driven Design."
- "CQRS appears as a secondary application-flow influence in selected use cases."
- "Event-driven integration is present, but it does not define the primary application architecture."
- "Repository usage is a localized persistence pattern and does not by itself support a DDD classification."
- "The observed vertical slices influence feature organization without replacing the repository-wide layered structure."

## Hybrid Architecture Model

Hybrid architecture means more than one architectural approach is present in meaningful scope. Hybrid does not automatically mean incoherent. A hybrid classification should be treated as a problem only when evidence shows impact, incoherence, unclear boundaries, dependency contradiction, or missing governance in the reviewed scope.

| Type | Characteristics | Evidence Expectations | Diagnostic Language | Common Risks | Must Not Be Assumed |
| --- | --- | --- | --- | --- | --- |
| Intentional hybrid architecture | Different approaches are applied deliberately to different dimensions, modules, or contexts. | Documentation, consistent boundaries, repeated patterns, clear exceptions, implementation evidence aligned with stated intent. | "The system combines logical layering with localized vertical slices." | Boundary drift, terminology confusion, inconsistent enforcement. | That mixed styles are incoherent, casual, or lower quality. |
| Emergent hybrid architecture | Multiple approaches appear through accumulated implementation choices without clear declared intent, but with some repeated shape. | Repeated mixed structures, uneven conventions, partial but observable patterns, limited documentation. | "The repository shows an emergent hybrid structure with layered and feature-oriented organization." | Unclear ownership, inconsistent dependency expectations, diagnosis ambiguity. | That the team intended the mix or that it is already harmful. |
| Transitional architecture | Old and new approaches coexist during migration or modernization. | Evidence of migration boundaries, newer modules following different patterns, legacy areas retained, documented or inferable transition scope. | "The evidence is consistent with a transitional architecture between a layered monolith and modularized boundaries." | Long-lived duplication, partial migrations, conflicting conventions. | That migration failed, will complete, or represents incomplete implementation without evidence. |
| Locally specialized architecture | A specific area uses a different pattern for justified or bounded local needs. | Local repetition, clear scope, stable boundary with the rest of the system, proportionate exception. | "The reporting module uses a localized CQRS-style flow within a predominantly layered architecture." | Overgeneralizing local exceptions, hidden coupling. | That the local pattern defines the repository-wide architecture or is inconsistent by default. |
| Inconsistent architecture | Approaches conflict in the same dimension or scope and create unclear responsibilities, dependency contradictions, or boundary confusion. | Contradictory dependencies, responsibility mixing, repeated boundary violations, conflicting conventions in comparable areas. | "The implementation shows inconsistent boundary expectations in the reviewed scope." | Maintainability risk, unclear change impact, fragile dependencies. | Root cause, negligence, failed intent, or low quality without evidence. |
| Fragmented architecture | Many unrelated local patterns exist without coherent repository-level organization or repeated organizing logic. | Low repetition, unrelated structures, inconsistent module boundaries, broad uncertainty, limited governing constraints. | "The available evidence suggests fragmented architectural organization rather than a coherent predominant style." | Difficult classification, uneven evolution, hidden coupling. | Absence of architecture, absence of quality, or intentional fragmentation by default. |

## Partial Adoption Model

Partial adoption means an approach appears in some scope but does not fully define the expected boundary. It should be separated from failure language unless evidence supports inconsistency, abandonment, or impact.

| Type | Indicators | Confidence Considerations | Recommended Diagnostic Language | Language to Avoid |
| --- | --- | --- | --- | --- |
| Partial but coherent adoption | A bounded scope consistently applies the approach while other scopes use different valid approaches. | Higher when scope boundaries and dependency expectations are clear. | "The evidence supports coherent partial adoption of Ports and Adapters in the integration boundary." | "The architecture is incomplete." |
| Incomplete implementation | Declared intent or expected boundary exists, but implementation is missing or uneven in important areas. | Requires explicit intent, expected boundary, or repeated interrupted pattern plus contradictory implementation evidence. | "The implementation appears incomplete relative to the declared Clean Architecture dependency model." | "The team failed Clean Architecture." |
| Experimental adoption | The approach appears in limited, isolated, or new areas with signs of exploration or trial scope. | Lower unless documentation, change history, isolation, or limited rollout supports experiment scope. | "The pattern appears experimental or localized based on the available evidence." | "The repository is moving to this architecture." |
| Legacy coexistence | Older modules retain one approach while newer modules use another. | Requires scope distinction and caution about historical intent. | "Legacy coexistence may explain the mixed structure, but intent cannot be confirmed from the available evidence." | "The migration failed." |
| Superficial adoption | Names, folders, diagrams, or framework constructs are present but stronger behavior or dependency evidence does not confirm adoption. | Low to medium depending on contradiction strength and coverage. | "Architectural naming is present, but implementation evidence does not confirm coherent adoption." | "The architecture is fake." |
| Abandoned adoption | Remnants of an approach remain but are unused, contradicted, isolated from current flows, or disconnected from active boundaries. | Requires verifiable evidence that remnants do not participate meaningfully in current behavior. | "The observed remnants are consistent with abandoned or obsolete adoption, within the reviewed scope." | "The team abandoned this deliberately." |
| Insufficient evidence | Signals exist but are too weak, local, unavailable, or contradictory to support classification. | Confidence should remain `Insufficient Evidence`. | "The available evidence is insufficient to classify adoption of this approach." | "The approach is absent." |

## Classification Conflicts

| Conflict | Why Confusion Occurs | Distinguishing Dimension | Minimum Evidence Needed | Safe Classification Language |
| --- | --- | --- | --- | --- |
| Layered versus Clean | Clean often uses layer-like separation, and projects may be named similarly. | Dependency direction and policy/detail separation. | Interface ownership, inward dependencies, responsibility placement, repeated flow evidence. | "The repository shows layered structure with some Clean Architecture characteristics." |
| Layered versus Hexagonal | Both separate technical concerns from application or domain code. | Ports, adapters, and dependency direction around application core. | Inbound and outbound boundary evidence, port ownership, adapter isolation. | "The implementation shows partial Ports and Adapters adoption, but the dependency model is not consistently hexagonal." |
| Clean versus Onion | Both emphasize inward dependencies and domain-centric organization. | Conceptual framing, use-case organization, dependency rings, source terminology. | Dependency evidence plus documentation or repeated structural conventions. | "Clean and Onion characteristics overlap in the observed dependency model; the available evidence does not support a more specific classification." |
| Hexagonal versus Ports and Adapters | The terms are often used as equivalent or near-equivalent. | Source terminology and conceptual scope. | Documentation, boundary naming, adapter and port responsibilities. | "The observed structure is consistent with Hexagonal Architecture, also commonly described as Ports and Adapters." |
| DDD versus Domain Model | DDD tactical patterns may look like a domain model. | Domain organization and strategic modeling scope. | Domain behavior, ubiquitous language, aggregate boundaries, bounded context evidence, governance signals. | "A domain model is present; full DDD adoption is not confirmed by the available evidence." |
| CQRS versus Event Sourcing | They are commonly paired in examples and systems. | Application flow versus persistence history model. | Separate command/query responsibilities for CQRS; event stream as source of truth for Event Sourcing. | "CQRS-style flow is present; Event Sourcing is not established without event-store evidence." |
| Modular Monolith versus Microservices | Both may have many modules, APIs, or service-like boundaries. | Deployment topology and runtime autonomy. | Deployable unit boundaries, independent runtime evidence, data ownership, service communication. | "The available evidence supports modular monolith classification at the deployment and modularity levels." |
| MVC versus application architecture | MVC frameworks impose visible folders and request flow. | Presentation/application flow versus full system structure. | Evidence beyond controllers and views, including dependency direction and responsibility placement. | "MVC structures the presentation layer, while application architecture remains classified separately." |
| Vertical Slice versus Layered | Feature folders can cut across layers, while slices may still contain internal layering. | Boundary organization and application flow. | Feature boundary consistency, dependency paths inside and across slices, responsibility placement. | "The system combines logical layering with localized vertical slices." |
| SOA versus Microservices | Both expose services and network contracts. | Deployment autonomy, service granularity, data ownership, operational independence. | Runtime boundaries, service ownership, data access, integration contracts, deployment evidence. | "The system shows service-oriented integration; microservice autonomy is not confirmed." |
| Repository pattern versus persistence abstraction | CRUD wrappers, ORM repositories, and domain repositories may share names. | Data pattern and dependency ownership. | Interface ownership, abstraction purpose, persistence access paths, domain relevance. | "Repository abstractions are present, but they do not prove DDD or Clean Architecture by themselves." |
| Event-Driven Architecture versus event usage | Many systems publish events for notifications, hooks, or local decoupling. | Integration style and runtime communication influence. | Event-driven workflows, subscribers, broker behavior, asynchronous coordination across meaningful scope. | "Event-driven integration is present, although the application architecture remains predominantly layered." |

No conflict should be resolved by naming or documentation alone. Documentation can frame the expected model, but implementation evidence should determine final confidence when the two diverge.

## Misclassification Risks

| Risk | Common Error | Why It Happens | Evidence Needed to Avoid Misclassification | Safe Language When Evidence Is Insufficient |
| --- | --- | --- | --- | --- |
| Folder organization | Classifying folder organization as architecture. | Folder names are visible and familiar. | Dependency direction, responsibility placement, repeated flows. | "Folder structure suggests candidates for review, but architecture is not confirmed." |
| Framework conventions | Classifying framework conventions as architecture. | Frameworks generate recognizable folders, classes, and flows. | Evidence that conventions shape repository-level boundaries beyond framework defaults. | "Framework conventions are present, but architectural style remains unconfirmed." |
| Single pattern generalization | Treating a single pattern as the complete architecture. | Local patterns are easier to observe than repository-wide structure. | Breadth and repetition across comparable scope. | "The pattern is localized in the reviewed scope." |
| Deployment/code confusion | Confusing deployment topology with code structure. | Services, projects, and containers can resemble architectural boundaries. | Deployable units plus code dependency and responsibility evidence. | "Deployment topology should be classified separately from code organization." |
| Tactical DDD inflation | Confusing DDD tactical patterns with full DDD adoption. | Entities, repositories, and aggregates are often named explicitly. | Domain behavior, ubiquitous language, bounded contexts, governance signals. | "Tactical domain patterns are visible, but full DDD adoption is not confirmed." |
| Event publication inflation | Classifying event publication as Event-Driven Architecture. | Events are easy to spot in code and infrastructure. | Event-driven workflows, subscribers, broker use, asynchronous coordination across meaningful scope. | "Event usage is present, but event-driven architecture is not confirmed." |
| Service count inflation | Classifying multiple services as Microservices. | Multiple APIs, projects, or containers look like service autonomy. | Independent deployment, runtime boundaries, ownership, data autonomy. | "Multiple services are present, but microservice autonomy is not confirmed." |
| Project separation inflation | Classifying separate projects as Clean or Hexagonal. | Physical separation resembles rings, layers, or adapters. | Inward dependencies, policy/detail separation, port ownership, adapter isolation. | "Project separation is present, but Clean or Hexagonal dependency expectations are not confirmed." |
| Repository as DDD proof | Classifying repository interfaces as proof of DDD. | Repository is common DDD vocabulary. | Domain relevance, abstraction ownership, aggregate persistence boundaries, corroborating domain evidence. | "Repository abstractions are present, but DDD is not confirmed." |
| Dependency injection inflation | Treating dependency injection as proof of dependency inversion. | Dependency injection frameworks are common in dependency-inverted designs. | Interface ownership, dependency direction, stable policy boundaries. | "Dependency injection is present, but dependency inversion is not confirmed." |
| Handler naming inflation | Treating CQRS handlers as proof of CQRS. | Command and query names are common in mediator patterns. | Separate command/query responsibilities and, when relevant, distinct read/write models. | "Handler naming is present, but CQRS remains unconfirmed." |
| MVC overreach | Treating MVC as the entire application architecture. | MVC frameworks make presentation structure prominent. | Evidence beyond presentation, including application flow, dependencies, and boundaries. | "MVC structures presentation flow; application architecture remains separately classified." |
| Hybrid problem assumption | Interpreting hybrid architecture as inconsistency by default. | Mixed labels can look contradictory. | Same-scope conflict, unclear boundaries, contradictory dependencies, or impact evidence. | "The architecture is hybrid; inconsistency is not established." |
| Legacy migration assumption | Interpreting legacy coexistence as failed migration without evidence. | Older and newer patterns may coexist visibly. | Historical, documentation, change, or boundary evidence showing failed transition. | "Legacy coexistence may be present, but migration outcome is not confirmed." |
| Quality from style | Assuming architecture quality from architectural style. | Some styles are treated as inherently better. | Evidence-supported strengths, risks, and consequences. | "Style classification does not determine quality." |

## Analyzer Guidance

The Analyzer should use this flow:

1. Collect observable facts.
2. Classify each fact by dimension.
3. Identify candidate approaches.
4. Identify relationship types.
5. Evaluate repository breadth and repetition.
6. Identify predominant structural organization.
7. Identify secondary influences.
8. Identify deployment and integration styles separately.
9. Identify hybrid or partial adoption.
10. Record contradictory evidence.
11. Resolve classification conflicts.
12. Assign confidence.
13. State limitations.
14. Produce calibrated diagnostic language.

Rules for calibrated use:

- Do not force a single label.
- Do not merge distinct dimensions into one conclusion.
- Do not classify by naming alone.
- Do not infer team intent without evidence.
- Do not recommend migration based only on classification.
- Do not treat secondary influence as predominant.
- Do not treat local patterns as repository-wide architecture.
- Do not hide contradictory evidence.
- Do not equate architectural classification with architectural quality.
- Do not replace evidence catalogs.
- Do not replace the Rule Engine.

Examples of calibrated language:

- `The repository is predominantly layered in structural organization, with a strong secondary influence from Domain-Driven Design in domain organization.`
- `The system combines logical layering with localized vertical slices.`
- `The implementation shows partial adoption of Ports and Adapters, but the dependency model is not consistently hexagonal.`
- `Event-driven integration is present, although the application architecture remains predominantly layered.`
- `The available evidence supports a modular monolith classification at the deployment and modularity levels.`
- `Clean and Onion characteristics overlap in the observed dependency model; the available evidence does not support a more specific classification.`
- `The available evidence is insufficient to classify the deployment topology beyond a single reviewed deployable.`

## Extension Rules

Future catalogs must follow these rules:

- Every catalog must declare its primary category.
- Every catalog must declare affected dimensions.
- Every catalog must reference this taxonomy.
- Every catalog must declare equivalent terminology, when relevant.
- Every catalog must document conceptual overlaps.
- Every catalog must document potential, context-dependent, and same-scope conflicts.
- Every catalog must identify distinguishing dimensions for adjacent approaches.
- Every catalog must state the scope of classification.
- Every catalog must preserve calibrated language.
- Every catalog must distinguish local behavior from repository-wide behavior.
- Every catalog must state known limitations.
- Evidence catalogs must not redefine taxonomy globally.
- New approaches must not be added without category and dimension classification.
- New relationship types require taxonomy revision.
- Catalogs must not use classification as a quality score.
- Catalogs may question or propose revisions to this taxonomy, but must not silently overwrite it.

Checklist for adding a new approach:

- Name the approach consistently.
- Declare its primary category.
- Declare secondary categories when relevant.
- Declare primary dimensions affected by the approach.
- Distinguish it from adjacent approaches.
- Document equivalent or near-equivalent terminology.
- Document conceptual overlaps.
- Document common coexistence relationships.
- Document potential or context-dependent conflicts.
- Define what must not be assumed from names, frameworks, documentation, or local patterns.
- Define local versus repository-wide classification behavior.
- Provide calibrated classification language.
- State known limitations.
- Confirm that the approach does not redefine existing taxonomy concepts globally.
- Confirm that the approach does not introduce scoring, metrics, or executable rules.

## Known Limitations

- This taxonomy is conceptual and documentary.
- This taxonomy does not execute classification.
- This taxonomy does not collect evidence.
- This taxonomy does not calculate score.
- This taxonomy does not replace evidence catalogs.
- This taxonomy does not replace the Rule Engine.
- This taxonomy does not determine architectural quality.
- This taxonomy does not know business context.
- This taxonomy does not confirm team intent.
- This taxonomy may require extension for specialized domains.
- This taxonomy may contain relationships that remain context-dependent.

## Traceability

Each future classification should point to:

- Taxonomy approach.
- Primary category.
- Secondary categories, when relevant.
- Dimensions.
- Relationship type.
- Evidence IDs.
- Findings.
- Rule results.
- Repository scope.
- Contradictory evidence.
- Confidence.
- Limitations.

Minimum usable classification traceability requires:

- Taxonomy approach or `Undetermined`.
- Primary category or `Undetermined`.
- At least one classified dimension.
- Reviewed scope.
- Evidence IDs or explicit evidence source references.
- Supported interpretation.
- Confidence.
- Limitations.

Fields such as secondary categories, relationship type, findings, rule results, and contradictory evidence should be included when available, but they must not be invented or made artificially mandatory when the reviewed source cannot provide them.

Traceability must preserve the distinction between observed facts and architectural interpretation. It should also preserve the classification dimension so that structural organization, domain modeling, integration style, data consistency, deployment topology, runtime communication, modularity, and governance are not collapsed into one unsupported conclusion.
