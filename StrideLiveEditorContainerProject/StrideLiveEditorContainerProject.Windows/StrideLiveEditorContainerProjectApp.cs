using System;
using System.Threading;
using Stride.Engine;
using System.Threading.Tasks;
using StrideLiveEditor.Avalonia;
using Avalonia;

namespace StrideLiveEditorContainerProject.Windows
{
    internal class StrideLiveEditorContainerProjectApp
    {
        [STAThread]
        private static void Main(string[] args)
        {
            using (var game = new Game())
            using (var cts = new CancellationTokenSource())
            {
                // WPF editor
                var window = new StrideLiveEditor.LiveEditorMainWindow(game);
                window.Show();
                
                // Avalonia editor
                Task.Run(() => StartLiveEditor(args, game, cts));

                game.Run();

                // Close the WPF window when the game is closed
                if (window != null)
                    window.Close();
                
                // Close the Avalonia window when the game is closed
                cts.Cancel();
            }
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>().UsePlatformDetect();

        private static void StartLiveEditor(string[] args, Game game, CancellationTokenSource cts)
        {
            var liveEditor = new LiveEditor(game, args);
            liveEditor.Start(cts.Token);
        }
    }
}
