# ArchInspector Evaluation Scenario Catalog

## 1. Purpose

This catalog defines the ready Evaluation Suite scenarios for ArchInspector.

It defines which scenarios exist, which existing Rule each scenario validates, which architectural risk is covered, which outcomes are expected, which false-positive and false-negative protections are required, which internal and cross-catalog boundaries are evaluated, the implementation order, the Gold Standard scenario, and the current distribution of coverage across Rules and catalogs.

This catalog records the scenario suite state and does not create or alter Rules, code, scripts, commits, tags, or releases.

## 2. Catalog Identity

| Attribute | Value |
| --- | --- |
| Catalog Name | ArchInspector Evaluation Scenario Catalog |
| Evaluation Suite Version Context | `v0.6.0 - Evaluation Suite` |
| Scenario Catalog Status | `Defined` |
| Total Scenarios | `40` |
| Gold Standard Scenario | `EVAL-CORE-001` |
| Gold Standard Title | `Domain logic coupled to external infrastructure` |
| Scenario Status | `Ready` for every scenario |
| Concrete Scenario Files | `40 Ready` |
| Expected Result Files | `40 Match` |
| Reviews and Stabilizations | `Present` |

Core scenarios validate core ArchInspector review behavior such as evidence before conclusion, proportional remediation, legitimate absence, insufficient evidence, and architectural coupling. The repository does not define a `CORE-*` Rule prefix, so Core scenarios target existing Rules whose responsibilities exercise those core behaviors.

## 3. Scenario Design Principles

- Use only existing Rule IDs.
- Select exactly one Primary Rule per scenario.
- Use Supporting Rules only for shared evidence, boundary protection, non-findings, or full-review coverage.
- Preserve Rule ownership; supporting Rules do not own the primary outcome.
- Prefer `Not Enough Evidence` over speculation when implementation, dependency graph, execution output, or behavioral evidence is missing.
- Treat legitimate absence separately from insufficient evidence.
- Validate both required findings and forbidden findings.
- Validate confidence as a function of evidence strength, not naming or style preference.
- Validate severity as contextual impact, not a fixed value derived from Rule ID, catalog, technology, or scenario number.
- Avoid semantic duplication when the same evidence touches multiple catalogs.
- Keep scenario definitions at catalog level; implementation details belong to scenario files.

## 4. Scenario Metadata Model

Each scenario entry contains:

- Scenario ID
- Title
- Category
- Catalogs
- Primary Rule
- Supporting Rules
- Scenario Type
- Risk Level
- Execution Type
- Primary Outcome
- Secondary Outcomes
- Evidence Strength
- False Positive Guard
- False Negative Guard
- Boundary Focus
- Fixture Type
- Priority
- Implementation Order
- Status

## 5. Allowed Values

Scenario Type values:

`Positive Compliance`, `Confirmed Violation`, `Warning Condition`, `Legitimate Absence`, `Insufficient Evidence`, `False Positive Guard`, `False Negative Guard`, `Internal Boundary`, `Cross-Catalog Boundary`, `Multiple Findings`, `Conflicting Evidence`, `Partial Scope`, `Manual Validation`, `Automated Validation`, `Regression`, `Exception Governance`, `Determinism`, `Report Consistency`.

Risk Level values:

`Critical`, `High`, `Medium`, `Low`.

Execution Type values:

`Static Fixture`, `Executable Fixture`, `Document Fixture`, `Mixed Fixture`, `Manual Evaluation`.

Outcome values:

`Pass`, `Fail`, `Warning`, `Not Applicable`, `Not Enough Evidence`.

Confidence values covered across the catalog:

`Confirmed`, `Likely`, `Possible`, `Not Enough Evidence`.

Evidence Strength values:

`Strong`, `Partial`, `Nominal`, `Contradictory`, `Absent`.

Priority values:

`P0`, `P1`, `P2`, `P3`.

Status value for all scenarios in this catalog:

`Ready`.

## 6. Gold Standard Scenario

| Field | Value |
| --- | --- |
| Scenario ID | `EVAL-CORE-001` |
| Title | `Domain logic coupled to external infrastructure` |
| Category | Core |
| Catalogs | Core; Hexagonal Architecture; Clean Architecture |
| Primary Rule | `HEX-001` |
| Supporting Rules | `CLEAN-004`, `CLEAN-009`, `LAYER-001`, `LAYER-007`, `SOLID-001` |
| Scenario Type | Primary: `Confirmed Violation`; Secondary: `False Negative Guard`, `Cross-Catalog Boundary`, `Regression` |
| Risk Level | `High` |
| Execution Type | `Static Fixture` |
| Primary Outcome | `Fail` |
| Secondary Outcomes | `Warning` for neighboring responsibility ambiguity only when evidence is partial; forbidden duplicate `Fail` from supporting Rules without exclusive evidence |
| Evidence Strength | `Strong` |
| False Positive Guard | Do not report Clean, Layered, or SOLID findings unless evidence shows their exclusive responsibility beyond the domain-to-infrastructure dependency. |
| False Negative Guard | Direct dependency from domain logic to infrastructure must produce a finding under `HEX-001` even when folder names suggest a clean domain module. |
| Boundary Focus | Core x Hexagonal; Core x Clean; Hexagonal x Layered; shared evidence deduplication |
| Fixture Type | Minimal static code fixture with domain behavior referencing an infrastructure dependency |
| Priority | `P0` |
| Implementation Order | `1` |
| Status | `Ready` |

`EVAL-CORE-001` is the Gold Standard because `HEX-001` is the existing Rule that directly evaluates whether domain code depends on infrastructure. The scenario defines the structural and semantic standard for scenario definitions, expected results, findings, non-findings, evidence interpretation, remediation proportionality, confidence, severity, and boundary handling.

## 7. Core Scenarios

| Scenario ID | Title | Category | Catalogs | Primary Rule | Supporting Rules | Scenario Type | Risk Level | Execution Type | Primary Outcome | Secondary Outcomes | Evidence Strength | False Positive Guard | False Negative Guard | Boundary Focus | Fixture Type | Priority | Implementation Order | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `EVAL-CORE-001` | Domain logic coupled to external infrastructure | Core | Core; Hexagonal Architecture; Clean Architecture | `HEX-001` | `CLEAN-004`, `CLEAN-009`, `LAYER-001`, `LAYER-007`, `SOLID-001` | Primary: `Confirmed Violation`; Secondary: `False Negative Guard`, `Cross-Catalog Boundary`, `Regression` | `High` | `Static Fixture` | `Fail` | Required finding; proportional remediation; no duplicate neighboring findings without exclusive evidence | `Strong` | Do not convert every infrastructure mention into multiple catalog failures. | Detect direct domain-to-infrastructure dependency despite misleading naming. | Core x Hexagonal; Core x Clean | Static code fixture | `P0` | `1` | `Ready` |
| `EVAL-CORE-002` | Cohesive domain module with legitimate dependencies | Core | Core; Layered Architecture; DDD | `LAYER-002` | `DDD-002`, `DDD-006`, `DDD-012` | Primary: `Positive Compliance`; Secondary: `False Positive Guard`, `Internal Boundary` | `Medium` | `Static Fixture` | `Pass` | Absence of finding; confidence `Confirmed` or `Likely` depending fixture detail | `Strong` | Legitimate domain dependencies must not be reported as coupling violations. | Do not miss a hidden non-domain dependency if fixture later includes one. | Core x DDD; internal responsibility boundaries | Static code fixture | `P1` | `4` | `Ready` |
| `EVAL-CORE-003` | Architectural intent documented but implementation unavailable | Core | Core; Solution Architecture; Architecture Testing | `SOL-001` | `TEST-002`, `TEST-003`, `TEST-001` | Primary: `Insufficient Evidence`; Secondary: `Manual Validation`, `Partial Scope` | `Medium` | `Document Fixture` | `Not Enough Evidence` | Forbidden `Fail`; confidence `Not Enough Evidence` | `Nominal` | Documentation alone must not become confirmed compliance or violation. | Missing implementation must remain visible as review risk. | Core evidence boundary; document x implementation boundary | Document-only fixture | `P1` | `5` | `Ready` |
| `EVAL-CORE-004` | Small temporary component without formal modular constraints | Core | Core; Architecture Testing; Solution Architecture | `TEST-020` | `SOL-001`, `TEST-001`, `TEST-018` | Primary: `Legitimate Absence`; Secondary: `False Positive Guard`, `Manual Validation` | `Low` | `Static Fixture` | `Not Applicable` | `Pass` is acceptable only if selected Rule evidence shows deliberate lightweight validation | `Partial` | Do not require formal architecture tests, catalogs, or module constraints universally. | Do not let "temporary" hide a concrete high-impact violation. | Applicability boundary; proportionality | Lightweight document fixture | `P2` | `6` | `Ready` |

## 8. Hexagonal Architecture Scenarios

| Scenario ID | Title | Category | Catalogs | Primary Rule | Supporting Rules | Scenario Type | Risk Level | Execution Type | Primary Outcome | Secondary Outcomes | Evidence Strength | False Positive Guard | False Negative Guard | Boundary Focus | Fixture Type | Priority | Implementation Order | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `EVAL-HEX-001` | Core depends directly on a database adapter | Hexagonal Architecture | Hexagonal Architecture; Clean Architecture; Layered Architecture | `HEX-009` | `HEX-004`, `HEX-007`, `CLEAN-009` | Primary: `Confirmed Violation`; Secondary: `False Negative Guard`, `Cross-Catalog Boundary` | `High` | `Static Fixture` | `Fail` | Required finding; neighboring findings only with exclusive evidence | `Strong` | Do not duplicate the same dependency as every possible boundary failure. | Detect direct database adapter dependency from core. | inside/outside; Clean x Layered | Static code fixture | `P0` | `7` | `Ready` |
| `EVAL-HEX-002` | Multiple adapters implement the same application port | Hexagonal Architecture | Hexagonal Architecture | `HEX-005` | `HEX-004`, `HEX-006`, `HEX-007` | Primary: `Positive Compliance`; Secondary: `False Positive Guard`, `Internal Boundary` | `Medium` | `Static Fixture` | `Pass` | Absence of finding | `Strong` | Multiple adapters are legitimate when they implement the core-owned port. | Do not miss adapter leakage into the port contract. | Port x adapter substitutability | Static code fixture | `P1` | `8` | `Ready` |
| `EVAL-HEX-003` | Framework annotations present only in an inbound adapter | Hexagonal Architecture | Hexagonal Architecture; Clean Architecture | `HEX-008` | `HEX-002`, `HEX-003`, `CLEAN-006` | Primary: `False Positive Guard`; Secondary: `Positive Compliance`, `Internal Boundary` | `Medium` | `Static Fixture` | `Pass` | Forbidden core framework-leak finding | `Strong` | Framework usage in adapter code must not be treated as core leakage. | Do not miss framework types crossing into core if present. | inbound adapter x core | Static code fixture | `P1` | `9` | `Ready` |
| `EVAL-HEX-004` | Port exists only in documentation | Hexagonal Architecture | Hexagonal Architecture | `HEX-004` | `HEX-006`, `HEX-007`, `CLEAN-009` | Primary: `Insufficient Evidence`; Secondary: `False Negative Guard`, `Partial Scope` | `Medium` | `Document Fixture` | `Not Enough Evidence` | Forbidden confirmed conclusion | `Nominal` | Do not accept a documented port as implemented architecture. | Missing implementation must prevent false `Pass`. | nominal port evidence | Document-only fixture | `P1` | `10` | `Ready` |

## 9. Clean Architecture Scenarios

| Scenario ID | Title | Category | Catalogs | Primary Rule | Supporting Rules | Scenario Type | Risk Level | Execution Type | Primary Outcome | Secondary Outcomes | Evidence Strength | False Positive Guard | False Negative Guard | Boundary Focus | Fixture Type | Priority | Implementation Order | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `EVAL-CLEAN-001` | Use case exposes framework request and response types | Clean Architecture | Clean Architecture; Hexagonal Architecture | `CLEAN-001` | `CLEAN-004`, `CLEAN-011`, `HEX-008` | Primary: `Confirmed Violation`; Secondary: `False Negative Guard`, `Cross-Catalog Boundary` | `High` | `Static Fixture` | `Fail` | Required finding with `Confirmed` confidence | `Strong` | Do not also fail Hexagonal unless framework crosses the core boundary under Hexagonal evidence. | Detect framework type in use case boundary despite adapter names. | Clean x Hexagonal | Static code fixture | `P1` | `11` | `Ready` |
| `EVAL-CLEAN-002` | Interface adapter maps external models into use-case models | Clean Architecture | Clean Architecture | `CLEAN-006` | `CLEAN-001`, `CLEAN-004`, `CLEAN-011` | Primary: `Positive Compliance`; Secondary: `False Positive Guard`, `Internal Boundary` | `Medium` | `Static Fixture` | `Pass` | Absence of finding | `Strong` | Mapping code in an adapter is not a violation when it protects use-case boundaries. | Do not miss external DTO leakage into use cases. | adapter x use-case model | Static code fixture | `P1` | `12` | `Ready` |
| `EVAL-CLEAN-003` | Infrastructure implementation references domain contracts | Clean Architecture | Clean Architecture; Hexagonal Architecture; DDD | `CLEAN-009` | `CLEAN-002`, `CLEAN-012`, `HEX-005` | Primary: `False Positive Guard`; Secondary: `Positive Compliance`, `Cross-Catalog Boundary` | `Medium` | `Static Fixture` | `Pass` | No finding for correct outward implementation dependency | `Strong` | Infrastructure depending on domain-facing contracts is legitimate when direction is correct. | Do not miss contract definitions owned by infrastructure rather than inner policy. | Clean x Hexagonal x DDD | Static code fixture | `P1` | `13` | `Ready` |
| `EVAL-CLEAN-004` | Package names suggest layers but dependency graph is unavailable | Clean Architecture | Clean Architecture | `CLEAN-013` | `CLEAN-002`, `CLEAN-004`, `CLEAN-005` | Primary: `Insufficient Evidence`; Secondary: `Partial Scope`, `False Negative Guard` | `Medium` | `Document Fixture` | `Not Enough Evidence` | Forbidden `Fail` from naming alone | `Nominal` | Layer-like package names must not prove Clean Architecture conformance or violation. | Missing dependency graph must be called out. | naming x dependency evidence | Document fixture | `P2` | `14` | `Ready` |

## 10. DDD Scenarios

| Scenario ID | Title | Category | Catalogs | Primary Rule | Supporting Rules | Scenario Type | Risk Level | Execution Type | Primary Outcome | Secondary Outcomes | Evidence Strength | False Positive Guard | False Negative Guard | Boundary Focus | Fixture Type | Priority | Implementation Order | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `EVAL-DDD-001` | Entity uses primitive strings for validated domain concepts | DDD | DDD; Core | `DDD-001` | `DDD-012`, `DDD-013`, `DDD-006` | Primary: `Warning Condition`; Secondary: `Confirmed Violation`, `Internal Boundary` | `Medium` | `Static Fixture` | `Warning` | `Fail` allowed only if Rule evidence shows invariant loss is confirmed and material | `Partial` | Do not require Value Objects for every primitive. | Do not miss a primitive obsession risk when validation/invariants are demonstrably duplicated or absent. | DDD x Core | Static code fixture | `P1` | `15` | `Ready` |
| `EVAL-DDD-002` | Aggregate protects invariants through domain behavior | DDD | DDD | `DDD-004` | `DDD-005`, `DDD-012`, `DDD-010` | Primary: `Positive Compliance`; Secondary: `Internal Boundary` | `Medium` | `Static Fixture` | `Pass` | No finding | `Strong` | Encapsulated behavior must not be reported as overengineering. | Do not miss public mutation that bypasses aggregate invariants. | aggregate x invariant ownership | Static code fixture | `P1` | `16` | `Ready` |
| `EVAL-DDD-003` | Repository contract is defined inside the domain boundary | DDD | DDD; Hexagonal Architecture; Clean Architecture | `DDD-009` | `HEX-005`, `CLEAN-009`, `FOWLER-001` | Primary: `False Positive Guard`; Secondary: `Positive Compliance`, `Cross-Catalog Boundary` | `Medium` | `Static Fixture` | `Pass` | No finding for legitimate domain-facing repository contract | `Strong` | Repository contract inside domain is not automatically infrastructure leakage. | Do not miss storage-shaped APIs exposed as domain collections. | DDD x Hexagonal x Clean | Static code fixture | `P1` | `17` | `Ready` |
| `EVAL-DDD-004` | CRUD model without meaningful domain complexity | DDD | DDD; Fowler; Core | `DDD-013` | `DDD-001`, `DDD-004`, `FOWLER-002` | Primary: `Legitimate Absence`; Secondary: `False Positive Guard` | `Low` | `Static Fixture` | `Not Applicable` | `Pass` acceptable when Rule selected as satisfied within simple scope | `Partial` | Do not require tactical DDD universally. | Do not use CRUD simplicity to hide actual invariant loss if provided. | DDD x Fowler | Static code fixture | `P2` | `18` | `Ready` |

## 11. Layered Architecture Scenarios

| Scenario ID | Title | Category | Catalogs | Primary Rule | Supporting Rules | Scenario Type | Risk Level | Execution Type | Primary Outcome | Secondary Outcomes | Evidence Strength | False Positive Guard | False Negative Guard | Boundary Focus | Fixture Type | Priority | Implementation Order | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `EVAL-LAYER-001` | Presentation layer accesses persistence directly | Layered Architecture | Layered Architecture; Clean Architecture | `LAYER-008` | `LAYER-003`, `LAYER-004`, `LAYER-007` | Primary: `Confirmed Violation`; Secondary: `False Negative Guard`, `Internal Boundary` | `High` | `Static Fixture` | `Fail` | Required finding for bypass | `Strong` | Do not fail merely because presentation receives data through mediated contracts. | Detect direct persistence access that skips required mediation. | Clean x Layered | Static code fixture | `P1` | `19` | `Ready` |
| `EVAL-LAYER-002` | Application layer orchestrates domain and infrastructure contracts | Layered Architecture | Layered Architecture; Clean Architecture; Hexagonal Architecture | `LAYER-005` | `LAYER-002`, `LAYER-006`, `HEX-004` | Primary: `Positive Compliance`; Secondary: `False Positive Guard`, `Cross-Catalog Boundary` | `Medium` | `Static Fixture` | `Pass` | No finding | `Strong` | Orchestration is legitimate when business decisions remain in domain/business responsibility. | Do not miss application layer owning business rules. | Layered x Clean x Hexagonal | Static code fixture | `P1` | `20` | `Ready` |
| `EVAL-LAYER-003` | Shared utility referenced by multiple layers | Layered Architecture | Layered Architecture; Core | `LAYER-009` | `LAYER-002`, `LAYER-003`, `SOLID-001` | Primary: `Warning Condition`; Secondary: `False Positive Guard`, `Internal Boundary` | `Low` | `Static Fixture` | `Warning` | `Pass` allowed when utility is neutral and contracts are stable | `Partial` | Shared utility usage must not be automatic failure. | Do not miss utility becoming cross-layer business or infrastructure coupling. | shared evidence; internal layer contracts | Static code fixture | `P2` | `21` | `Ready` |
| `EVAL-LAYER-004` | Layer names exist without observable dependency information | Layered Architecture | Layered Architecture | `LAYER-002` | `LAYER-001`, `LAYER-003`, `LAYER-008` | Primary: `Insufficient Evidence`; Secondary: `Partial Scope` | `Medium` | `Document Fixture` | `Not Enough Evidence` | Forbidden confirmed layer-direction finding | `Nominal` | Do not infer conformance or violation from layer names alone. | Missing dependency evidence must stay visible. | nominal layer evidence | Document fixture | `P2` | `22` | `Ready` |

## 12. Fowler Scenarios

| Scenario ID | Title | Category | Catalogs | Primary Rule | Supporting Rules | Scenario Type | Risk Level | Execution Type | Primary Outcome | Secondary Outcomes | Evidence Strength | False Positive Guard | False Negative Guard | Boundary Focus | Fixture Type | Priority | Implementation Order | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `EVAL-FOWLER-001` | Complex business workflow implemented as procedural transaction script | Fowler | Fowler; DDD | `FOWLER-002` | `FOWLER-003`, `FOWLER-005`, `DDD-013` | Primary: `Warning Condition`; Secondary: `Conflicting Evidence`, `Cross-Catalog Boundary` | `Medium` | `Static Fixture` | `Warning` | `Fail` only if complexity evidence shows confirmed maintainability risk under the Rule | `Partial` | Do not treat Transaction Script as universally wrong. | Do not miss complexity that makes procedural organization risky. | DDD x Fowler | Static code fixture | `P1` | `23` | `Ready` |
| `EVAL-FOWLER-002` | Simple CRUD workflow implemented with Transaction Script | Fowler | Fowler; Core | `FOWLER-002` | `DDD-013`, `LAYER-005` | Primary: `Positive Compliance`; Secondary: `False Positive Guard`, `Legitimate Absence` | `Low` | `Static Fixture` | `Pass` | No Domain Model prescription | `Strong` | Simple CRUD transaction scripts must not be reported as DDD absence. | Do not miss procedural script accumulating complex domain rules. | Fowler x DDD absence | Static code fixture | `P1` | `24` | `Ready` |
| `EVAL-FOWLER-003` | Active Record contains persistence and domain behavior | Fowler | Fowler; DDD; Layered Architecture | `FOWLER-006` | `FOWLER-003`, `FOWLER-007`, `DDD-006` | Primary: `Warning Condition`; Secondary: `Internal Boundary`, `Cross-Catalog Boundary` | `Medium` | `Static Fixture` | `Warning` | `Pass` allowed in context; `Fail` only for pattern responsibility breakdown | `Partial` | Active Record is not automatically a violation. | Do not miss mixed responsibilities that contradict the selected pattern context. | Active Record x Data Mapper x Domain Model | Static code fixture | `P2` | `25` | `Ready` |
| `EVAL-FOWLER-004` | Pattern inferred only from class names | Fowler | Fowler | `FOWLER-003` | `FOWLER-001`, `FOWLER-005`, `FOWLER-006` | Primary: `Insufficient Evidence`; Secondary: `False Positive Guard`, `Partial Scope` | `Medium` | `Document Fixture` | `Not Enough Evidence` | Forbidden pattern finding from naming alone | `Nominal` | Class names such as Repository, Service, or Model are supporting evidence only. | Do not allow naming to mask real behavioral pattern evidence when later provided. | Fowler internal pattern boundaries | Document fixture | `P2` | `26` | `Ready` |

## 13. Events & Messaging Scenarios

| Scenario ID | Title | Category | Catalogs | Primary Rule | Supporting Rules | Scenario Type | Risk Level | Execution Type | Primary Outcome | Secondary Outcomes | Evidence Strength | False Positive Guard | False Negative Guard | Boundary Focus | Fixture Type | Priority | Implementation Order | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `EVAL-MSG-001` | Integration event published before transaction durability | Events & Messaging | Events & Messaging; Architecture Testing | `MSG-010` | `MSG-011`, `MSG-012`, `TEST-005` | Primary: `Confirmed Violation`; Secondary: `Warning Condition`, `Cross-Catalog Boundary` | `High` | `Mixed Fixture` | `Fail` | `Warning` allowed only if durability evidence is partial | `Strong` | Do not require Transactional Outbox when equivalent consistency evidence exists. | Detect publication-before-durability inconsistency. | Events x Architecture Testing | Mixed static/document fixture | `P1` | `27` | `Ready` |
| `EVAL-MSG-002` | Consumer handles duplicate delivery idempotently | Events & Messaging | Events & Messaging | `MSG-013` | `MSG-012`, `MSG-014`, `MSG-020` | Primary: `Positive Compliance`; Secondary: `False Positive Guard` | `Medium` | `Executable Fixture` | `Pass` | No finding for duplicate delivery risk | `Strong` | At-least-once delivery must not be reported as failure when idempotency is evidenced. | Do not miss duplicated side effects outside the idempotency guard. | delivery x consumer behavior | Executable fixture | `P1` | `28` | `Ready` |
| `EVAL-MSG-003` | Retry exists without dead-letter or terminal handling | Events & Messaging | Events & Messaging | `MSG-016` | `MSG-017`, `MSG-018`, `MSG-013` | Primary: `Warning Condition`; Secondary: `False Negative Guard`, `Internal Boundary` | `Medium` | `Static Fixture` | `Warning` | `Fail` only for confirmed operational risk with no terminal handling | `Partial` | Do not require a specific dead-letter technology. | Do not miss infinite retry or hidden poison-message risk. | retry x dead-letter x poison handling | Static code fixture | `P1` | `29` | `Ready` |
| `EVAL-MSG-004` | Event semantics documented without producer or consumer implementation | Events & Messaging | Events & Messaging; DDD | `MSG-006` | `MSG-001`, `DDD-011`, `EVENT-001` | Primary: `Insufficient Evidence`; Secondary: `Manual Validation`, `Partial Scope` | `Medium` | `Document Fixture` | `Not Enough Evidence` | Forbidden confirmed event-semantics finding | `Nominal` | Documentation-only semantics must not prove implementation behavior. | Missing producer/consumer evidence must be explicit. | DDD event meaning x messaging semantics | Document fixture | `P2` | `30` | `Ready` |

## 14. Architecture Testing Scenarios

| Scenario ID | Title | Category | Catalogs | Primary Rule | Supporting Rules | Scenario Type | Risk Level | Execution Type | Primary Outcome | Secondary Outcomes | Evidence Strength | False Positive Guard | False Negative Guard | Boundary Focus | Fixture Type | Priority | Implementation Order | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `EVAL-TEST-001` | Architecture test passes because its selection is empty | Architecture Testing | Architecture Testing | `TEST-013` | `TEST-004`, `TEST-010`, `TEST-005` | Primary: `False Negative Guard`; Secondary: `Confirmed Violation`, `Automated Validation` | `High` | `Executable Fixture` | `Fail` | Required finding for empty selection risk | `Strong` | Do not fail deliberately narrow non-empty selections. | Detect green result with empty or ineffective scope. | TEST-004 x TEST-013 | Executable fixture | `P1` | `31` | `Ready` |
| `EVAL-TEST-002` | Architecture test detects a forbidden dependency with actionable diagnostics | Architecture Testing | Architecture Testing | `TEST-015` | `TEST-005`, `TEST-006`, `TEST-018` | Primary: `Positive Compliance`; Secondary: `Automated Validation`, `Report Consistency` | `Medium` | `Executable Fixture` | `Pass` | Required diagnostics; no unsupported architecture conclusion | `Strong` | Tool output must not prove the underlying architecture beyond tested scope. | Do not miss weak diagnostics that make failures unactionable. | verification x diagnostic quality | Executable fixture | `P1` | `32` | `Ready` |
| `EVAL-TEST-003` | Architecture exception has owner, justification and expiration | Architecture Testing | Architecture Testing | `TEST-016` | `TEST-006`, `TEST-012`, `TEST-017` | Primary: `Exception Governance`; Secondary: `Positive Compliance`, `False Positive Guard` | `Medium` | `Document Fixture` | `Pass` | No universal suppression failure | `Partial` | Governed exceptions must not be treated as hidden violations. | Do not miss broad or expired exceptions that hide risk. | exception governance | Document fixture | `P1` | `33` | `Ready` |
| `EVAL-TEST-004` | Architecture rule exists but is never executed | Architecture Testing | Architecture Testing | `TEST-018` | `TEST-001`, `TEST-002`, `TEST-014` | Primary: `False Negative Guard`; Secondary: `Manual Validation`, `Automated Validation`, `Partial Scope` | `Medium` | `Mixed Fixture` | `Warning` | `Fail` only when risk and delivery expectations make non-execution confirmed impact | `Contradictory` | Do not require every architecture check in every pipeline. | Do not accept unexecuted checks as effective verification. | manual x automated validation | Mixed fixture | `P1` | `34` | `Ready` |

## 15. Cross-Catalog Scenarios

| Scenario ID | Title | Category | Catalogs | Primary Rule | Supporting Rules | Scenario Type | Risk Level | Execution Type | Primary Outcome | Secondary Outcomes | Evidence Strength | False Positive Guard | False Negative Guard | Boundary Focus | Fixture Type | Priority | Implementation Order | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `EVAL-CROSS-001` | Domain service directly depends on a database framework | Cross-Catalog | Core; Hexagonal Architecture; Clean Architecture; DDD; Layered Architecture | `HEX-001` | `CLEAN-004`, `LAYER-007`, `SOLID-001` | Primary: `Cross-Catalog Boundary`; Secondary: `Confirmed Violation`, `Multiple Findings` | `High` | `Static Fixture` | `Fail` | Distinct findings only for exclusive conclusions | `Strong` | Shared evidence must not create duplicate semantic findings. | Detect the core boundary violation even if service is named "DomainService". | Core x Hexagonal x Clean x DDD x Layered | Static code fixture | `P1` | `35` | `Ready` |
| `EVAL-CROSS-002` | Repository contract and implementation are separated correctly | Cross-Catalog | Hexagonal Architecture; Clean Architecture; DDD; Fowler; Layered Architecture | `FOWLER-001` | `DDD-009`, `HEX-004`, `CLEAN-009` | Primary: `Cross-Catalog Boundary`; Secondary: `Positive Compliance`, `False Positive Guard` | `Medium` | `Static Fixture` | `Pass` | No improper finding | `Strong` | Repository, gateway, mapper, and adapter concepts must retain separate meanings. | Do not miss implementation leakage into the contract. | Hexagonal x Clean x DDD x Fowler x Layered | Static code fixture | `P1` | `36` | `Ready` |
| `EVAL-CROSS-003` | Domain event is published directly by infrastructure code | Cross-Catalog | DDD; Events & Messaging; Hexagonal Architecture; Clean Architecture | `MSG-003` | `DDD-011`, `MSG-010`, `HEX-010` | Primary: `Cross-Catalog Boundary`; Secondary: `Warning Condition`, `Multiple Findings` | `Medium` | `Mixed Fixture` | `Warning` | `Fail` allowed only when direct ownership or consistency violation is confirmed | `Partial` | Do not duplicate event meaning, ownership, and publication mechanics as one finding. | Do not miss infrastructure ownership of domain-significant publication when evidenced. | DDD x Events x Hexagonal x Clean | Mixed fixture | `P1` | `37` | `Ready` |
| `EVAL-CROSS-004` | Architecture test validates a Clean Architecture dependency rule | Cross-Catalog | Clean Architecture; Architecture Testing | `TEST-005` | `CLEAN-004`, `TEST-015`, `TEST-018` | Primary: `Cross-Catalog Boundary`; Secondary: `Automated Validation`, `Report Consistency` | `Medium` | `Executable Fixture` | `Pass` | Clean rule evidence and test mechanism evidence stay separate | `Strong` | Passing architecture test must not become unsupported proof of complete Clean compliance. | Do not miss test scope mismatch that weakens the verification. | Clean x Architecture Testing | Executable fixture | `P1` | `38` | `Ready` |
| `EVAL-CROSS-005` | Layered monolith uses Transaction Script appropriately | Cross-Catalog | Layered Architecture; Fowler; Core | `FOWLER-002` | `LAYER-005`, `DDD-013`, `SOL-001` | Primary: `Cross-Catalog Boundary`; Secondary: `Positive Compliance`, `Legitimate Absence`, `False Positive Guard` | `Low` | `Static Fixture` | `Pass` | No DDD prescription; proportional report language | `Strong` | Do not treat absence of Domain Model as failure in simple layered CRUD context. | Do not miss layer bypass or accumulated business complexity if evidence appears. | Layered x Fowler x Core | Static code fixture | `P2` | `39` | `Ready` |
| `EVAL-CROSS-006` | Insufficient evidence across multiple architectural catalogs | Cross-Catalog | Core; Hexagonal Architecture; Clean Architecture; DDD; Layered Architecture; Fowler; Events & Messaging; Architecture Testing | `TEST-010` | `HEX-002`, `CLEAN-013`, `MSG-006` | Primary: `Insufficient Evidence`; Secondary: `Cross-Catalog Boundary`, `Report Consistency`, `Conflicting Evidence`, `Partial Scope` | `High` | `Document Fixture` | `Not Enough Evidence` | Multiple forbidden inferred `Fail` results | `Absent` | Naming and catalog labels must not create cross-catalog violations. | Do not hide missing implementation and dependency evidence. | Full cross-catalog insufficiency | Document fixture | `P1` | `40` | `Ready` |

## 16. Full Review Scenarios

| Scenario ID | Title | Category | Catalogs | Primary Rule | Supporting Rules | Scenario Type | Risk Level | Execution Type | Primary Outcome | Secondary Outcomes | Evidence Strength | False Positive Guard | False Negative Guard | Boundary Focus | Fixture Type | Priority | Implementation Order | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `EVAL-FULL-001` | Modular order-processing system with mixed compliance and violations | Full Review | Core; Hexagonal Architecture; Clean Architecture; DDD; Layered Architecture; Fowler; Events & Messaging; Architecture Testing; SOLID; Solution Architecture | `SOL-001` | `HEX-001`, `CLEAN-001`, `TEST-018` | Primary: `Multiple Findings`; Secondary: `Report Consistency`, `Determinism`, `Regression`, `Conflicting Evidence`, `Manual Validation`, `Automated Validation` | `Critical` | `Mixed Fixture` | `Warning` | Includes `Pass`, `Fail`, `Warning`, `Not Applicable`, and `Not Enough Evidence` across evaluated Rules | `Contradictory` | Do not duplicate findings across catalogs or overstate mixed evidence. | Do not miss separate findings hidden by shared root causes. | Full cross-catalog deduplication and report coherence | Mixed fixture | `P1` | `41` | `Ready` |
| `EVAL-FULL-002` | Small CRUD application with limited architectural evidence | Full Review | Core; Layered Architecture; Fowler; Architecture Testing; Solution Architecture | `TEST-020` | `SOL-001`, `FOWLER-002`, `TEST-019` | Primary: `Legitimate Absence`; Secondary: `Insufficient Evidence`, `False Positive Guard`, `Report Consistency`, `Manual Validation` | `Low` | `Mixed Fixture` | `Not Applicable` | Limited `Pass` and `Not Enough Evidence`; few findings | `Absent` | Do not overengineer a small CRUD system. | Do not miss a concrete violation simply because the system is small. | proportional full review | Mixed fixture | `P2` | `42` | `Ready` |

## 17. Scenario Catalog Matrix

| Scenario ID | Title | Catalogs | Primary Rule | Supporting Rules | Scenario Type | Primary Outcome | Evidence Strength | Execution Type | Priority | Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `EVAL-CORE-001` | Domain logic coupled to external infrastructure | Core; Hexagonal; Clean | `HEX-001` | `CLEAN-004`, `CLEAN-009`, `LAYER-001`, `LAYER-007`, `SOLID-001` | `Confirmed Violation`; `False Negative Guard`; `Cross-Catalog Boundary`; `Regression` | `Fail` | `Strong` | `Static Fixture` | `P0` | `Ready` |
| `EVAL-CORE-002` | Cohesive domain module with legitimate dependencies | Core; Layered; DDD | `LAYER-002` | `DDD-002`, `DDD-006`, `DDD-012` | `Positive Compliance`; `False Positive Guard`; `Internal Boundary` | `Pass` | `Strong` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-CORE-003` | Architectural intent documented but implementation unavailable | Core; Solution; Architecture Testing | `SOL-001` | `TEST-002`, `TEST-003`, `TEST-001` | `Insufficient Evidence`; `Manual Validation`; `Partial Scope` | `Not Enough Evidence` | `Nominal` | `Document Fixture` | `P1` | `Ready` |
| `EVAL-CORE-004` | Small temporary component without formal modular constraints | Core; Architecture Testing; Solution | `TEST-020` | `SOL-001`, `TEST-001`, `TEST-018` | `Legitimate Absence`; `False Positive Guard`; `Manual Validation` | `Not Applicable` | `Partial` | `Static Fixture` | `P2` | `Ready` |
| `EVAL-HEX-001` | Core depends directly on a database adapter | Hexagonal; Clean; Layered | `HEX-009` | `HEX-004`, `HEX-007`, `CLEAN-009` | `Confirmed Violation`; `False Negative Guard`; `Cross-Catalog Boundary` | `Fail` | `Strong` | `Static Fixture` | `P0` | `Ready` |
| `EVAL-HEX-002` | Multiple adapters implement the same application port | Hexagonal | `HEX-005` | `HEX-004`, `HEX-006`, `HEX-007` | `Positive Compliance`; `False Positive Guard`; `Internal Boundary` | `Pass` | `Strong` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-HEX-003` | Framework annotations present only in an inbound adapter | Hexagonal; Clean | `HEX-008` | `HEX-002`, `HEX-003`, `CLEAN-006` | `False Positive Guard`; `Positive Compliance`; `Internal Boundary` | `Pass` | `Strong` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-HEX-004` | Port exists only in documentation | Hexagonal | `HEX-004` | `HEX-006`, `HEX-007`, `CLEAN-009` | `Insufficient Evidence`; `False Negative Guard`; `Partial Scope` | `Not Enough Evidence` | `Nominal` | `Document Fixture` | `P1` | `Ready` |
| `EVAL-CLEAN-001` | Use case exposes framework request and response types | Clean; Hexagonal | `CLEAN-001` | `CLEAN-004`, `CLEAN-011`, `HEX-008` | `Confirmed Violation`; `False Negative Guard`; `Cross-Catalog Boundary` | `Fail` | `Strong` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-CLEAN-002` | Interface adapter maps external models into use-case models | Clean | `CLEAN-006` | `CLEAN-001`, `CLEAN-004`, `CLEAN-011` | `Positive Compliance`; `False Positive Guard`; `Internal Boundary` | `Pass` | `Strong` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-CLEAN-003` | Infrastructure implementation references domain contracts | Clean; Hexagonal; DDD | `CLEAN-009` | `CLEAN-002`, `CLEAN-012`, `HEX-005` | `False Positive Guard`; `Positive Compliance`; `Cross-Catalog Boundary` | `Pass` | `Strong` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-CLEAN-004` | Package names suggest layers but dependency graph is unavailable | Clean | `CLEAN-013` | `CLEAN-002`, `CLEAN-004`, `CLEAN-005` | `Insufficient Evidence`; `Partial Scope`; `False Negative Guard` | `Not Enough Evidence` | `Nominal` | `Document Fixture` | `P2` | `Ready` |
| `EVAL-DDD-001` | Entity uses primitive strings for validated domain concepts | DDD; Core | `DDD-001` | `DDD-012`, `DDD-013`, `DDD-006` | `Warning Condition`; `Confirmed Violation`; `Internal Boundary` | `Warning` | `Partial` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-DDD-002` | Aggregate protects invariants through domain behavior | DDD | `DDD-004` | `DDD-005`, `DDD-012`, `DDD-010` | `Positive Compliance`; `Internal Boundary` | `Pass` | `Strong` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-DDD-003` | Repository contract is defined inside the domain boundary | DDD; Hexagonal; Clean | `DDD-009` | `HEX-005`, `CLEAN-009`, `FOWLER-001` | `False Positive Guard`; `Positive Compliance`; `Cross-Catalog Boundary` | `Pass` | `Strong` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-DDD-004` | CRUD model without meaningful domain complexity | DDD; Fowler; Core | `DDD-013` | `DDD-001`, `DDD-004`, `FOWLER-002` | `Legitimate Absence`; `False Positive Guard` | `Not Applicable` | `Partial` | `Static Fixture` | `P2` | `Ready` |
| `EVAL-LAYER-001` | Presentation layer accesses persistence directly | Layered; Clean | `LAYER-008` | `LAYER-003`, `LAYER-004`, `LAYER-007` | `Confirmed Violation`; `False Negative Guard`; `Internal Boundary` | `Fail` | `Strong` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-LAYER-002` | Application layer orchestrates domain and infrastructure contracts | Layered; Clean; Hexagonal | `LAYER-005` | `LAYER-002`, `LAYER-006`, `HEX-004` | `Positive Compliance`; `False Positive Guard`; `Cross-Catalog Boundary` | `Pass` | `Strong` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-LAYER-003` | Shared utility referenced by multiple layers | Layered; Core | `LAYER-009` | `LAYER-002`, `LAYER-003`, `SOLID-001` | `Warning Condition`; `False Positive Guard`; `Internal Boundary` | `Warning` | `Partial` | `Static Fixture` | `P2` | `Ready` |
| `EVAL-LAYER-004` | Layer names exist without observable dependency information | Layered | `LAYER-002` | `LAYER-001`, `LAYER-003`, `LAYER-008` | `Insufficient Evidence`; `Partial Scope` | `Not Enough Evidence` | `Nominal` | `Document Fixture` | `P2` | `Ready` |
| `EVAL-FOWLER-001` | Complex business workflow implemented as procedural transaction script | Fowler; DDD | `FOWLER-002` | `FOWLER-003`, `FOWLER-005`, `DDD-013` | `Warning Condition`; `Conflicting Evidence`; `Cross-Catalog Boundary` | `Warning` | `Partial` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-FOWLER-002` | Simple CRUD workflow implemented with Transaction Script | Fowler; Core | `FOWLER-002` | `DDD-013`, `LAYER-005` | `Positive Compliance`; `False Positive Guard`; `Legitimate Absence` | `Pass` | `Strong` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-FOWLER-003` | Active Record contains persistence and domain behavior | Fowler; DDD; Layered | `FOWLER-006` | `FOWLER-003`, `FOWLER-007`, `DDD-006` | `Warning Condition`; `Internal Boundary`; `Cross-Catalog Boundary` | `Warning` | `Partial` | `Static Fixture` | `P2` | `Ready` |
| `EVAL-FOWLER-004` | Pattern inferred only from class names | Fowler | `FOWLER-003` | `FOWLER-001`, `FOWLER-005`, `FOWLER-006` | `Insufficient Evidence`; `False Positive Guard`; `Partial Scope` | `Not Enough Evidence` | `Nominal` | `Document Fixture` | `P2` | `Ready` |
| `EVAL-MSG-001` | Integration event published before transaction durability | Events; Testing | `MSG-010` | `MSG-011`, `MSG-012`, `TEST-005` | `Confirmed Violation`; `Warning Condition`; `Cross-Catalog Boundary` | `Fail` | `Strong` | `Mixed Fixture` | `P1` | `Ready` |
| `EVAL-MSG-002` | Consumer handles duplicate delivery idempotently | Events | `MSG-013` | `MSG-012`, `MSG-014`, `MSG-020` | `Positive Compliance`; `False Positive Guard` | `Pass` | `Strong` | `Executable Fixture` | `P1` | `Ready` |
| `EVAL-MSG-003` | Retry exists without dead-letter or terminal handling | Events | `MSG-016` | `MSG-017`, `MSG-018`, `MSG-013` | `Warning Condition`; `False Negative Guard`; `Internal Boundary` | `Warning` | `Partial` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-MSG-004` | Event semantics documented without producer or consumer implementation | Events; DDD | `MSG-006` | `MSG-001`, `DDD-011`, `EVENT-001` | `Insufficient Evidence`; `Manual Validation`; `Partial Scope` | `Not Enough Evidence` | `Nominal` | `Document Fixture` | `P2` | `Ready` |
| `EVAL-TEST-001` | Architecture test passes because its selection is empty | Architecture Testing | `TEST-013` | `TEST-004`, `TEST-010`, `TEST-005` | `False Negative Guard`; `Confirmed Violation`; `Automated Validation` | `Fail` | `Strong` | `Executable Fixture` | `P1` | `Ready` |
| `EVAL-TEST-002` | Architecture test detects a forbidden dependency with actionable diagnostics | Architecture Testing | `TEST-015` | `TEST-005`, `TEST-006`, `TEST-018` | `Positive Compliance`; `Automated Validation`; `Report Consistency` | `Pass` | `Strong` | `Executable Fixture` | `P1` | `Ready` |
| `EVAL-TEST-003` | Architecture exception has owner, justification and expiration | Architecture Testing | `TEST-016` | `TEST-006`, `TEST-012`, `TEST-017` | `Exception Governance`; `Positive Compliance`; `False Positive Guard` | `Pass` | `Partial` | `Document Fixture` | `P1` | `Ready` |
| `EVAL-TEST-004` | Architecture rule exists but is never executed | Architecture Testing | `TEST-018` | `TEST-001`, `TEST-002`, `TEST-014` | `False Negative Guard`; `Manual Validation`; `Automated Validation`; `Partial Scope` | `Warning` | `Contradictory` | `Mixed Fixture` | `P1` | `Ready` |
| `EVAL-CROSS-001` | Domain service directly depends on a database framework | Core; Hexagonal; Clean; DDD; Layered | `HEX-001` | `CLEAN-004`, `LAYER-007`, `SOLID-001` | `Cross-Catalog Boundary`; `Confirmed Violation`; `Multiple Findings` | `Fail` | `Strong` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-CROSS-002` | Repository contract and implementation are separated correctly | Hexagonal; Clean; DDD; Fowler; Layered | `FOWLER-001` | `DDD-009`, `HEX-004`, `CLEAN-009` | `Cross-Catalog Boundary`; `Positive Compliance`; `False Positive Guard` | `Pass` | `Strong` | `Static Fixture` | `P1` | `Ready` |
| `EVAL-CROSS-003` | Domain event is published directly by infrastructure code | DDD; Events; Hexagonal; Clean | `MSG-003` | `DDD-011`, `MSG-010`, `HEX-010` | `Cross-Catalog Boundary`; `Warning Condition`; `Multiple Findings` | `Warning` | `Partial` | `Mixed Fixture` | `P1` | `Ready` |
| `EVAL-CROSS-004` | Architecture test validates a Clean Architecture dependency rule | Clean; Architecture Testing | `TEST-005` | `CLEAN-004`, `TEST-015`, `TEST-018` | `Cross-Catalog Boundary`; `Automated Validation`; `Report Consistency` | `Pass` | `Strong` | `Executable Fixture` | `P1` | `Ready` |
| `EVAL-CROSS-005` | Layered monolith uses Transaction Script appropriately | Layered; Fowler; Core | `FOWLER-002` | `LAYER-005`, `DDD-013`, `SOL-001` | `Cross-Catalog Boundary`; `Positive Compliance`; `Legitimate Absence`; `False Positive Guard` | `Pass` | `Strong` | `Static Fixture` | `P2` | `Ready` |
| `EVAL-CROSS-006` | Insufficient evidence across multiple architectural catalogs | Core; Hexagonal; Clean; DDD; Layered; Fowler; Events; Testing | `TEST-010` | `HEX-002`, `CLEAN-013`, `MSG-006` | `Insufficient Evidence`; `Cross-Catalog Boundary`; `Report Consistency`; `Conflicting Evidence`; `Partial Scope` | `Not Enough Evidence` | `Absent` | `Document Fixture` | `P1` | `Ready` |
| `EVAL-FULL-001` | Modular order-processing system with mixed compliance and violations | All evaluation catalogs plus SOLID and Solution Architecture | `SOL-001` | `HEX-001`, `CLEAN-001`, `TEST-018` | `Multiple Findings`; `Report Consistency`; `Determinism`; `Regression`; `Conflicting Evidence`; `Manual Validation`; `Automated Validation` | `Warning` | `Contradictory` | `Mixed Fixture` | `P1` | `Ready` |
| `EVAL-FULL-002` | Small CRUD application with limited architectural evidence | Core; Layered; Fowler; Architecture Testing; Solution | `TEST-020` | `SOL-001`, `FOWLER-002`, `TEST-019` | `Legitimate Absence`; `Insufficient Evidence`; `False Positive Guard`; `Report Consistency`; `Manual Validation` | `Not Applicable` | `Absent` | `Mixed Fixture` | `P2` | `Ready` |

## 18. Rule Coverage Matrix

Every existing Rule is covered as Primary or Supporting. Rules not owned by the eight scenario-specific architectural catalogs are covered through Core, Cross-Catalog, or Full Review scenarios.

| Rule | Primary Scenarios | Supporting Scenarios | Positive | Violation | Warning | N/A | NEE | FP Guard | FN Guard | Boundary | Coverage Status |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `HEX-001` | `EVAL-CORE-001`, `EVAL-CROSS-001` | `EVAL-FULL-001` |  | Yes |  |  |  |  | Yes | Yes | `Covered` |
| `HEX-002` |  | `EVAL-HEX-003`, `EVAL-CROSS-006` |  |  |  |  | Yes | Yes | Yes | Yes | `Covered` |
| `HEX-003` |  | `EVAL-HEX-003` | Yes |  |  |  |  | Yes |  | Yes | `Partially Covered` |
| `HEX-004` | `EVAL-HEX-004` | `EVAL-HEX-001`, `EVAL-HEX-002`, `EVAL-LAYER-002`, `EVAL-CROSS-002` | Yes | Yes |  |  | Yes | Yes | Yes | Yes | `Covered` |
| `HEX-005` | `EVAL-HEX-002` | `EVAL-CLEAN-003`, `EVAL-DDD-003` | Yes | Yes |  |  |  | Yes | Yes | Yes | `Covered` |
| `HEX-006` |  | `EVAL-HEX-002`, `EVAL-HEX-004` | Yes |  |  |  | Yes | Yes |  | Yes | `Covered` |
| `HEX-007` |  | `EVAL-HEX-001`, `EVAL-HEX-002`, `EVAL-HEX-004` | Yes | Yes |  |  |  | Yes | Yes | Yes | `Covered` |
| `HEX-008` | `EVAL-HEX-003` | `EVAL-CLEAN-001` | Yes | Yes |  |  |  | Yes | Yes | Yes | `Covered` |
| `HEX-009` | `EVAL-HEX-001` |  |  | Yes |  |  |  |  | Yes | Yes | `Covered` |
| `HEX-010` |  | `EVAL-CROSS-003` |  |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `HEX-011` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `HEX-012` |  |  | Yes |  |  |  | Yes | Yes |  | Yes | `Covered` |
| `CLEAN-001` | `EVAL-CLEAN-001` | `EVAL-CLEAN-002`, `EVAL-FULL-001` | Yes | Yes |  |  |  | Yes | Yes | Yes | `Covered` |
| `CLEAN-002` |  | `EVAL-CLEAN-003`, `EVAL-CLEAN-004` | Yes |  |  |  | Yes | Yes |  | Yes | `Covered` |
| `CLEAN-003` |  |  |  |  | Yes |  | Yes | Yes |  | Yes | `Covered` |
| `CLEAN-004` |  | `EVAL-CORE-001`, `EVAL-CLEAN-001`, `EVAL-CLEAN-002`, `EVAL-CLEAN-004`, `EVAL-CROSS-001`, `EVAL-CROSS-004` | Yes | Yes |  |  | Yes | Yes | Yes | Yes | `Covered` |
| `CLEAN-005` |  | `EVAL-CLEAN-004` |  |  | Yes |  | Yes | Yes |  | Yes | `Covered` |
| `CLEAN-006` | `EVAL-CLEAN-002` | `EVAL-HEX-003` | Yes |  |  |  | Yes | Yes |  | Yes | `Covered` |
| `CLEAN-007` |  |  | Yes | Yes |  |  | Yes | Yes | Yes | Yes | `Covered` |
| `CLEAN-008` |  |  |  |  | Yes |  | Yes | Yes |  | Yes | `Covered` |
| `CLEAN-009` | `EVAL-CLEAN-003` | `EVAL-CORE-001`, `EVAL-HEX-001`, `EVAL-HEX-004`, `EVAL-DDD-003`, `EVAL-CROSS-002` | Yes | Yes |  |  |  | Yes | Yes | Yes | `Covered` |
| `CLEAN-010` |  |  | Yes |  |  |  |  | Yes |  | Yes | `Covered` |
| `CLEAN-011` |  | `EVAL-CLEAN-001`, `EVAL-CLEAN-002` | Yes | Yes |  |  |  | Yes | Yes | Yes | `Covered` |
| `CLEAN-012` |  | `EVAL-CLEAN-003` | Yes |  |  |  | Yes | Yes | Yes | Yes | `Covered` |
| `CLEAN-013` | `EVAL-CLEAN-004` | `EVAL-CROSS-006` |  |  |  |  | Yes | Yes | Yes | Yes | `Covered` |
| `DDD-001` | `EVAL-DDD-001` | `EVAL-DDD-004` |  |  | Yes | Yes |  | Yes | Yes | Yes | `Covered` |
| `DDD-002` |  | `EVAL-CORE-002` | Yes |  |  |  | Yes | Yes |  | Yes | `Covered` |
| `DDD-003` |  |  |  |  |  |  | Yes | Yes |  | Yes | `Covered` |
| `DDD-004` | `EVAL-DDD-002` | `EVAL-DDD-004` | Yes |  |  | Yes |  | Yes | Yes | Yes | `Covered` |
| `DDD-005` |  | `EVAL-DDD-002` | Yes |  |  |  |  | Yes |  | Yes | `Covered` |
| `DDD-006` |  | `EVAL-CORE-002`, `EVAL-DDD-001`, `EVAL-FOWLER-003` | Yes |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `DDD-007` |  |  |  | Yes |  | Yes |  | Yes | Yes | Yes | `Covered` |
| `DDD-008` |  |  |  |  | Yes | Yes |  | Yes | Yes | Yes | `Covered` |
| `DDD-009` | `EVAL-DDD-003` | `EVAL-CROSS-002` | Yes |  |  |  |  | Yes | Yes | Yes | `Covered` |
| `DDD-010` |  | `EVAL-DDD-002` | Yes |  |  |  |  | Yes |  | Yes | `Covered` |
| `DDD-011` |  | `EVAL-MSG-004`, `EVAL-CROSS-003` |  |  | Yes |  | Yes | Yes | Yes | Yes | `Covered` |
| `DDD-012` |  | `EVAL-CORE-002`, `EVAL-DDD-001`, `EVAL-DDD-002` | Yes |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `DDD-013` | `EVAL-DDD-004` | `EVAL-DDD-001`, `EVAL-FOWLER-001`, `EVAL-FOWLER-002`, `EVAL-CROSS-005` | Yes |  | Yes | Yes |  | Yes | Yes | Yes | `Covered` |
| `DDD-014` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `DDD-015` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `DDD-016` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `DDD-017` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `DDD-018` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `DDD-019` |  |  |  | Yes |  |  |  | Yes | Yes | Yes | `Covered` |
| `LAYER-001` |  | `EVAL-CORE-001`, `EVAL-LAYER-004` |  | Yes |  |  | Yes | Yes | Yes | Yes | `Covered` |
| `LAYER-002` | `EVAL-CORE-002`, `EVAL-LAYER-004` | `EVAL-LAYER-002`, `EVAL-LAYER-003` | Yes |  | Yes | Yes | Yes | Yes | Yes | Yes | `Covered` |
| `LAYER-003` |  | `EVAL-LAYER-001`, `EVAL-LAYER-003`, `EVAL-LAYER-004` | Yes | Yes | Yes |  | Yes | Yes | Yes | Yes | `Covered` |
| `LAYER-004` |  | `EVAL-LAYER-001` |  | Yes |  |  | Yes | Yes | Yes | Yes | `Covered` |
| `LAYER-005` | `EVAL-LAYER-002` | `EVAL-FOWLER-002`, `EVAL-CROSS-005` | Yes | Yes |  | Yes | Yes | Yes | Yes | Yes | `Covered` |
| `LAYER-006` |  | `EVAL-LAYER-002` | Yes |  | Yes | Yes | Yes | Yes | Yes | Yes | `Covered` |
| `LAYER-007` |  | `EVAL-CORE-001`, `EVAL-LAYER-001`, `EVAL-CROSS-001` | Yes | Yes |  |  |  | Yes | Yes | Yes | `Covered` |
| `LAYER-008` | `EVAL-LAYER-001` | `EVAL-LAYER-004` |  | Yes |  |  | Yes | Yes | Yes | Yes | `Covered` |
| `LAYER-009` | `EVAL-LAYER-003` |  |  |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `FOWLER-001` | `EVAL-CROSS-002` | `EVAL-DDD-003`, `EVAL-FOWLER-004` | Yes |  |  |  | Yes | Yes | Yes | Yes | `Covered` |
| `FOWLER-002` | `EVAL-FOWLER-001`, `EVAL-FOWLER-002`, `EVAL-CROSS-005` | `EVAL-DDD-004`, `EVAL-FULL-002` | Yes |  | Yes | Yes |  | Yes | Yes | Yes | `Covered` |
| `FOWLER-003` | `EVAL-FOWLER-004` | `EVAL-FOWLER-001`, `EVAL-FOWLER-003` |  |  | Yes |  | Yes | Yes | Yes | Yes | `Covered` |
| `FOWLER-004` |  |  |  |  |  |  | Yes | Yes |  | Yes | `Covered` |
| `FOWLER-005` |  | `EVAL-FOWLER-001`, `EVAL-FOWLER-004` |  |  | Yes |  | Yes | Yes | Yes | Yes | `Covered` |
| `FOWLER-006` | `EVAL-FOWLER-003` | `EVAL-FOWLER-004` |  |  | Yes |  | Yes | Yes | Yes | Yes | `Covered` |
| `FOWLER-007` |  | `EVAL-FOWLER-003` | Yes |  | Yes |  | Yes | Yes | Yes | Yes | `Covered` |
| `FOWLER-008` |  |  |  |  |  |  | Yes | Yes |  | Yes | `Covered` |
| `FOWLER-009` |  |  |  |  |  |  | Yes | Yes |  | Yes | `Covered` |
| `FOWLER-010` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `FOWLER-011` |  |  | Yes |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `FOWLER-012` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `FOWLER-013` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `FOWLER-014` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `FOWLER-015` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `FOWLER-016` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `FOWLER-017` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `FOWLER-018` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `FOWLER-019` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `FOWLER-020` |  |  |  |  |  |  | Yes | Yes |  | Yes | `Covered` |
| `MSG-001` |  | `EVAL-MSG-004` |  |  | Yes |  | Yes | Yes | Yes | Yes | `Covered` |
| `MSG-002` |  |  |  |  | Yes |  | Yes | Yes | Yes | Yes | `Covered` |
| `MSG-003` | `EVAL-CROSS-003` |  |  |  | Yes |  | Yes | Yes | Yes | Yes | `Covered` |
| `MSG-004` |  |  |  |  |  |  | Yes | Yes |  | Yes | `Covered` |
| `MSG-005` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `MSG-006` | `EVAL-MSG-004` | `EVAL-CROSS-006` |  |  |  |  | Yes | Yes | Yes | Yes | `Covered` |
| `MSG-007` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `MSG-008` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `MSG-009` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `MSG-010` | `EVAL-MSG-001` | `EVAL-CROSS-003` |  | Yes | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `MSG-011` |  | `EVAL-MSG-001` |  | Yes |  |  |  | Yes | Yes | Yes | `Covered` |
| `MSG-012` |  | `EVAL-MSG-001`, `EVAL-MSG-002` | Yes | Yes | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `MSG-013` | `EVAL-MSG-002` | `EVAL-MSG-003` | Yes |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `MSG-014` |  | `EVAL-MSG-002` | Yes |  |  |  |  | Yes | Yes | Yes | `Covered` |
| `MSG-015` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `MSG-016` | `EVAL-MSG-003` |  |  |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `MSG-017` |  | `EVAL-MSG-003` |  |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `MSG-018` |  | `EVAL-MSG-003` |  |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `MSG-019` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `MSG-020` |  | `EVAL-MSG-002` | Yes | Yes |  |  |  | Yes | Yes | Yes | `Covered` |
| `TEST-001` |  | `EVAL-CORE-003`, `EVAL-CORE-004`, `EVAL-TEST-004` |  |  | Yes | Yes | Yes | Yes | Yes | Yes | `Covered` |
| `TEST-002` |  | `EVAL-CORE-003`, `EVAL-TEST-004` |  |  | Yes |  | Yes | Yes | Yes | Yes | `Covered` |
| `TEST-003` |  | `EVAL-CORE-003` |  |  |  |  | Yes | Yes | Yes | Yes | `Covered` |
| `TEST-004` |  | `EVAL-TEST-001` | Yes | Yes |  |  |  | Yes | Yes | Yes | `Covered` |
| `TEST-005` | `EVAL-CROSS-004` | `EVAL-MSG-001`, `EVAL-TEST-001`, `EVAL-TEST-002` | Yes | Yes |  |  |  | Yes | Yes | Yes | `Covered` |
| `TEST-006` |  | `EVAL-TEST-002`, `EVAL-TEST-003` | Yes |  |  |  |  | Yes | Yes | Yes | `Covered` |
| `TEST-007` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `TEST-008` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `TEST-009` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `TEST-010` | `EVAL-CROSS-006` | `EVAL-TEST-001` |  | Yes |  |  | Yes | Yes | Yes | Yes | `Covered` |
| `TEST-011` |  |  |  |  | Yes |  |  | Yes | Yes | Yes | `Partially Covered` |
| `TEST-012` |  | `EVAL-TEST-003` | Yes |  |  |  |  | Yes | Yes | Yes | `Covered` |
| `TEST-013` | `EVAL-TEST-001` |  |  | Yes |  |  |  | Yes | Yes | Yes | `Covered` |
| `TEST-014` |  | `EVAL-TEST-004` |  |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `TEST-015` | `EVAL-TEST-002` | `EVAL-CROSS-004` | Yes |  |  |  |  | Yes | Yes | Yes | `Covered` |
| `TEST-016` | `EVAL-TEST-003` |  | Yes |  |  |  |  | Yes | Yes | Yes | `Covered` |
| `TEST-017` |  | `EVAL-TEST-003` | Yes |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `TEST-018` | `EVAL-TEST-004` | `EVAL-CORE-004`, `EVAL-TEST-002`, `EVAL-CROSS-004`, `EVAL-FULL-001` | Yes |  | Yes | Yes |  | Yes | Yes | Yes | `Covered` |
| `TEST-019` |  | `EVAL-FULL-002` | Yes |  | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `TEST-020` | `EVAL-CORE-004`, `EVAL-FULL-002` |  |  |  | Yes | Yes | Yes | Yes | Yes | Yes | `Covered` |
| `SOLID-001` |  | `EVAL-CORE-001`, `EVAL-LAYER-003`, `EVAL-CROSS-001` | Yes | Yes | Yes |  |  | Yes | Yes | Yes | `Covered` |
| `SOL-001` | `EVAL-CORE-003`, `EVAL-FULL-001` | `EVAL-CORE-004`, `EVAL-CROSS-005`, `EVAL-FULL-002` | Yes |  | Yes | Yes | Yes | Yes | Yes | Yes | `Covered` |
| `EVENT-001` |  | `EVAL-MSG-004` |  |  | Yes |  | Yes | Yes | Yes | Yes | `Covered` |

## 19. Catalog Coverage Matrix

| Catalog | Scenario Range | Dedicated Scenarios | Cross-Catalog Scenarios | Full Review Scenarios | Coverage Status |
| --- | --- | --- | --- | --- | --- |
| Core | `EVAL-CORE-001` to `EVAL-CORE-004` | 4 | `EVAL-CROSS-001`, `EVAL-CROSS-005`, `EVAL-CROSS-006` | `EVAL-FULL-001`, `EVAL-FULL-002` | `Covered` |
| Hexagonal Architecture | `EVAL-HEX-001` to `EVAL-HEX-004` | 4 | `EVAL-CROSS-001`, `EVAL-CROSS-002`, `EVAL-CROSS-003`, `EVAL-CROSS-006` | `EVAL-FULL-001` | `Covered` |
| Clean Architecture | `EVAL-CLEAN-001` to `EVAL-CLEAN-004` | 4 | `EVAL-CROSS-001`, `EVAL-CROSS-002`, `EVAL-CROSS-003`, `EVAL-CROSS-004`, `EVAL-CROSS-006` | `EVAL-FULL-001` | `Covered` |
| DDD | `EVAL-DDD-001` to `EVAL-DDD-004` | 4 | `EVAL-CROSS-001`, `EVAL-CROSS-002`, `EVAL-CROSS-003`, `EVAL-CROSS-006` | `EVAL-FULL-001`, `EVAL-FULL-002` | `Covered` |
| Layered Architecture | `EVAL-LAYER-001` to `EVAL-LAYER-004` | 4 | `EVAL-CROSS-001`, `EVAL-CROSS-002`, `EVAL-CROSS-005`, `EVAL-CROSS-006` | `EVAL-FULL-001`, `EVAL-FULL-002` | `Covered` |
| Fowler | `EVAL-FOWLER-001` to `EVAL-FOWLER-004` | 4 | `EVAL-CROSS-002`, `EVAL-CROSS-005`, `EVAL-CROSS-006` | `EVAL-FULL-001`, `EVAL-FULL-002` | `Covered` |
| Events & Messaging | `EVAL-MSG-001` to `EVAL-MSG-004` | 4 | `EVAL-CROSS-003`, `EVAL-CROSS-006` | `EVAL-FULL-001` | `Covered` |
| Architecture Testing | `EVAL-TEST-001` to `EVAL-TEST-004` | 4 | `EVAL-CROSS-004`, `EVAL-CROSS-006` | `EVAL-FULL-001`, `EVAL-FULL-002` | `Covered` |
| SOLID | Covered through Core/Cross/Full support | 0 | `EVAL-CROSS-001` | `EVAL-FULL-001`, `EVAL-FULL-002` | `Partially Covered` |
| Solution Architecture | Covered through Core/Cross/Full support | 0 | `EVAL-CROSS-005`, `EVAL-CROSS-006` | `EVAL-FULL-001`, `EVAL-FULL-002` | `Partially Covered` |

## 20. Outcome Coverage Matrix

| Outcome | Scenarios | Coverage Status |
| --- | --- | --- |
| `Pass` | `EVAL-CORE-002`, `EVAL-HEX-002`, `EVAL-HEX-003`, `EVAL-CLEAN-002`, `EVAL-CLEAN-003`, `EVAL-DDD-002`, `EVAL-DDD-003`, `EVAL-LAYER-002`, `EVAL-FOWLER-002`, `EVAL-MSG-002`, `EVAL-TEST-002`, `EVAL-TEST-003`, `EVAL-CROSS-002`, `EVAL-CROSS-004`, `EVAL-CROSS-005` | `Covered` |
| `Fail` | `EVAL-CORE-001`, `EVAL-HEX-001`, `EVAL-CLEAN-001`, `EVAL-LAYER-001`, `EVAL-MSG-001`, `EVAL-TEST-001`, `EVAL-CROSS-001` | `Covered` |
| `Warning` | `EVAL-DDD-001`, `EVAL-LAYER-003`, `EVAL-FOWLER-001`, `EVAL-FOWLER-003`, `EVAL-MSG-003`, `EVAL-TEST-004`, `EVAL-CROSS-003`, `EVAL-FULL-001` | `Covered` |
| `Not Applicable` | `EVAL-CORE-004`, `EVAL-DDD-004`, `EVAL-FULL-002` | `Covered` |
| `Not Enough Evidence` | `EVAL-CORE-003`, `EVAL-HEX-004`, `EVAL-CLEAN-004`, `EVAL-LAYER-004`, `EVAL-FOWLER-004`, `EVAL-MSG-004`, `EVAL-CROSS-006` | `Covered` |

## 21. Confidence Coverage Matrix

| Confidence | Scenarios | Expected Interpretation | Coverage Status |
| --- | --- | --- | --- |
| `Confirmed` | `EVAL-CORE-001`, `EVAL-HEX-001`, `EVAL-CLEAN-001`, `EVAL-LAYER-001`, `EVAL-MSG-001`, `EVAL-TEST-001` | Direct structural, behavioral, dependency, or execution evidence supports the conclusion. | `Covered` |
| `Likely` | `EVAL-CORE-002`, `EVAL-CLEAN-003`, `EVAL-DDD-002`, `EVAL-DDD-003`, `EVAL-LAYER-002`, `EVAL-MSG-002`, `EVAL-CROSS-002` | Multiple consistent evidence points support the result while still respecting scope. | `Covered` |
| `Possible` | `EVAL-DDD-001`, `EVAL-LAYER-003`, `EVAL-FOWLER-001`, `EVAL-FOWLER-003`, `EVAL-MSG-003`, `EVAL-CROSS-003` | Partial, mixed, or contextual evidence supports a warning or constrained conclusion. | `Covered` |
| `Not Enough Evidence` | `EVAL-CORE-003`, `EVAL-HEX-004`, `EVAL-CLEAN-004`, `EVAL-LAYER-004`, `EVAL-FOWLER-004`, `EVAL-MSG-004`, `EVAL-CROSS-006` | Evidence is missing, nominal, absent, or too narrow to support another confidence level. | `Covered` |

## 22. Severity Coverage Matrix

| Severity Range | Scenarios | Expected Interpretation | Coverage Status |
| --- | --- | --- | --- |
| `Critical` | `EVAL-FULL-001` | Broad multi-catalog impact, multiple findings, mixed evidence, and report-level risk. | `Covered` |
| `High` | `EVAL-CORE-001`, `EVAL-HEX-001`, `EVAL-CLEAN-001`, `EVAL-LAYER-001`, `EVAL-MSG-001`, `EVAL-TEST-001`, `EVAL-CROSS-001`, `EVAL-CROSS-006` | Confirmed or high-impact boundary, consistency, false-negative, or evidence-risk conditions. | `Covered` |
| `Medium` | `EVAL-CORE-002`, `EVAL-CORE-003`, `EVAL-HEX-002`, `EVAL-HEX-003`, `EVAL-HEX-004`, `EVAL-DDD-001`, `EVAL-FOWLER-001`, `EVAL-MSG-003`, `EVAL-TEST-004` | Important but scoped architectural concerns, warnings, or insufficient evidence with material review impact. | `Covered` |
| `Low` | `EVAL-CORE-004`, `EVAL-DDD-004`, `EVAL-LAYER-003`, `EVAL-FOWLER-002`, `EVAL-CROSS-005`, `EVAL-FULL-002` | Simple, local, legitimate absence, or proportionality-focused situations. | `Covered` |

## 23. Evidence Coverage Matrix

| Evidence Strength | Scenarios | Expected Interpretation | Coverage Status |
| --- | --- | --- | --- |
| `Strong` | `EVAL-CORE-001`, `EVAL-CORE-002`, `EVAL-HEX-001`, `EVAL-HEX-002`, `EVAL-HEX-003`, `EVAL-CLEAN-001`, `EVAL-CLEAN-002`, `EVAL-CLEAN-003`, `EVAL-DDD-002`, `EVAL-DDD-003`, `EVAL-LAYER-001`, `EVAL-LAYER-002`, `EVAL-FOWLER-002`, `EVAL-MSG-001`, `EVAL-MSG-002`, `EVAL-TEST-001`, `EVAL-TEST-002`, `EVAL-CROSS-001`, `EVAL-CROSS-002`, `EVAL-CROSS-004`, `EVAL-CROSS-005` | Direct evidence can support `Confirmed`, `Pass`, or `Fail` when applicability is established. | `Covered` |
| `Partial` | `EVAL-CORE-004`, `EVAL-DDD-001`, `EVAL-DDD-004`, `EVAL-LAYER-003`, `EVAL-FOWLER-001`, `EVAL-FOWLER-003`, `EVAL-MSG-003`, `EVAL-TEST-003`, `EVAL-CROSS-003` | Partial evidence supports warning, constrained pass, or legitimate absence without overstatement. | `Covered` |
| `Nominal` | `EVAL-CORE-003`, `EVAL-HEX-004`, `EVAL-CLEAN-004`, `EVAL-LAYER-004`, `EVAL-FOWLER-004`, `EVAL-MSG-004` | Naming or documentation can support scope discussion but not confirmed conclusions. | `Covered` |
| `Contradictory` | `EVAL-TEST-004`, `EVAL-FULL-001` | Conflicting evidence constrains confidence, outcome, and report language. | `Covered` |
| `Absent` | `EVAL-CROSS-006`, `EVAL-FULL-002` | Absence of necessary evidence must produce `Not Enough Evidence`, `Not Applicable`, or explicit unknowns. | `Covered` |

## 24. False Positive Coverage Matrix

| Guard Area | Scenarios | Forbidden Finding Pattern | Coverage Status |
| --- | --- | --- | --- |
| Legitimate dependency | `EVAL-CORE-002`, `EVAL-CLEAN-003`, `EVAL-DDD-003`, `EVAL-LAYER-002` | Treating correct inward or boundary-preserving dependencies as violations. | `Covered` |
| Adapter/framework placement | `EVAL-HEX-003`, `EVAL-CLEAN-002` | Treating adapter-local framework or mapping code as core leakage. | `Covered` |
| Legitimate absence | `EVAL-CORE-004`, `EVAL-DDD-004`, `EVAL-FOWLER-002`, `EVAL-FULL-002` | Requiring formalism, DDD, architecture tests, or rich patterns universally. | `Covered` |
| Naming-only evidence | `EVAL-CLEAN-004`, `EVAL-LAYER-004`, `EVAL-FOWLER-004`, `EVAL-CROSS-006` | Converting names, folders, or documentation labels into confirmed findings. | `Covered` |
| Governed exception | `EVAL-TEST-003` | Treating every suppression or exception as a failure. | `Covered` |
| Cross-catalog duplication | `EVAL-CROSS-001` through `EVAL-CROSS-006`, `EVAL-FULL-001` | Duplicating the same evidence as multiple semantically identical findings. | `Covered` |

## 25. False Negative Coverage Matrix

| Guard Area | Scenarios | Required Detection Pattern | Coverage Status |
| --- | --- | --- | --- |
| Hidden dependency violation | `EVAL-CORE-001`, `EVAL-HEX-001`, `EVAL-CLEAN-001`, `EVAL-CROSS-001` | Direct dependency or boundary crossing must produce the owner Rule finding. | `Covered` |
| Missing implementation behind documentation | `EVAL-CORE-003`, `EVAL-HEX-004`, `EVAL-MSG-004`, `EVAL-CROSS-006` | Missing evidence must not be reported as compliance. | `Covered` |
| Empty or incomplete verification | `EVAL-TEST-001`, `EVAL-TEST-004`, `EVAL-CROSS-004` | Green or present tests must not hide empty scope, weak selection, or non-execution. | `Covered` |
| Operational messaging risk | `EVAL-MSG-001`, `EVAL-MSG-003` | Publication consistency and retry terminal handling risks must remain visible. | `Covered` |
| Contextual complexity | `EVAL-DDD-001`, `EVAL-FOWLER-001`, `EVAL-FOWLER-003` | Ambiguous design shape must not hide real invariant or complexity risk. | `Covered` |
| Report-level drift | `EVAL-FULL-001`, `EVAL-FULL-002` | Full review must not omit required findings, unknowns, or proportionality constraints. | `Covered` |

## 26. Boundary Coverage Matrix

| Boundary | Scenarios | Expected Separation | Coverage Status |
| --- | --- | --- | --- |
| Core x Hexagonal | `EVAL-CORE-001`, `EVAL-CROSS-001` | Core review behavior uses `HEX-001` without inventing Core Rule IDs. | `Covered` |
| Core x Clean | `EVAL-CORE-001`, `EVAL-CROSS-001` | Core coupling evidence and Clean use-case evidence remain distinct. | `Covered` |
| Core x DDD | `EVAL-CORE-002`, `EVAL-DDD-001`, `EVAL-CROSS-005` | Cohesion, domain language, and tactical DDD responsibilities remain separate. | `Covered` |
| Hexagonal x Clean | `EVAL-HEX-001`, `EVAL-CLEAN-001`, `EVAL-CROSS-004` | Ports/adapters and Clean policy boundaries keep separate ownership. | `Covered` |
| Hexagonal x DDD | `EVAL-DDD-003`, `EVAL-CROSS-002`, `EVAL-CROSS-003` | Domain-facing contracts and adapter boundaries are not conflated. | `Covered` |
| Hexagonal x Layered | `EVAL-HEX-001`, `EVAL-LAYER-002`, `EVAL-CROSS-001` | Inside/outside boundaries and layered responsibilities remain distinct. | `Covered` |
| Clean x DDD | `EVAL-CLEAN-003`, `EVAL-DDD-003`, `EVAL-CROSS-003` | Use-case boundaries and domain model meaning remain distinct. | `Covered` |
| Clean x Layered | `EVAL-LAYER-001`, `EVAL-LAYER-002`, `EVAL-CROSS-001` | Clean policy direction and declared layer mediation remain distinct. | `Covered` |
| DDD x Fowler | `EVAL-DDD-004`, `EVAL-FOWLER-001`, `EVAL-FOWLER-002`, `EVAL-CROSS-005` | Domain Model expectations and Fowler pattern applicability are contextual. | `Covered` |
| DDD x Events & Messaging | `EVAL-MSG-004`, `EVAL-CROSS-003` | Domain event meaning and messaging publication/ownership remain separate. | `Covered` |
| Layered x Fowler | `EVAL-FOWLER-002`, `EVAL-CROSS-005` | Layered monolith structure and Transaction Script pattern suitability remain distinct. | `Covered` |
| Events & Messaging x Architecture Testing | `EVAL-MSG-001`, `EVAL-CROSS-004` | Messaging risk and validation mechanism quality remain separate. | `Covered` |
| Clean x Architecture Testing | `EVAL-CROSS-004`, `EVAL-TEST-002` | Clean dependency condition and architecture-test mechanism are evaluated independently. | `Covered` |
| Internal Rule Boundaries | `EVAL-HEX-002`, `EVAL-CLEAN-002`, `EVAL-DDD-002`, `EVAL-LAYER-003`, `EVAL-FOWLER-004`, `EVAL-MSG-003`, `EVAL-TEST-001` | Adjacent Rules share evidence without absorbing each other's responsibility. | `Covered` |
| Full Cross-Catalog Deduplication | `EVAL-CROSS-001` through `EVAL-CROSS-006`, `EVAL-FULL-001` | Shared evidence produces distinct findings only when conclusions are exclusive. | `Covered` |

## 27. Execution Type Coverage Matrix

| Execution Type | Scenarios | Coverage Status |
| --- | --- | --- |
| `Static Fixture` | `EVAL-CORE-001`, `EVAL-CORE-002`, `EVAL-CORE-004`, `EVAL-HEX-001`, `EVAL-HEX-002`, `EVAL-HEX-003`, `EVAL-CLEAN-001`, `EVAL-CLEAN-002`, `EVAL-CLEAN-003`, `EVAL-DDD-001`, `EVAL-DDD-002`, `EVAL-DDD-003`, `EVAL-DDD-004`, `EVAL-LAYER-001`, `EVAL-LAYER-002`, `EVAL-LAYER-003`, `EVAL-FOWLER-001`, `EVAL-FOWLER-002`, `EVAL-FOWLER-003`, `EVAL-MSG-003`, `EVAL-CROSS-001`, `EVAL-CROSS-002`, `EVAL-CROSS-005` | `Covered` |
| `Executable Fixture` | `EVAL-MSG-002`, `EVAL-TEST-001`, `EVAL-TEST-002`, `EVAL-CROSS-004` | `Covered` |
| `Document Fixture` | `EVAL-CORE-003`, `EVAL-HEX-004`, `EVAL-CLEAN-004`, `EVAL-LAYER-004`, `EVAL-FOWLER-004`, `EVAL-MSG-004`, `EVAL-TEST-003`, `EVAL-CROSS-006` | `Covered` |
| `Mixed Fixture` | `EVAL-MSG-001`, `EVAL-TEST-004`, `EVAL-CROSS-003`, `EVAL-FULL-001`, `EVAL-FULL-002` | `Covered` |
| `Manual Evaluation` | Available as an evaluation method inside `EVAL-CORE-003`, `EVAL-CORE-004`, `EVAL-MSG-004`, `EVAL-TEST-004`, `EVAL-FULL-001`, `EVAL-FULL-002`; no scenario uses it as the primary execution type. | `Partially Covered` |

## 28. Implementation Order

1. `EVAL-CORE-001` - Gold Standard;
2. Gold Scenario Review;
3. Gold Scenario Stabilization;
4. `EVAL-CORE-002` to `EVAL-CORE-004`;
5. `EVAL-HEX-001` to `EVAL-HEX-004`;
6. `EVAL-CLEAN-001` to `EVAL-CLEAN-004`;
7. `EVAL-DDD-001` to `EVAL-DDD-004`;
8. `EVAL-LAYER-001` to `EVAL-LAYER-004`;
9. `EVAL-FOWLER-001` to `EVAL-FOWLER-004`;
10. `EVAL-MSG-001` to `EVAL-MSG-004`;
11. `EVAL-TEST-001` to `EVAL-TEST-004`;
12. `EVAL-CROSS-001` to `EVAL-CROSS-006`;
13. `EVAL-FULL-001` to `EVAL-FULL-002`;
14. Evaluation Execution;
15. Coverage Review;
16. Regression Suite;
17. Commit.

## 29. Coverage Gaps

No coverage gap identified.

## 30. Catalog Validation

Catalog validation checklist:

- Correct file: `evaluation/SCENARIO_CATALOG.md`.
- Required top-level structure: 32 numbered sections.
- Exactly 40 scenario IDs are defined.
- Scenario IDs are unique.
- Scenario IDs are continuous within each requested range.
- Scenario titles are unique.
- Distribution is 4 Core, 4 Hexagonal Architecture, 4 Clean Architecture, 4 DDD, 4 Layered Architecture, 4 Fowler, 4 Events & Messaging, 4 Architecture Testing, 6 Cross-Catalog, and 2 Full Review.
- Each scenario has exactly one Primary Rule.
- Primary Rules and Supporting Rules use existing Rule IDs only.
- `EVAL-CORE-001` is the Gold Standard.
- `EVAL-CORE-001` title is exactly `Domain logic coupled to external infrastructure`.
- Scenario types use allowed values only.
- Outcomes use allowed values only.
- Confidence values are covered.
- Severity ranges are covered contextually.
- Evidence strengths use allowed values only.
- Execution types use allowed values only.
- Priorities use allowed values only.
- Every scenario status is `Ready`.
- Every existing Rule is covered as Primary or Supporting.
- Every catalog is covered and no catalog status is `Gap`.
- Every outcome is covered.
- Every confidence level is covered.
- Every severity range is covered.
- Every evidence strength is covered.
- False-positive and false-negative guards are covered.
- Internal and cross-catalog boundaries are covered.
- Matrices are present.
- No central gap is identified.
- No invented Rule ID is used.
- Concrete scenario files are present and ready.
- Expected-result files are present and match the ready scenarios.
- No scenario or expected-result file is altered by this catalog.
- No Rule is altered.
- No architectural catalog, review, or stabilization is altered.
- No commit is made.

## 31. Current Status

- Scenario Catalog: `Defined`;
- Total Scenarios: `40`;
- Gold Standard Scenario: `EVAL-CORE-001`;
- Concrete Scenario Files: `40 Ready`;
- Expected Results: `40 Match`;
- Gold Scenario Review: `Present`;
- Gold Scenario Stabilization: `Present`;
- Evaluation Execution: `Not Started`;
- Coverage Review: `Present`;
- Regression Suite: `Not Started`.

## 32. Change Notes

- Initial scenario catalog created.
- Aligned with `EVALUATION_SUITE.md`.
- Aligned with `SCENARIO_MODEL.md`.
- Aligned with `EXPECTED_RESULT_MODEL.md`.
- Aligned with `COVERAGE_MODEL.md`.
- Defined 40 scenarios.
- Selected `EVAL-CORE-001` as Gold Standard.
