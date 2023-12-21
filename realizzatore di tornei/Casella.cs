using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace realizzatore_di_tornei
{
    public class Casella
    {
        Button b;


        int calcolaNumCaselleTotali(int numCaselle)
        {
            if(numCaselle > 1) { return numCaselle + calcolaNumCaselleTotali(numCaselle / 2); }; return 1;
        }
    }
}
