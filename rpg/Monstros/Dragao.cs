class Dragao : Monstro
{
    public Dragao() : base("Dragão Bebê", 200, 15, 5, 100, 100) { }

    public override Monstro EncontrarMonstro()
    {
        return new Dragao();
    }
}
