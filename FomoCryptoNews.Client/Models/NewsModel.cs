﻿using Bogus;

namespace FomoCryptoNews.Client.Models;

public class NewsModel
{
    public int  Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Cover { get; set; }
    
    public Status Status { get; set; }
    
    public int CreatedAt { get; set; }
    
    //
    // public static List<NewsModel> FakerCollection()
    // {
    //     var faker = new Faker<NewsModel>("ru")
    //         .RuleFor(n => n.Id, f => Guid.NewGuid())
    //         .RuleFor(n => n.Title, f => f.Lorem.Sentence(5, 7))
    //         .RuleFor(n => n.Description, f => f.Lorem.Paragraphs(1, 3)) 
    //         .RuleFor(n => n.Cover, f => f.Image.PicsumUrl()) 
    //         .RuleFor(n => n.Status, f => f.PickRandom<Status>()) 
    //         .RuleFor(n => n.CreatedAt, f => f.Date.Between(DateTime.Now.AddMonths(-1), DateTime.Now));
    //
    //     var collection = faker.Generate(30);
    //     return collection;
    // }
}