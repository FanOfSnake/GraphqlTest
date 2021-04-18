using GraphqlTest.Common;
using GraphqlTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlTest.Speakers
{
    public class AddSpeakerPayload: SpeakerPayloadBase
    {
        public AddSpeakerPayload(Speaker speaker)
            : base(speaker)
        {
        }

        public AddSpeakerPayload(IReadOnlyList<UserError> errors)
            :base(errors)
        {
        }
    }
}
