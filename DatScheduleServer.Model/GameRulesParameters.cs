using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatScheduleServer.Model
{
    public class GameRulesParameters
    {
        public static int ImpactOfSleepOnTiredness { get { return 60; }}
        public static int ImpactOfMealOnHunger { get { return 30; }}
        public static int ImpactOfLeisureOnStress { get { return 20; }}
    }
}
