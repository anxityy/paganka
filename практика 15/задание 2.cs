using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp34
{
    internal class work
    {
        static void Main(string[] args)
        {

        }
            public interface ISwitchable
        {
            void TurnOn();
            void TurnOff();
        }

        public interface iymeu
        {
            void SetLevel(int level);
        }

        public class Lamp : ISwitchable, iymeu
        {
            private bool isOn;
            private int level;

            public Lamp()
            {
                isOn = false;
                level = 0;
            }

            public void TurnOn()
            {
                isOn = true;
                level = 100;
                Console.WriteLine($"Лампа включена. Уровень: {level}%");
            }

            public void TurnOff()
            {
                isOn = false;
                level = 0;
                Console.WriteLine($"Лампа выключена. Уровень: {level}%");
            }

            public void SetLevel(int level)
            {
                if (level < 0) level = 0;
                if (level > 100) level = 100;

                this.level = level;

                if (level > 0)
                {
                    isOn = true;
                }
                else
                {
                    isOn = false;
                }

                Console.WriteLine($"Установлен уровень лампы: {level}%. Состояние: {(isOn ? "включена" : "выключена")}");
            }
        }

        public class Fan : ISwitchable
        {
            private bool isOn;

            public Fan()
            {
                isOn = false;
            }

            public void TurnOn()
            {
                isOn = true;
                Console.WriteLine("Вентилятор включен");
            }

            public void TurnOff()
            {
                isOn = false;
                Console.WriteLine("Вентилятор выключен");
            }
        }

        class skovorodka
        {
            static void Main(string[] args)
            {
                Console.WriteLine("=== Демонстрация работы устройств ===\n");

                Lamp lamp = new Lamp();
                Fan fan = new Fan();

                List<ISwitchable> devices = new List<ISwitchable> { lamp, fan };
                Console.WriteLine("1. Включаем все устройства:");
                for (int i = 0; i < devices.Count; i++)
                {
                    devices[i].TurnOn();
                }

                Console.WriteLine("\n2. Выключаем все устройства:");
              
                for (int i = 0; i < devices.Count; i++)
                {
                    devices[i].TurnOff();
                }

                Console.WriteLine("\n3. Дополнительные операции для лампы:");
                lamp.TurnOn();
                lamp.SetLevel(30);
                lamp.SetLevel(120);
                lamp.SetLevel(-10);
                lamp.TurnOff();

                Console.WriteLine("\n=== Программа завершена ===");
                Console.ReadLine();
            }
        }
    }
    }

