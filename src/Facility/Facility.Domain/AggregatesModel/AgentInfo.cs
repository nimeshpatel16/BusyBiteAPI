using Envision.MDM.Location.Domain.Common;


namespace Envision.MDM.Location.Domain.AggregatesModel
{
    public class AgentInfo : Entity, IAggregateRoot
    {
        public int agentId { get; set; }
        public string agentName { get; set; }
      

        public AgentInfo() { }

        public AgentInfo(int id) { base.Id = id; }

        public AgentInfo(int id, string Name)
        {
            base.Id = id;
            agentId = id;
            agentName = Name;
        }
    }
}
