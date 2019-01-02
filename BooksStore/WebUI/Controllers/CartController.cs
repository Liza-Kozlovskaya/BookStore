using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    //Контроллер корзины
    public class CartController : Controller
    {
        private IBookRepository repository;

        //обработка запроса POST Формы, когда пользователь нажимает на "оформить заказ"
        private IOrderProcessor orderProcessor; 

        public CartController(IBookRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int bookId, string returnUrl) //метод добавления в корзину
        {
            Book book = repository.Books
                .FirstOrDefault(b => b.BookId == bookId);

            if(book != null)
            {
                /*GetCart()*/cart.AddItem(book, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int bookId, string returnUrl) //метод удаления из корзины
        {
            Book book = repository.Books
                .FirstOrDefault(b => b.BookId == bookId);

            if (book != null)
            {
                /*GetCart()*/cart.RemoveLine(book);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //отображение на панеле
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        //оформление заказа с вводом контактных данных
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails) //проверка корзины
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, корзина пуста!"); //ошибка оформления покупки, если корзина пуста
            }

            if(ModelState.IsValid) //проверка наличия ошибок
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(new ShippingDetails());
            }
            
        }
    }
}