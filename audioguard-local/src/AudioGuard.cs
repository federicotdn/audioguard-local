using AudioSwitcher.AudioApi.CoreAudio;
using System;
using WebSocketSharp;

namespace audioguard {
    class AudioGuard {

        private WebSocket ws;
        private CoreAudioDevice audioDevice;

        public AudioGuard() {
            audioDevice = new CoreAudioController().DefaultPlaybackDevice;
            ws = new WebSocket("ws://10.16.66.58:9000");
            ws.OnMessage += OnMessage;
        }

        private void OnMessage(object sender, MessageEventArgs e) {
            Console.WriteLine(e.Data);
            int volume = 50;
            int.TryParse(e.Data, out volume);

            if (volume < 0) {
                volume = 0;
            } else if (volume > 100) {
                volume = 100;
            }

            audioDevice.Volume = volume;
        }

        public void Connect() {
            ws.Connect();
        }
    }
}
