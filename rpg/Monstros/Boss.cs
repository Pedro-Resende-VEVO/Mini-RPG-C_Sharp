class Boss : Monstro
{
    public Boss() : base("Dragão Brilhante", 200, 30, 50, 200, 200) { }

    public override Monstro EncontrarMonstro()
    {
        return new Boss();
    }
}
