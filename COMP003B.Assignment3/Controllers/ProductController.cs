using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using COMP003B.Assignment3.Models;

namespace COMP003B.Assignment3.Controllers
{
    public class ProductController : Controller
    {
        private static List<ProductController> _products = new List<ProductController>();

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_products);
        }


        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductController product)
        {
          // TODO: add model stae validation
          if (ModelState.IsValid)
            {

                if (!_products.Any(p => p.Id == product.Id))
                {
                    product.Add(product);
                }

                return RedirectToAction(nameof(Index));
                
            }
          return View();
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
