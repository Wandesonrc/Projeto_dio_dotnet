using System;
using System.Collections.Generic;
using DIO.ESTOQUE.Interfaces;

namespace DIO.ESTOQUE
{
    public class RepositorioPrato : IRepositorio<Prato>
    {
        private List<Prato> listaPrato = new List<Prato>();

		public void Atualiza(int id, Prato objeto)
		{
			listaPrato[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaPrato[id].Excluir();
		}

		public void Insere(Prato objeto)
		{
			listaPrato.Add(objeto);
		}

		public List<Prato> Lista()
		{
			return listaPrato;
		}

		public int ProximoId()
		{
			return listaPrato.Count;
		}

		public Prato RetornaPorId(int id)
		{
			return listaPrato[id];
		}
        
    }
}