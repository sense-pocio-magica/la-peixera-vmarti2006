namespace Peixera
{
    public class Peix : Criatura
    {
        public Peix(int x, int y, Sexe sexe, Direccio dir) : base(x, y, sexe, dir) { }

        public override void Moure(int mida)
        {
            switch (Moviment)
            {
                case Direccio.Nord: Y = (Y - 1 + mida) % mida;
                break;
                case Direccio.Sud: Y = (Y + 1) % mida;
                break;
                case Direccio.Est: X = (X + 1) % mida;
                break;
                case Direccio.Oest: X = (X - 1 + mida) % mida;
                break;
            }
        }
    }
}