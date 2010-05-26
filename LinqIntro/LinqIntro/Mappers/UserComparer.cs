using System;
using System.Collections.Generic;

namespace LinqIntro.Mappers
{
    public class UserComparer : IComparer<User>
    {
        public int Compare(User user1, User user2)
        {
            int result = user1.Age > user2.Age ? 1 : user1.Age < user2.Age ? -1 : 0;
            if (result == 0)
            {
                return String.Compare(user1.DisplayName, user2.DisplayName, true);
            }
            else
            {
                return result;
            }
        }
    }
}