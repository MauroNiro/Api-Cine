using Cine_API.CTD;
using Cine_API.Entities;

namespace GameStore.Api.Mapping;

public static class DirectorMapping
{
    public static GetDirector ToDto(this Director director)
    {
        return new GetDirector(director.DirectorId, director.DirectorName);
    }
}
