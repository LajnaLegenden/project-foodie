using Blazored.LocalStorage;
using Newtonsoft.Json.Linq;
using project_foodie.Model;

namespace project_foodie.Modules;

public static class LocalStorage
{
    private static Dish getDishFromDmById(int id, DayMenu dm)
    {
        foreach (var d in dm.dishes)
            if (d.Id == id)
                return d;
        return null;
    }

    public static async Task<List<Row>> LoadData(ILocalStorageService localStorage, Menu menu)
    {
        var data = new List<Row>();

        var localStorageData = await localStorage.GetItemAsync<string>("dishData");
        // Check if localstorage is empty
        if (localStorageData == null) return new List<Row>();
        var localStorageObj = JObject.Parse(localStorageData);
        foreach (var dm in menu.dayMenus)
        {
            var dayString = dm.date.ToString("yyyy-MM-dd") + "-" + dm.type + "-" + dm.Id;
            if (localStorageObj[dayString] != null)
                foreach (JProperty item in localStorageObj[dayString])
                {
                    var dishId = int.Parse(item.Name);
                    var count = (int)item.Value;
                    if (count == 0)
                        continue;

                    foreach (var r in data)
                        if (r.dm.date == dm.date)
                            r.dishCount.Append((count, dishId, dm));
                    data.Add(new Row
                        { dm = dm, dishCount = new (int Count, int dishId, DayMenu dm)[] { (count, dishId, dm) } });
                }
        }


        var data2 = new List<Row>();

        foreach (var r in data)
        {
            //loop over data2
            var found = false;
            foreach (var r2 in data2)
                if (r2.dm.date == r.dm.date)
                {
                    found = true;
                    r2.dishCount = r2.dishCount.Concat(r.dishCount).ToArray();
                }

            if (!found) data2.Add(r);
        }

        //calculate lunch and dinner price

        foreach (var r in data2)
        foreach (var item in r.dishCount)
            if (item.dm.type == OrderType.Lunch)
                r.LunchPrice += getDishFromDmById(item.dishId, item.dm).Price * item.Count;
            else
                r.DinnerPrice += getDishFromDmById(item.dishId, item.dm).Price * item.Count;

        return data2;
    }

    public class Row
    {
        public int DinnerPrice;
        public (int Count, int dishId, DayMenu dm)[] dishCount;
        public DayMenu dm;
        public int LunchPrice;
    }
}