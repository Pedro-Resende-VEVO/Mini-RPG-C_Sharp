class Troll : Monstro
{
    public Troll() : base("Troll", 60, 15, 2, 10, 10) { }



    public override Monstro EncontrarMonstro()
    {
        return new Troll();
    }
}