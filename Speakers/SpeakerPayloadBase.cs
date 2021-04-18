using GraphqlTest.Common;
using GraphqlTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlTest.Speakers
{
    public class SpeakerPayloadBase: Payload
    {
        public Speaker? Speaker { get; }
        protected SpeakerPayloadBase(Speaker speaker)
        {
            Speaker = speaker;
        }

        protected SpeakerPayloadBase(IReadOnlyList<UserError> errors)
            :base(errors)
        {
        }
    }
}
