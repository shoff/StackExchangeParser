namespace StackExchangeParser.Domain.Models
{
    using System;

    public class Vote : IVote
    {
        public virtual long Id { get; set; }
        public virtual long? PostId { get; set; }
        public virtual int VoteTypeId { get; set; }
        public virtual long? UserId { get; set; }
        public virtual DateTime CreationDate { get; set; }
    }
}