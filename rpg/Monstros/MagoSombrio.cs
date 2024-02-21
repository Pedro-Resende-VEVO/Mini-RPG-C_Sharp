class MagoSombrio : Monstro
{
    public MagoSombrio() : base("Mago Sombrio", 40, 5, 2, 50, 50) { }


    public override Monstro EncontrarMonstro()
    {
        return new MagoSombrio();
    }
}
