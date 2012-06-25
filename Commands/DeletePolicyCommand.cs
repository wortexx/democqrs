using System;

namespace Domain.Commands
{
    public class DeletePolicyCommand : Ncqrs.Commanding.ICommand
    {
        public Guid PolicyId { get; set; }

        public Guid CommandIdentifier
        {
            get { return PolicyId; }
        }
    }

    public class DeleteLocationCommand
    {
        public Guid PolicyId { get; set; }
    }
}