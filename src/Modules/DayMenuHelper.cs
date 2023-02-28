
using project_foodie.Model;

namespace project_foodie.Modules
{
    public static class DayMenuHelper
    {
        public static List<(DayMenu DayMenu, int Index)> getSortedDayMenus(Menu menu)
        {
            var indexedDayMenus = menu.dayMenus
                .Select((d, i) => new { DayMenu = d, Index = i })
                .OrderBy(di => di.DayMenu.date)
                .ThenBy(di => di.DayMenu.type)
                .ToList();

            var sortedDayMenus = indexedDayMenus.Select(di => di.DayMenu).ToList();

            var result = new List<(DayMenu DayMenu, int Index)>();

            for (int i = 0; i < indexedDayMenus.Count(); i++)
            {
                result.Add((indexedDayMenus[i].DayMenu, i));
            }

            return result;
        }

        public static int getNumberOfSameDateDayMenus(int index, List<(DayMenu DayMenu, int Index)> sections)
        {
            int count = 0;
            DateTime date = sections[index].DayMenu.date;

            for (int i = 0; i < sections.Count; i++)
            {
                if (sections[i].DayMenu.date == date)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }
        
        public static int getDayMenuIndex(Menu menu, DayMenu dm)
        {
            List<(DayMenu DayMenu, int Index)> sections = getSortedDayMenus(menu);
            for (int i = 0; i < sections.Count; i++)
            {
                if (sections[i].DayMenu.Id == dm.Id)
                {
                    return i;
                }
            }
            return -1;
        }
        public static string convertToWeekday(DateTime date)
        {
            string weekday = "";

            weekday = date.ToString("dddddd", new System.Globalization.CultureInfo("sv-SE"));
            weekday = char.ToUpper(weekday[0]) + weekday.Substring(1);

            return weekday;
        }
    }
}