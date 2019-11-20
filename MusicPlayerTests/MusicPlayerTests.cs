using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MusicPlayerTests
{
  [TestClass]
  public class MusicPlayerTests
  {
    public void Launch_Music_Player()
    {
      LaunchMusicPlayerPage launchMusicPlayer = new LaunchMusicPlayerPage();
      launchMusicPlayer.LaunchMusicPlayer();
    }


    //This tests whether the file browser being opened
    [TestMethod]
    public void Open_File_Browser()
    {
      LaunchMusicPlayerPage openFileBrowser = new LaunchMusicPlayerPage();
      openFileBrowser.OpenFileBrowser();
    }

    [TestMethod]
    public void Enter_Music_Path()
    {
      LaunchMusicPlayerPage enterMusicPath = new LaunchMusicPlayerPage();
      enterMusicPath.EnterMusicPath();
    }


    [TestMethod]
    public void Press_Play_Music()
    {
      MusicPlayerButtonPage pressPlay = new MusicPlayerButtonPage();
      pressPlay.PressPlay();
    }

    [TestMethod]
    public void Press_Stop_Music()
    {
      MusicPlayerButtonPage pressStop = new MusicPlayerButtonPage();
      pressStop.PressStop();
    }

    [TestMethod]
    public void Open_Music_Folder()
    {
      FolderPage folderPage = new FolderPage();
      folderPage.OpenMusicFolder();

    }

    [TestMethod]
    public void Play_Music_Folder()
    {
      FolderPage playMusicFolder = new FolderPage();
      playMusicFolder.PlayMusicFromFolder();

    }

    [TestMethod]
    public void Save_Playlist()
    {
      PlaylistPage playlistPage = new PlaylistPage();
      playlistPage.SavePlaylist();
    }

    [TestMethod]
    public void Open_Playlist()
    {
      PlaylistPage openPlayList = new PlaylistPage();
      openPlayList.OpenPlayList();
    }

    [TestMethod]
    public void Exit_Application_Test()
    {
      ExitPage exit = new ExitPage();
      exit.ExitMusicPlayer();
    }

    [TestMethod]
    public void Next_Previous_Song_Test()
    {
      NextPreviousSongPage fastPreviousPage = new NextPreviousSongPage();
      fastPreviousPage.NextAndPreviousSong();
    }

    [TestMethod]
    public void Search_Filter_Test()
    {
      SearchFiltersPage filterMusic = new SearchFiltersPage();
      filterMusic.SearchMusicFile();
    }
  }
}