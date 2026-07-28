# Architecture Analyzer Review

## Review Scope

Reviewed the Architecture Analyzer v0.1.0 documentation and template in `skill/analyzer/`:

- `README.md`
- `analyzer-instructions.md`
- `input-contract.md`
- `output-contract.md`
- `evidence-model.md`
- `diagnosis-model.md`
- `templates/ARCHITECTURE_ANALYSIS.md`

No files outside `skill/analyzer/` were changed.

## Overall Assessment

The module is conceptually sound and correctly positioned after Rule Engine execution. The review tightened separation between observed facts, architectural evidence, interpretation, diagnosis, and recommendation; clarified confidence models; aligned contract fields with the report template; and reinforced guardrails against unsupported architectural prescription.

## Strengths

- Clear post-rule-analysis role.
- Strong existing guardrails against style preference and unsupported rewrites.
- Explicit evidence-first principles.
- Useful separation between evidence model, diagnosis model, contracts, and report template.

## Issues Found

| ID | Severity | File | Issue | Resolution |
| --- | --- | --- | --- | --- |
| AA-001 | High | `output-contract.md`, `templates/ARCHITECTURE_ANALYSIS.md` | `Review Context` and `Evidence Traceability` were template sections but were not defined as required output fields. | Added both fields to the output contract with purpose, minimum criteria, unavailable-evidence behavior, and traceability. |
| AA-002 | High | `analyzer-instructions.md`, `output-contract.md` | Inherited Rule Engine confidence and Analyzer confidence were both present but not clearly distinguished. | Added explicit stage ownership and explained how inherited confidence influences, but does not equal, Analyzer confidence. |
| AA-003 | Medium | `input-contract.md` | Input fields lacked stable field names and expected source definitions. | Added field names and expected information sources for each input field. |
| AA-004 | Medium | `output-contract.md` | Output fields lacked minimum criteria, no-evidence behavior, and traceability expectations. | Added those requirements for each output field. |
| AA-005 | Medium | `evidence-model.md` | Evidence `direction`, `weight`, and `confidence` semantics needed sharper boundaries. | Defined `supports`, `weakens`, `contradicts`, and `neutral`; clarified weight as relative relevance and confidence as reliability. |
| AA-006 | Medium | `diagnosis-model.md` | Causality rules did not fully prevent symptoms, correlations, or future possibilities from being stated as confirmed causes or facts. | Added causal calibration rules and recommendation alignment rules. |
| AA-007 | Medium | `analyzer-instructions.md`, `diagnosis-model.md` | Hybrid architecture and mixed styles were not fully differentiated from inconsistency. | Added guidance for intentional hybrid architecture, accidental hybrid architecture, valid coexistence, partial adoption, incomplete implementation, and absence of evidence. |
| AA-008 | Low | `templates/ARCHITECTURE_ANALYSIS.md` | Template was usable but too narrative to enforce traceability and reasoning-level separation. | Converted sections to objective placeholders and compact tables with HTML comments where helpful. |
| AA-009 | Low | `README.md` | Analyzer responsibility could be read too broadly in relation to Rule Engine outputs. | Clarified that the Analyzer consumes Rule Engine outputs and does not re-evaluate rules, invent details, or transform warnings into risks. |

## Contract Consistency

The input contract now defines a stable field name, purpose, required behavior, expected format, unavailable-evidence behavior, and expected source for every input field.

The output contract now defines all sections used by the template, including `review_context` and `evidence_traceability`. No required output field is absent from the template, and no template section lacks contract coverage.

## Evidence and Diagnosis Integrity

The revised evidence model separates observed fact from architectural relevance and supported interpretation. Evidence direction, weight, confidence, related rules, related findings, and limitations are explicit.

The revised diagnosis model distinguishes architectural observation, pattern, inconsistency, risk, strength, root cause, consequence, recommendation, and evolutionary step. It now states that correlation does not prove causality, symptoms are not causes, future consequences are risks or possibilities unless observed, and recommendations must map to a diagnosis, risk, strength, or evidence gap.

## Confidence Model Assessment

The module now distinguishes inherited Rule Engine confidence (`Confirmed`, `Likely`, `Possible`, `Not Enough Evidence`) from Analyzer confidence (`High`, `Medium`, `Low`, `Insufficient Evidence`).

Analyzer confidence must consider inherited confidence together with evidence relevance, independence, contradictions, coverage, and limitations. Multiple weak or duplicate evidence items do not automatically justify high confidence. Contradictory evidence lowers confidence or narrows the conclusion. `Insufficient Evidence` prevents definitive conclusions.

## Template Assessment

The template is now usable without external instructions. It uses concise placeholders, requires evidence traceability, separates facts from interpretation and diagnosis, places confidence near major conclusions, allows contradictory evidence and unavailable information, and avoids prompts that encourage speculative conclusions.

## Changes Applied

- Clarified Analyzer responsibility and v0.1.0 boundaries.
- Added explicit reasoning-level separation across README, instructions, contracts, models, and template.
- Added stable input and output field names.
- Added expected source information for inputs.
- Added minimum criteria, no-evidence behavior, and traceability requirements for outputs.
- Clarified evidence direction, weight, confidence, independence, and strength guidance.
- Strengthened diagnosis causality, hybrid architecture, roadmap, and recommendation rules.
- Aligned the template with the output contract.

## Remaining Limitations

- This review validates documentation consistency only; it does not execute a real Analyzer implementation.
- No external rule catalogs, metrics, or architecture-style evidence catalogs were reviewed or changed.
- Markdown hierarchy and link checks were performed with lightweight repository-local validation.

## Stabilization Decision

Approved for Stabilization

The module is approved because the reviewed files now consistently define Analyzer scope, contracts, confidence handling, evidence semantics, diagnosis rules, and template structure without adding new rules, metrics, catalogs, or architecture-style prescriptions.
