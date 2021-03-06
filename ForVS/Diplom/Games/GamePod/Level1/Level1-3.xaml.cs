﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Diplom.Games.GamePod.Level1
{
    /// <summary>
    /// Логика взаимодействия для Level1_3.xaml
    /// </summary>
    public partial class Level1_3 : Window
    {

        private GamePod.Level2.Level2 lv2;

        public Level1_3()
        {
            InitializeComponent();
        }

        ///Событие по кнопке
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "2")
            {
                MessageBox.Show("Поздравляю, вы прошли первый уровень! Переход к последнему уровню");
                lv2 = new Level2.Level2();
                lv2.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Ответ неверный.");
                textBox1.Clear();
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (textBox1.Text == "2")
                {
                    MessageBox.Show("Поздравляю, вы прошли первый уровень! Переход к последнему уровню");
                    lv2 = new GamePod.Level2.Level2();
                    lv2.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Ответ неверный.");
                    textBox1.Clear();
                }
            }
        }
    }
}
