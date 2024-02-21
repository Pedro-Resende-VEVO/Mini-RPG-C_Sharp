static Monstro EncontrarMonstro()
    {
        List<Monstro> monstros = new List<Monstro>
        {
            new Monstro("Lobo", 40, 5, 2, 10, 10),
            new Monstro("Troll", 80, 15, 2, 10, 10),
            new Monstro("Orc", 40, 5, 2, 20, 20),
            new Monstro("Elfo negro", 200, 3, 2, 100, 100),
            new Monstro("Mago sombrio", 40, 5, 2, 50, 50),
            new Monstro("Goblin", 50, 7, 3, 15, 15),
            new Monstro("Dragão", 300, 15, 5, 200, 200)
        };

        int randomIndex = random.Next(monstros.Count);
        return monstros[randomIndex];
    }