class Goblin : Monstro
{
    public Goblin() : base("Goblin", 50, 7, 3, 15, 15) { }

    public override Monstro EncontrarMonstro()
    {
        return new Goblin();
    }
}
