using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
      class Path
    {
        public string From;
        public string To;
    }
    class Node
    {
        public Node NextNode;
        public string City;

        public override string ToString()
        {
            Node curr;
            StringBuilder result = new();
            curr = this;
            while (curr != null)
            {
                result.Append(curr.City);
                if (curr.NextNode != null)
                {
                    result.Append(" ");
                }
                curr = curr.NextNode;
            }

            return result.ToString();
        }
    }

    //Выходит за 2n по скорости и 3n по памяти. Можно просто за n^2 отсортировать изначальный массив, без доп памяти
    //Для ввода данных без консоли, строки 48-57 закомментировать, а строки 42-47 разкоменнтировать 
    class Program
    {
        static void Main(string[] args)
        {
            //List<Path> routeList = new()
            // {
            //     new Path(){From="Tambov", To="Sochi"},
            //     new Path(){From="Orel", To="Moscow"},
            //     new Path(){From="Moscow", To="Tambov"}
            // };
            List<Path> routeList = new();
            int number;
            int.TryParse(Console.ReadLine(), out number);
            for (int i = 0; i < number; i++)
            {
                string line = Console.ReadLine();
                var temp = line.Split(" ");

                routeList.Add(new Path() { From = temp[0], To = temp[1] });
            }

            Dictionary<string, string> toMap = new();
            Dictionary<string, string> fromMap = new();

            Node head;
            Node curr = new();

            foreach (var route in routeList)
            {
                toMap[route.From] = route.To;
                fromMap[route.To] = route.From;
            }
            head = curr;
            var startPoint = routeList[0];

            var to = startPoint.To;
            var from = startPoint.From;

            try
            {
                while (to != null)
                {
                    curr.City = to;
                    to = toMap[to];
                    curr.NextNode = new Node();
                    curr = curr.NextNode;
                }
            }
            catch (Exception ex)
            { }
            try
            {
                while (from != null)
                {
                    head = new Node() { City = from, NextNode = head };
                    from = fromMap[from];
                }
            }
            catch (Exception ex)
            { }
            Console.WriteLine(head);
            Console.ReadLine();
        }
    }
}
