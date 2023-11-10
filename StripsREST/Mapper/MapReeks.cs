using StripsBL.Model;
using StripsREST.DTO;
using StripsREST.Exceptions;

namespace StripsREST.Mapper
{
    public class MapReeks
    {

        public static ReeksDTO MapFromDomain(string url, Reeks reeks, int id)
        {
            try
            {
                string reeksURL = $"{url}";
                List<StripDTO> strips = reeks.Strips.Select(strip => new StripDTO(strip.Nr.ToString(), strip.Titel, $"{reeksURL}/strip/{strip.ID}")).ToList();

                ReeksDTO reeksDTO = new(id, reeks.Naam, $"{reeksURL}/reeks/{id}", strips);

                return reeksDTO;
            }
            catch (MapException mex)
            {
                throw new MapException(mex.Message);
            }
        }


    }
}
