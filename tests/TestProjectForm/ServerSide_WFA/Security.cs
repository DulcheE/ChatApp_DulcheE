using Communication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static ServerSide.Database;

namespace ServerSide
{

    class Security
    {

        public static void TestUser(User user)
        {

            User db_user = UserService.getByUsername(user.Username);

            if (user.Password != db_user.Password)
                throw new ClientCredentialsInvalidException("The credentials of the User `" + user.Username + "` are invalid !");

            if (user.Cookie != 0 && user.Cookie != db_user.Cookie)
                throw new ClientCredentialsInvalidException("Another user connect with your credentials !");
        }


        public static void TestUser(User user1, User user2)
        {
            if (user1.Username != user2.Username)
                throw new SecurityException("The users are different !");

            TestUser(user1);
        }


        public static void TestTopic(Topic topic)
        {

            Topic db_topic = TopicService.getByTopic_name(topic.Topic_name, true);

            if (topic.Password != db_topic.Password)
                throw new InvalidCredentialsException("The credentials of the Topic `" + topic.Topic_name + "` are invalid !");
        }


        public static void TestOwner(User owner, Topic topic)
        {
            TestUser(owner);

            TestTopic(topic);


            if (owner.Username != topic.Owner.Username)
                throw new UserNotOwnerOfTopicException("The User `" + owner.Username + "` is not the owner of the Topic `" + topic.Topic_name + "` !");
        }

    }

}
