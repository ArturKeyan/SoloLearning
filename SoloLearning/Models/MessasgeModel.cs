using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoloLearning.Web.Models
{
    public class MessageCreateModel
    {
        public UserModel User { get; set; }
        public string Text { get; set; }
        public int RoomId { get; set; }
    }

    public class MessageModel : MessageCreateModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    
    public class MessageCreateModelValidator : AbstractValidator<MessageCreateModel>
    {
        public MessageCreateModelValidator()
        {
            RuleFor(p => p.User.Id)
                .NotNull().WithMessage("fieldIsRequired");
            RuleFor(p => p.RoomId)
                .NotNull().WithMessage("fieldIsRequired");
            RuleFor(p => p.Text)
                .NotNull().WithMessage("fieldIsRequired")
                .MaximumLength(100).WithMessage("messageMaxLength");
        }
    }
}
