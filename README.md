# Calculadora de Salário Líquido

Este projeto é uma aplicação Blazor para calcular o salário líquido com base no salário bruto fornecido. Ele considera deduções de INSS e IR para calcular o valor final.

## Estrutura do Projeto

- **CalculadoraSalarioLiquido.Domain**: Contém a lógica de negócios para calcular o salário líquido, INSS e IR.
- **CalculadoraSalarioLiquido.Application**: Contém os serviços que utilizam a lógica de negócios.
- **CalculadoraSalarioLiquido.API**: Contém os controladores da API para expor os serviços.
- **CalculadoraSalarioLiquido.Tests**: Contém os testes unitários e de integração para o projeto.

## Funcionalidades

- **Calcular Salário Líquido**: Calcula o salário líquido com base no salário bruto fornecido.
- **Calcular INSS**: Calcula a dedução do INSS com base no salário bruto.
- **Calcular IR**: Calcula a dedução do IR com base no salário bruto e no valor do INSS.

## Instalação

1. Clone o repositório:

git clone git@github.com:PauloFreitas533/CalculadoraSalarioLiquido.git

2. Navegue até o diretório do projeto:

cd calculadora-salario-liquido

3. Restaure as dependências do projeto:

dotnet restore

## Exemplo de Uso

### Calcular Salário Líquido

1. Acesse `https://localhost:7189`.
2. Tela de apresentação, clique no botão para ser direcionado para a calculadora.
3. Insira o valor do salário bruto.
4. Clique em "Calcular".
5. O salário líquido será exibido na tela.
 