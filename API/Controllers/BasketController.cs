using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class BasketController : MyBaseApiController
{
    private readonly StoreContext _context;
    public BasketController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetBasket")]
    public async Task<ActionResult<BasketDto>> GetBasket()
    {
        var buyerIdFromCookie = GetBuyerId();
        var basket = await RetrieveBasket(buyerIdFromCookie);
        if (basket == null) return NotFound();
        return MapToBasketDto(basket);
    }

    [HttpPost]
    public async Task<ActionResult<BasketDto>> AddItemToBasket(int productId, int quantity = 1)
    {
        var buyerIdFromCookie = GetBuyerId();
        var basket = await RetrieveBasket(buyerIdFromCookie);
        if (basket == null) basket = CreateBasket();
        var product = await _context.Products.FindAsync(productId);

        if (product == null) return BadRequest(new ProblemDetails { Title = "Product not found" });

        basket.AddItem(product, quantity);
        var result = await _context.SaveChangesAsync() > 0;

        if (result) return CreatedAtRoute("GetBasket", MapToBasketDto(basket));
        return BadRequest(new ProblemDetails { Title = "Problem saving item to basket" });
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveBasketItem(int productId, int quantity = 1)
    {
        var basket = await RetrieveBasket(GetBuyerId());
        if (basket == null) return NotFound();

        basket.RemoveItem(productId, quantity);
        var result = await _context.SaveChangesAsync() > 0;

        if (result) return Ok();

        return BadRequest(new ProblemDetails { Title = "Problem removing item from the basket" });
    }

    private async Task<Basket> RetrieveBasket(string buyerId)
    {
        return await _context.Baskets
            .Include(i => i.Items)
            .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync(basket => basket.BuyerId == buyerId);
    }

    private string GetBuyerId()
    {
        string cookie = Request.Cookies["buyerId"];
        cookie = "3bc1b36a-7aea-498a-b53b-03c907b0bc63";

        return cookie;
    }

    private Basket CreateBasket()
    {
        var buyerId = Guid.NewGuid().ToString();
        var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
        Response.Cookies.Append("buyerId", buyerId, cookieOptions);

        var basket = new Basket { BuyerId = buyerId };
        _context.Baskets.Add(basket);
        return basket;
    }
    private BasketDto MapToBasketDto(Basket basket)
    {
        return new BasketDto
        {
            Id = basket.Id,
            BuyerId = basket.BuyerId,
            Items = basket.Items.Select(x => new BasketItemDto
            {
                ProductId = x.ProductId,
                Name = x.Product.Name,
                Price = x.Product.Price,
                PictureUrl = x.Product.PictureUrl,
                Type = x.Product.Type,
                Brand = x.Product.Brand,
                Quantity = x.Quantity
            }).ToList()
        };
    }
}