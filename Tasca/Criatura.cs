namespace Peixera
{
    public abstract class Criatura
    {
        public int      X        { get; set; }
        public int      Y        { get; set; }
        public Sexe     Genere   { get; set; }
        public Direccio Moviment { get; set; }
        public bool     EstaMort { get; set; } = false;

        protected Criatura(int x, int y, Sexe sexe, Direccio dir)
        {
            X = x; Y = y; Genere = sexe; Moviment = dir;
        }

        public abstract void Moure(int mida);
    }
}