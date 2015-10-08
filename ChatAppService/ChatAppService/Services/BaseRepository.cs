using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ChatAppService.Services
{
	public class BaseRepository
	{
		public BaseRepository()
		{
			connection = new MySql.Data.MySqlClient.MySqlConnection("Server=127.0.0.1;Database=ChatApp;Uid=root;Pwd=;");
		}

		protected MySqlConnection connection
		{
			get;
			set;
		}

		protected MySqlCommand command
		{
			get;
			set;
		}

		protected MySqlDataReader reader
		{
			get;
			set;
		}
	}
}
