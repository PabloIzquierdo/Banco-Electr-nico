using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlusBankWeb.Utilities
{
    public class Enums
    {
        public static Currency currency;
        public static Comission comission;
        public enum Currency{
            USD = 1, //Dollar
            JPY = 2, //Yen Japanese
            GBP = 3, //Pound sterling
            RUB = 4, //Russian ruble
            MXN = 5, //Mexican peso
            EUR = 6, //Euro
        }

        public enum Comission
        {
            Corriente = 60, //Anual
            Nómina = 0,
            Ahorros = 80,
            Remunerada = 72
        }

        public static Comission GetComission()
        {
            return comission;
        }

        public static void SetComission(string typeCuenta)
        {
            switch (typeCuenta)
            {
                case "Ahorros":
                    comission = Comission.Ahorros;
                    break;

                case "Corriente":
                    comission = Comission.Corriente;
                    break;

                case "Nómina":
                    comission = Comission.Nómina;
                    break;

                case "Remunerada":
                    comission = Comission.Remunerada;
                    break;

            }
        }

        public static Currency GetCurrency()
        {
            return currency;
        }

        public static string GetCurrencyString()
        {
            switch (currency)
            {
                case Currency.USD:
                    return "USD";
                    break;

                case Currency.JPY:
                    return "JPY";
                    break;

                case Currency.GBP:
                    return "GBP";
                    break;

                case Currency.RUB:
                    return "RUB";
                    break;

                case Currency.MXN:
                    return "MXN";
                    break;

                case Currency.EUR:
                    return "EUR";
                    break;
                default:
                    return null;
                    break;

            }
        }
        public static void SetCurrency(int id)
        {
            switch (id)
            {
                case 1:
                    currency = Currency.USD;
                    break;

                case 2:
                    currency = Currency.JPY;
                    break;

                case 3:
                    currency = Currency.GBP;
                    break;

                case 4:
                    currency = Currency.RUB;
                    break;

                case 5:
                    currency = Currency.MXN;
                    break;

                case 6:
                    currency = Currency.EUR;
                    break;

            }
        }
    }
}