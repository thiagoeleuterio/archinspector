# Evidence Builder Pipeline

## Purpose

This document defines the Evidence Builder pipeline.

The pipeline transforms Rule Results into Evidence Objects and an EvidenceSet. It defines responsibilities, validation points, failure modes, and invariants. It does not define an execution algorithm or implementation code.

```text
Receive Rule Results

↓

Validate

↓

Normalize

↓

Attach Taxonomy

↓

Identify Evidence Type

↓

Determine Strength

↓

Attach Traceability

↓

Preserve Limitations

↓

Create Evidence Objects

↓

Build EvidenceSet

↓

Return
```

## Pipeline Steps

## Receive Rule Results

Input: Rule Results produced by the Rule Engine.

Output: Received Rule Result collection.

Validations:

- Input collection exists.
- Each item is identifiable as a Rule Result.
- Execution context is preserved when available.

Possible failures:

- Missing input collection.
- Unsupported input format.
- Duplicated or ambiguous Rule Result envelope.

Invariants:

- The Evidence Builder does not execute rules.
- The Evidence Builder does not modify Rule Engine outcomes.

## Validate

Input: Received Rule Result collection.

Output: Valid Rule Results and validation failures.

Validations:

- `rule_id` is present.
- `raw_evidence` is present.
- `traceability` is present.
- `scope` is present.
- `limitations` is present or explicitly declared unavailable.

Possible failures:

- Missing required field.
- Empty rule ID.
- Evidence without traceable source.
- Scope too broad for the supplied fact.
- Raw evidence contains no concrete fact and no unavailable-evidence statement.

Invariants:

- Invalid Rule Results do not become Evidence Objects.
- Validation failures must not be converted into diagnosis.

## Normalize

Input: Valid Rule Results.

Output: Normalized evidence candidates.

Validations:

- Field names are mapped to Evidence Builder contract names.
- Raw evidence is represented as collected facts.
- Source rule and source finding references are preserved.
- Metadata remains descriptive.

Possible failures:

- Unsupported field shape.
- Ambiguous fact boundaries.
- Conflicting source identifiers.
- Metadata contains prohibited downstream outputs.

Invariants:

- Normalization does not add architectural conclusions.
- Missing optional fields remain unavailable rather than invented.

## Attach Taxonomy

Input: Normalized evidence candidates.

Output: Evidence candidates with taxonomy references.

Validations:

- Architecture references map to known taxonomy concepts when possible.
- Unknown concepts are represented as `Undetermined`.
- Catalog references do not redefine taxonomy.

Possible failures:

- Unknown taxonomy reference.
- Ambiguous taxonomy dimension.
- Missing catalog mapping.
- Conflict between source reference and known taxonomy vocabulary.

Invariants:

- Taxonomy mapping is a reference, not architecture classification.
- Unavailable taxonomy mapping must be preserved as a limitation or metadata note.

## Identify Evidence Type

Input: Evidence candidates with taxonomy references.

Output: Evidence candidates with evidence type and evidence kind.

Validations:

- Evidence type uses `Positive`, `Weak`, `Negative`, `Contradictory`, or `Contextual`.
- Evidence kind uses the allowed source-kind vocabulary.
- Contradictory and negative evidence are preserved.

Possible failures:

- Evidence source does not support a kind.
- Evidence type cannot be determined.
- Evidence mixes unrelated facts requiring separation.

Invariants:

- Evidence type describes evidence relation, not a diagnosis.
- Evidence kind describes source nature, not a diagnosis.
- Contradiction is not resolved or discarded.

## Determine Strength

Input: Evidence candidates with evidence type and evidence kind.

Output: Evidence candidates with qualitative strength.

Validations:

- Strength uses `Strong`, `Moderate`, `Weak`, or `Contextual`.
- Strength is based on evidence quality, directness, scope, and traceability.
- Strength is not calculated as a numeric weight.

Possible failures:

- Insufficient source detail to determine strength.
- Conflicting catalog guidance.
- Attempted conversion from severity, score, or confidence.

Invariants:

- Strength is not a score.
- Strength is not confidence.
- Strength does not produce diagnosis.

## Attach Traceability

Input: Evidence candidates with strength.

Output: Evidence candidates with complete traceability.

Validations:

- Source rule is attached.
- Source finding is attached when available.
- Reviewed artifact references are preserved.
- Scope and execution context remain linked.

Possible failures:

- Missing required source rule.
- Missing required traceability.
- Traceability cannot support the stated scope.
- Duplicate evidence lacks source distinction.

Invariants:

- Every Evidence Object remains traceable to its source Rule Result.
- Traceability must be specific enough to support downstream review.

## Preserve Limitations

Input: Evidence candidates with traceability.

Output: Evidence candidates with source and derived limitations.

Validations:

- Source limitations are retained.
- Missing context is explicit.
- Partial scope is explicit.
- Contradictory evidence remains visible.

Possible failures:

- Missing required limitation field.
- Limitations conflict with normalized facts.
- Limitation scope is unclear.

Invariants:

- Limitations are never dropped.
- Missing evidence is not converted into failure, score, or diagnosis.

## Create Evidence Objects

Input: Fully prepared evidence candidates.

Output: Immutable Evidence Objects.

Validations:

- Unique ID is assigned.
- Required Evidence Object fields are present.
- Allowed values are used for type, kind, and strength.
- No prohibited downstream output is embedded.

Possible failures:

- Duplicate Evidence ID.
- Missing required Evidence field.
- Invalid controlled value.
- Evidence Object contains diagnosis, recommendation, score, or confidence aggregation.

Invariants:

- Evidence Objects are immutable.
- One Evidence Object represents one normalized evidence item.

## Build EvidenceSet

Input: Evidence Objects, validation failures, collection metadata, and collection limitations.

Output: Immutable EvidenceSet.

Validations:

- Collection ID is present.
- Repository ID is present.
- Analysis ID is present.
- Evidence list contains only valid Evidence Objects.
- Statistics contain descriptive counts only.
- Collection limitations are preserved.

Possible failures:

- Missing collection identity.
- Duplicate Evidence IDs.
- Invalid Evidence Object in collection.
- Statistics include score, weight, or confidence aggregation.

Invariants:

- EvidenceSet organizes evidence only.
- EvidenceSet does not classify architecture.
- EvidenceSet does not produce score.
- EvidenceSet does not aggregate confidence.

## Return

Input: Built EvidenceSet.

Output: Evidence Builder output contract instance.

Validations:

- Output contains Evidence and EvidenceSet objects as defined by the output contract.
- Contract version is present in metadata.
- Prohibited outputs are absent.

Possible failures:

- Output contract violation.
- Missing metadata.
- Embedded diagnosis or recommendation.

Invariants:

- Returned output is ready for the Diagnosis Engine.
- Returned output contains no architecture diagnosis, score, recommendation, confidence aggregation, or execution algorithm.
