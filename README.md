# 🐱 CatBills - Gerenciador de Finanças Pessoais

O CatBills é uma API RESTful para controle e monitoramento de finanças pessoais, desenvolvida em C# com ASP.NET Core e Entity Framework Core. O projeto conta com um banco de dados local SQLite e uma interface de usuário (Frontend) responsiva, moderna e intuitiva integrada diretamente na aplicação.

## 🚀 Funcionalidades Principais

- Gestão de Utilizadores: Cadastro de perfis com definição de salário mensal bruto.

- Controle de Despesas: Lançamento de gastos com descrição, valor, data de vencimento e status de pagamento (Pago/Pendente).

- Categorização Dinâmica: Separação de custos por categorias visuais (Habitação, Alimentação, Transportes, Lazer, etc.) com cores personalizadas.

- Painel de Indicadores (Dashboard):
  - Gráficos interativos de distribuição de despesas por categoria.
  - Cálculo automático de saldo restante com base no salário e gastos do mês.
  - Alertas visuais para contas próximas do vencimento.

## 🛠️ Tecnologias Utilizadas

### Backend (API)

- **Linguagem:** C# (.NET 8.0 / 9.0)
- **Framework:** ASP.NET Core Web API
- **Persistência de Dados:** Entity Framework Core
- **Banco de Dados:** SQLite (banco em arquivo local)
- **Padrão de Projeto:** DTOs (Data Transfer Objects) para segurança e validação de dados.

### Frontend (Interface)

- **Estrutura:** HTML5 de página única (SPA) integrado na pasta `wwwroot`.
- **Estilização:** Tailwind CSS (via CDN) com tema Dark Mode personalizado (Roxo e Preto).
- **Gráficos:** Chart.js para renderização de dados financeiros em tempo real.
- **Ícones:** Lucide Icons.

## 📂 Estrutura do Projeto

```text
CatBills/
│
├── Controllers/         # Endpoints da API (Despesas e Utilizadores)
├── Data/                # Contexto do Banco de Dados (DataContext) e Seeder de dados iniciais
├── DTOs/                # Objetos de Transferência de Dados (Validação de Entrada/Saída)
├── Models/              # Classes de Entidade (Despesa, Utilizador, CategoriaDespesa)
├── wwwroot/             # Ficheiros estáticos do Frontend
│   └── index.html       # Painel de controle do usuário (HTML/CSS/JS)
├── CatBills.csproj      # Ficheiro de configuração do projeto .NET
└── Program.cs           # Ponto de entrada da aplicação e configuração de serviços
```

## 🔧 Como Executar o Projeto Localmente

### Pré-requisitos

- .NET SDK instalado.
- Visual Studio 2022 ou VS Code.

### Passo a Passo

#### Clonar o Repositório

```bash
git clone https://github.com/CamileXavierMedina/CatBills.git
cd CatBills
```

#### Instalar as Dependências (Entity Framework & SQLite)

Abra o terminal do projeto ou o Console do Gerenciador de Pacotes no Visual Studio e execute:

```powershell
Install-Package Microsoft.EntityFrameworkCore.Sqlite
Install-Package Microsoft.EntityFrameworkCore.Design
```

#### Executar a Aplicação

Pressione **F5** no Visual Studio ou execute o comando abaixo no terminal:

```bash
dotnet run
```

#### Acessar a Interface

A API irá iniciar o servidor local e abrirá automaticamente o navegador na interface do usuário através do endereço configurado (ex: `http://localhost:5000` ou `https://localhost:5001`).

O banco de dados SQLite (`catbills.db`) e os dados iniciais de teste serão criados de forma **100% automática** no primeiro início.

## 📝 Licença

Este projeto é de uso livre para fins de estudo e desenvolvimento de portfólio.

Desenvolvido por **Camile Xavier Medina**.
