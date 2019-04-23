using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets
{
    class Program
    {
        static void Main(string[] args)
        {

            string menu;
            Train train;    // выбранный поезд
            Car car;        // выбранный вагон
            Place place;    // выбранное место

            var choice = new Choice();
            choice.DataInit();

            Console.WriteLine("\n\t\t ПОКУПКА ЖЕЛЕЗНОДОРОЖНЫХ БИЛЕТОВ");
            while (true)
            {
                Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("\n\t\tГлавное меню:\n");
                Console.WriteLine("\t1 - Покупка билетов");
                Console.WriteLine("\t0 - Выход\n");
                Console.Write("\tВаш выбор = ");
                menu = Console.ReadLine();

                if (menu == "0")
                {
                    break;
                }
                if (menu == "1")   // покупка билетов
                {
                    train = choice.ChoiceTrain();

                    if (train != null)
                    {
                        car = choice.ChoiceCar(train);
                        if (car != null)
                        {
                            place = choice.ChoicePlace(car);
                            if (place !=null)
                            {
                                choice.PlaceActions(place);
                            }
                        }
                    }
                    continue;
                }
            }
        }
    }
}
