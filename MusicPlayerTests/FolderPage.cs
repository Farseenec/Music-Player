using NUnit.Framework;
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

namespace MusicPlayerTests
{
  public class FolderPage : AssertAudio
  {
    public void OpenMusicFolder()
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
      Assert.That(selectedItem.Text, Is.EqualTo("C:\\Users\\mohammed.farseen\\OneDrive - Royal Mail Group Ltd\\Desktop\\Music Files\\1-Minute Audio Test.mp3"));
      application.Close();

    }
    public void PlayMusicFromFolder()
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


      //1st item in the music list box
      Assert.That(selectedItem.Text, Is.EqualTo("C:\\Users\\mohammed.farseen\\OneDrive - Royal Mail Group Ltd\\Desktop\\Music Files\\1-Minute Audio Test.mp3"));
      selectedItem.Click();
      var clickPlay = windows.Get<Button>(SearchCriteria.ByAutomationId("PlayButton"));
      clickPlay.Click();
      Assert.AreEqual(clickPlay.Text, "PlayButton");
      Thread.Sleep(2000);
      Assert.IsTrue(IsAudioPlaying(GetDefaultRenderDevice()));


      //2nd item in the music list box
      listBox.Items[1].Click();
      Assert.That(listBox.SelectedItemText, Is.EqualTo("C:\\Users\\mohammed.farseen\\OneDrive - Royal Mail Group Ltd\\Desktop\\Music Files\\3 Minute Step Test Timer.mp3"));
      var clickPlayButton = windows.Get<Button>(SearchCriteria.ByAutomationId("PlayButton"));
      clickPlayButton.Click();
      Thread.Sleep(4000);
      Assert.IsTrue(IsAudioPlaying(GetDefaultRenderDevice()));
      application.Close();

    }
  }
}
