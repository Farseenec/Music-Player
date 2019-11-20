using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;

namespace MusicPlayerTests
{
  public class PlaylistPage
  {
    public void SavePlaylist()
    {
      //Open folder
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



      //Saves the current playlist
      var menu2 = windows.MenuBar.MenuItem("File", "Save Playlist");
      menu2.Click();
      Window messageBox = windows.MessageBox("");
      var label = windows.Get<Label>("65535");

      //Checking if the message is correct
      Assert.AreEqual("Playlist have been saved", label.Text);

      //Press the ok button in the message box
      windows.Get<Button>("2").Click();

      application.Close();

    }

    public void OpenPlayList()
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



      //Saves the current playlist
      var menu2 = windows.MenuBar.MenuItem("File", "Save Playlist");
      menu2.Click();
      Window messageBox = windows.MessageBox("");
      var label = windows.Get<Label>("65535");

      //Checking if the message is correct
      Assert.AreEqual("Playlist have been saved", label.Text);

      //Press the ok button in the message box
      windows.Get<Button>("2").Click();


      //Click on Open File- was failing at the window step- Please check
      var clickOpen = windows.MenuBar.MenuItem("File", "Open File");
      clickOpen.Click();
      windows.Get<Button>("2").Click();

      //Open Playlist
      var musiclistBox = windows.Get<ListBox>("MusicListBox");
      var emptyBox = musiclistBox.SelectedItem;
      Assert.IsNull(emptyBox);


      //OpenPlaylist
      var openplaylist = windows.MenuBar.MenuItem("File", "Open Playlist");
      openplaylist.Click();
      var musicBox = windows.Get<ListBox>("MusicListBox");
      var selectedItemMusic = musicBox.SelectedItem;
      musicBox.Select(0);
      Assert.That(selectedItemMusic.Text, Is.EqualTo("C:\\Users\\mohammed.farseen\\OneDrive - Royal Mail Group Ltd\\Desktop\\Music Files\\1-Minute Audio Test.mp3"));
      musicBox.Items[1].Click();
      Assert.That(musicBox.SelectedItemText, Is.EqualTo("C:\\Users\\mohammed.farseen\\OneDrive - Royal Mail Group Ltd\\Desktop\\Music Files\\3 Minute Step Test Timer.mp3"));

      application.Close();


    }

  }
}
