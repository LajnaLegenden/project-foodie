using project_foodie.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace project_foodie.Modules
{
    public static class LocalStorage
    {
        public class Row
        {
            public DayMenu dm;
            public (int Count, int dishId, DayMenu dm)[] dishCount;
            public int LunchPrice;
            public int DinnerPrice;
        }

        private static Dish getDishFromDmById(int id, DayMenu dm)
        {
            foreach (Dish d in dm.dishes)
            {
                if (d.Id == id)
                    return d;
            }
            return null;
        }

        public async static Task<List<Row>> LoadData(Blazored.LocalStorage.ILocalStorageService localStorage, Menu menu) {
            List<Row> data = new List<Row>();

            var localStorageData = await localStorage.GetItemAsync<string>("dishData");
            // Check if localstorage is empty
            if (localStorageData == null) {
                return null;
            }
            var localStorageObj = JObject.Parse(localStorageData);
            foreach (DayMenu dm in menu.dayMenus)
            {
                string dayString = dm.date.ToString("yyyy-MM-dd") + "-" + dm.type + "-" + dm.Id;
                if (localStorageObj[dayString] != null)
                {
                    foreach (JProperty item in localStorageObj[dayString])
                    {
                        int dishId = Int32.Parse(item.Name);
                        int count = (int)item.Value;
                        if (count == 0)
                            continue;

                        foreach (Row r in data)
                        {
                            if (r.dm.date == dm.date)
                            {
                                r.dishCount.Append((count, dishId, dm));
                            }
                        }
                        data.Add(new Row { dm = dm, dishCount = new (int Count, int dishId, DayMenu dm)[] { (count, dishId, dm) } });

                    }

                }
            }


            List<Row> data2 = new List<Row>();

            foreach (Row r in data)
            {
                //loop over data2
                bool found = false;
                foreach (Row r2 in data2)
                {
                    if (r2.dm.date == r.dm.date)
                    {
                        found = true;
                        r2.dishCount = r2.dishCount.Concat(r.dishCount).ToArray();
                    }
                }
                if (!found)
                {
                    data2.Add(r);
                }
            }

            //calculate lunch and dinner price

            foreach (Row r in data2)
            {
                foreach (var item in r.dishCount)
                {
                    if (item.dm.type == OrderType.Lunch)
                    {
                        r.LunchPrice += getDishFromDmById(item.dishId, item.dm).Price * item.Count;
                    }
                    else
                    {
                        r.DinnerPrice += getDishFromDmById(item.dishId, item.dm).Price * item.Count;
                    }
                }
            }

            return data2;
        }
    }
}