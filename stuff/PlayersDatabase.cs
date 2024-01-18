using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace stuff
{
    public static class PlayersDatabase
    {
        // Реализовать базу данных игроков и методы для работы с ней.
        // У игрока может быть уникальный номер, ник, уровень, флаг – забанен ли
        // он(флаг - bool).
        // Реализовать возможность добавления игрока, бана игрока по
        // уникальному номеру, разбана игрока по уникальному номеру и удаление
        // игрока.
        // Создание самой БД не требуется, задание выполняется инструментами,
        // которые вы уже изучили в рамках курса. Но нужен класс, который
        // содержит игроков и её можно назвать "База данных".
        
        
        private static Dictionary<int, PlayerInfo> playersID = new Dictionary<int, PlayerInfo>();
        public static void AddPlayer()
        {
            Console.Write("Enter your nickname: ");
            PlayerInfo newPlayer = new PlayerInfo(Console.ReadLine());
            
            playersID.Add(newPlayer.id, newPlayer);
            Console.WriteLine($"Your info:\nID: {newPlayer.id}\nLevel: {newPlayer.level}");
        }

        public static void BanPlayer(int id)
        {
            if (playersID.TryGetValue(id, out PlayerInfo player))
            {
                player.IsBanned = true;
                Console.WriteLine($"Player {player.nickname} was banned");
            }
            else
            {
                Console.WriteLine("Invalid ID");
            }
        }

        public static void UnbanPlayer(int id)
        {
            if (playersID.TryGetValue(id, out PlayerInfo player))
            {
                player.IsBanned = false;
                Console.WriteLine($"Player {player.nickname} was unbanned");
            }
            else
            {
                Console.WriteLine("Invalid ID");
            }
        }

        public static void DeletePlayer(int id)
        {
            if (playersID.TryGetValue(id, out PlayerInfo player))
            {
                playersID.Remove(id);
                Console.WriteLine($"The player with {id} ID was deleted");
            }
            else
            {
                Console.WriteLine("Invalid ID");
            }
        }

        public static int GetIDbyIndex(int index)
        {
            return playersID.ElementAt(index).Key;
        }
    }

    public class PlayerInfo
    {
        public string nickname;
        public int level;
        public bool IsBanned { get; set; }
        public readonly int id;
        public PlayerInfo(string nickname)
        {
            this.nickname = nickname;
            level = 1;
            IsBanned = false;
            id = GetHashCode();
        }
    }
    
}