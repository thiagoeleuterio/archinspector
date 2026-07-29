# Evidence Object

## Purpose

An Evidence Object is one immutable, normalized, traceable architectural signal derived from a Rule Result.

It records what was observed, where it came from, how it is classified as evidence, what taxonomy reference it may relate to, and what limitations constrain its use.

It does not record an architecture diagnosis.

## Identity

Required fields:

- `id`: unique Evidence identifier within an EvidenceSet.
- `created_from`: reference to the source Rule Result.
- `source_rule`: rule ID and rule version when available.
- `source_finding`: finding ID when available, otherwise `Unavailable`.
- `schema_version`: Evidence Object contract version.

Identity must be stable within one analysis. The same Rule Result may produce more than one Evidence Object only when the source contains distinct traceable facts.

## Taxonomy Reference

Required field:

- `taxonomy_reference`.

The taxonomy reference links the evidence to Architecture Taxonomy concepts when supported by the Rule Result or an Evidence Catalog.

Recommended fields:

- `approach`: named architectural approach or `Undetermined`.
- `category`: taxonomy category or rule category when available.
- `dimension`: taxonomy dimension such as structural organization, dependency direction, domain organization, application flow, integration style, data consistency, deployment topology, runtime communication, modularity, or governance and enforcement.
- `relationship_type`: relationship described by the taxonomy when available.
- `catalog_reference`: Evidence Catalog entry when the evidence maps to one.

The taxonomy reference must not be interpreted as architecture classification.

## Evidence Classification

Required fields:

- `evidence_type`.
- `evidence_kind`.

Evidence type describes how the evidence relates to a possible architectural interpretation.

Allowed evidence type values:

- `Positive`;
- `Weak`;
- `Negative`;
- `Contradictory`;
- `Contextual`.

Evidence kind describes the source nature of the evidence. Expected values include:

- `Structural`;
- `Dependency`;
- `Naming`;
- `Framework`;
- `Domain Model`;
- `Boundary`;
- `Persistence`;
- `Integration`;
- `Event`;
- `Testing`;
- `Operational`;
- `Undetermined`.

### Positive

Positive evidence supports a possible architectural interpretation when correlated later by the Diagnosis Engine.

It does not prove the interpretation by itself.

### Weak

Weak evidence provides a lead, hint, or low-force signal. Naming, folder structure, suffixes, and framework conventions are often weak when isolated.

Weak evidence must not become strong merely because several similar weak signals exist.

### Negative

Negative evidence weakens a possible architectural interpretation without necessarily disproving it.

It should be scoped carefully and may represent a local exception, partial adoption, or missing support.

### Contradictory

Contradictory evidence directly conflicts with an asserted, expected, or previously suggested architectural interpretation in the reviewed scope.

Contradictions must be preserved as first-class evidence. The Evidence Builder must not resolve them.

### Contextual

Contextual evidence provides background that helps downstream interpretation, such as documentation, framework use, diagrams, execution context, or declared intent.

Contextual evidence should not drive a conclusion alone.

## Traceability

Required field:

- `traceability`.

Traceability must identify the most specific available source of the evidence.

Traceability may include:

- source Rule Result ID;
- rule ID and rule version;
- finding ID;
- repository ID;
- project, module, package, or namespace;
- file path;
- type, method, symbol, or component;
- dependency edge;
- reviewed artifact;
- report section;
- source line or range when available;
- execution context.

Traceability must preserve the distinction between raw fact, rule output, and later interpretation.

## Scope

Required field:

- `scope`.

Scope defines where the evidence applies and prevents local evidence from being treated as repository-wide.

Scope may be:

- repository;
- project;
- module;
- package;
- namespace;
- file;
- component;
- dependency edge;
- scenario;
- reviewed subset.

The Evidence Object must state scope precisely enough for downstream diagnosis to narrow conclusions.

## Evidence Strength

Required field:

- `evidence_strength`.

Allowed strength levels:

- `Strong`;
- `Moderate`;
- `Weak`;
- `Contextual`.

Evidence strength is qualitative. It is not a score, weight, confidence value, severity, or final architectural judgment.

### Strong

Strong evidence is directly verifiable and architecturally material within the reviewed scope.

Examples include dependency direction, boundary enforcement, responsibility placement, architecture tests, or repeated interaction flow with adequate traceability.

### Moderate

Moderate evidence has architectural relevance but partial coverage, indirect meaning, or limited scope.

It can support downstream correlation when combined with stronger or independent evidence.

### Weak

Weak evidence is a low-force signal, usually based on names, folders, namespaces, suffixes, conventions, or isolated framework clues.

It may guide review but must not confirm architecture by itself.

### Contextual

Contextual evidence frames interpretation but should not drive diagnosis alone.

Examples include documentation, diagrams, declared intent, tool context, framework configuration, or review constraints.

## Difference Between Type, Kind, and Strength

Type explains whether evidence supports, weakens, contradicts, or contextualizes a possible interpretation.

Kind explains whether the evidence comes from structure, dependency, boundary, naming, framework use, domain modeling, persistence, integration, events, testing, operations, or an undetermined source.

Strength explains the qualitative force and usefulness of the evidence for later correlation.

For example, a direct dependency violation can be `Contradictory`, `Dependency`, and `Strong`, while a folder name can be `Positive`, `Naming`, and `Weak`.

## Limitations

Required field:

- `limitations`.

Limitations must preserve uncertainty, missing context, weak source quality, incomplete traceability, generated code caveats, partial scope, unavailable artifacts, or contradictory evidence.

An Evidence Object without known limitations must still explicitly state that no known limitation was provided by the source.

## Metadata

Required field:

- `metadata`.

Metadata preserves normalized descriptive data. It may include:

- source rule category;
- inherited Rule Result status;
- inherited Rule Engine confidence;
- inherited severity;
- execution context;
- catalog reference;
- source timestamp;
- analyzer compatibility flags;
- normalization notes.

Metadata must not contain Evidence Builder scores, diagnosis, recommendations, confidence aggregation, or architecture classification output.

## Lifecycle

Lifecycle states:

- `Created`: the Evidence Object was built from a validated Rule Result.
- `Rejected`: the source Rule Result did not meet minimum input requirements.
- `Superseded`: a later analysis produced a newer Evidence Object for the same source context.

Lifecycle state records object handling only. It does not imply architectural quality or diagnosis.

## Immutability

Evidence Objects are immutable after creation.

Corrections, reclassification, or enriched mappings must produce a new Evidence Object or a new EvidenceSet version. Existing objects must remain traceable to their original Rule Result, source context, and contract version.

## Validation Rules

An Evidence Object is valid only when:

- `id` is present and unique within the EvidenceSet.
- `source_rule` includes a non-empty rule ID.
- `traceability` is present.
- `scope` is present.
- `collected_facts` contains at least one fact or explicit unavailable-evidence statement.
- `taxonomy_reference` is present, even when the value is `Undetermined`.
- `evidence_type` uses an allowed value.
- `evidence_kind` uses an allowed value.
- `evidence_strength` uses an allowed value.
- `limitations` is present.
- `metadata` is present.
- No diagnosis, recommendation, score, confidence aggregation, or architecture classification is embedded.
