using Project.ClothingMall.Models;
using Project.ClothingMall.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project.ClothingMall.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBLL.IUsersService _userService = new BLL.UsersService();
        public UsersController()
        {
            AutoMapper.Mapper.CreateMap<Users,UsersViewModel>();
        }
        //
        // GET: /Users/
        public ActionResult Index()
        {
            var usersList = _userService.GetEntities();
            return View(AutoMapper.Mapper.Map<List<Users>,List<UsersViewModel>> (usersList.ToList()));
        }
        ///-------------------////
        public ActionResult Create()
        {
            return View("Create", new UsersViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,UserPassword,Status")] UsersViewModel users)
        {
            if (ModelState.IsValid)//该方法会执行ModelState的IsValid方法
            {
                users.CreateTime = DateTime.Now;
                users.UpdateTime = DateTime.Now;
                _userService.AddEntity(AutoMapper.Mapper.DynamicMap<UsersViewModel, Users>(users));
                return RedirectToAction("Index");
            }

            return View(users);
        }
        public ActionResult Edit(int? id)//?表示这个值可以为空
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = _userService.LoadEntities(u => u.UserId == id).FirstOrDefault();
            if (users == null)
            {
                return HttpNotFound();
            }
            return View("Edit", AutoMapper.Mapper.Map<Users, UsersViewModel>(users));
        }
        [HttpPost]

        public ActionResult Edit([Bind(Include = "UserId,UserName,UserPassword,CreateTime,UpdateTime,Status")] Users users)
        {
            if (ModelState.IsValid)         //如果前台验证成功
            {
                _userService.EditEntity(users);
                return RedirectToAction("Index");
            }
            return View(users);
        }
        public ActionResult Details(int? id)//?表示这个值可以为空
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = _userService.LoadEntities(u => u.UserId == id).FirstOrDefault();
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapper.Mapper.Map<Users,UsersViewModel>(users));
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = _userService.LoadEntities(u => u.UserId == id).FirstOrDefault();
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapper.Mapper.Map<Users, UsersViewModel>(users));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DelteConfirmed(int id)
        {
            Users users = _userService.LoadEntities(u => u.UserId == id).FirstOrDefault();
            _userService.DeleteEntity(users);
            return RedirectToAction("Index");
        }
        ///-------------------////
	}
}