using System.Collections.Generic;
using Xunit;
using MessageCards.Webhooks;
using MessageCards.Extensions;
using Microsoft.Extensions.Configuration;

namespace MessageCards.Tests
{
    public class MessageCardTests
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets("MessageCards", true)
                .Build();
            return config;
        }

        [Fact]
        public void LiveTestToJson()
        {
            var config = InitConfiguration();

            var input = new TextInput("Insert message to post here") { IsRequired = true };
            var card = new MessageCard("Card title")
            {
                Text = "The text",
                Summary = "The summary",
                Sections = new List<Section>
                {
                    new Section("The section text")
                    {
                        Facts = new List<Fact>
                        {
                            new Fact("Fact name", "Fact value")
                        }
                    }
                },
                Actions = new List<Action>
                {
                    new ActionCard("The actioncard name")
                    {
                        Inputs = new List<Input>
                        {
                            input
                        },
                        Actions = new List<INestableAction>
                        {
                            new OpenUriAction("Open Uri name")
                            {
                                Targets = new List<Target>
                                {
                                    new Target($"http://www.google.com")
                                }
                            },
                            new HttpPostAction("Post message to this channel", config["webhook"])
                            {
                                Body = new MessageCard($"Posted nested card with input {input.GetValueReference()}").ToJson()
                            }
                        }
                    },
                    new HttpPostAction("Post", config["webhook"])
                    {
                        Body = new MessageCard("Posted card").ToJson()
                    }
                }
            };
            var webhook = new Webhook(config["webhook"]);
            webhook.PostAsync(card).GetAwaiter().GetResult();
        }

        [Fact]
        public void TestUrlBuilder()
        {
            var config = InitConfiguration();
            var query = "exceptions | order by timestamp desc";

            var url = QueryBuilder.BuildLogAnalyticsUrl(config["tenantName"], config["resourceId"], query);
        }
    }
}
