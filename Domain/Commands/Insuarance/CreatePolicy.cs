using Domain.Design;

namespace Domain.Commands.Insuarance
{
    public class CreatePolicy : Command
    {
        public string PolicyNumber { get; set; }
    }
}