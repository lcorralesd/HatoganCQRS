using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public static class Utils
    {
        public static string CalculateLongAge(DateTime? birthDate, DateTime actualDate)
        {
            if (birthDate != null)
            {
                int year = birthDate.Value.Year;

                int leapYear = 0;

                for (int i = year; i < actualDate.Year; i++)
                {
                    if (DateTime.IsLeapYear(i))
                    {
                        ++leapYear;
                    }
                }

                TimeSpan timeSpan = actualDate.Subtract(birthDate.Value);
                int day = timeSpan.Days - leapYear;

                year = Math.DivRem(day, 365, out int r);
                int mes = Math.DivRem(r, 30, out r);
                day = r;
                return $"{year} años, {mes} meses, {day} dias";
            }
            return null;

        }

        public static int CalculateAgeDays(DateTime? birthDate)
        {
            if (birthDate != null)
            {
                int anio = birthDate.Value.Year;

                int leapYear = 0;

                for (int i = anio; i < DateTime.Now.Year; i++)
                {
                    if (DateTime.IsLeapYear(i))
                    {
                        ++leapYear;
                    }
                }

                TimeSpan timeSpan = DateTime.Now.Subtract(birthDate.Value);
                var ageDays = timeSpan.Days - leapYear;
                return ageDays;
            }
            return 0;
        }

        public static int CalculateCategory(int ageDays, Sex sex)
        {
            int categoryId = 0;
            categoryId = ageDays switch
            {
                int value when value is > 0 and <= 240 => 1,
                int value when value is > 240 and <= 365 && sex == Sex.Hembra => 2,
                int value when value is > 365 and <= 600 && sex == Sex.Hembra => 3,
                int value when value is > 600 and <= 1080 && sex == Sex.Hembra => 4,
                int value when value is > 240 and <= 365 && sex == Sex.Macho => 5,
                int value when value is > 365 and <= 600 && sex == Sex.Macho => 6,
                int value when value is > 600 and <= 1080 && sex == Sex.Macho => 7,
                int value when value is > 1080 && sex == Sex.Hembra => 8,
                int value when value is > 1080 && sex == Sex.Macho => 12,
                _ => 8,
            };
            return categoryId;
        }
    }
}
