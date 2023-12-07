using System.Diagnostics;
using System.Text;

namespace CalcFor5thGrade
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Calculator";

            Console.WriteLine(
                "Калькулятор для систем счисления от 1 до 50 включительно и перевода чисел в римскую систему.");
            Console.WriteLine("Калькулятор предназначен для работы с положительными целыми числами.");
            Console.WriteLine("Написал Дударов Дмитрий Группа: ПрИ-102");
            CreateBorder();
            GetHelp();

            Begin:
            try
            {
                GetInput();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ArgumentException)) Console.WriteLine(ex.Message);
                else Console.WriteLine("Обнаружена ошибка! повторите ввод еще раз, скорее всего данные некорректны!");

                goto Begin;
            }
        }

        public static void ColoringToGreen(string line)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        private static void GetHelp()
        {
            Console.WriteLine("* 1 \u279f перевод числа из любой СС в любую другую СС *");
            Console.WriteLine("* 2 \u279f перевод числа в римскую СС *");
            Console.WriteLine("* 3 \u279f перевод из римской СС *");
            Console.WriteLine("* 4 \u279f суммирование в любой СС *");
            Console.WriteLine("* 5 \u279f вычитание в любой СС *");
            Console.WriteLine("* 6 \u279f умножение в любой СС *");
            Console.WriteLine("* 7 \u279f список команд *");
            CreateBorder();
        }

        private static void WannaTryAgain()
        {
            Console.WriteLine(
                "Если вы желаете продолжить использование приложения, пожалуйста, нажмите на любую кнопку.");
            Console.WriteLine(
                "Если вы желаете прекратить использовать приложение пожалуйста, нажмите на ESC.");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(
                    "Калькулятор для систем счисления от 1 до 50 включительно и перевода чисел в римскую систему.");
                Console.WriteLine("Написал Дударов Дмитрий Группа: ПрИ-102");
                CreateBorder();
                GetHelp();
                Console.WriteLine("Введите цифру, соответствующую пункту меню");
            }
        }

        public static int GetInt(char c)
        {
            Dictionary<int, char> alphabet = new Dictionary<int, char>();
            for (int i = 0; i < 62; i++)
            {
                if (i >= 0 && i <= 9)
                    alphabet.Add(i, (char)('0' + i));
                if (i >= 10 && i <= 35)
                    alphabet.Add(i, (char)('A' + i - 10));
                if (i >= 36 && i <= 62)
                    alphabet.Add(i, (char)('a' + i - 36));
            }

            for (int i = 0; i < 62; i++)
            {
                if (alphabet[i] == c)
                {
                    return i;
                }
            }

            throw new ArgumentException("Число невозможно получить из остатка. Попробуйте еще раз!");
        }

        private static int GetInput()
        {
            Console.WriteLine("\n Укажите цифру, соответствующую действию, которое необходимо выполнить:");
            while (true)
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int command) || !(command >= 1 && command <= 7))
                {
                    Console.WriteLine("Введите существующую команду!");
                    GetInput();
                }

                switch (command)
                {
                    case 1:
                        Console.Clear();
                        FirstOption();
                        WannaTryAgain();
                        break;
                    case 2:
                        Console.Clear();
                        SecondFunction();
                        WannaTryAgain();
                        break;
                    case 3:
                        Console.Clear();
                        ThirdFunction();
                        WannaTryAgain();
                        break;
                    case 4:
                        Console.Clear();
                        FourthFunction();
                        WannaTryAgain();
                        break;
                    case 5:
                        Console.Clear();
                        FifthFunction();
                        WannaTryAgain();
                        break;
                    case 6:
                        Console.Clear();
                        SixthFunction();
                        WannaTryAgain();
                        break;
                    case 7:
                        Console.Clear();
                        GetHelp();
                        break;
                    default:
                        Console.WriteLine("Упс, что-то пошло не так.");
                        break;
                }
            }
        }

        private static void CreateBorder()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("═");
                Console.ResetColor();
            }
        }

        private static char ConvertNumberToSymbol(int modul)
        {
            if (modul >= 0 && modul <= 9) return (char)('0' + modul);
            if (modul >= 10 && modul <= 36) return (char)('A' + (modul - 10));
            if (modul >= 37 && modul <= 62) return (char)('a' + (modul - 36));

            throw new ArgumentException("Некорректный остаток от деления!");
        }

        private static int ConvertToDecimal(string number, int numberBase)
        {
            if (numberBase > 50)
                throw new ArgumentException("Основание некорректо! Оно должно быть в пределе от 1 до 50 включительно!");
            int result = 0;
            int digitsCount = number.Length;
            int num;

            Console.WriteLine("Разбиваем число на отдельные символы.");
            var builder = new StringBuilder();
            builder.Append("Символы:");
            foreach (char c in number.ToCharArray())
            {
                builder.Append($" {c}");
            }

            Console.WriteLine(builder.ToString());

            Console.WriteLine("Начинаем перевод в десятичную систему счисления.");
            Console.WriteLine("Изначальный результат вычисления 0.");

            if (numberBase == 1)
            {
                Console.WriteLine(
                    "Чтобы число из 1-СС перевести в 10-СС нужно просто подсчитать количество 1 в этом числе. Полученное число и есть число в 10-СС");
                int res = 0;
                char[] chars = number.ToCharArray();
                for (int i = 0; i < number.Length; i++)
                {
                    char lol = chars[i];
                    res += int.Parse(lol.ToString());
                }

                Console.WriteLine(res);
                if (res != number.Length) throw new ArgumentException("Некорректное число! Попробуйте еще раз");
                return res;
            }

            for (int i = 0; i < digitsCount; i++)
            {
                char symbol = number[i];

                if (symbol >= '0' && symbol <= '9') num = symbol - '0';

                else if (symbol >= 'A' && symbol <= 'Z') num = symbol - 'A' + 10;
                else if (symbol >= 'a' && symbol <= 'z') num = symbol - 'a' + (('Z' - 'A') + 1) + 10;
                else throw new ArgumentException("Некорректное число!");

                if (num >= numberBase)
                    throw new ArgumentException("Исходная строка имеет некорректные символы в обозначении чисел.");

                Console.WriteLine(
                    $"Умножаем результат на основание СС: {numberBase}, затем прибавляем число: {num}, соответствующее {i + 1} элементу числа.");

                result *= numberBase;
                result += num;
                Console.WriteLine($"({result / numberBase} * {numberBase}) + {num} = {result}");
            }

            Console.Write($"В ходе манипуляций получаем новое число: ");
            ColoringToGreen(result.ToString());

            return result;
        }

        private static string ConvertFromDecToAny(int number, int numberBase)
        {
            if (numberBase > 50)
                throw new ArgumentException("Основание некорректо! Оно должно быть в пределе от 1 до 50 включительно!");
            StringBuilder builder = new StringBuilder();

            Console.WriteLine($"Теперь {number} переведем из 10-СС в {numberBase}");
            do
            {
                Console.WriteLine(
                    $"Делим с остатком {number} на {numberBase}. При этом остаток приписываем к числу-результату. ");
                int mod = number % numberBase;
                char symbol = ConvertNumberToSymbol(mod);
                Console.WriteLine($"{builder} + {mod}");
                builder.Append(symbol);
                number /= numberBase;
            } while (number >= numberBase);

            if (number != 0)
            {
                builder.Append(ConvertNumberToSymbol(number));
                Console.WriteLine(
                    $"Делим с остатком {number} на 10. При этом остаток приписываем к числу-результату. ");
            }

            Console.WriteLine(
                $"Получаем число {builder.ToString()}. Но это еще не результат. Чтобы получить корректное нужно его записать наоборот: {string.Join("", builder.ToString().Reverse())}");
            string result = string.Join("", builder.ToString().Reverse());

            return result;
        }

        private static int ConvertFromAnyToDecWithoutComments(string number, int numberBase)
        {
            if (numberBase > 50)
                throw new ArgumentException("Основание некорректо! Оно должно быть в пределе от 1 до 50 включительно!");
            int result = 0;
            int digitsCount = number.Length;
            int num;

            var builder = new StringBuilder();
            builder.Append("Символы:");
            foreach (char c in number.ToCharArray())
            {
                builder.Append($" {c}");
            }


            if (numberBase == 1)
            {
                int res = 0;
                for (int i = 0; i < number.Length; i++)
                    res++;
                if (res != number.Length) throw new ArgumentException("Некорректное число! Попробуйте еще раз");
                return res;
            }

            for (int i = 0; i < digitsCount; i++)
            {
                char symbol = number[i];

                if (symbol >= '0' && symbol <= '9') num = symbol - '0';

                else if (symbol >= 'A' && symbol <= 'Z') num = symbol - 'A' + 10;
                else if (symbol >= 'a' && symbol <= 'z') num = symbol - 'a' + (('Z' - 'A') + 1) + 10;
                else throw new ArgumentException("Некорректное число!");

                if (num >= numberBase)
                    throw new ArgumentException("Исходная строка имеет некорректные символы в обозначении чисел.");
                result *= numberBase;
                result += num;
            }

            return result;
        }

        private static string ConvertFromDecToAnyWithoutComments(int number, int numberBase)
        {
            if (numberBase > 50)
                throw new ArgumentException("Основание некорректо! Оно должно быть в пределе от 1 до 50 включительно!");
            StringBuilder builder = new StringBuilder();

            do
            {
                int mod = number % numberBase;
                char symbol = ConvertNumberToSymbol(mod);

                builder.Append(symbol);
                number /= numberBase;
            } while (number >= numberBase);

            if (number != 0)
            {
                builder.Append(ConvertNumberToSymbol(number));
            }

            string result = string.Join("", builder.ToString().Reverse());

            return result;
        }

        private static void FirstOption()
        {
            Console.WriteLine("\u2600 Перевод числа из любой СС в любую другую СС \u2600");
            CreateBorder();
            Console.WriteLine("Введите число:");
            string originNumber = Console.ReadLine();
            Console.WriteLine("Введите систему счисления этого числа");
            int originNumberBase = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите систему счисления, в которую необходимо перевести число");
            int toWhatBase = int.Parse(Console.ReadLine());

            int toDec = ConvertToDecimal(originNumber, originNumberBase);
            Console.WriteLine("Ваше новое число");
            Console.Write(ConvertFromDecToAny(toDec, toWhatBase));
            Console.Write(" в системе счисления ");
            Console.WriteLine(toWhatBase);
            CreateBorder();
        }

        private static void SecondFunction()
        {
            int[] arabic = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] roman = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            Console.WriteLine("* Перевод числа в римскую СС *");
            CreateBorder();
            Console.WriteLine("Введите число от 1 до 5000");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int number) || !(number >= 1 && number <= 5000))
                throw new ArgumentException("Некорректное число! Введите число от 1 до 5000");
            int i = 0;
            string output = "";
            var origin = number;
            while (number > 0)
            {
                if (arabic[i] <= number)
                {
                    Console.WriteLine($"{number} - {arabic[i]} = {number - arabic[i]}");
                    Console.WriteLine(
                        $"Число {roman[i]}, соответствующее {arabic[i]} приписывается справа. И так до нуля.");
                    number = number - arabic[i];
                    output = output + roman[i];
                }
                else i++;
            }

            Console.Write($"Получаем новое число ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(output);
            Console.ResetColor();
            Console.Write(" из исходного ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(origin);
            Console.ResetColor();
            CreateBorder();
        }

        private static void ThirdFunction()
        {
            Console.WriteLine("\u273f Перевод из римской СС \u273f");

            Console.WriteLine("Введите число в римской СС");
            string input = Console.ReadLine();
            string[] arab = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            for (int i = 0; i < input.Length; i++)
            {
                bool isCorrect = false;
                for (int j = 0; j < arab.Length; j++)
                {
                    if (input[i].ToString() == arab[j])
                    {
                        isCorrect = true;
                        break;
                    }
                }

                if (!isCorrect) throw new ArgumentException("Некорректное число!");
            }

            Console.Write($"Разбиваем число {input} на отдельные цифры: ");
            ColoringToGreen(string.Join(" ", input.Split("")));

            int result = 0;
            var RomToArab = new Dictionary<char, int>
                { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
            for (short i = 0; i < input.Length - 1; ++i)
            {
                if (RomToArab[input[i]] < RomToArab[input[i + 1]])
                {
                    Console.WriteLine(
                        $"Число слева {RomToArab[input[i]]} меньше числа справа {RomToArab[input[i + 1]]} , поэтому вычитаем из результирующего числа левое {RomToArab[input[i]]}");
                    result -= RomToArab[input[i]];
                }
                else if (RomToArab[input[i]] >= RomToArab[input[i + 1]])
                {
                    Console.WriteLine(
                        $"Число слева {RomToArab[input[i]]} больше, чем число справа {RomToArab[input[i + 1]]}, то прибавляем к результирующему числу левое {RomToArab[input[i]]}");
                    result += RomToArab[input[i]];
                }

                Console.WriteLine($"Получили текущее ");
                ColoringToGreen(result.ToString());
            }

            result += RomToArab[input[^1]];
            Console.Write($"Получили текущее - ");
            ColoringToGreen(result.ToString());
            Console.Write($"Итоговое число в римской СС - ");
            ColoringToGreen(result.ToString());

            CreateBorder();
        }

        private static void FourthFunction()
        {
            Console.WriteLine("\u2744 Суммирование в любой СС \u2744");
            Console.WriteLine("Введите систему счисления: ");
            string ss = Console.ReadLine();
            if (!int.TryParse(ss, out var based) || !(based >= 1 && based <= 50))
                throw new ArgumentException("Некорректная система счисления!");

            Console.WriteLine("Введите первое число: ");
            string number1 = Console.ReadLine();

            Console.WriteLine("Введите второе число: ");
            string number2 = Console.ReadLine();

            int n1 = ConvertFromAnyToDecWithoutComments(number1, based);
            int n2 = ConvertFromAnyToDecWithoutComments(number2, based);

            Console.WriteLine($"Начем сложение числе в {based}-СС");

            if (based == 1)
            {
                Console.WriteLine(
                    "Так как система счисления 1, то результатом суммы будет общее количество единиц обоих чисел");
                Console.WriteLine($"Тогда результат: {number1 + number2}");
                return;
            }

            List<int> num1 = new List<int>();
            List<int> num2 = new List<int>();

            List<int> sumResult = new List<int>();

            int maxLen = Math.Max(number1.Length, number2.Length);

            number1 = number1.PadLeft(maxLen, '0');
            number2 = number2.PadLeft(maxLen, '0');


            foreach (var i in number1)
                num1.Add(GetInt(i));
            foreach (var j in number2)
                num2.Add(GetInt(j));

            num1.Reverse();
            num2.Reverse();

            Console.WriteLine($" {number1}");
            Console.WriteLine($"+");
            Console.WriteLine($" {number2}");
            string border = "";
            Console.WriteLine($" {border.PadLeft(maxLen, '-')}");

            Console.WriteLine("Поразрядно складываем числа");

            int overflow = 0;
            for (int i = 0; i < num1.Count; i++)
            {
                int result = num1[i] + num2[i] + overflow;
                if (overflow >= 1) overflow -= 1;
                Console.WriteLine($"{num1[i]} + {num2[i]} = {result} в [{i + 1}] разряде  ");
                if (result >= based)
                {
                    Console.WriteLine(
                        "При сложении возникло переполнение, поэтому необходимо увеличить значение следующего разряда, добавив 1.");
                    Console.WriteLine(
                        $"Помимо этого записываем под {i + 1} разрядом {result} - {based} = {result - based}");
                    sumResult.Add(result - based);
                    overflow += 1;
                }
                else
                {
                    Console.WriteLine($"Записываем под {i + 1} разрядом {result}");
                    sumResult.Add(result);
                }
            }

            sumResult.Reverse();

            StringBuilder sb = new StringBuilder();
            foreach (var item in sumResult)
            {
                sb.Append(item.ToString());
            }

            Console.WriteLine($" {number1}");
            Console.WriteLine($"+");
            Console.WriteLine($" {number2}");

            Console.WriteLine($" {border.PadLeft(maxLen, '-')}");

            Console.WriteLine($" {sb.ToString()}");

            Console.Write($"Результат: ");
            ColoringToGreen(sb.ToString());
        }

        private static void FifthFunction()
        {
            Console.WriteLine("\u272a Вычитание в любой СС \u272a");
            Console.WriteLine("Введите систему счисления для операции над числами:");
            string ss = Console.ReadLine();
            Console.WriteLine("Введите число:");
            string number = Console.ReadLine();
            Console.WriteLine("Введите вычитаемое:");
            string subtrahend = Console.ReadLine();

            if (!int.TryParse(ss, out var based) || !(based >= 1 && based <= 50))
                throw new ArgumentException("Некорректная система счисления!");

            int numberCorrected = ConvertFromAnyToDecWithoutComments(number, based);
            int vichitCorrected = ConvertFromAnyToDecWithoutComments(subtrahend, based);

            bool isNumberNegative = ConvertFromAnyToDecWithoutComments(number, based) <
                                    ConvertFromAnyToDecWithoutComments(subtrahend, based);

            List<int> numberList = new List<int>();
            List<int> subtrahendList = new List<int>();

            int maxLength = Math.Max(number.Length, subtrahend.Length);

            subtrahend = subtrahend.PadLeft(maxLength, '0');
            number = number.PadLeft(maxLength, '0');

            if (isNumberNegative)
            {
                Console.WriteLine(
                    $"Число {number} обладает меньшим значением по сравнению с {subtrahend}, следовательно, результат вычитания будет отрицательным.");
                Console.WriteLine(
                    $"Таким образом, мы можем получить разность, вычтя из {subtrahend} значение {number} и добавив знак минус впереди.");

                foreach (var i in number)
                {
                    numberList.Add(GetInt(i));
                }

                foreach (var j in subtrahend)
                {
                    subtrahendList.Add(GetInt(j));
                }
            }
            else
            {
                foreach (var i in number)
                    numberList.Add(GetInt(i));
                foreach (var j in subtrahend)
                    subtrahendList.Add(GetInt(j));
            }

            StringBuilder sb = new StringBuilder();
            if (!isNumberNegative)
            {
                for (int i = maxLength - 1; i >= 0; i--)
                {
                    Console.Write($"Посчитаем разряд номер ");
                    ColoringToGreen((i + 1).ToString());

                    if (numberList[i] < subtrahendList[i])
                    {
                        if (numberList[i] >= 0)
                        {
                            Console.WriteLine($"{numberList[i]} меньше {subtrahendList[i]}, занимаем у левого разряда");
                            Console.WriteLine(
                                $" {numberList[i]} + {based} вычитаем {subtrahendList[i]} и получаем {numberList[i] + based - subtrahendList[i]}");
                        }
                        else
                        {
                            Console.WriteLine(
                                "Поскольку в первом разряде числа находится ноль (ранее из него занимали), мы занимаем у левого разряда.");
                            Console.WriteLine($"{based - 1} - {subtrahendList[i]} = {based - 1 - subtrahendList[i]}");
                        }

                        numberList[i - 1] = numberList[i - 1] - 1;
                        numberList[i] += based;
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Из {numberList[i]} - {subtrahendList[i]} = {numberList[i] - subtrahendList[i]}");
                    }

                    char resSub = ConvertNumberToSymbol(numberList[i] - subtrahendList[i]);

                    Console.WriteLine(resSub);
                    sb.Append(resSub);
                }
            }
            else
            {
                var temp = number;
                number = subtrahend;
                subtrahend = temp;

                var temp2 = numberList;
                numberList = subtrahendList;
                subtrahendList = temp2;


                for (int i = maxLength - 1; i >= 0; i--)
                {
                    Console.Write($"Посчитаем разряд номер ");
                    ColoringToGreen((i + 1).ToString());

                    if (numberList[i] < subtrahendList[i])
                    {
                        if (numberList[i] >= 0)
                        {
                            Console.WriteLine($"{numberList[i]} меньше {subtrahendList[i]}, занимаем у левого разряда");
                            Console.WriteLine(
                                $" {numberList[i]} + {based} вычитаем {subtrahendList[i]} и получаем {numberList[i] + based - subtrahendList[i]}");
                        }
                        else
                        {
                            Console.WriteLine(
                                "Поскольку в первом разряде числа находится ноль (ранее из него занимали), мы занимаем у левого разряда.");
                            Console.WriteLine($"{based - 1} - {subtrahendList[i]} = {based - 1 - subtrahendList[i]}");
                        }

                        numberList[i - 1] = numberList[i - 1] - 1;
                        numberList[i] += based;
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Из {numberList[i]} - {subtrahendList[i]} = {numberList[i] - subtrahendList[i]}");
                    }

                    char resSub = ConvertNumberToSymbol(numberList[i] - subtrahendList[i]);

                    Console.WriteLine(resSub);
                    sb.Append(resSub);

                    CreateBorder();
                }
            }

            CreateBorder();
            if (isNumberNegative)
            {
                Console.WriteLine();
                Console.WriteLine(" " + subtrahend);
                Console.WriteLine("-");
                Console.WriteLine(" " + number.PadLeft(maxLength, '0'));
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine(" " + number);
                Console.WriteLine("-");
                Console.WriteLine(" " + subtrahend.PadLeft(maxLength, '0'));
            }

            for (int i = 0; i <= maxLength; i++)
            {
                Console.Write("-");
            }

            string answer;
            if (isNumberNegative)
            {
                answer = "-" + new string(sb.ToString().Reverse().ToArray());
                Console.WriteLine($"\n {answer}");
            }
            else
            {
                answer = new string(sb.ToString().Reverse().ToArray());
                Console.WriteLine($"\n {answer}");
            }

            Console.Write($"Ответ: ");
            ColoringToGreen(answer);
            CreateBorder();
        }

        private static void SixthFunction()
        {
            Console.WriteLine("\u2756 Умножение в любой СС \u2756");
            Console.WriteLine("Введите систему счисления:");
            string ss = Console.ReadLine();
            if (!int.TryParse(ss, out int based) || !(based >= 1 && based <= 50))
                throw new ArgumentException("Некорректная система счисления! Она должна быть от 1 до 50 включительно!");

            Console.WriteLine("Введите первое число:");
            string number1 = Console.ReadLine();

            Console.WriteLine("Введите второе число:");
            string number2 = Console.ReadLine();

            int n1 = ConvertFromAnyToDecWithoutComments(number1, based);
            int n2 = ConvertFromAnyToDecWithoutComments(number2, based);

            List<int> num2 = new List<int>();

            List<int> multResultsInDec = new List<int>();
            List<string> multResultsInAny = new List<string>();
            foreach (var i in number2)
                num2.Add(GetInt(i));

            Console.WriteLine("Начинаем умножение");

            num2.Reverse();


            for (int i = 0; i < num2.Count; i++)
            {
                int currentRazryad = ConvertFromAnyToDecWithoutComments(number1, based) * num2[i];
                string displayedRazryad = ConvertFromDecToAnyWithoutComments(currentRazryad, based);
                Console.WriteLine(
                    $"{number1} * {ConvertNumberToSymbol(num2[i])} = {displayedRazryad}, где умножаем первое число на число под [{i + 1}] разрядом.");
                multResultsInDec.Add(currentRazryad);
                multResultsInAny.Add(displayedRazryad);
            }

            List<string> finalResults = new List<string>();
            finalResults.Add(multResultsInAny[0].PadLeft(multResultsInAny[0].Length + multResultsInAny.Count - 1, '0'));
            for (int i = 1; i < multResultsInAny.Count; i++)
            {
                var result = multResultsInAny[i].PadLeft(finalResults[0].Length - i, '0');
                result = result.PadRight(finalResults[0].Length, '0');

                finalResults.Add(result);
            }

            Console.WriteLine("Строки складываем поразрядно. Пример :");
            Console.WriteLine(number1.PadLeft(number1.Length + finalResults.Count, ' '));
            Console.WriteLine("*");
            Console.WriteLine(number2.PadLeft(number2.Length + finalResults.Count, ' '));
            Console.WriteLine(" " + "".PadLeft(finalResults[0].Length, '-'));
            foreach (var i in finalResults)
            {
                Console.WriteLine("+" + i);
            }

            Console.WriteLine(" " + "".PadLeft(finalResults[0].Length, '-'));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" " + ConvertFromDecToAnyWithoutComments(n1 * n2, based));
            Console.ResetColor();
        }
    }
}