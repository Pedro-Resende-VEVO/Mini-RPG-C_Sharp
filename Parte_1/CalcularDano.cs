static int CalcularDano(Personagem atacante, Monstro defensor, bool critico = false)
    {
        int danoBase = atacante.ataque - defensor.defesa;
        if (critico)
        {
            danoBase += (int)(0.5 * atacante.ataque);
        }
        return Math.Max(danoBase, 0);
    }