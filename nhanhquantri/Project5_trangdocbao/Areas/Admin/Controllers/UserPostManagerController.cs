using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EntityFramework;
using Project5_trangdocbao.Common;
using PagedList;

namespace Project5_trangdocbao.Areas.Admin.Controllers
{
    public class UserPostManagerController : BaseUserController
    {
        //
        // GET: /Admin/UserPostManager/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public ActionResult Create()
        {
            GetTypeForPost();
            return View();
        }




        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(BAIDANG bd)
        {
            if (ModelState.IsValid)
            {
                var DAO = new PostDao();
                bd.UrlRequire = RewriteURL.RewriteUrl(bd.TenBaiDang);
                bd.TrangThaiBaiDang = "chờ duyệt";

                int idtk = int.Parse(Session["USER_ID"].ToString());
                bd.IDTaiKhoan = idtk;
                bd.NgayDang = DateTime.Now;
                bd.IDBaiDang = 0;
                long idpost = DAO.CreatePost(bd);
            }
            return View("MyPost");
        }

        //lấy ra danh sách thể loại cho bài đăng
        public void GetTypeForPost(long? selectedid = null)
        {
            var dao = new TypeDao();
            ViewBag.IDTheLoai = new SelectList(dao.ListTypeForCreatePost(), "IDTheLoai", "TenTheLoai", selectedid);
        }

        //Lấy ra danh sách tất cả bài đăng
        public ActionResult MyPost(string searchString, int page = 1, int pageSize = 5)
        {
            var postdao = new PostDao();
            var userSession = new UserInfo();
            int idtk = int.Parse(Session["USER_ID"].ToString());
            var model = postdao.MyPost(searchString, page, pageSize, idtk);
            ViewBag.searchstring = searchString;
            return View(model);
        }


        //Xóa bài đăng
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new PostDao().Delete(id);
            return RedirectToAction("Index");
        }


    }
}
