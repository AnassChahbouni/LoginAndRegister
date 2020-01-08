/*
 * Created by SharpDevelop.
 * User: etu
 * Date: 08/01/2020
 * Time: 15:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace LoginAndRegister
{
	/// <summary>
	/// Description of Login.
	/// </summary>
	public class Login
	{
		public Login()
		{
		}
		
		public static void logIn(string email, string password) {
			DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `email` = @email and `password` = @pass", db.getConnection());

            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if the user exists or not
            if (table.Rows.Count > 0) {
                Console.WriteLine("Hello Word!");
            }else {
            	Console.WriteLine("Wrong Login or Password!");
            }
		}
            
	}
}
