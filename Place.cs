using System;

namespace LP2_RockPaperScissor.Common
{
    public class Place
    {
        private Species specie;
        private Random rdn;

        public Place(Species specie)
        {
            this.specie = specie;

            rdn = new Random();
        }

        public Species GetSpecie() => specie;

        public void SetSpecie(Species specie) => this.specie = specie;

        public void Swap(Place[,] map, int x, int y, int xdim, int ydim)
        {
            Place[] selected = 
                { map[x, y], GetRandomPlaces(map, x, y, xdim, ydim) };
            Species sp = selected[0].GetSpecie();
            selected[0].SetSpecie(selected[1].GetSpecie());
            selected[1].SetSpecie(sp);
        }

        public void Reproduction
            (Place[,] map, int x, int y, int xdim, int ydim)
        {
            Place[] selected = 
                { map[x, y], GetRandomPlaces(map, x, y, xdim, ydim) };
            if (selected[0].GetSpecie() == Species.Empty) 
                selected[0].SetSpecie(selected[1].specie);
            else if (selected[1].GetSpecie() == Species.Empty) 
                selected[1].SetSpecie(selected[0].specie);
        }

        public void Selection(Place[,] map, int x, int y, int xdim, int ydim)
        {
            Place[] selected = 
                { map[x, y], GetRandomPlaces(map, x, y, xdim, ydim) };
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

        private Place GetRandomPlaces(
            Place[,] map, int x, int y, int xdim, int ydim)
        {
            Place selected;

            switch (rdn.Next(0, 5))
            {
                case 0:
                    selected =
                        map[x ,y + 1 >= ydim ? 0 : y + 1];
                    break;
                case 1:
                    selected =
                        map[x + 1 >= xdim ? 0 : x + 1, y];
                    break;
                case 2:
                    selected =
                        map[x, y - 1 < 0 ? ydim - 1 : y - 1];
                    break;
                case 3:
                    selected =
                        map[x - 1 < 0 ? xdim - 1: x - 1, y];
                    break;
                default:
                    selected = new Place(Species.Empty);
                    break;
            }

            return selected;
        }
    }
}
