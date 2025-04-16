using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class InternetSupportHandler : SupportHandler
    {
        public InternetSupportHandler()
        {
            subCategories = new Dictionary<string, string>
            {
                {"1", "Відсутнє підключення"},
                {"2", "Повільна швидкість"},
                {"3", "Технічні проблеми"},
                {"4", "Налаштування роутера"}
            };
        }

        public override void HandleRequest(int level)
        {
            if (level == 2)
            {
                DisplaySubCategories();
                string subChoice = Console.ReadLine();

                if (subChoice == "0") return;

                if (subCategories.ContainsKey(subChoice))
                {
                    string response = subChoice switch
                    {
                        "1" => "Технічний спеціаліст зв'яжеться з вами протягом 30 хвилин.",
                        "2" => "Інженер з мереж перевірить ваше підключення протягом 1 години.",
                        "3" => "Техпідтримка дослідить проблему протягом 2 годин.",
                        "4" => "Інструкції з налаштування будуть надіслані протягом 15 хвилин.",
                        _ => "Очікуйте на відповідь протягом 1 години."
                    };
                    LogAndDisplayResponse("Проблема з інтернетом", subCategories[subChoice], response);
                }
            }
            else
            {
                nextHandler?.HandleRequest(level);
            }
        }

    }
}
