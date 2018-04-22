using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace PerformanceProfilerTester.CoreWin
{
    class Program
    {
        static void Main(string[] args)
        {
            // ExecuteGrouping(Grouping3);

            // Execute(Serialize, 10000);

            // 创建1000个用户，10个分类
            // var entities = TestModel.GetTestModel(1000000, 1000, "呵呵呵呵");

            // TestMemory();

            TestMemory();

            Console.ReadKey();
        }

        #region CPU测试

        static void Execute(Action method, int count)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (var i = 0; i < count; i++)
            {
                method();
            }
            watch.Stop();
            Console.WriteLine($"耗时:{watch.ElapsedMilliseconds}毫秒。");

        }

        static void ExecuteGrouping(Action<UserInfo[]> grouping)
        {
            // 创建1000个用户，10个分类
            var users = UserManager.GetUsers(1000, 10).ToArray();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (var i = 0; i < 100000; i++)
            {
                grouping(users);
            }
            watch.Stop();
            Console.WriteLine($"耗时:{watch.ElapsedMilliseconds}毫秒。");

        }

        static void Grouping1(params UserInfo[] users)
        {
            // 按ClassId分组
            var result = (from user in users
                          group user by user.ClassId
                            into g
                          select new { ClassId = g.Key, Count = g.Count() }
                         ).ToArray();
        }

        static void Grouping2(params UserInfo[] users)
        {
            List<KeyValuePair<int, int>> result = new List<KeyValuePair<int, int>>();
            int oldClassId = 0;
            int count = 0;
            for (var i = 0; i < users.Length; i++)
            {
                var user = users[i];
                if (oldClassId != user.ClassId || i == users.Length - 1)
                {
                    if (oldClassId != 0 || i == users.Length - 1)
                    {
                        result.Add(new KeyValuePair<int, int>(oldClassId, count));
                        count = 0;
                    }
                    oldClassId = user.ClassId;
                }
                count++;
            }
        }

        static void Grouping3(params UserInfo[] users)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (var i = 0; i < users.Length; i++)
            {
                var user = users[i];
                if (!result.ContainsKey(user.ClassId))
                {
                    result.Add(user.ClassId, 1);
                }
                else
                {
                    result[user.ClassId]++;
                }
            }
        }

        static void Serialize()
        {
            var entities = TestModel.GetTestModel(10, 100, "我是中国人");

            for (var i = 0; i < 10000; i++)
            {
                Newtonsoft.Json.JsonConvert.SerializeObject(entities);
            }
            Console.WriteLine("OK");
        }

        #endregion

        #region 内存测试

        public static void TestMemory()
        {
            while (true)
            {
                var entity = new TestMemoryModle();

                Thread.Sleep(1);
            }                           
        }

        public static void TestMemory2()
        {
            List<string> items = new List<string>();
            int k = 0;
            while (true)
            {
                items.Add($"积分辣椒粉多了解案件发生纠纷会计分录{++k}");

                Thread.Sleep(1);
            }
        }

        #endregion

    }
}
