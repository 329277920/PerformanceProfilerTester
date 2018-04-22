using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceProfilerTester
{
    public class TestMemoryModle : IDisposable
    {
        private System.Threading.Semaphore _sh;
        public TestMemoryModle()
        {
            _sh = new System.Threading.Semaphore(5, 5);
        }

        public void Dispose()
        {
            // _sh.Dispose();
        }
    }
}
