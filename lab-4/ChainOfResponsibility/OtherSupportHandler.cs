using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class OtherSupportHandler : SupportHandler
    {
        public OtherSupportHandler()
        {
            subCategories = new Dictionary<string, string>
            {
                {"1", "Юридичні питання"},
                {"2", "Фінансові питання"},
                {"3", "HR питання"},
                {"4", "Інші скарги"}
            };
        }

        public override void HandleRequest(int level)
        {
            if (level == 5)
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
                            "1" => "Юрист компанії зв'яжеться з вами протягом 48 годин.",
                            "2" => "Фінансовий відділ надасть відповідь протягом 24 годин.",
                            "3" => "HR менеджер відповість на ваш запит протягом 12 годин.",
                            _ => "Ваш запит буде розглянуто протягом 24 годин."
                        };
                        LogAndDisplayResponse("Інша проблема", subCategories[subChoice], response);
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

            LogAndDisplayResponse("Інша проблема", subCategories["4"], response);
        }
    }
}
