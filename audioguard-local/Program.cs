using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AudioSwitcher.AudioApi.CoreAudio;

namespace audioguard {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("starting");

            AudioGuard audioGuard = new AudioGuard();
            audioGuard.Connect();

            Console.ReadKey(true);
        }
    }
}
