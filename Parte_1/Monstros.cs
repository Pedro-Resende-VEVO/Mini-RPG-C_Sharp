class Monstro
    {
        public string nome;
        public int hp;
        public int ataque;
        public int defesa;
        public int recompensa;
        public int ouro;

        public Monstro(string nome, int hp, int ataque, int defesa, int recompensa, int ouro)
        {
            this.nome = nome;
            this.hp = hp;
            this.ataque = ataque;
            this.defesa = defesa;
            this.recompensa = recompensa;
            this.ouro = ouro;
        }

        public int Atacado(int poder)
        {
            int dano = Math.Max(poder - this.defesa, 0);
            this.hp -= dano;
            return dano;
        }
    }
