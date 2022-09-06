using Flunt.Notifications;

namespace Konia.Delivery.App.Domain
{
    public class Entity : Notifiable<Notification>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}