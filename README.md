### Projeto de Modelo CRUD em ASP.NET 7 🖥️
Este é um projeto de modelo CRUD (Create, Read, Update e Delete) desenvolvido em ASP.NET 7, utilizando as seguintes tecnologias e ferramentas: 
Entity Framework, SQLite, ASP.NET Identity para autenticação e Bootstrap como framework de CSS.

O objetivo deste projeto é criar uma plataforma onde os alunos possam se cadastrar e gerenciar suas assinaturas. Os alunos têm a capacidade de se cadastrar na plataforma e ter uma ou várias assinaturas associadas às suas contas, mas apenas uma assinatura ativa naquele momento atual.

* #### Funcionalidades 🖱️

**Cadastro de Alunos:** Os alunos podem se cadastrar na plataforma fornecendo informações como nome, e-mail e senha.

**Autenticação e Autorização:** O sistema utiliza ASP.NET Identity para permitir que os alunos façam login de forma segura e acessem apenas as áreas autorizadas.

**Gerenciamento de Assinaturas:** Os alunos podem gerenciar suas assinaturas. Cada assinatura possui informações como data de início, data de término e status (ativa ou não).

* #### Estrutura do Projeto: 🖼️

**Controllers:** Contém os controladores que definem as ações a serem executadas em resposta às solicitações do usuário.

**Entities:** Contém as classes de entidade que representam os objetos, como as classes de Aluno e Assinatura.

**Views:** Contém as visualizações em formato Razor que definem a aparência das páginas.

**Migrations:** Contém as migrações do Entity Framework para criar e atualizar o esquema do banco de dados.

![image](https://github.com/RafaelaRomin/CrudBaltaIo/assets/124751861/f5dd3970-a950-46e8-8bd4-a0dc81cbf95e)

Este projeto foi feito para fins didáticos e pode não abranger todos os aspectos de segurança e otimização necessários em uma aplicação de produção real.
