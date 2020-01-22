using System.Collections.Generic;

namespace MessageCards
{
    public class OpenUriAction : Action, INestableAction
    {
        public OpenUriAction(string name) : base("OpenUri", name)
        {
            Targets = new List<Target>();
        }

        public List<Target> Targets { get; set; }

        public void AddTarget(string uri, Target.Os os)
        {
            Targets.Add(new Target(uri, os));
        }
    }
}
