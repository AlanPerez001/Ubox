using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubox.ModelService.Ubox
{
    class GetLockers
    {
        public GetLockers(int idUbox)
        {
            IdUbox = idUbox;

        }

        public int IdUbox { get; set; }
        
    }
}
