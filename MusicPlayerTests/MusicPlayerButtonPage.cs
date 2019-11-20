using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;

namespace MusicPlayerTests
{
  public class MusicPlayerButtonPage: AssertAudio
  {
    public void PressPlay()
    {
      var application = Application.Launch("Music Player.exe");
      var windows = application.GetWindow("Music Player", InitializeOption.NoCache);
      var menu = windows.MenuBar.MenuItem("File", "Open File");
      menu.Click();
      var fileNameTextBox = windows.Get<TextBox>(SearchCriteria.ByAutomationId("1148"));
      string fileName = "C:\\Music Files\\1-Minute Audio Test.mp3";
      fileNameTextBox.Text = fileName;
      var openFile = windows.Get<Button>(SearchCriteria.ByAutomationId("1"));
      openFile.Click();
      var listBox = windows.Get<ListBox>("PlayingTrack");
      listBox.Click();
      var clickPlay = windows.Get<Button>(SearchCriteria.ByAutomationId("PlayButton"));
      clickPlay.Click();
      Thread.Sleep(3000);
      Assert.AreEqual(clickPlay.Text, "PlayButton");
      Assert.IsTrue(IsAudioPlaying(GetDefaultRenderDevice()));
      Thread.Sleep(2000);
      application.Close();

    }

    public void PressStop()
    {
      var application = Application.Launch("Music Player.exe");
      var windows = application.GetWindow("Music Player", InitializeOption.NoCache);
      var menu = windows.MenuBar.MenuItem("File", "Open File");
      menu.Click();
      var fileNameTextBox = windows.Get<TextBox>(SearchCriteria.ByAutomationId("1148"));
      string fileName = "C:\\Music Files\\1-Minute Audio Test.mp3";
      fileNameTextBox.Text = fileName;
      var openFile = windows.Get<Button>(SearchCriteria.ByAutomationId("1"));
      openFile.Click();
      var listBox = windows.Get<ListBox>("PlayingTrack");
      listBox.Click();
      var clickPlay = windows.Get<Button>(SearchCriteria.ByAutomationId("PlayButton"));
      clickPlay.Click();
      Thread.Sleep(3000);
      Assert.AreEqual(clickPlay.Text, "PlayButton");
      var clickStop = windows.Get<Button>(SearchCriteria.ByAutomationId("StopButton"));
      clickStop.Click();
      Thread.Sleep(1000);
      Assert.IsFalse(IsAudioPlaying(GetDefaultRenderDevice()));
      Thread.Sleep(3000);
      Assert.AreEqual(clickStop.Text, "StopButton");
      application.Close();
    }

  }
}
