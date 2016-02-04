using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jiro;

namespace WindowsFormsApplication1 {
    class staff {
        public Noodle cooking(Gram g) {
            Noodle ret=new Noodle();
            ret.NoodleVolume=g;

            return ret;
        }
        public Topping toppingMake(string ClientCall) {
            Topping ret=new Topping(ClientCall);

            return ret;
        }
    }
}
