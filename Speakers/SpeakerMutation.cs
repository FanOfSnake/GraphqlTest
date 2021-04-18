using GraphqlTest.Data;
using GraphqlTest.Extensions;
using HotChocolate;
using System.Threading.Tasks;

namespace GraphqlTest.Speakers
{
    public class SpeakerMutation
    {
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeakerAsync(
            AddSpeakerInput input,
            [ScopedService] ApplicationDbContext context)
        {
            var speaker = new Speaker
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            context.Add(speaker);
            await context.SaveChangesAsync();

            return new AddSpeakerPayload(speaker);
        }
    }
}
