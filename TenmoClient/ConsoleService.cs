﻿using System;
using System.Collections.Generic;
using TenmoClient.Data;

namespace TenmoClient
{
    public class ConsoleService
    {
        /// <summary>
        /// Prompts for transfer ID to view, approve, or reject
        /// </summary>
        /// <param name="action">String to print in prompt. Expected values are "Approve" or "Reject" or "View"</param>
        /// <returns>ID of transfers to view, approve, or reject</returns>
        public int PromptForTransferID(string action)
        {
            Console.WriteLine("");
            Console.Write($"Please enter transfer ID to {action} (0 to cancel): ");

            if (!int.TryParse(Console.ReadLine(), out int accountId))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0; //make this loop over prompt / response.
            }

            return accountId;
        }

        public LoginUser PromptForLogin()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            string password = GetPasswordFromConsole("Password: ");

            return new LoginUser
            {
                Username = username,
                Password = password
            };
        }

        private string GetPasswordFromConsole(string displayMessage)
        {
            string pass = "";
            Console.Write(displayMessage);
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (!char.IsControl(key.KeyChar))
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Remove(pass.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            }

            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine("");

            return pass;
        }

        public void ListAllUsers(List<API_User> users)
        {
            foreach (API_User user in users)
            {
                Console.WriteLine($"{user.UserId})  {user.Username}");
            }
        }

        //public int FindTransferUserId(int transferId, List<API_User> users)
        //{
        //    foreach (API_User user in users)
        //    {
        //        if (user.UserId == transferId)
        //        {

        //        }
        //    }
        //}


    }

    //public decimal PromptForTransferAmount(string message)
    //{

    //}
}


