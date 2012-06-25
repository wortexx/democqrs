using System;
using Domain.Design;

namespace Domain.Commands.Insuarance
{
    public class DeletePolicy : Command
    {
        public Guid PolicydId { get; set; }
    }
}