class Batalhar

{
    private static Random random = new Random();

    //Função de batalhar
    public static void batalhar(Personagem jogador, Monstro monstro)
    {
        Console.WriteLine($"\nUm {monstro.nome} apareceu!");
        while (jogador.hp > 0 && monstro.hp > 0)
        {
            Console.WriteLine($"\n\nStatus\nHP: {jogador.hp}\nAtaque: {jogador.ataque}\nDefesa: {jogador.defesa}\nOuro: {jogador.ouro}\n\n");

            // Mostra as opções do menu
            Console.WriteLine("Escolha sua ação:");
            Console.WriteLine("1 - Atacar");
            Console.WriteLine("2 - Dodge");
            Console.WriteLine("3 - Fugir");
            Console.Write("Opção: ");

            string acaoJogador;
            do
            {
                acaoJogador = Console.ReadLine()!;
                if (acaoJogador != "1" && acaoJogador != "2" && acaoJogador != "3")
                {
                    Console.WriteLine("Opção inválida. Por favor, escolha 1 para atacar, 2 para tentar dodge ou 3 para fugir.");
                    Console.Write("Opção: ");
                }
            } while (acaoJogador != "1" && acaoJogador != "2" && acaoJogador != "3");

            if (acaoJogador == "3") // Fugir
            {
                if (random.NextDouble() > 0.7) // 30% de chance de fuga bem-sucedida
                {
                    Console.WriteLine("Você conseguiu fugir!");
                    return;
                }
                else
                {
                    Console.WriteLine("A fuga falhou!");
                    acaoJogador = "1"; // Se a fuga falhar, o jogador ataca automaticamente
                }
            }

            string[] acoesMonstro = { "atacar", "defender" };
            string acaoMonstro = acoesMonstro[random.Next(acoesMonstro.Length)];

            bool critico = random.NextDouble() < 0.3; // 30% de chance de acerto crítico

            if (acaoJogador == "1") // Ataque
            {
                if (acaoMonstro == "atacar")
                {
                    int dano = CalcularDano(jogador, monstro, critico);
                    Console.WriteLine($"Você causou {dano} de dano ao {monstro.nome}.");
                    monstro.hp -= dano;

                    dano = CalcularDano(jogador, monstro);
                    Console.WriteLine($"{monstro.nome} te atacou e causou {dano} de dano.");
                    jogador.hp -= dano;
                }
                else // Monstro defende
                {
                    int dano = CalcularDano(jogador, monstro, critico);
                    Console.WriteLine($"Você causou {dano} de dano ao {monstro.nome}.");
                    monstro.hp -= dano;
                }
            }
            else if (acaoJogador == "2") // Dodge
            {
                if (acaoMonstro == "atacar")
                {
                    if (random.NextDouble() > 0.7) // 30% de chance de dodge bem-sucedida
                    {
                        int dano = CalcularDano(jogador, monstro, critico);
                        Console.WriteLine($"{monstro.nome} te atacou, mas você o atordoou e causou {dano} de dano ao {monstro.nome}.");
                        monstro.hp -= dano;
                        return;
                    }
                    else
                    {
                        int dano = CalcularDano(jogador, monstro);
                        Console.WriteLine($"{monstro.nome} te atacou, mas você errou o atordoamento e recebeu {dano} de dano.");
                        jogador.hp -= dano;
                    }
                }
                else // Monstro de defende
                {
                    Console.WriteLine($"{monstro.nome} se defende de seu atordoamento");
                }
            }

            if (monstro.hp <= 0)
            {
                Console.WriteLine($"Você derrotou o {monstro.nome}!");
                jogador.ouro += monstro.ouro;
                Console.WriteLine($"\nVocê ganhou {monstro.ouro} moedas de ouro!");
                return;
            }

            if (jogador.hp <= 0)
            {
                Console.WriteLine("Você foi derrotado!");
                return;
            }
        }
    }

    //Função de calcular dano
    static int CalcularDano(Personagem atacante, Monstro defensor, bool critico = false)
    {
        int danoBase = atacante.ataque - defensor.defesa;
        if (critico)
        {
            danoBase += (int)(0.5 * atacante.ataque);
        }
        return Math.Max(danoBase, 0);
    }
}