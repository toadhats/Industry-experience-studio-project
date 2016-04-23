using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geocoder
{
    class TokenBucket
    {
        // The rate limit we want to use
        private readonly short REQUESTS_PER_SEC = 10; // It would hypothetically change to 50 if someone spent $10k on a premium account, plus it makes this number a little less magic
        int tokens;

        int lastRefill;
        public TokenBucket()
        {
            tokens = REQUESTS_PER_SEC;
            lastRefill = Environment.TickCount;
        }

        // Returns true if there was a spare token
        public Boolean getToken()
        {
            int timeElapsed = Environment.TickCount - lastRefill;
            if (timeElapsed > 1000)
            {
                // Doing this the really simple way
                tokens = 10;
                lastRefill = Environment.TickCount;
                // Console.WriteLine("Refreshed the token bucket. ({0} seconds elapsed since last refill)", timeElapsed / 1000);
            }
            if (tokens > 0)
            {
                tokens -= 1;
                // Console.WriteLine("Giving a token, {0} are left.", tokens);
                return true;
            }
            else
            {
                Console.WriteLine("No tokens left soz, come back in {0}ms", 1000 - timeElapsed);
                return false;
            }

        }

        // Locks the thread until it gets a token. Easy way/worst way
        public void waitForToken()
        {
            while (!getToken())
            {
                // Console.WriteLine("No token for you");
                System.Threading.Thread.Sleep(100);
            }
            return;
        }

    }
}
