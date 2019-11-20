using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace MusicPlayerTests
{
  public class LaunchMusicPlayerPage
  {
    public void LaunchMusicPlayer()
    {
      var application = Application.Launch("Music Player.exe");
      var windows = application.GetWindow("Music Player", InitializeOption.NoCache);
      application.Close();
    }

    public void OpenFileBrowser()
    {
      var application = Application.Launch("Music Player.exe");
      var windows = application.GetWindow("Music Player", InitializeOption.NoCache);
      var menu = windows.MenuBar.MenuItem("File", "Open File");
      menu.Click();
      windows.Close();
      var fileNameTextBox = windows.Get<TextBox>(SearchCriteria.ByAutomationId("1148"));
      application.Close();

    }

    public void EnterMusicPath()
    {
      var application = Application.Launch(@"Music Player.exe");
      var windows = application.GetWindow("Music Player", InitializeOption.NoCache);
      var menu = windows.MenuBar.MenuItem("File", "Open File");
      menu.Click();
      var fileNameTextBox = windows.Get<TextBox>(SearchCriteria.ByAutomationId("1148"));
      string fileName = "C:\\Music Files\\1-Minute Audio Test.mp3";
      fileNameTextBox.Text = fileName;
      windows.Close();
      application.Close();

    }
  }
}
