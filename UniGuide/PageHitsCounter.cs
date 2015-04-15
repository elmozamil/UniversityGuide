using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace UniGuide
{
    public class PageHitsCounter : Hub
    {
        static int _hitCount = 0;
        static int _registeredusers = 0;
        public void RecordHit()
        {
            _hitCount++;
            _registeredusers = _hitCount * _hitCount;
            Clients.All.OnRecordHit(_hitCount, _registeredusers);
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            _hitCount--;
            _registeredusers /= _hitCount;
            Clients.All.OnRecordHit(_hitCount, _registeredusers);
            return base.OnDisconnected(stopCalled);
        }
    }
}