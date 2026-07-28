# Architecture Analyzer

## Purpose

The Architecture Analyzer is a post-rule-analysis module for ArchInspector.

Its purpose is to correlate Rule Engine results, findings, evidence records, unavailable evidence, and architectural classifications into a contextual architectural diagnosis that can be understood by architects, tech leads, and senior developers.

The Analyzer does not replace the Rule Engine. It consumes Rule Engine outputs and explains what the evidence suggests about architectural coherence, strengths, risks, probable root causes, consequences, and possible evolutionary steps. It must not re-evaluate individual rules, invent missing details, or convert warnings or absent evidence into risks.

## Position in the ArchInspector Pipeline

The Architecture Analyzer runs after evidence collection, architecture classification, rule selection, and rule evaluation.

The expected pipeline position is:

1. Discover available material.
2. Define review scope.
3. Detect likely architecture styles.
4. Select applicable rules.
5. Collect evidence.
6. Evaluate rules.
7. Produce findings.
8. Run the Architecture Analyzer.
9. Generate architecture analysis output.
10. Use the analysis to inform reports and roadmaps.

The Analyzer must not create new architectural rules, modify existing catalogs, or evaluate source code dependencies directly in v0.1.0.

## Inputs

The Analyzer accepts structured review material, including:

- repository overview;
- project and module inventory;
- dependency information already collected by prior steps;
- architecture classifications;
- rule evaluation summary;
- rule results;
- findings;
- confidence information;
- unresolved or unavailable evidence;
- review scope and exclusions.

The complete input contract is defined in [input-contract.md](input-contract.md).

## Outputs

The Analyzer produces a contextual architecture analysis containing:

- executive architectural summary;
- predominant architecture;
- secondary architectural influences;
- architectural confidence;
- coherence assessment;
- architectural strengths;
- architectural risks;
- correlated findings;
- probable root causes;
- architectural consequences;
- evolution roadmap;
- uncertainties and limitations.

The complete output contract is defined in [output-contract.md](output-contract.md).

## Principles

- Evidence before diagnosis.
- Context before architectural preference.
- Absence of evidence is not automatic evidence of failure.
- Every conclusion must have a confidence level.
- Observed facts, architectural evidence, interpretation, diagnosis, and recommendation must remain distinct.
- Observed facts must be directly verifiable from reviewed material or prior ArchInspector outputs.
- Architectural evidence is the architectural relevance of an observed fact, not the fact itself.
- Interpretation is a cautious reading supported by evidence.
- Diagnosis is a contextual conclusion derived from correlating multiple relevant evidence items when available.
- Recommendation comes after diagnosis and must consider context, cost, risk, benefit, and reversibility.
- Naming, folder structure, and framework presence are supporting signals, not definitive proof.
- No architecture style is treated as universally superior.
- Uncertainty must be visible instead of hidden behind generic language.

## Version 0.1.0 Limitations

Version 0.1.0 defines the initial documentation, contracts, evidence model, diagnosis model, and output template for the Architecture Analyzer.

It does not:

- compute fan-in, fan-out, instability, abstractness, or other architecture metrics;
- inspect source code dependencies directly;
- introduce new architectural rules;
- modify rule catalogs;
- calculate a definitive architecture score;
- infer missing evidence as a failure;
- recommend rewrites without strong evidence and explicit trade-off analysis.

## Module Structure

- [README.md](README.md): module purpose, pipeline position, principles, limitations, and usage overview.
- [analyzer-instructions.md](analyzer-instructions.md): required analysis process and guardrails.
- [input-contract.md](input-contract.md): expected input fields and unavailable-evidence behavior.
- [output-contract.md](output-contract.md): required output fields and Analyzer confidence levels.
- [evidence-model.md](evidence-model.md): evidence structure, evidence types, weight, and traceability rules.
- [diagnosis-model.md](diagnosis-model.md): diagnosis concepts and correlation rules.
- [templates/ARCHITECTURE_ANALYSIS.md](templates/ARCHITECTURE_ANALYSIS.md): architecture analysis report template.

## Summary Example

Given a review with several rule results related to boundary leakage, direct persistence access from application services, and weak architecture test coverage, the Analyzer may correlate those findings with dependency and boundary evidence.

The output should distinguish:

- observed fact: a project reference or finding exists in the reviewed material;
- architectural evidence: the fact supports a boundary concern;
- interpretation: the boundary appears inconsistently protected;
- diagnosis: architectural coherence is reduced in the affected scope;
- recommendation: prioritize incremental boundary stabilization before broader architectural evolution.

If the reviewed material does not include project references, dependency information, or relevant code excerpts, the Analyzer must state the limitation and use `Insufficient Evidence` for unsupported conclusions.
