using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBAChallenger_withClass
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dictPlayerPositionSkill = new Dictionary<string, Player>();
            string command;
            while ((command = Console.ReadLine()) != "Season end")
            {
                string[] commandArray = command.Split(" -> ",' ');
                if (!commandArray.Contains("vs"))
                {
                    string playerName = commandArray[0];
                    string position = commandArray[1];
                    int skill = int.Parse(commandArray[2]);
                    if (!dictPlayerPositionSkill.ContainsKey(playerName))
                    {
                        var newPlayer = new Player(playerName);
                        newPlayer.Name = playerName;
                        newPlayer.DictPositionSkill = new Dictionary<string, int>();
                        newPlayer.DictPositionSkill.Add(position, skill);
                        dictPlayerPositionSkill.Add(playerName, newPlayer);
                    }

                    else if (dictPlayerPositionSkill.ContainsKey(playerName))
                    {
                        if (!dictPlayerPositionSkill[playerName].DictPositionSkill.ContainsKey(position))
                        {
                            dictPlayerPositionSkill[playerName].DictPositionSkill.Add(position, skill);
                        }

                        else if (dictPlayerPositionSkill[playerName].DictPositionSkill[position] < skill)
                        {
                            dictPlayerPositionSkill[playerName].DictPositionSkill[position] = skill;
                        }
                    }
                }

                else if (commandArray.Contains("vs"))
                {
                    string firstPlayer = commandArray[0];
                    string secondPlayer = commandArray[2];
                    if(!dictPlayerPositionSkill.ContainsKey(firstPlayer) || !dictPlayerPositionSkill.ContainsKey(secondPlayer))
                    {
                        continue;
                    }

                    bool firstPlayerIsWinner = false;
                    bool secondPlayerIsWinner = false;
                    string commanPosition = string.Empty;
                    int currentSkill = 0;
                    foreach (var (position1, skill1) in dictPlayerPositionSkill[firstPlayer].DictPositionSkill)
                    {
                        foreach (var (position2, skill2) in dictPlayerPositionSkill[secondPlayer].DictPositionSkill)
                        {
                            if (position1 == position2 && skill1>skill2)
                            {
                                commanPosition = position1;
                                currentSkill = skill2;
                                firstPlayerIsWinner = true;
                                break;
                            }

                            else if(position1==position2 && skill2 > skill1)
                            {
                                commanPosition = position1;
                                currentSkill = skill1;
                                secondPlayerIsWinner = true;
                                break;
                            }
                        }

                        if(firstPlayerIsWinner=true || secondPlayerIsWinner == true)
                        {
                            break;
                        }
                    }

                    if (firstPlayerIsWinner)
                    {
                        dictPlayerPositionSkill.Remove(secondPlayer);
                        dictPlayerPositionSkill[firstPlayer].DictPositionSkill[commanPosition] -= currentSkill;
                    }

                    if (secondPlayerIsWinner)
                    {
                        dictPlayerPositionSkill.Remove(firstPlayer);
                        dictPlayerPositionSkill[secondPlayer].DictPositionSkill[commanPosition] -= currentSkill;
                    }






                }





            }



        }
    }

    class Player
    {
        public string Name { get; set; }
        public new Dictionary<string, int> DictPositionSkill { get; set; }

        public Player(string name)
        {
            this.Name = name;
            this.DictPositionSkill = new Dictionary<string, int>();
        }

    }
}
