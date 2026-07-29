# Architecture Taxonomy Review

## Review Scope

This review covered `architecture-taxonomy.md` as the conceptual reference for the Architecture Analyzer and future evidence catalogs. The review checked taxonomy principles, dimensions, categories, recognized approaches, relationship semantics, coexistence values, predominance, secondary influence, hybrid architecture, partial adoption, classification conflicts, misclassification risks, analyzer guidance, extension rules, and traceability.

Reference consistency was checked against `../evidence-model.md`, `../diagnosis-model.md`, and `../evidence-catalogs/layered-evidence-catalog.md`.

## Overall Assessment

The taxonomy is suitable to serve as the central conceptual reference for architectural classification. It now states the multidimensional nature of architecture, avoids classification by naming or framework convention, separates deployment, integration, runtime communication, data consistency, structure, modularity, and governance, and preserves calibrated language for uncertainty and contradiction.

The remaining limitations are non-blocking because this document is intentionally conceptual and does not replace evidence catalogs, executable rules, analyzer contracts, or the Rule Engine.

## Taxonomy Coverage

| Category | Expected | Found | Status |
| --- | --- | --- | --- |
| Classification Dimensions | 10 | 10 | Complete |
| Architectural Categories | 8 | 8 | Complete |
| Recognized Approaches | 21 | 21 | Complete |
| Relationship Types | 9 | 9 | Complete |
| Coexistence Matrix Concepts | 11 | 11 | Complete |
| Hybrid Architecture Types | 6 | 6 | Complete |
| Partial Adoption Types | 7 | 7 | Complete |
| Classification Conflicts | 12 | 12 | Complete |
| Misclassification Risks | 15 | 15 | Complete |

## Strengths

- Clear separation between architectural dimensions and architectural quality.
- Explicit rejection of naming, folder structure, framework usage, and documentation as standalone proof.
- Stronger treatment of hybrid and partial adoption without default failure language.
- Relationship model now defines symmetry, directionality, permitted use, and conceptual boundaries.
- Coexistence matrix avoids absolute incompatibility and limits `Usually Alternative` to same-scope choices.
- Traceability now defines a usable minimum without requiring fields that may not exist for every source.

## Issues Found

| ID | Severity | Section | Issue | Resolution |
| --- | --- | --- | --- | --- |
| TAX-001 | Medium | Taxonomy Principles | Principles did not fully state dimension-specific predominance and coexistence boundaries. | Expanded principles to cover dimensions, scoped predominance, documentation limits, hybrid coherence, partial adoption, and absence of named approaches. |
| TAX-002 | Medium | Classification Dimensions | Legitimate overlaps between integration/runtime, structure/modularity, dependency/application flow, and deployment/code style were not explicit enough. | Added distinction language to the affected dimension limitations. |
| TAX-003 | Medium | Architectural Categories | Categories lacked enough boundary language for secondary category relevance. | Added coexistence and non-inference language, including secondary category handling. |
| TAX-004 | Medium | Recognized Architectural Approaches | Several approaches needed stronger prohibition against over-inference. | Clarified DDD, CQRS, MVC, Repository, Event Sourcing, Event-Driven Architecture, Microservices, Modular Monolith, Shared Database, and Database per Service. |
| TAX-005 | Medium | Relationship Model | Relationship types lacked direction, symmetry, permitted use, and distinction rules. | Replaced the compact model with a structured table covering all required semantics. |
| TAX-006 | Low | Coexistence Matrix | Matrix guidance did not explicitly constrain `Usually Alternative`. | Added same-dimension and same-scope guidance while preserving transitional coexistence. |
| TAX-007 | Low | Predominance Model | Integration and deployment were listed together and dimension-specific predominance was under-emphasized. | Separated integration and deployment evaluation and added dimension-specific predominance guidance. |
| TAX-008 | Low | Secondary Influence Model | Strong secondary influence, secondary influence, localized pattern, and partial adoption needed sharper distinction. | Added explicit distinctions and evidence requirements. |
| TAX-009 | Low | Hybrid Architecture Model | Hybrid types needed clearer separation from incoherence and failure language. | Added impact and governance threshold language plus stronger per-type prohibitions. |
| TAX-010 | Low | Partial Adoption Model | Incomplete, experimental, superficial, abandoned, and insufficient-evidence cases needed more precise evidence thresholds. | Strengthened indicators, confidence considerations, and language to avoid. |
| TAX-011 | Observation | Classification Conflicts | Conflict table was conceptually sound but lacked a global warning against naming-only resolution. | Added explicit conflict-resolution guidance. |
| TAX-012 | Observation | Misclassification Risks | Risks existed only as a bullet list, which made required evidence and safe language implicit. | Converted risks to a structured table with error, cause, evidence, and safe language. |
| TAX-013 | Observation | Analyzer Guidance | Guidance omitted explicit statements that the taxonomy must not replace evidence catalogs or the Rule Engine. | Added both prohibitions. |
| TAX-014 | Observation | Extension and Traceability | Future catalog requirements and minimum traceability needed stronger compatibility with evidence model limitations. | Added required declarations, revision rules, and a minimum usable classification record. |

## Dimension Model Assessment

The dimension model is complete and sufficiently distinct. The revised text explicitly separates integration style from runtime communication, structural organization from modularity, dependency direction from application flow, data consistency from persistence mechanisms, deployment topology from code-level architecture, and governance as a transversal confidence and enforcement dimension.

## Category Model Assessment

The category model is complete. Definitions, examples, non-inferences, and coexistence language are clear enough for future evidence catalogs. The model allows primary and secondary category relevance without forcing a single category when an approach legitimately crosses conceptual boundaries.

## Approach Classification Assessment

The 21 recognized approaches are present without duplication. The revised notes avoid improper equivalences and overreach: DDD is not treated as a complete structural style, CQRS is not a complete architecture, MVC is scoped to presentation and application flow, Repository is not proof of DDD, Event Sourcing is not equivalent to CQRS, Event-Driven Architecture does not depend on Microservices, and service or module count alone does not prove Microservices or Modular Monolith.

## Relationship Model Assessment

The relationship model now covers definition, direction or symmetry, permitted use, examples, and distinctions among all 9 relationship types. Equivalent terminology is explicitly cautious, specialization is directional, implementation variant is not treated as specialization, potentially conflicting does not imply incompatibility, and independent does not mean coexistence is impossible.

## Coexistence Matrix Assessment

The matrix covers the expected 11 concepts and uses only the controlled values in the legend. Symmetric pairs were reviewed, including Layered with Hexagonal, Clean, and Vertical Slice; Hexagonal with Clean; Clean with Onion; DDD with CQRS; CQRS with Event-Driven; Modular Monolith with Microservices; MVC with Vertical Slice; and Event-Driven with Modular Monolith and Microservices.

No absolute incompatibility is encoded. `Usually Alternative` is limited to same-scope deployment or data ownership choices and does not block localized or transitional coexistence.

## Predominance Model Assessment

The predominance model now includes repository breadth, repetition, dependency direction, boundary consistency, application flow, module organization, declared intent, contradictory evidence, exception scope, and separate treatment of deployment and integration. It supports `Insufficient Evidence` and makes confidence dependent on evidence quality and coverage.

The outputs are distinct enough for Analyzer language: predominant controls a named dimension, strong secondary influence materially affects important scope, secondary influence is meaningful but limited, localized pattern remains narrow, partial adoption describes bounded adoption state, and insufficient evidence prevents definitive classification.

## Hybrid and Partial Adoption Assessment

Hybrid architecture types are distinct and calibrated. Emergent hybrid architecture is separated from fragmented architecture by repeated shape, transitional architecture is separated from incomplete implementation by migration or modernization scope, locally specialized architecture is separated from inconsistency by bounded and stable scope, and intentional hybrid architecture is separated from casual coexistence by evidence of deliberate boundaries.

Partial adoption types now require appropriate evidence thresholds. Partial but coherent adoption is not treated as failure, incomplete implementation requires intent or interrupted boundary evidence, experimental adoption requires local scope and exploration signals, legacy coexistence avoids failed-migration language, superficial adoption requires naming or documentation to diverge from behavior, abandoned adoption requires verifiable disuse, and insufficient evidence blocks definitive conclusions.

## Classification Conflict Assessment

The 12 required conflicts are covered. Each conflict includes why confusion occurs, the differentiating dimension, minimum evidence, and calibrated language. The added global rule prevents resolving conflicts by naming or documentation alone.

## Analyzer Guidance Assessment

The 14-step flow matches the required sequence. The calibrated-use rules prevent forcing a single label, mixing dimensions, classifying by naming, inferring team intent, recommending migration from classification alone, generalizing local patterns, hiding contradictory evidence, associating classification with quality, replacing evidence catalogs, or replacing the Rule Engine.

## Extension Model Assessment

Extension rules now require future catalogs to declare primary category, affected dimensions, taxonomy references, equivalent terminology, overlaps, conflicts, distinguishing dimensions, classification scope, calibrated language, local versus repository-wide behavior, and known limitations. They also prevent evidence catalogs from silently redefining the taxonomy and require taxonomy revision for new relationship types.

## Traceability Assessment

Traceability now covers taxonomy approach, primary category, secondary categories when relevant, dimensions, relationship type, evidence IDs, findings, rule results, repository scope, contradictory evidence, confidence, and limitations.

The minimum usable classification record is clear and practical: approach or `Undetermined`, category or `Undetermined`, at least one dimension, reviewed scope, evidence IDs or explicit evidence source references, supported interpretation, confidence, and limitations. Optional fields are not made artificially mandatory.

## Changes Applied

- Rewrote taxonomy principles for multidimensional coexistence, scoped predominance, evidence requirements, documentation limits, hybrid architecture, partial adoption, quality neutrality, and uncertainty.
- Clarified all 10 classification dimensions and documented legitimate overlaps.
- Expanded category boundaries and coexistence language.
- Reviewed all 21 recognized approaches and corrected over-inference risks.
- Replaced the relationship model with a structured directional and symmetric model.
- Preserved and clarified the coexistence matrix and controlled values.
- Strengthened predominance and secondary influence criteria.
- Clarified hybrid and partial adoption models.
- Converted misclassification risks into a structured evidence table.
- Added analyzer prohibitions against replacing evidence catalogs or the Rule Engine.
- Expanded extension and traceability rules.

## Remaining Limitations

- This taxonomy remains conceptual and cannot validate code behavior without evidence catalogs and analyzer evidence.
- Approach-specific catalogs are still needed for detailed evidence interpretation outside Layered Architecture.
- Some relationship classifications remain intentionally context-dependent.
- The taxonomy does not define recommendations, scores, metrics, rules, or executable checks.

## Stabilization Decision

Approved with Non-Blocking Observations

The taxonomy is approved as a stable conceptual reference because required dimensions, categories, approaches, relationships, coexistence semantics, adoption models, conflict handling, analyzer guidance, extension rules, and traceability are present and internally consistent. Remaining limitations are expected for a conceptual taxonomy and should be addressed by future evidence catalogs rather than by expanding this document into executable logic.
