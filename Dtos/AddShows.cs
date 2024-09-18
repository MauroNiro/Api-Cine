namespace Api_Cine.Dtos
{
    public record class AddShows(
        decimal Price,
        int MovieId,
        DateTime Date);
}

