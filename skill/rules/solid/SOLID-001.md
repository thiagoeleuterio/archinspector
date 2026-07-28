# Rule ID

SOLID-001

# Title

High-level policy should depend on abstractions

# Category

SOLID

# Status

Active

# Intent

Evaluate whether high-level policy remains protected from low-level implementation volatility by depending on stable abstractions instead of concrete details.

# Applicability

Apply this rule when the reviewed material includes object-oriented types, components, modules, services, use cases, domain services, application services, or policy-bearing code that coordinates or expresses high-level behavior while collaborating with lower-level details.

The rule is relevant when there is enough evidence to distinguish high-level policy from lower-level implementation details and to inspect the dependencies between them. Do not apply this rule solely because an interface, abstract class, dependency injection container, or framework registration exists.

# Rule Statement

High-level policy must depend on abstractions whose ownership and stability protect the policy from concrete low-level implementation details.

# Rationale

The Dependency Inversion Principle reduces architectural coupling by preventing important policy decisions from being forced to change when lower-level details such as persistence, delivery, infrastructure, framework, or vendor code change.

When high-level policy depends directly on volatile implementations, policy code becomes harder to test, reuse, replace, and evolve independently. Conversely, an abstraction that merely mirrors one implementation or is owned by the low-level detail may not provide meaningful inversion.

# Evidence Required

Evaluation requires traceable evidence identifying the high-level policy, the lower-level detail, the dependency direction, and any abstraction intended to separate them.

Direct evidence may include type references, imports, constructor parameters, method signatures, interface definitions, abstract base types, dependency injection registrations, module or project references, package dependencies, adapter or implementation bindings, tests using substitutes, and reviewed code excerpts showing how policy code calls lower-level behavior.

Evidence must distinguish stable policy-facing abstractions from implementation-shaped wrappers. Naming conventions, folders, interface suffixes, dependency injection configuration, and comments may support interpretation but must not be treated as conclusive evidence without corroborating structural or behavioral evidence.

# Evaluation Guidance

First determine whether the reviewed dependency involves high-level policy and lower-level implementation detail in a SOLID sense. High-level policy may appear in application, domain, orchestration, business rule, or component decision code; low-level details may include persistence, external services, framework APIs, UI mechanisms, messaging clients, file systems, vendor SDKs, or concrete algorithms that are expected to vary.

Evaluate the direction and quality of the dependency. A pass requires more than the presence of an interface: the policy should depend on an abstraction that expresses what the policy needs, and concrete details should conform to that abstraction rather than shaping the policy around their own API.

Interpret evidence conservatively. Direct concrete references from policy to detail are strong evidence. An abstraction located near or owned by the implementation is not automatically invalid, but it becomes suspect when it exposes implementation vocabulary, lifecycle, exceptions, configuration, or data structures that force policy to know the detail.

Do not use this rule to re-evaluate a complete Clean Architecture, Hexagonal Architecture, Layered Architecture, messaging, or solution-level boundary. Those rules may use similar evidence, but this rule concludes only on dependency inversion as a SOLID principle with architectural relevance.

# Pass Conditions

Use `Pass` when the reviewed scope is sufficient to identify high-level policy, lower-level details, and dependency direction, and the evidence supports that policy code depends on stable abstractions rather than concrete implementations.

Use `Pass` when the abstraction is shaped by policy needs, can be implemented or substituted without changing policy code, and prevents low-level implementation concerns from leaking into policy signatures, behavior, or decisions.

Use `Pass` when concrete details depend on or are bound to the abstraction through composition, adapter code, configuration, or equivalent assembly mechanisms outside the high-level policy.

# Fail Conditions

Use `Fail` when direct evidence shows that high-level policy depends directly on concrete low-level implementation details in a way that creates architectural coupling or change sensitivity.

Use `Fail` when the supposed abstraction is implementation-owned or implementation-shaped to the extent that policy code still depends on low-level concepts, framework types, vendor APIs, persistence structures, transport models, technical lifecycle, or concrete exception behavior.

Use `Fail` when replacing a low-level detail would require changing high-level policy code because no stable policy-facing abstraction exists or because the abstraction exposes the detail's volatile contract.

# Warning Conditions

Use `Warning` when evidence indicates partial, inconsistent, indirect, or ambiguous dependency inversion risk that does not justify a definitive `Fail`.

Use `Warning` when abstractions exist but are inconsistently used, policy code mostly depends on abstractions but retains isolated concrete references, or implementation vocabulary appears in policy-facing contracts without enough evidence of confirmed coupling impact.

Use `Warning` when dependency injection or interface extraction is present but the reviewed material does not fully show whether the abstraction is policy-facing, stable, substitutable, or meaningfully independent from the implementation.

# Not Applicable Conditions

Use `Not Applicable` when the reviewed scope does not include high-level policy, lower-level details, object-oriented dependency relationships, or concrete collaborations relevant to dependency inversion.

Use `Not Applicable` when the material concerns purely data declarations, build configuration, deployment topology, documentation without inspectable dependency relationships, or architectural boundaries owned by another category without a SOLID dependency-inversion concern.

# Not Enough Evidence Conditions

Use `Not Enough Evidence` when the rule may be relevant but the reviewed material does not provide enough evidence to identify high-level policy, identify lower-level details, inspect dependency direction, inspect abstraction ownership or shape, or determine whether replacement of the detail would affect policy code.

Use `Not Enough Evidence` when only naming, folder structure, interface suffixes, dependency injection registrations, diagrams, or comments are available without traceable code, dependency, or behavioral evidence.

Use `Not Enough Evidence` when implementation and documentation conflict and the reviewed material cannot resolve which dependency relationship is actually used.

# Severity Guidance

The intended default severity for this rule is High. Assign higher severity when direct dependence on details affects central business policy, many policy types, critical change paths, broadly reused abstractions, core module boundaries, or important testability and replaceability concerns.

Assign lower severity when the issue is isolated, peripheral, easy to isolate through composition, limited to a stable detail with low replacement pressure, or has little demonstrated impact on policy change. Severity must reflect architectural impact within the reviewed scope.

# Confidence Guidance

Use `Confirmed` when direct evidence clearly establishes the policy code, the low-level detail, the dependency direction, and whether the abstraction protects or fails to protect policy from implementation detail.

Use `Likely` when multiple consistent evidence points support the evaluation but some dependency, binding, test, or ownership detail is unavailable. Use `Possible` when evidence is limited, indirect, naming-based with partial corroboration, or structurally suggestive.

Use `Not Enough Evidence` when essential information is missing, the dependency path is not traceable, the role of the abstraction cannot be determined, or documentation conflicts with implementation. Naming alone must not produce `Confirmed` confidence.

# Dependencies

None

# References

TAXONOMY.md

SPECIFICATION.md

Robert C. Martin, dependency inversion principle material.

# Change Notes

Expanded the legacy incomplete rule into the official specification format while preserving the existing rule identifier, severity intent, and dependency-inversion concern.
