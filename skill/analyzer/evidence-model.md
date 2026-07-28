# Analyzer Evidence Model

## Purpose

This document defines the evidence structure used by the Architecture Analyzer.

Analyzer evidence is not a replacement for Rule Engine evidence. It is a correlation-oriented representation of verified facts and findings that can support architectural interpretation, diagnosis, and recommendations.

## Evidence Principles

- Evidence must be concrete, traceable, and tied to reviewed material.
- Evidence must distinguish observed fact from supported interpretation.
- Evidence describes the architectural relevance of an observed fact; it is not a new rule evaluation.
- Naming and framework evidence are supporting signals, not definitive proof.
- Absence of evidence must not be interpreted automatically as failure.
- Each evidence item must describe limitations.
- Evidence weight helps correlation but does not produce a definitive score in v0.1.0.
- Duplicated evidence or evidence derived from the same origin must not be counted as independent corroboration.

## Evidence Structure

Each evidence item should contain the following fields.

## Evidence ID

Purpose: Provide a stable identifier for traceability.

Expected format: Short unique ID such as `EV-001` within one analysis output.

## Source

Purpose: Identify where the evidence came from.

Expected format: File path, project name, package reference, namespace, type, method, rule result, finding ID, report section, or reviewed artifact.

## Evidence Type

Purpose: Classify the kind of evidence.

Expected format: One of the initial evidence types defined below.

## Observed Fact

Purpose: Record what was directly observed or received from prior review output.

Expected format: Concrete statement without interpretation. Include paths, identifiers, relationships, rule IDs, or finding IDs when available.

## Supported Interpretation

Purpose: Explain what the observed fact may support architecturally.

Expected format: Cautious interpretation using qualified language when confidence is not high.

## Architectural Style

Purpose: Identify the style, pattern, category, or influence related to the evidence.

Expected format: Named style or category such as Clean Architecture, Hexagonal Architecture, Domain-Driven Design, Layered Architecture, Fowler Patterns, Events and Messaging, Architecture Testing, Solution Architecture, or `Undetermined`.

## Direction

Purpose: Describe whether the evidence supports, weakens, contradicts, or is neutral toward an architectural interpretation.

Expected format: one of:

- `supports`: the evidence strengthens the stated interpretation.
- `weakens`: the evidence makes the stated interpretation less plausible without directly disproving it.
- `contradicts`: the evidence conflicts with the stated interpretation.
- `neutral`: the evidence is relevant context but does not materially support or weaken the interpretation.

## Weight

Purpose: Indicate relative usefulness for correlation.

Expected format: `strong`, `moderate`, `weak`, or `contextual`.

Weight represents relative architectural relevance, not correctness, severity, confidence, or a final score. Weights do not represent a definitive score in v0.1.0. They guide explanation and prioritization only.

Use weights conservatively:

- `strong`: directly verifiable dependency, boundary, responsibility, runtime, or behavioral evidence with adequate scope.
- `moderate`: relevant evidence with partial scope or indirect architectural meaning.
- `weak`: naming, folder, namespace, class-name, or framework signals when analyzed in isolation.
- `contextual`: background evidence that helps interpret other evidence but should not drive a conclusion alone.

## Confidence

Purpose: Record confidence in the evidence item or the supported interpretation.

Expected format: Analyzer confidence values: `High`, `Medium`, `Low`, or `Insufficient Evidence`.

Confidence represents reliability of the interpretation attached to the evidence. Weight and confidence are not equivalent: an evidence item can be architecturally important but low confidence, or low weight but high confidence as a narrow fact.

## Related Rules

Purpose: Link the evidence to evaluated rules when applicable.

Expected format: List of rule IDs or empty list.

## Related Findings

Purpose: Link the evidence to findings when applicable.

Expected format: List of finding IDs or empty list.

## Limitations

Purpose: State uncertainty, missing context, weak signals, scope limits, or conflicting evidence.

Expected format: Short text or list of limitations.

## Initial Evidence Types

## Structural

Evidence from repository layout, solution structure, projects, modules, namespaces, or visible component organization.

Structural evidence is useful for scope and organization, but names and folders alone are not definitive proof of architectural style.

## Dependency

Evidence from project references, package references, imports, type dependencies, constructor dependencies, method calls, or previously collected dependency relationships.

Dependency evidence can strongly support boundary and direction conclusions when scope is adequate.

## Naming

Evidence from names of projects, folders, namespaces, types, methods, or conventions.

Naming evidence is weak unless corroborated by stronger evidence.

## Framework

Evidence from frameworks, libraries, runtime hosts, persistence frameworks, messaging frameworks, dependency injection frameworks, or testing frameworks.

Framework evidence can indicate technical context but must not be treated as proof of architecture style.

## Domain Model

Evidence from domain entities, value objects, aggregates, domain services, domain events, ubiquitous language, or domain behavior.

Domain model evidence supports Domain-Driven Design or domain boundary interpretations only when behavior and responsibility are visible.

## Boundary

Evidence from interfaces, ports, adapters, layers, module boundaries, visibility constraints, allowed dependencies, or ownership boundaries.

Boundary evidence is central for coherence analysis.

## Persistence

Evidence from repositories, data mappers, active record structures, ORM usage, database access patterns, migrations, or persistence abstractions.

Persistence evidence must distinguish technical mechanism from architectural responsibility.

## Integration

Evidence from external systems, APIs, clients, gateways, adapters, contracts, protocols, or integration boundaries.

Integration evidence can support coupling and boundary diagnosis when relationships are traceable.

## Event

Evidence from domain events, integration events, messages, handlers, publishers, subscribers, brokers, queues, topics, or asynchronous flows.

Event evidence must distinguish message transport from message semantics.

## Testing

Evidence from architecture tests, boundary tests, dependency tests, contract tests, unit tests, integration tests, or verification mechanisms.

Testing evidence can support confidence in architectural constraints, but the absence of tests is not automatically a failure without scope and context.

## Operational

Evidence from deployment topology, configuration, observability, runtime boundaries, infrastructure definitions, runbooks, or operational constraints.

Operational evidence may affect architectural diagnosis when it is available and in scope.

## Evidence Strength Guidance

Folder names, namespaces, and class names are weak evidence when analyzed alone. They may support a hypothesis only when corroborated by stronger evidence.

Dependencies, boundaries, responsibility placement, and structural behavior have greater architectural force when they are directly verifiable and within the reviewed scope.

Evidence records that repeat the same fact, derive from the same source, or restate a single finding should be treated as related evidence, not independent evidence.

Contradictory evidence must be recorded with `weakens` or `contradicts` direction and must reduce confidence or narrow the supported interpretation.
