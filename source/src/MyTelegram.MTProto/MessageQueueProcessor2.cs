﻿namespace MyTelegram.MTProto;

public class MessageQueueProcessor2<TData>(
    ILogger<MessageQueueProcessor2<TData>> logger,
    IDataProcessor<TData> dataProcessor)
    : IMessageQueueProcessor<TData>
{
    //private readonly Channel<TData> _queue = Channel.CreateUnbounded<TData>();
    private const int MaxQueueCount = 1000;
    private readonly ConcurrentDictionary<long, Channel<TData>> _queues = new();
    private readonly SemaphoreSlim _semaphoreSlim = new(1, 1);
    private bool _isInited;

    public void Enqueue(TData message,
        long key)
    {
        if (!TryGetQueue(key, out var queue))
        {
            InitQueueIfNeed();
            if (!TryGetQueue(key, out queue))
            {
                throw new InvalidOperationException($"Get queue failed,key={key} message='{typeof(TData)}'");
            }
        }

        if (!queue!.Writer.TryWrite(message))
        {
            logger.LogWarning("Can not write message to queue");
        }
    }

    public async Task ProcessAsync()
    {
        InitQueueIfNeed();
        //while (await _queue.Reader.WaitToReadAsync())
        //{
        //    while (_queue.Reader.TryRead(out var item))
        //    {
        //        await func(item);
        //    }
        //}

        //await Parallel.ForEachAsync(_queues,
        //     async (queue,
        //         _) => {
        //             while (await queue.Value.Reader.WaitToReadAsync(_))
        //             {
        //                 while (queue.Value.Reader.TryRead(out var item))
        //                 {
        //                     try
        //                     {
        //                        //await func(item);
        //                        await _dataProcessor.ProcessAsync(item);
        //                     }
        //                     catch (Exception ex)
        //                     {
        //                         _logger.LogError(ex, "Process message queue error:");
        //                     }
        //                 }
        //             }
        //         })
        //        

        var tasks = new List<Task>();
        foreach (var queue in _queues)
        {
            var task = Task.Run(async () =>
            {
                while (await queue.Value.Reader.WaitToReadAsync())
                {
                    while (queue.Value.Reader.TryRead(out var item))
                    {
                        try
                        {
                            //await func(item);
                            await dataProcessor.ProcessAsync(item);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "Process message queue error:");
                        }
                    }
                }
            });

            tasks.Add(task);
        }

        await Task.WhenAll(tasks);
        //return Task.CompletedTask;
    }
    //private Channel<TData> GetQueue(long key)
    //{
    //    var n = Math.Abs(key % MaxQueueCount);
    //    if (!_queues.TryGetValue(n, out var queue))
    //    {
    //        _logger.LogWarning("Can not find queue for key {Key}", key);
    //    }

    //    return queue;
    //}

    private void InitQueueIfNeed()
    {
        if (!_isInited)
        {
            _semaphoreSlim.Wait();
            for (var i = 0; i < MaxQueueCount; i++)
            {
                _queues.TryAdd(i, Channel.CreateUnbounded<TData>());
            }

            _isInited = true;
            _semaphoreSlim.Release();
        }
    }

    private bool TryGetQueue(long key,
        out Channel<TData>? queue)
    {
        var n = Math.Abs(key % MaxQueueCount);
        if (_queues.TryGetValue(n, out queue))
        {
            return true;
        }

        logger.LogWarning("Can not find queue for key {Key}", key);
        return false;
    }
}
