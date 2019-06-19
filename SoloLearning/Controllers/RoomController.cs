using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoloLearning.DTO;
using SoloLearning.Services.Intefaces;
using SoloLearning.Web.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoloLearning.Web.Controllers
{
    public class RoomController : BaseController
    {
        private readonly IChatService chatService;

        public RoomController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var roomModels = (await chatService.GetAllRooms()).Select(m => new RoomModel {
                    Id = m.Id,
                    Name = m.Name,
                    Owner = m.Owner == null ? null : new UserModel
                    {
                        Name = m.Owner.Name,
                        Id = m.Owner.Id
                    },
                    Messages = m.Messages == null ? null : m.Messages.Select(k => new MessageModel
                    {
                        Id = k.Id,
                        Text = k.Text,
                        User = k.User == null ? null : new UserModel
                        {
                            Name = k.User.Name,
                            Id = k.User.Id,
                        },
                        CreatedDate = k.CreatedDate
                    }),
                });

                return ApiResult(roomModels);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RoomCreateModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await chatService.CreateRoom(new RoomDTO
                    {
                        Name = model.Name
                    });

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
