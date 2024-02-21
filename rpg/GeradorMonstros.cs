using System;

public static class GeradorDeMonstros
{
    private static Random random = new Random();

    public static Monstro CriarMonstro()
    {
        int tipoMonstro = random.Next(0, 8); // Gera um número aleatório entre 0 e 7, correspondendo ao número de tipos de monstros
        switch (tipoMonstro)
        {
            case 0:
                return new Dragao();
            case 1:
                return new Boss();
            case 2:
                return new ElfoNegro();
            case 3:
                return new Goblin();
            case 4:
                return new Lobo();
            case 5:
                return new MagoSombrio();
            case 6:
                return new Orc();
            case 7:
                return new Troll();
            default:
                throw new Exception("Tipo de monstro desconhecido."); // Para segurança, mas nunca deve chegar aqui devido ao range do Next()
        }
    }
}
