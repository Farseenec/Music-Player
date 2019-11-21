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
using TestStack.White.UIItems.WindowItems;

namespace MusicPlayerTests
{
  public class MusicIdlePage : AssertAudio
  {
    public void IdleModeTest()
    {
      var application = Application.Launch("Music Player.exe");
      var windows = application.GetWindow("Music Player", InitializeOption.NoCache);
      var menu = windows.MenuBar.MenuItem("File", "Open File");
      menu.Click();
      var fileNameTextBox = windows.Get<TextBox>(SearchCriteria.ByAutomationId("1148"));
      string fileName = FileNameConstantFile.MusicPath;
      fileNameTextBox.Text = fileName;
      var openFile = windows.Get<Button>(SearchCriteria.ByAutomationId("1"));
      openFile.Click();
      var listBox = windows.Get<ListBox>("PlayingTrack");
      listBox.Click();
      var clickPlay = windows.Get<Button>(SearchCriteria.ByAutomationId("PlayButton"));
      clickPlay.Click();
      Thread.Sleep(25000);


      //Get Idle message box
      var label = windows.Get<Label>("65535");

      //Checking if the message is correct
      Assert.AreEqual("Device Idle", label.Text);
      

      Assert.IsTrue(IsAudioPlaying(GetDefaultRenderDevice()));

      application.Close();


    }
  }
}
