using Microsoft.AspNetCore.Mvc;
using TASagentTwitchBot.Core.Chatbot;

namespace TASagentTwitchBot.Standard.Web.Controllers;

[ApiController]
[Route("/TASagentBotAPI/Chat/[action]")]
public class ChatController : ControllerBase
{
    private readonly TFidfChatbot _tfidf;
    private readonly MarkovChatbot _markov;

    public ChatController(TFidfChatbot tfidf, MarkovChatbot markov)
    {
        _tfidf = tfidf;
        _markov = markov;
    }

    [HttpGet]
    public ActionResult Say([FromQuery] string input)
    {
        if (!_tfidf.SetupComplete || !_markov.SetupComplete)
        {
            return Ok();
        }
        var response = _tfidf.Say(input);
        if (response.Score < 0.75)
        {
            response = _markov.Say(input);
        }
        return Ok(response.Output);
    }

    [HttpPost]
    public ActionResult Train()
    {
        _markov.Train();
        _tfidf.Train();
        return Ok();
    }
}
