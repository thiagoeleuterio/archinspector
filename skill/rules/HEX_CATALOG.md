# Hexagonal Rule Catalog

# Catalog Scope

This catalog defines the official organization of Hexagonal Architecture rules in ArchInspector.

It lists the rule identifiers, titles, and short objectives used to organize evidence-driven review of ports, adapters, dependency direction, core isolation, and technical integration boundaries.

The catalog does not define full rule content, knowledge material, examples, templates, evaluation assets, scoring, or review output.

# Rule Ordering Principles

Rules are ordered from foundational architectural boundaries to more specific integration concerns.

The sequence begins with protection of the domain and application core, then moves through inbound ports, inbound adapters, outbound ports, outbound adapters, dependency direction, and adapter-specific concerns.

This order supports both learning and review: earlier rules establish the core concepts needed to interpret later rules, while later rules evaluate more specialized forms of boundary leakage or adapter coupling.

# Rule Catalog

| Rule ID | Title | Objective |
| --- | --- | --- |
| HEX-001 | Domain layer must not depend on infrastructure | Ensure domain code remains independent from infrastructure concerns. |
| HEX-002 | Application core must expose inbound ports | Ensure external actors enter the application through explicit application-facing boundaries. |
| HEX-003 | Inbound adapters must not contain core business behavior | Ensure delivery mechanisms delegate business behavior to the application core. |
| HEX-004 | Application core must use outbound ports for external systems | Ensure core behavior depends on abstractions rather than concrete external integrations. |
| HEX-005 | Outbound adapters must implement outbound ports | Ensure infrastructure integrations stay outside the core behind defined ports. |
| HEX-006 | Ports must be owned by the application core | Ensure boundary abstractions are defined from the core's needs rather than adapter details. |
| HEX-007 | Dependencies must point toward the core | Ensure adapters depend on the core and the core does not depend on adapters. |
| HEX-008 | Framework concerns must remain outside the core | Ensure framework-specific APIs and configuration do not leak into core behavior. |
| HEX-009 | Persistence concerns must remain behind outbound ports | Ensure storage mechanisms do not shape domain or application behavior directly. |
| HEX-010 | Messaging concerns must remain behind adapters | Ensure brokers, queues, and message handlers interact with the core through ports. |
| HEX-011 | Adapter models must not leak into core contracts | Ensure transport, persistence, or infrastructure DTOs do not become core boundary types. |
| HEX-012 | Core behavior must be testable without adapters | Ensure core behavior can be evaluated independently of infrastructure and delivery mechanisms. |

# Rule Dependencies

Some rules depend conceptually on earlier rules because they reuse the same architectural vocabulary and boundary model.

For example, rules about outbound adapters, framework leakage, persistence, messaging, and adapter models are easier to interpret after the reviewer has established the distinction between the application core, ports, adapters, and dependency direction.

These conceptual dependencies do not make rules procedurally dependent on one another. Each rule remains independently selectable and independently evaluable when the reviewed material provides enough evidence for that rule.

# Catalog Stability

Rule IDs are stable once published.

New Hexagonal Architecture rules may be added to the catalog without changing existing Rule IDs. Existing IDs must not be reused for substantially different architectural conditions.

Editorial changes may clarify titles or objectives, but changes that alter the evaluated architectural concern require a new Rule ID.
