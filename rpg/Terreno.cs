class Terreno
    {
        public string nome;
        public int missoesCompletas;
        private static Random random = new Random();

        public Terreno(string nome)
        {
            this.nome = nome;
            this.missoesCompletas = 0;
        }
        //Missões

        public void Missao(Personagem jogador)
        {
            List<string> missoes = new List<string>
            {
                "\nMulher desconhecida:\n -Minha filha sofre de uma doença terrível, por favor encontre uma planta para ajudar a curá-la\n",
                "\nGarota desconhecida:\n Perdi meu cãozinho no horizonte, poderia me ajudar a encontrá-lo?\n",
                "\nAldeão:\n Ouvi dizer que por estas terras existe um tesouro enterrado, que me ajudar a procurar?\n",
                "\nAldeão:\n Estes malditos insetos... poderia me trazer um pouco de veneno para me livrar deles?\n",
                "\nCriança desconhecida:\n Me perdi dos meus pais, poderia me ajudar a encontrá-los?\n",
                "\nAldeão:\n Ei amigo se me ajudar com estes pesos posso recompensá-lo\n",
                "\nSoldado:\n Se me vencer em um duelo irei recompensá-lo",
                "\nTroll:\n Ei traz planta pra mim, eu te darei ouro ",
                "\nAnão:\n Preciso de madeira para meu machado, consegue me ajudar com isso?\n",
                "\nMago:\n Não encontro minha pedra encantada, me ajudaria com isso?\n",
                "\nHomem desconhecido: Preciso cortar estas madeiras, mas é impossível sozinho, poderia me ajudar?",
            };

            if (this.missoesCompletas < 15)
            {
                string missaoAtual = missoes[random.Next(missoes.Count)];
                Console.WriteLine($"\nMissão: {missaoAtual}");
                Console.Write("Você deseja tentar completar essa missão? (Sim/Não) ");
                string escolha = Console.ReadLine().ToLower();

                if (escolha == "sim")
                {
                    bool sucesso = random.NextDouble() > 0.3; // 70% de chance de sucesso
                    if (sucesso)
                    {
                        Console.WriteLine("\nMissão completada com sucesso!");
                        this.missoesCompletas++;
                        int ouro = random.Next(5, 20);
                        jogador.ouro += ouro;
                        Console.WriteLine($"\nVocê ganhou {ouro} moedas de ouro!");
                        if (this.missoesCompletas == random.Next(4, 15))
                        {
                            Console.WriteLine("\nUma criatura especial apareceu!");
                            Monstro monstroEspecial = new Boss();
                            Batalhar.batalhar(jogador, monstroEspecial);
                            if (monstroEspecial.hp <= 0)
                            {
                                jogador.hp += 20;
                                jogador.ataque += 5;
                                jogador.defesa += 5;
                                Console.WriteLine("\nSeus atributos foram aumentados!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nMissão falhou. Tente novamente mais tarde.");
                    }
                }
                else
                {
                    Console.WriteLine("\nTalvez da próxima vez!");
                }
            }
            else
            {
                Console.WriteLine("\nVocê já completou todas as missões deste terreno!");
            }
        }
    }