using System.Collections.Generic;

namespace MessageCards
{
    public class ActionCard : Action
    {
        public List<Input> Inputs { get; set; }

        public List<INestableAction> Actions { get; set; }

        public ActionCard(string name) : base("ActionCard", name)
        {
            Actions = new List<INestableAction>();
            Inputs = new List<Input>();
        }
    }
}
