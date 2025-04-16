using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class PhoneSupportHandler : SupportHandler
    {
        public PhoneSupportHandler()
        {
            subCategories = new Dictionary<string, string>
            {
                {"1", "Відсутній зв'язок"},
                {"2", "Проблеми з якістю зв'язку"},
                {"3", "Налаштування послуг"},
                {"4", "Технічні несправності"}
            };
        }

        public override void HandleRequest(int level)
        {
            if (level == 4)
            {
                DisplaySubCategories();
                string subChoice = Console.ReadLine();

                if (subChoice == "0") return;

                if (subCategories.ContainsKey(subChoice))
                {
                    string response = subChoice switch
                    {
                        "1" => "Мережевий інженер перевірить стан зв'язку протягом 1 години.",
                        "2" => "Технічний спеціаліст дослідить проблему протягом 2 годин.",
                        "3" => "Консультант з послуг зв'яжеться з вами протягом 30 хвилин.",
                        "4" => "Інженер приїде для перевірки обладнання протягом 24 годин.",
                        _ => "Очікуйте на відповідь протягом 1 години."
                    };
                    LogAndDisplayResponse("Проблема з телефонією", subCategories[subChoice], response);
                }
            }
            else
            {
                nextHandler?.HandleRequest(level);
            }
        }
    }
}
