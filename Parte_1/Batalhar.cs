static void Batalhar(Personagem jogador, Monstro monstro)
    {
        Console.WriteLine($"\nUm {monstro.nome} apareceu!");
        while (jogador.hp > 0 && monstro.hp > 0)
        {
            Console.WriteLine($"\n\n Status \n hp:{jogador.hp} \n Ataque:{jogador.ataque} \n Defesa:{jogador.defesa} \n Ouro:{jogador.ouro}\n\n\n");
            // Ação do jogador
            Console.Write("Você deseja Atacar, Defender ou Fugir? ");
            string acaoJogador = Console.ReadLine().ToLower();

            if (acaoJogador == "fugir")
            {
                if (random.NextDouble() > 0.7) // 30% de chance de fuga bem-sucedida
                {
                    Console.WriteLine("Você conseguiu fugir!");
                    return;
                }
                else
                {
                    Console.WriteLine("A fuga falhou!");
                    acaoJogador = "atacar"; // Se a fuga falhar, o jogador ataca automaticamente
                }
            }

            string[] acoesMonstro = { "atacar", "defender" };
            string acaoMonstro = acoesMonstro[random.Next(acoesMonstro.Length)];

            bool critico = random.NextDouble() < 0.1; // 10% de chance de acerto crítico

            if (acaoJogador == "atacar" && acaoMonstro == "atacar")
            {
                int dano = CalcularDano(jogador, monstro, critico);
                Console.WriteLine($"Você causou {dano} de dano ao {monstro.nome}.");
                monstro.hp -= dano;

                dano = CalcularDano(monstro, jogador);
                Console.WriteLine($"{monstro.nome} te atacou e causou {dano} de dano.");
                jogador.hp -= dano;
            }
            else if (acaoJogador == "atacar" && acaoMonstro == "defender")
            {
                int dano = CalcularDano(jogador, monstro, critico);
                Console.WriteLine($"Você causou {dano} de dano ao {monstro.nome}.");
                monstro.hp -= dano;
            }
            else if (acaoJogador == "defender" && acaoMonstro == "atacar")
            {
                int dano = CalcularDano(monstro, jogador);
                Console.WriteLine($"{monstro.nome} te atacou, mas você se defendeu e recebeu apenas {dano} de dano.");
                jogador.hp -= dano;
            }
            else if (acaoJogador == "defender" && acaoMonstro == "defender")
            {
                Console.WriteLine("Ambos escolheram se defender, nada aconteceu!");
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
