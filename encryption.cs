using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Recorder
{
    class Encryptor
    {
        public Encryptor() 
        {

        }
        public Func<string> Encode(string password)
        {

            return ()=>password;
        }
    }

}
