# 🦷 Sistema de Gerenciamento de Cadeiras Odontológicas

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![MySQL](https://img.shields.io/badge/MySQL-8.0-4479A1?style=for-the-badge&logo=mysql&logoColor=white)
![API REST](https://img.shields.io/badge/API-RESTful-009688?style=for-the-badge&logo=swagger&logoColor=white)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-FF6F00?style=for-the-badge)

Sistema completo para **gerenciamento de cadeiras odontológicas**, com **alocação automática inteligente**, desenvolvido em **.NET 8**, seguindo os princípios da **Clean Architecture** e boas práticas de engenharia de software.

---

## 📋 Índice
- [Funcionalidades](#-funcionalidades)
- [Arquitetura](#-arquitetura)
- [Tecnologias](#-tecnologias)
- [Instalação](#-instalação)
- [Endpoints da API](#-endpoints-da-api)
- [Estrutura do Projeto](#-estrutura-do-projeto)

---

## ✨ Funcionalidades

### 🪑 Gestão de Cadeiras
- CRUD completo de cadeiras odontológicas
- Cadastro com número único, descrição, modelo e fabricante
- Controle de manutenção (data da última manutenção)
- Contador de uso para balanceamento de alocações
- Ativação e inativação de cadeiras

### 📅 Sistema de Alocação Inteligente
- Alocação automática com rotação inteligente
- Distribuição proporcional baseada no histórico de uso
- Validação de conflitos de horário
- Controle de status (Agendado → Em andamento → Concluído / Cancelado)
- Alocação manual para exceções
- Consulta de disponibilidade por período

### 🛡️ Funcionalidades Técnicas
- Validações robustas com **FluentValidation**
- Tratamento global de erros
- Documentação automática com **Swagger / OpenAPI**
- Migrações de banco com **FluentMigrator**
- Injeção de dependência
- AutoMapper para transformação de dados

---

## 🏗️ Arquitetura

### Clean Architecture / Onion Architecture

┌──────────────────────────────────────────────────────────────────┐
│ DentalChair.API │ ← Controllers, Filters                         │
├──────────────────────────────────────────────────────────────────┤
│ DentalChair.Application │ ← Use Cases, Extensions, Services      │
├──────────────────────────────────────────────────────────────────┤
│ DentalChair.Domain │ ← Entities, Enum, IRepository               │
├──────────────────────────────────────────────────────────────────┤
│ DentalChair.Infrastructure │ ← DataAccess, Extensions, Migration │
├──────────────────────────────────────────────────────────────────┤
│ DentalChair.Communication │ ← Enum, Response, Request            │
├──────────────────────────────────────────────────────────────────┤
│ DentalChair.Exceptions │ ←  ExceptionsBase                       │
└──────────────────────────────────────────────────────────────────┘

### Padrões Utilizados
- Clean Architecture
- Repository Pattern
- CQRS (Light)
- Domain-Driven Design (DDD)
- Dependency Injection

---

## 🛠️ Tecnologias

### Backend
| Tecnologia | Versão |
|----------|--------|
| .NET | 8.0 |
| Entity Framework Core | 8.0 |
| FluentMigrator | 3.3.2 |
| FluentValidation | 11.9.0 |
| AutoMapper | 12.0.1 |
| Dapper | 2.1.28 |
| MySqlConnector | 8.3.0 |

### Banco de Dados
| Tecnologia | Finalidade |
|----------|------------|
| MySQL 8+ | Banco relacional |
| Índices | Performance |
| Foreign Keys | Integridade |
| Transações ACID | Consistência |

---

## 🚀 Instalação

### Pré-requisitos
- .NET 8 SDK
- MySQL 8+
- Git
- Visual Studio 2022+

### Passos

git clone https://github.com/seu-usuario/dental-chair-api.git

### ⚙️ Configuração

Altere apenas a String de Conexão colocando os dados do seu banco

String de Conexão
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=SeuBanco;Uid=root;Pwd=SuaSenha;"
}

---

## 🌐 Endpoints da API

### Cadeiras
Método	Endpoint

POST /Chair/register

GET /Chair/getall

GET /Chair/GetById/{id}

GET /Chair/GetByChairNumber/{chairNumber}

PUT /Chair/update/{id}

PUT /Chair/updateMaintenance/{id}

DELETE /Chair/delete/{id}


### Alocações
Método	Endpoint

POST	/Allocation/register

PUT /Allocation/updateStatus/{id}

GET /Allocation/GetAll

GET /Allocation/GetChairAvailableByDate/{date}

GET /Allocation/GetAllocationById/{id}

---

## 📁 Estrutura do Projeto

Organização baseada em responsabilidades claras, separando domínio, aplicação, infraestrutura e API.

src/
  Backend/
   ├── DentalChair.API
   ├── DentalChair.Application
   ├── DentalChair.Domain
   └── DentalChair.Infrastructure
  Shared/
  ├── DentalChair.Communication
  ├── DentalChair.Exceptions

