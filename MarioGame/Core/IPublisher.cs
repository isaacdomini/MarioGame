using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Theming;

namespace MarioGame.Core
{
    public interface IPublisher
    {
        void Subscribe(EventTypes eventType, ISubscriber subscriber);
        void Announce(EventTypes eventType);
    }
}
