Nessa aplicação eu crio uma Api com 2 controllers, a primeira controller é responsavel por fazer a autenticação jwt(JsonWebToken), a segunda controller faz o retorno dos dados 
apenas se a autenticação der certo. A segunda aplicação é uma aplication console, nela eu faço primeiro a autenticação via httpclient recebendo o token e depois dou um send
enviando no corpo da requisição o token.
