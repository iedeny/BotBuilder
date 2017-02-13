using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Bot.Sample.AspNetCore.Pizza.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly IConfigurationRoot configuration;

        /*private static IForm<PizzaOrder> BuildForm()
        {
            var builder = new FormBuilder<PizzaOrder>();

            ActiveDelegate<PizzaOrder> isBYO = (pizza) => pizza.Kind == PizzaOptions.BYOPizza;
            ActiveDelegate<PizzaOrder> isSignature = (pizza) => pizza.Kind == PizzaOptions.SignaturePizza;
            ActiveDelegate<PizzaOrder> isGourmet = (pizza) => pizza.Kind == PizzaOptions.GourmetDelitePizza;
            ActiveDelegate<PizzaOrder> isStuffed = (pizza) => pizza.Kind == PizzaOptions.StuffedPizza;

            return builder
                // .Field(nameof(PizzaOrder.Choice))
                .Field(nameof(PizzaOrder.Size))
                .Field(nameof(PizzaOrder.Kind))
                .Field("BYO.Crust", isBYO)
                .Field("BYO.Sauce", isBYO)
                .Field("BYO.Toppings", isBYO)
                .Field(nameof(PizzaOrder.GourmetDelite), isGourmet)
                .Field(nameof(PizzaOrder.Signature), isSignature)
                .Field(nameof(PizzaOrder.Stuffed), isStuffed)
                .AddRemainingFields()
                .Confirm("Would you like a {Size}, {BYO.Crust} crust, {BYO.Sauce}, {BYO.Toppings} pizza?", isBYO)
                .Confirm("Would you like a {Size}, {&Signature} {Signature} pizza?", isSignature, dependencies: new string[] { "Size", "Kind", "Signature" })
                .Confirm("Would you like a {Size}, {&GourmetDelite} {GourmetDelite} pizza?", isGourmet)
                .Confirm("Would you like a {Size}, {&Stuffed} {Stuffed} pizza?", isStuffed)
                .Build()
                ;
        }

        internal static IDialog<PizzaOrder> MakeRoot()
        {
            return Chain.From(() => new PizzaOrderDialog(BuildForm));
        }

        public MessagesController(IConfigurationRoot configuration)
        {
            this.configuration = configuration;
        }

        [Authorize(Roles = "Bot")]
        // POST api/values
        [HttpPost]
        public virtual async Task<OkResult> Post([FromBody]Activity activity)
        {
            var appCredentials = new MicrosoftAppCredentials(this.configuration);
            var client = new ConnectorClient(new Uri(activity.ServiceUrl), appCredentials);

            if (activity != null)
            {
                // one of these will have an interface and process it
                switch (activity.GetActivityType())
                {
                    case ActivityTypes.Message:
                        await Conversation.SendAsync(activity, MakeRoot);
                        break;

                    case ActivityTypes.ConversationUpdate:
                    case ActivityTypes.ContactRelationUpdate:
                    case ActivityTypes.Typing:
                    case ActivityTypes.DeleteUserData:
                    default:
                        Trace.TraceError($"Unknown activity type ignored: {activity.GetActivityType()}");
                        break;
                }
            }


            await client.Conversations.ReplyToActivityAsync(reply);
            return Ok();
        }*/

        public MessagesController(IConfigurationRoot configuration)
        {
            this.configuration = configuration;
        }

        [Authorize(Roles = "Bot")]
        // POST api/values
        [HttpPost]
        public virtual async Task<OkResult> Post([FromBody]Activity activity)
        {
            var appCredentials = new MicrosoftAppCredentials(this.configuration);
            var client = new ConnectorClient(new Uri(activity.ServiceUrl), appCredentials);
            var reply = activity.CreateReply();
            if (activity.Type == ActivityTypes.Message)
            {
                reply.Text = $"echo: {activity.Text}";
            }
            else
            {
                reply.Text = $"activity type: {activity.Type}";
            }
            await client.Conversations.ReplyToActivityAsync(reply);
            return Ok();
        }
    }
}
