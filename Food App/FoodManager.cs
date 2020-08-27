using System;
using System.Collections.Generic;
using System.Text;

namespace Food_App
{
    class FoodManager
    {
        private DateTime now = DateTime.Now;
        private DateTime firstdate = new DateTime();
        private const string DatePath = @"C:\FoodManager\FoodDate.txt";
        private const string NamePath = @"C:\FoodManager\FoodName.txt";
        private string[] FoodName = new string[100];
        private DateTime[] FoodDate = new DateTime[100];
        public void SetAll(string[] Names, DateTime[] Dates)
        {
            FoodDate = Dates;
            FoodName = Names;
        }
        public string IsExpire()
        {
            string final_string = null;
            int j = 0;
            bool IsExpire = false;
            int i = 0;
            while (FoodDate[i] != firstdate)
            {
                if (FoodDate[i] < now)
                {
                    IsExpire = true;
                    final_string += FoodName[i] + " is expire  " + FoodDate[i].ToShortDateString()
                    + Environment.NewLine + Environment.NewLine;
                    WriteTostringWithExeption(i - j, DatePath);
                    WriteTostringWithExeption(i - j, NamePath);
                    j++;
                }
                i++;
            }
            if (!IsExpire)
                final_string = "The food is still fresh";
            return final_string;
        }
        public string WhatLeft()
        {
            string final_string;
            int i = 0;
            if (FoodName[i] == null)
            {
                final_string = "Nothing left";
                goto END;
            }
            final_string = "left:" + Environment.NewLine;
            while (FoodName[i] != null)
            {
                final_string += FoodName[i] + " " + FoodDate[i].ToShortDateString() +
                    Environment.NewLine;
                i++;
            }
            END:;
            return final_string;
        }
        private void WriteTostringWithExeption(int badNumber, string path)
        {
            int i = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string Final_string = null;
            for (i = 0; i < badNumber; i++)
            {
                line = file.ReadLine();
                if (i == 0)
                    Final_string += line;
                else
                    Final_string += Environment.NewLine + line;
            }
            //don't enclude the "bad" line
            line = file.ReadLine();
            while ((line = file.ReadLine()) != null)
            {
                if (i == 0)
                    Final_string += line;
                else
                    Final_string += Environment.NewLine + line;
                i++;
            }
            if (Final_string != null)
                Final_string += Environment.NewLine;
            file.Close();
            System.IO.File.WriteAllText(path, Final_string);
        }
    }
}
