using System;
using System.Collections.Generic;

class Jogo
{
    private static Random random = new Random();

    public static void iniciarJogo()
    {
        Console.Write("Digite o nome do seu personagem: ");
        string nome = Console.ReadLine()!;
        Personagem jogador = new Personagem(nome);
        jogador.DistribuirAtributos();

        List<Terreno> terrenos = new List<Terreno>
        {
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
                    Terreno lugarEscolhido = terrenos[escolha - 1];
                    int chanceBatalha = random.Next(1, 3); // 50% de chance: 1 ou 2
                    if (chanceBatalha == 1)
                    {
                        
                       Monstro monstro = GeradorDeMonstros.CriarMonstro();
                        Console.WriteLine($"\nUm {monstro.nome} selvagem apareceu!");
                        Batalhar.batalhar(jogador, monstro);
                    }
                    lugarEscolhido.Missao(jogador);
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
            Console.WriteLine("\nVocê escolheu sair. Fim de jogo!");
        }
    }

    private static void ExibirStatusDoJogador(Personagem jogador)
    {
        Console.WriteLine($"\n\nStatus de {jogador.nome}\nHP: {jogador.hp}\nAtaque: {jogador.ataque}\nDefesa: {jogador.defesa}\nOuro: {jogador.ouro}\n");
    }

    private static void ExibirOpcoesDeTerreno(List<Terreno> terrenos)
    {
        Console.WriteLine("Onde você gostaria de ir?");
        for (int i = 0; i < terrenos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {terrenos[i].nome}");
        }
    }

    private static void ExibirMensagemDeErro()
    {
        Console.WriteLine("\nEscolha inválida!\n");
    }
}
