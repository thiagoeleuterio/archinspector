# Events & Messaging Rule Catalog

## 1. Purpose

This catalog defines the planned official Events and Messaging rules for ArchInspector.

The catalog identifies candidate rule identities, titles, responsibilities, evidence expectations, overlap boundaries, and coverage responsibilities for evidence-driven review of events, messaging, asynchronous communication, message delivery, event-oriented processing, consistency between persistence and publication, and operational reliability of producers and consumers.

This catalog is an inventory and planning artifact. It does not define complete rule documents, findings, recommendations, scoring, knowledge content, templates, examples, evaluation assets, implementation code, or product-specific configuration.

## 2. Scope

Events and Messaging rules evaluate architectural concerns related to:

- domain events;
- integration events;
- asynchronous messages;
- producers;
- publication;
- persistence-to-publication consistency;
- delivery assumptions;
- consumers;
- retries;
- dead-letter handling;
- poison message handling;
- idempotency;
- duplicate handling;
- ordering;
- contract evolution;
- correlation;
- traceability;
- replay;
- operational recovery.

The catalog does not make event-driven architecture, messaging, asynchronous communication, a broker, a queue, a topic, Transactional Outbox, event sourcing, microservices, architectural tests, or any product-specific messaging technology universally required.

## 3. Architectural Principles

Rules in this catalog must remain:

- atomic: each rule evaluates one messaging or event concern;
- evidence-driven: each outcome must be supported by reviewed material;
- technology-neutral: no rule depends on a specific broker, framework, language, package, cloud service, or library;
- context-aware: legitimate synchronous communication and legitimate absence of messaging can be `Not Applicable`;
- independently evaluable: shared evidence may exist, but each rule must produce an independent conclusion;
- outcome-complete: each future rule must support `Pass`, `Fail`, `Warning`, `Not Applicable`, and `Not Enough Evidence`;
- stable: published rule meaning must not shift to absorb adjacent catalog responsibilities.

## 4. Catalog Conventions

The official taxonomy defines the category name as `Events and Messaging` and the official prefix as `MSG`.

Rule IDs in this catalog therefore use `MSG-NNN`, with sequence numbers scoped to the Events and Messaging category.

The repository contains an older incomplete file at `skill/rules/events/EVENT-001.md`. This catalog does not use `EVENT` as the official prefix because `TAXONOMY.md` explicitly defines `MSG` for Events and Messaging. This catalog does not alter that existing file.

Catalog entries use concise planned-rule metadata rather than the full 20-field rule document structure defined by `SPECIFICATION.md`. Complete rule files, if created in a later module, must use the official 20-field specification.

## 5. Evidence Principles

Future rules in this catalog must be evaluated from concrete reviewed material such as:

- production code;
- tests;
- producer behavior;
- consumer behavior;
- message contracts;
- schemas;
- configuration;
- acknowledgement behavior;
- checkpoint behavior;
- processing records;
- persisted publication records;
- error handling;
- retry handling;
- dead-letter handling;
- logs;
- traces;
- metrics;
- architectural documentation;
- architectural decisions.

Naming, folders, comments, topic names, queue names, message class names, or the mere presence of a broker are supporting signals only. They are not sufficient by themselves to produce confirmed architectural conclusions.

## 6. Outcome Principles

Each future rule must define distinct conditions for:

- `Pass`: reviewed evidence supports that the responsibility is satisfied in the relevant scope;
- `Fail`: reviewed evidence confirms a violation or architectural risk;
- `Warning`: reviewed evidence shows partial, inconsistent, weak, or emerging risk;
- `Not Applicable`: the responsibility is legitimately outside the reviewed scope or system context;
- `Not Enough Evidence`: the responsibility may be relevant, but evidence is missing, incomplete, indirect, conflicting, or too narrow.

Severity must be derived from demonstrated architectural impact, not from the rule ID or category. Confidence must follow the official confidence levels and must not be upgraded by naming alone.

## 7. Internal Boundaries

Domain event concerns and integration event concerns are intentionally separate.

Domain event rules evaluate whether a message represents a domain-significant fact inside a domain context. They do not require external transport and do not evaluate the whole domain model.

Integration event rules evaluate communication contracts across architectural boundaries. They do not require Domain-Driven Design and do not turn every asynchronous message into a domain event.

Publication consistency is separate from any specific publication mechanism. A future rule may recognize Transactional Outbox or an equivalent transactional capture mechanism without making one pattern universal.

Delivery semantics, idempotency, duplicate handling, ordering, retries, dead-letter handling, poison message handling, and replay safety are separate because they can produce independent findings from shared evidence.

## 8. Cross-Catalog Boundaries

Domain-Driven Design owns aggregate boundaries, bounded contexts, ubiquitous language, domain services, repositories as domain-facing concepts, entities, value objects, domain invariants, and the existence of domain events as a DDD modeling concern.

Fowler Patterns owns Repository, Unit of Work, Data Mapper, Service Layer, Remote Facade, Data Transfer Object, Optimistic Offline Lock, Pessimistic Offline Lock, and other Fowler enterprise patterns.

Hexagonal Architecture owns ports, adapters, drivers, driven actors, inside/outside boundaries, adapter model leakage, and core isolation from infrastructure.

Clean Architecture owns entities, use cases, interface adapters, frameworks and drivers, gateways, controllers, presenters, boundary data structures, flow of control, and the Dependency Rule.

Layered Architecture owns declared layer responsibility, layer dependency direction, layer bypass, presentation/application/domain/data-access placement, and layer contract integrity.

SOLID owns object-oriented responsibility, extension, substitutability, interface segregation, and dependency inversion concerns when those principles are the primary evaluated condition.

Architecture Testing owns verification mechanisms for architectural constraints. Tests may be evidence for this catalog, but this catalog does not require a specific architecture testing tool or pipeline.

## 9. Rule Catalog

| Rule ID | Title | Category | Objective | Architectural responsibility | Applicability summary | Primary evidence | Principal false-positive risk | Principal false-negative risk | Related entries | Cross-catalog boundary |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| MSG-001 | Domain event semantics | Events and Messaging | Evaluate whether a domain event represents a completed domain-significant fact rather than a technical notification or command. | Preserve domain-event meaning without evaluating the whole domain model. | Applies when reviewed material contains or claims domain events. | Domain event types, raising points, state transitions, domain tests, domain documentation. | Treating any event-like name as a domain event. | Missing behavior because only declarations or names were inspected. | MSG-002, MSG-006 | DDD owns domain model quality and DDD domain-event existence. |
| MSG-002 | Integration event boundary | Events and Messaging | Evaluate whether an integration event is a stable communication contract across a boundary rather than leakage of an internal model. | Preserve the boundary between internal state and external communication contract. | Applies when messages cross component, module, service, process, or context boundaries. | Published contracts, schemas, producer mappings, consumer usage, architectural decisions. | Requiring DDD or bounded contexts for every integration message. | Missing contract leakage hidden behind mapping or serialization layers. | MSG-001, MSG-007, MSG-008 | Clean and Hexagonal own adapter or use-case boundaries; DDD owns bounded context modeling. |
| MSG-003 | Event ownership | Events and Messaging | Evaluate whether responsibility for defining, publishing, and evolving an event is identifiable. | Make event ownership explicit enough to support reliable change and operations. | Applies when an event or message is produced for one or more consumers. | Producer code, ownership documentation, contract repository, change process, consumer references. | Treating repository location or namespace as ownership proof. | Missing informal ownership when documentation is absent but operational evidence exists elsewhere. | MSG-002, MSG-007 | Solution Architecture owns broad module ownership and repository organization. |
| MSG-004 | Event granularity | Events and Messaging | Evaluate whether event payloads and emission boundaries are neither too coarse nor too fine for their architectural responsibility. | Keep messages aligned to one meaningful fact or integration responsibility. | Applies when events are emitted or consumed as architectural communication units. | Payload schemas, producer emission points, consumer projections, handler behavior, tests. | Penalizing a coarse or fine message without evidence of architectural harm. | Missing hidden consumers affected by overbroad or fragmented payloads. | MSG-001, MSG-002, MSG-006 | Fowler DTO and DDD aggregate responsibilities are not re-evaluated here. |
| MSG-005 | Event immutability | Events and Messaging | Evaluate whether published events are treated as immutable records of what was communicated. | Protect event history and consumer reasoning from mutation after publication. | Applies when events are persisted, published, replayed, audited, or consumed asynchronously. | Event storage, message records, update paths, audit trails, replay logic, consumer assumptions. | Confusing schema evolution with mutation of an already published event. | Missing mutation through repair scripts, projection rebuilds, or operational tooling. | MSG-009, MSG-020 | Fowler persistence patterns own object/database mapping concerns. |
| MSG-006 | Event naming and meaning | Events and Messaging | Evaluate whether event names and descriptions communicate the fact or message meaning consistently with producer and consumer behavior. | Preserve shared interpretation of message meaning without relying on names alone. | Applies when event or message names are used to communicate architectural intent. | Names, payload fields, producer behavior, consumer behavior, tests, documentation. | Producing findings from naming preference alone. | Missing semantic drift because only producer-side evidence was inspected. | MSG-001, MSG-004 | DDD owns ubiquitous language consistency across the broader domain model. |
| MSG-007 | Event contract versioning | Events and Messaging | Evaluate whether message contracts have an explicit versioning approach when incompatible change is possible. | Make contract identity and coexistence of versions reviewable. | Applies when messages are consumed beyond the producer boundary or retained over time. | Version fields, schema registry or equivalent records, contract docs, producer and consumer compatibility tests. | Requiring version numbers when another explicit compatibility mechanism exists. | Missing implicit versioning hidden in endpoint, topic, or envelope conventions. | MSG-002, MSG-008, MSG-009 | Architecture Testing owns contract test mechanisms if testing is the primary concern. |
| MSG-008 | Event contract compatibility | Events and Messaging | Evaluate whether contract changes preserve older consumers and tolerate newer producers when required by the communication relationship. | Protect producer-consumer compatibility across independent deployment or release timing. | Applies when producers and consumers can change independently or retained messages may be consumed later. | Old and new schemas, consumer deserialization, compatibility tests, deployment records, change notes. | Treating every breaking change as invalid when all consumers are coordinated or retired. | Missing semantic breakage when field names and types remain unchanged. | MSG-007, MSG-009 | Clean boundary data and Fowler DTO concerns are not the primary condition. |
| MSG-009 | Schema evolution | Events and Messaging | Evaluate whether message schema evolution preserves field meaning, optionality, type expectations, and transformation paths. | Control structural and semantic evolution of message payloads. | Applies when messages have explicit or implicit schemas that evolve over time. | Schemas, serializers, payload definitions, migration logic, transformation code, compatibility documentation. | Requiring a particular schema tool. | Missing schema contracts embedded only in code or shared libraries. | MSG-007, MSG-008 | Fowler Data Transfer Object owns transfer-object pattern responsibility, not event schema evolution. |
| MSG-010 | Producer-persistence consistency | Events and Messaging | Evaluate whether state changes and event publication intent remain consistent under success, failure, and recovery paths. | Prevent persisted state without corresponding event intent, or event publication without the state it represents. | Applies when events communicate changes that depend on durable state. | Transaction boundaries, persistence code, publication code, failure handling, tests, operational recovery records. | Treating absence of Transactional Outbox as automatic failure. | Missing rare failure windows not represented in happy-path tests. | MSG-011, MSG-012, MSG-020 | Fowler Unit of Work owns changed-object transaction coordination itself. |
| MSG-011 | Transactional publication record | Events and Messaging | Evaluate whether a durable publication record or equivalent transactional capture exists when the architecture depends on recoverable publication after persistence. | Capture publication intent atomically with the relevant state change when needed. | Applies when reliable post-persistence publication is architecturally required. | Outbox-like records, change capture, transaction logs, dispatcher behavior, recovery tests, operational docs. | Requiring a named Transactional Outbox pattern universally. | Missing equivalent capture because it is implemented outside application code. | MSG-010, MSG-014, MSG-016 | Fowler and persistence catalogs own generic transaction and repository behavior. |
| MSG-012 | Message delivery semantics | Events and Messaging | Evaluate whether declared delivery semantics match real producer, transport, acknowledgement, retry, and consumer behavior. | Make loss, re-delivery, duplication, and effective processing assumptions explicit. | Applies when messages are sent, acknowledged, retried, consumed, or documented with delivery guarantees. | Producer send behavior, acknowledgement points, retry paths, consumer checkpoints, documentation, tests. | Accepting local exactly-once claims as end-to-end guarantees. | Missing re-delivery behavior caused by infrastructure defaults outside reviewed code. | MSG-013, MSG-014, MSG-016 | Architecture Testing owns verification mechanism quality, not delivery semantics itself. |
| MSG-013 | Consumer idempotency | Events and Messaging | Evaluate whether consumers can safely process repeated messages or repeated business effects when re-delivery or uncertain completion is possible. | Protect business effects from duplicate execution under retries and uncertain failures. | Applies when consumers perform state changes, external effects, or non-idempotent operations. | Handler logic, deduplication records, natural idempotent operations, transaction boundaries, external calls, tests. | Reducing idempotency to stored message IDs only. | Missing duplicate effects through downstream calls or partial transactions. | MSG-012, MSG-014, MSG-020 | SOLID does not own this even when local responsibility boundaries are evidence. |
| MSG-014 | Duplicate message handling | Events and Messaging | Evaluate whether duplicate messages are recognized, tolerated, or handled according to the architectural delivery model. | Control duplicate detection and duplicate outcome handling separately from consumer operation idempotency. | Applies when at-least-once delivery, retry, replay, multiple publishers, or uncertain acknowledgement can create duplicates. | Message identifiers, business keys, processing records, duplicate handling paths, tests, operational logs. | Treating idempotent effects as proof that duplicates are observed and handled. | Missing duplicates generated before the inspected consumer boundary. | MSG-012, MSG-013, MSG-020 | Fowler Identity Map and offline locks do not own message duplicate handling. |
| MSG-015 | Message ordering | Events and Messaging | Evaluate whether ordering assumptions are explicit and supported only where business or processing rules require ordering. | Prevent invalid conclusions from missing, excessive, or misunderstood ordering requirements. | Applies when consumers rely on message sequence or when concurrent processing can affect correctness. | Partition or key strategy, sequence fields, handler logic, concurrency settings, tests, documentation. | Requiring global order without evidence of need. | Missing ordering dependence hidden in stateful consumers or projections. | MSG-014, MSG-020 | Fowler Offline Lock rules own concurrent offline work, not message order. |
| MSG-016 | Retry strategy | Events and Messaging | Evaluate whether transient failures are retried with bounded, observable, and system-compatible behavior. | Keep retries from becoming silent loss, infinite repetition, duplicated effects, or retry storms. | Applies when producers, dispatchers, or consumers can fail transiently. | Retry policy, backoff behavior, limits, error classification, acknowledgement behavior, logs, metrics, tests. | Requiring specific retry values or a particular library. | Missing platform-level retry behavior outside reviewed application code. | MSG-012, MSG-013, MSG-017 | Dead-letter routing is separate from retry policy design. |
| MSG-017 | Dead-letter handling | Events and Messaging | Evaluate whether messages that cannot be processed through normal retry paths are routed or retained for meaningful operational resolution. | Provide a recoverable operational path for unprocessed messages. | Applies when message processing can permanently fail or exceed retry limits. | Dead-letter routing, retained payload and context, diagnostics, reprocessing paths, ownership docs, operational procedures. | Treating existence of a dead-letter queue as sufficient. | Missing dead-letter behavior configured outside reviewed code or docs. | MSG-016, MSG-018 | Solution Architecture owns broad operational ownership only when messaging is not the primary concern. |
| MSG-018 | Poison message handling | Events and Messaging | Evaluate whether non-processable messages are identified, isolated, diagnosed, and resolved without repeatedly harming normal flow. | Distinguish malformed or semantically invalid messages from ordinary transient failures. | Applies when consumers may encounter invalid payloads, unsupported versions, impossible state, or unrecoverable semantic errors. | Error classification, validation behavior, isolation paths, diagnostics, discard or repair decisions, reprocessing records. | Treating any failed message as a poison message. | Missing poison behavior because failures are hidden inside generic exception handling. | MSG-017, MSG-008, MSG-009 | Retry and dead-letter rules remain adjacent but independent. |
| MSG-019 | Correlation and traceability | Events and Messaging | Evaluate whether asynchronous flows preserve enough correlation, causation, and trace context to diagnose and reconstruct message-driven behavior. | Support end-to-end understanding of asynchronous message chains without becoming generic observability. | Applies when a business or operational flow spans multiple messages, producers, or consumers. | Correlation IDs, causation links, trace context, logs, metrics, message envelopes, audit records. | Treating generic logging as message traceability. | Missing trace breaks across async boundaries or produced messages. | MSG-012, MSG-016, MSG-020 | Architecture Testing and Solution Architecture do not own message-flow trace semantics. |
| MSG-020 | Replay safety | Events and Messaging | Evaluate whether replay or reprocessing can occur without unintended duplicated effects, incompatible interpretation, or invalid historical logic. | Make replay safe for projection rebuilds, operational recovery, and retained-message processing without assuming event sourcing. | Applies when messages may be replayed, reprocessed, retained, or used to rebuild derived state. | Replay tools, handlers, idempotency controls, version handling, external side-effect guards, projection logic, tests. | Assuming replay exists only in event-sourced systems. | Missing manual or operational reprocessing paths outside normal code flow. | MSG-005, MSG-013, MSG-014, MSG-015, MSG-019 | Event Sourcing-specific responsibilities are not introduced in this catalog. |

## 10. Coverage Matrix

| Coverage group | Responsible rules | Coverage rationale |
| --- | --- | --- |
| Event semantics | MSG-001, MSG-006 | Domain fact meaning and name-to-behavior consistency are separate. |
| Event boundaries | MSG-002, MSG-003 | Integration contract boundary and event ownership are independently reviewable. |
| Publishing consistency | MSG-010, MSG-011 | State/publication consistency and transactional capture are separate responsibilities. |
| Delivery | MSG-012 | Delivery semantics has its own rule to avoid absorbing idempotency. |
| Consumption | MSG-013, MSG-014, MSG-015 | Consumer-side effects, duplicates, and ordering are separate concerns. |
| Reliability | MSG-011, MSG-012, MSG-016 | Reliable publication, delivery assumptions, and retry policy cover different failure points. |
| Failure handling | MSG-016, MSG-017, MSG-018 | Retry, dead-letter, and poison handling produce independent conclusions. |
| Ordering | MSG-015 | Ordering is evaluated only when the architecture needs it. |
| Duplicate handling | MSG-013, MSG-014 | Idempotency and duplicate recognition/tolerance are distinct. |
| Contract evolution | MSG-007, MSG-008, MSG-009 | Versioning, compatibility, and schema evolution are separated. |
| Traceability | MSG-019 | Async flow correlation, causation, and trace context are centered in one rule. |
| Replay | MSG-020 | Replay safety is covered without requiring event sourcing. |
| Consistency | MSG-010, MSG-011 | Consistency between state and communication is handled without requiring strong consistency. |
| Coupling | MSG-002, MSG-008, MSG-012, MSG-019 | Boundary contracts, compatibility, delivery assumptions, and trace context reveal coupling risks. |
| Operational recovery | MSG-011, MSG-016, MSG-017, MSG-018, MSG-020 | Recoverable publication, retry, dead-letter, poison handling, and replay cover operational recovery. |

## 11. Overlap Prevention Matrix

| Rule pair | First responsibility | Second responsibility | Shared evidence | Independent conclusion | Duplication risk | Explicit boundary |
| --- | --- | --- | --- | --- | --- | --- |
| MSG-001 x MSG-002 | Domain-significant fact inside a domain context. | Stable communication contract across a boundary. | Event names, payloads, producer behavior. | A valid domain event may still be an unsafe integration contract, and a valid integration message need not be a domain event. | High if all events are treated as domain events. | Domain semantics and integration contracts are separate. |
| MSG-003 x MSG-007 | Ownership of definition, publication, and evolution responsibility. | Explicit versioning approach for contracts. | Contract docs, ownership docs, change records. | Ownership may be clear while versioning is weak, or versioning may exist without clear ownership. | Medium. | Ownership is accountability; versioning is contract identity over time. |
| MSG-010 x MSG-011 | Consistency between durable state and publication intent. | Durable transactional capture mechanism when needed. | Transactions, records, dispatchers, recovery tests. | Consistency can be satisfied by equivalent means; a publication record can exist but be insufficiently integrated. | High if Outbox is treated as the only answer. | Mechanism evidence supports but does not replace consistency evaluation. |
| MSG-012 x MSG-013 | Declared and actual delivery semantics. | Consumer safety under repeated processing or uncertain completion. | Acknowledgements, retries, handler behavior, checkpoints. | Delivery may be at-least-once while consumers are idempotent, or delivery claims may be unclear even with idempotent consumers. | High. | Delivery describes message arrival/processing assumptions; idempotency describes effect safety. |
| MSG-013 x MSG-014 | Repeated processing produces safe business effects. | Duplicate messages are recognized, tolerated, or routed. | Message IDs, business keys, processing records. | A naturally idempotent operation may not record duplicates; duplicate detection may exist but effects may still repeat. | High. | Effect safety and duplicate recognition are separate. |
| MSG-015 x MSG-020 | Ordering assumptions and support. | Safety of replay or reprocessing. | Sequence fields, replay tooling, projection handlers. | Correct order may still be unsafe for replay; replay may be safe without strict order when logic tolerates it. | Medium. | Ordering is sequence dependence; replay is repeated historical processing. |
| MSG-016 x MSG-017 | Bounded retry behavior for transient failures. | Operational routing or retention after normal processing cannot complete. | Error handling, retry limits, dead-letter records. | Retry can be well designed without dead-letter, and dead-letter can exist with bad retry behavior. | High. | Retry is repeated attempt policy; dead-letter is alternate resolution path. |
| MSG-017 x MSG-018 | Retention/routing for unprocessed messages. | Identification and isolation of non-processable messages. | Error classification, failed payloads, operational handling. | Dead-letter may catch failures without classifying poison messages; poison handling may occur before dead-letter. | High. | Dead-letter is destination or resolution path; poison handling is failure classification and containment. |
| MSG-007 x MSG-009 | Version identity and coexistence approach. | Structural and semantic schema evolution. | Schemas, serializers, compatibility docs. | A schema can evolve safely without explicit version field, or versions can exist while schema changes are unsafe. | Medium. | Versioning labels contract change; schema evolution governs payload shape and meaning. |
| MSG-009 x MSG-008 | Field-level and semantic schema change control. | Consumer and producer compatibility across change timing. | Old/new schemas, consumers, transformations. | Compatible consumers may tolerate schema changes, and schema changes may be technically valid but semantically incompatible. | High. | Schema evolution is change mechanics; compatibility is relationship outcome. |
| MSG-019 x MSG-012 | Correlation, causation, and trace context across async flow. | Delivery, acknowledgement, loss, and re-delivery assumptions. | Envelopes, logs, acknowledgements, traces. | Traceability can be strong while delivery semantics are unclear, and delivery can be known while tracing is weak. | Medium. | Trace context explains observability of flow; delivery explains messaging behavior. |
| MSG-019 x MSG-020 | Reconstruction of async flow. | Safe replay or reprocessing of messages. | Trace IDs, causation links, replay records. | A flow may be traceable but unsafe to replay; replay may be safe without complete diagnostic trace. | Medium. | Traceability is diagnostic continuity; replay safety is controlled repeated processing. |
| MSG-010 x MSG-012 | State/publication consistency. | Delivery assumptions after the message enters the messaging flow. | Producer code, transactions, acknowledgements. | A producer can persist publication intent correctly while later delivery semantics remain at-least-once or unclear. | Medium. | Producer consistency ends at publication intent and handoff; delivery semantics covers transport/consumer behavior. |
| MSG-002 x MSG-008 | Boundary contract independence from internal model. | Compatibility of contract changes for consumers. | Schemas, mappings, consumers, deployments. | A contract can be well separated but changed incompatibly, or compatible but still leak internal structures. | Medium. | Boundary quality and evolution compatibility are independent. |
| MSG-004 x MSG-006 | Message size and emission responsibility. | Name and meaning alignment. | Payload fields, names, consumers. | A well named event may be too broad or too fragmented; a granular event may be ambiguously named. | Low. | Granularity is responsibility size; naming is semantic clarity. |

## 12. Known Risks

False-positive risks:

- treating message names as proof of event semantics;
- treating a queue, topic, broker, or handler as proof of architectural quality;
- treating the absence of messaging as a failure when synchronous communication is legitimate;
- requiring Transactional Outbox when an equivalent consistency mechanism exists;
- requiring global ordering without evidence of a business ordering need;
- treating a local delivery guarantee as an end-to-end guarantee;
- treating dead-letter existence as operational recovery;
- requiring a specific schema or retry technology.

False-negative risks:

- hidden consumers or producers outside the reviewed scope;
- platform-level retries, acknowledgements, or dead-letter behavior not visible in code;
- external side effects repeated by consumers after partial failure;
- implicit contracts embedded in shared libraries;
- outdated documentation masking changed message behavior;
- manual replay or repair processes absent from code;
- semantic contract breaks that do not change field names or types;
- happy-path tests that never exercise duplicate, failure, or replay behavior.

## 13. Future Extensions

Future modules may create individual rule documents for the entries in this catalog using the official 20-field structure from `SPECIFICATION.md`.

Potential future extensions must not be added silently as extra rules in this catalog. They should first be checked for atomicity, taxonomy ownership, overlap with existing entries, evidence availability, outcome completeness, and cross-catalog boundary safety.

Potential future topics that require separate evaluation before inclusion include:

- command message semantics;
- event sourcing-specific invariants;
- saga or process manager coordination;
- projection freshness;
- subscription lifecycle;
- consumer scaling boundaries;
- message retention policy.

These topics are intentionally not included in this catalog because the current 20 entries cover the requested core responsibilities without expanding into separate pattern catalogs or technology-specific concerns.

## 14. Change Notes

Initial catalog created for Module 48.

Only `skill/rules/EVENTS_CATALOG.md` is created by this module.

No individual Rule document is created by this catalog.

No review, stabilization, knowledge, example, evaluation, scoring, template, code, existing catalog, existing rule, or existing repository documentation file is changed by this module.
