namespace VaporStore.DataProcessor.ImportDto
{
    using System.Collections.Generic;

    public class ImportUserDto
    {
        public string FullName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public ICollection<ImportCardDto> Cards { get; set; }
    }
}