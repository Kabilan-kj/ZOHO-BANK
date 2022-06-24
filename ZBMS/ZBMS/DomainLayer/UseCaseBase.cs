using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBMS.DomainLayer
{
    public abstract class UseCaseBase
    {
        public abstract void Action();

        public void Execute()
        {
            Task.Run(() =>
                Action()
            );
        }
    }
}
