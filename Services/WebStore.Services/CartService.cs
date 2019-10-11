using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.Filters;
using WebStore.DomainNew.ViewModel;
using WebStore.Infrastucture.Interfaces;
using WebStore.Interface.Services;
using WebStore.ViewModel;

namespace WebStore.Infrastucture.Implementations
{
    public class CartService : ICartService
    {

        private IProductService _productService { get; }

        private ICartStore _cartStore;

        public CartService(IProductService productService, ICartStore cartStore)
        {
            _productService = productService;
            _cartStore = cartStore;

        }

        public void AddToCart(int id)
        {
            var cart = _cartStore.Cart;

            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                cart.Items.Add(new CartItem() { ProductId = id, Quantity = 1 });
            }


            _cartStore.Cart = cart;
        }

        public void DecrementFromCart(int id)
        {
            var cart = _cartStore.Cart;

            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item !=null)
            {
                if (item.Quantity>0)
                    item.Quantity--;

                if (item.Quantity==0)
                    cart.Items.Remove(item);
            }
            _cartStore.Cart = cart;
        }


        public void RemoveAll()
        {
            _cartStore.Cart = new Cart { Items = new List<CartItem>() };
        }

        public void RemoveFromCart(int id)
        {
            var cart = _cartStore.Cart;

            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
                cart.Items.Remove(item);

            _cartStore.Cart = cart;
        }

        public CartViewModel TransformCart()
        {
            var product = _productService.GetProducts(new ProductFilter()
            {
                Ids = _cartStore.Cart.Items.Select(x => x.ProductId).ToList()
            }).Products.Select(p => new ProductViewModel()
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                BrandName = p.Brand != null ? p.Brand.Name : string.Empty
            }).ToList();

            var r = new CartViewModel()
            {
                Items = _cartStore.Cart.Items.ToDictionary(
                    x => product.First(y => y.Id == x.ProductId),
                    x => x.Quantity)
            };

            return r;

        }
    }
}
