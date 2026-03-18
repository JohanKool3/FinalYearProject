using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FinalYearProject.Shared.Services
{
    /// <summary>
    /// Keeps track of the playback time in a global context.
    /// </summary>
    public class GlobalTimerService
    {
        private Stopwatch _clock = new();
        private CancellationTokenSource? _cts;

        public double CurrentTime 
            => _clock.Elapsed.TotalSeconds;

        public event Func<Task>? OnTick;

        public void Start()
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            _clock.Restart();

            _ = RunClock(_cts.Token);
        }

        public void Stop()
        {
            _cts?.Cancel();
        }

        private async Task RunClock(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (OnTick is not null)
                {
                    await OnTick.Invoke();
                }
                await Task.Delay(1, token);
            }
        }
    }
}
