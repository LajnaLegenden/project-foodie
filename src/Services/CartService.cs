using Blazored.LocalStorage;
using Newtonsoft.Json;

public class CartService
{
    private readonly ILocalStorageService _localStorage;

    public CartService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    private int cartCount;
    public event EventHandler CartCountChanged;

    public int GetCartCount()
    {
        return cartCount;
    }

    public void SetCartCount(int count)
    {
        cartCount = count;
    }

    public async void AddToCart()
    {
        cartCount = await GetObjectCount();
        CartCountChanged?.Invoke(this, EventArgs.Empty);
    }

    public async Task<int> GetObjectCount()
    {
        // Fetch the data from local storage
        var localStorageContent = await _localStorage.GetItemAsync<string>("dishData");
        // Check if the data is empty
        if (localStorageContent == null)
        {
            return 0;
        }
        else
        {
            // Deserialize the data
            var dictionary = JsonConvert.DeserializeObject<
                Dictionary<string, Dictionary<string, int>>
            >(localStorageContent);
            // Filter the data where count is greater than 0
            var filteredObjects = dictionary.Values.Where(
                obj => obj.Values.Any(count => count > 0)
            );
            // Count the data and return the count
            var itemsCount = filteredObjects.Count();
            return itemsCount;
        }
    }
}
