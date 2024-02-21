using System;
using System.Collections.Generic;

class Jogo
{
    private static Random random = new Random();

    public static void iniciarJogo()
    {
        Console.Write("Digite o nome do seu personagem: ");
        string nome = Console.ReadLine()!;
        if (nome == "")
        {
            nome = "Desconhecido";
        }
        Personagem jogador = new Personagem(nome);
        jogador.DistribuirAtributos();

        List<Terreno> terrenos = new List<Terreno>
        {
            new Terreno("Área do Boss"),
            new Terreno("Floresta"),
            new Terreno("Montanha"),
            new Terreno("Caverna")
        };

        bool jogoAtivo = true;
        while (jogador.hp > 0 && jogoAtivo)
        {
            ExibirStatusDoJogador(jogador);
            ExibirOpcoesDeTerreno(terrenos);

            Console.WriteLine($"{terrenos.Count + 1}. Cidade");
            Console.WriteLine($"{terrenos.Count + 2}. Sair");

            int escolha;
            if (int.TryParse(Console.ReadLine(), out escolha))
            {
                if (escolha >= 1 && escolha <= terrenos.Count)
                {
                    Terreno lugarEscolhido = terrenos[escolha];
                    int chanceBatalha = random.Next(1, 4); // 33% de chance: 1 a 3
                    if (chanceBatalha == 1)
                    {

                        Monstro monstro = GeradorDeMonstros.CriarMonstro();
                        Console.WriteLine($"\nUm {monstro.nome} apareceu no caminho!");
                        Batalhar.batalhar(jogador, monstro);

                        if (monstro.hp <= 0)
                        {
                            jogador.hp += 20;
                            jogador.ataque += 10;
                            jogador.defesa += 10;
                            Console.WriteLine("\nSeus atributos foram aumentados!");
                            ExibirStatusDoJogador(jogador);
                        }
                    }

                    if (lugarEscolhido.nome == "Área do Boss")
                    {
                        lugarEscolhido.Boss(jogador);
                        jogoAtivo = false;
                    }
                    else
                    {
                        lugarEscolhido.Missao(jogador);
                        terrenos.Remove(lugarEscolhido); //Remove o lugar já passado da lista
                    }

                }
                else if (escolha == terrenos.Count + 1)
                {
                    Cidade.cidade(jogador); // Chama o método da classe Cidade
                }
                else if (escolha == terrenos.Count + 2)
                {
                    jogoAtivo = false; // Trata a opção de sair do jogo
                }
                else
                {
                    ExibirMensagemDeErro();
                }
            }
            else
            {
                ExibirMensagemDeErro();
            }
        }

        if (jogador.hp <= 0)
        {
            Console.WriteLine("\nVocê morreu. Fim de jogo!");
        }
        else
        {
            Console.WriteLine("\nFim de jogo!");
        }
    }

    private static void ExibirStatusDoJogador(Personagem jogador)
    {
        Console.WriteLine($"\n\nStatus de {jogador.nome}\nHP: {jogador.hp}\nAtaque: {jogador.ataque}\nDefesa: {jogador.defesa}\nOuro: {jogador.ouro}\n");
    }

    private static void ExibirOpcoesDeTerreno(List<Terreno> terrenos)
    {
        Console.WriteLine("Onde você gostaria de ir?");
        if (terrenos.Count == 2)
        {
            for (int i = 0; i < terrenos.Count; i++)
            {
                Console.WriteLine($"{i}. {terrenos[i].nome}");
            }
        }
        else
        {
            for (int i = 1; i < terrenos.Count; i++)
            {
                Console.WriteLine($"{i}. {terrenos[i].nome}");
            }
        }
    }

    private static void ExibirMensagemDeErro()
    {
        Console.WriteLine("\nEscolha inválida!\n");
    }
}
