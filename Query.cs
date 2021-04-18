﻿using GraphqlTest.Data;
using GraphqlTest.DataLoader;
using GraphqlTest.Extensions;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GraphqlTest
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context)
            => context.Speakers.ToListAsync();

        public Task<Speaker> GetSpeakerAsync(
            int id,
            SpeakerByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
            => dataLoader.LoadAsync(id, cancellationToken);

    }
}
