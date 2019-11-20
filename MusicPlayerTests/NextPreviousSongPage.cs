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
  public class NextPreviousSongPage
  {
    public void NextAndPreviousSong()
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
      selectedItem.Click();
      var clickPlay = windows.Get<Button>(SearchCriteria.ByAutomationId("PlayButton"));
      clickPlay.Click();
      Thread.Sleep(2000);


      //Fast Forward
      var fastForward = windows.Get<Button>(SearchCriteria.ByAutomationId("PlayNextSong"));
      fastForward.Click();
      var pressForwardPlay = windows.Get<Button>(SearchCriteria.ByAutomationId("PlayButton"));
      pressForwardPlay.Click();
      Thread.Sleep(2000);


      ////Play Backward
      var pressBackward = windows.Get<Button>(SearchCriteria.ByAutomationId("PreviousSong"));
      pressBackward.Click();
      Thread.Sleep(2000);
      var pressBackPlay = windows.Get<Button>(SearchCriteria.ByAutomationId("PlayButton"));
      pressBackPlay.Click();
      Thread.Sleep(2000);

      application.Close();

    }
  }
}
