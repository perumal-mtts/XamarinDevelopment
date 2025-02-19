﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ChatAppService.Services
{
	public class BaseRepository
	{
		public BaseRepository()
		{
			var connStr = ConfigurationManager.ConnectionStrings["MyContext"];

			if (connStr == null)
			{
				connection = new MySql.Data.MySqlClient.MySqlConnection("Server=127.0.0.1;Database=chat;Uid=root;Pwd=;");
			}
			else
			{
				connection = new MySql.Data.MySqlClient.MySqlConnection(connStr.ConnectionString);
			}
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
