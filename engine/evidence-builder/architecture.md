# Evidence Builder Architecture

## Responsibilities

The Evidence Builder is responsible for transforming Rule Results into normalized Evidence Objects.

Its responsibilities are:

- Normalize rule outputs into stable field names, value formats, and terminology.
- Enrich rule results with catalog-derived and taxonomy-derived references when available.
- Attach traceability to the source rule, source finding, reviewed artifact, scope, and execution context.
- Associate taxonomy references without producing final architecture classification.
- Identify evidence types such as positive, weak, negative, contradictory, or contextual.
- Identify evidence kinds such as structural, dependency, boundary, naming, framework, domain model, persistence, integration, event, testing, or operational evidence.
- Estimate evidence strength using qualitative levels only.
- Preserve contradictions as evidence rather than resolving them.
- Preserve limitations, missing context, unavailable evidence, and scope restrictions.
- Build immutable Evidence Objects.
- Build an EvidenceSet that groups Evidence Objects for one analysis.

## Explicitly Not Responsible For

The Evidence Builder must not perform:

- Architecture diagnosis.
- Score calculation.
- Recommendation.
- Report generation.
- Rule execution.
- Confidence aggregation.
- Architecture classification.

## Architectural Boundaries

The Evidence Builder is a transformation component. It accepts Rule Results and returns Evidence Objects and EvidenceSets.

It does not inspect source code directly. Any facts about code, dependencies, modules, files, symbols, or reviewed artifacts must come from the Rule Result input or from traceable catalog and taxonomy references attached during normalization.

It does not decide whether an architecture is layered, clean, hexagonal, modular, event-driven, coherent, inconsistent, risky, or healthy. Those decisions belong to downstream diagnosis.

## Compatibility Principles

The Evidence Builder must remain compatible with:

- Analyzer contracts, by preserving reviewed scope, findings, traceability, limitations, and unavailable evidence.
- Taxonomy, by referencing architecture concepts without replacing taxonomy definitions.
- Evidence Model, by preserving evidence type, evidence kind, strength, facts, interpretation boundaries, and limitations.
- Diagnosis Model, by providing inputs that support diagnosis while keeping diagnosis outside this component.

## Contract Stability

Evidence Builder contracts should remain stable across Architecture Engine versions. New fields may be added when needed, but existing field meanings should not be redefined without a versioned contract change.
