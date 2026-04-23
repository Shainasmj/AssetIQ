using AssetIQ.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AssetIQ.Models.ViewModels;
using AssetIQ.Models.Domain;
using AssetIQ.Helpers;

namespace AssetIQ.Controllers
{
    [AuthorizeUser]
    public class AssetController : Controller
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        public async Task<IActionResult> Index()
        {
            var assets = await _assetService.GetAllAsync();
            return View(assets);
        }

        [AuthorizeUser(Role = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AuthorizeUser(Role = "Admin")]
        public async Task<IActionResult> Create(AssetViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var asset = new Asset
            {
                Id = model.Id,
                Name = model.Name,
                Category = model.Category,
                PurchaseDate = model.PurchaseDate.Value,
                Price = model.Price.Value,
                IsAssigned = model.IsAssigned
            };

            await _assetService.CreateAsync(asset);

            return RedirectToAction("Index");
        }

        [AuthorizeUser(Role = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var asset = await _assetService.GetByIdAsync(id);

            if (asset == null)
            {
                return NotFound();
            }

            var model = new AssetViewModel
            {
                Id = asset.Id,
                Name = asset.Name,
                Category = asset.Category,
                PurchaseDate = asset.PurchaseDate,
                Price = asset.Price,
                IsAssigned = asset.IsAssigned
            };

            return View(model);
        }

        [HttpPost]
        [AuthorizeUser(Role = "Admin")]
        public async Task<IActionResult> Edit(AssetViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var asset = new Asset
            {
                Name = model.Name,
                Category = model.Category,
                PurchaseDate = model.PurchaseDate.Value,
                Price = model.Price.Value,
                IsAssigned = model.IsAssigned
            };

            await _assetService.UpdateAsync(asset);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [AuthorizeUser(Role = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _assetService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}