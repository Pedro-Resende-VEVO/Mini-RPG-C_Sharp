using System;

class Cidade
{
    public static void cidade(Personagem jogador)
    {
        Console.WriteLine("\nBem-vindo à cidade!");
        bool sairDaLoja = false;
        
        while (!sairDaLoja)
        {
            Console.WriteLine("\n1. Comprar Poção de Cura (30 ouro)");
            Console.WriteLine("2. Comprar Espada (50 ouro)");
            Console.WriteLine("3. Comprar Escudo (40 ouro)");
            Console.WriteLine("4. Comprar Armadura (80 ouro)");
            Console.WriteLine("5. Sair da loja");

            Console.Write("\nO que você gostaria de fazer? ");
            string input = Console.ReadLine();
            int escolha;

            if (!int.TryParse(input, out escolha) || escolha < 1 || escolha > 5)
            {
                Console.WriteLine("\nOpção inválida!");
                continue;
            }

            switch (escolha)
            {
                case 1:
                    ComprarItem(jogador, "Poção de Cura", 30);
                    break;
                case 2:
                    ComprarItem(jogador, "Espada", 50);
                    break;
                case 3:
                    ComprarItem(jogador, "Escudo", 40);
                    break;
                case 4:
                    ComprarItem(jogador, "Armadura", 80);
                    break;
                case 5:
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
