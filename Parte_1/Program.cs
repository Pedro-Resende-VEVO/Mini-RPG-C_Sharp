using System;
using System.Collections.Generic;

class Program
{
    static Random random = new Random();
    static void IniciarJogo()
    {
        Console.Write("Digite o nome do seu personagem: ");
        string nome = Console.ReadLine();
        Personagem jogador = new Personagem(nome);
        jogador.DistribuirAtributos();
        List<Terreno> terrenos = new List<Terreno>
        {
            new Terreno("Floresta"),
            new Terreno("Montanha"),
            new Terreno("Caverna"),
            new Terreno("Cidade"),
            new Terreno("Sair")
        };

        while (jogador.hp > 0)
        {
            Console.WriteLine($"\n\n Status de {jogador.nome}\n hp:{jogador.hp} \n Ataque:{jogador.ataque} \n Defesa:{jogador.defesa} \n Ouro:{jogador.ouro}\n");
            Console.WriteLine("\nOnde você gostaria de ir?");
            for (int i = 0; i < terrenos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {terrenos[i].nome}");
            }

            int escolha;
            if (int.TryParse(Console.ReadLine(), out escolha))
            {
                if (escolha == terrenos.Count)
                {
                    break;
                }

                if (escolha >= 1 && escolha <= terrenos.Count)
                {
                    Terreno lugarEscolhido = terrenos[escolha - 1];
                    if (lugarEscolhido.nome == "Sair")
                    {
                        break;
                    }

                    if (lugarEscolhido is Terreno)
                    {
                        int chanceBatalha = random.Next(1, 3); // 50% de chance: 1 ou 2
                        if (chanceBatalha == 1)
                        {
                            Monstro monstro = EncontrarMonstro();
                            Console.WriteLine($"\nUm {monstro.nome} selvagem apareceu!");
                            Batalhar(jogador, monstro);
                            lugarEscolhido.Missao(jogador);
                        }
                        else
                        {
                            lugarEscolhido.Missao(jogador);
                        }
                    }
                    else
                    {
                        Cidade(jogador);
                    }
                }
                else
                {
                    Console.WriteLine("\nEscolha inválida!\n");
                }
            }
            else
            {
                Console.WriteLine("\nEscolha inválida!\n");
            }
        }

        Console.WriteLine("\nFim de jogo!");
    }

    static void Main(string[] args)
    {
        IniciarJogo();
    }
}
