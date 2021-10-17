using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;


namespace _1lesson_on_2021
{
    class Program
    {
        private static readonly TelegramBotClient bot = new TelegramBotClient("2047377771:AAGryfyg5dQ75IRhJUiTg53aqf0OjO4wqjo");
        private static Dictionary<long,int> questionNumber = new Dictionary<long, int>();
        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Message msg = e.Message;
            if (msg == null) return;
            if (!questionNumber.ContainsKey(msg.Chat.Id))
            {
                await bot.SendTextMessageAsync(msg.Chat.Id, "Привет) напиши старт");
                questionNumber[msg.Chat.Id] = 0;
            }else if (msg.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                
                if (questionNumber[msg.Chat.Id] == 0 && msg.Text.ToLower() == "старт")
                {
                    Console.WriteLine(msg.Text);
                    await bot.SendTextMessageAsync(msg.Chat.Id, "Введите ваше имя");
                    questionNumber[msg.Chat.Id]++;
                }
                else if (questionNumber[msg.Chat.Id] == 1 && msg.Text.ToLower() == "тимофей")
                {
                    Console.WriteLine(msg.Text);
                    await bot.SendTextMessageAsync(msg.Chat.Id, "Ты тимофей ахах");
                    questionNumber[msg.Chat.Id]++;
                }
                else
                {
                    Console.WriteLine(msg.Text);
                    await bot.SendTextMessageAsync(msg.Chat.Id, "Поменяй имя на тимофей и запомни 112");
                }
            }
        }
        static void Main(string[] args)
        {
            bot.OnMessage += Bot_OnMessage;
            var me = bot.GetMeAsync().Result;
            Console.Title = me.Username;

            bot.StartReceiving();
            
            Random rnd = new Random();
            int hp = 30;
            int presents = 0;
            int enemy = 30;
            int dmg = 2;

            while (true)
            {
                Console.WriteLine("Введите ваше имя");
                string name = Console.ReadLine();
                if (name == "1")
                {
                    Console.WriteLine("112");
                    hp += 1000;

                }
                if (name == "тимофей")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("поменяйте имя на тимофей" + " запомните 112");
                }
            }




            SPAWN:
            Console.WriteLine("вы тимофей");
            Console.ReadKey(); 
            Console.WriteLine("Правила: 1 отвечать цифрами автор наверное это продумал 2 попробуйте выжить 3 запомнить 00123" +
               "не нажимайте Enter во время вопросов");
            Console.ReadKey();
            Console.WriteLine("Вы стоите перед дверью в магазин" +
            " Но у вас нет маски: \n" +
            ",Купить маску? (1.да 2.зайду так(шанс 50%))");
             string answer = Console.ReadLine();
            if (answer == "2")
            {
                int randomNumber = rnd.Next(0, 100);
                if (randomNumber < 60)
                {
                    Console.WriteLine("Покупаем маски))) :_:");
                    Console.ReadKey();
                    goto SPAWN;
                }
                else if (randomNumber > 60 )
                {
                    Console.WriteLine("Вам повезло, но тут не должно быть везения(1 перезапуск 2 перезапуск 3 магия)");
                    answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        goto SPAWN;
                    }
                    else if (answer == "3")
                    {
                        Console.WriteLine("какая ёще магия");
                        Console.ReadKey();
                        goto SPAWN;
                    }
                    else if (answer == "2")
                    {
                        goto SPAWN;
                    }
                }
            }
            while (true)
            {
                if (answer == "1")
                {
                    Console.WriteLine("вы заходите но теряете 1 хп на маску(ваше хп 000000000-)" +
                        "Вы зашли в магазин чтобы купить хлеб\n" +
                            "вы можете украсть хлеб так как тут мало камер(шанс 60% наверно)или купить хп-1 (1.купить2.украсть)");
                    hp -= 1;
                    answer = Console.ReadLine();
                    if (answer == "2")
                    {
                        Console.WriteLine("Ух какая жалость я не просчитал 60% перезапуск");
                        goto SPAWN;
                    }
                    if (answer == "1")
                    {

                        Console.WriteLine("Вы купили хлеб но могли украсть(Ваше хп 0000000---");



                        hp -= 2;                   
                        break;
                    }
                }
            }
            LEVEL2:
            Console.WriteLine("Вы будете сражаться с охранником");
            Console.ReadKey();
            Console.WriteLine("Ваши предметы: 1 хлеб + 3 хп и + 1 к урону");
            Console.WriteLine("Характеристики ваши: 2 урона 15 хп ну и хлеб)а и шанс на уворот 30%");
            Console.ReadKey();
            Console.WriteLine("Характеристики охранника: 2 урона 30 хп");
            Console.ReadKey();
            Console.WriteLine("Будете драться? 1 да 2 да 3 магия ");
            string answer1 = Console.ReadLine();

            if(answer1 == "1")
            {
                while (true)
                {
                    Console.WriteLine("вы начинаете бой");
                    Console.ReadKey();
                    int randomNumber = rnd.Next(0, 100);
                    if (randomNumber > 30)
                    {
                        Console.WriteLine("Вы получаете урон 2");
                        hp -= 2;

                        if (hp < 0)
                        {
                            Console.WriteLine("YOU DIED");
                                goto LEVEL2;
                        }
                    }
                    else if (randomNumber < 30)
                    {
                        Console.WriteLine("вы улоняетесь от удара");
                        Console.ReadKey();
                        Console.WriteLine("Нанести удар? 1да  2 съесть хлеб");
                        string answer2 = Console.ReadLine();
                        if (answer2 == "1")
                        {
                            Console.WriteLine("вы нанесли урон");
                            Console.WriteLine(enemy-dmg);
                            if (enemy < 0)
                            {
                                Console.WriteLine("вы победили");
                                break;
                            }
                        }
                        else if (answer2 == "2")
                        {
                            Console.WriteLine("вы откусили хлеб но шанс на бафф 50%");
                            int randomNumber1 = rnd.Next(0, 100);
                            if (randomNumber1 < 50)
                            {
                                Console.WriteLine("удачный бафф");
                                hp += 10;
                                dmg = +2;
                            }
                            if (randomNumber1 > 50)
                            {
                                Console.WriteLine("бафф не удался");
                                Console.ReadKey();
                            }
                        }
                    }
                }
                
            }
            else
            {
                goto LEVEL2;
            }





            while (true)
            {
                Console.WriteLine("Сейчас мы проверим насколько вы внимательно читаете таблички");
                answer = Console.ReadLine();

                if (answer == "112")
                {
                    Console.WriteLine("Мои почтения");
                    Console.ReadKey();
                    Console.WriteLine("1 медалька");
                    presents += 1;
                    hp *= 2;
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильно");
                    Console.ReadKey();
                    Console.WriteLine("хп минус 1");
                    hp -= 1;

                }
                while (true)
                {
                    Console.WriteLine("Сейчас мы проверим насколько вы внимательно читаете таблички 2 раз");
                    Console.ReadKey();
                    Console.WriteLine("Напишите 2 цифру которую вы видели");

                    answer = Console.ReadLine();

                    if (answer == "00123")
                    {
                        Console.WriteLine("Мои почтения");
                        Console.ReadKey();
                        Console.WriteLine("1 медалька");
                        presents += 1;
                        hp *= 2;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неправильно");
                        Console.ReadKey();
                        Console.WriteLine("хп минус 1");
                        hp -= 1;

                    }
                }
            }




















            Console.WriteLine("Вы вернулись домой у вас хлеб и 2 медальки (1 повторить/2 умереть) ");
            answer = Console.ReadLine();

            if (answer == "1")
            {
                return;

            }
            if (answer == "2")
                if (hp > 0)
                {
                    Console.WriteLine("YOU DIED(выпадение - 1хлеб и минус 1 нервная клетка)");
                    return;
                }
            Console.ReadLine();
            bot.StopReceiving();


        }


















    }
}















