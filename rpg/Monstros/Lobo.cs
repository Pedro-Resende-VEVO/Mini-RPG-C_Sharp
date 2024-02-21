    class Lobo : Monstro {
        public Lobo() : base("Lobo", 40, 5, 2, 10, 10) { }

        // Implementação do método abstrato
        public override Monstro EncontrarMonstro() {
            return new Lobo();
        }
    }

