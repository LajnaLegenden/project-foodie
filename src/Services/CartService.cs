using Blazored.LocalStorage;
using Newtonsoft.Json;

// Cart service Class to handle the cart count
public class CartService
{
    private readonly ILocalStorageService _localStorage;

    // Cart count variable
    private int cartCount;

    public CartService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    // Event handler to notify the cart count change
    public event EventHandler CartCountChanged;

    // Get and Set the cart count
    public int GetCartCount()
    {
        return cartCount;
    }

    // Set the cart count
    public void SetCartCount(int count)
    {
        cartCount = count;
    }

    // Add to cart method
    public async void AddToCart()
    {
        cartCount = await GetObjectCount();
        CartCountChanged?.Invoke(this, EventArgs.Empty);
    }

    // Get the object count from local storage
    public async Task<int> GetObjectCount()
    {
        // Fetch the data from local storage
        var localStorageContent = await _localStorage.GetItemAsync<string>("dishData");
        // Check if the data is empty
        if (localStorageContent == null)
            return 0;

        // Deserialize the data
        var dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(
            localStorageContent
        );

        // Count the occurrences of each ID
        var idCounts = new Dictionary<string, int>();
        foreach (var obj in dictionary.Values)
        foreach (var id in obj.Keys)
        {
            var count = obj[id];
            if (count < 0)
                count = 0; // Set count to 0 if it's negative
            if (idCounts.ContainsKey(id))
                idCounts[id] += count;
            else
                idCounts[id] = count;
        }

        // Sum the counts and return the total
        var totalCount = idCounts.Values.Sum();
        return totalCount;
    }
}