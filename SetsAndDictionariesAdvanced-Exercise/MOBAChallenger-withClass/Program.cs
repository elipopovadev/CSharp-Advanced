using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBAChallenger_withClass
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dictNamePlayer = new Dictionary<string, Player>();
            string command;
            while ((command = Console.ReadLine()) != "Season end")
            {
                if (!command.Contains("vs"))
                {
                    string[] commandArray = command.Split(" -> ");
                    string playerName = commandArray[0];
                    string position = commandArray[1];
                    int skill = int.Parse(commandArray[2]);
                    if (!dictNamePlayer.ContainsKey(playerName))
                    {
                        var newPlayer = new Player(playerName);
                        newPlayer.Name = playerName;
                        newPlayer.DictPositionSkill = new Dictionary<string, int>();
                        newPlayer.DictPositionSkill.Add(position, skill);
                        dictNamePlayer.Add(playerName, newPlayer);
                    }

                    else if (dictNamePlayer.ContainsKey(playerName))
                    {
                        if (!dictNamePlayer[playerName].DictPositionSkill.ContainsKey(position))
                        {
                            dictNamePlayer[playerName].DictPositionSkill.Add(position, skill);
                        }

                        else if (dictNamePlayer[playerName].DictPositionSkill[position] < skill)
                        {
                            dictNamePlayer[playerName].DictPositionSkill[position] = skill;
                        }
                    }
                }

                else if (command.Contains("vs"))
                {
                    string[] commandArray = command.Split(' ');
                    string firstPlayer = commandArray[0];
                    string secondPlayer = commandArray[2];
                    if (!dictNamePlayer.ContainsKey(firstPlayer) || !dictNamePlayer.ContainsKey(secondPlayer))
                    {
                        continue;
                    }

                    bool firstPlayerIsWinner = false;
                    bool secondPlayerIsWinner = false;
                    foreach (var (position1, skill1) in dictNamePlayer[firstPlayer].DictPositionSkill)
                    {
                        foreach (var (position2, skill2) in dictNamePlayer[secondPlayer].DictPositionSkill)
                        {
                            if (position1 == position2 && skill1 > skill2)
                            {
                                firstPlayerIsWinner = true;
                                break;
                            }

                            else if (position1 == position2 && skill2 > skill1)
                            {
                                secondPlayerIsWinner = true;
                                break;
                            }
                        }

                        if (firstPlayerIsWinner == true || secondPlayerIsWinner == true)
                        {
                            break;
                        }
                    }

                    if (firstPlayerIsWinner == false && secondPlayerIsWinner == false)
                    {
                        continue;
                    }

                    CheckWhoIsTheWinnerAndRemoveLoser(dictNamePlayer, firstPlayer, secondPlayer, firstPlayerIsWinner, secondPlayerIsWinner);
                }
            }

            PrintResult(dictNamePlayer);
        }



        private static void CheckWhoIsTheWinnerAndRemoveLoser(Dictionary<string, Player> dictPlayerPositionSkill, string firstPlayer, string secondPlayer, bool firstPlayerIsWinner, bool secondPlayerIsWinner)
        {
            if (firstPlayerIsWinner)
            {
                dictPlayerPositionSkill.Remove(secondPlayer);
            }

            else if (secondPlayerIsWinner)
            {
                dictPlayerPositionSkill.Remove(firstPlayer);
            }
        }

        private static void PrintResult(Dictionary<string, Player> dictNamePlayer)
        {
            foreach (var (currentName, currentPlayer) in dictNamePlayer
                .OrderByDescending(x => x.Value.DictPositionSkill.Values.Sum()).ThenBy(x => x.Key))
            {

                Console.WriteLine($"{currentName}: {currentPlayer.DictPositionSkill.Values.Sum()} skill");
                foreach (var (position, skill) in currentPlayer.DictPositionSkill
                    .OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {position} <::> {skill}");
                }
            }
        }


        class Player
        {
            public string Name { get; set; }
            public Dictionary<string, int> DictPositionSkill { get; set; }

            public Player(string name)
            {
                this.Name = name;
                this.DictPositionSkill = new Dictionary<string, int>();
            }
        }

    }
}
