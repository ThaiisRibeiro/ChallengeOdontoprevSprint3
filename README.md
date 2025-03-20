 📌 API #de Microservices em C# com Simple Factory

## 📖 Sobre o Projeto
Este projeto tem como objetivo desenvolver uma aplicação para a **OdontoPrev**, que gerencia operações diárias envolvendo **Pacientes, Dentistas, Clínicas, Agendamentos, Tabela de Preços e Contas a Receber/Pagar**. Além disso, o sistema detectará automaticamente possíveis **fraudes financeiras e administrativas**, facilitando a gestão e prevenindo atividades fraudulentas. 🚀

## 📐 Escopo
As funcionalidades principais incluem:
- **Gerenciamento de Pacientes, Dentistas e Clínicas, Agendamentos, Contas, Tabela de Preços e Fraude** 🏥👨‍⚕️💳
  - Cadastrar, visualizar, atualizar e excluir informações.
- **Agendamentos** 📅
  - Registrar consultas entre pacientes e dentistas.
- **Contas a Receber/Pagar** 💰
  - Gerenciar os pagamentos de consultas e procedimentos.
- **Detecção de Fraudes** 🔍
  - Identificar comportamentos suspeitos, como múltiplos agendamentos em períodos curtos e valores anormais em contas.

## 📝 Requisitos Funcionais
✔️ CRUD completo para **Pacientes, Dentistas, Clínicas, Agendamentos, Contas, Tabela de Preços e Fraude**.  
✔️ Consultas e visualização de **relatórios de fraudes**.  
✔️ Integração com **Oracle Database** para persistência de dados.  
✔️ Documentação completa via **Swagger**.  

## 🏗️ Arquitetura da API
Optamos pela abordagem de **microservices** devido aos seguintes motivos:
- **Escalabilidade** ⚡: Cada serviço pode ser escalado de forma independente.
- **Manutenção simplificada** 🔧: Alterações em um serviço não impactam diretamente os outros.
- **Flexibilidade** 🔀: Permite que cada microserviço use tecnologias diferentes conforme a necessidade.
- **Alta disponibilidade** 📡: Problemas em um serviço não afetam o funcionamento do sistema como um todo.

🔹 **Diferença para uma arquitetura monolítica:** Enquanto um monólito concentra toda a lógica em uma única aplicação, a abordagem de **microservices** divide o sistema em várias partes menores, facilitando sua manutenção e escalabilidade.

## 📌 Endpoints CRUD 🗄️
A API realiza operações CRUD utilizando **Oracle Database** para os seguintes recursos:
- **Pacientes** 👤
- **Dentistas** 🦷
- **Clínicas** 🏥
- **Agendamentos** 📅
- **Contas a Receber/Pagar** 💳
- **Tabela de Preços** 💰
- **Fraudes** 🔍

### Exemplos de Endpoints:
```http
GET /api/pacientes
POST /api/pacientes
PUT /api/pacientes/{id}
DELETE /api/pacientes/{id}
```

## 🏗️ Padrão de Criação: Simple Factory 🏭
Implementamos o padrão **Simple Factory** para facilitar a criação de objetos sem expor a lógica de instanciamento ao cliente.

### 🛠 Exemplo de Implementação:
```csharp
public class UsuarioFactory
{
    public static Usuario CriarUsuario(string nome, string email)
    {
        return new Usuario { Nome = nome, Email = email };
    }
}
```


## 🚀 Como Rodar a API
1. **Clone o repositório:**
   ```sh
   git clone https://github.com/ThaiisRibeiro/ChallengeOdontoprevSprint3.git
   cd nome-do-repositorio
   ```
2. **Configure o banco de dados Oracle** (modifique `Program.cs` e no  `Context.cs`  com as credenciais corretas).
3. **Instale as dependências:**
   ```sh
   dotnet restore
   ```
4. **Execute a API:**
   ```sh
   dotnet run
   ```
5. **Acesse o Swagger para testar os endpoints:** 


