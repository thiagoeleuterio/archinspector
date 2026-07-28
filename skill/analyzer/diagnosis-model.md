# Analyzer Diagnosis Model

## Purpose

This document defines the diagnosis concepts used by the Architecture Analyzer.

Diagnosis connects verified observations, architectural evidence, rule results, and findings into contextual conclusions. It must preserve uncertainty and avoid unsupported causality.

## Core Concepts

## Architectural Observation

An architectural observation is a direct or near-direct statement about reviewed material or prior review output.

It records what is known before broader interpretation. It should be linked to evidence IDs, rule results, findings, or reviewed artifacts.

An observation is not a diagnosis. It must remain separable from architectural evidence, interpretation, consequence, and recommendation.

## Architectural Pattern

An architectural pattern is a recurring structure, dependency shape, responsibility model, or interaction model supported by evidence.

A pattern may be predominant, secondary, localized, partial, or only possible depending on evidence quality and scope.

Pattern coexistence is not automatically inconsistency. The Analyzer must distinguish intentional hybrid architecture, accidental hybrid architecture, valid style coexistence, partial adoption, incomplete implementation, and absence of evidence.

## Architectural Inconsistency

An architectural inconsistency is a mismatch between observed evidence and the expected responsibilities, boundaries, or dependency direction of the detected or stated architecture.

An inconsistency must identify scope and supporting evidence. It must not be inferred from preference or naming alone.

## Architectural Risk

An architectural risk is an evidence-supported condition that may negatively affect maintainability, evolvability, testability, deployability, operational behavior, or change isolation.

A risk may be derived from one severe finding or from correlated findings. A warning is not automatically an architectural risk.

## Architectural Strength

An architectural strength is an evidence-supported condition that improves architectural clarity, boundary protection, domain alignment, testability, operational confidence, or evolutionary capacity.

Strengths require evidence in the same way as risks.

## Root Cause

A root cause is a probable shared architectural condition that explains multiple related observations, findings, or risks.

Root causes should usually be expressed with qualified language unless direct evidence confirms the causal relationship.

A root cause must be supported by multiple related evidence items when it is used to justify architectural recommendations. A symptom must not be presented as a cause.

## Consequence

A consequence is the architectural effect that may follow from an observation, inconsistency, risk, or root cause.

Consequences must remain scoped to available evidence and must distinguish observed effects from possible effects.

Future consequences must be described as risks or possibilities unless they are directly observed in reviewed material.

## Recommendation

A recommendation is an evidence-derived action intended to reduce risk, preserve a strength, improve coherence, or support architectural evolution.

Recommendations must consider context, cost, risk, benefit, and trade-offs. They must not present architectural preference as an objective requirement.

There must be no recommendation without a corresponding diagnosis, risk, strength, or evidence gap. Recommendations should attack the probable cause or reduce the likely consequence. Evidence collection may be the correct recommendation when diagnosis confidence is insufficient.

## Evolutionary Step

An evolutionary step is a bounded recommendation that can move the architecture from its current condition toward a more coherent or lower-risk state.

Evolutionary steps should be incremental, reversible when practical, and derived from evidence-supported diagnosis.

Evolutionary steps must not assume migration to a specific architecture style. Stabilization and evolution are different: stabilization reduces current risk or uncertainty, while evolution changes architectural structure after sufficient diagnosis.

## Correlation Structure

Use the following structure when correlating findings:

Finding A + Finding B + Evidence C
-> shared architectural condition
-> probable root cause
-> architectural consequence
-> recommended action.

Each part must be traceable:

- Finding A and Finding B must reference existing finding IDs.
- Evidence C must reference one or more evidence IDs.
- The shared architectural condition must be supported by the findings and evidence.
- The probable root cause must be stated with appropriate confidence.
- The architectural consequence must fit the reviewed scope.
- The recommended action must follow from the consequence and include trade-offs.

## Causality Rules

Avoid excessive causality.

Use causal language only when evidence supports it. Prefer qualified expressions when evidence is partial:

- indicates;
- suggests;
- is consistent with;
- may result from;
- cannot be confirmed with available evidence.

Do not claim that a condition caused a finding when the available evidence only shows correlation.

Correlation does not prove causality. Use `may result from`, `is consistent with`, or `likely contributes to` when causality is plausible but not directly confirmed.

Do not infer historical intent, team behavior, organizational structure, delivery pressure, or decision quality unless such evidence is explicitly available.

Do not convert co-location into causality. Two findings in the same module may be unrelated.

Do not convert category similarity into causality. Two findings in the same rule category may have different causes.

Do not convert repeated naming signals into confirmed diagnosis.

Do not use architectural ideology as causality. A system is not risky because it is not shaped like a preferred architecture style.

Do not present future consequences as facts. State them as likely consequences, possible consequences, or risks according to evidence strength.

Do not recommend action that is unrelated to the stated diagnosis or only reflects a preferred architecture style.

## Diagnosis Validity

A diagnosis is valid only when it:

- identifies reviewed scope;
- cites supporting evidence;
- distinguishes observation from interpretation;
- assigns confidence;
- states limitations;
- avoids unsupported causality;
- leads to proportionate recommendations when action is proposed.

When these conditions are not met, the diagnosis must be narrowed or marked as `Insufficient Evidence`.

## Coherence Evaluation

Architectural coherence should consider:

- consistency of dependency direction;
- clarity and enforcement of boundaries;
- alignment between stated intent, detected style, and implementation evidence;
- repetition of patterns across the reviewed scope;
- justified exceptions;
- adequacy to the system context.

Mixed styles can be coherent when boundaries, responsibilities, and trade-offs are explicit or consistently implemented. Mixed styles become an inconsistency only when evidence shows conflicting responsibilities, unclear boundaries, dependency conflicts, or unacknowledged partial implementation that creates architectural risk.
