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
        
        public ActionResult MyBids()
        {
            try
            {
                List<Auction> auctions = _auctionService.GetOngoingAuctionsByBidUserid(User.Identity.Name);
                List<AuctionVm> auctionsVms = new List<AuctionVm>();
                foreach (var auction in auctions)
                {
                    auctionsVms.Add(AuctionVm.FromAuction(auction)); 
                }
            
                return View(auctionsVms);
            }
            catch (Exception e)
            {
                return View(new List<AuctionVm>());
            }
           
        }

        // GET: AuctionController/Details/5
        public ActionResult Details(int id)
        {
            TempData["id"] = id;
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
                if (ModelState.IsValid)
                {
                    
                }
                return View(createAuctionVm);
            }
        }
        
        // GET: AuctionController/Create
        public ActionResult CreateBid()
        {
            return View();
        }

        // POST: AuctionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBid(CreateBidVm createBidVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int auctionId = -1;
                    string userId = User.Identity.Name;
                    int amount = createBidVm.amount;
                    if (TempData["id"] != null)
                    {
                        auctionId = Convert.ToInt32(TempData["id"]);
                    }
                    
                    _auctionService.AddBid(amount, userId, auctionId);
                    return RedirectToAction("Index");
                }
                return View(createBidVm);
            }
            catch (DataException ex)
            {
                if (ModelState.IsValid)
                {
                    
                }
                return View(createBidVm);
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

