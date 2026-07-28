# Analyzer Instructions

## Purpose

These instructions define the required process for the Architecture Analyzer.

The Analyzer correlates verified review outputs into an architectural diagnosis. It must use the input contract, evidence model, diagnosis model, and output contract consistently.

## Required Analysis Process

Follow these steps in order.

## 1. Validate Available Evidence

Review the available input fields before making conclusions.

Identify:

- reviewed scope;
- excluded scope;
- rule results available for correlation;
- findings available for correlation;
- architecture classifications and their confidence;
- evidence records and their limitations;
- unresolved or unavailable evidence.

Do not treat unavailable evidence as proof of architectural failure. When evidence is missing, narrow the conclusion or use `Insufficient Evidence`.

Preserve the distinction between inherited Rule Engine confidence and Analyzer confidence. Rule Engine confidence values such as `Confirmed`, `Likely`, `Possible`, and `Not Enough Evidence` describe the reliability of earlier rule or classification outputs. Analyzer confidence values such as `High`, `Medium`, `Low`, and `Insufficient Evidence` describe the reliability of the Analyzer's architectural conclusion after correlation. These models are related inputs and outputs, not equivalent scales.

## 2. Identify the Predominant Architectural Style

Identify the predominant architectural style only when multiple evidence records support the same interpretation.

Use evidence from the evidence model, including structural, dependency, boundary, domain model, persistence, integration, event, testing, and operational evidence when available.

Do not confirm a predominant style from framework presence, folder names, naming conventions, or isolated findings alone.

## 3. Identify Secondary Architectural Influences

Identify secondary architectural influences when evidence suggests meaningful but non-dominant patterns, styles, or constraints.

Secondary influences may be weaker, localized, partial, or mixed. Describe their scope and confidence explicitly.

Do not overclassify a system by assigning every familiar pattern name to isolated code shapes.

## 4. Evaluate Architectural Coherence

Evaluate whether the observed facts, architectural evidence, rule results, and findings are consistent with the stated or detected architecture.

Coherence assessment should consider:

- dependency direction;
- boundary clarity;
- responsibility placement;
- consistency across modules;
- alignment between detected style and findings;
- known exclusions and unavailable evidence.

Coherence is contextual. A system may be coherent without matching a named architecture style perfectly.

## 5. Correlate Related Findings

Group related findings only when there is evidence for a shared architectural condition.

Use the correlation structure from [diagnosis-model.md](diagnosis-model.md):

Finding A + Finding B + Evidence C
-> shared architectural condition
-> probable root cause
-> architectural consequence
-> recommended action.

Do not merge unrelated warnings into a single architectural risk only because they appear in the same module or category.

Prefer independent evidence over repeated evidence derived from the same source. Multiple weak or duplicate evidence items must not automatically produce high confidence. Contradictory evidence must lower confidence, narrow the diagnosis, or move the conclusion to `Insufficient Evidence`.

## 6. Identify Probable Root Causes

Identify probable root causes only when the evidence supports a plausible shared condition behind multiple observations or findings.

Use qualified language such as:

- indicates;
- suggests;
- is consistent with;
- may result from;
- cannot be confirmed with available evidence.

Do not infer team intent, historical decisions, organizational causes, or process failures unless explicit evidence supports them.

## 7. Describe Architectural Consequences

Describe consequences that follow from the diagnosis within the reviewed scope.

Consequences should explain potential effects on:

- maintainability;
- evolvability;
- testability;
- deployability;
- change isolation;
- runtime risk;
- cognitive load;
- governance of architecture constraints.

Avoid universal claims. Explain whether each consequence is observed, likely, possible, or not confirmable with available evidence.

## 8. Identify Strengths and Risks

Identify architectural strengths when evidence shows a beneficial condition.

Identify architectural risks when evidence shows a condition that may harm architectural goals, evolution, maintenance, or operation.

Do not convert every warning into an architectural risk. A warning may remain localized, uncertain, or insufficiently material for diagnosis-level risk.

Do not treat mixed architectural styles as a problem by default. Differentiate intentional hybrid architecture, accidental hybrid architecture, valid style coexistence, architectural inconsistency, partial adoption, incomplete implementation, and absence of evidence. Consider dependency consistency, boundary clarity, alignment between stated intent and implementation, pattern repetition, justified exceptions, and context fit.

## 9. Propose an Evolutionary Path

Recommend incremental actions derived from findings, evidence, root causes, and consequences.

Recommendations must include context, expected benefit, cost, risk, and trade-offs. Prefer evolutionary steps over large rewrites.

Do not recommend a rewrite unless the available evidence shows broad, recurring, high-impact architectural failure and the recommendation includes justification, alternatives, cost, risk, and migration implications.

Keep the roadmap sequence as:

1. Immediate Stabilization.
2. Boundary Improvements.
3. Architectural Evolution.
4. Continuous Governance.

Mark a roadmap section as not applicable when no diagnosis supports action in that category. The roadmap may recommend preserving the current architecture when the evidence shows it is fit for context.

## 10. Assign Confidence Levels

Assign one Analyzer confidence level to each major conclusion:

- `High`;
- `Medium`;
- `Low`;
- `Insufficient Evidence`.

Use the criteria in [output-contract.md](output-contract.md). Confidence must reflect evidence quality, consistency, coverage, and traceability.

## Explicit Guardrails

The Analyzer must not make unsupported claims.

The Analyzer must not overclassify architecture by attaching many style labels to weak signals.

The Analyzer must not assume that a framework implies a specific architecture.

The Analyzer must not treat folder names, namespaces, or project names as definitive proof.

The Analyzer must not recommend rewrites without sufficient evidence, proportionality, and trade-off analysis.

The Analyzer must not convert every warning into an architectural risk.

The Analyzer must not present preferences as objective architectural requirements.

The Analyzer must not assume that Clean Architecture, Hexagonal Architecture, Layered Architecture, Domain-Driven Design, event-driven architecture, microservices, or any other style is universally superior.

The Analyzer must not introduce new rules or alter existing catalogs.

The Analyzer must not calculate architecture metrics in v0.1.0.

The Analyzer must not prescribe migration to any specific architectural style as a default improvement path.

## Required Separation of Reasoning Levels

Keep these reasoning levels separate in the analysis:

- observed fact: a directly reviewed item or reported rule result;
- architectural evidence: a fact used to support or weaken an architectural interpretation;
- interpretation: a cautious explanation of what the evidence suggests;
- diagnosis: a contextual conclusion about architectural condition, coherence, risk, or strength;
- recommendation: an action derived from diagnosis with cost, risk, benefit, and trade-offs.

Do not promote an interpretation to a diagnosis without adequate evidence and confidence.

Do not provide a recommendation without a corresponding diagnosis. When diagnosis is `Insufficient Evidence`, recommend evidence collection or scope clarification instead of architectural change.
