using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AudioSwitcher.AudioApi.CoreAudio;

namespace iot {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("starting");
            CoreAudioDevice a = new CoreAudioController().DefaultPlaybackDevice;

            while (true) {
                Console.WriteLine("curent vol: " + a.Volume);
                Console.WriteLine("input new vol:");
                string i = Console.ReadLine();
                int v;
                if (!int.TryParse(i, out v)) {
                    continue;
                }

                a.Volume = v;
            }
        }
    }
}
