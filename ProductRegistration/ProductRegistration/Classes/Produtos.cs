namespace ProductRegistration.Classes
{
    internal class Produtos : EntidadeBase
    {
        private string nome {get; set; }
        private int estoque {get; set; }
        private double valor {get; set; }
        private bool excuido { get; set; }

        public Produtos(int id, string name, int estoque, double valor)
        {
            this.id = id;
            this.nome = name;
            this.estoque = estoque;
            this.valor = valor;
            this.excuido = false;
        }

        public override string ToString()
        {
            string resposta = "";
            resposta += "Nome: " + this.nome + Environment.NewLine;
            resposta += "Estoque: " + this.estoque + Environment.NewLine;
            resposta += "Valor: " + this.valor + Environment.NewLine;
            resposta += "excluido: " + this.excuido;
            return resposta;
        }

        public string retornaNome(){
            return this.nome;
        }
        public int retornaId(){
            return this.id;
        }  

        public bool retornaExcluido(){
            return this.excuido;
        }

        public void Excluir() {
            this.excuido = true;
        }

    }
}
