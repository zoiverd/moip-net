using System;

namespace Moip.Net
{
    /// <summary>
    /// Estrutura de data do Moip
    /// </summary>
    public class MoipDate
    {
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }

        public int? Hour { get; set; }
        public int? Minute { get; set; }
        public int? Second { get; set; }

        public DateTime ToDate()
        {
            var year = Year ?? DateTime.Now.Year;
            var month = Month ?? DateTime.Now.Month;
            var day = Day ?? DateTime.Now.Day;

            var data = new DateTime(year, month, day);

            if (Hour.HasValue)
                data = data.AddHours(Hour.Value);
            if (Minute.HasValue)
                data = data.AddMinutes(Minute.Value);
            if (Second.HasValue)
                data = data.AddSeconds(Second.Value);
            
            return data;
        }

        public static MoipDate FromDate(DateTime date)
        {
            var moipDate = new MoipDate()
            {
                Year = date.Year,
                Month = date.Month,
                Day = date.Day
            };

            //Caso não tenha minutos, segundos ou horas
            if(date != date.Date)
            {
                moipDate.Hour = date.Hour;
                moipDate.Minute = date.Minute;
                moipDate.Second = date.Second;
            }

            return moipDate;
        }

    }
}
