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
using TestStack.White.UIItems.TreeItems;
using NUnit;
using NUnit.Framework;

namespace MusicPlayerTests
{
  public class MusicPlayerButtonPage : AssertAudio
  {
    public void PressPlay()
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
      Thread.Sleep(3000);
      Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(clickPlay.Text, "PlayButton");
      Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(IsAudioPlaying(GetDefaultRenderDevice()));
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
      string fileName = FileNameConstantFile.MusicPath;
      fileNameTextBox.Text = fileName;
      var openFile = windows.Get<Button>(SearchCriteria.ByAutomationId("1"));
      openFile.Click();
      var listBox = windows.Get<ListBox>("PlayingTrack");
      listBox.Click();
      var clickPlay = windows.Get<Button>(SearchCriteria.ByAutomationId("PlayButton"));
      clickPlay.Click();
      Thread.Sleep(3000);
      Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(clickPlay.Text, "PlayButton");
      var clickStop = windows.Get<Button>(SearchCriteria.ByAutomationId("StopButton"));
      clickStop.Click();
      Thread.Sleep(1000);
      Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(IsAudioPlaying(GetDefaultRenderDevice()));
      Thread.Sleep(3000);
      Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(clickStop.Text, "StopButton");
      application.Close();
    }

    public void PressPause()
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
      Thread.Sleep(3000);
      Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(clickPlay.Text, "PlayButton");
      Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(IsAudioPlaying(GetDefaultRenderDevice()));
      var clickPause = windows.Get<Button>(SearchCriteria.ByAutomationId("PauseButton"));
      clickPause.Click();
      Thread.Sleep(1000);
      Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(IsAudioPlaying(GetDefaultRenderDevice()));
      Thread.Sleep(3000);
      Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(clickPause.Text, "Pause");
      application.Close();

    }

    public void PressShuffle()
    {
      var application = Application.Launch("Music Player.exe");
      var windows = application.GetWindow("Music Player", InitializeOption.NoCache);
      var menu = windows.MenuBar.MenuItem("File", "Open Folder");
      menu.Click();
      var folderImage = windows.Get<TreeNode>(SearchCriteria.ByText("Music Files"));
      folderImage.Click();
      var openFile = windows.Get<Button>(SearchCriteria.ByAutomationId("1"));
      openFile.Click();
      var listBox = windows.Get<ListBox>("MusicListBox");
      var selectedItem = listBox.SelectedItem;
      NUnit.Framework.Assert.That(selectedItem.Text, Is.EqualTo(FileNameConstantFile.MusicFile1Playlist));
      var clickShuffle = windows.Get<Button>(SearchCriteria.ByAutomationId("ShuffleSongButton"));
      clickShuffle.Click();
      Thread.Sleep(3000);
      Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(clickShuffle.Text, "ShuffleSongButton");

      //Random Shuffle
      NUnit.Framework.Assert.That(listBox.SelectedItemText, Is.EqualTo(FileNameConstantFile.MusicFile2Playlist));
      Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(IsAudioPlaying(GetDefaultRenderDevice()));
      application.Close();

    }
  }
}
