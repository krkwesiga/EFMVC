using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Models;
using PMS.ViewModels;

namespace PMS.Controllers
{
  public class CashRequisitionController : Controller
  {
    private PMSEntities db = new PMSEntities();

    //
    // GET: /CashRequisition/

    public ActionResult Index()
    {
      var pendingCashRequisitions = from pcr in db.CashRequisitions
                                    where (pcr.RequisitionStatus == "Pending")
                                    select pcr;

      return View(pendingCashRequisitions.ToList());
    }

    //
    // GET: /CashRequisition/Details/5

    public ActionResult Details(int id = 0)
    {
      CashRequisition cashrequisition = db.CashRequisitions.Find(id);
      if (cashrequisition == null)
      {
        return HttpNotFound();
      }
      return View(cashrequisition);
    }

    //
    // GET: /CashRequisition/Create

    public ActionResult Create()
    {
      var cashProject = new CashRequisitionActiveProjectsViewModel();
      cashProject.Projects = db.Projects.ToList();
      return View(cashProject);
    }

    //
    // POST: /CashRequisition/Create

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CashRequisitionActiveProjectsViewModel cashrequisition)
    {
      if (ModelState.IsValid)
      {
        db.CashRequisitions.Add(cashrequisition.CashRequisitions);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(cashrequisition);
    }

    //
    // GET: /CashRequisition/Edit/5

    public ActionResult Edit(int id = 0)
    {
      CashRequisition cashrequisition = db.CashRequisitions.Find(id);
      if (cashrequisition == null)
      {
        return HttpNotFound();
      }
      return View(cashrequisition);
    }

    //
    // POST: /CashRequisition/Edit/5

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(CashRequisition cashrequisition)
    {
      if (ModelState.IsValid)
      {
        db.Entry(cashrequisition).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(cashrequisition);
    }

    [ActionName("Approve")]
    public ActionResult Approve(int id)
    {
      CashRequisition cashreq = db.CashRequisitions.Find(id);
      if (cashreq == null)
      {
        return HttpNotFound();
      }

      cashreq.RequisitionStatus = "Approved";
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    //
    // GET: /CashRequisition/Delete/5

    public ActionResult Delete(int id = 0)
    {
      CashRequisition cashrequisition = db.CashRequisitions.Find(id);
      if (cashrequisition == null)
      {
        return HttpNotFound();
      }
      return View(cashrequisition);
    }

    //
    // POST: /CashRequisition/Delete/5

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      CashRequisition cashrequisition = db.CashRequisitions.Find(id);
      db.CashRequisitions.Remove(cashrequisition);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}