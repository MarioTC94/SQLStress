using SQLStress.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLStress.Business.Logic {
	public class SqlCallBL : ISqlCall {
		public bool RequestTo(int cant, string tableName) {
			throw new NotImplementedException();
		}

		public bool RequestTo(int cant) {
			throw new NotImplementedException();
		}

		public int RequestWithThread(int cantThreads, int cantRequestByThread, string TableName, string DatabaseName) {
			throw new NotImplementedException();
		}
	}
}
