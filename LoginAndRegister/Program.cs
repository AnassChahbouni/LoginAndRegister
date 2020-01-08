/*
 * Created by SharpDevelop.
 * User: etu
 * Date: 08/01/2020
 * Time: 15:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LoginAndRegister
{
	class Program
	{
		public static void Main(string[] args)
		{
			bool q = false;
			while(!q) {
				string firstname, lastname, email, password;
				string option = null;
				
				Console.WriteLine("-------------------Welcome to PasStop!-------------------");
				Console.WriteLine("1.Register");
				Console.WriteLine("2.Log in");
				Console.WriteLine("3.Exit");
				Console.WriteLine("---------------------------------------------------------");
				option = Console.ReadLine();
				
				switch(int.Parse(option)) {
					case 1:
			            Console.WriteLine("-------------------------Register-------------------------");
						Console.WriteLine("1.Firstname");
						firstname = Console.ReadLine();
						Console.WriteLine("2.Lastname");
						lastname = Console.ReadLine();
						Console.WriteLine("3.Email");
						email = Console.ReadLine();
						Console.WriteLine("4.Password");
						password = Console.ReadLine();
						Register.addUser(firstname, lastname, email, password);
						Console.WriteLine("---------------------------------------------------------");
			            break;
			         case 2:
			            Console.WriteLine("-------------------------Log in--------------------------");
			            Console.WriteLine("1.Email");
						email = Console.ReadLine();
						Console.WriteLine("2.Password");
						password = Console.ReadLine();
						Login.logIn(email, password);
						Console.WriteLine("---------------------------------------------------------");
			            break;
			         case 3:
			            Console.WriteLine("Byebye!");
            			q = true;
			            break;
			         default:
			            Console.WriteLine("Sorry?");
			            break;
				}
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}