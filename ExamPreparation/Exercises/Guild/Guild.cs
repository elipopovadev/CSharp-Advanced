using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
   public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (this.roster.Any(p => p.Name == name))
            {
                Player foundedPlayer = this.roster.Where(p => p.Name == name).First();
                this.roster.Remove(foundedPlayer);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            if (this.roster.Any(p => p.Name == name && p.Rank != "Member"))
            {
                Player foundedPlayer = this.roster.Where(p => p.Name == name && p.Rank != "Member").First();
                foundedPlayer.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (this.roster.Any(p => p.Name == name && p.Rank != "Trial"))
            {
                Player foundedPlayer = this.roster.Where(p => p.Name == name && p.Rank != "Trial").First();
                foundedPlayer.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> listWithKickedPlayers = new List<Player>();
            foreach (var player in this.roster)
            {
                if (player.Class == @class)
                {
                    listWithKickedPlayers.Add(player);
                }
            }

            this.roster.RemoveAll(p => p.Class == @class);
            return listWithKickedPlayers.ToArray();
        }

        public int Count => this.roster.Count();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
