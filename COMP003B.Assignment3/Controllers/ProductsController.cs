using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using COMP003B.Assignment3.Models;

namespace COMP003B.Assignment3.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> _products = new List<Product>();

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_products);
        }


        // GET: ProductController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
          //  add model state validation
          if (ModelState.IsValid)
            {
                // checks if product already exists
                if (!_products.Any(s => s.Id == product.Id))
                {
                    // adds product to the list
                    _products.Add(product);
                }

                // redirects to the index page
                return RedirectToAction(nameof(Index));
                
            }
          return View();
        }

        // GET: ProductController/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            // checks if id is null
            if (id == null)
            {
                return NotFound();
            }

            // finds the product with the id
            var product = _products.FirstOrDefault(p => p.Id == id);

            // checks if product is null again
            if (product == null)
            {
                return NotFound();
            }

            // returns product to view
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            // checks if id is the same as product id
            if (id != product.Id)
            {
                return NotFound();
            }

            // checks if model state is valid
            if (ModelState.IsValid)
            {
                // finds product in list
                var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);

                // checks if product exists
                if (existingProduct != null)
                {
                    // updates product details
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                }

                // redirects to index page
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            // checks if id is null
            if (id == null)
            {
                return NotFound();
            }

            // finds product with id
            var product = _products.FirstOrDefault(p => p.Id == id);

            // checks if product is null after finding in list
            if (product == null)
            {
                return NotFound();
            }

            // returns view of the product found from the list
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // looks for product with id
            var product = _products.FirstOrDefault(p => p.Id == id);

            // checks if product exists
            if (product != null)
            {
                // removes product from list
                _products.Remove(product);
            }

            // redirects to index page
            return RedirectToAction(nameof(Index));
        }
    }
}
