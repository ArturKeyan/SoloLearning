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
                    Owner = new UserModel {
                        Name = m.Owner.Name,
                        Id = m.Owner.Id
                    },
                    Messages = m.Messages.Select(k => new MessageModel {
                        Id = k.Id,
                        Text = k.Text,
                        User = new UserModel
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

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
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
