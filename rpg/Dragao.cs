class Dragao : Monstro
{
    public Dragao() : base("Dragão", 300, 15, 5, 200, 200) { }

    public override Monstro EncontrarMonstro()
    {
        return new Dragao();
    }
}
