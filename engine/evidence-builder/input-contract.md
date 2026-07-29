# Evidence Builder Input Contract

## Purpose

This document defines the input accepted by the Evidence Builder.

The component consumes Rule Results produced by the Rule Engine. Each Rule Result represents the evaluated outcome of one rule against a reviewed scope.

## Contract Rules

- Inputs must be traceable to the Rule Engine output.
- Missing optional fields must remain absent or be represented as unavailable; they must not be invented.
- Required fields must be present before an Evidence Object can be created.
- Rule Result status, severity, and confidence may be preserved as metadata, but they must not be converted into a score or diagnosis.
- Limitations and contradictions must be preserved.

## Rule Result Fields

### Rule ID

Field name: `rule_id`.

Required: Required.

Purpose: Identifies the rule that produced the result.

Expected format: Stable rule identifier such as `LAYER-001`, `HEX-006`, `DDD-003`, `MSG-001`, `TEST-020`, or `SOLN-001`.

Validation: Must be non-empty and traceable to a known or declared rule source.

### Rule Version

Field name: `rule_version`.

Required: Optional.

Purpose: Identifies the version of the rule definition used during evaluation.

Expected format: Version string, revision identifier, or published rule contract version.

Validation: When present, it must be preserved exactly.

### Finding ID

Field name: `finding_id`.

Required: Optional.

Purpose: Links the Rule Result to a finding produced or referenced by the Rule Engine.

Expected format: Stable finding identifier such as `FINDING-001` or a repository-specific finding ID.

Validation: When present, it must be copied into `source_finding`.

### Architecture Reference

Field name: `architecture_reference`.

Required: Optional.

Purpose: Indicates the architecture style, pattern, category, dimension, or taxonomy entry related to the Rule Result.

Expected format: Taxonomy name, catalog ID, rule category, dimension, or `Undetermined`.

Validation: Must not be treated as final architecture classification.

### Raw Evidence

Field name: `raw_evidence`.

Required: Required.

Purpose: Contains the observed fact, rule evidence, artifact excerpt, dependency relationship, structural observation, or other concrete signal produced by the Rule Engine.

Expected format: Text, list, or structured object.

Validation: Must contain at least one concrete, traceable fact or an explicit unavailable-evidence statement.

### Traceability

Field name: `traceability`.

Required: Required.

Purpose: Links the Rule Result to reviewed material and prior ArchInspector outputs.

Expected format: Structured references to files, paths, modules, projects, namespaces, symbols, dependency edges, report sections, rule outputs, or reviewed artifacts.

Validation: Must identify the source scope sufficiently for downstream review. If fine-grained traceability is unavailable, the limitation must be explicit.

### Scope

Field name: `scope`.

Required: Required.

Purpose: Defines where the Rule Result applies.

Expected format: Repository, project, module, package, namespace, file, component, dependency edge, scenario, or reviewed subset.

Validation: Must be specific enough to prevent repository-wide interpretation when only local evidence exists.

### Metadata

Field name: `metadata`.

Required: Optional.

Purpose: Preserves additional Rule Engine fields that are useful for later correlation.

Expected format: Structured object containing status, category, inherited confidence, severity, evaluation mode, catalog source, analyzer references, or source timestamps.

Validation: Metadata must remain descriptive and must not introduce scores, weights, recommendations, or diagnosis.

### Limitations

Field name: `limitations`.

Required: Required.

Purpose: Records missing context, weak signals, partial scope, uncertainty, generated-code caveats, unavailable artifacts, or contradictory evidence noted by the Rule Engine.

Expected format: List of limitation statements.

Validation: Empty limitations are allowed only when the Rule Result explicitly declares no known limitation.

### Execution Context

Field name: `execution_context`.

Required: Optional.

Purpose: Preserves context about how the Rule Engine produced the result.

Expected format: Analysis ID, repository ID, rule catalog version, evaluation timestamp, tool version, reviewed commit, scenario ID, or run identifier.

Validation: Execution context is informational. It must not affect strength or diagnosis by itself.

## Minimum Usable Input

An Evidence Object may be created only when the input contains:

- `rule_id`;
- `raw_evidence`;
- `traceability`;
- `scope`;
- `limitations`.

When one of these fields is missing, the Rule Result must be rejected for Evidence Object creation or represented as an input validation failure outside the EvidenceSet evidence list.
