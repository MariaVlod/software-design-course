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

        var table = new LightElementNode("table", "block", false);
        table.CssClassList.Add("data-table");

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
    }
}