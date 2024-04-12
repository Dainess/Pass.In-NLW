[Link](http://a.com)

Name
	Pass.In - Backend C# | ASP.NET | MVC | SQLite

Project Overview
	Passs.In é uma aplicação para gestão de participantes em eventos. 
	Organizadores disponibilizam eventos e os participantes podem se cadastrar neles e fazer check-in no dia do evento. 

Requisitos
	Funcionais
		Eventos
			O organizador pode cadastrar um evento
			O organizador pode receber dados de um evento já cadastrado
			O organizador pode ver todos os participantes cadastrados em um evento
			O organizador pode pesquisar especificamente por um participante
		Participante
			O participante pode se cadastrar em um evento
			O participante pode receber dados de uma inscrição sua em um evento
			O participante pode fazer check-in no evento

	Regras de Negócio
		O participante pode se cadastrar apenas uma vez em um evento (chave principal é o e-mail de cadastro)
		O participante pode fazer check-in apenas uma vez em um evento
		O participante só pode se cadastrar em eventos que ainda tem vagas disponíveis

Tecnologias utilizadas
	C#
	ASP.NET
	MVC
	SQLite (local)
	Swagger

Installation Instructions
	Seria bom testar em outro PC para ver como fazer do zero
	Mas basicamente imagino que vc ia ter que instalar o .Net 8, o VS Code, clonar o repo, rodar dentro da pasta PassIn.API o comando dotnet run Program.cs, abrir o link fornecido e voilá, brincar no Swagger

Usage Guide
	Endpoints
	Modo de usar
		A aplicação gira em torno do conceito do evento. Então para se ter qualquer resposta com o programa, a primeira coisa a se fazer é cadastrar um evento usando o endpoint /api/Events. O próximo passo será cadastrar um novo participante no evento a partir de api/Attendees/{eventId}/register, com essa variável sendo o Id retornado pelo método anterior. 
		A partir daí existe uma estrutura básica para adicionar mais eventos, adicionar mais participantes em eventos, realizar check-ins, e obter todas essas informações registradas via endpoints GET. 

Configuration

Support

Roadmap

Contributing Guidelines

Authors and acknowledgments
	Implementado por [Daniel Coutto Mittelman](https://www.linkedin.com/in/daniel-couto-mittelman-34b544116/)

	Esse projeto foi realizado durante a NLWUnite 15, um evento de estímulo ao aprendizado em desenvovimento de software da Rocketseat. Fica o agradecimento à equipe por ter disponibilizado a estrutura, o sem tempo e seus conhecimentos de forma gratuita para o benefício de todos os participantes.

	Professor responsável pelo tutorial:
	Welisson

License

Project Status