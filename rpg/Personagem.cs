class Personagem
{
    public string nome;
    public int hp;
    public int ataque;
    public int defesa;
    public int ouro;
    public List<string> inventario;

    public Personagem(string nome)
    {
        this.nome = nome;
        this.hp = 50;
        this.ataque = 0;
        this.defesa = 0;
        this.ouro = 0;
        this.inventario = new List<string>();
    }
    // Distribuição inicial de pontos
    public void DistribuirAtributos()
    {
        int pontos = 20;
        while (pontos > 0)
        {
            Console.WriteLine($"\nPontos restantes: {pontos}");
            Console.WriteLine("Distribua seus pontos entre Ataque, Defesa e HP.");

            try
            {
                Console.Write("Quantos pontos você deseja adicionar ao Ataque? ");
                int ataque = Convert.ToInt32(Console.ReadLine());

                Console.Write("Quantos pontos você deseja adicionar à Defesa? ");
                int defesa = Convert.ToInt32(Console.ReadLine());

                Console.Write("Quantos pontos você deseja adicionar ao HP? ");
                int hp = Convert.ToInt32(Console.ReadLine());

                if (ataque + defesa + hp <= pontos)
                {
                    this.ataque += ataque;
                    this.defesa += defesa;
                    this.hp += hp;
                    pontos -= (ataque + defesa + hp);
                }
                else
                {
                    Console.WriteLine("\nVocê tentou distribuir mais pontos do que tinha disponível. Tente novamente.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nEntrada inválida. Use apenas números. Tente novamente.");
            }
        }

        Console.WriteLine($"\nAtributos definidos! Ataque: {this.ataque}, Defesa: {this.defesa}, HP: {this.hp}");
    }

    //Efeito dos itens
    public void ComprarItem(string item, int custo)
    {
        if (this.ouro >= custo)
        {
            this.ouro -= custo;
            if (item == "Poção de Cura")
            {
                this.hp += 50;
                Console.WriteLine("\nVocê usou uma Poção de Cura e recuperou 50 pontos de vida!");
            }
            else if (item == "Espada de Madeira")
            {
                this.ataque += 10;
            }
            else if (item == "Espada Longa")
            {
                this.ataque += 25;
            }
            else if (item == "Espada Flamejante")
            {
                this.ataque += 40;
            }
            else if (item == "Escudo de Madeira")
            {
                this.defesa += 10;
            }
            else if (item == "Escudo Resistente")
            {
                this.defesa += 30;
            }
            else if (item == "Escudo de Magma")
            {
                this.defesa += 50;
            }
            else if (item == "Armadura de Madeira")
            {
                this.defesa += 20;
            }
            else if (item == "Armadura de Ferro Polido")
            {
                this.defesa += 40;
            }
            else if (item == "Armadura Vulcânica")
            {
                this.defesa += 60;
            }
            Console.WriteLine($"\nVocê comprou {item}!");
        }
    }
}