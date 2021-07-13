# Projeto de Recurso de LPII 2020/2021

## Autores

* [Diana Nóia](https://github.com/diananoia), a21703004
* [Diogo Maia](https://github.com/Diogo-Maia), a21901308
* [Inês Gonçalves](https://github.com/ineesgoncalvees), a21702076

## Repartição de Tarefas

* Diana Nóia
  * Reprodução das células
  * Seleção das células
  * Sistema de verificação
  * UI do Unity
  * Comentários XML

* Diogo Maia
  * Troca das células
  * Vizinhança de Von Neumann
  * *Shuffle* de *FisherYates*
  * Distribuição de *Poisson*
  * *Gameloop*
  * Implementar código do ramo common na Consola e no Unity

* Inês Gonçalves
  * *Setup* do repositório git
  * Ajudou a fazer a reprodução das células
  * Ajudou a fazer a seleção das células
  * UI do Unity
  * Relatório
  * UML
  * Doxygen

## Repositório

O projeto pode ser encontrado neste [repositório](https://github.com/Diogo-Maia/LP2_RockPaperScissor).

## Arquitetura da solução

Este projeto foi feito utilizando o design patern MVC (Model-View-Controller),
que consiste na utilização de um modelo que tem toda a lógica do programa,
independente de toda a parte da interface e controlo, sendo estes controlados
respetivamente pela 'View' e pelo 'Controller'. O nosso projeto está organizado
dessa forma, havendo um sub-módulo com o código comum aos dois projetos, que
funciona como se fosse uma biblioteca, e depois cada projeto tem a sua 'View' e
o seu 'Controller' específicos.

Para tornar mais fácil o processo de utilização do código comum criamos duas
interfaces, uma chamada IView, que tem os métodos base que cada classe View deve
implementar, e uma chamada IController, que faz o mesmo mas para a parte do
controlo do programa (maioritariamente *inputs* e *outputs*).

No código comum foi usada a Vizinhança de *Von Neumann* toroidal que verifica as
casas de cima, baixo e lados da célula selecionada "dando a volta" na vertical e
na horizontal, ignorando os limites das paredes.
Usámos também o método de *Shuffle de FisherYates* que nos ajudou a baralhar os
dados dentro dos arrays.
Para distribuir as diferentes células pela grelha usámos a distribuição de
*Poisson*.
Durante a simulação vão acontecendo três eventos (Troca, Reprodução e Seleção)
usando as regras do jogo "Pedra, papel ou tesoura", podendo o utilizador
controlar, no princípio da simulação a frequência com que estes acontecem, assim
como o tamanho da grelha.

Usámos também os design patterns GameLoop e Facade. O Unity já usa o GameLoop
por si, mas usamos também no código comum, na classe 'GameManager'.
Usamos o Facade tendo classes como o 'GameManager'.
Tivemos em conta também o principio SOLID Single Responsibility.

O projeto da Consola tem apenas duas classes e o Program. Ambas implementam a
respetiva interface usando os métodos necessários.

O projeto do Unity usámos multithreading para podermos usar os botões do Unity.
Para imprimir a imagem da simulação usamos uma 'raw image' que mostra uma
textura que podemos mudar com o código exibindo a simulação.

### Diagrama UML

O UML deste projeto é o seguinte:

![UML](UML.svg)

## Referências

[API do C#](https://docs.microsoft.com/en-us/dotnet/csharp/).

[Stackoverflow](https://stackoverflow.com).

[Vídeo MVC exemplo](https://www.youtube.com/watch?v=_z_iRUjmvzE).

[Wikipédia da distribuição de Poisson](https://en.wikipedia.org/wiki/Poisson_distribution).

[Wikipédia do embaralhamento de FisherYates](https://en.wikipedia.org/wiki/Fisher–Yates_shuffle).
