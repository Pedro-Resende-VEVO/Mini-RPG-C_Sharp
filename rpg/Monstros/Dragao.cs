class Dragao : Monstro
{
    public Dragao() : base("Dragão Bebê", 50, 15, 5, 100, 100) { }

    public override Monstro EncontrarMonstro()
    {
        return new Dragao();
    }
}
