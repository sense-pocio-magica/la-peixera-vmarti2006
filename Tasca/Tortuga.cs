namespace Peixera
{
    // Misma lógica de movimiento que Peix, pero es resistente al Tauro
    public class Tortuga : Peix
    {
        public Tortuga(int x, int y, Sexe sexe, Direccio dir)
            : base(x, y, sexe, dir) { }
    }
}