# webapieventos
.Net Core Api 2.0 - Jwt - EF Core - Dapper - Swagger


Api Documentation

http://localhost:<random_port>/swagger

Rodando a aplicação:
1º Faça o clone.
2º Abra no visual studio 2017 com asp.net core 2.0
3º Faça o migratio(Sql Server) 
   3.1 Execute: Add-Migration "NomeDaSuaMigration"
   3.2 Update-Database
4º Rode aplicação(F5)

Cadastrando usuário padrão:

http://localhost:<random_port>/api/usuario/CrieUsuarioPadrao

Fazendo requisição de um novo Token: 

http://localhost:<random_port>/token

Deve passar no Header os seguintes parametros: username : "" e password: ""

POST /token
Content-Type: application/x-www-form-urlencoded
 
username=TEST&password=TEST123
