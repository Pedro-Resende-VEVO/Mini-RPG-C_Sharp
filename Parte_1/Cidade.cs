 static void Cidade(Personagem jogador)
    {
        Console.WriteLine("\nBem-vindo à cidade!");
        while (true)
        {
            Console.WriteLine("\n1. Comprar Poção de Cura (30 ouro)");
            Console.WriteLine("2. Comprar Espada (50 ouro)");
            Console.WriteLine("3. Comprar Escudo (40 ouro)");
            Console.WriteLine("4. Comprar Armadura (80 ouro)");
            Console.WriteLine("5. Sair da loja");

            Console.Write("\nO que você gostaria de fazer? ");
            int escolha = int.Parse(Console.ReadLine());

            if (escolha == 1)
            {
                jogador.ComprarItem("Poção de Cura", 30);
            }
            else if (escolha == 2)
            {
                jogador.ComprarItem("Espada", 50);
            }
            else if (escolha == 3)
            {
                jogador.ComprarItem("Escudo", 40);
            }
            else if (escolha == 4)
            {
                jogador.ComprarItem("Armadura", 80);
            }
            else if (escolha == 5)
            {
                Console.WriteLine("\nAté logo!");
                break;
            }
            else
            {
                Console.WriteLine("\nOpção inválida!");
            }
        }
    }