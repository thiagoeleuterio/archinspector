# Rule Model

## Purpose

This document defines the conceptual model of the Rule entity in ArchInspector.

It explains what a Rule represents, which conceptual properties every Rule must have, and how a Rule differs from other ArchInspector artifacts.

## Definition

A Rule is a reusable and normative architectural condition selected according to review context and evaluated against the evidence available in the reviewed material.

A Rule defines what architectural condition should be assessed. It does not define the final finding, recommendation, report wording, score, or project-specific interpretation.

## Core Properties

Every Rule must be:

- Atomic: it evaluates one architectural concern.
- Reusable: it can be applied across reviews when the context is relevant.
- Evidence-driven: it can only be evaluated from concrete reviewed material.
- Context-aware: it is selected only when relevant to the review scope and system context.
- Independently evaluable: it can produce an evaluation outcome without depending on a report, example, scenario, or scoring formula.
- Uniquely identifiable: it has a stable identity that distinguishes it from every other Rule.
- Stable over time: its published meaning remains consistent across reviews and versions.
- Outcome-complete: it defines enough evaluation intent to support all official review outcomes.

## Rule Boundaries

A Rule is not:

- a finding;
- a project-specific observation;
- a checklist;
- a recommendation;
- knowledge content;
- an example;
- a report template;
- an evaluation scenario;
- a scoring formula.

A Rule may inform these artifacts, but it must not become any of them.

## Stability

The meaning of a published Rule must remain stable over time.

Minor editorial improvements may clarify wording without changing the evaluated architectural condition. Substantial changes to the meaning, scope, or evaluation intent require a new Rule.

## Relationship with Rule Specification

`RULE_MODEL.md` defines the concept of a Rule in ArchInspector.

`SPECIFICATION.md` defines how a Rule must be documented.
