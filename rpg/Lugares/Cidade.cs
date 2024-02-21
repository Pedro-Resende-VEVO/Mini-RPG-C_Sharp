using System;

class Cidade
{
    public static void cidade(Personagem jogador)
    {
        Console.WriteLine("\nBem-vindo à cidade!");
        bool sairDaLoja = false;

        while (!sairDaLoja)
        {
            Console.WriteLine("\n1. Poção de Cura (15 ouro)");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("2. Espada de Madeira (50 ouro)");
            Console.WriteLine("3. Espada Longa (70 ouro)");
            Console.WriteLine("4. Espada Flamejante (90 ouro)");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("5. Escudo de Madeira (40 ouro)");
            Console.WriteLine("6. Escudo Resistente (60 ouro)");
            Console.WriteLine("7. Escudo de Magma (75 ouro)");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("8. Armadura de Madeira(50 ouro)");
            Console.WriteLine("9. Armadura de Ferro Polido(70 ouro)");
            Console.WriteLine("10. Armadura Vulcânica(85 ouro)");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("11. Sair da loja");

            Console.Write("\nO que você gostaria de fazer? ");
            string input = Console.ReadLine()!;
            int escolha;

            if (!int.TryParse(input, out escolha) || escolha < 1 || escolha > 11)
            {
                Console.WriteLine("\nOpção inválida!");
                continue;
            }

            switch (escolha)
            {
                case 1:
                    ComprarItem(jogador, "Poção de Cura", 15);
                    break;
                case 2:
                    ComprarItem(jogador, "Espada de Mandeira", 50);
                    break;
                case 3:
                    ComprarItem(jogador, "Espada Longa", 70);
                    break;
                case 4:
                    ComprarItem(jogador, "Espada Flamejante", 90);
                    break;
                case 5:
                    ComprarItem(jogador, "Escudo de Madeira", 40);
                    break;
                case 6:
                    ComprarItem(jogador, "Escudo Resistente", 60);
                    break;
                case 7:
                    ComprarItem(jogador, "Escudo de Magma", 75);
                    break;
                case 8:
                    ComprarItem(jogador, "Armadura de Madeira", 50);
                    break;
                case 9:
                    ComprarItem(jogador, "Armadura de Ferro Polido", 70);
                    break;
                case 10:
                    ComprarItem(jogador, "Armadura Vulcânica", 85);
                    break;
                case 11:
                    Console.WriteLine("\nAté logo!");
                    sairDaLoja = true;
                    break;
            }
        }
    }

    private static void ComprarItem(Personagem jogador, string item, int custo)
    {
        if (jogador.ouro >= custo)
        {
            jogador.ComprarItem(item, custo);
            Console.WriteLine($"{item} comprado com sucesso! Restam {jogador.ouro} de ouro.");
        }
        else
        {
            Console.WriteLine($"Você não tem ouro suficiente para comprar {item}. Necessário: {custo}, Disponível: {jogador.ouro}.");
        }
    }
}
