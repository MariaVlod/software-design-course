using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class TVSupportHandler : SupportHandler
    {
        public TVSupportHandler()
        {
            subCategories = new Dictionary<string, string>
            {
                {"1", "Відсутній сигнал"},
                {"2", "Проблеми з каналами"},
                {"3", "Налаштування приставки"},
                {"4", "Технічні несправності"}
            };
        }

        public override void HandleRequest(int level)
        {
            if (level == 3)
            {
                DisplaySubCategories();
                string subChoice = Console.ReadLine();

                if (subChoice == "0") return;

                if (subCategories.ContainsKey(subChoice))
                {
                    string response = subChoice switch
                    {
                        "1" => "Технічний спеціаліст перевірить сигнал протягом 1 години.",
                        "2" => "Проблема з каналами буде вирішена протягом 2 годин.",
                        "3" => "Інструкції з налаштування будуть надіслані протягом 20 хвилин.",
                        "4" => "Інженер приїде для перевірки обладнання протягом 24 годин.",
                        _ => "Очікуйте на відповідь протягом 1 години."
                    };
                    LogAndDisplayResponse("Проблема з телебаченням", subCategories[subChoice], response);
                }
            }
            else
            {
                nextHandler?.HandleRequest(level);
            }
        }
    }
}
