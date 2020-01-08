/*
 * Created by SharpDevelop.
 * User: etu
 * Date: 08/01/2020
 * Time: 15:27
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
	/// Description of Register.
	/// </summary>
	public class Register
	{
		public Register()
		{
		}
		
		public static void addUser(string firstname, string lastname, string email, string password) {
			DB db = new DB();
	        MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`firstname`, `lastname`, `email`, `password`) VALUES (@fn, @ln, @email, @pass)", db.getConnection());
	
	        command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = firstname;
	        command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lastname;
	        command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
	        command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
	
	            // open the connection
	        db.openConnection();
	        
	        if(email == "" || password == "") {
	        	Console.WriteLine("Empty Email or Password, Retry!");
	        }else if(checkUsername(email)) {
	        	Console.WriteLine("Email already used, Retry!");
	        } else {
		        if (command.ExecuteNonQuery() == 1) {
		        	Console.WriteLine("Your Account Has Been Created");
	            }else {
		        	Console.WriteLine("Failed");
		        }
	        }
	        	// close the connection
            db.closeConnection();
		}
		
		public static Boolean checkUsername(string email) {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `email` = @email", db.getConnection());
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            // check if this username already exists in the database
            if (table.Rows.Count > 0) {
                return true;
            }else {
                return false;
            }

        }
		
	}
}
