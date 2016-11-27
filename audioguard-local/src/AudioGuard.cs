using AudioSwitcher.AudioApi.CoreAudio;
using System;
using WebSocketSharp;

namespace audioguard {
    class AudioGuard {

        private WebSocket ws;
        private CoreAudioDevice audioDevice;

        public AudioGuard() {
            audioDevice = new CoreAudioController().DefaultPlaybackDevice;
            ws = new WebSocket("ws://127.0.0.1:9000");
            ws.OnMessage += OnMessage;
        }

        private void OnMessage(object sender, MessageEventArgs e) {
            Console.WriteLine(e.Data);
            int pctgDiff;
            bool ok = int.TryParse(e.Data, out pctgDiff);
            if (!ok) {
                Console.WriteLine("Unable to parse int: " + e.Data);
                return;
            }

            float pctg = 1.0f + (pctgDiff / 100.0f);
            float newVolume = (float)audioDevice.Volume * pctg;

            Console.WriteLine("Setting new volume at: " + newVolume.ToString());

            if (newVolume < 0) {
                newVolume = 0;
            } else if (newVolume > 100) {
                newVolume = 100;
            }

            audioDevice.Volume = newVolume;
        }

        public void Connect() {
            ws.Connect();
        }
    }
}
