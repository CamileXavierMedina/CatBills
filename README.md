# CatBills - Gestão de Finanças Pessoais

O **CatBills** é um ecossistema completo e inteligente para controlo e monitorização de finanças pessoais. O projeto é composto por uma API RESTful robusta desenvolvida em **C# com ASP.NET Core** (com banco de dados SQLite local) e uma interface de utilizador premium, moderna e responsiva (**Single Page Application**) integrada diretamente no servidor de ficheiros estáticos da aplicação.

Esta versão foi completamente otimizada para o seminário académico, focando em dois CRUDs de tabelas físicas totalmente independentes e integrados a uma base de dados física local relacional.

---

## Design & Identidade Visual

A interface do CatBills foi projetada com foco na experiência de utilizador (**UX**) e legibilidade em ambientes escuros (**Dark Mode**):

* **Fundo Deep Black:** estética de alto contraste (`#09090B`) para reduzir o cansaço visual.
* **Destaques em Roxo Vibrante:** cor da marca (`#8B5CF6`) utilizada nas ações principais e navegação.
* **Ganhos em Verde Vibrante:** receitas e saldos positivos recebem destaque visual (`#10B981`).
* **Barra Lateral Estática:** menu lateral fixo enquanto a área principal realiza a rolagem independentemente.

---

## Funcionalidades Principais

### CRUD 1 — Gestão de Receitas (Entradas)

* Cadastro de receitas
* Listagem de receitas
* Edição de receitas
* Exclusão de receitas

**Campos:**

* Descrição
* Valor
* Data de recebimento
* Origem

### CRUD 2 — Gestão de Despesas (Saídas)

* Cadastro de despesas
* Listagem de despesas
* Edição de despesas
* Exclusão de despesas

**Campos:**

* Descrição
* Valor
* Data de vencimento
* Meio de pagamento (PIX, Crédito ou Débito)
* Tipo de despesa (Fixa ou Variável)
* Associação física com categorias

### Dashboard Financeiro

* Saldo calculado dinamicamente em tempo real
* Receitas menos despesas
* Gráfico de progresso orçamentário
* Distribuição percentual por categorias
* Classificação de despesas fixas e variáveis

**Categorias suportadas:**

* Habitação
* Alimentação
* Transportes
* Lazer

---

## Tecnologias Utilizadas

### Backend (API)

| Tecnologia            | Utilização                     |
| --------------------- | ------------------------------ |
| C# (.NET 8.0)         | Linguagem principal            |
| ASP.NET Core Web API  | API RESTful                    |
| Entity Framework Core | Persistência de dados          |
| SQLite                | Banco de dados físico local    |
| DTO Pattern           | Validação e segurança de dados |

### Frontend (Interface)

| Tecnologia   | Utilização              |
| ------------ | ----------------------- |
| HTML5        | Estrutura               |
| JavaScript   | Comunicação com API     |
| Fetch API    | Requisições assíncronas |
| Tailwind CSS | Estilização             |
| Lucide Icons | Ícones                  |

---

## Estrutura do Repositório

```text
CatBills/
│
├── Controllers/
│   ├── DespesasController.cs
│   └── ReceitasController.cs
│
├── Data/
│   └── DataContext.cs
│
├── DTOs/
│   ├── CriarDespesaDto.cs
│   ├── CriarReceitaDto.cs
│   ├── ExibirDespesaDto.cs
│   └── ExibirReceitaDto.cs
│
├── Models/
│   ├── CategoriaDespesa.cs
│   ├── Despesa.cs
│   └── Receita.cs
│
├── wwwroot/
│   └── index.html
│
├── CatBills.csproj
└── Program.cs
```

---

## Como Executar o Projeto Localmente

### Pré-requisitos

* .NET SDK 8.0
* Visual Studio 2022 ou VS Code

### 1. Clonar o Repositório

```bash
git clone https://github.com/CamileXavierMedina/CatBills.git

cd CatBills
```

### 2. Instalar Dependências do SQLite

Abra:

```text
Ferramentas
→ Gerenciador de Pacotes NuGet
→ Console do Gerenciador de Pacotes
```

Execute:

```powershell
Install-Package Microsoft.EntityFrameworkCore.Sqlite -Version 8.0.12

Install-Package Microsoft.EntityFrameworkCore.Design -Version 8.0.12
```

### 3. Compilar e Executar

Pressione:

```text
F5
```

ou clique no botão **Play** do Visual Studio.

---

## Inicialização Automática

Ao executar o projeto:

* O servidor ASP.NET Core será iniciado localmente.
* O arquivo físico `catbills.db` será criado automaticamente.
* As tabelas serão geradas automaticamente.
* O Seeder inicial irá popular dados de teste.
* O painel financeiro abrirá diretamente no navegador.

---

## Licença

Desenvolvido por **Camile Xavier Medina** para fins de estudo académico, extensão universitária e portfólio de desenvolvimento de sistemas Web.

Uso livre para fins educacionais.
