using Phonebook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Data
{
    public class PhonebookContextSeed
    {
        public static async Task SeedAsync(PhonebookContext context, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // TODO: Only run this if using a real database
                //context.Database.Migrate();
                //context.Database.EnsureCreated();

                if (!context.Phonebooks.Any())
                {
                    context.Phonebooks.Add(GetPreconfiguredPhonebook());
                    await context.SaveChangesAsync();
                }

                if (!context.Entries.Any())
                {
                    context.Entries.AddRange(GetPreconfiguredEntries());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    await SeedAsync(context, retryForAvailability);
                }
                throw;
            }
        }
        private static PhonebookEntity GetPreconfiguredPhonebook()
        {

            return new PhonebookEntity() { Name = "DefaultPhoneBook" };
        }
        private static IEnumerable<EntryEntity> GetPreconfiguredEntries()
        {
            return new List<EntryEntity>()
            {
                new EntryEntity() { Name = "Abdul", Number = "0111111111", PhonebookId = 1},
                new EntryEntity() { Name = "Bianca", Number ="0121111111", PhonebookId = 1},
            };
        }
    }
}
