using System;
using System.Collections.Generic;

namespace DateModifier
{
    class DateModifier
    {
        public DateModifier()
        {
            this.ListWithAllDays = new List<DateTime>();
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DateTime> ListWithAllDays { get; set; }

        public List<DateTime> ReturnDaysBetwenTwoDates(string startDate, string endDate)
        {
            this.StartDate = DateTime.Parse(startDate);
            this.EndDate = DateTime.Parse(endDate);
            if(this.StartDate < this.EndDate)
            {
                for (DateTime date = this.StartDate; date < this.EndDate; date = date.AddDays(1))
                {
                    this.ListWithAllDays.Add(date);
                }
            }

            else
            {
                for (DateTime date = this.EndDate; date < this.StartDate; date = date.AddDays(1))
                {
                    this.ListWithAllDays.Add(date);
                }
            }
          
            return this.ListWithAllDays;
        }
    }
}
