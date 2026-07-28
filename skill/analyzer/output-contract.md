# Analyzer Output Contract

## Purpose

This document defines the output produced by the Architecture Analyzer.

The output must present contextual architectural diagnosis while preserving traceability, uncertainty, and separation between observed facts, architectural evidence, interpretation, diagnosis, and recommendation.

## Contract Rules

- Every conclusion must include one Analyzer confidence level.
- Every recommendation must be derived from evidence-supported diagnosis.
- Every risk and strength must identify scope and supporting evidence.
- Missing or unavailable evidence must be reported as uncertainty, not converted into failure.
- The output must be readable by architects, tech leads, and senior developers.

## Required Output Fields

## Executive Architectural Summary

Field name: `executive_architectural_summary`.

Purpose: Summarize the most important architecture-level conclusions within the reviewed scope.

Required: Required.

Expected format: Short narrative with key strengths, risks, coherence statement, and uncertainty. Include confidence for each major conclusion.

Minimum criteria: At least one traceable conclusion or an explicit `Insufficient Evidence` statement tied to unavailable inputs.

Behavior when no evidence: State that no executive architecture conclusion can be supported and identify missing inputs.

Traceability: Link to evidence IDs, finding IDs, rule IDs, scope entries, or unavailable-evidence entries.

## Predominant Architecture

Field name: `predominant_architecture`.

Purpose: Describe the architecture style most strongly supported by available evidence.

Required: Required.

Expected format: Style name, scope, supporting evidence, interpretation, limitations, and confidence.

Use `Insufficient Evidence` when no predominant style can be supported.

Minimum criteria: Multiple relevant evidence records for the same interpretation, including at least one stronger signal than naming, folders, or framework presence.

Behavior when no evidence: Use `Insufficient Evidence` and do not assign a style.

Traceability: Link to architecture classifications, evidence IDs, and scope entries.

## Secondary Architectural Influences

Field name: `secondary_architectural_influences`.

Purpose: Describe additional architectural styles, patterns, or influences supported by evidence but not predominant.

Required: Required.

Expected format: List of influence entries with scope, supporting evidence, interpretation, limitations, and confidence.

Use an empty list or `Insufficient Evidence` when unsupported.

Minimum criteria: Evidence shows a meaningful localized, partial, or non-dominant influence.

Behavior when no evidence: Use an empty list with a limitation or `Insufficient Evidence`.

Traceability: Link each influence to evidence IDs and scope entries.

## Architectural Confidence

Field name: `architectural_confidence`.

Purpose: Explain the overall confidence of the Analyzer output.

Required: Required.

Expected format: Overall confidence level with rationale based on evidence strength, consistency, coverage, and unresolved limitations.

Minimum criteria: Explicitly consider inherited Rule Engine confidence, evidence independence, contradictions, scope coverage, and unavailable evidence.

Behavior when no evidence: Use `Insufficient Evidence`.

Traceability: Link to confidence information, limitations, and the major evidence groups that drive the rating.

## Coherence Assessment

Field name: `coherence_assessment`.

Purpose: Evaluate alignment between detected architecture, rule results, findings, dependencies, boundaries, and module responsibilities.

Required: Required.

Expected format: Narrative or structured assessment containing observed facts, architectural evidence, interpretation, diagnosis, affected scope, confidence, and limitations.

Minimum criteria: Separates facts, evidence, interpretation, diagnosis, and confidence.

Behavior when no evidence: State that coherence cannot be assessed and identify missing dependency, boundary, classification, or scope inputs.

Traceability: Link to evidence IDs, rule results, findings, and scope entries.

## Architectural Strengths

Field name: `architectural_strengths`.

Purpose: Identify architecture-level conditions that support maintainability, evolvability, testability, deployability, or operational clarity.

Required: Required.

Expected format: List of strengths with evidence, scope, benefit, confidence, and limitations.

Use `Insufficient Evidence` when no strength can be supported by available material.

Minimum criteria: Evidence-supported beneficial condition with stated scope and benefit.

Behavior when no evidence: Use `Insufficient Evidence`; do not invent strengths from expected architecture style.

Traceability: Link each strength to evidence IDs, rule results, findings, or reviewed artifacts.

## Architectural Risks

Field name: `architectural_risks`.

Purpose: Identify architecture-level risks supported by correlated evidence.

Required: Required.

Expected format: List of risks with evidence, affected scope, likely consequence, severity when inherited from findings, confidence, and limitations.

Warnings are not automatically risks. A warning becomes an architectural risk only when context and evidence support architectural impact.

Minimum criteria: Evidence-supported condition with plausible architectural impact, affected scope, and confidence.

Behavior when no evidence: Use `Insufficient Evidence`; do not turn missing evidence into a risk.

Traceability: Link each risk to evidence IDs, findings, rule results, and limitations.

## Correlated Findings

Field name: `correlated_findings`.

Purpose: Group related findings that indicate a shared architectural condition.

Required: Required.

Expected format: List of correlation groups containing finding IDs, related evidence IDs, shared architectural condition, confidence, and limitations.

Use `Insufficient Evidence` or leave findings ungrouped when correlation is unsupported.

Minimum criteria: At least two related findings or one finding plus independent architectural evidence supporting a shared condition.

Behavior when no evidence: Leave ungrouped and explain why correlation is unsupported.

Traceability: Link to finding IDs, evidence IDs, and related rule IDs.

## Probable Root Causes

Field name: `probable_root_causes`.

Purpose: Explain plausible shared causes behind correlated findings when evidence permits.

Required: Required.

Expected format: List of root cause entries with supporting findings, supporting evidence, reasoning language, confidence, and caveats.

Use qualified language such as `suggests`, `is consistent with`, or `may result from`. Do not state root causes as confirmed unless direct evidence supports them.

Minimum criteria: Multiple related evidence items support a shared explanation. Symptoms must not be restated as causes.

Behavior when no evidence: Use `Insufficient Evidence`; do not identify a root cause.

Traceability: Link to correlated findings, evidence IDs, and limitations.

## Architectural Consequences

Field name: `architectural_consequences`.

Purpose: Describe the architectural effects of observed conditions and risks.

Required: Required.

Expected format: List or narrative covering consequence, affected scope, supporting evidence, expected impact, confidence, and limitations.

Consequences must stay within the reviewed scope and evidence coverage.

Minimum criteria: Consequence follows from a diagnosis, risk, strength, or observation and is framed as observed, likely, possible, or not confirmable.

Behavior when no evidence: Use `Insufficient Evidence`; do not present future outcomes as facts.

Traceability: Link to diagnoses, risks, strengths, findings, or evidence IDs.

## Evolution Roadmap

Field name: `evolution_roadmap`.

Purpose: Provide prioritized evolutionary steps derived from diagnosis.

Required: Required.

Expected format: Roadmap grouped by Immediate Stabilization, Boundary Improvements, Architectural Evolution, and Continuous Governance. Each step should include rationale, expected benefit, cost, risk, trade-offs, evidence references, and confidence.

Roadmap items must be proportional to the evidence and should favor incremental evolution.

Minimum criteria: Each item maps to a diagnosis, risk, root cause, consequence, or evidence gap and includes expected benefit, cost, risk, trade-offs, evidence references, and confidence.

Behavior when no evidence: Mark sections as not applicable or recommend evidence collection only. Do not presume migration to any architecture style.

Traceability: Link roadmap items to diagnoses, risks, root causes, evidence IDs, finding IDs, or limitations.

## Uncertainties and Limitations

Field name: `uncertainties_and_limitations`.

Purpose: Make missing, conflicting, weak, or out-of-scope evidence visible.

Required: Required.

Expected format: List of unresolved questions, unavailable evidence, excluded scope, confidence limitations, and conclusions that cannot be confirmed.

Minimum criteria: Includes unavailable inputs, conflicting evidence, weak signals, and scope boundaries that affect conclusions.

Behavior when no evidence: State that evidence is unavailable or undeclared.

Traceability: Link to input fields, scope entries, and unavailable-evidence entries.

## Evidence Traceability

Field name: `evidence_traceability`.

Purpose: Map conclusions, risks, root causes, consequences, recommendations, and confidence decisions back to their inputs.

Required: Required.

Expected format: Table or structured list containing output section, conclusion or item ID, evidence IDs, finding IDs, rule IDs, source inputs, and limitations.

Minimum criteria: Every major conclusion and recommendation has at least one traceable input reference or is explicitly marked `Insufficient Evidence`.

Behavior when no evidence: State that traceability cannot be established and identify the unavailable input fields.

Traceability: References the Analyzer input fields and evidence records.

## Review Context

Field name: `review_context`.

Purpose: Document analyzed scope, excluded scope, available input sources, and unavailable evidence used to bound the analysis.

Required: Required.

Expected format: Short structured section listing scope, exclusions, available inputs, unavailable inputs, and assumptions.

Minimum criteria: Must identify what was reviewed and what was excluded before any conclusion is presented.

Behavior when no evidence: State that review context is unavailable and restrict conclusions to `Insufficient Evidence`.

Traceability: References `review_scope_and_exclusions`, `repository_overview`, and `unresolved_or_unavailable_evidence`.

## Confidence Levels

Use exactly one of these levels for each Analyzer conclusion.

Analyzer confidence is produced by correlation and is not the same as inherited Rule Engine confidence. `Confirmed`, `Likely`, `Possible`, and `Not Enough Evidence` belong to prior Rule Engine or classification stages. The Analyzer may use those values as inputs, but it must also consider evidence relevance, independence, contradictions, scope coverage, and limitations.

Multiple weak signals do not automatically justify `High`. Repeated evidence from the same source should be treated as reinforcement of that source, not as independent corroboration. Contradictory evidence reduces confidence. `Insufficient Evidence` prevents definitive conclusions and should result in narrowed statements or evidence-gathering recommendations.

## High

Minimum criteria:

- direct or strong evidence supports the conclusion;
- evidence is traceable and relevant to the conclusion;
- reviewed scope is sufficient for the claimed scope;
- evidence is internally consistent;
- limitations do not materially weaken the conclusion.

## Medium

Minimum criteria:

- multiple evidence points support the conclusion;
- at least one evidence point is stronger than naming or folder structure;
- reviewed scope is partial but adequate for a bounded conclusion;
- limitations exist but do not overturn the interpretation;
- alternative explanations remain possible.

## Low

Minimum criteria:

- evidence suggests the conclusion but is weak, indirect, narrow, or incomplete;
- the conclusion is framed as possible or tentative;
- scope is limited;
- limitations are explicit;
- no stronger unsupported claim is made.

## Insufficient Evidence

Minimum criteria:

- available evidence cannot support the conclusion;
- required input is missing, unavailable, conflicting, or outside scope;
- naming or framework presence is the only signal;
- confidence from prior review steps is unavailable or too weak;
- the Analyzer cannot distinguish between competing interpretations.

## Template Field Alignment

The architecture analysis template must include these sections from this contract:

- Review Context;
- Executive Architectural Summary;
- Predominant Architecture;
- Secondary Architectural Influences;
- Architectural Confidence;
- Coherence Assessment;
- Architectural Strengths;
- Architectural Risks;
- Correlated Findings;
- Probable Root Causes;
- Architectural Consequences;
- Evolution Roadmap;
- Uncertainties and Limitations;
- Evidence Traceability.

`Review Context` and `Evidence Traceability` support this contract by documenting scope, exclusions, inputs, and evidence links.
