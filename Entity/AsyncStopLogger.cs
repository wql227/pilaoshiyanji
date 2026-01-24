using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoPENetConnect
{
    public static class AsyncStopLogger
    {
        private static BlockingCollection<LogDataItem> _logQueue = new BlockingCollection<LogDataItem>(new ConcurrentQueue<LogDataItem>());
        private static Thread _logWorkerThread;
        private static bool _isRunning = false;

        static AsyncStopLogger()
        {
            //StartWorker();
        }

        public static void EnqueueLog(string logLine)
        {
            if (!_isRunning)
            {
                return;
            }

            try
            {
                // 不会阻塞，除非队列设置了上限
                _logQueue.Add(new LogDataItem(logLine));
            }
            catch (ObjectDisposedException)
            {
                // 日志系统已停止
            }
        }


        public static void EnqueueLog(int channelNo, string logLine)
        {
            if (!_isRunning)
            {
                return;
            }

            try
            {
                // 不会阻塞，除非队列设置了上限
                _logQueue.Add(new LogDataItem(channelNo, logLine));
            }
            catch (ObjectDisposedException)
            {
                // 日志系统已停止
            }
        }

        public static void Shutdown()
        {
            _isRunning = false;
            _logQueue?.Dispose();
        }

        private static void StartWorker()
        {
            _isRunning = true;
            _logWorkerThread = new Thread(WorkerLoop)
            {
                Name = "Async CSV Logger Thread",
                IsBackground = true // 程序退出时自动结束
            };
            _logWorkerThread.Start();
        }

        private static void WorkerLoop()
        {
            // 缓冲一批日志再写，减少 I/O 次数
            var batch = new List<LogDataItem>(1000);

            try
            {
                while (_isRunning)
                {
                    batch.Clear();

                    // 取出最多 100 条，或等待 100ms
                    var item = _logQueue.Take();
                    batch.Add(item);

                    // 尝试再多取一些
                    for (int i = 0; i < 999; i++)
                    {
                        if (_logQueue.TryTake(out var nextItem, 10))
                        {
                            batch.Add(nextItem);
                        }
                        else
                        {
                            break;
                        }
                    }

                    // 按通道分组写入
                    var groups = batch.GroupBy(x => x.ChannelNo);
                    foreach (var group in groups)
                    {
                        var sb = new StringBuilder();
                        foreach (var logItem in group)
                        {
                            sb.AppendLine(logItem.LogLine);
                        }
                        LogHelper.SaveStopData(sb.ToString()/*, group.Key*/);
                    }
                }
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is ObjectDisposedException)
            {
                // 队列关闭，正常退出
            }
            catch (Exception ex)
            {
                // 记录错误（可用 EventLog 或控制台）
                Console.WriteLine($"Logger Worker Error: {ex.Message}");
            }
        }
    }

}