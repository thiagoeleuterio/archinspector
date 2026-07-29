# Evidence Builder Output Contract

## Purpose

This document defines the output produced by the Evidence Builder.

The component produces Evidence and EvidenceSet objects. These outputs are transformation artifacts for the Diagnosis Engine, not architectural conclusions.

## Output Objects

The Evidence Builder produces:

- `Evidence`: one immutable normalized evidence item derived from a Rule Result.
- `EvidenceSet`: one immutable collection of Evidence Objects for a repository analysis.

## Evidence Required Fields

Each Evidence Object must contain:

- Unique ID.
- Taxonomy reference.
- Evidence type.
- Evidence kind.
- Evidence strength.
- Source rule.
- Source finding.
- Traceability.
- Scope.
- Limitations.
- Collected facts.
- Normalized metadata.

## No Architectural Conclusions

Evidence Builder output must not include:

- Predominant architecture.
- Secondary architectural influences.
- Architecture diagnosis.
- Architectural risks.
- Architectural strengths.
- Probable root causes.
- Recommendations.
- Scores.
- Aggregated confidence.

## Output Field Meanings

### Unique ID

Field name: `id`.

Purpose: Identifies one Evidence Object within an EvidenceSet.

Expected format: Stable generated identifier such as `EV-001` or a deterministic evidence identifier.

### Taxonomy Reference

Field name: `taxonomy_reference`.

Purpose: Links evidence to taxonomy concepts when supported.

Expected format: Structured reference containing approach, category, dimension, relationship type, and catalog reference when available.

### Evidence Type

Field name: `evidence_type`.

Purpose: Classifies how the evidence relates to a possible architectural interpretation.

Expected format: `Positive`, `Weak`, `Negative`, `Contradictory`, or `Contextual`.

### Evidence Kind

Field name: `evidence_kind`.

Purpose: Classifies the source nature of the evidence represented by the object.

Expected format: Controlled value such as `Structural`, `Dependency`, `Naming`, `Framework`, `Domain Model`, `Boundary`, `Persistence`, `Integration`, `Event`, `Testing`, `Operational`, or `Undetermined`.

### Evidence Strength

Field name: `evidence_strength`.

Purpose: Describes the qualitative architectural force of the evidence for downstream correlation.

Expected format: `Strong`, `Moderate`, `Weak`, or `Contextual`.

### Source Rule

Field name: `source_rule`.

Purpose: Identifies the rule that produced the source result.

Expected format: Rule ID plus version when available.

### Source Finding

Field name: `source_finding`.

Purpose: Identifies the source finding when the Rule Result is linked to one.

Expected format: Finding ID or `Unavailable`.

### Traceability

Field name: `traceability`.

Purpose: Links the evidence to reviewed material, Rule Results, findings, files, modules, symbols, dependency edges, or report sections.

Expected format: Structured trace entries.

### Scope

Field name: `scope`.

Purpose: Defines where the evidence applies.

Expected format: Repository, project, module, package, namespace, file, component, dependency edge, scenario, or reviewed subset.

### Limitations

Field name: `limitations`.

Purpose: Preserves uncertainty, weak signals, missing context, unavailable evidence, conflicting evidence, or scope restrictions.

Expected format: List of limitation statements.

### Collected Facts

Field name: `collected_facts`.

Purpose: Stores normalized observed facts derived from `raw_evidence`.

Expected format: List of concrete statements or structured facts without diagnosis.

### Normalized Metadata

Field name: `metadata`.

Purpose: Preserves normalized contextual data needed by downstream components.

Expected format: Structured object containing rule category, inherited status, inherited confidence, execution context, catalog reference, source timestamps, and source identifiers when available.

## EvidenceSet Required Fields

Each EvidenceSet must contain:

- Collection ID.
- Repository ID.
- Analysis ID.
- Evidence list.
- Statistics.
- Collection limitations.
- Collection metadata.

The EvidenceSet organizes evidence only. It does not classify architecture, produce scores, aggregate confidence, or diagnose architectural conditions.
