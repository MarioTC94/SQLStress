using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SQLStress.Data;

namespace SQLStress.Business {
	public class Consultas {

		public int cantidad = 0;
		public SQLDatabase conexion = new SQLDatabase();
		public bool Excepcion;

		public void CantidadConsultas() {
			var Hilo = new Thread[cantidad];

			for (int i = 0; i < cantidad; i++) {
				Hilo[i] =
						new Thread(new ThreadStart((Action) ( () => {
							try {
								conexion.OpenConnection();
							} catch (Exception) {
								Excepcion = true;
							}
						} )));
			}

			for (int i = 0; i < 100; i++) {
				Hilo[i].Start();
			}
			for (int i = 0; i < 100; i++) {
				Hilo[i].Join();
			}

			Excepcion = false;
		}
	}
}

