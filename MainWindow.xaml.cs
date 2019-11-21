using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace Music_Player
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    String musicTrack = "";
    bool musicPaused = false;
    public MainWindow()
    {
      InitializeComponent();
      ShowAllSongs();
      //IdleMode();
    }



    //This methods plays the music when the user click on the play button
    private void PlayButton_Click(object sender, RoutedEventArgs e)
    {
      if (musicPaused)
      {
        ContinuePlaying();
      }
      else
      {
        if (MusicListBox.Items.Count > 0)
        {
          PlayPlaylist();

        }
        if (PlayingTrack.Items.Count > 0)
        {
          PlayMusic();
        }

      }
    }

    //This methods pause the music when the user click on pause button
    private void PauseButton_Click(object sender, RoutedEventArgs e)
    {
      MediaPlayer.Pause();
      musicPaused = true;
    }

    private void PreviousSongButton_Click(object sender, RoutedEventArgs e)
    {
      if (MusicListBox.SelectedIndex > 0)
      {
        MusicListBox.SelectedIndex = MusicListBox.SelectedIndex - 1;
        MediaPlayer.Close();
        Uri src;
        src = new Uri(MusicListBox.SelectedValue.ToString());
        MediaPlayer.Source = src;
        MediaPlayer.Play();
      }
    }

    //This methods stop the music when the user click on stop button
    private void StopButton_Click(object sender, RoutedEventArgs e)
    {
      MediaPlayer.Stop();

    }

    //This methods plays the next song in the playlist
    private void NextSongButton_Click(object sender, RoutedEventArgs e)
    {
      if (MusicListBox.SelectedIndex < MusicListBox.Items.Count - 1)
      {
        MusicListBox.SelectedIndex = MusicListBox.SelectedIndex + 1;
        MediaPlayer.Close();
        Uri src;
        src = new Uri(MusicListBox.SelectedValue.ToString());
        MediaPlayer.Source = src;
        MediaPlayer.Play();

      }
    }
    //This methods shuffles the playlist or choose a random music
    private void ShuffleButton_Click(object sender, RoutedEventArgs e)
    {
      var random = new Random();
      int i = MusicListBox.Items.Count;
      int chosenItem = random.Next(0, i);
      MusicListBox.SelectedIndex = chosenItem;
      FileInfo fi = null;
      Uri src;
      fi = new FileInfo(MusicListBox.SelectedValue.ToString());
      src = new Uri(MusicListBox.SelectedValue.ToString());
      MediaPlayer.Source = src;
      MediaPlayer.Play();
    }

    //This method allows the user to change the volume
    private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      MediaPlayer.Volume = Volume.Value;

    }

    //This method gets the file path of the music and play
    public void PlayMusic()
    {
      bool fileExist = true;
      FileInfo fi = null;
      Uri src;
      try
      {
        fi = new FileInfo(musicTrack);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        fileExist = false;
      }
      if (fileExist)
      {
        if (!fi.Exists)
        {
          MessageBox.Show("The" + musicTrack + "you entered is incorrect or not found");
        }
        else
        {
          src = new Uri(musicTrack);
          MediaPlayer.Source = src;
          ContinuePlaying();
        }
      }
    }

    //This method allows the music to continue where it was left off
    public void ContinuePlaying()
    {
      musicPaused = false;
      MediaPlayer.Play();
    }

    //This method allows the user to click on the MusicListBox(playlist) and play music depending on the index
    private void PlayPlaylist()
    {
      int selectedItemIndex = -1;
      if (MusicListBox.Items.Count > 0)
      {
        selectedItemIndex = MusicListBox.SelectedIndex;
        if (selectedItemIndex > -1)
        {
          musicTrack = MusicListBox.Items[selectedItemIndex].ToString();
          PlayMusic();

        }
      }

    }


    //This method exit the application
    private void CloseApp_Click(object sender, RoutedEventArgs e)
    {
      mainWindow.Close();

    }

    //This method opens file and allows the user to choose a music file
    private void OpenFile_Click(object sender, RoutedEventArgs e)
    {
      Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
      MediaPlayer.Stop();
      ClearTextBlocks();
      Nullable<bool> result;
      openFileDialog.FileName = "";

      //Clears the previous items in the playlist box and trackbox
      MusicListBox.Items.Clear();
      PlayingTrack.Items.Clear();


      openFileDialog.DefaultExt = ".mp3";
      openFileDialog.Filter = ".mp3|*.mp3|.mpg|*.mpg|.wmv|*.wmv|All files (*.*)|*.*";
      openFileDialog.CheckFileExists = true;
      openFileDialog.FileName = String.Empty;
      result = openFileDialog.ShowDialog();
      if (result == true)
      {
        PlayingTrack.Items.Add(openFileDialog.FileName);

      }
    }



    //Allows the user to open a folder which main contains some music files
    private void OpenFolder_Click(object sender, RoutedEventArgs e)
    {
      String folderPath = "";
      string[] files;
      // Note: You must browse to add a reference to System.Windows.Forms
      // in Solution Explorer in order to have access to the FolderBrowserDialog			
      System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      MediaPlayer.Stop();
      PlayingTrack.Items.Clear();
      ClearTextBlocks();

      System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();
      if (result == System.Windows.Forms.DialogResult.OK)
      {
        folderPath = folderBrowserDialog.SelectedPath;
      }
      if (folderPath != "")
      {
        MusicListBox.Items.Refresh();

        MusicListBox.Visibility = Visibility.Visible;
        files = Directory.GetFiles(folderPath, "*.mp3");

        foreach (string fn in files)
        {

          MusicListBox.Items.Add(fn);
        }
        MusicListBox.SelectedIndex = 0;
      }

    }

    //Clears the value from music info
    public void ClearTextBlocks()
    {
      musicPath.Text = null;
      musicName.Text = null;
    }



    //This method open the saved playlist using the xml data
    private void OpenPlaylist_Click(object sender, RoutedEventArgs e)
    {
      XmlDocument xdoc = new XmlDocument();
      XmlNodeList xmlNodes;
      XmlNode pathNode;
      string track;
      bool ok = true;
      try
      {
        xdoc.Load("playlistData.xml");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Error Loading XML Data");
        ok = false;
      }
      if (ok)
      {
        MusicListBox.Items.Clear();
        MusicListBox.Visibility = Visibility.Visible;
        xmlNodes = xdoc.SelectNodes("PlaylistTrack/Track");
        foreach (XmlNode node in xmlNodes)
        {
          pathNode = node.SelectSingleNode("MusicPath");
          track = pathNode.InnerText;
          MusicListBox.Items.Add(track);
        }
        MusicListBox.SelectedIndex = 0;
      }
    }

    //This methods saves the playlist and store it in an XML file
    private void SavePlaylist_Click(object sender, RoutedEventArgs e)
    {
      XmlTextWriter xMLTextWriter = new XmlTextWriter("playlistData.xml", Encoding.Unicode);
      xMLTextWriter.WriteStartElement("PlaylistTrack");

      foreach (string item in MusicListBox.Items)
      {
        xMLTextWriter.WriteStartElement("Track");
        xMLTextWriter.WriteElementString("MusicPath", item);
        string fileName = System.IO.Path.GetFileName(item);
        string simpleFileName = System.IO.Path.GetFileNameWithoutExtension(fileName);
        xMLTextWriter.WriteElementString("TrackName", simpleFileName);



        xMLTextWriter.WriteEndElement();
      }
      xMLTextWriter.WriteEndElement();

      xMLTextWriter.Close();

      MessageBox.Show("Playlist have been saved");
    }


    //This displays music track info depending on what the user has clicked
    private void PlayingTrack_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      int selectedItemIndex = -1;

      if (PlayingTrack.Items.Count > 0)
      {
        selectedItemIndex = PlayingTrack.SelectedIndex;
        if (selectedItemIndex > -1)
        {
          musicTrack = PlayingTrack.Items[selectedItemIndex].ToString();
          musicPath.Text = musicTrack;
          string fileName = System.IO.Path.GetFileName(musicTrack);
          string simpleFileName = System.IO.Path.GetFileNameWithoutExtension(fileName);
          musicName.Text = simpleFileName;
        }
      }
    }

    //This displays music track info when user clicks the playlist box(MusicListBox)

    private void MusicListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      int selectedItemIndex = -1;

      if (MusicListBox.Items.Count > 0)
      {
        selectedItemIndex = MusicListBox.SelectedIndex;
        if (selectedItemIndex > -1)
        {
          string musicTracks = MusicListBox.Items[selectedItemIndex].ToString();
          PlayingTrack.Items.Clear();
          musicPath.Text = musicTracks;
          string fileName = System.IO.Path.GetFileName(musicTracks);
          string simpleFileName = System.IO.Path.GetFileNameWithoutExtension(fileName);
          musicName.Text = simpleFileName;
          PlayingTrack.Items.Add(simpleFileName);
        }

      }
    }

    //Search text box functionality
    private void WaterMark_GotFocus(object sender, RoutedEventArgs e)
    {
      WaterMark.Visibility = System.Windows.Visibility.Collapsed;
      Search.Visibility = System.Windows.Visibility.Visible;
      Search.Focus();
    }


    //Search text box functionality

    private void Search_LostFocus(object sender, RoutedEventArgs e)
    {
      if (string.IsNullOrEmpty(Search.Text))
      {
        Search.Visibility = System.Windows.Visibility.Collapsed;
        WaterMark.Visibility = System.Windows.Visibility.Visible;
      }
    }

    //This method gets data from xml file and show it in the datagrid
    private void ShowAllSongs()
    {
      MusicListBox.Items.Clear();
      DataSet dataSet = new DataSet();
      dataSet.ReadXml("playlistData.xml");
      this.allSongs.ItemsSource = dataSet.Tables[0].DefaultView;
    }

    //This method allows the user to search and filter according to track name
    private void Search_SelectionChanged(object sender, RoutedEventArgs e)
    {

      DataSet dataSet = new DataSet();
      dataSet.ReadXml("playlistData.xml");
      DataView dv = new DataView();
      dv = dataSet.Tables[0].DefaultView;
      dv.RowFilter = "TrackName LIKE '%" + Search.Text + "%'";
      this.allSongs.ItemsSource = dv;
    }

    private void Media_Player_Opened(object sender, RoutedEventArgs e)
    {
      SliderPosition.Maximum = MediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;

    }

    private void SliderPosition_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      int SliderValue = (int)SliderPosition.Value;
      TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
      MediaPlayer.Position = ts;
    }


    //This method test idle mode scenorios
    //public void IdleMode()
    //{
    //  var timer = new DispatcherTimer
    //        (
    //        TimeSpan.FromMinutes(0.5), //30 seconds
    //        DispatcherPriority.SystemIdle,// 
    //        (s, e) => MessageBox.Show("Device Idle"),
    //        Application.Current.Dispatcher
    //        );

    //}
  }
}
