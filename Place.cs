using System;

namespace LP2_RockPaperScissor.Common
{
    /// <summary>
    /// Classe Place que decide onde cada espécie é colocada
    /// </summary>
    public class Place
    {
        /// <summary>
        /// Variável specie do tipo Species 
        /// </summary>
        private Species specie;

        /// <summary>
        /// Construtor da classe Place
        /// </summary>
        /// <param name="specie">Aceita uma variável specie do Tipo Species
        /// </param>
        public Place(Species specie) => this.specie = specie;

        /// <summary>
        /// Método que seleciona a próxima specie a ser mudada
        /// </summary>
        /// <returns>Retorna uma specie</returns>
        public Species GetSpecie() => specie;

        /// <summary>
        /// Método que muda a specie selecionada para uma diferente
        /// </summary>
        /// <param name="specie">Variável specie, que será alterada</param>
        public void SetSpecie(Species specie) => this.specie = specie;

        /// <summary>
        /// Método Swap que escolhe duas células vizinhas aleatoriamente e 
        /// troca a espécie das duas 
        /// </summary>
        /// <param name="map">Mapa onde as posições são guardadas</param>
        /// <param name="x">Posição em x</param>
        /// <param name="y">Posição em y</param>
        /// <param name="xdim">Dimensão horizontal da grelha</param>
        /// <param name="ydim">Dimensão vertical da grelha</param>
        public void Swap(Place[,] map, int x, int y, int xdim, int ydim)
        {
            // Array que vai receber uma posição aleatória
            Place[] selected = GetRandomPlaces(map, x, y, xdim, ydim);

            // Seleciona uma posição, vê que specie está nessa posição, muda
            // essa specie para a specie da célula vizinha selecionada, e por
            // fim muda a specie da célula vizinha para a specie da célula 
            // incial
            Species sp = selected[0].GetSpecie();
            selected[0].SetSpecie(selected[1].GetSpecie());
            selected[1].SetSpecie(sp);
        }

        /// <summary>
        /// Método Reproduction  que escolhe duas células vizinhas 
        /// aleatoriamente, e se uma das células estiver vazia passa a ser 
        /// ocupada pela espécie da célula vizinha selecionada
        /// </summary>
        /// <param name="map">Mapa onde as posições são guardadas</param>
        /// <param name="x">Posição em x</param>
        /// <param name="y">Posição em y</param>
        /// <param name="xdim">Dimensão horizontal da grelha</param>
        /// <param name="ydim">Dimensão vertical da grelha</param>
        public void Reproduction(
            Place[,] map, int x, int y, int xdim, int ydim)
        {
            // Array que vai receber uma posição aleatória
            Place[] selected = GetRandomPlaces(map, x, y, xdim, ydim);

            // Verifica se a célula selecionada está vazia, e se estiver atribui
            // a specie da célula vizinha selecionada. A mesma verificação
            // acontece para ver se a célula vizinha está vazia, e se estiver é 
            // atribuida a specie da célula original selecionada
            if (selected[0].GetSpecie() == Species.Empty) selected[0]
                    .SetSpecie(selected[1].specie);
            else if (selected[1].GetSpecie() == Species.Empty) selected[1]
                    .SetSpecie(selected[0].specie);
        }

        /// <summary>
        /// Método Selection que escolhe duas células vizinhas aleatoriamente,
        /// e as espécies de cada uma competem entre si, seguindo as regras do
        /// jogo Pedra, Papel e Tesoura. A célula perdedora torna-se vazia
        /// </summary>
        /// <param name="map">Mapa onde as posições são guardadas</param>
        /// <param name="x">Posição em x</param>
        /// <param name="y">Posição em y</param>
        /// <param name="xdim">Dimensão horizontal da grelha</param>
        /// <param name="ydim">Dimensão vertical da grelha</param>
        public void Selection(Place[,] map, int x, int y, int xdim, int ydim)
        {
            // Array que vai receber uma posição aleatória
            Place[] selected = GetRandomPlaces(map, x, y, xdim, ydim);

            // Switch que verifica a specie da célula selecionada e compara com
            // a specie da célula vizinha, para relaizar o jogo Pedra, Papel e
            // Tesoura. A célua perdedora fica vazia
            switch (selected[0].specie)
            {
                case Species.Rock:
                    if (selected[1].specie == Species.Paper)
                        selected[0].specie = Species.Empty;
                    else if (selected[1].specie == Species.Scissor)
                        selected[1].specie = Species.Empty;
                    break;
                case Species.Paper:
                    if (selected[1].specie == Species.Scissor)
                        selected[0].specie = Species.Empty;
                    else if (selected[1].specie == Species.Rock)
                        selected[1].specie = Species.Empty;
                    break;
                case Species.Scissor:
                    if (selected[1].specie == Species.Rock)
                        selected[0].specie = Species.Empty;
                    else if (selected[1].specie == Species.Paper)
                        selected[1].specie = Species.Empty;
                    break;

            }
        }

        /// <summary>
        /// Método GetRandomPlaces do tipo Place[], que 
        /// </summary>
        /// <param name="map">Mapa onde as posições são guardadas</param>
        /// <param name="x">Posição em x</param>
        /// <param name="y">Posição em y</param>
        /// <param name="xdim">Dimensão horizontal da grelha</param>
        /// <param name="ydim">Dimensão vertical da grelha</param>
        /// <returns>Retorna a specie selecionada</returns>
        private Place[] GetRandomPlaces(
            Place[,] map, int x, int y, int xdim, int ydim)
        {
            //
            Random rdn = new Random();
            //
            Place[] selected = new Place[2];
            int n;
            int i = 0;
            int previous = default;

            //
            do
            {
                if (i != 0)
                {
                    do
                    {
                        n = rdn.Next(0, 8);
                    } while (n == previous);
                }
                n = rdn.Next(0, 8);
                previous = n;

                //
                switch (n)
                {
                    case 0:
                        selected[i] =
                            map[y + 1 >= ydim ? 0 : y + 1, x];
                        break;
                    case 1:
                        selected[i] =
                            map[y + 1 >= ydim ? 0 : y + 1,
                            x + 1 >= xdim ? 0 : x + 1];
                        break;
                    case 2:
                        selected[i] =
                            map[y, x + 1 >= xdim ? 0 : x + 1];
                        break;
                    case 3:
                        selected[i] =
                            map[y - 1 < 0 ? ydim - 1 : y - 1,
                            x + 1 >= xdim ? 0 : x + 1];
                        break;
                    case 4:
                        selected[i] =
                            map[y - 1 < 0 ? ydim - 1 : y - 1, x];
                        break;
                    case 5:
                        selected[i] =
                            map[y - 1 < 0 ? ydim - 1 : y - 1,
                            x - 1 < 0 ? xdim - 1 : x - 1];
                        break;
                    case 6:
                        selected[i] =
                            map[y, x - 1 < 0 ? xdim - 1 : x - 1];
                        break;
                    case 7:
                        selected[i] =
                            map[y + 1 >= ydim ? 0 : y + 1,
                            x - 1 < 0 ? xdim - 1 : x - 1];
                        break;
                }
                i++;
            } while (i <= 1);

            return selected;
        }
    }
}
