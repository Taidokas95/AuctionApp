using System.Data;
using AuctionApp.Core;
using AuctionApp.Core.Interfaces;
using AuctionApp.Models;
using AuctionApp.Models.Auctions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers;
    [Authorize]
    public class AuctionController : Controller
    {

        private IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }
        // GET: AuctionController
        public ActionResult Index()
        {
            List<Auction> auctions = _auctionService.GetOngoingAuctions();
            List<AuctionVm> auctionsVms = new List<AuctionVm>();
            foreach (var auction in auctions)
            {
               auctionsVms.Add(AuctionVm.FromAuction(auction)); 
            }
            return View(auctionsVms);
        }
        
        public ActionResult MyAuctions() 
        {
            List<Auction> auctions = _auctionService.GetAuctionByUserId(User.Identity.Name);
            List<AuctionVm> auctionVms = new List<AuctionVm>();
            foreach(var auction in auctions)
            {
                auctionVms.Add(AuctionVm.FromAuction(auction));
            }
            return View(auctionVms);
        }

        // GET: AuctionController/Details/5
        public ActionResult Details(int id)
        {
            Auction auction = _auctionService.GetAuctionById(id);
            if (auction == null) return BadRequest(); // HTTP 400
            AuctionDetailsVm detailsVm = AuctionDetailsVm.FromAuction(auction);
            return View(detailsVm);
        }

        // GET: AuctionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAuctionVm createAuctionVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string userId = User.Identity.Name;
                    string name = createAuctionVm.name;
                    string description = createAuctionVm.description;
                    int price = createAuctionVm.price;
                    
                    _auctionService.AddAuction(userId, name, description, price);
                    return RedirectToAction("Index");
                }
                return View(createAuctionVm);
            }
            catch (DataException ex)
            {
                return View(createAuctionVm);
            }
        }

        // GET: AuctionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuctionController/Edit/5
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

        // GET: AuctionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuctionController/Delete/5
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

