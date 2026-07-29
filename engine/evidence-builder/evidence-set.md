# EvidenceSet

## Purpose

An EvidenceSet is an immutable collection of Evidence Objects produced for one repository analysis.

It organizes evidence for downstream diagnosis. It does not interpret, score, classify, or aggregate confidence.

## Required Fields

### Collection ID

Field name: `collection_id`.

Purpose: Identifies the EvidenceSet.

Expected format: Stable identifier unique within the analysis environment.

### Repository ID

Field name: `repository_id`.

Purpose: Identifies the repository or reviewed system.

Expected format: Repository identifier, path-derived identifier, remote identifier, or declared system ID.

### Analysis ID

Field name: `analysis_id`.

Purpose: Links the EvidenceSet to one analysis execution or review context.

Expected format: Analysis run identifier, scenario ID, review ID, or execution context identifier.

### Evidence List

Field name: `evidence`.

Purpose: Contains the Evidence Objects created from Rule Results.

Expected format: Ordered list of valid Evidence Objects.

Rules:

- The list may be empty only when no Rule Result passed validation.
- Each Evidence Object ID must be unique within the collection.
- Ordering should be stable for repeatable downstream processing.
- Contradictory, negative, weak, and contextual evidence must remain in the list.

### Statistics

Field name: `statistics`.

Purpose: Summarizes the collection contents without scoring or confidence aggregation.

Allowed examples:

- total Evidence Object count;
- count by evidence type;
- count by evidence kind;
- count by evidence strength;
- count by source rule;
- count by source rule category;
- count by scope level;
- rejected Rule Result count;
- unavailable taxonomy mapping count.

Statistics must not calculate architecture score, quality score, confidence aggregation, weighted totals, or diagnosis confidence.

### Collection Limitations

Field name: `collection_limitations`.

Purpose: Preserves limitations that apply to the whole EvidenceSet.

Expected format: List of collection-level limitations.

Examples:

- incomplete Rule Result input;
- unavailable dependency graph;
- partial repository scope;
- missing rule versions;
- unavailable fine-grained traceability;
- unsupported taxonomy mappings;
- conflicting Rule Results preserved for diagnosis.

### Collection Metadata

Field name: `collection_metadata`.

Purpose: Preserves descriptive context about the EvidenceSet.

Expected format: Structured object containing contract version, repository metadata, execution context, source Rule Engine summary, catalog versions, taxonomy version, creation timestamp, or normalization notes when available.

Metadata must not include diagnosis, recommendation, score, confidence aggregation, or architecture classification.

## Non-Responsibilities

The EvidenceSet does not classify architecture.

The EvidenceSet does not produce score.

The EvidenceSet does not aggregate confidence.

The EvidenceSet does not decide whether evidence confirms, disproves, or diagnoses an architectural condition.

The EvidenceSet only organizes Evidence Objects.

## Validation Rules

An EvidenceSet is valid only when:

- `collection_id` is present.
- `repository_id` is present.
- `analysis_id` is present.
- `evidence` is present and contains only valid Evidence Objects.
- Evidence Object IDs are unique within the collection.
- `statistics` is present and contains only descriptive counts.
- `collection_limitations` is present.
- `collection_metadata` is present.
- No score, recommendation, diagnosis, confidence aggregation, or architecture classification is embedded.

## Immutability

An EvidenceSet is immutable after creation.

Any update to evidence, metadata, limitations, taxonomy mapping, or statistics must create a new EvidenceSet version. Downstream components must be able to trace every diagnosis input back to the exact EvidenceSet version used.
