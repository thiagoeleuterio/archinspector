# Rule ID

EVENT-001

# Title

Domain events should represent completed domain facts

# Category

Events and Messaging

# Status

Active

# Intent

Evaluate whether domain events preserve domain meaning by representing facts that have already occurred, rather than intentions, commands, technical notifications, or transport activity.

# Applicability

Apply this rule when the reviewed material includes an element that is presented, produced, stored, published, consumed, documented, or otherwise treated as a domain event.

The rule is relevant only when there is enough reviewed context to inspect the event role, the behavior that creates it, and the domain occurrence it claims to represent. Do not apply this rule merely because the system contains messages, callbacks, logs, audit records, integration contracts, commands, or technical notifications with event-like names.

# Rule Statement

A domain event must represent a completed, domain-significant fact that has occurred within the domain and must not be used to express a request, attempted action, technical lifecycle signal, or mutable implementation state.

# Rationale

Domain events are useful architectural signals because consumers can react to something that is already true in the domain. When an event represents an intention, a command, a persistence operation, or a technical notification, consumers may react prematurely or depend on implementation details instead of domain facts.

Misclassified domain events weaken domain language, blur the boundary between decisions and facts, and make asynchronous or internal reactions harder to reason about. The risk is semantic: the reviewed event may look like a domain event while carrying meaning that is not stable enough for domain reasoning.

# Evidence Required

Evaluation requires traceable evidence identifying the event, its claimed or inferred domain-event role, the producer flow, the domain decision or state transition associated with creation, and the fact represented by the event.

Direct evidence may include event creation code, aggregate or domain service behavior, state transitions before the event is recorded or published, validation preceding event creation, tests that assert event production, consumers that treat the event as a completed fact, event contracts or schemas, and documentation tied to the reviewed implementation.

Supporting evidence may include naming, folders, suffixes, marker interfaces, annotations, routing configuration, comments, and diagrams. Supporting evidence must not establish `Confirmed` confidence without corroborating behavioral, structural, contractual, test, or documentation evidence.

# Evaluation Guidance

First determine whether the element is actually being treated as a domain event. If it is explicitly a command, request, integration message, technical event, callback, audit record, log, DTO, transport envelope, or operational notification with no domain-event role, use `Not Applicable`.

Evaluate the event's semantics, not the whole domain model or messaging infrastructure. The central question is whether the event describes a completed fact that is meaningful in the reviewed domain. Names and tense may help interpretation, but they are not sufficient without evidence of when and why the event is created.

Interpret creation timing conservatively. A valid domain event is created after the relevant business decision, validation, or logical transition makes the fact true inside the model. Creation before validation, before an operation can still fail, or without a domain-significant occurrence is evidence against the rule.

Keep adjacent responsibilities separate. This rule does not evaluate integration contract stability, event ownership, delivery reliability, idempotency, ordering, replay, schema evolution, or observability except where that evidence directly clarifies whether the event is a completed domain fact.

# Pass Conditions

Use `Pass` when reviewed evidence is sufficient to identify the domain-event role and supports that the event represents a completed, domain-significant fact.

Use `Pass` when the event is created only after the relevant domain decision, validation, or state transition has occurred, uses domain language coherent with the represented fact, and contains information sufficient to understand that fact within the reviewed scope.

Use `Pass` when the event does not function as a command, request, technical signal, generic wrapper, or transport mechanism, and its meaning does not depend on mutable external state after creation.

# Fail Conditions

Use `Fail` when direct evidence shows that an element adopted as a domain event represents an intention, command, request, attempted action, persistence signal, framework callback, transport concern, generic wrapper, technical workflow, or implementation state rather than a completed domain fact.

Use `Fail` when the event is created before required validation or transition completion, declares success for an operation that may still fail, is emitted when no relevant domain occurrence happened, or is reused for materially different domain facts.

Use `Fail` when the event has no discernible domain significance, when its name and producer behavior conflict in a way that misleads consumers, or when its payload prevents consumers from understanding the completed fact it claims to represent.

# Warning Conditions

Use `Warning` when evidence suggests partially valid domain-event semantics but also shows ambiguity, inconsistency, or emerging risk that does not justify a definitive `Fail`.

Use `Warning` when an event mixes fact and command language, is produced around technical lifecycle points, has doubtful domain relevance, has partially incoherent payload, or is valid in some producer flows but premature or unclear in others.

Use `Warning` when tests, consumers, documentation, or producer code partially support the represented fact but leave material uncertainty about creation timing, factual completion, or domain significance.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope contains no domain events or when the system does not adopt domain events for the reviewed context.

Use `Not Applicable` when the reviewed element is a command, request, integration event, technical event, transport envelope, log, audit record, callback, DTO, persistence signal, or operational notification and is not presented or used as a domain event.

Use `Not Applicable` when the review scope is limited to publication reliability, delivery behavior, idempotency, ordering, replay, versioning, observability, adapter placement, layer dependencies, or test strategy without a domain-event semantic concern.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the reviewed material does not show the event role, producer flow, creation point, preceding validation, associated state transition, represented fact, payload meaning, consumers, or implementation-linked documentation.

Use `Not Enough Evidence` when only names, suffixes, folders, marker interfaces, comments, diagrams, or isolated schemas suggest domain-event semantics without traceable behavior showing that a completed domain fact occurred.

Use `Not Enough Evidence` when implementation and documentation conflict and the reviewed material cannot resolve whether the event behaves as a completed fact, a command, a technical signal, or an integration contract outside this rule's scope.

# Severity Guidance

The intended default severity for this rule is Medium. Assign higher severity when invalid domain-event semantics affect critical business flows, central domain decisions, multiple producers or consumers, important projections, semantic audit trails, consistency decisions, or externally retained event streams.

Assign lower severity when the issue is localized, internal, infrequent, easy to rename or separate, has limited consumers, or creates maintainability risk without demonstrated business, consistency, or operational impact. Severity must reflect architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence establishes the domain-event role, producer flow, creation timing, associated decision or state transition, payload meaning, and whether the event represents a completed domain-significant fact.

Use `Likely` when multiple consistent evidence points support the evaluation but part of the flow, tests, consumer behavior, or documentation is unavailable. Use `Possible` when evidence is limited, indirect, structurally suggestive, or naming-based with partial corroboration.

Use `Not Enough Evidence` when essential information is missing, the flow is not traceable, documentation conflicts with implementation, or the material cannot distinguish a domain event from a command, technical event, integration message, DTO, or generic message. Naming alone must not produce `Confirmed` confidence.

# Dependencies

MSG-001, MSG-002, MSG-003, MSG-005. These are related Events and Messaging rules with adjacent responsibilities, not procedural prerequisites.

# References

EVENTS_CATALOG.md

SPECIFICATION.md

TAXONOMY.md

# Change Notes

Expanded the legacy incomplete rule into the official specification format while preserving the existing rule identifier and architectural intent.
