using RedoneComposer;
using System;
using System.Collections.Generic;

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
    }
}