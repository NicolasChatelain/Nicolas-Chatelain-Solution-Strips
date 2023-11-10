namespace StripsREST.DTO
{
    public class StripDTO
    {
        public StripDTO(string nr, string titel, string uRL)
        {
            Nr = nr;
            Titel = titel;
            URL = uRL;
        }

        private string _nr;

        public string Nr
        {
            get { return _nr; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _nr = value;
                }
                else
                {
                    _nr = "-";
                }
            }
        }
        public string Titel { get; set; }
        public string URL { get; set; }

    }
}
