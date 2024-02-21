class Terreno
{
    public string nome;
    private static Random random = new Random();

    public Terreno(string nome)
    {
        this.nome = nome;
    }

    public void Boss(Personagem jogador){
        Console.WriteLine("Você passa pela passagem secreta na montanha e se depara com Smaug, o Dragão Dourado\nA batalha começa:");
        Monstro Boss = GeradorDeMonstros.Boss();
        Console.WriteLine($"\n{Boss.nome} apareceu!");
        Batalhar.batalhar(jogador, Boss);

        if (Boss.hp <= 0)
        {
            Console.WriteLine("\nMissão cumprida, você venceu o jogo!!!.");
        }
        else
        {
            Console.WriteLine("\nMissão falhou. Tente novamente mais tarde.");
        }
    }

    //Missões

    public void Missao(Personagem jogador)
    {
        List<string> missoes = new List<string>
            {
                "\nMulher desconhecida: -Minha filha sofre de uma doença terrível, por favor encontre uma planta para ajudar a curá-la\n",
                "\nGarota desconhecida: Perdi meu cãozinho no horizonte, poderia me ajudar a encontrá-lo?\n",
                "\nAldeão: Ouvi dizer que por estas terras existe um tesouro enterrado, que me ajudar a procurar?\n",
                "\nAldeão: Estes malditos insetos... poderia me trazer um pouco de veneno para me livrar deles?\n",
                "\nCriança desconhecida: Me perdi dos meus pais, poderia me ajudar a encontrá-los?\n",
                "\nAldeão: Ei amigo se me ajudar com estes pesos posso recompensá-lo\n",
                "\nSoldado: Se me vencer em um duelo irei recompensá-lo",
                "\nTroll: Ei traz planta pra mim, eu te darei ouro ",
                "\nAnão: Preciso de madeira para meu machado, consegue me ajudar com isso?\n",
                "\nMago: Não encontro minha pedra encantada, me ajudaria com isso?\n",
                "\nHomem desconhecido: Preciso cortar estas madeiras, mas é impossível sozinho, poderia me ajudar?",
            };


        string missaoAtual = missoes[random.Next(missoes.Count)];
        Console.WriteLine($"\nMissão: {missaoAtual}");
        Console.Write("\nAperte qualquer tecla para tentar completar essa missão");
        string sese = Console.ReadLine()!;

        Console.WriteLine("\nUma criatura apareceu!");
        Monstro monstroEspecial = GeradorDeMonstros.CriarMonstro();
        Console.WriteLine($"\nUm {monstroEspecial.nome} selvagem apareceu!");
        Batalhar.batalhar(jogador, monstroEspecial);

        if (monstroEspecial.hp <= 0)
        {
            jogador.hp += 30;
            jogador.ataque += 20;
            jogador.defesa += 20;
            Console.WriteLine("\nSeus atributos foram aumentados!");

            Console.WriteLine("\nMissão completada com sucesso!");
            int ouro = random.Next(5, 30);
            jogador.ouro += ouro;
            Console.WriteLine($"\nVocê ganhou {ouro} moedas de ouro!");

            Console.WriteLine("\nMissão cumprida, hora de voltar ao caminho.");
        }
        else
        {
            Console.WriteLine("\nMissão falhou. Tente novamente mais tarde.");
        }
    }
}