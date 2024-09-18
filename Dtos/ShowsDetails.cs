namespace Api_Cine.Dtos
{
    public record class ShowsDetails(
        int ShowId,
        decimal Price,
        int MovieId,
        DateTime Date);
}

