using LibDyreInternat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoskildeDyreinternat
{
    public class MainHandler
    {
        private static CustomDictionary<string, string> m_dictionary = new CustomDictionary<string, string>();


        private bool m_run = true;



        public MainHandler()
        {


            while (m_run)
            {
                Console.WriteLine("Indtast en kommand:\n" +
                    "Indput Hjælp for liste med kommandoer\n------------");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (input.ToLower() == "hjælp")
                {
                    Console.WriteLine("Indtast en af følgend\n------------\nSe\nTilfoj\nFjern\nÆndr\n------------\nEfterfulgt af følgende\n------------\nDyr\nMedlem\nBegivenhed\nBlog\nBooking\n------------\nKommandoerne Ryd og Exit\nRyder consolen eller slutter programmet\n------------");
                    continue;
                }

                if (input.ToLower() == "Ryd")
                {
                    Console.Clear();
                }

                if (input.ToLower() == "exit")
                {
                    m_run = false;
                    break;
                }
                FindKeyValuePair(input);
                FindKey();
                Console.WriteLine();
            }
            //FindKeyValuePair(Console.ReadLine());
            //FindKey();
        }

        public static Person JSonRead(string filePath)
        {
            string text = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Person>(text);
        }

        public void FindKey()
        {
            foreach (var keyValuePair in m_dictionary)
            {
                switch (keyValuePair.Value.ToLower())
                {
                    case "dyr":
                        ValueEventHandler.ValueAnimal(keyValuePair.Key);
                        break;
                    case "log":
                        ValueEventHandler.ValueMedicalLog(keyValuePair.Key);
                        break;
                    case "person":
                        ValueEventHandler.ValuePerson(keyValuePair.Key);
                        break;
                    case "aktivitet":
                        ValueEventHandler.ValueEvent(keyValuePair.Key);
                        break;
                    case "blog":
                        ValueEventHandler.ValueBlog(keyValuePair.Key);
                        break;
                }
            }

            m_dictionary.ToList().Clear();
        }

        public void FindKeyValuePair(string input)
        {
            int keyStart = 0;
            int keyEnd = 0;
            int valueStart = 0;
            int valueEnd = 0;
            string key = "";
            string value = "";
            bool checkForValue = false;

            for (int i = 0; i < input.Count(); i++)
            {
                if (input.ElementAt(i) != ' ' && checkForValue == false)
                {
                    keyStart = i;
                    keyEnd = input.IndexOf(" ", keyStart);

                    if (keyEnd == -1)
                    {
                        break;
                    }

                    key = input.Substring(keyStart, keyEnd - keyStart);
                    checkForValue = true;
                    i = keyEnd;
                }

                if (input.ElementAt(i) != ' ' && checkForValue == true)
                {
                    valueStart = i;
                    valueEnd = input.IndexOf(" ", valueStart);

                    if (valueEnd == -1)
                    {
                        valueEnd = input.Count();
                    }

                    value = input.Substring(valueStart, valueEnd - valueStart);
                    checkForValue = false;
                    i = valueEnd;
                    m_dictionary.Add(key, value);
                }
            }
        }
    }

}

