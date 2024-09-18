namespace Cine_API.Entities
{
    public class Show
    {
        public int ShowId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int MovieId { get; set; }
        public  Movie? Movie { get; set; }

        public static bool ValidatePrice(decimal price)
        {
            if (price > 0)
                return true;
            else return false;
        }
        public static bool ValidateDate(DateTime dateTime)
        {
            if (dateTime > DateTime.Now)
                return true;
            return false;
        }
        public static bool ShowSameDateVerification(DateTime editShowDate,DateTime showDate)
        {
            if (editShowDate.Date == showDate.Date)
            {
                return true;
            };
            return false;
        }
        public static bool ShowQuantityVerification(Show newshow, List<Show> shows)
        {
            if (!newshow.Movie!.IsNational)
            {
                var showQuantity = shows.Where(show => show.MovieId == newshow.MovieId && show.Date.Date == newshow.Date.Date).Count();
                if (showQuantity >= 8)
                {
                    return false;
                }
            }
            var showDirectorQuantity = shows.Where(show => show.Movie!.DirectorId == newshow.Movie!.DirectorId && show.Date.Date == newshow.Date.Date).Count();
            if (showDirectorQuantity >= 10) { 
                return false;
            }
            return true;
        }
    }
   
}
