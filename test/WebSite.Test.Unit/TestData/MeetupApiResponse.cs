namespace WebSite.Test.Unit.TestData
{
    public class MeetupApiResponse
    {
        public const string EventsNnugTrondheim = @"[
  {
    ""link"": ""http://www.meetup.com/nnug-trondheim/events/121046502/"",
    ""venue"": {
      ""name"": ""Clarion Hotel & Congress Trondheim""
    },
    ""utc_offset"": 7200000,
    ""time"": 1371744000000,
    ""name"": ""Sommerfest""
  },
  {
    ""link"": ""https://www.meetup.com/nnug-trondheim/events/259060331/"",
    ""venue"": {
      ""name"": ""Norconsult AS Avd Trondheim""
    },
    ""utc_offset"": 7200000,
    ""time"": 1561962600000,
    ""name"": ""Visual Studio 2019, Identity & Cosmos DB""
  }
]";
        public const string GroupNnugTrondheim = @"{
  ""members"": 610,
  ""name"": ""NNUG Trondheim""
}";
    }
}