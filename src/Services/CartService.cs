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
        if (localStorageContent == null) return 0;

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