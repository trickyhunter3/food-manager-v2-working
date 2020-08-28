using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextForm textFrom = new TextForm();
            FoodManager foodManager = new FoodManager();
            foodManager.SetAll(GetAllNamesFromFile(), GetAllDatesfromfile());
            textFrom.ChangeTitle("What left");
            textFrom.ChangeLabel(foodManager.WhatLeft());
            textFrom.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextForm textFrom = new TextForm();
            FoodManager foodManager = new FoodManager();
            foodManager.SetAll(GetAllNamesFromFile(), GetAllDatesfromfile());
            textFrom.ChangeTitle("Check if expire");
            textFrom.ChangeLabel(foodManager.IsExpire());
            textFrom.ShowDialog();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void FirstForm_SizeChanged(object sender, EventArgs e)
        {
            bool MousePointerNotOnTaskBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);
            if (WindowState == FormWindowState.Minimized && MousePointerNotOnTaskBar)
            {
                FoodManager foodManager = new FoodManager();
                foodManager.SetAll(GetAllNamesFromFile(), GetAllDatesfromfile());
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipText = "some product expire";
            }
        }

        private static string[] GetAllNamesFromFile()
        {
            string[] Names = new string[100];
            string line;
            int i = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\FoodManager\FoodName.txt");
            while ((line = file.ReadLine()) != null)
            {
                Names[i] = line;
                i++;
            }
            file.Close();
            return Names;
        }

        private static DateTime[] GetAllDatesfromfile()
        {
            DateTime[] arrayTime = new DateTime[100];
            string line;
            int i = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\FoodManager\FoodDate.txt");
            while ((line = file.ReadLine()) != null)
            {
                arrayTime[i] = Convert.ToDateTime(line);
                i++;
            }
            file.Close();
            return arrayTime;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }
    }
}
