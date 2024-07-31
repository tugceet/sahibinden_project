namespace sahibinden_project;

public record class SaveListing
{
    public string Category { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public DateTime Date { get; set; }
    public string ImageFileName { get; set; }

    public SaveListing(string category, string title, string description, int price, DateTime date, string imageFileName)
    {
        Category = category;
        Title = title;
        Price = price;
        Description = description;
        Date = date;
        ImageFileName = imageFileName;
    }
}
