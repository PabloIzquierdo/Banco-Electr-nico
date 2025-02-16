﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlusBankWeb.Utilities
{
    public class Enums
    {
        public static Currency currency;
        public Comission comission;
        public static Operation operation;

        public enum Operation
        {
            Pasivo = 1,
            Activo = 2
        }
        public enum Currency
        {
            USD = 1, //Dollar
            GBP = 2, //Pound sterling
            EUR = 3, //Euro
        }

        public enum Comission
        {
            Corriente = 60, //Anual
            Nómina = 0,
            Ahorros = 80,
            Remunerada = 72
        }

        public Operation GetOperation()
        {
            return operation;
        }

        public int GetOperationValue(Operation op)
        {
            if (op == Operation.Pasivo)
                return 1;
            else
                return 2;
        }

        public void SetOperationValue(int value)
        {
            if (value == 1)
                operation = Operation.Pasivo;
            else
                operation = Operation.Activo;
        }

        public int GetComissionValue(Comission com)
        {
            switch (com)
            {
                case Comission.Ahorros:
                    return 80;

                case Comission.Corriente:
                    return 60;

                case Comission.Nómina:
                    return 0;

                case Comission.Remunerada:
                    return 72;

                default:
                    return 0;
            }
        }

        public Comission GetComission()
        {
            return comission;
        }

        public void SetComission(string typeCuenta)
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

        public Currency GetCurrency()
        {
            return currency;
        }

        public string GetCurrencyString()
        {
            switch (currency)
            {
                case Currency.USD:
                    return "USD";
                case Currency.GBP:
                    return "GBP";

                case Currency.EUR:
                    return "EUR";

                default:
                    return null;

            }
        }
        public string GetCurrencySymbol()
        {
            switch (currency)
            {
                case Currency.USD:
                    return "$";

                case Currency.GBP:
                    return "£";

                case Currency.EUR:
                    return "€";

                default:
                    return null;

            }
        }

        public void SetCurrency(int id)
        {
            switch (id)
            {
                case 1:
                    currency = Currency.USD;
                    break;

                case 3:
                    currency = Currency.GBP;
                    break;
                case 6:
                    currency = Currency.EUR;
                    break;

            }
        }
    }
}