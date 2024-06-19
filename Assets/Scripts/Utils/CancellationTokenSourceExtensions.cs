using System.Threading;

namespace AnimalCatcher.Utils
{
    public static class CancellationTokenSourceExtensions
    {
        public static void CancelAndDispose(this CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }
    }   
}