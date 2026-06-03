using Microsoft.AspNetCore.Mvc;
using OpenAI;
using OpenAI.Chat;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class AIController : Controller
    {
        private readonly OpenAIClient _openAI;

        public AIController(OpenAIClient openAI)
        {
            _openAI = openAI;
        }

        public IActionResult FitnessTips()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FitnessTips(string goal)
        {
            if (string.IsNullOrWhiteSpace(goal))
            {
                ViewBag.Advice = "Please enter a fitness goal.";
                return View();
            }

            var messages = new List<ChatMessage>
            {
                ChatMessage.CreateUserMessage($"Give me fitness advice for this goal: {goal}")
            };

            // Get a chat client for the model
            var chatClient = _openAI.GetChatClient("gpt-3.5-turbo");

            // Correct method call
            ChatCompletion response = await chatClient.CompleteChatAsync(messages);

            // FIX: Access the first output message content
            ViewBag.Advice = response.Content[0].Text;

            return View();
        }
    }
}