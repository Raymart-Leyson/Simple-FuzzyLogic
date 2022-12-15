using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzzy
{
    public class FuzzyLogic
    {
        public float[] Defuzzify(int temp)
        {
            float[] result = new float[4];
            float temperature = temp;
            // Define the triangular fuzzy sets for cold, warm, and hot
            float coldMin = 0;
            float coldMax = 50;
            float coldMid = 25;

            float warmMin = 50;
            float warmMax = 80;
            float warmMid = 65;

            float hotMin = 80;
            float hotMax = 100;
            float hotMid = 90;

            // Calculate the membership values for each fuzzy set using a set of if-else statements
            float coldMembership;
            if (temperature <= coldMin || temperature >= coldMax)
            {
                coldMembership = 0;
            }
            else if (temperature < coldMid)
            {
                coldMembership = (temperature - coldMin) / (coldMid - coldMin);
            }
            else
            {
                coldMembership = (coldMax - temperature) / (coldMax - coldMid);
            }

            float warmMembership;
            if (temperature <= warmMin || temperature >= warmMax)
            {
                warmMembership = 0;
            }
            else if (temperature < warmMid)
            {
                warmMembership = (temperature - warmMin) / (warmMid - warmMin);
            }
            else
            {
                warmMembership = (warmMax - temperature) / (warmMax - warmMid);
            }

            float hotMembership;
            if (temperature <= hotMin || temperature >= hotMax)
            {
                hotMembership = 0;
            }
            else if (temperature < hotMid)
            {
                hotMembership = (temperature - hotMin) / (hotMid - hotMin);
            }
            else
            {
                hotMembership = (hotMax - temperature) / (hotMax - hotMid);
            }

            // Perform defuzzification to convert the fuzzy output into a crisp, numerical value
            float crispOutput = (coldMembership * coldMin + warmMembership * warmMid + hotMembership * hotMax) / (coldMembership + warmMembership + hotMembership);

            result[0] = coldMembership;
            result[1] = warmMembership;
            result[2] = hotMembership;
            result[3] = crispOutput;

            return result;
        }
    }
}
