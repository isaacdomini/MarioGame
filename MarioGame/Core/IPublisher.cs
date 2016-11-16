using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Core
{
    public interface IPublisher
    {
        void Subscribe(String eventName, ISubscriber subscriber);
        void Announce(String eventName);
    }
}
