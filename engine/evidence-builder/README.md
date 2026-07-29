# Evidence Builder

## Purpose

The Evidence Builder is the first executable foundation of the future Architecture Engine.

Its purpose is to transform Rule Results produced by the Rule Engine into immutable Evidence Objects that can be consumed by the Diagnosis Engine.

The component preserves traceable architectural signals. It does not produce architectural conclusions.

## Position in the Architecture

The Evidence Builder sits between rule evaluation and architectural diagnosis.

```text
Rule Engine

↓

Rule Results

↓

Evidence Builder

↓

Evidence Objects

↓

Diagnosis Engine
```

## Responsibilities

- Receive Rule Results from the Rule Engine.
- Validate that required rule-result fields are present.
- Normalize raw rule outputs into stable Evidence fields.
- Enrich evidence with taxonomy and catalog references when available.
- Attach source traceability from rules, findings, reviewed artifacts, and scope.
- Identify the Evidence Type.
- Estimate Evidence Strength as a qualitative signal.
- Preserve contradictory, weak, negative, and contextual evidence.
- Preserve limitations and unavailable context.
- Build immutable Evidence Objects.
- Organize Evidence Objects into an EvidenceSet.

## Responsibilities That Do Not Belong Here

- Architecture diagnosis.
- Architecture classification.
- Score calculation.
- Recommendation.
- Report generation.
- Rule execution.
- Confidence aggregation.
- Root-cause analysis.
- Architectural roadmap generation.

## Relationship With the Rule Engine

The Rule Engine evaluates rules and produces Rule Results. The Evidence Builder consumes those Rule Results as input.

The Evidence Builder must not execute rules, reinterpret rule intent, change rule outcomes, or create new findings. It may normalize and enrich Rule Results so downstream components can reason over them consistently.

## Relationship With Taxonomy

The Architecture Taxonomy provides conceptual references such as architectural approaches, categories, dimensions, and relationship types.

The Evidence Builder attaches taxonomy references when a Rule Result or Evidence Catalog provides enough information. It must preserve `Undetermined` when taxonomy mapping is unavailable or unsupported.

## Relationship With Evidence Catalogs

Evidence Catalogs define known evidence patterns, evidence types, strength guidance, limitations, and traceability expectations for specific architectural areas.

The Evidence Builder may use catalog references to classify evidence and determine qualitative strength. It must not treat catalogs as executable rules, scoring models, or diagnosis rules.

## Relationship With the Diagnosis Engine

The Diagnosis Engine consumes Evidence Objects and EvidenceSets to produce architectural interpretation, diagnosis, risks, strengths, root causes, confidence, and recommendations.

The Evidence Builder provides clean, traceable, immutable evidence. It does not decide what the evidence means architecturally beyond its normalized classification fields.
