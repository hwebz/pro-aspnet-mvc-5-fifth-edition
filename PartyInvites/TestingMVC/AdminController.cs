using System;
using System.Collections.Generic;
using System.Text;

namespace TestingMVC
{
    public class AdminController
    {
        IUserRepository _repository;

        public AdminController(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool ChangeLoginName(string oldLoginName, string newLoginName)
        {
            User user = _repository.FetchByLoginName(oldLoginName);
            user.LoginName = newLoginName;
            _repository.SubmitChanges();

            return true;
        }
    }
}
