namespace LP2_RockPaperScissor.Common
{
    public class Place
    {
        private Species specie;

        public Place(Species specie) => this.specie = specie;

        public Species GetSpecie() => specie;
    }
}
