using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<AuctionDbContext>());
    }

    private static void SeedData(AuctionDbContext context)
    {
        context.Database.Migrate();

        if (context.Auctions.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        var auctions = new List<Auction>()
        {
            new Auction
            {
                Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Item = new Item
                {
                    Type = "Ford",
                    Model = "GT",
                    Color = "White",
                    Condition = "Good",
                    Year = 2020,
                    ImageUrl = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg"
                }
            },
            new Auction
            {
                Id = Guid.Parse("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
                Status = Status.Live,
                ReservePrice = 90000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(60),
                Item = new Item
                {
                    Type = "Ford",
                    Model = "GT",
                    Color = "White",
                    Condition = "Good",
                    Year = 2020,
                    ImageUrl = "https://cdn.pixabay.com/photo/2012/05/29/00/43/car-49278_960_720.jpg"
                }
            },
            new Auction
            {
                Id = Guid.Parse("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"),
                Status = Status.Live,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(4),
                Item = new Item
                {
                    Type = "Ford",
                    Model = "GT",
                    Color = "White",
                    Condition = "Good",
                    Year = 2020,
                    ImageUrl = "https://cdn.pixabay.com/photo/2012/11/02/13/02/car-63930_960_720.jpg"
                }
            },
            new Auction
            {
                Id = Guid.Parse("155225c1-4448-4066-9886-6786536e05ea"),
                Status = Status.ReserveNotMet,
                ReservePrice = 50000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(-10),
                Item = new Item
                {
                    Type = "Ford",
                    Model = "GT",
                    Color = "White",
                    Condition = "Good",
                    Year = 2020,
                    ImageUrl = "https://cdn.pixabay.com/photo/2016/04/17/22/10/mercedes-benz-1335674_960_720.png"
                }
            },
            // 5 BMW X1
            new Auction
            {
                Id = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(30),
                Item = new Item
                {
                    Type = "Ford",
                    Model = "GT",
                    Color = "White",
                    Condition = "Good",
                    Year = 2020,
                    ImageUrl = "https://cdn.pixabay.com/photo/2017/08/31/05/47/bmw-2699538_960_720.jpg"
                }
            },
            new Auction
            {
                Id = Guid.Parse("dc1e4071-d19d-459b-b848-b5c3cd3d151f"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(45),
                Item = new Item
                {
                    Type = "Ford",
                    Model = "GT",
                    Color = "White",
                    Condition = "Good",
                    Year = 2020,
                    ImageUrl = "https://cdn.pixabay.com/photo/2017/11/09/01/49/ferrari-458-spider-2932191_960_720.jpg"
                }
            },
            new Auction
            {
                Id = Guid.Parse("47111973-d176-4feb-848d-0ea22641c31a"),
                Status = Status.Live,
                ReservePrice = 150000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(13),
                Item = new Item
                {
                    Type = "Ford",
                    Model = "GT",
                    Color = "White",
                    Condition = "Good",
                    Year = 2020,
                    ImageUrl = "https://cdn.pixabay.com/photo/2017/11/08/14/39/ferrari-f430-2930661_960_720.jpg"
                }
            },  
        };

        context.AddRange(auctions);
        context.SaveChanges();
    }
}
