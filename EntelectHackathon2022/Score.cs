using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntelectHackathon2022
{
    public class Score
    {
        //ToDo:
        //Quota multiplier
        //Resources added

        /*
            Score score = new Score();

            int allowance = 5;
            double travelScore = 0;
            bool scout = true;
            int[] difficulty = {0,1,5,5,10,1,1};
            double sum = 0;
            
            for(int i =0; i<6; i++)
            {
                Console.WriteLine(score.calcScore(difficulty[i],i,5, travelScore, scout, false).ToString());
                sum += score.calcScore(difficulty[i], i, 5, travelScore, scout, false);
            }
            Console.WriteLine((2*(200 + 400 + sum)).ToString()); // 2 fish, + 2 coal, + x2 multiplier
         */

        public double calcScore(int difficulty, int currentStep, int allowance, double travelScore, bool scout, bool quotoFulfilled)
        {
            if(currentStep == 0) //step 0 does not count, and would cause div0 error
                return 0;
            else if(scout == false)
            {
                //if party has no scout
                travelScore += 150 / difficulty / (Erf(currentStep - 1 / allowance) + 1);

                //if party exceeds step allowance
                if(currentStep > allowance)
                {
                    travelScore -= (150 / difficulty) * (Erf((currentStep - allowance) / allowance) + 1);
                }
            }
            else if (scout == true)
            {
                //else if party has scout
                travelScore += (2 * (150 / difficulty)) / (Erf(currentStep - 1 / allowance) + 1);
                //if party exceeds step allowance
                if (currentStep > allowance)
                {
                    travelScore -= 0.5 * (150 / difficulty) * (Erf((currentStep - allowance) / allowance) + 1);
                }
            }

            return travelScore; 
        }


        //Error Function Code, functions changed from static
        public double Erf(double x) //Changed From Static
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return sign * y;
        }

        public void TestErf() //Changed From Static
        {
            // Select a few input values
            double[] x =
                {
                    -3,
                    -1,
                    0.0,
                    0.5,
                    2.1
                };

            // Output computed by Mathematica
            // y = Erf[x]
            double[] y =
            {
                -0.999977909503,
                -0.842700792950,
                0.0,
                0.520499877813,
                0.997020533344
            };

            double maxError = 0.0;
            for (int i = 0; i < x.Length; ++i)
            {
                double error = Math.Abs(y[i] - Erf(x[i]));
                if (error > maxError)
                    maxError = error;
            }

            Console.WriteLine("Maximum error: {0}", maxError);
        }
    }
}
