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
    FileNameConstantFile FileNameConstantFile;
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
      string fileName = FileNameConstantFile.MusicPath;
      fileNameTextBox.Text = fileName;
      windows.Close();
      application.Close();

    }
  }
}
