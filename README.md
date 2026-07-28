# ArchInspector

ArchInspector é uma Skill de revisão arquitetural orientada por evidências, especializada em sistemas C#/.NET.

Seu princípio central é simples: nenhuma conclusão arquitetural deve ser apresentada sem evidência concreta. A ferramenta foi criada para analisar sistemas existentes, identificar estilos arquiteturais prováveis, validar fronteiras, explicar riscos e produzir recomendações priorizadas com base no material realmente disponível para revisão.

---

## Objetivo

O objetivo do ArchInspector é apoiar revisões arquiteturais profissionais de projetos C#/.NET, com foco em clareza, rastreabilidade e tomada de decisão técnica.

A ferramenta ajuda a responder perguntas como:

- Quais estilos arquiteturais aparecem no sistema analisado?
- As dependências respeitam as fronteiras esperadas?
- Existem violações relevantes de domínio, camadas, persistência, mensageria ou testes?
- Quais riscos arquiteturais têm maior impacto para evolução, manutenção e operação?
- Quais melhorias devem ser priorizadas, considerando benefícios e trade-offs?

O ArchInspector não substitui o julgamento de arquitetura. Ele organiza a análise, aplica catálogos de regras, torna incertezas explícitas e evita conclusões baseadas apenas em preferência, nomenclatura ou suposições.

---

## Principais funcionalidades

- Revisão arquitetural orientada por evidências.
- Detecção de estilos arquiteturais com níveis de confiança.
- Avaliação de regras por categoria arquitetural.
- Registro explícito de escopo, cobertura e limitações da análise.
- Classificação de resultados como `Pass`, `Fail`, `Warning`, `Not Applicable` ou `Not Enough Evidence`.
- Identificação de findings com severidade, impacto, recomendação e trade-offs.
- Agrupamento de findings por causa raiz quando houver evidência suficiente.
- Geração de relatório executivo para stakeholders técnicos e não técnicos.
- Geração de relatório técnico detalhado para times de engenharia e arquitetura.
- Geração de scorecard arquitetural quando a cobertura da análise permitir pontuação.
- Produção de roadmap de refatoração priorizado e baseado nos findings encontrados.
- Suporte a exemplos, templates, catálogos de regras e suíte de avaliação.

---

## Arquiteturas suportadas

- Arquitetura Hexagonal
- Clean Architecture
- Domain-Driven Design (DDD)
- Layered Architecture
- Patterns of Enterprise Application Architecture (PoEAA)

Além dessas categorias principais, o ArchInspector também possui regras e conhecimento relacionados a SOLID, eventos e mensageria, testes de arquitetura e arquitetura de solução.

---

## Como funciona

O ArchInspector segue um fluxo sequencial de análise para reduzir subjetividade e evitar conclusões sem base material.

1. Descobre o material disponível para revisão.
2. Define o escopo da análise, incluindo o que foi e o que não foi revisado.
3. Detecta estilos arquiteturais prováveis com base nas evidências encontradas.
4. Seleciona regras aplicáveis ao escopo e aos estilos identificados.
5. Coleta evidências concretas, como referências de projeto, pacotes, namespaces, tipos, dependências, construtores, métodos e trechos de código.
6. Avalia cada regra usando status e nível de confiança.
7. Agrupa findings por causa raiz quando a relação for sustentada por evidências.
8. Calcula pontuações apenas quando houver cobertura suficiente.
9. Gera os relatórios definidos pelos templates do projeto.
10. Produz um roadmap priorizado a partir dos findings confirmados ou prováveis.

Quando a evidência é insuficiente, a conclusão deve ser marcada como `Not Enough Evidence`. Isso preserva a confiabilidade da revisão e evita extrapolações indevidas.

---

## Estrutura do projeto

- `.archinspector`: contexto e metadados de apoio para uso da Skill.
- `.github`: arquivos de configuração e automação relacionados ao GitHub.
- `docs`: documentação de apoio, processo de escrita, arquitetura do repositório e guia inicial.
- `evaluation`: suíte de avaliação, modelos de cenário, resultados esperados, cobertura e estabilizações.
- `examples`: exemplos completos de revisão e relatórios gerados.
- `samples`: projetos ou descrições de amostra usados como referência para análise.
- `skill`: núcleo da Skill, incluindo instruções, checklists, regras, templates, exemplos, schemas, conhecimento e avaliações internas.
- `CHANGELOG.md`: histórico de mudanças do projeto.
- `CODE_OF_CONDUCT.md`: diretrizes de conduta para colaboração.
- `CONTRIBUTING.md`: orientações para contribuição.
- `LICENSE`: arquivo reservado para a licença do projeto.
- `ROADMAP.md`: evolução planejada do ArchInspector.

---

## Exemplo de utilização

Um fluxo típico de uso do ArchInspector envolve:

1. Reunir o material do sistema a ser analisado, como estrutura da solução, arquivos de projeto, dependências, namespaces, trechos de código, testes e documentação disponível.
2. Ler o contexto em `.archinspector/AI_CONTEXT.md` e as instruções principais em `skill/instructions.md`.
3. Definir o escopo da revisão antes de qualquer conclusão arquitetural.
4. Executar a análise seguindo o fluxo sequencial da Skill.
5. Registrar evidências para cada conclusão, finding ou recomendação.
6. Gerar os relatórios aplicáveis: Executive Report, Technical Report e Architecture Scorecard.
7. Usar o roadmap resultante para priorizar ações de melhoria arquitetural.

Exemplos completos de saída podem ser encontrados em `examples/full-review`.

---

## Estrutura dos relatórios gerados

### Executive Report

Relatório voltado para leitura executiva e tomada de decisão. Resume o estado arquitetural, principais riscos, pontos fortes, findings críticos, visão geral da arquitetura e recomendações priorizadas.

### Technical Report

Relatório detalhado para engenharia e arquitetura. Apresenta escopo, categorias avaliadas, findings completos, evidências, impactos, recomendações, trade-offs, dívidas técnicas e conclusão técnica.

### Architecture Scorecard

Resumo quantitativo e comparativo da maturidade arquitetural. Apresenta pontuação geral, resultado por categoria, indicadores de conformidade, principais riscos e próximos passos.

A pontuação arquitetural é condicional: ela só deve ser calculada quando a cobertura da análise for suficiente para sustentar um resultado significativo.

---

## Roadmap

A versão v1.0.0 marca a consolidação estável dos principais módulos do ArchInspector:

- Instruções centrais de revisão.
- Base de conhecimento.
- Catálogo de regras.
- Templates de relatórios.
- Exemplos de uso.
- Suíte de avaliação.

As próximas evoluções previstas incluem:

- Expansão controlada de cenários de avaliação.
- Fortalecimento da suíte de regressão.
- Evolução dos exemplos completos de revisão.
- Refinamento contínuo dos templates de relatório.
- Melhoria da documentação de uso e contribuição.
- Ampliação da rastreabilidade entre regras, evidências, findings e resultados esperados.

---

## Licença

A licença do projeto está preparada para definição formal futura.

Antes de utilizar, distribuir ou modificar o ArchInspector em ambientes públicos ou comerciais, consulte o arquivo `LICENSE` e acompanhe futuras atualizações da licença oficial do repositório.
