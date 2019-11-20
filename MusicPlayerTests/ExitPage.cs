using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Factory;

namespace MusicPlayerTests
{
  public class ExitPage
  {
    public void ExitMusicPlayer()
    {
      var application = Application.Launch("Music Player.exe");
      var windows = application.GetWindow("Music Player", InitializeOption.NoCache);
      var menu = windows.MenuBar.MenuItem("File", "Exit");
      menu.Click();
      application.Close();
    }
  }
}
