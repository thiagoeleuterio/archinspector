# Rule ID

CLEAN-010

# Title

Data mappers must not shape entities or use cases

# Category

Clean Architecture

# Status

Active

# Intent

Ensure mapping logic translates data without imposing persistence or transport structures on policies.

# Applicability

Apply this rule when the reviewed material includes identifiable data mappers, mapping logic, persistence models, transport models, external data structures, entities, use cases, application business rules, enterprise business rules, or equivalent policy components that interact through translated data.

# Rule Statement

Data mappers must translate between external data structures and policy-facing structures without shaping entities or use cases around persistence or transport concerns.

# Rationale

Data mappers protect Clean Architecture policies by converting data across technical boundaries. When mapper behavior or mapper-owned structures force entities or use cases to reflect persistence schemas, transport payloads, serialization concerns, query results, or external data contracts, policy code becomes coupled to technical detail models and changes in those details are more likely to alter business rules or use case contracts.

# Evidence Required

Evaluation requires traceable evidence that identifies the reviewed mapper scope, the external data structures being translated, and the entities or use cases that may be shaped by those structures. Direct evidence may include project or module references, dependency declarations, package references, imports, namespace relationships, type dependencies, constructor dependencies, method signatures, mapping method behavior, mapper interfaces, entity member definitions, use case boundary data structures, persistence or transport model usage, serialization metadata, schema-shaped fields, or reviewed code excerpts showing whether mapping logic translates data or imposes external structures on policies.

Evidence must distinguish data mapping responsibility from general gateway, repository, persistence, transport, or interface adapter responsibility. Naming conventions, folder names, mapper labels, model suffixes, or architectural intent may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

Determine first whether the reviewed material supports a defensible Clean Architecture distinction between data mappers, external data structures, entities, and use cases. Then inspect whether mapper behavior translates data across boundaries while entities and use cases remain shaped by policy needs, or whether policy structures are constrained by persistence schemas, transport payloads, serialization formats, query projections, external identifiers, or other technical data forms.

Evaluate only whether data mappers shape entities or use cases by imposing persistence or transport structures on policies. Do not use this rule to evaluate general gateway isolation, repository design, persistence architecture, transport architecture, interface adapter translation as a whole, or whether every mapping implementation is ideal unless that evidence directly shows mapper-driven shaping of entities or use cases.

Interpret evidence conservatively. Similar field names between external models and policy structures are not enough to prove that a mapper shapes policies. Prefer `Not Enough Evidence` when the reviewed material does not allow the reviewer to identify mapper responsibility, distinguish external data structures from policy-facing structures, or determine whether policy shape is imposed by mapping concerns.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify relevant data mappers, external data structures, entities or use cases, and mapping behavior, and the available evidence supports that mappers translate data without making entities or use cases conform to persistence or transport structures.

# Fail Conditions

Use `Fail` when direct evidence shows that data mapper behavior, mapper-owned models, or mapper-required structures force entities or use cases to expose, accept, require, or organize policy data according to persistence schemas, transport payloads, serialization formats, query result shapes, external data contracts, or other technical data structures.

# Warning Conditions

Use `Warning` when evidence indicates partial, inconsistent, indirect, emerging, or ambiguous mapper influence on entity or use case shape, but the available material does not justify a definitive `Fail`. Use `Warning` when mapping logic mostly translates data but some policy-facing structures appear partly shaped by persistence or transport concerns without enough evidence to classify the issue conclusively.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include identifiable data mappers, mapping logic, external data structures, entities, use cases, policy-facing structures, or mapper-to-policy interactions relevant to this rule.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the available material does not provide enough evidence to identify mapper scope, identify external data structures, inspect mapping behavior, distinguish policy-facing structures from persistence or transport structures, determine whether entities or use cases are shaped by mapper concerns, or resolve conflicting signals.

# Severity Guidance

Assign higher severity when mapper-imposed persistence or transport shape affects central entities, central use cases, broad policy contracts, multiple technical data mechanisms, or stable business-rule boundaries. Assign lower severity when the shaping is narrow, isolated, indirect, or limited to peripheral policy data. Severity must reflect the demonstrated architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the mapper scope, the external data structure, the affected entity or use case, and the mapper-driven shaping relationship. Use `Likely` when multiple evidence points support the evaluation but direct confirmation is incomplete. Use `Possible` when evidence is limited, indirect, or partially ambiguous. Use `Not Enough Evidence` when the material cannot support a reliable conclusion. Naming alone must not produce `Confirmed` confidence.

# Dependencies

CLEAN-003, CLEAN-004, CLEAN-005, CLEAN-006, CLEAN-009. These are conceptual dependencies for shared policy, use case, entity, adapter, gateway, and boundary translation vocabulary, not procedural prerequisites for evaluating this rule.

# References

CA_CATALOG.md

# Change Notes

None
