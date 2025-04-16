using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class BillingSupportHandler : SupportHandler
    {
        public BillingSupportHandler()
        {
            subCategories = new Dictionary<string, string>
            {
                {"1", "Некоректний рахунок"},
                {"2", "Питання щодо оплати"},
                {"3", "Повернення коштів"},
                {"4", "Скарги на обслуговування"}
            };
        }

        public override void HandleRequest(int level)
        {
            if (level == 1)
            {
                DisplaySubCategories();
                string subChoice = Console.ReadLine();

                if (subChoice == "0") return;

                if (subCategories.ContainsKey(subChoice))
                {
                    if (subChoice == "4")
                    {
                        HandleComplaint();
                    }
                    else
                    {
                        string response = subChoice switch
                        {
                            "1" => "Фахівець з рахунків зв'яжеться з вами протягом 1 години.",
                            "2" => "Відділ оплати надасть відповідь протягом 2 годин.",
                            "3" => "Ваш запит на повернення буде оброблено протягом 24 годин.",
                            _ => "Очікуйте на відповідь протягом 3 годин."
                        };
                        LogAndDisplayResponse("Проблема з рахунком", subCategories[subChoice], response);
                    }
                }
            }
            else
            {
                nextHandler?.HandleRequest(level);
            }
        }

        private void HandleComplaint()
        {
            Console.WriteLine("\nОцініть терміновість скарги від 1 до 3:");
            Console.WriteLine("1 - Низька терміновість");
            Console.WriteLine("2 - Середня терміновість");
            Console.WriteLine("3 - Висока терміновість");

            while (!int.TryParse(Console.ReadLine(), out complaintPriority) || complaintPriority < 1 || complaintPriority > 3)
            {
                Console.WriteLine("Будь ласка, введіть число від 1 до 3");
            }

            string response = complaintPriority switch
            {
                3 => "Керівник відділу якості зв'яжеться з вами протягом 1 години.",
                2 => "Спеціаліст відділу якості зв'яжеться з вами протягом 3 годин.",
                1 => "Ваша скарга буде розглянута протягом 24 годин.",
                _ => "Ваша скарга буде розглянута протягом 24 годин."
            };

            LogAndDisplayResponse("Проблема з рахунком", subCategories["4"], response);
        }
    }
}
