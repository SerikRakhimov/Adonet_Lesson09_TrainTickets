using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets
{
    public class Choice
    {
        private string check;
        private int i, number;

        public void DataInit()
        {

            using (DataContext context = new DataContext())
            {
                // очистка таблиц, пример -  http://www.dotnetblog.ru/2014/10/entity-framework.html
                context.Places.RemoveRange(context.Places);
                context.Cars.RemoveRange(context.Cars);
                context.Trains.RemoveRange(context.Trains);
                context.SaveChanges();

                Train train1 = new Train
                {
                    Number = "501",
                    StationFrom = "АСТАНА",
                    StationTo = "АЛМАТЫ",
                    Data = DateTime.Now
                };
                Train train2 = new Train
                {
                    Number = "502",
                    StationFrom = "КАРАГАНДА",
                    StationTo = "АЛМАТЫ",
                    Data = DateTime.Now
                };
                Train train3 = new Train
                {
                    Number = "503",
                    StationFrom = "ПЕТРОПАВЛОВСК",
                    StationTo = "АЛМАТЫ",
                    Data = DateTime.Now
                };
                context.Trains.AddRange(new List<Train> { train1, train2, train3 });
                Car car1 = new Car { Number = "1", Train = train1 };
                Car car2 = new Car { Number = "2", Train = train1 };
                Car car3 = new Car { Number = "3", Train = train1 };
                Car car4 = new Car { Number = "1", Train = train2 };
                Car car5 = new Car { Number = "2", Train = train2 };
                Car car6 = new Car { Number = "3", Train = train2 };
                Car car7 = new Car { Number = "1", Train = train3 };
                Car car8 = new Car { Number = "2", Train = train3 };
                Car car9 = new Car { Number = "3", Train = train3 };
                context.Cars.AddRange(new List<Car> { car1, car2, car3, car4, car5, car6, car7, car8, car9 });
                context.Places.AddRange(new List<Place>
                {
                    new Place {Number = "01", Price = 5000, Car=car1}, new Place { Number = "02", Price = 5000, Car = car1 }, new Place { Number = "03", Price = 5000, Car = car1 },
                    new Place {Number = "01", Price = 5000, Car=car2}, new Place { Number = "02", Price = 5000, Car = car2 }, new Place { Number = "03", Price = 5000, Car = car2 },
                    new Place {Number = "01", Price = 5000, Car=car3}, new Place { Number = "02", Price = 5000, Car = car3 }, new Place { Number = "03", Price = 5000, Car = car3 },
                    new Place {Number = "01", Price = 5000, Car=car4}, new Place { Number = "02", Price = 5000, Car = car4 }, new Place { Number = "03", Price = 5000, Car = car4 },
                    new Place {Number = "01", Price = 5000, Car=car5}, new Place { Number = "02", Price = 5000, Car = car5 }, new Place { Number = "03", Price = 5000, Car = car5 },
                    new Place {Number = "01", Price = 5000, Car=car6}, new Place { Number = "02", Price = 5000, Car = car6 }, new Place { Number = "03", Price = 5000, Car = car6 },
                    new Place {Number = "01", Price = 5000, Car=car7}, new Place { Number = "02", Price = 5000, Car = car7 }, new Place { Number = "03", Price = 5000, Car = car7 },
                    new Place {Number = "01", Price = 5000, Car=car8}, new Place { Number = "02", Price = 5000, Car = car8 }, new Place { Number = "03", Price = 5000, Car = car8 },
                    new Place {Number = "01", Price = 5000, Car=car9}, new Place { Number = "02", Price = 5000, Car = car9 }, new Place { Number = "03", Price = 5000, Car = car9 }
                });
                context.SaveChanges();

                //// вывод 

                //var cars = context.Cars.ToList();
                //foreach (Car car in cars)
                //    Console.WriteLine("{0} - {1}", car.Number, car.Train != null ? car.Train.Number : "");
                //Console.WriteLine();

                //var places = context.Places.ToList();
                //foreach (Place place in places)
                //    Console.WriteLine("{0} - {1} - {2}", place.Number, place.Car != null ? place.Car.Number : "", place.Car.Train != null ? place.Car.Train.Number : "");
                //Console.WriteLine();

                //var trains = context.Trains.ToList();

                //trains.Sort(delegate (Train train11, Train train12)
                //{ return train11.Number.CompareTo(train12.Number); });

                //foreach (Train train in trains)
                //{
                //    Console.WriteLine("Поезд: {0}", train.Number);
                //    context.Entry(train).Collection("Cars").Load();
                //    foreach (Car car in train.Cars)
                //    {
                //        Console.WriteLine("Вагон: {0}", car.Number);
                //        context.Entry(car).Collection("Places").Load();
                //        foreach (Place place in car.Places)
                //        {
                //            Console.WriteLine("Место: {0}", place.Number);
                //        }
                //        Console.WriteLine();
                //    }
                //}
            }
        }

        public Train ChoiceTrain()
        {

            Train result = null;

            using (DataContext context = new DataContext())
            {
                var trains = context.Trains.ToList();

                trains.Sort(delegate (Train train1, Train train2)  // про сортировку см. http://www.skillcoding.com/Default.aspx?id=198
                { return train1.Number.CompareTo(train2.Number); });

                Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                if (trains.Count == 0)
                {
                    Console.WriteLine($"\tСписок поездов пуст.");
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("\n\tСписок поездов:\n");
                        i = 0;
                        foreach (var train in trains)
                        {
                            i++;
                            Console.WriteLine($"\t{i} - поезд № {train.Number} {train.Data.ToShortDateString()} {train.StationFrom}-{train.StationTo}");
                        };

                        Console.WriteLine($"\n\t0 - выход");
                        Console.Write($"\n\tВведите номер поезда (1-{trains.Count}) = ");
                        check = Console.ReadLine();

                        try
                        {
                            number = int.Parse(check);
                            if (number == 0)  // выход с программы
                            {
                                break;
                            }
                            if (1 <= number && number <= trains.Count)
                            {
                                break;
                            }

                        }
                        catch
                        {
                        }
                    }

                    if (number != 0)
                    {
                        number--;
                        result = trains[number];
                        context.Entry(result).Collection("Cars").Load();
                    }

                }
            }
            return result;
        }

        public Car ChoiceCar(Train train)
        {

            Car result = null;

            using (DataContext context = new DataContext())
            {

                var trains = context.Trains.ToList();
                Train trainwork = null;
                foreach (var t in trains)
                {
                    if (t.Id == train.Id)
                    {
                        trainwork = t;
                    }
                }

                var cars = trainwork.Cars.ToList();

                cars.Sort(delegate (Car car1, Car car2)  // про сортировку см. http://www.skillcoding.com/Default.aspx?id=198
                { return car1.Number.CompareTo(car2.Number); });

                Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"\n\tПоезд: {train.Number} {train.Data.ToShortDateString()} {train.StationFrom}-{train.StationTo}");
                if (cars.Count == 0)
                {
                    Console.WriteLine($"\tСписок вагонов пуст.");
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("\n\tСписок вагонов:\n");
                        i = 0;
                        foreach (var car in cars)
                        {
                            i++;
                            Console.WriteLine($"\t{i} - вагон № {car.Number} ");
                        };

                        Console.WriteLine($"\n\t0 - выход");
                        Console.Write($"\n\tВведите номер вагона (1-{cars.Count}) = ");
                        check = Console.ReadLine();

                        try
                        {
                            number = int.Parse(check);
                            if (number == 0)  // выход с программы
                            {
                                break;
                            }
                            if (1 <= number && number <= cars.Count)
                            {
                                break;
                            }

                        }
                        catch
                        {
                        }
                    }

                    if (number != 0)
                    {
                        number--;
                        result = cars[number];
                        context.Entry(result).Collection("Places").Load();
                    }

                }
            }
            return result;
        }

        public Place ChoicePlace(Car car)
        {

            Place result = null;

            using (DataContext context = new DataContext())
            {
                var places = car.Places.ToList();
                
                places.Sort(delegate (Place place1, Place place2)  // про сортировку см. http://www.skillcoding.com/Default.aspx?id=198
                { return place1.Number.CompareTo(place2.Number); });

                Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"\n\tПоезд: {car.Train.Number} {car.Train.Data.ToShortDateString()} {car.Train.StationFrom}-{car.Train.StationTo}");
                Console.WriteLine($"\tВагон: {car.Number}");
                if (places.Count == 0)
                {
                    Console.WriteLine($"\tСписок мест пуст.");
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("\n\tСписок мест:\n");
                        i = 0;
                        foreach (var place in places)
                        {
                            i++;
                            Console.Write($"\t{i} - Место № {place.Number}  Цена = {place.Price}  ");
                            if (place.Pay == true)
                            {
                                Console.WriteLine("Оплачено");
                            }
                            else
                            {
                                Console.WriteLine("Свободно");
                            }
                        };

                        Console.WriteLine($"\n\t0 - выход");
                        Console.Write($"\n\tВведите номер места (1-{places.Count}) = ");
                        check = Console.ReadLine();

                        try
                        {
                            number = int.Parse(check);
                            if (number == 0)  // выход с программы
                            {
                                break;
                            }
                            if (1 <= number && number <= places.Count)
                            {
                                break;
                            }

                        }
                        catch
                        {
                        }
                    }

                    if (number != 0)
                    {
                        number--;
                        result = places[number];
                    }

                }
            }
            return result;
        }


        public void PlaceActions(Place place)
        {
            string menu, cardNumber,fio;

            Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"\tПоезд: {place.Car.Train.Number}");
            Console.WriteLine($"\tВагон: {place.Car.Number}");
            Console.WriteLine($"\tМесто: № {place.Number}");
            Console.WriteLine($"\tСтоимость: {place.Price} тнг");

            if (place.Pay == false)
            {
                while (true)
                {
                    Console.WriteLine("\n\t1 - Купить билет");
                    Console.WriteLine("\t0 - Выход\n");
                    Console.Write("\tВаш выбор = ");
                    menu = Console.ReadLine();

                    if (menu == "0")
                    {
                        break;
                    }
                    if (menu == "1")   // купить билет
                    {
                        fio = "";
                        while (fio == "")
                        {
                            Console.Write("\n\tФамилия И.О. пассажира = ");
                            fio = Console.ReadLine();
                        }
                        Console.WriteLine("\n\tНомер Вашей банковской карточки, с которой будет произведена");
                        Console.Write($"\tоплата в размере {place.Price} тенге (0 - отказ) = ");
                        cardNumber = Console.ReadLine();

                        if (cardNumber == "" || cardNumber == "0")
                        {
                            Console.WriteLine("\n\tНомер карты не введен, оплата не произведена.");
                            Console.WriteLine("\t*********************************************");
                        }
                        else
                        {
                            using (DataContext context = new DataContext())
                            {

                                var places = context.Places.ToList();
                                Place placework = null;
                                foreach (var p in places)
                                {
                                    if (p.Id == place.Id)
                                    {
                                        placework = p;
                                    }
                                }
                                placework.Pay = true;
                                placework.Fio = fio;
                                placework.CardNumber = cardNumber;
                                context.SaveChanges();
                                Console.WriteLine("\n\tОплата произведена.");
                                Console.WriteLine("\t*******************");
                            }
                        };

                        break;
                    }
                    continue;
                }
            }
            else if (place.Pay == true)
            {
                Console.WriteLine("\n\tМесто уже оплачено.");
                Console.WriteLine("\t*******************");
            }
        }
    }
}
