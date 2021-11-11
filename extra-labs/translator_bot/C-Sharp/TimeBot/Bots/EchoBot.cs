// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with EchoBot .NET Template version v4.14.1.2

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace EchoBot.Bots
{
 public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var response = MakeTranslator(turnContext.Activity.Text);
            var replyText = $"原始語系: {   response[0].detectedLanguage.language }  { System.Environment.NewLine }";
            replyText += $"日文: {   response[0].translations[0].text} { System.Environment.NewLine }";
            replyText += $"英文: {   response[0].translations[1].text} { System.Environment.NewLine }";
            replyText += $"韓文: {   response[0].translations[2].text} { System.Environment.NewLine }";
            await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
        }

        static List<TranslatorResponse> MakeTranslator(string msg)
        {
            HttpClient client = new HttpClient();
            string endpoint = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&to=ja&to=en&to=ko";

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "____________key__________");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Region", "eastasia");

            var JsonBody = "[{'text':'" + msg + "'}]";
            var content =
               new StringContent(JsonBody, System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(endpoint, content).Result;
            var ResponseJson = response.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<TranslatorResponse>>(ResponseJson);

        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Hello and welcome!";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }
    }

    //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class DetectedLanguage
    {
        public string language { get; set; }
        public double score { get; set; }
    }

    public class Translation
    {
        public string text { get; set; }
        public string to { get; set; }
    }

    public class TranslatorResponse
    {
        public DetectedLanguage detectedLanguage { get; set; }
        public List<Translation> translations { get; set; }
    }

}
