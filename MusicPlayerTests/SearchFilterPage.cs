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
using TestStack.White.UIItems.TableItems;

namespace MusicPlayerTests
{
  public class SearchFiltersPage
  {
    public void SearchMusicFile()
    {
      var application = Application.Launch("Music Player.exe");
      var windows = application.GetWindow("Music Player", InitializeOption.NoCache);
      SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("SearchBar");

      TextBox textBox = windows.Get<TextBox>(searchCriteria);

      //Clear and enter text. Use BulkText to set value in textbox for better performance.
      textBox.BulkText = "3 Minute";

      //Click center of text box
      textBox.ClickAtCenter();

      SearchCriteria dataGrid = SearchCriteria.ByAutomationId("allSongs");
      ListView test = windows.Get<ListView>(dataGrid);
      ListViewRow first = test.Rows[0];
      Assert.AreEqual("C:\\Users\\mohammed.farseen\\OneDrive - Royal Mail Group Ltd\\Desktop\\Music Files\\3 Minute Step Test Timer.mp3", first.Cells[0].Text);










    }
  }


}
