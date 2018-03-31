using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLStress.Business.Interfaces {
	public interface ISqlCall {

		bool RequestTo(int cant);

		bool RequestTo(int cant, String tableName);

		int RequestWithThread(int cantThreads, int cantRequestByThread, String TableName, String DatabaseName);
	}
}
