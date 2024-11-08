using Microsoft.VisualStudio.TestPlatform.TestHost;
using RentCarChallenge;
using Xunit;
namespace RentCarChallengeTest
{
    public class UnitTest
    {
        private Car[] carros;
        private Car Ka;

        public UnitTest() {
            Ka = new Car();
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

            carros = new Car[5];
            carros[0] = Ka;
            carros[1] = Yaris;
            carros[2] = VIRTUS;
            carros[3] = Doblo;
            carros[4] = Hilux;
        }
        
        [Fact]
        public void RegularCustomerTest()
        {
            Customer customer = new Customer();
            customer.IsFidelidade = false;
            DateTime startDate = new DateTime(2024, 08, 11);
            DateTime endDate = new DateTime(2024, 08, 13);
            Car car = RentCarChallenge.Program.CheapestCar(carros, customer, startDate, endDate);
            Assert.NotNull(car);
            Assert.Equal("Hilux 4x2 2.4 Diesel", car.Model);
        }

        [Fact]
        public void YarisPriceLoyaltyTest() {
            Customer customer = new Customer();
            customer.IsFidelidade = true;
            DateTime startDate = new DateTime(2024, 08, 11);
            DateTime endDate = new DateTime(2024, 08, 13);

            var result = RentCarChallenge.Program.precoCarro(carros[1], customer, startDate, endDate);

            Assert.Equal(320, result);
        }

        [Fact]
        public void YarisPriceRegularTest()
        {
            Customer customer = new Customer();
            customer.IsFidelidade = false;
            DateTime startDate = new DateTime(2024, 08, 11);
            DateTime endDate = new DateTime(2024, 08, 13);

            var result = RentCarChallenge.Program.precoCarro(carros[1], customer, startDate, endDate);

            Assert.Equal(360, result);
        }


        [Fact]
        public void KaPriceLoyaltyTest()
        {
            Customer customer = new Customer();
            customer.IsFidelidade = true;
            DateTime startDate = new DateTime(2024, 08, 11);
            DateTime endDate = new DateTime(2024, 08, 13);

            var result = RentCarChallenge.Program.precoCarro(carros[0], customer, startDate, endDate);

            Assert.Equal(290, result);
        }

        [Fact]
        public void KaPriceRegularTest()
        {
            Customer customer = new Customer();
            customer.IsFidelidade = false;
            DateTime startDate = new DateTime(2024, 08, 11);
            DateTime endDate = new DateTime(2024, 08, 13);

            var result = RentCarChallenge.Program.precoCarro(carros[0], customer, startDate, endDate);

            Assert.Equal(380, result);
        }

        [Fact]
        public void VirtusPriceLoyaltyTest()
        {
            Customer customer = new Customer();
            customer.IsFidelidade = true;
            DateTime startDate = new DateTime(2024, 08, 11);
            DateTime endDate = new DateTime(2024, 08, 13);

            var result = RentCarChallenge.Program.precoCarro(carros[2], customer, startDate, endDate);

            Assert.Equal(320, result);
        }

        [Fact]
        public void VirtusPriceRegularTest()
        {
            Customer customer = new Customer();
            customer.IsFidelidade = false;
            DateTime startDate = new DateTime(2024, 08, 11);
            DateTime endDate = new DateTime(2024, 08, 13);

            var result = RentCarChallenge.Program.precoCarro(carros[2], customer, startDate, endDate);

            Assert.Equal(390, result);
        }

        [Fact]
        public void DobloPriceLoyaltyTest()
        {
            Customer customer = new Customer();
            customer.IsFidelidade = true;
            DateTime startDate = new DateTime(2024, 08, 11);
            DateTime endDate = new DateTime(2024, 08, 13);

            var result = RentCarChallenge.Program.precoCarro(carros[3], customer, startDate, endDate);

            Assert.Equal(370, result);
        }

        [Fact]
        public void DobloPriceRegularTest()
        {
            Customer customer = new Customer();
            customer.IsFidelidade = false;
            DateTime startDate = new DateTime(2024, 08, 11);
            DateTime endDate = new DateTime(2024, 08, 13);

            var result = RentCarChallenge.Program.precoCarro(carros[3], customer, startDate, endDate);

            Assert.Equal(400, result);
        }

        [Fact]
        public void HiluxPriceLoyaltyTest()
        {
            Customer customer = new Customer();
            customer.IsFidelidade = true;
            DateTime startDate = new DateTime(2024, 08, 11);
            DateTime endDate = new DateTime(2024, 08, 13);

            var result = RentCarChallenge.Program.precoCarro(carros[4], customer, startDate, endDate);

            Assert.Equal(340, result);
        }

        [Fact]
        public void HiluxPriceRegularTest()
        {
            Customer customer = new Customer();
            customer.IsFidelidade = false;
            DateTime startDate = new DateTime(2024, 08, 11);
            DateTime endDate = new DateTime(2024, 08, 13);

            var result = RentCarChallenge.Program.precoCarro(carros[4], customer, startDate, endDate);

            Assert.Equal(360, result);
        }
    }
}