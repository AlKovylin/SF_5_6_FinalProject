using System;
using System.Linq;

namespace SF_5_6_FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var Anketa = DataEntry();
            ShowAnketa(Anketa);
        }

        /// <summary>
        /// Функция ввода данных в анкету
        /// </summary>
        /// <returns>кортеж Anketa</returns>
        static (string, string, int, bool, int, string[], string[]) DataEntry()
        {
            (string FirstName, string LastName, int Age, bool HasPet, int NumPet, string[] NamePet, string[] FavColors) Anketa;

            Console.Write("\tЗаполнение анкеты.\n\n");

            Console.Write("Введите ваше имя: ");
            Anketa.FirstName = Console.ReadLine();

            Console.Write("Введите вашу фамилию: ");
            Anketa.LastName = Console.ReadLine();

            Anketa.Age = InNumData("Введите ваш возраст цифрами: ");

            //необходимое присвоение - питомцев может и не быть
            Anketa.NumPet = 0;
            Anketa.NamePet = null;

            if (Anketa.HasPet = CheckInYesOrNo())
            {
                Anketa.NumPet = InNumData("Введите количество ваших питомцев: ");
                Anketa.NamePet = InArrayData(Anketa.NumPet, "Введите кличку питомца");
            }

            int numFavColors = InNumData("Введите количество ваших любимых цветов цифрами: ");
            Anketa.FavColors = InArrayData(numFavColors, "Введите ваш любимый цвет");

            return Anketa;
        }

        /// <summary>
        /// Ограничение. Ввод только численного значения.
        /// </summary>
        /// <param name="outMessage"></param>
        /// <returns>int</returns>
        static int InNumData(string outMessage)
        {
            string strData;
            int intData;
            do
            {
                Console.Write(outMessage);
                strData = Console.ReadLine();
            }
            while (!CheckInNumData(strData, out intData));
            return intData;
        }

        /// <summary>
        /// Проверка: входящие данные это число?
        /// </summary>
        /// <param name="inStr"></param>
        /// <param name="numInt"></param>
        /// <returns>bool</returns>
        static bool CheckInNumData(string inStr, out int numInt)
        {
            numInt = 0;
            if (int.TryParse(inStr, out int result))
            {
                if (result > 0)
                {
                    numInt = result;
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Ограничение. Ввод только "Да/Нет"
        /// </summary>
        /// <returns>bool</returns>
        static bool CheckInYesOrNo()
        {
            bool flagExit = false;
            bool checkData = false;

            while (!flagExit)
            {
                Console.Write("Есть ли у вас питомец? (Да/Нет): ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "Да":
                        checkData = true;
                        flagExit = true;
                        break;
                    case "Нет":
                        checkData = false;
                        flagExit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Вводите только (Да/Нет).");
                        break;
                }
            }
            return checkData;
        }

        /// <summary>
        /// Формирование массива строк.
        /// </summary>
        /// <param name="numOfElements"></param>
        /// <param name="outMessage"></param>
        /// <returns>string[]</returns>
        static string[] InArrayData(int numOfElements, string outMessage)
        {
            string[] arrData = new string[numOfElements];

            for (int i = 0; i < numOfElements; i++)
            {
                Console.Write(outMessage + " {0}: ", i + 1);
                arrData[i] = Console.ReadLine();
            }
            return arrData;
        }

        /// <summary>
        /// Вывод анкеты на экран.
        /// </summary>
        /// <param name="Anketa"></param>
        static void ShowAnketa((string firstName, string lastName, int age, bool hasPet, int numPet, string[] namePet, string[] favColors) Anketa)
        {
            Console.WriteLine("\n\tДанные анкеты:\n");
            Console.WriteLine("Имя: " + Anketa.firstName);
            Console.WriteLine("Фамилия: " + Anketa.lastName);
            Console.WriteLine("Возраст: " + Anketa.age);

            if (Anketa.hasPet)//выводим только если питомцы есть          
                PrintArray(Anketa.namePet, "\nПитомцы:\n");

            PrintArray(Anketa.favColors, "\nЛюбимые цвета:\n");
        }

        /// <summary>
        /// Выдов содержимого одномерного массива на экран.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="nameArr"></param>
        static void PrintArray(string[] arr, string nameArr)
        {
            Console.WriteLine(nameArr);

            foreach (var item in arr.Select((value, i) => new { i, value }))
            {
                Console.WriteLine(item.i + 1 + ". " + item.value);
            }
        }
    }
}