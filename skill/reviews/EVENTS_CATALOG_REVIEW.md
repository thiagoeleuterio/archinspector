# Events & Messaging Catalog Review

## 1. Review Scope

This review audits `skill/rules/EVENTS_CATALOG.md` and the twenty Events and Messaging Rules implemented in `skill/rules/events/`, from `MSG-001` through `MSG-020`.

The review covers catalog identity, catalog structure, rule inventory, catalog-to-rule alignment, specification compliance, rule model compliance, taxonomy compliance, Gold Standard consistency, rule-by-rule architectural accuracy, coverage, overlap, gaps, applicability, evidence, outcomes, confidence, severity, common finding shapes, remediation guidance, false-positive risk, false-negative risk, internal messaging boundaries, cross-catalog boundaries, related rules, references, change notes, and readiness for catalog stabilization.

This review does not modify `skill/rules/EVENTS_CATALOG.md`, does not modify any `MSG-*` Rule, does not modify any existing review or stabilization, does not create a stabilization, does not create a Rule, does not create knowledge, examples, evaluation assets, scoring, templates, code, or commits.

Created file: `skill/reviews/EVENTS_CATALOG_REVIEW.md`.

## 2. Sources Reviewed

- `README.md`
- `.archinspector/AI_CONTEXT.md`
- `.archinspector/ARCHITECTURE.md`
- `.archinspector/DECISIONS.md`
- `skill/instructions.md`
- `skill/rules/RULE_MODEL.md`
- `skill/rules/SPECIFICATION.md`
- `skill/rules/TAXONOMY.md`
- `skill/rules/EVENTS_CATALOG.md`
- `skill/rules/events/MSG-001.md`
- `skill/rules/events/MSG-002.md`
- `skill/rules/events/MSG-003.md`
- `skill/rules/events/MSG-004.md`
- `skill/rules/events/MSG-005.md`
- `skill/rules/events/MSG-006.md`
- `skill/rules/events/MSG-007.md`
- `skill/rules/events/MSG-008.md`
- `skill/rules/events/MSG-009.md`
- `skill/rules/events/MSG-010.md`
- `skill/rules/events/MSG-011.md`
- `skill/rules/events/MSG-012.md`
- `skill/rules/events/MSG-013.md`
- `skill/rules/events/MSG-014.md`
- `skill/rules/events/MSG-015.md`
- `skill/rules/events/MSG-016.md`
- `skill/rules/events/MSG-017.md`
- `skill/rules/events/MSG-018.md`
- `skill/rules/events/MSG-019.md`
- `skill/rules/events/MSG-020.md`
- `skill/reviews/MSG-001_REVIEW.md`
- `skill/reviews/MSG-001_STABILIZATION.md`
- `skill/reviews/LAYER_CATALOG_REVIEW.md`
- `skill/reviews/LAYER_CATALOG_STABILIZATION.md`
- `skill/reviews/FOWLER_CATALOG_REVIEW.md`
- `skill/reviews/FOWLER_CATALOG_STABILIZATION.md`
- `skill/reviews/DDD_CATALOG_REVIEW.md`
- `skill/reviews/CLEAN_CATALOG_REVIEW.md`
- `skill/reviews/HEX_CATALOG_REVIEW.md`
- representative Gold Standard review material for DDD and Clean Architecture.

No external web source was inspected. External reference quality was evaluated from recognized bibliographic identity and relevance stated in the Rules, not from live URLs.

## 3. Review Method

The review used the requested source order: `SPECIFICATION.md`, `RULE_MODEL.md`, `TAXONOMY.md`, `EVENTS_CATALOG.md`, stabilized `MSG-001`, `MSG-001_REVIEW.md`, `MSG-001_STABILIZATION.md`, stabilized cross-catalog boundary patterns, and recognized architecture references.

Structural validation checked file existence, ID sequence, title match, category, status, official heading count, official heading order, required fields, optional fields, all five outcomes, severity guidance, confidence guidance, dependencies, references, and change notes.

Semantic validation compared every Rule directly against its catalog row, neighboring Rules, internal Events and Messaging boundaries, false-positive risks, false-negative risks, and cross-catalog responsibilities. No Rule was approved merely because it resembled the Gold Standard visually.

Allowed finding classifications were restricted to the requested list. Allowed severities were `Critical`, `High`, `Medium`, `Low`, and `Informational`. Allowed confidence values were `Confirmed`, `Likely`, `Possible`, and `Not Enough Evidence`.

Primary overlap pairs reviewed included all requested pairs from `MSG-001 x MSG-002` through `MSG-019 x MSG-020`. Cross-catalog boundaries reviewed included DDD, Fowler, Hexagonal Architecture, Clean Architecture, Layered Architecture, SOLID, Architecture Testing, and Solution Architecture.

## 4. Catalog Identity

Catalog identity is valid.

| Attribute | Expected | Observed | Status |
| --- | --- | --- | --- |
| Catalog file | `skill/rules/EVENTS_CATALOG.md` | Present | Compliant |
| Category | `Events and Messaging` | `Events and Messaging` | Compliant |
| Prefix | `MSG` | `MSG` | Compliant |
| ID sequence | `MSG-001` through `MSG-020` | `MSG-001` through `MSG-020` | Compliant |
| Rule directory | `skill/rules/events/` | `skill/rules/events/` | Compliant |
| Technology neutrality | No required broker, queue, topic, outbox, event sourcing, microservices, or product | Preserved | Compliant |

The catalog states that it does not make event-driven architecture, messaging, asynchronous communication, broker usage, Transactional Outbox, event sourcing, microservices, architecture tests, or product-specific messaging technology universally required.

No corrective finding identified.

## 5. Catalog Structure Validation

`EVENTS_CATALOG.md` contains purpose, scope, architectural principles, catalog conventions, evidence principles, outcome principles, internal boundaries, cross-catalog boundaries, a 20-entry rule catalog, coverage matrix, overlap prevention matrix, known risks, future extensions, and change notes.

| Validation item | Result | Evidence |
| --- | --- | --- |
| Prefix `MSG` | Compliant | Catalog conventions define `MSG` for Events and Messaging. |
| Sequence `MSG-001` to `MSG-020` | Compliant | Rule catalog table lists all 20 IDs in order. |
| Unique IDs | Compliant | No duplicate `MSG-*` catalog row was found. |
| Unique titles | Compliant | Each title is distinct. |
| Unique responsibilities | Compliant | Objectives and architectural responsibilities are distinct. |
| Coverage thematic completeness | Compliant | Semantics, boundary, ownership, granularity, immutability, naming, evolution, consistency, delivery, consumption, failure handling, traceability, and replay are covered. |
| Absence of technology-specific mandate | Compliant | Catalog explicitly rejects universal broker, outbox, event sourcing, schema registry, and product requirements. |
| Absence of generic Rule | Compliant | Each row has a specific messaging concern. |
| Explicit duplication | Compliant | No duplicate catalog objective was found. |
| Critical gap | Compliant | No critical gap inside the requested core scope was identified. |
| Internal boundaries | Compliant | Catalog separates Domain Event, Integration Event, publication consistency, delivery, idempotency, duplicate handling, ordering, retries, dead-letter, poison, traceability, and replay. |
| Cross-catalog boundaries | Compliant | Catalog preserves boundaries with DDD, Fowler, Hexagonal, Clean, Layered, SOLID, and Architecture Testing. |
| Overlap matrix | Partially Compliant | Matrix is useful but not exhaustive for all mandatory review pairs. The review supplies the full required overlap matrix below. No catalog correction is required solely for non-exhaustiveness. |
| False-positive risks | Compliant | Known risks section identifies naming, broker, absence of messaging, outbox, ordering, exactly-once, dead-letter, and schema technology risks. |
| False-negative risks | Compliant | Known risks section identifies hidden consumers, platform behavior, external effects, shared libraries, stale docs, manual replay, semantic breaks, and happy-path-only tests. |
| Taxonomy alignment | Compliant | Category and prefix match `TAXONOMY.md`. |

No corrective finding identified for the catalog structure.

## 6. Rule Inventory

| ID | Title | File Exists | Catalog Match | 20 Fields | Correct Order | Five Outcomes | Confidence | Severity | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| MSG-001 | Domain event semantics | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-002 | Integration event boundary | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-003 | Event ownership | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-004 | Event granularity | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-005 | Event immutability | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-006 | Event naming and meaning | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-007 | Event contract versioning | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-008 | Event contract compatibility | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-009 | Schema evolution | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-010 | Producer-persistence consistency | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-011 | Transactional publication record | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Partially Compliant |
| MSG-012 | Message delivery semantics | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-013 | Consumer idempotency | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-014 | Duplicate message handling | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-015 | Message ordering | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-016 | Retry strategy | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Partially Compliant |
| MSG-017 | Dead-letter handling | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-018 | Poison message handling | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Partially Compliant |
| MSG-019 | Correlation and traceability | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-020 | Replay safety | Yes | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |

The `Partially Compliant` statuses are limited to related-rule alignment findings in the `Dependencies` field. They do not indicate structural failure, category mismatch, title mismatch, or central responsibility drift.

## 7. Specification Compliance

All twenty Rules contain exactly the official 20 top-level headings in the required order:

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

Mandatory fields are populated with rule-specific content. Optional fields are present in the official order. No Rule adds unofficial top-level fields before, between, or after the official fields. All Rules define `Pass`, `Fail`, `Warning`, `Not Applicable`, and `Not Enough Evidence`.

`SPECIFICATION.md` does not define separate top-level fields named `Common Findings`, `Remediation Guidance`, or `Related Rules`. The Rules correctly represent common finding shapes and remediation guidance inside `Evaluation Guidance`, and represent related rules through `Dependencies`.

No corrective finding identified.

## 8. Rule Model Compliance

The catalog is broadly compliant with `RULE_MODEL.md`.

Each Rule is atomic around one Events and Messaging concern, reusable across reviewed systems, evidence-driven, context-aware, independently evaluable, uniquely identifiable, stable, and outcome-complete.

No Rule is written as a project-specific finding, checklist, recommendation, knowledge article, example, report template, evaluation scenario, scoring formula, or implementation artifact.

The only model-adjacent issue is not a failure of independence: three Rules omit direct catalog-listed related entries from `Dependencies`, which weakens boundary navigation but does not make the Rules non-evaluable. These are recorded as `Related Rules` findings.

## 9. Taxonomy Compliance

Taxonomy compliance is confirmed.

| Rule range | Prefix | Category | Directory | Sequence | Status |
| --- | --- | --- | --- | --- | --- |
| `MSG-001` through `MSG-020` | `MSG` | `Events and Messaging` | `skill/rules/events/` | Continuous | Compliant |

No invented IDs, alternate prefixes, category collisions, or implicit taxonomy changes were identified. The older `EVENT-001.md` mentioned by the catalog is outside this `MSG-*` sequence and is not treated as part of the Events and Messaging catalog under review.

No corrective finding identified.

## 10. Catalog Alignment

All Rule IDs, filenames, titles, category values, and core intents align with `EVENTS_CATALOG.md`.

| ID | Catalog Title | Rule Title | Responsibility Alignment | Related Entry Alignment |
| --- | --- | --- | --- | --- |
| MSG-001 | Domain event semantics | Domain event semantics | Aligned | Expanded but review-stabilized |
| MSG-002 | Integration event boundary | Integration event boundary | Aligned | Expanded, acceptable |
| MSG-003 | Event ownership | Event ownership | Aligned | Aligned |
| MSG-004 | Event granularity | Event granularity | Aligned | Aligned |
| MSG-005 | Event immutability | Event immutability | Aligned | Expanded, acceptable |
| MSG-006 | Event naming and meaning | Event naming and meaning | Aligned | Aligned |
| MSG-007 | Event contract versioning | Event contract versioning | Aligned | Expanded, acceptable |
| MSG-008 | Event contract compatibility | Event contract compatibility | Aligned | Expanded, acceptable |
| MSG-009 | Schema evolution | Schema evolution | Aligned | Aligned |
| MSG-010 | Producer-persistence consistency | Producer-persistence consistency | Aligned | Aligned |
| MSG-011 | Transactional publication record | Transactional publication record | Aligned | Missing `MSG-014` |
| MSG-012 | Message delivery semantics | Message delivery semantics | Aligned | Expanded, acceptable |
| MSG-013 | Consumer idempotency | Consumer idempotency | Aligned | Aligned |
| MSG-014 | Duplicate message handling | Duplicate message handling | Aligned | Expanded, acceptable |
| MSG-015 | Message ordering | Message ordering | Aligned | Aligned |
| MSG-016 | Retry strategy | Retry strategy | Aligned | Missing `MSG-013`; expanded with `MSG-011` and `MSG-018` |
| MSG-017 | Dead-letter handling | Dead-letter handling | Aligned | Aligned |
| MSG-018 | Poison message handling | Poison message handling | Aligned | Missing `MSG-008` and `MSG-009` |
| MSG-019 | Correlation and traceability | Correlation and traceability | Aligned | Aligned |
| MSG-020 | Replay safety | Replay safety | Aligned | Aligned |

Corrective findings are limited to missing direct related-rule references in `MSG-011`, `MSG-016`, and `MSG-018`.

## 11. Gold Standard Consistency

`MSG-001` remains consistent with `MSG-001_REVIEW.md` and `MSG-001_STABILIZATION.md`.

It preserves the Gold Standard properties for structure, precision, applicability, evidence hierarchy, all five outcomes, confidence, severity, false-positive control, false-negative control, internal boundaries, cross-catalog boundaries, references, and change notes.

No regression or new inconsistency was identified in `MSG-001`. The review does not reopen stabilized findings because no new contrary evidence was found.

No corrective finding identified.

## 12. Rule-by-Rule Review

### MSG-001 -- Domain event semantics

`MSG-001` evaluates exclusively whether a claimed or used Domain Event represents a completed, stable, domain-significant fact. It preserves the boundary with integration contracts, ownership, granularity, immutability, naming, publication consistency, delivery, idempotency, traceability, and replay.

Structure: compliant. Catalog alignment: compliant. Applicability, evidence, outcomes, confidence, severity, false-positive controls, false-negative controls, remediation guidance, dependencies, references, and change notes are compliant.

No corrective finding identified.

### MSG-002 -- Integration event boundary

`MSG-002` evaluates boundary-crossing messages as stable integration contracts and avoids absorbing Domain Event semantics, ownership, versioning, compatibility, schema evolution, delivery, or DDD bounded context quality.

Structure: compliant. Catalog alignment: compliant. The expanded `Dependencies` list is direct and boundary-helpful because ownership and schema evolution can affect contract exposure without becoming the conclusion.

No corrective finding identified.

### MSG-003 -- Event ownership

`MSG-003` evaluates definition ownership, publication responsibility, change authority, governance, and operational accountability. It avoids absorbing versioning, compatibility, retry, dead-letter handling, and schema evolution.

Structure: compliant. Catalog alignment: compliant. Applicability supports formal and informal ownership evidence without prescribing team structure or tooling.

No corrective finding identified.

### MSG-004 -- Event granularity

`MSG-004` evaluates coherent message granularity, mixed facts, overbroad events, event-per-trivial-change noise, fragmentation, and payload excess when tied to granularity. It avoids becoming a generic naming, schema, or payload rule.

Structure: compliant. Catalog alignment: compliant. Evidence and severity avoid field-count or payload-size thresholds.

No corrective finding identified.

### MSG-005 -- Event immutability

`MSG-005` evaluates mutation after publication or retention, mutable references, reused instances, delayed enrichment, stored-record overwrite, and stable communicated fact preservation. It preserves the boundary with `MSG-001` by focusing on technical and contractual preservation after availability.

Structure: compliant. Catalog alignment: compliant. It does not require language-specific immutable types.

No corrective finding identified.

### MSG-006 -- Event naming and meaning

`MSG-006` evaluates alignment between event/message names and behavior, payload, consumers, and documentation. It controls ambiguous names, generic names, technical names, command-like names, reused names, and attempt/success mismatch.

Structure: compliant. Catalog alignment: compliant. It does not repeat `MSG-001` because it centers name-to-meaning consistency rather than full Domain Event semantics.

No corrective finding identified.

### MSG-007 -- Event contract versioning

`MSG-007` evaluates identifiable and managed contract versions when incompatible change, retained messages, or independent consumer timelines require distinguishable forms. It does not require universal version fields or a specific versioning strategy.

Structure: compliant. Catalog alignment: compliant. Boundaries with `MSG-008` and `MSG-009` are clear: version identity is separate from compatibility behavior and schema evolution mechanics.

No corrective finding identified.

### MSG-008 -- Event contract compatibility

`MSG-008` evaluates producer-consumer compatibility across actual coexistence windows, including old consumers with new producers and new consumers with old or retained messages when those combinations can occur.

Structure: compliant. Catalog alignment: compliant. It does not replace versioning or schema evolution and does not require backward compatibility forever.

No corrective finding identified.

### MSG-009 -- Schema evolution

`MSG-009` evaluates structural and semantic schema changes, including fields, types, requiredness, cardinality, enums, units, transformations, documentation drift, and historical interpretation.

Structure: compliant. Catalog alignment: compliant. It does not require a schema registry, broker-specific format, or schema language.

No corrective finding identified.

### MSG-010 -- Producer-persistence consistency

`MSG-010` evaluates durable state versus publication intent under success, failure, rollback, and recovery. It identifies dual-write windows, lost publication intent, false publication, and recoverability without mandating Outbox.

Structure: compliant. Catalog alignment: compliant. Boundary with `MSG-011` is preserved: this Rule evaluates the consistency problem, while `MSG-011` evaluates the adopted durable record solution.

No corrective finding identified.

### MSG-011 -- Transactional publication record

`MSG-011` evaluates durable or equivalent transactional publication capture when adopted or required. It covers durability, transaction relationship, status, recovery, dispatcher behavior, concurrency, retention, stuck records, and controlled resend.

Structure: compliant. Catalog alignment: partially compliant. The central responsibility is correct and it does not condemn absence when another strategy satisfies `MSG-010`. However, the Rule omits `MSG-014` from `Dependencies` even though the catalog lists it as related and the Rule's own responsibility includes controlled resend and duplicate exposure.

Corrective finding: `EVENTS-CAT-REV-001`.

### MSG-012 -- Message delivery semantics

`MSG-012` evaluates declared and effective delivery semantics, including loss, redelivery, acknowledgement timing, timeout, visibility, offset commit, and uncertain failure. It avoids absorbing idempotency.

Structure: compliant. Catalog alignment: compliant. Boundaries with `MSG-013`, `MSG-014`, and `MSG-016` are explicit.

No corrective finding identified.

### MSG-013 -- Consumer idempotency

`MSG-013` evaluates repeated processing at the level of message or business intent, including duplicated state changes, external effects, atomicity between effect and marker, natural idempotency, and explicit idempotency mechanisms.

Structure: compliant. Catalog alignment: compliant. It does not reduce idempotency to message ID presence and preserves boundaries with `MSG-014` and `MSG-020`.

No corrective finding identified.

### MSG-014 -- Duplicate message handling

`MSG-014` evaluates duplicate existence, recognition, tolerance, discard, merge, diagnostics, and the distinction between harmful duplicates and legitimate repeated business facts.

Structure: compliant. Catalog alignment: compliant. It does not duplicate idempotency because it centers duplicate recognition and handling rather than repeated effect safety.

No corrective finding identified.

### MSG-015 -- Message ordering

`MSG-015` evaluates whether ordering needs are identified and supported at the correct scope, such as entity, aggregate, business key, partition, stream, or workflow. It rejects unnecessary global order.

Structure: compliant. Catalog alignment: compliant. It covers delayed, out-of-order, concurrent, stale, and over-serialized processing without requiring a specific broker.

No corrective finding identified.

### MSG-016 -- Retry strategy

`MSG-016` evaluates bounded, observable, failure-type-aware retry behavior for production, dispatch, consumption, acknowledgement, and side-effect interaction. It avoids absorbing dead-letter or poison handling.

Structure: compliant. Catalog alignment: partially compliant. The central responsibility is correct, but the Rule omits `MSG-013` from `Dependencies` even though the catalog lists it as related and retry strategy directly affects duplicated consumer effects.

Corrective finding: `EVENTS-CAT-REV-002`.

### MSG-017 -- Dead-letter handling

`MSG-017` evaluates whether messages that cannot complete normal processing are routed or retained with enough payload, context, error information, ownership, monitoring, retention, and recovery or resolution path.

Structure: compliant. Catalog alignment: compliant. Boundary with `MSG-018` is preserved: dead-letter is the operational destination or resolution path, poison handling is classification and isolation of permanently non-processable messages.

No corrective finding identified.

### MSG-018 -- Poison message handling

`MSG-018` evaluates deterministic or permanent failure classification, isolation, quarantine, diagnostics, retry avoidance, discard or repair decisions, and prevention of blocking or repeated degradation.

Structure: compliant. Catalog alignment: partially compliant. The central responsibility is correct and does not duplicate dead-letter handling, but the Rule omits `MSG-008` and `MSG-009` from `Dependencies` even though unsupported versions and invalid payload/schema forms are explicit poison-message evidence and catalog-listed related entries.

Corrective finding: `EVENTS-CAT-REV-003`.

### MSG-019 -- Correlation and traceability

`MSG-019` evaluates correlation, causation, message identity, business context, trace context, flow reconstruction, and async diagnostics. It does not become a generic observability Rule.

Structure: compliant. Catalog alignment: compliant. It treats logging and tracing as evidence only when they support message-flow traceability.

No corrective finding identified.

### MSG-020 -- Replay safety

`MSG-020` evaluates replay and reprocessing safety for state, external effects, historical facts, schemas, ordering, checkpoints, replay modes, retained messages, and changed business rules. It does not presume Event Sourcing.

Structure: compliant. Catalog alignment: compliant. It does not duplicate idempotency, duplicate handling, ordering, schema evolution, or traceability because it centers deliberate or operational historical reprocessing.

No corrective finding identified.

## 13. Coverage Matrix

| Capability | Primary Rule | Supporting Rules | Coverage Status | Gap | Overlap Risk |
| --- | --- | --- | --- | --- | --- |
| Domain event semantics | MSG-001 | MSG-006 | Covered | None | Low |
| Integration boundary | MSG-002 | MSG-007, MSG-008, MSG-009 | Covered | None | Low |
| Ownership | MSG-003 | MSG-002, MSG-007 | Covered | None | Low |
| Granularity | MSG-004 | MSG-001, MSG-006 | Covered | None | Low |
| Immutability | MSG-005 | MSG-001, MSG-020 | Covered | None | Low |
| Naming | MSG-006 | MSG-001, MSG-004 | Covered | None | Low |
| Versioning | MSG-007 | MSG-008, MSG-009 | Covered | None | Low |
| Compatibility | MSG-008 | MSG-007, MSG-009 | Covered | None | Low |
| Schema evolution | MSG-009 | MSG-007, MSG-008 | Covered | None | Low |
| Producer-persistence consistency | MSG-010 | MSG-011, MSG-012 | Covered | None | Low |
| Transactional publication record | MSG-011 | MSG-010, MSG-016 | Covered | None | Low |
| Delivery semantics | MSG-012 | MSG-013, MSG-014, MSG-016 | Covered | None | Low |
| Consumer idempotency | MSG-013 | MSG-012, MSG-014, MSG-020 | Covered | None | Low |
| Duplicate handling | MSG-014 | MSG-012, MSG-013, MSG-020 | Covered | None | Low |
| Ordering | MSG-015 | MSG-014, MSG-020 | Covered | None | Low |
| Retry | MSG-016 | MSG-012, MSG-017, MSG-018 | Covered | None | Low |
| Dead-letter | MSG-017 | MSG-016, MSG-018 | Covered | None | Low |
| Poison message | MSG-018 | MSG-016, MSG-017, MSG-008, MSG-009 | Covered | None | Low |
| Correlation | MSG-019 | MSG-012, MSG-016, MSG-020 | Covered | None | Low |
| Traceability | MSG-019 | MSG-012, MSG-016, MSG-020 | Covered | None | Low |
| Replay | MSG-020 | MSG-005, MSG-013, MSG-014, MSG-015, MSG-019 | Covered | None | Medium |
| Eventual consistency | MSG-010 | MSG-011, MSG-012, MSG-013, MSG-020 | Partially Covered | No standalone eventual consistency strategy Rule; current coverage is sufficient for messaging consistency concerns. | Medium |
| Temporal coupling | MSG-008 | MSG-007, MSG-012, MSG-015, MSG-020 | Partially Covered | No standalone temporal coupling Rule; current coverage handles contract coexistence and ordering/replay timing. | Medium |
| Failure recovery | MSG-010 | MSG-011, MSG-016, MSG-017, MSG-018, MSG-020 | Covered | None | Medium |
| Operational diagnosis | MSG-017 | MSG-019, MSG-016, MSG-012 | Covered | None | Low |
| Consumer autonomy | MSG-002 | MSG-003, MSG-007, MSG-008, MSG-009 | Covered | None | Low |
| Contract governance | MSG-003 | MSG-007, MSG-008, MSG-009 | Covered | None | Low |

The partial coverage entries are not stabilization blockers because the catalog intentionally avoids expanding into broad solution-architecture strategy. They should not cause new Rules in this stage.

## 14. Overlap Matrix

| Rule A | Rule B | Shared Evidence | Rule A Conclusion | Rule B Conclusion | Overlap Status | Finding |
| --- | --- | --- | --- | --- | --- | --- |
| MSG-001 | MSG-002 | Names, payload, producer behavior | Domain fact semantics | Boundary contract stability | Clear Boundary | None |
| MSG-001 | MSG-004 | Fact, payload, emission point | Completed domain fact | Granularity of communication responsibility | Clear Boundary | None |
| MSG-001 | MSG-005 | Event lifecycle and fact stability | Semantic completion | Post-publication immutability | Clear Boundary | None |
| MSG-001 | MSG-006 | Name, meaning, behavior | Domain Event semantics | Name-to-meaning alignment | Clear Boundary | None |
| MSG-002 | MSG-003 | Contract, producer, consumer | Boundary contract | Ownership/accountability | Clear Boundary | None |
| MSG-002 | MSG-007 | Contract, boundary, change records | Boundary separation | Version identity | Clear Boundary | None |
| MSG-002 | MSG-008 | Contract, consumers, rollout | Internal-model leakage | Compatibility across coexistence | Clear Boundary | None |
| MSG-003 | MSG-007 | Contract docs, change records | Change authority | Versioning approach | Clear Boundary | None |
| MSG-004 | MSG-006 | Payload and names | Granularity | Naming alignment | Clear Boundary | None |
| MSG-005 | MSG-020 | Stored messages, replay | Mutation of communicated fact | Replay/reprocessing safety | Clear Boundary | None |
| MSG-007 | MSG-008 | Old/new contracts | Version identification | Compatibility result | Clear Boundary | None |
| MSG-007 | MSG-009 | Schemas and history | Version identity | Schema change mechanics | Clear Boundary | None |
| MSG-008 | MSG-009 | Schemas, consumers, transformations | Compatibility relationship | Structural/semantic evolution | Clear Boundary | None |
| MSG-010 | MSG-011 | Transactions, capture, dispatch | Consistency problem | Durable capture solution | Clear Boundary | None |
| MSG-010 | MSG-012 | Producer send and ack behavior | State/publication consistency | Effective delivery behavior | Clear Boundary | None |
| MSG-011 | MSG-016 | Dispatch retry, records | Publication record recoverability | Retry strategy | Clear Boundary | None |
| MSG-012 | MSG-013 | Redelivery, ack, side effects | Delivery semantics | Repeated effect safety | Clear Boundary | None |
| MSG-012 | MSG-014 | Redelivery and duplicates | Delivery behavior | Duplicate recognition/handling | Clear Boundary | None |
| MSG-013 | MSG-014 | Message IDs, business keys | Idempotent effects | Duplicate classification/handling | Clear Boundary | None |
| MSG-013 | MSG-020 | Reprocessing and side effects | Ordinary repeated processing safety | Replay safety | Clear Boundary | None |
| MSG-014 | MSG-015 | Duplicate and sequence evidence | Duplicate handling | Ordering requirement | Clear Boundary | None |
| MSG-015 | MSG-020 | Sequence, checkpoints, replay | Ordering scope | Historical reprocessing safety | Clear Boundary | None |
| MSG-016 | MSG-017 | Exhausted retry, failed messages | Retry bounds/escalation | Dead-letter resolution path | Clear Boundary | None |
| MSG-016 | MSG-018 | Failure classification | Retry policy | Poison isolation | Clear Boundary | None |
| MSG-017 | MSG-018 | Failed payloads and routing | Dead-letter destination/usefulness | Permanent failure classification/isolation | Clear Boundary | None |
| MSG-019 | MSG-020 | Trace, causation, replay records | Diagnostic reconstruction | Replay safety | Clear Boundary | None |

No problematic overlap was identified.

## 15. Gap Analysis

No critical catalog gap was identified.

Observed partial coverage:

| Area | Current coverage | Gap assessment | Finding |
| --- | --- | --- | --- |
| Eventual consistency | `MSG-010`, `MSG-011`, `MSG-012`, `MSG-013`, `MSG-020` | Partially covered as messaging consistency and recovery, not broad consistency strategy. No new Rule required. | None |
| Temporal coupling | `MSG-007`, `MSG-008`, `MSG-012`, `MSG-015`, `MSG-020` | Partially covered through coexistence, retained messages, order, and replay. No standalone Rule required in this catalog. | None |
| Command message semantics | Not included | Catalog future extension intentionally excludes it pending separate evaluation. | None |
| Saga/process manager coordination | Not included | Correctly left out as future extension; current catalog reviews core messaging concerns. | None |
| Event sourcing-specific invariants | Not included | Correctly excluded; `MSG-020` does not presume Event Sourcing. | None |

No gap requires correction before stabilization.

## 16. Applicability Analysis

| ID | Applicability Clear | Legitimate Absence Covered | N/A Clear | NEE Clear | Universal Prescription Risk | Status |
| --- | --- | --- | --- | --- | --- | --- |
| MSG-001 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-002 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-003 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-004 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-005 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-006 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-007 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-008 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-009 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-010 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-011 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-012 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-013 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-014 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-015 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-016 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-017 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-018 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-019 | Yes | Yes | Yes | Yes | Controlled | Compliant |
| MSG-020 | Yes | Yes | Yes | Yes | Controlled | Compliant |

No Rule requires universal broker adoption, universal outbox, universal idempotency, universal ordering, universal retry, universal dead-letter, universal replay, universal version field, universal schema registry, DDD formal adoption, or a technology-specific mechanism.

## 17. Evidence Analysis

| ID | Primary Evidence | Weak Evidence Controlled | Direct Evidence for Fail | External Evidence Considered | Status |
| --- | --- | --- | --- | --- | --- |
| MSG-001 | Creation flow, state transition, tests, consumers | Yes | Yes | Docs and recognized Domain Event references | Compliant |
| MSG-002 | Contracts, mappings, consumers, schemas | Yes | Yes | Architecture decisions | Compliant |
| MSG-003 | Producers, ownership docs, contract repos, operations | Yes | Yes | CODEOWNERS/runbooks when available | Compliant |
| MSG-004 | Payload, emission points, consumers, projections | Yes | Yes | ADRs/docs | Compliant |
| MSG-005 | Lifecycle, storage, mutation paths, replay | Yes | Yes | Repair procedures | Compliant |
| MSG-006 | Name, behavior, payload, consumers, docs | Yes | Yes | Domain docs | Compliant |
| MSG-007 | Version identity, retained messages, migrations | Yes | Yes | Contract lifecycle docs | Compliant |
| MSG-008 | Old/new contracts, deserialization, rollout | Yes | Yes | Deployment records | Compliant |
| MSG-009 | Schema definitions, serializers, history | Yes | Yes | Migration docs | Compliant |
| MSG-010 | Persistence flow, publish decision, failure paths | Yes | Yes | Operational recovery records | Compliant |
| MSG-011 | Publication records, transactions, dispatcher | Yes | Yes | Operational procedures | Compliant |
| MSG-012 | Send, ack, retries, checkpoints, consumers | Yes | Yes | Broker config when available | Compliant |
| MSG-013 | Handler effects, idempotency keys, transactions | Yes | Yes | External effect records | Compliant |
| MSG-014 | Duplicate sources, keys, records, logs | Yes | Yes | Operational logs | Compliant |
| MSG-015 | Ordering assumptions, keys, sequence, concurrency | Yes | Yes | Broker config when available | Compliant |
| MSG-016 | Retry policies, classification, logs, metrics | Yes | Yes | Platform retry behavior | Compliant |
| MSG-017 | DLQ/retention, payload, context, ownership | Yes | Yes | Runbooks and monitoring | Compliant |
| MSG-018 | Validation, classification, isolation, diagnostics | Yes | Yes | Operational records | Compliant |
| MSG-019 | IDs, trace context, propagation, logs | Yes | Yes | Monitoring/tracing config | Compliant |
| MSG-020 | Replay tools, handlers, checkpoints, historical data | Yes | Yes | Reprocessing procedures | Compliant |

Naming, documentation, configuration, or queue/topic presence alone is consistently controlled and cannot produce `Confirmed` confidence without stronger corroboration.

## 18. Outcome Analysis

| ID | Pass | Fail | Warning | N/A | NEE | Independent | Status |
| --- | --- | --- | --- | --- | --- | --- | --- |
| MSG-001 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-002 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-003 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-004 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-005 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-006 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-007 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-008 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-009 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-010 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-011 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-012 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-013 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-014 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-015 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-016 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-017 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-018 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-019 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |
| MSG-020 | Yes | Yes | Yes | Yes | Yes | Yes | Compliant |

`Warning` is not used as a substitute for `Not Enough Evidence`. `Not Applicable` is not confused with `Pass`. `Fail` requires direct evidence and architectural impact.

## 19. Confidence Analysis

All twenty Rules define the official confidence levels: `Confirmed`, `Likely`, `Possible`, and `Not Enough Evidence`.

Confidence guidance is independent of outcome and severity. The Rules consistently state that naming, library presence, version labels, queue names, identifier presence, generic logging, or event storage alone cannot produce `Confirmed` confidence.

No confidence correction is required.

## 20. Severity Analysis

All twenty Rules define severity from demonstrated architectural impact within the reviewed scope.

Severity dimensions include consumer count, criticality, retained-message impact, consistency risk, duplicate effects, operational recovery, financial or regulatory exposure, detectability, recovery cost, business flow importance, and correction difficulty.

No Rule uses a score, formula, threshold, fixed severity, or automatic mapping such as `Fail = High`.

No severity correction is required.

## 21. Common Findings Analysis

Common finding shapes are present in `Evaluation Guidance` or outcome fields for every Rule.

The catalog covers the required false-negative patterns: command named as event, internal contract exposed externally, implicit ownership, generic payload, mutable event, silent breaking change, semantic schema drift, dual write, lost publication, incorrect exactly-once assumption, duplicate external effects, insufficient deduplication, ignored ordering need, infinite retry, abandoned dead-letter, poison message blocking, lost correlation, replay with current rules, divergent documentation, and off-repository operational configuration.

No Rule converts common finding shapes into examples, project-specific observations, scoring, or template language.

No corrective finding identified.

## 22. Remediation Guidance Analysis

Remediation guidance is present in `Evaluation Guidance` for all twenty Rules and remains actionable without prescribing one technology.

The Rules recommend correction shapes such as separating commands from events, mapping internal models to integration contracts, assigning ownership, adjusting granularity, copying payload data, clarifying versioning, preserving compatibility windows, documenting schema history, making publication intent recoverable, aligning acknowledgements, using business idempotency keys, distinguishing duplicates, documenting ordering scope, bounding retries, preserving dead-letter context, isolating poison messages, propagating trace context, and separating replay side effects.

No remediation requires a broker, Outbox, schema registry, exactly-once delivery, architecture testing tool, framework, cloud product, or DDD adoption as a universal solution.

No corrective finding identified.

## 23. False Positive Analysis

False-positive controls are strong across the catalog.

| Risk | Control |
| --- | --- |
| Broker presence as proof of quality | Presence is supporting evidence only. |
| Broker absence as failure | Legitimate absence and synchronous communication are allowed. |
| Universal Outbox | `MSG-010` and `MSG-011` reject named Outbox as mandatory. |
| Universal idempotency | `MSG-013` applies only when repetition can occur and effects matter. |
| Universal ordering | `MSG-015` rejects global order without evidence. |
| Universal retry | `MSG-016` allows intentional no-retry with acceptable evidenced impact. |
| Universal dead-letter | `MSG-017` applies only when operational handling is required. |
| Universal replay | `MSG-020` applies only when replay/reprocessing can occur. |
| Versioning every message | `MSG-007` requires versioning only when context needs it. |
| Schema registry required | `MSG-009` explicitly rejects registry requirement. |
| Aggregate Root required | `MSG-001` does not require aggregate-root event production. |
| Formal DDD required | `MSG-001` and catalog boundaries reject formal DDD prerequisite. |
| Event split required in every scenario | `MSG-004` rejects universal event count rules. |
| Exactly-once required | `MSG-012` rejects exactly-once as universal. |
| Complete correlation required | `MSG-019` requires sufficient context for the reviewed need, not every identifier. |
| Timestamp required | No Rule requires universal timestamp. |
| Message ID required | IDs are contextual evidence, not universal pass/fail criteria. |
| Specific technology required | All Rules remain technology-neutral. |

No false-positive corrective finding identified.

## 24. False Negative Analysis

False-negative controls are strong across the catalog.

| Risk | Primary Detection |
| --- | --- |
| Command with event name | MSG-001, MSG-006 |
| Internal contract exposed externally | MSG-002 |
| Ownership implicit or absent | MSG-003 |
| Generic payload | MSG-001, MSG-004, MSG-006 |
| Mutable event | MSG-005 |
| Silent breaking change | MSG-007, MSG-008 |
| Semantic schema change | MSG-009 |
| Dual write | MSG-010 |
| Lost publication | MSG-010, MSG-011 |
| Incorrect exactly-once assumption | MSG-012 |
| Duplicate external effects | MSG-013 |
| Insufficient deduplication | MSG-014 |
| Ignored ordering need | MSG-015 |
| Infinite retry | MSG-016 |
| Abandoned dead-letter | MSG-017 |
| Poison message blocking partition | MSG-018 |
| Lost correlation | MSG-019 |
| Replay using current rules unsafely | MSG-020 |
| Divergent documentation | MSG-006, MSG-008, MSG-009, MSG-012 |
| Off-repository operational configuration | MSG-011, MSG-012, MSG-016, MSG-017, MSG-018, MSG-019, MSG-020 |

No false-negative corrective finding identified beyond the related-rule navigation issues already recorded.

## 25. Internal Messaging Boundary Analysis

Internal boundaries are clear.

Domain semantics (`MSG-001`) and integration boundary (`MSG-002`) are separate. Ownership (`MSG-003`) is accountability, not versioning or retry. Granularity (`MSG-004`) is responsibility size, not naming or generic payload quality. Immutability (`MSG-005`) is post-publication preservation, not schema evolution or replay safety. Naming (`MSG-006`) is name-to-meaning alignment, not complete Domain Event semantics.

Versioning (`MSG-007`), compatibility (`MSG-008`), and schema evolution (`MSG-009`) form a close but well-bounded triad. Versioning identifies contract forms. Compatibility evaluates producer-consumer coexistence. Schema evolution evaluates structural and semantic change mechanics.

Producer-persistence consistency (`MSG-010`) and publication record quality (`MSG-011`) are distinct. Delivery semantics (`MSG-012`), idempotency (`MSG-013`), duplicate handling (`MSG-014`), ordering (`MSG-015`), retry (`MSG-016`), dead-letter (`MSG-017`), poison handling (`MSG-018`), correlation (`MSG-019`), and replay (`MSG-020`) each produce independent conclusions from sometimes shared failure evidence.

No problematic internal overlap was identified.

## 26. Cross-Catalog Boundary Analysis

### DDD

The catalog does not duplicate aggregate, entity, value object, domain service, repository, bounded context, global ubiquitous language, invariant, strategic design, context mapping, or aggregate consistency rules. Events may use DDD concepts as evidence, especially `MSG-001`, but findings remain about event and message responsibilities rather than global DDD maturity.

### Fowler

The catalog does not duplicate Transaction Script, Table Module, Domain Model, Service Layer, Repository, Unit of Work, Data Mapper, Active Record, DTO, or Remote Facade. DTO, Unit of Work, Domain Model, and related Fowler terms remain contextual evidence only.

### Hexagonal Architecture

The catalog does not require ports, adapters, drivers, driven actors, inside/outside terminology, or application core isolation. Messaging adapter placement remains Hexagonal when adapter isolation is the primary evaluated condition.

### Clean Architecture

The catalog does not require Entities, Use Cases, Interface Adapters, Frameworks and Drivers, gateways, controllers, presenters, boundary data structures, flow of control, or the Dependency Rule.

### Layered Architecture

The catalog does not evaluate correct layer placement, layer bypass, generic dependency between layers, Presentation, Application, Domain, or Infrastructure as primary conditions.

### SOLID

No Rule produces a primary finding about SRP, OCP, LSP, ISP, or DIP. Object responsibility and coupling may be evidence but not the conclusion.

### Architecture Testing

No Rule requires a tool, pipeline, fitness function, test coverage, or automated architecture test. Tests can provide evidence for any Rule.

### Solution Architecture

The catalog does not become a global evaluation of enterprise integration strategy, product selection, topology, vendor, cost, cloud, broad organizational governance, or build-versus-buy decisions. Ownership, operation, and contract concerns remain Rule-scoped.

No cross-catalog corrective finding identified.

## 27. Related Rules Analysis

| Rule | Related Rule | Exists | Direct Relation | Boundary Helpful | Problem |
| --- | --- | --- | --- | --- | --- |
| MSG-001 | MSG-002 | Yes | Yes | Yes | None |
| MSG-001 | MSG-006 | Yes | Yes | Yes | None |
| MSG-002 | MSG-001 | Yes | Yes | Yes | None |
| MSG-002 | MSG-007 | Yes | Yes | Yes | None |
| MSG-002 | MSG-008 | Yes | Yes | Yes | None |
| MSG-003 | MSG-002 | Yes | Yes | Yes | None |
| MSG-003 | MSG-007 | Yes | Yes | Yes | None |
| MSG-004 | MSG-001 | Yes | Yes | Yes | None |
| MSG-004 | MSG-002 | Yes | Yes | Yes | None |
| MSG-004 | MSG-006 | Yes | Yes | Yes | None |
| MSG-005 | MSG-009 | Yes | Yes | Yes | None |
| MSG-005 | MSG-020 | Yes | Yes | Yes | None |
| MSG-006 | MSG-001 | Yes | Yes | Yes | None |
| MSG-006 | MSG-004 | Yes | Yes | Yes | None |
| MSG-007 | MSG-002 | Yes | Yes | Yes | None |
| MSG-007 | MSG-008 | Yes | Yes | Yes | None |
| MSG-007 | MSG-009 | Yes | Yes | Yes | None |
| MSG-008 | MSG-007 | Yes | Yes | Yes | None |
| MSG-008 | MSG-009 | Yes | Yes | Yes | None |
| MSG-009 | MSG-007 | Yes | Yes | Yes | None |
| MSG-009 | MSG-008 | Yes | Yes | Yes | None |
| MSG-010 | MSG-011 | Yes | Yes | Yes | None |
| MSG-010 | MSG-012 | Yes | Yes | Yes | None |
| MSG-010 | MSG-020 | Yes | Yes | Yes | None |
| MSG-011 | MSG-010 | Yes | Yes | Yes | None |
| MSG-011 | MSG-014 | Yes | Yes | Yes | Missing from Rule `Dependencies`; see `EVENTS-CAT-REV-001`. |
| MSG-011 | MSG-016 | Yes | Yes | Yes | None |
| MSG-012 | MSG-013 | Yes | Yes | Yes | None |
| MSG-012 | MSG-014 | Yes | Yes | Yes | None |
| MSG-012 | MSG-016 | Yes | Yes | Yes | None |
| MSG-013 | MSG-012 | Yes | Yes | Yes | None |
| MSG-013 | MSG-014 | Yes | Yes | Yes | None |
| MSG-013 | MSG-020 | Yes | Yes | Yes | None |
| MSG-014 | MSG-012 | Yes | Yes | Yes | None |
| MSG-014 | MSG-013 | Yes | Yes | Yes | None |
| MSG-014 | MSG-020 | Yes | Yes | Yes | None |
| MSG-015 | MSG-014 | Yes | Yes | Yes | None |
| MSG-015 | MSG-020 | Yes | Yes | Yes | None |
| MSG-016 | MSG-012 | Yes | Yes | Yes | None |
| MSG-016 | MSG-013 | Yes | Yes | Yes | Missing from Rule `Dependencies`; see `EVENTS-CAT-REV-002`. |
| MSG-016 | MSG-017 | Yes | Yes | Yes | None |
| MSG-017 | MSG-016 | Yes | Yes | Yes | None |
| MSG-017 | MSG-018 | Yes | Yes | Yes | None |
| MSG-018 | MSG-017 | Yes | Yes | Yes | None |
| MSG-018 | MSG-008 | Yes | Yes | Yes | Missing from Rule `Dependencies`; see `EVENTS-CAT-REV-003`. |
| MSG-018 | MSG-009 | Yes | Yes | Yes | Missing from Rule `Dependencies`; see `EVENTS-CAT-REV-003`. |
| MSG-019 | MSG-012 | Yes | Yes | Yes | None |
| MSG-019 | MSG-016 | Yes | Yes | Yes | None |
| MSG-019 | MSG-020 | Yes | Yes | Yes | None |
| MSG-020 | MSG-005 | Yes | Yes | Yes | None |
| MSG-020 | MSG-013 | Yes | Yes | Yes | None |
| MSG-020 | MSG-014 | Yes | Yes | Yes | None |
| MSG-020 | MSG-015 | Yes | Yes | Yes | None |
| MSG-020 | MSG-019 | Yes | Yes | Yes | None |

No invented related IDs were identified.

## 28. References Analysis

References are structurally present in every Rule and are generally relevant.

All Rules reference `RULE_MODEL.md`, `SPECIFICATION.md`, `TAXONOMY.md`, and `EVENTS_CATALOG.md`. External references are recognized and relevant to messaging and event-driven systems, including Gregor Hohpe and Bobby Woolf's *Enterprise Integration Patterns*, Martin Kleppmann's *Designing Data-Intensive Applications*, Eric Evans, Vaughn Vernon, Martin Fowler's Domain Event material, and Greg Young material where relevant.

No invented URL, nonexistent source, irrelevant decorative-only reference, or indiscriminate identical external list was identified. Reference lists vary by Rule responsibility.

No corrective finding identified.

## 29. Change Notes Analysis

Change notes are acceptable for all twenty Rules.

`MSG-001` records initial Gold Standard rule content for the Events and Messaging catalog. `MSG-002` through `MSG-020` record initial rule content aligned to `EVENTS_CATALOG.md` and derived from the stabilized Gold Standard pattern in `MSG-001`.

No Rule claims that the catalog review is complete, stabilization is complete, the catalog is stabilized, a commit was made, a tag exists, a global version was published, or final approval was granted.

No corrective finding identified.

## 30. Findings

### EVENTS-CAT-REV-001 -- MSG-011 omits the catalog-listed duplicate handling relationship

* Classification: `Related Rules`
* Severity: `Low`
* Confidence: `Confirmed`
* Affected file: `skill/rules/events/MSG-011.md`
* Affected Rule: `MSG-011`
* Affected field: `Dependencies`
* Affected section: `# Dependencies`
* Evidence: `EVENTS_CATALOG.md` lists `MSG-011` related entries as `MSG-010, MSG-014, MSG-016`; `MSG-011.md` lists only `MSG-010, MSG-016`.
* Problem: The Rule omits `MSG-014` even though transactional publication resend and dispatcher recovery can create duplicate-message evidence that should be routed to duplicate handling rather than absorbed by the publication-record Rule.
* Architectural impact: Reviewers may under-emphasize the boundary between controlled resend and duplicate recognition, increasing the chance that a publication-record finding tries to evaluate duplicate handling.
* Catalog impact: Catalog-to-Rule related-entry alignment is incomplete for one direct neighboring Rule.
* False-positive risk: A reviewer may over-report `MSG-011` when the actual issue is duplicate handling after resend.
* False-negative risk: A reviewer may miss a `MSG-014` concern when publication recovery repeatedly sends the same message.
* Related Rules: `MSG-010`, `MSG-014`, `MSG-016`
* Recommended correction: Add `MSG-014` to `MSG-011` `Dependencies` and state that it is an adjacent responsibility, not a procedural prerequisite.
* Acceptance criteria: `MSG-011` `Dependencies` includes `MSG-014`; the text preserves `MSG-010` as the consistency boundary and `MSG-016` as the retry boundary; no new procedural dependency is introduced.

### EVENTS-CAT-REV-002 -- MSG-016 omits the catalog-listed consumer idempotency relationship

* Classification: `Related Rules`
* Severity: `Low`
* Confidence: `Confirmed`
* Affected file: `skill/rules/events/MSG-016.md`
* Affected Rule: `MSG-016`
* Affected field: `Dependencies`
* Affected section: `# Dependencies`
* Evidence: `EVENTS_CATALOG.md` lists `MSG-016` related entries as `MSG-012, MSG-013, MSG-017`; `MSG-016.md` lists `MSG-011, MSG-012, MSG-017, MSG-018`.
* Problem: The Rule omits `MSG-013` even though its own guidance identifies repeated side effects and coordination with idempotency as retry concerns that must remain bounded by the consumer idempotency Rule.
* Architectural impact: Reviewers may evaluate duplicate effect safety under retry strategy instead of routing consumer effect safety to `MSG-013`.
* Catalog impact: Catalog-to-Rule related-entry alignment is incomplete for one direct neighboring Rule.
* False-positive risk: A reviewer may fail `MSG-016` for a problem that belongs primarily to idempotency when retry behavior itself is bounded and observable.
* False-negative risk: A reviewer may miss idempotency risk created by legitimate retries because `MSG-013` is not visible in the related-rule field.
* Related Rules: `MSG-012`, `MSG-013`, `MSG-017`
* Recommended correction: Add `MSG-013` to `MSG-016` `Dependencies` and preserve wording that dependencies are adjacent responsibilities rather than prerequisites.
* Acceptance criteria: `MSG-016` `Dependencies` includes `MSG-013`; retry strategy remains distinct from repeated effect safety; no dead-letter or poison responsibility is absorbed.

### EVENTS-CAT-REV-003 -- MSG-018 omits catalog-listed compatibility and schema evolution relationships

* Classification: `Related Rules`
* Severity: `Low`
* Confidence: `Confirmed`
* Affected file: `skill/rules/events/MSG-018.md`
* Affected Rule: `MSG-018`
* Affected field: `Dependencies`
* Affected section: `# Dependencies`
* Evidence: `EVENTS_CATALOG.md` lists `MSG-018` related entries as `MSG-017, MSG-008, MSG-009`; `MSG-018.md` lists only `MSG-016, MSG-017`. `MSG-018` applicability includes unsupported contract versions and invalid payloads as poison-message inputs.
* Problem: The Rule omits `MSG-008` and `MSG-009`, which are direct boundaries when poison messages arise from unsupported versions, malformed schemas, invalid payload structure, or schema evolution drift.
* Architectural impact: Reviewers may treat a compatibility or schema-evolution issue purely as poison-message handling, or may miss the upstream contract cause behind permanent processing failure.
* Catalog impact: Catalog-to-Rule related-entry alignment is incomplete for two direct neighboring Rules.
* False-positive risk: A reviewer may over-report `MSG-018` when the primary defect is a compatibility break or unmanaged schema evolution.
* False-negative risk: A reviewer may miss `MSG-008` or `MSG-009` when poison behavior is only the symptom of contract incompatibility or schema drift.
* Related Rules: `MSG-008`, `MSG-009`, `MSG-016`, `MSG-017`
* Recommended correction: Add `MSG-008` and `MSG-009` to `MSG-018` `Dependencies`, with wording that compatibility and schema evolution are upstream or adjacent boundaries and not procedural prerequisites.
* Acceptance criteria: `MSG-018` `Dependencies` includes `MSG-008` and `MSG-009`; poison classification remains separate from compatibility and schema evolution conclusions; no new technology requirement is introduced.

## 31. Stabilization Recommendations

| Finding | Priority | File to alter later | Rule | Field | Recommended correction | Semantic impact | Structural impact | Correction risk | Validation needed | Related Rules update | References update | Change Notes update | Dependency | Order |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| EVENTS-CAT-REV-001 | Low | `skill/rules/events/MSG-011.md` | MSG-011 | Dependencies | Add `MSG-014` as adjacent responsibility | Clarifies duplicate boundary | One field text edit | Low | Recheck Dependencies and overlap matrix | Yes | No | Yes, if Rule edited | None | 1 |
| EVENTS-CAT-REV-002 | Low | `skill/rules/events/MSG-016.md` | MSG-016 | Dependencies | Add `MSG-013` as adjacent responsibility | Clarifies idempotency boundary | One field text edit | Low | Recheck Dependencies and retry/idempotency boundary | Yes | No | Yes, if Rule edited | None | 2 |
| EVENTS-CAT-REV-003 | Low | `skill/rules/events/MSG-018.md` | MSG-018 | Dependencies | Add `MSG-008` and `MSG-009` as adjacent responsibilities | Clarifies compatibility/schema boundary | One field text edit | Low | Recheck Dependencies and poison/schema/compatibility boundary | Yes | No | Yes, if Rule edited | None | 3 |

No stabilization correction is executed in this review.

## 32. Stabilization Order

1. Apply `EVENTS-CAT-REV-001` to `MSG-011` because publication resend and duplicate handling are an immediate adjacent boundary.
2. Apply `EVENTS-CAT-REV-002` to `MSG-016` because retry and consumer idempotency must stay explicitly adjacent.
3. Apply `EVENTS-CAT-REV-003` to `MSG-018` because poison-message classification should point reviewers back to compatibility and schema evolution when contract defects are the root cause.
4. Revalidate `Dependencies` across all `MSG-*` Rules.
5. Revalidate the mandatory overlap pairs involving `MSG-011`, `MSG-013`, `MSG-016`, `MSG-018`, `MSG-008`, and `MSG-009`.
6. Update Rule `Change Notes` only if the stabilization stage edits the affected Rule files.
7. Create a separate stabilization record only in the stabilization stage.

## 33. Final Readiness Assessment

Final classification: `Ready for Catalog Stabilization with Minor Findings`.

Rationale:

- all 20 Rules exist;
- all 20 Rules use the correct `MSG` prefix, IDs, titles, category, and file names;
- all 20 Rules contain exactly the 20 official fields in the official order;
- all 20 Rules define the five official outcomes;
- evidence, confidence, and severity guidance are conservative and aligned with normative documents;
- no central Rule responsibility is misaligned with the catalog;
- no problematic overlap was identified;
- no critical gap was identified;
- no cross-catalog boundary violation was identified;
- three corrective findings were identified, all `Low`, all limited to related-rule alignment in `Dependencies`;
- no Rule loses atomicity because of the findings.

The catalog can proceed to stabilization after minor related-rule corrections.

Rules conforming without corrective findings: `MSG-001`, `MSG-002`, `MSG-003`, `MSG-004`, `MSG-005`, `MSG-006`, `MSG-007`, `MSG-008`, `MSG-009`, `MSG-010`, `MSG-012`, `MSG-013`, `MSG-014`, `MSG-015`, `MSG-017`, `MSG-019`, `MSG-020`.

Rules partially compliant with corrective findings: `MSG-011`, `MSG-016`, `MSG-018`.

Rules non-compliant: none.

## 34. Review Change Notes

Initial Events and Messaging catalog review created.

Only `skill/reviews/EVENTS_CATALOG_REVIEW.md` was created by this review.

No change was made to `skill/rules/EVENTS_CATALOG.md`.

No change was made to `skill/rules/events/MSG-001.md` through `skill/rules/events/MSG-020.md`.

No existing review or stabilization was changed.

No stabilization was created.

No commit was made.
