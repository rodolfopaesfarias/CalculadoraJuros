# Pré Requisitos
- Microsoft Visual Studio
- .NET Core 3.1

# CalculadoraJuros
APIs para cálculo de juros compostos
O repositório possui uma solução do Visual Studio com 5 projetos:
1. CalculadoraJurosAPI: API que retorna o valor final com juros, buscando a taxa de juro da API Taxa de Juros.
2. CalculadoraJurosAPIUnitTests: Testes unitários da CalculadoraJurosAPI
3. TaxaJurosAPI: API que retorna a taxa de juros padrão a ser utilizada pela CalculadoraJurosAPI
4. TaxaJurosAPIUnitTests: Testes unitários da TaxaJurosAPI
5. SwaggerController: Library que provê funções de configuração e ativação do Swagger usada pelos projetos CalculadoraJurosAPI e TaxaJurosAPI.

# Como Executar a Solução
Basta fazer o download do código fonte, abrir a solução (arquivo CalculadoraJuros.sln) no Microsoft Visual Studio configurar para iniciar múltiplos projetos sendo os projetos abaixo para serem iniciados:
1. CalculadoraJurosAPI
2. TaxaJurosAPI

Para configurar devem ser seguidos os seguintes passos:
1. Em Solution Explorer clicar com o botão direito do mouse em cima de "Solution 'CalculadoraJuros'"
2. Abaixo de Commom Properties em Startup Project marcar a opção Multiple startup projects
3. Nos projetos CalculadoraJurosAPI e TaxaJurosAPI selecionar a opção Start na coluna Action.

Após isso basta executar a solução apertando F5.

# Como Testar APIs

A CalculadoraJurosAPI faz uma chamada a TaxaJurosAPI, para identificar a URL que deve ser acessada no projeto CalculadoraJurosAPI no arquivo appsettings.json existe uma chave chamada TaxaJurosAPI, conforme abaixo:
- "TaxaJurosAPI": "https://localhost:44358/taxaJuros"

Em ambos projetos de API (CalculadoraJurosAPI e TaxaJurosAPI) está implementado o Swagger, portanto acessando a URL base de cada um /swagger irá exibir a documentação de cada uma delas. 
Exemplo: https://localhost:44357/swagger

# Exemplos de Chamadas

https://localhost:44358/taxaJuros
Retornará 0.01

https://localhost:44357/calculajuros?valorInicial=1000&tempoEmMeses=12
Retornará 1126.82
  
https://localhost:44357/showmethecode
Retornará https://github.com/rodolfopaesfarias/CalculadoraJuros
