using System.Globalization;

namespace RentCarChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            Car Ka = new Car();
            Ka.Model = "Ka 1.0 SEL TiVCT Flex 5p";
            Ka.Category = 1;
            Ka.Weekday = 130;
            Ka.Weekendday = 120;
            Ka.WeekdayFidelidade = 100;
            Ka.WeekenddayLoyalty = 90;

            Car Yaris = new Car();
            Yaris.Model = "YARIS XL 1.3 Flex 16V 5p Aut.";
            Yaris.Category = 2;
            Yaris.Weekday = 120;
            Yaris.Weekendday = 120;
            Yaris.WeekdayFidelidade = 110;
            Yaris.WeekenddayLoyalty = 100;

            Car VIRTUS = new Car();
            VIRTUS.Model = "VIRTUS 1.6 MSI Flex 16V 4p Aut.";
            VIRTUS.Category = 3;
            VIRTUS.Weekday = 140;
            VIRTUS.Weekendday = 110;
            VIRTUS.WeekdayFidelidade = 120;
            VIRTUS.WeekenddayLoyalty = 80;

            Car Doblo = new Car();
            Doblo.Model = "Doblo  1.4 mpi Fire Flex  8V 4p";
            Doblo.Category = 4;
            Doblo.Weekday = 150;
            Doblo.Weekendday = 100;
            Doblo.WeekdayFidelidade = 130;
            Doblo.WeekenddayLoyalty = 110;

            Car Hilux = new Car();
            Hilux.Model = "Hilux 4x2 2.4 Diesel";
            Hilux.Category = 5;
            Hilux.Weekday = 130;
            Hilux.Weekendday = 100;
            Hilux.WeekdayFidelidade = 130;
            Hilux.WeekenddayLoyalty = 80;

            Car[] carros = new Car[5];
            carros[0] = Ka;
            carros[1] = Yaris;
            carros[2] = VIRTUS;
            carros[3] = Doblo;
            carros[4] = Hilux;

            Console.WriteLine("Digite a linha de comando: ");
            string input = Console.ReadLine();
            (Customer customer, DateTime starDate, DateTime endDate) inputs = cmdLineParse(input);

            Car cheaper = CheapestCar(carros, inputs.customer, inputs.starDate, inputs.endDate);

            Console.WriteLine($"Carro mais barato: {cheaper.Model} Categoria: {cheaper.Category} Preço total: R$ {precoCarro(cheaper, inputs.customer, inputs.starDate, inputs.endDate)}");
        }

        public static (Customer customer, DateTime starDate, DateTime endDate) cmdLineParse(string cmdLine)
        {
            string[] partes = cmdLine.Split(':');
            if (partes.Length != 2)
            {
                throw new ArgumentException("Formato inválido.");
            }

            Customer customer = new Customer();
            string tipoDoCliente = partes[0].Trim();

            if (tipoDoCliente == "REGULAR")
            {
                customer.IsFidelidade = false;
            }
            else if (tipoDoCliente == "FIDELIDADE")
            {
                customer.IsFidelidade = true;
            }
            else
            {
                throw new ArgumentException("Tipo do cliente nao identificado");
            }
        
            string[] datas = partes[1].Split(',');
            if (datas.Length != 2)
            {
                throw new ArgumentException("Formato inválido para as datas.");
            }

            DateTime dataInicio, dataFinal;
            bool dataInicioValida = DateTime.TryParseExact(datas[0].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataInicio);
            bool dataFinalValida = DateTime.TryParseExact(datas[1].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataFinal);

            if (!dataInicioValida || !dataFinalValida)
            {
                throw new ArgumentException("Uma ou ambas as datas estão em formato inválido. Use o formato dd/MM/yyyy.");
            }
            return (customer, dataInicio, dataFinal);
        }

        public static Car CheapestCar(Car[] vehicles, Customer customer, DateTime startDate, DateTime endDate)
        {
            Car cheaper = null;
            foreach (var item in vehicles)
            {
                if (cheaper == null)
                {
                    cheaper = item;
                }
                else if (cheaper != null && precoCarro(cheaper, customer, startDate, endDate) >= precoCarro(item, customer, startDate, endDate)) {
                    cheaper = item;
                }
            }

            return cheaper;
        }

        public static float precoCarro(Car car, Customer customer, DateTime startDate, DateTime endDate)
        {
            float totalPrice = 0f;
            int qtyDays = endDate.Day - startDate.Day;

            for (int i = 0; i <= qtyDays; i++)
            {
                var currentDay = startDate.AddDays(i);
                if (currentDay.DayOfWeek == DayOfWeek.Monday || currentDay.DayOfWeek == DayOfWeek.Tuesday || currentDay.DayOfWeek == DayOfWeek.Thursday ||
                    currentDay.DayOfWeek == DayOfWeek.Wednesday || currentDay.DayOfWeek == DayOfWeek.Friday)
                {
                    if (customer.IsFidelidade)
                    {
                        totalPrice = totalPrice + car.WeekdayFidelidade;
                    }
                    else
                    {
                        totalPrice = totalPrice + car.Weekday;
                    }
                }
                else
                {
                    if (customer.IsFidelidade)
                    {
                        totalPrice += car.WeekenddayLoyalty;
                    }
                    else
                    {
                        totalPrice += car.Weekendday;
                    }
                }
            }
            return totalPrice;
        }
    }
}