# Hexagonal Catalog Review

# 1. Catalog Completeness

The Hexagonal Architecture catalog covers the central concerns defined for the category: protection of the domain and application core, inbound boundaries, outbound boundaries, adapter responsibility, dependency direction, framework isolation, persistence isolation, messaging isolation, adapter model leakage, and independent evaluation of core behavior.

The foundational boundary from core to infrastructure is covered by HEX-001 and HEX-007. HEX-001 focuses on domain dependency on infrastructure, while HEX-007 covers the broader dependency direction between the application core and adapters. Together they provide the main structural protection expected from Hexagonal Architecture.

Inbound interaction is covered by HEX-002 and HEX-003. HEX-002 requires explicit inbound ports for external actors, and HEX-003 keeps core business behavior out of inbound adapters. This covers the driving side of the architecture without requiring a specific delivery mechanism.

Outbound interaction is covered by HEX-004, HEX-005, and HEX-006. HEX-004 requires outbound ports for external systems, HEX-005 requires outbound adapters to implement or satisfy those ports, and HEX-006 requires ports to be owned by the application core. This covers the driven side of the architecture and the ownership of boundary abstractions.

Specialized adapter leakage is covered by HEX-008, HEX-009, HEX-010, and HEX-011. HEX-008 addresses framework concerns, HEX-009 addresses persistence concerns, HEX-010 addresses messaging concerns, and HEX-011 addresses adapter models in core contracts. These Rules make the generic core isolation principle more concrete for common integration mechanisms.

Independent evaluation of core behavior is covered by HEX-012. This is consistent with the classical expectation that the application core can be exercised without delivery or infrastructure mechanisms.

Identified gaps:

- The catalog does not explicitly distinguish primary and secondary adapter terminology as a catalog-level concept, although the same concern is effectively represented by inbound and outbound boundaries in HEX-002, HEX-003, HEX-004, HEX-005, HEX-009, and HEX-010.
- The catalog does not explicitly assess adapter substitutability as its own evaluated condition, although substitutability is implied in HEX-004, HEX-005, HEX-006, HEX-007, and HEX-012.
- The catalog does not explicitly assess whether the same core behavior can be reached through multiple inbound adapters without duplicating behavior, although the concern is partially addressed by HEX-002 and HEX-003.
- The catalog does not explicitly assess composition or wiring boundaries, although framework and adapter coupling risks are partially addressed by HEX-007, HEX-008, HEX-009, HEX-010, and HEX-012.

# 2. Rule Independence

The Rules are generally independently evaluable. Each Rule defines its own applicability, evidence requirements, pass conditions, fail conditions, warning conditions, not applicable conditions, not enough evidence conditions, severity guidance, and confidence guidance.

HEX-001 is independent because it evaluates domain dependency on infrastructure without requiring the evaluator to first evaluate any other Rule.

HEX-002 is independent because it evaluates whether inbound interaction paths enter the application core through explicit inbound ports.

HEX-003 is independent because it evaluates behavior placement in inbound adapters, not the mere existence of inbound ports. It overlaps conceptually with HEX-002 but evaluates a distinct responsibility.

HEX-004 is independent because it evaluates whether core outbound interactions depend on ports instead of concrete external systems.

HEX-005 is independent because it evaluates whether outbound adapters implement or satisfy outbound ports outside the core. It is related to HEX-004, but HEX-004 evaluates the core side of the boundary while HEX-005 evaluates the adapter side.

HEX-006 is independent because it evaluates ownership and shape of ports. It depends on shared vocabulary with HEX-002, HEX-004, and HEX-005, but it can still be evaluated from direct evidence about where ports are declared and how their contracts are shaped.

HEX-007 is independent because it evaluates general dependency direction between the core and adapters. It overlaps with HEX-001, HEX-004, HEX-005, HEX-008, HEX-009, and HEX-010, but it states a broader structural concern and explicitly leaves specialized leakage to the corresponding specialized Rules.

HEX-008 is independent because it evaluates framework concerns in the core, which can be assessed without first evaluating all dependency direction Rules.

HEX-009 is independent because it evaluates persistence concerns behind outbound ports. It shares boundary vocabulary with HEX-004, HEX-005, HEX-006, and HEX-007, but its evaluated concern is persistence-specific leakage.

HEX-010 is independent because it evaluates messaging concerns behind adapters. It shares inbound and outbound vocabulary with HEX-002, HEX-004, HEX-005, HEX-006, and HEX-007, but its evaluated concern is messaging-specific leakage.

HEX-011 is independent because it evaluates adapter model leakage into core contracts. It overlaps with HEX-006, HEX-009, and HEX-010, but its distinct boundary is contract type leakage rather than ownership, persistence mechanism leakage, or messaging mechanism leakage.

HEX-012 is independent because it evaluates whether core behavior can be exercised without adapters. It uses evidence that may also support HEX-003, HEX-004, HEX-005, HEX-007, HEX-008, HEX-009, and HEX-010, but it evaluates testability of core behavior rather than the underlying boundary condition itself.

# 3. Responsibility Boundaries

The boundary between HEX-001 and HEX-007 is clear enough but close. HEX-001 is limited to domain dependency on infrastructure. HEX-007 covers dependency direction between application core and adapters more generally.

The boundary between HEX-002 and HEX-003 is clear. HEX-002 evaluates entry through inbound ports. HEX-003 evaluates whether inbound adapters contain core business behavior.

The boundary between HEX-004 and HEX-005 is clear. HEX-004 evaluates whether the application core uses outbound ports for external systems. HEX-005 evaluates whether outbound adapters implement or satisfy those outbound ports.

The boundary between HEX-004 and HEX-006 is clear but related. HEX-004 evaluates use of outbound ports by the core. HEX-006 evaluates ownership and shaping of ports by core needs.

The boundary between HEX-007 and specialized leakage Rules requires reviewer discipline. HEX-007 covers general dependency direction, while HEX-008, HEX-009, HEX-010, and HEX-011 cover specific leakage mechanisms. The text of HEX-007 explicitly directs specialized leakage to the corresponding Rules, which reduces ambiguity.

The boundary between HEX-008 and HEX-010 is clear when messaging frameworks are present. HEX-008 evaluates framework-specific APIs and configuration in the core. HEX-010 evaluates messaging mechanisms, brokers, handlers, and messaging contracts behind adapters.

The boundary between HEX-009 and HEX-011 is clear but close. HEX-009 evaluates persistence concerns shaping domain or application behavior. HEX-011 evaluates persistence or infrastructure DTOs used as core contract types.

The boundary between HEX-010 and HEX-011 is clear but close. HEX-010 evaluates messaging concerns behind adapters. HEX-011 evaluates messaging-related adapter models when they leak into core contracts.

The boundary between HEX-012 and HEX-007 is clear in intent. HEX-007 evaluates dependency direction, while HEX-012 evaluates whether core behavior can be evaluated without concrete adapters. HEX-012 explicitly states that it does not evaluate general dependency direction except as evidence for its own condition.

# 4. Consistency

Terminology is consistent across the catalog. The Rules consistently use application core, domain, inbound adapters, outbound adapters, ports, adapters, external actors, external systems, infrastructure, reviewed scope, direct evidence, naming conventions, and adapter-specific concerns.

Normative language is consistent. Each Rule uses a direct requirement in the Rule Statement. HEX-011 has a title that says adapter models must not leak into core contracts, while its Rule Statement says adapter models must not become types in core contracts. The meaning is consistent, but the wording is slightly narrower in the Rule Statement than in the title.

Severity guidance is consistent. HEX-001 through HEX-012 all assign higher severity based on central behavior, broad surfaces, stable boundaries, or architectural impact, and lower severity for narrow, isolated, indirect, or peripheral concerns.

Confidence guidance is consistent. HEX-001 through HEX-012 use `Confirmed`, `Likely`, `Possible`, and `Not Enough Evidence` consistently, and each Rule prevents naming alone from producing `Confirmed` confidence.

Applicability guidance is consistent. Each Rule starts by requiring enough reviewed material to identify the relevant scopes and concerns. The Rules consistently avoid assuming that a system claims Hexagonal Architecture before evaluation.

Evidence guidance is consistent. HEX-001 through HEX-012 require traceable evidence and consistently treat naming as a supporting signal rather than conclusive evidence.

Evaluation guidance is consistent. Each Rule instructs the reviewer to first establish the relevant scopes, then evaluate the architectural condition conservatively from the strongest available evidence.

Catalog-level consistency issue: the repository contains an additional `HEX-001` file under `skill/rules/hexagonal/HEX-001.md` that does not follow the Rule Specification format and duplicates an existing Rule ID already represented by `skill/rules/HEX-001.md`. This creates a catalog hygiene risk for HEX-001 even though `HEX_CATALOG.md` lists only one HEX-001 entry.

# 5. Dependency Analysis

The catalog contains conceptual dependencies but no required procedural execution chain.

HEX-001, HEX-002, HEX-003, HEX-004, and HEX-005 declare no dependencies and can be selected and evaluated independently.

HEX-006 declares dependencies on HEX-002, HEX-004, and HEX-005. These dependencies are conceptual because HEX-006 uses inbound and outbound port vocabulary, but the Rule itself contains sufficient applicability, evidence, and evaluation guidance to be evaluated independently.

HEX-007 declares dependencies on HEX-001, HEX-002, HEX-004, and HEX-005. These dependencies are conceptual because HEX-007 uses the same boundary model, but it can be evaluated from direct dependency evidence without requiring prior evaluation outcomes from those Rules.

HEX-008 declares a dependency on HEX-007. This dependency is conceptual because framework leakage often manifests as dependency direction risk, but HEX-008 can be evaluated directly from evidence about framework concerns inside core behavior.

HEX-009 declares dependencies on HEX-004, HEX-005, HEX-006, and HEX-007. These dependencies are conceptual because persistence boundaries depend on outbound ports, adapter implementation, port ownership, and dependency direction as vocabulary. HEX-009 still defines its own persistence-specific evaluation condition.

HEX-010 declares dependencies on HEX-002, HEX-004, HEX-005, HEX-006, and HEX-007. These dependencies are conceptual because messaging can be inbound or outbound and can involve ports, adapters, and dependency direction. HEX-010 remains independently evaluable from evidence about messaging concerns and adapter boundaries.

HEX-011 declares dependencies on HEX-002, HEX-004, HEX-006, HEX-007, HEX-009, and HEX-010. These dependencies are conceptual because adapter model leakage may appear in inbound, outbound, persistence, or messaging contracts. HEX-011 remains independently evaluable from evidence about core contract types and adapter models.

HEX-012 declares dependencies on HEX-003, HEX-004, HEX-005, HEX-007, HEX-008, HEX-009, and HEX-010. These dependencies are conceptual because independent core evaluation may be affected by behavior placement, outbound abstractions, adapter implementations, dependency direction, framework concerns, persistence concerns, and messaging concerns. HEX-012 remains independently evaluable because it defines its own condition around evaluating core behavior without adapters.

No circular dependency is present among HEX-001 through HEX-012.

# 6. Catalog Coverage

Against the classical Hexagonal Architecture model, the catalog provides strong coverage of the core idea that the application is protected from external actors and external systems through ports and adapters.

Core isolation is covered by HEX-001, HEX-007, HEX-008, HEX-009, HEX-010, HEX-011, and HEX-012.

Inbound interaction through application-facing boundaries is covered by HEX-002 and HEX-003.

Outbound interaction through core-defined abstractions and external adapters is covered by HEX-004, HEX-005, and HEX-006.

Dependency direction toward the core is covered by HEX-007 and reinforced by HEX-001, HEX-004, HEX-005, HEX-006, HEX-008, HEX-009, HEX-010, and HEX-011.

Adapter responsibility is covered by HEX-003, HEX-005, HEX-008, HEX-009, HEX-010, and HEX-011.

Framework independence is covered by HEX-008.

Persistence as an external mechanism is covered by HEX-009.

Messaging as an adapter-mediated mechanism is covered by HEX-010.

Boundary contract purity is covered by HEX-006 and HEX-011.

Independent evaluation of core behavior is covered by HEX-012.

The coverage is suitable for a first official Hexagonal Architecture catalog. The main remaining gaps are catalog-level precision around adapter substitutability, multiple adapter use of the same core behavior, and composition or wiring boundaries, as related to HEX-002, HEX-003, HEX-004, HEX-005, HEX-006, HEX-007, HEX-008, HEX-009, HEX-010, and HEX-012.

# 7. Redundancy Analysis

No Rule is a full duplicate of another Rule.

HEX-001 and HEX-007 share concern around dependency direction, but HEX-001 is narrower and domain-focused while HEX-007 is broader and core-adapter-focused.

HEX-004, HEX-005, and HEX-006 share outbound boundary concerns, but each evaluates a different side of the boundary: core use of ports, adapter satisfaction of ports, and core ownership of ports.

HEX-007 overlaps with HEX-008, HEX-009, HEX-010, and HEX-011 because all specialized leakage concerns can also affect dependency direction. The specialized Rules remain justified because they evaluate distinct mechanisms rather than generic dependency direction.

HEX-009 and HEX-011 share persistence-related concerns when persistence models appear in core contracts. HEX-009 owns persistence mechanisms shaping core behavior, while HEX-011 owns adapter model leakage into core contract types.

HEX-010 and HEX-011 share messaging-related concerns when messaging models appear in core contracts. HEX-010 owns messaging mechanisms behind adapters, while HEX-011 owns adapter model leakage into core contract types.

HEX-012 reuses evidence that may also support HEX-003, HEX-004, HEX-005, HEX-007, HEX-008, HEX-009, and HEX-010, but its evaluated responsibility is distinct because it focuses on whether core behavior can be evaluated without adapters.

# 8. Quality Assessment

Clarity is strong across HEX-001 through HEX-012. The Rules use direct titles, concise intents, explicit applicability, and conservative evaluation guidance.

Objectivity is strong across HEX-001 through HEX-012. The Rules require concrete, traceable evidence and explicitly reject naming alone as conclusive evidence.

Consistency is strong across HEX-001 through HEX-012. The status vocabulary, confidence vocabulary, evidence hierarchy, evaluation outcomes, and severity patterns are consistently applied.

Reusability is strong across HEX-001 through HEX-012. The Rules are generic, project-neutral, and applicable across C#/.NET systems without depending on a specific framework or delivery mechanism.

Stability is strong across HEX-001 through HEX-012. The evaluated conditions are broad architectural conditions rather than project-specific observations or transient implementation details.

Independence is good across HEX-001 through HEX-012. The Rules are self-contained despite conceptual dependencies in HEX-006 through HEX-012.

The main quality risk is not the content of HEX-001 through HEX-012, but catalog hygiene around the additional `HEX-001` file outside the main catalog path. This affects uniqueness and automation-readiness for HEX-001.

# 9. Improvement Opportunities

- Clarify catalog hygiene for HEX-001 because an additional nonconforming `HEX-001` file exists outside the main catalog path.
- Clarify that Dependencies in HEX-006, HEX-007, HEX-008, HEX-009, HEX-010, HEX-011, and HEX-012 are conceptual dependencies and not procedural prerequisites for evaluation.
- Tighten wording alignment between the title and Rule Statement of HEX-011 so the evaluated condition reads with the same breadth in both places.
- Review whether adapter substitutability is sufficiently explicit through HEX-004, HEX-005, HEX-006, HEX-007, and HEX-012.
- Review whether multiple inbound adapters reaching the same core behavior without duplicated core behavior is sufficiently explicit through HEX-002 and HEX-003.
- Review whether composition or wiring boundaries are sufficiently explicit through HEX-007, HEX-008, HEX-009, HEX-010, and HEX-012.
- Maintain the current conservative evidence language across HEX-001 through HEX-012 because it is aligned with the evidence-driven operating principle.
- Preserve the current separation between generic dependency direction in HEX-007 and specialized leakage in HEX-008, HEX-009, HEX-010, and HEX-011.

# 10. Final Recommendation

The catalog is substantially ready to be frozen as a first official Hexagonal Architecture version, subject to resolving the catalog hygiene risk involving the additional nonconforming HEX-001 file outside the main catalog sequence.

HEX-001 through HEX-012 provide coherent, reusable, evidence-driven coverage of the central Hexagonal Architecture concerns: core isolation, ports, adapters, dependency direction, framework isolation, persistence isolation, messaging isolation, adapter model leakage, and independent evaluation of core behavior.

The Rules are generally atomic, independently evaluable, stable, and consistent with the Rule Model, Specification, Taxonomy, and ArchInspector evidence discipline.

The main risks before freezing are limited and identifiable: duplicate/nonconforming HEX-001 material, possible ambiguity around conceptual dependencies in HEX-006 through HEX-012, and minor wording alignment in HEX-011. These risks do not invalidate the catalog's architectural foundation, but they should be resolved before treating the catalog as a fully frozen official baseline.
