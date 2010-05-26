using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using LinqIntro.Mappers;
using System.Collections;

namespace LinqIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = LoadUsers();
            var badges = LoadBadges();

            var list1 = new[] { 1, 2, 3 };
            var list2 = new[] { 1, 2, 3 };

            
        }

        private static IEnumerable<User> LoadUsers()
        {
            var xdoc = XDocument.Load(@"..\..\..\Files\users.xml");
            var userMapper = new UserMapper();

            var users = userMapper.Map(xdoc.Descendants("row"));
            var userDictionary = new Dictionary<int, User>();
            foreach (User user in users)
            {
                userDictionary.Add(user.Id, user);
            }

            var badges = LoadBadges();
            foreach (Badge badge in badges)
            {
                if (userDictionary.ContainsKey(badge.UserId))
                {
                    var user = userDictionary[badge.UserId];
                    user.AddBadge(badge);
                }
            }
            return users;
        }
        private static IEnumerable<Badge> LoadBadges()
        {
            var xdoc = XDocument.Load(@"..\..\..\Files\badges.xml");
            var badgeMapper = new BadgeMapper();
            return badgeMapper.Map(xdoc.Descendants("row"));
        }
    }
}
