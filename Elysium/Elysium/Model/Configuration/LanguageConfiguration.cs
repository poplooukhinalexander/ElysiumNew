using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elysium.Model.Configuration
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(_ => _.Code);
            var languages = new Language[] 
            { 
                new Language { Code = "rus", Name = "Russian" },
                new Language { Code = "ara", Name = "Arabic" },
                new Language { Code = "eng", Name = "English" },
                new Language { Code = "fra", Name = "French" },
                new Language { Code = "jpn", Name = "Japanese"},
                new Language { Code = "deu", Name = "German" },
                new Language { Code = "ita", Name = "Italian" },
                new Language { Code = "spa", Name = "Spanish" },                
            };
            builder.HasData(languages);
        }
    }
}
