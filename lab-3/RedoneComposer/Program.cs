﻿using RedoneComposer;
using System;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var rootDiv = new LightElementNode("div", "block", false);
        rootDiv.CssClassList.Add("main-container");

        var heading = new LightElementNode("h2", "block", false);
        heading.AddChild(new LightTextNode("Список і таблиця в LightHTML"));

        var list = new LightElementNode("ul", "block", false);
        var listItem1 = new LightElementNode("li", "block", false);
        listItem1.AddChild(new LightTextNode("Пункт 1"));
        var listItem2 = new LightElementNode("li", "block", false);
        listItem2.AddChild(new LightTextNode("Пункт 2"));
        var listItem3 = new LightElementNode("li", "block", false);
        listItem3.AddChild(new LightTextNode("Пункт 3"));
        list.AddChild(listItem1);
        list.AddChild(listItem2);
        list.AddChild(listItem3);

        listItem1.AddEventListener("click", (element) => {
            Console.WriteLine($"Клікнуто на елемент списку: {element.InnerHTML()}");
        });

        listItem2.AddEventListener("click", (element) => {
            Console.WriteLine($"Клікнуто на другому пункті списку!");
        });

        var table = new LightElementNode("table", "block", false);
        table.CssClassList.Add("data-table");

        table.AddEventListener("mouseover", (element) => {
            Console.WriteLine("Курсор миші над таблицею!");
        });

        var tableRowHeader = new LightElementNode("tr", "block", false);
        var th1 = new LightElementNode("th", "inline", false);
        th1.AddChild(new LightTextNode("Ім'я"));
        var th2 = new LightElementNode("th", "inline", false);
        th2.AddChild(new LightTextNode("Вік"));
        tableRowHeader.AddChild(th1);
        tableRowHeader.AddChild(th2);

        var tableRow1 = new LightElementNode("tr", "block", false);
        var td1 = new LightElementNode("td", "inline", false);
        td1.AddChild(new LightTextNode("Аня"));
        var td2 = new LightElementNode("td", "inline", false);
        td2.AddChild(new LightTextNode("18"));
        tableRow1.AddChild(td1);
        tableRow1.AddChild(td2);

        var tableRow2 = new LightElementNode("tr", "block", false);
        var td3 = new LightElementNode("td", "inline", false);
        td3.AddChild(new LightTextNode("Богдан"));
        var td4 = new LightElementNode("td", "inline", false);
        td4.AddChild(new LightTextNode("20"));
        tableRow2.AddChild(td3);
        tableRow2.AddChild(td4);

        table.AddChild(tableRowHeader);
        table.AddChild(tableRow1);
        table.AddChild(tableRow2);

        rootDiv.AddChild(heading);
        rootDiv.AddChild(list);
        rootDiv.AddChild(table);

        Console.WriteLine(rootDiv.OuterHTML());

        Console.WriteLine("\nСимуляція подій:");
        listItem1.TriggerEvent("click");
        listItem2.TriggerEvent("click");
        table.TriggerEvent("mouseover");

        var localImage = new LightImageNode("images/photo.jpg");
        var webImage1 = new LightImageNode("http://example.com/image.png");
        var webImage2 = new LightImageNode("https://example.com/pic.jpg");

        Console.WriteLine("Демонстрація роботи стратегій завантаження:");
        Console.WriteLine("-------------------------------------------");

        Console.WriteLine("\nЛокальне зображення:");
        Console.WriteLine(localImage.OuterHTML());
        localImage.LoadImage();
        Console.WriteLine(localImage.GetLoadingInfo());

        Console.WriteLine("\nМережне зображення (HTTP):");
        Console.WriteLine(webImage1.OuterHTML());
        webImage1.LoadImage();
        Console.WriteLine(webImage1.GetLoadingInfo());

        Console.WriteLine("\nМережне зображення (HTTPS):");
        Console.WriteLine(webImage2.OuterHTML());
        webImage2.LoadImage();
        Console.WriteLine(webImage2.GetLoadingInfo());

        Console.WriteLine("Демонстрація життєвого циклу елементів:");
        Console.WriteLine("--------------------------------------");

        var rootDiv2 = new LightElementNode("div", "block", false);
        rootDiv2.CssClassList.Add("main-container");

        var heading2 = new LightElementNode("h2", "block", false);
        heading2.AddChild(new LightTextNode("Життєвий цикл елементів"));

        var paragraph = new LightElementNode("p", "block", false);
        paragraph.CssClassList.Add("description");
        paragraph.AddChild(new LightTextNode("Це демонстрація хуків життєвого циклу."));

        var list2 = new LightElementNode("ul", "block", false);
        var listItem1_2 = new LightElementNode("li", "block", false);
        listItem1_2.AddChild(new LightTextNode("Перший пункт"));
        var listItem2_2 = new LightElementNode("li", "block", false);
        listItem2_2.AddChild(new LightTextNode("Другий пункт"));

        rootDiv2.AddChild(heading2);
        rootDiv2.AddChild(paragraph);
        rootDiv2.AddChild(list2);

        list2.AddChild(listItem1_2);
        list2.AddChild(listItem2_2);

        Console.WriteLine("\nВивід HTML:");
        Console.WriteLine(rootDiv2.Render());

        Console.WriteLine("\nВидалення елемента:");
        list2.RemoveChild(listItem2_2);

        Console.WriteLine("\nКінцевий HTML:");
        Console.WriteLine(rootDiv2.OuterHTML());

        Console.WriteLine("\nДемонстрація роботи ітераторів:");
        Console.WriteLine("--------------------------------");

        Console.WriteLine("\nОбхід DOM в глибину (Depth-First):");
        var depthIterator = rootDiv.GetDepthFirstIterator();

        while (depthIterator.HasNext())
        {
            var node = depthIterator.Next();
            var level = depthIterator.CurrentLevel;

            if (node is LightElementNode elementNode)
            {
                Console.WriteLine($"[Рівень {level}] Елемент: <{elementNode.TagName}>");
            }
            else if (node is LightTextNode textNode)
            {
                string escapedText = textNode.TextContent.Replace("'", "\\'");
                Console.WriteLine($"[Рівень {level}] Текст: \"{escapedText}\"");
            }
        }

        Console.WriteLine("\nОбхід DOM в ширину (Breadth-First) з правильними рівнями:");
        var breadthIterator = rootDiv.GetBreadthFirstIterator();
        string currentSection = "";

        while (breadthIterator.HasNext())
        {
            var node = breadthIterator.Next();
            var level = breadthIterator.CurrentLevel;

            if (node is LightElementNode elementNode)
            {
                if (elementNode.TagName == "table" && currentSection != "table")
                {
                    Console.WriteLine("\n--- Таблиця ---");
                    currentSection = "table";
                }
                else if (elementNode.TagName == "ul" && currentSection != "list")
                {
                    Console.WriteLine("\n--- Список ---");
                    currentSection = "list";
                }

                Console.WriteLine($"[Рівень {level}] Елемент: <{elementNode.TagName}>");
            }
            else if (node is LightTextNode textNode)
            {
                string escapedText = textNode.TextContent.Replace("'", "\\'");
                Console.WriteLine($"[Рівень {level}] Текст: \"{escapedText}\"");
            }
        }


        Console.WriteLine("\nДемонстрація шаблону Команда (Історія дій):");
        Console.WriteLine("-----------------------------------------");

        var commandHistory = new CommandHistory();
        var demoDiv = new LightElementNode("div", "block", false);

        Console.WriteLine("\nПочатковий HTML:");
        Console.WriteLine(demoDiv.OuterHTML());

        var heading4 = new LightElementNode("h1", "block", false);
        var addHeadingCommand = new AddChildCommand(demoDiv, heading4);
        commandHistory.ExecuteCommand(addHeadingCommand);

        Console.WriteLine("\nПісля додавання заголовка:");
        Console.WriteLine(demoDiv.OuterHTML());

        var textNode4 = new LightTextNode("Демонстрація команди");
        var addTextCommand = new AddChildCommand(heading4, textNode4);
        commandHistory.ExecuteCommand(addTextCommand);

        Console.WriteLine("\nПісля додавання тексту:");
        Console.WriteLine(demoDiv.OuterHTML());

        commandHistory.Undo();
        Console.WriteLine("\nПісля Undo (видалення тексту):");
        Console.WriteLine(demoDiv.OuterHTML());


        commandHistory.Redo();
        Console.WriteLine("\nПісля Redo (повторне додавання тексту):");
        Console.WriteLine(demoDiv.OuterHTML());

        var removeHeadingCommand = new RemoveChildCommand(demoDiv, heading4);
        commandHistory.ExecuteCommand(removeHeadingCommand);

        Console.WriteLine("\nПісля видалення заголовка:");
        Console.WriteLine(demoDiv.OuterHTML());

        commandHistory.Undo();
        Console.WriteLine("\nПісля Undo (повернення заголовка):");
        Console.WriteLine(demoDiv.OuterHTML());

        Console.WriteLine("\nДемонстрація шаблону Стейт (Очищена версія):");
        Console.WriteLine("-------------------------------------------");

        var cleanStateDiv = new LightElementNode("div", "block", false);
        cleanStateDiv.AddChild(new LightTextNode("Чиста демонстрація станів"));

        Console.WriteLine("\nПочатковий стан:");
        Console.WriteLine($"Стан: {cleanStateDiv.GetCurrentState()}");
        Console.WriteLine(cleanStateDiv.OuterHTML());

        Console.WriteLine("\nПереводимо в стан 'виділено':");
        cleanStateDiv.SetState(new HighlightedState());
        Console.WriteLine(cleanStateDiv.OuterHTML());

        Console.WriteLine("\nПереводимо в стан 'сховано':");
        cleanStateDiv.SetState(new HiddenState());
        Console.WriteLine(cleanStateDiv.OuterHTML());

        Console.WriteLine("\nПовертаємо в стан 'видимий':");
        cleanStateDiv.SetState(new VisibleState());
        Console.WriteLine(cleanStateDiv.OuterHTML());



        Console.WriteLine("\nДемонстрація шаблону Відвідувач:");
        Console.WriteLine("--------------------------------");

       
        Console.WriteLine("\n1. Підрахунок елементів:");
        var counter = new ElementCounterVisitor();
        rootDiv.Accept(counter);
        Console.WriteLine($"Знайдено елементів: {counter.ElementCount}");
        Console.WriteLine($"Знайдено текстових вузлів: {counter.TextCount}");

        Console.WriteLine("\n2. Збір CSS класів:");
        var classCollector = new ClassCollectorVisitor();
        rootDiv.Accept(classCollector);
        Console.WriteLine("Використані CSS класи:");
        foreach (var cssClass in classCollector.Classes)
        {
            Console.WriteLine($"- {cssClass}");
        }

        Console.WriteLine("\n3. Спеціальний рендеринг через Visitor:");
        var renderer = new NodeRendererVisitor();
        rootDiv.Accept(renderer);
        Console.WriteLine(renderer.Output.ToString());
        Console.WriteLine("\nДемонстрація обробки зображень через Visitor:");

        var imageContainer = new LightElementNode("div", "block", false);
        imageContainer.AddChild(new LightImageNode("images/photo.jpg"));
        imageContainer.AddChild(new LightImageNode("http://example.com/image.png"));

        
        var imageCounter = new ElementCounterVisitor();
        imageContainer.Accept(imageCounter);
        Console.WriteLine($"Знайдено елементів: {imageCounter.ElementCount}");
        Console.WriteLine($"Знайдено текстових вузлів: {imageCounter.TextCount}");
        Console.WriteLine($"Знайдено зображень: {imageCounter.ImageCount}");

        
        var imageRenderer = new NodeRendererVisitor();
        imageContainer.Accept(imageRenderer);
        Console.WriteLine(imageRenderer.Output.ToString());

        Console.WriteLine("\nДемонстрація шаблону Макрокоманда:");
        Console.WriteLine("---------------------------------");

        var history = new CommandHistory();
        var macroContainer = new LightElementNode("div", "block", false); 

        var createTableMacro = new MacroCommand("Створити таблицю");

        var macroTable = new LightElementNode("table", "block", false);
        var headerRow = new LightElementNode("tr", "block", false);
        var headerCell = new LightElementNode("th", "inline", false);
        headerCell.AddChild(new LightTextNode("Колонка 1"));

        createTableMacro.AddCommand(new AddChildCommand(headerRow, headerCell));
        createTableMacro.AddCommand(new AddChildCommand(macroTable, headerRow)); 
        createTableMacro.AddCommand(new AddChildCommand(macroContainer, macroTable)); 

        history.ExecuteCommand(createTableMacro);

        Console.WriteLine("\nРезультат після створення таблиці:");
        Console.WriteLine(macroContainer.OuterHTML());







        
        Console.WriteLine("\nДемонстрація валідації HTML:");
        Console.WriteLine("---------------------------");

        
        var invalidHtml = new LightElementNode("div", "block", false);
        invalidHtml.AddChild(new LightElementNode("li", "block", false)); 
        invalidHtml.AddChild(new LightElementNode("table", "block", false));
        invalidHtml.AddChild(new LightElementNode("td", "inline", false)); 
        
        var validHtml = new LightElementNode("div", "block", false);
        var validList = new LightElementNode("ul", "block", false);
        validList.AddChild(new LightElementNode("li", "block", false));
        validHtml.AddChild(validList);

        var validTable = new LightElementNode("table", "block", false);
        var validRow = new LightElementNode("tr", "block", false);
        validRow.AddChild(new LightElementNode("th", "inline", false));
        validTable.AddChild(validRow);
        validHtml.AddChild(validTable);

        var validator = new HtmlValidationVisitor();
        invalidHtml.Accept(validator);
        validator.AfterVisit();

        Console.WriteLine("\nРезультати валідації (з помилками):");
        foreach (var error in validator.Errors)
        {
            Console.WriteLine($"- {error}");
        }

        validator = new HtmlValidationVisitor();
        validHtml.Accept(validator);
        validator.AfterVisit();

        Console.WriteLine("\nРезультати валідації (коректний HTML):");
        if (validator.Errors.Count == 0)
        {
            Console.WriteLine("- HTML валідний, помилок не знайдено");
        }
        else
        {
            foreach (var error in validator.Errors)
            {
                Console.WriteLine($"- {error}");
            }
        }

    }
}