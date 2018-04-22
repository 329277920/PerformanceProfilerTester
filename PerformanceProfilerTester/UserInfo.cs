using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceProfilerTester
{
    public class UserInfo
    {
        public string Name { get; set; }

        public int ClassId { get; set; }
    }

    public class UserManager
    {
        private static Random Random = new Random();

        private static char[] Letters = new Lazy<char[]>(()=> {
            char[] letters = new char[26];
            int i = 0;
            for (var letter = 'a'; letter <= 'z'; letter++)
            {
                letters[i++] = letter;
            }
            return letters;
        }).Value;

        private static string BuildUserName()
        {
            char[] userName = new char[5];
            for (var i = 0; i < 5; i++)
            {
                userName[i] = Letters[Random.Next(0, 25)];
            }
            return new string(userName);
        }

        public static List<UserInfo> GetUsers(int userCount, int classCount)
        {
            List<UserInfo> users = new List<UserInfo>();
            for (var i = 0; i < userCount; i++)
            {
                users.Add(new UserInfo()
                {
                    Name = BuildUserName(),
                    ClassId = Random.Next(1, classCount + 1)
                });
            }
            return users;
        }
    }
}
