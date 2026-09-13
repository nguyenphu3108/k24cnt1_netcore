using Microsoft.AspNetCore.Mvc;

using TvcLesson7.Models.DataModels;

namespace TvcLesson7.Models.Controllers
{
    public class TvcMemberController : Controller
    {
        protected static List<TvcMember> _members = new List<TvcMember>
        {
             new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "phutv",
                TvcPassword = "123456",
                TvcFullName = "Nguyễn Trọng Phú",
                TvcEmail = "phutv@example.com"
            },
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "nguyenbalinh",
                TvcPassword = "123456",
                TvcFullName = "Nguyễn Bá Linh",
                TvcEmail = "nguyenbalinh@example.com"
            },
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "doxuanthanh",
                TvcPassword = "123456",
                TvcFullName = "Đỗ Xuân Thành",
                TvcEmail = "doxuanthanh@example.com"
            },
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "maihoanganh",
                TvcPassword = "123456",
                TvcFullName = "Mai Hoàng Anh",
                TvcEmail = "maihoanganh@example.com"
            },
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "haquangtatdat",
                TvcPassword = "123456",
                TvcFullName = "Hà Quang Tất Đạt",
                TvcEmail = "haquangtatdat@example.com"
            }
        };

        public IActionResult Index()
        {
            return View(_members);
        }
        public IActionResult GetMember()
        {
            var member = new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "phutv",
                TvcPassword = "password123",
                TvcFullName = "Nguyễn Trọng Phú",
                TvcEmail = "phutv@example.com"
            };
         
            return View(member);
        }

        public IActionResult GetMembers()
        {
        
            ViewBag.Members = _members;
            return View();

        }

        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TvcMember member)
        {
            if (ModelState.IsValid)
            {
                member.TvcMemberId = Guid.NewGuid().ToString();
                _members.Add(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
    }
}