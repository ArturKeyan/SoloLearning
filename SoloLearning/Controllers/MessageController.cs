using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SoloLearning.DTO;
using SoloLearning.Services.Intefaces;
using SoloLearning.Web.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoloLearning.Web.Controllers
{
    public class MessageController : BaseController
    {
        private IHubContext<ChatHub> chatHub;
        private readonly IChatService chatService;

        public MessageController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MessageCreateModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await chatService.SendMessage(new MessageDTO
                    {
                        User = new UserDTO {
                            Id = model.User.Id,
                        },
                        RoomId = model.RoomId,
                        Text = model.Text
                    });

                    await chatHub.Clients.All.SendAsync("transferchartdata", model);

                    return ApiResult(true);
                }

                return Error(ModelState);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await chatService.RemoveRoom(id);
                return ApiResult(id);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
