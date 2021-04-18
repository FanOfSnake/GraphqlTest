using GraphqlTest.Data;
using GraphqlTest.DataLoader;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphqlTest.Types
{
    public class SpeakerType: ObjectType<Speaker>
    {
        protected override void Configure(
            IObjectTypeDescriptor<Speaker> descriptor)
        {
            descriptor
                .Field(t => t.SessionSpeakers)
                .ResolveWith<SpeakerResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
                .Name("sessions");
        }
    }

    public class SpeakerResolvers
    {
        public async Task<IEnumerable<Session>> GetSessionsAsync(
            Speaker speaker,
            [ScopedService] ApplicationDbContext dbContext,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken)
        {
            int[] sessionsIds = await dbContext.Speakers
                .Where(s => s.Id == speaker.Id)
                .Include(s => s.SessionSpeakers)
                .SelectMany(s => s.SessionSpeakers.Select(t => t.SessionId))
                .ToArrayAsync();

            return await sessionById.LoadAsync(sessionsIds,cancellationToken);
        }
    }
}
