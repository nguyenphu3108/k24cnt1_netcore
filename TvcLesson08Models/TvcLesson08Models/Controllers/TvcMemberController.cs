using Microsoft.AspNetCore.Mvc;
using TvcLesson08Models.Models;

namespace TvcLesson08Models.Controllers
{
    public class TvcMemberController : Controller
    {
        private static List<TvcMember> _members = new List<TvcMember>()
        {
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "PhuTv",
                TvcPassword = "Password123!",
                TvcFullName = "Nguyễn Trọng Phú",
                TvcEmail = "nguyenphu@gmail.com"
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
            }
        };

        public IActionResult Index()
        {
            return View(_members);
        }

        [HttpGet]
        public IActionResult TvcCreate()
        {
            var member = new TvcMember();
            return View(member);
        }
        [HttpPost]
        public IActionResult TvcCreate(TvcMember tvcMember)
        {
            tvcMember.TvcMemberId = Guid.NewGuid().ToString();
            _members.Add(tvcMember);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult TvcEdit(string id)
        {
            var member = _members.Where(x => x.TvcMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public IActionResult TvcEdit(string id, TvcMember tvcMember)
        {
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].TvcMemberId == id)
                {
                    _members[i].TvcUserName = tvcMember.TvcUserName;
                    _members[i].TvcPassword = tvcMember.TvcPassword;
                    _members[i].TvcFullName = tvcMember.TvcFullName;
                    _members[i].TvcEmail = tvcMember.TvcEmail;

                    return RedirectToAction("Index");
                }

            }
            return View();
        }

        [HttpGet]
        public IActionResult TvcDetails(string id)
        {
            var member = _members.Where(x => x.TvcMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpGet]
        public IActionResult TvcDelete(string id)
        {
            var member = _members.Where(x => x.TvcMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public IActionResult TvcDeleted(string id)
        {
            foreach (var item in _members)
            {
                if (item.TvcMemberId.Equals(id))
                {
                    _members.Remove(item);
                    return RedirectToAction("Index");
                }
            }
            return View("TvcDelete");
        }
    }
}