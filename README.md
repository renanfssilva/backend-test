# backend-test
Teste para a vaga de Backend Developer na Audaces.

### Sobre o desafio:
Foi desenvolvida uma API com C#, porém foram utilizados conceitos REST ao invés de GraphQL. 
A API recebe uma lista de números, chamada de Sequence, e um número alvo, chamado de Target.  
Por exemplo: 
```
{
 "Sequence": [5, 20, 2, 1],
 "Target": 47
}
```

A API checa se é possível atingir o número alvo com uma combinação das pontuações e, se possível, retorna essa combinação.  
No nosso exemplo, a API poderia retornar: 
```
[2, 5, 20, 20]
```
Além disso, as chamadas para a API são gravadas num banco em memória para não haver a necessidade da utilização de um SQL Server e montar um banco completo para a aplicação.
Como o problema é um NP-hard, a solução desenvolvida por mim poderá haver problemas com um Target de valor muito alto e uma Sequence longa.

### Endpoints implementados: 

* Um endpoint que recebe as pontuações e o número alvo, retornando uma combinação possível;

* Um endpoint que receba duas datas e retorne todos as consultas na API naquele período;
 

### Extras: 

* Testes unitários com xUnit e Moq;
* Swagger para a documentação através do endpoint `api/documentation`;
* Autofac para a inversão de controle;
* AutoMapper para fazer o mapeamento de DTOs e Models.
