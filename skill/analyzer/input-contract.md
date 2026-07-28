# Analyzer Input Contract

## Purpose

This document defines the input expected by the Architecture Analyzer.

The Analyzer consumes outputs from earlier ArchInspector steps. It does not discover source code dependencies directly or evaluate new rules in v0.1.0.

## Contract Rules

- Inputs must be traceable to reviewed material or prior ArchInspector outputs.
- Unavailable fields must be declared explicitly.
- Missing evidence must narrow or lower confidence, not automatically create a failure.
- Field names may be represented as Markdown sections, JSON properties, or structured report objects, but their meaning must remain stable.

## Input Fields

## Repository Overview

Field name: `repository_overview`.

Purpose: Describe the reviewed repository at a high level.

Required: Required.

Expected format: Text or structured object containing repository name, technology stack when known, solution shape, reviewed material, and relevant context.

Expected source: Review scope definition, repository discovery output, or structured report produced before Analyzer execution.

Behavior when unavailable: State that the repository overview is unavailable and limit all repository-wide conclusions to `Insufficient Evidence`.

## Project and Module Inventory

Field name: `project_module_inventory`.

Purpose: List projects, modules, packages, namespaces, bounded areas, or deployable units that were identified before Analyzer execution.

Required: Required when the review scope includes solution-level or module-level conclusions.

Expected format: List of project or module entries with names, paths when available, roles when supported by evidence, and known limitations.

Expected source: Repository discovery, project graph extraction, module inventory, or prior structured review output.

Behavior when unavailable: Do not infer module boundaries or solution-level coherence. Use `Insufficient Evidence` for module-wide conclusions.

## Dependency Information

Field name: `dependency_information`.

Purpose: Provide dependency relationships collected by prior steps.

Required: Optional, but required for dependency-direction or boundary-coherence conclusions.

Expected format: List, graph summary, matrix, or structured object describing project references, package references, namespace imports, type dependencies, constructor dependencies, method behavior, or other reviewed dependency evidence.

Expected source: Dependency collection output, Rule Engine evidence, project graph, static analysis report, or reviewed artifact references.

Behavior when unavailable: Do not diagnose dependency direction, fan-in, fan-out, instability, abstractness, or coupling metrics. State that dependency evidence is unavailable.

## Architecture Classifications

Field name: `architecture_classifications`.

Purpose: Provide previously detected architecture styles and their confidence.

Required: Optional, but required for predominant architecture and secondary influence conclusions.

Expected format: List of classifications with style name, scope, evidence references, inherited confidence, and limitations.

Expected source: Architecture classification stage or prior structured review output.

Behavior when unavailable: Do not assign a predominant architecture. Use `Insufficient Evidence` and describe what classification evidence is missing.

## Rule Evaluation Summary

Field name: `rule_evaluation_summary`.

Purpose: Summarize evaluated rules, categories, status distribution, scope, and coverage.

Required: Required when rule results are included.

Expected format: Structured summary with counts or grouped entries for `Pass`, `Fail`, `Warning`, `Not Applicable`, and `Not Enough Evidence`, plus coverage notes.

Expected source: Rule Engine summary output.

Behavior when unavailable: Correlate only individual findings and evidence that are available. Do not infer overall rule health or catalog coverage.

## Rule Results

Field name: `rule_results`.

Purpose: Provide individual Rule Engine outcomes for correlation.

Required: Optional, but required for rule-based diagnosis.

Expected format: List of rule results containing rule ID, category, status, inherited Rule Engine confidence, scope, evidence, reasoning, and limitations when available.

Expected source: Rule Engine result output.

Behavior when unavailable: Do not claim rule-supported architectural conditions. Use only findings and evidence records that are independently available.

## Findings

Field name: `findings`.

Purpose: Provide evaluated findings that may be grouped, correlated, or used as diagnosis inputs.

Required: Optional, but required for finding-based root cause analysis.

Expected format: List of findings following the ArchInspector finding contract: Finding ID, Rule ID, Title, Category, Severity, Confidence, Status, Scope, Evidence, Reasoning, Impact, Recommendation, Trade-offs, and References.

Expected source: Rule Engine findings, review findings report, or prior structured finding output.

Behavior when unavailable: Do not identify finding correlations or finding-derived root causes. The Analyzer may still describe evidence-supported observations.

## Confidence Information

Field name: `confidence_information`.

Purpose: Preserve confidence assigned by earlier review steps and provide confidence inputs for Analyzer conclusions.

Required: Required for any conclusion.

Expected format: Confidence per classification, rule result, finding, evidence item, or reviewed scope. Existing Rule Engine confidence values may include `Confirmed`, `Likely`, `Possible`, and `Not Enough Evidence`.

Expected source: Rule Engine results, architecture classification output, evidence records, findings, or scope coverage notes.

Behavior when unavailable: Assign `Insufficient Evidence` to affected Analyzer conclusions unless confidence can be derived from explicit evidence quality, consistency, independence, and coverage. Do not translate inherited confidence directly into Analyzer confidence without correlation.

## Unresolved or Unavailable Evidence

Field name: `unresolved_or_unavailable_evidence`.

Purpose: Make uncertainty visible and prevent unsupported conclusions.

Required: Required.

Expected format: List of missing files, unavailable code areas, omitted dependency data, excluded projects, incomplete findings, unknown runtime or deployment context, conflicting evidence, or other limitations.

Expected source: Review scope definition, evidence collection logs, Rule Engine limitations, user-provided constraints, or analyzer preparation notes.

Behavior when unavailable: Treat the input as incomplete. Add an uncertainty noting that unavailable evidence was not declared.

## Review Scope and Exclusions

Field name: `review_scope_and_exclusions`.

Purpose: Define what the Analyzer is allowed to analyze and which areas are out of scope.

Required: Required.

Expected format: Text or structured object listing included projects, modules, files, evidence sources, time or version boundaries, excluded areas, and expected coverage.

Expected source: User request, review plan, repository discovery output, or structured scope definition.

Behavior when unavailable: Do not produce repository-wide diagnosis. Limit output to local observations and mark broad conclusions as `Insufficient Evidence`.
