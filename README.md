# webapieventos
.Net Core Api 2.0 - Jwt - EF Core - Dapper - Swagger


Api Documentation

http://localhost:<random_port>/swagger

Cadastrando usuário padrão:

http://localhost:<random_port>/api/usuario/CrieUsuarioPadrao

Fazendo requisição de um novo Token: 

http://localhost:<random_port>/token

Deve passar no Header os seguintes parametros: username : "" e password: ""

POST /token
Content-Type: application/x-www-form-urlencoded
 
username=TEST&password=TEST123
