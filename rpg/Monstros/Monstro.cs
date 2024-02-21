public abstract class Monstro
    {
        public string nome;
        public double hp;
        public double ataque;
        public double defesa;
        public double recompensa;
        public double ouro;

        public Monstro(string nome, double hp, double ataque, double defesa, double recompensa, double ouro)
        {
            this.nome = nome;
            this.hp = hp;
            this.ataque = ataque;
            this.defesa = defesa;
            this.recompensa = recompensa;
            this.ouro = ouro;
        }

        public double Atacado(double poder)
        {
            double dano = Math.Max(poder - this.defesa, 0);
            this.hp -= dano;
            return dano;
        }

        // Método abstrato para encontrar um monstro
        public abstract Monstro EncontrarMonstro();
    }

