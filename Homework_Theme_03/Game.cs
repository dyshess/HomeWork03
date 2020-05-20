using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class Game
    {
        /// <summary>
        /// Количество игроков
        /// </summary>
        public List<Player> players;
        /// <summary>
        /// Поле настроек
        /// </summary>
        private Setting setting;
        /// <summary>
        /// Загаданное число
        /// </summary>
        public int gameNumber;
        /// <summary>
        /// Победитель
        /// </summary>
        private Player winner;
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private Random random = new Random();
        /// <summary>
        /// Конструктор создания новой игры
        /// </summary>
        /// <param name="GamersCount">Количество игроков</param>
        public Game(Setting Setting)
        {
            //Копирование настроек
            this.setting = Setting;
            this.players = new List<Player>(setting.players);
            //Добавление Компьютера для однопользовательской игры
            if (players.Count == 1)
            {
                players.Add(new Player("Компьютер"));
            }
            
            this.gameNumber = random.Next(setting.leftBorder, setting.rightBorder + 1);
            ShowCurrentNumber();

            //Цикл игровых ходов
            while (this.gameNumber > 0 && this.winner == null)
            {
                foreach (var player in this.players)
                {
                    var value = (player.name == "Компьютер" ? player.ComputerTry(gameNumber, setting.userTrySize) : player.UserTry(gameNumber, setting.userTrySize));

                    this.gameNumber -= value;
                    ShowCurrentNumber();

                    if (this.gameNumber == 0) { this.winner = player; break; };
                }
            }

            //Поздравление победителя
            MakeCongratulation();
        }
        /// <summary>
        /// Поздравление победителя
        /// </summary>
        private void MakeCongratulation()
        {
            if (this.winner.name != "Компьютер")
            {
                Console.WriteLine("Поздравляем с победой, " + this.winner.name + "!");
            }
            else
            {
                Console.WriteLine("Вы проиграли, попробуйте ещё раз!");
            }
        }
        /// <summary>
        /// Отображение текущего числа
        /// </summary>
        private void ShowCurrentNumber()
        {
            Console.WriteLine("\nТекущее значение числа = " + this.gameNumber);
        }
    }
}
