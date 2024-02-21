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
                int ataque = int.Parse(Console.ReadLine());

                Console.Write("Quantos pontos você deseja adicionar à Defesa? ");
                int defesa = int.Parse(Console.ReadLine());

                Console.Write("Quantos pontos você deseja adicionar ao HP? ");
                int hp = int.Parse(Console.ReadLine());

                if (ataque + defesa + hp <= pontos)
                {
                    this.ataque += ataque;
                    this.defesa += defesa;
                    this.hp += hp + 30; // O mínimo de hp é 30
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
            else if (item == "Espada")
            {
                this.ataque += 10;
            }
            else if (item == "Escudo")
            {
                this.defesa += 10;
            }
            else if (item == "Armadura")
            {
                this.defesa += 20;
            }
            Console.WriteLine($"\nVocê comprou {item}!");
        }
        else
        {
            Console.WriteLine("\nVocê não tem ouro suficiente!");
        }
    }
}
