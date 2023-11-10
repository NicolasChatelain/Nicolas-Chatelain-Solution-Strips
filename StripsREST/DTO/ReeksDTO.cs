namespace StripsREST.DTO
{
    public class ReeksDTO
    {
        public ReeksDTO(int id, string name, string uRL, List<StripDTO> strips)
        {
            Id = id;
            Name = name;
            URL = uRL;
            this.strips = strips;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string URL {  get; set; }
        public List<StripDTO> strips { get; set; }
    }
}
