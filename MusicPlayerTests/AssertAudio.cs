using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerTests
{
  public class AssertAudio
  {
    public static MMDevice GetDefaultRenderDevice()
    {
      using (var enumerator = new MMDeviceEnumerator())
      {
        return enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
      }
    }

    public static bool IsAudioPlaying(MMDevice device)
    {
      using (var meter = AudioMeterInformation.FromDevice(device))
      {
        return meter.PeakValue > 0;
      }
    }
  }
}
