namespace Peixera
{
    public class Pop : Criatura
    {
        public Pop(int x, int y) : base(x, y, Sexe.Null, Direccio.Est) { }

        public override void Moure(int mida)
        {
            if (X == mida - 1 && Moviment == Direccio.Est) Moviment = Direccio.Sud;
            else if (Y == mida - 1 && Moviment == Direccio.Sud) Moviment = Direccio.Oest;
            else if (X == 0 && Moviment == Direccio.Oest) Moviment = Direccio.Nord;
            else if (Y == 0 && Moviment == Direccio.Nord) Moviment = Direccio.Est;

            switch (Moviment)
            {
                case Direccio.Nord: Y--; break;
                case Direccio.Sud: Y++; break;
                case Direccio.Est: X++; break;
                case Direccio.Oest: X--; break;
            }
        }
    }
}