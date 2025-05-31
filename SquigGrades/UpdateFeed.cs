using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SquigGrades
{
    public class UpdateFeed
    {
        [JsonPropertyName("stable")]
        public UpdateInfo Stable { get; set; } = new UpdateInfo();
        [JsonPropertyName("prerelease")]
        public UpdateInfo Prerelease { get; set; } = new UpdateInfo();
    }
}
