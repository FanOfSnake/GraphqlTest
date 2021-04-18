using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlTest.Speakers
{
    public record AddSpeakerInput
    (
        string Name,
        string? Bio,
        string? WebSite
    );
}
