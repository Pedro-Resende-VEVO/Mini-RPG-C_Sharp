class Troll : Monstro
{
    public Troll() : base("Troll", 80, 15, 2, 10, 10) { }



    public override Monstro EncontrarMonstro()
    {
        return new Troll();
    }
}