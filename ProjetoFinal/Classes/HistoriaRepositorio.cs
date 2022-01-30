using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
	public class HistoriaRepositorio : IRepositorio<Historia>
	{
        private List<Historia> listaHistoria = new List<Historia>();
		public void Atualiza(int id, Historia objeto)
		{
			listaHistoria[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaHistoria[id].Excluir();
		}

		public void Insere(Historia objeto)
		{
			listaHistoria.Add(objeto);
		}

		public List<Historia> Lista()
		{
			return listaHistoria;
		}

		public int ProximoId()
		{
			return listaHistoria.Count;
		}

		public Historia RetornaPorId(int id)
		{
			return listaHistoria[id];
		}
	}
}