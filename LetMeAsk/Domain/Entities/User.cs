using System.Collections.Generic;

namespace Letmeask.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string SocialId { get; set; }

        private readonly List<Room> _Rooms = new();
        public IReadOnlyCollection<Room> Rooms => _Rooms;


        protected User()
        {
            _Rooms = new List<Room>();
        }

        public User(Guid id, string name, string photo, string email, string socialId)
        {
            Id = id;
            Name = name;
            Photo = photo;
            Email = email;
            SocialId = socialId;
        }

        public void UpdateUser(string name, string photo, string email, string socialId)
        {
            Name = name;
            Photo = photo;
            Email = email;
            SocialId = socialId;
        }

        public void ExisteUser(string email)
        {

        }
        public void SetNome(string nome) => Name = nome;
        public void SetPhoto(string photo) => Photo = photo;
        public void SetSocialId(string socialId) => SocialId = socialId;

        public void RemoverTodasAsSalas()
        {
            _Rooms.Clear();
        }

        public Room SearchRoom(string code)
        {
            return _Rooms.FirstOrDefault(room => room.Code == code);
        }

        public void RemoverSala(Room room)
        {
            var sala = SearchRoom(room.Code);

            if(sala is null) return;

            _Rooms.Remove(sala);
        }

    }
}