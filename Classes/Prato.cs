using System;
using System.Globalization;

namespace DIO.ESTOQUE
{
    public class Prato : EntidadeBase
    {
        // Atributos

        private Categoria Categoria { get; set; }

        private string Nome { get; set; }

        private int QuantidadePessoasServidas { get; set; }
        
        private double Preco { get; set; }

        private bool Excluido {get; set;}
        
        
        // Métodos

        public Prato(int id, Categoria categoria, string nome, int quantidadePessoasServidas, double preco)
        {

            this.Id = id;
			this.Categoria = categoria;
			this.Nome = nome;
			this.QuantidadePessoasServidas = quantidadePessoasServidas;
			this.Preco = preco;
            this.Excluido = false;

        }
        
        public override string ToString()
		{
			
            string retorno = "";
            retorno += "Categoria: " + this.Categoria + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Quantidade de Pessoas Servidas: " + this.QuantidadePessoasServidas + Environment.NewLine;
            retorno += "Preço: R$ " + this.Preco.ToString("F2", CultureInfo.InvariantCulture) + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaNome()
		{
			return this.Nome;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}