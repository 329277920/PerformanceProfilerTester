using System;
using System.Collections.Generic;

namespace PerformanceProfilerTester
{
    public class TestModel
    {        
        public int Id { get; set; }

        public TestModelItem[] Items { get; set; }

        public static TestModel[] GetTestModel(int count, int itemCount, string message)
        {
            List<TestModel> entities = new List<TestModel>();
            for (var i = 0; i < count; i++)
            {
                var entity = new TestModel() { Id = i + 1, Items = new TestModelItem[itemCount] };

                for (var j = 0; j < itemCount - 1; j++)
                {
                    entity.Items[j] = new TestModelItem() { Message = message };
                }
                entities.Add(entity);
            }
            return entities.ToArray();
        }
    }

    public class TestModelItem
    {
        public string Message { get; set; }
    }


}
