﻿using Clean_arch.Domain.Shared.Exceptions;
using System.Data.SqlTypes;

namespace Clean_arch.Domain.Shared
{
    public class Money : BaseValueObject
    {

        /// <summary>
        /// Rial
        /// </summary>
        public int Value { get; }

        public Money(int rialValue)
        {
            if (rialValue < 0)
            {
                throw new InvalidDomainDataException();
            }
            Value = rialValue;
        }


        public static Money FromRial(int value)
        {
            return new Money(value);
        }

        public static Money FromTooman(int value)
        {
            return new Money(value*10);
        }

        public override string ToString()
        {
            return Value.ToString("#,0");
        }


        public static Money operator +(Money a, Money b)
        {
            return new Money (a.Value + b.Value);
        }

        public static Money operator -(Money a, Money b)
        {
            return new Money (a.Value - b.Value);
        }
    }
}
