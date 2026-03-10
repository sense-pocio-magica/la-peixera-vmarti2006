namespace Peixera
{
    public class Pop : Criatura
    {
        public Pop(int x, int y)
            : base(x, y, Sexe.Null, Direccio.Est) { }

        public override void Moure(int mida)
        {
            // 1. Mover
            switch (Moviment)
            {
                case Direccio.Est:  X++; break;
                case Direccio.Sud:  Y++; break;
                case Direccio.Oest: X--; break;
                case Direccio.Nord: Y--; break;
            }

            // 2. Girar al llegar a una esquina (para el turno siguiente)
            if      (X >= mida-1 && Moviment == Direccio.Est)  Moviment = Direccio.Sud;
            else if (Y >= mida-1 && Moviment == Direccio.Sud)  Moviment = Direccio.Oest;
            else if (X <= 0      && Moviment == Direccio.Oest) Moviment = Direccio.Nord;
            else if (Y <= 0      && Moviment == Direccio.Nord) Moviment = Direccio.Est;
        }
    }
}