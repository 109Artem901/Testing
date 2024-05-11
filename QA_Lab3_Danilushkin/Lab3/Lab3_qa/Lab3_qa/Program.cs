using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace lab2
{   /// <summary>
    /// Класс Tour,вспомогательный класс, для класса Agency
    /// </summary>
    class Tour
    {
        private float Price_;
        private int Quantity_;

        /// <summary>
        /// Метод иницилизации параметров класса Tour
        /// </summary>
        /// <param name="Price">Цена билета</param>
        /// <param name="Quantity">Планируемое количество билетов</param>
        public void Init(float Price, int Quantity)
        {
            Price_ = Price;
            Quantity_ = Quantity;
        }
        /// <summary>
        /// Метод вывода информации о туре на экран
        /// </summary>
        public void Display()
        {
            string s, s1;
            s1 = Convert.ToString(Price_);
            s = "Цена билета: " + s1;
            s1 = Convert.ToString(Quantity_);
            s = s + " Планируемое количество билетов: " + s1 + " шт.";
            /**
             * Обычный комментарий.
             * Ещё один.
             **/
            Console.WriteLine(s);
        }
        /// <summary>
        /// Метод для ввода параметров класса Tour через консоль
        /// </summary>
        public void Read()
        {
            string s = "";
            Console.WriteLine("Введите цену билета и планируемое количество билетов");
            s = Console.ReadLine();
            string[] s1;
            s1 = s.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            Price_ = float.Parse(s1[0]);
            Quantity_ = Convert.ToInt32(s1[1]);
        }
        /// <summary>
        /// Метод вычисляющий ожидаемую сумму продаж, если количество билетов < 0, метод возвращает 0
        /// 
        /// Формула: \f$(Price*Quantity)^2\f$
        ///
        /// Результат: \image html C:\Users\Artem\Documents\GitHub\Testing\QA_Lab3_Danilushkin\IMG\1.jpg
        /// 
        /// </summary>
        /// <returns> Возвращает ожидаемую сумму продаж </returns>
        public float QuPr()
{
    if (Quantity_ == 0)
    {
        return 0;
    }
    return (float)Math.Pow((Price_ * Quantity_), 2);
}
}
/// <summary>
/// Класс Agency, является основным классом по отношению к Tour
/// </summary>
class Agency
{
private string name_;
/// <summary>
/// Переменная с функцией получения имени из приватной переменной name_
/// </summary>
public string Name { get { return name_; } }
private int NTour;
private Tour[] tours;
private int Percent1_;
private int Percent2_;
private int Percent3_;

/// <summary>
/// Метод иницилизации параметров класса Agency, вызывающий метод Init класса Tour, для иницилизации его элементов 
/// </summary>
/// <param name="na">Название тура</param>
/// <param name="n">Количество туров за заезд</param>
/// <param name="Pr">Массив цен на билеты за каждый тур</param>
/// <param name="Qu">Массив количества билетов, для каждого тура</param>
public void Init(string na, int n, float[] Pr, int[] Qu)
{
    tours = new Tour[n];
    NTour = n;
    for (int i = 0; i < NTour; i++)
    {
        tours[i] = new Tour();
    }
    name_ = na;
    for (int i = 0; i < NTour; i++)
    {
        tours[i].Init(Pr[i], Qu[i]);
    }
}
/// <summary>
/// Метод ввода информации реального процента купленных путёвок, вызывающий метод ввода информации о каждом туре класса Tour
/// </summary>
public void Read()
{
    Console.WriteLine("Реальный процент купленных путёвок: ");
    Console.Write("Для тура 1: ");
    Percent1_ = int.Parse(Console.ReadLine());
    Console.Write("Для тура 2: ");
    Percent2_ = int.Parse(Console.ReadLine());
    Console.Write("Для тура 3: ");
    Percent3_ = int.Parse(Console.ReadLine());
    for (int i = 0; i < NTour; i++)
    {
        tours[i].Read();
    }
}
/// <summary>
/// Метод вывода информации о турах, вызывающий метод вывода информации для каждой тура
/// </summary>
public void Display()
{
    Console.WriteLine($"Туры:{name_} ");
    for (int i = 0; i < NTour; i++)
    {
        Console.WriteLine($"Тур {i}: ");
        tours[i].Display();
    }
    Console.WriteLine($"Реальный процент купленных путёвок для тура 1: {Percent1_} процентов");
    Console.WriteLine($"Реальный процент купленных путёвок для тура 2: {Percent2_} процентов");
    Console.WriteLine($"Реальный процент купленных путёвок для тура 3: {Percent3_} процентов");
}
/// <summary>
/// Метод вычисляющий сумму денег от продажи всех туров   
/// </summary>
/// <returns>Возвращает сумму денег от продажи всех туров</returns>
public float AverageQuPr()
{
    float totalArea = 0;
    for (int i = 0; i < NTour; i++)
    {
        totalArea += tours[i].QuPr();
    }


    return totalArea;
}
/// <summary>
/// Метод находящий тур с наибольшей ожидаемой суммой продаж
/// </summary>
/// <returns>Возвращает тур типа Tour с максимальной ожидаемой суммой продаж </returns>
public Tour FindMax()
{
    Tour maxPr = new Tour();
    float maxPrice = 0;

    for (int i = 0; i < NTour; i++)
    {
        if (maxPrice < tours[i].QuPr())
        {
            maxPrice = tours[i].QuPr();
        }
    }
    for (int i = 0; i < NTour; i++)
    {
        if (maxPrice == tours[i].QuPr())
        {
            maxPr = tours[i];
        }
    }
    return maxPr;

}
}

/// <summary>
/// Касс Program, является основным классом программы
/// </summary>
class Program
{
/// <summary>
/// Основной метод программы 
/// </summary>
/// <param name="args"></param>
static void Main(string[] args)
{
    string name = "Заезд 1";
    int N = 3; //количество туров в заезде
    float[] Pr = new float[3] { 1300, 1000, 1800 };//инициализируем массив цен за билеты в турах
    int[] Qu = new int[3] { 10, 12, 8 };//инициализируем массив количества билетов для каждого тура

    Agency tour = new Agency();

    tour.Init(name, N, Pr, Qu);
    tour.Read();


    Console.WriteLine("Данные о заезде по турам: ");
    tour.Display();
    Console.WriteLine("Сумма денег от продажи всех туров: " + tour.AverageQuPr());
    Console.WriteLine("Тур с наибольшей ожидаемой суммой продаж: ");
    Tour maxPri = tour.FindMax();
    maxPri.Display();
    Console.ReadKey();

}
}
}
