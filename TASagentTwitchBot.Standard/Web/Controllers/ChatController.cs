using Microsoft.AspNetCore.Mvc;
using TASagentTwitchBot.Core.Chatbot;

namespace TASagentTwitchBot.Standard.Web.Controllers;

[ApiController]
[Route("/TASagentBotAPI/Chat/[action]")]
public class ChatController : ControllerBase
{
    [HttpGet]
    public ActionResult Say([FromQuery] string input)
    {
        
        return Ok("");
    }

    [HttpPost]
    public ActionResult Train()
    {
        return Ok();
    }
}
