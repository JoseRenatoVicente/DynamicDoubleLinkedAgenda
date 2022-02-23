using System;

namespace DynamicAgendaList
{
    internal class Program
    {
        static AgendaService agendaService = new AgendaService();
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(@"
            :::      ::::::::  :::::::::: ::::    ::: :::::::::      :::     
          :+: :+:   :+:    :+: :+:        :+:+:   :+: :+:    :+:   :+: :+:   
         +:+   +:+  +:+        +:+        :+:+:+  +:+ +:+    +:+  +:+   +:+  
        +#++:++#++: :#:        +#++:++#   +#+ +:+ +#+ +#+    +:+ +#++:++#++: 
        +#+     +#+ +#+   +#+# +#+        +#+  +#+#+# +#+    +#+ +#+     +#+ 
        #+#     #+# #+#    #+# #+#        #+#   #+#+# #+#    #+# #+#     #+# 
        ###     ###  ########  ########## ###    #### #########  ###     ### 

         __      __   _                    _           _                    _      
         \ \    / /__| |__ ___ _ __  ___  | |_ ___    /_\  __ _ ___ _ _  __| |__ _ 
          \ \/\/ / -_) / _/ _ \ '  \/ -_) |  _/ _ \  / _ \/ _` / -_) ' \/ _` / _` |
           \_/\_/\___|_\__\___/_|_|_\___|  \__\___/ /_/ \_\__, \___|_||_\__,_\__,_|
                                                          |___/                    
");

            Menu();
            Console.ReadKey();
        }


        public static void Menu()
        {         

            Console.WriteLine(@"
--------------------------------------- Agenda List ------------------------------------------------

                                1 – Insert a contact
                                2 - Find a contact
                                3 – Remove a contact
                                4 - Edit a contact
                                5 – Print the contacts 
                                ------------------------------
                                0 - Exit

-----------------------------------------------------------------------------------------------------
");

            string option = Console.ReadLine();

            switch (option)
            {
                case "0": Environment.Exit(0); break;

                case "1":
                    Console.Clear();
                    agendaService.AddContact();
                    BackMenu(); break;

                case "2":
                    Console.Clear();
                    agendaService.GetContactsByNamePhone();
                    BackMenu(); break;

                case "3":
                    Console.Clear();
                    agendaService.RemoveContact();
                    BackMenu(); break;

                case "4":
                    Console.Clear();
                    agendaService.EditContact();
                    BackMenu(); break;

                case "5":
                    Console.Clear();
                    agendaService.GetAllContacts();
                    BackMenu(); break;

                default:
                    Console.WriteLine("Invalid typed option! ");
                    BackMenu();
                    break;
            }

        }

        public static void BackMenu()
        {
            Console.WriteLine("\n Press any key to return to the menu");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}
