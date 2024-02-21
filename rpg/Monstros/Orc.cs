class Orc : Monstro
{
    public Orc() : base("Orc", 40, 5, 2, 20, 20) { }



    public override Monstro EncontrarMonstro()
    {
        return new Orc();
    }
}
