using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Games.BlackJack
{
    public static class BjRule
    {

        // Matrix Website : https://www.blackjackapprenticeship.com/wp-content/uploads/2018/08/BJA_Basic_Strategy.jpg


        public static char[,] splitMatrix =
        { 
          // ***************    DEALER CARD    *****************
          //  Ace  2    3    4    5    6    7    8    9    10  
            { 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S'},// A,A
            { 'N', 'D', 'D', 'S', 'S', 'S', 'S', 'N', 'N', 'N'},// 2,2
            { 'N', 'D', 'D', 'S', 'S', 'S', 'S', 'N', 'N', 'N'},// 3,3
            { 'N', 'N', 'N', 'N', 'D', 'D', 'N', 'N', 'N', 'N'},// 4,4
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'},// 5,5
            { 'N', 'D', 'S', 'S', 'S', 'S', 'N', 'N', 'N', 'N'},// 6,6
            { 'N', 'S', 'S', 'S', 'S', 'S', 'S', 'N', 'N', 'N'},// 7,7
            { 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S'},// 8,8
            { 'N', 'S', 'S', 'S', 'S', 'S', 'N', 'S', 'S', 'N'},// 9,9
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'},// 10,10
        };

        public static char[,] softMatrix =
        { 
          // ***************    DEALER CARD    *****************
          //  Ace  2    3    4    5    6    7    8    9    10  
            { 'H', 'H', 'H', 'H', 'D', 'D', 'H', 'H', 'H', 'H'},// A2
            { 'H', 'H', 'H', 'H', 'D', 'D', 'H', 'H', 'H', 'H'},// A3
            { 'H', 'H', 'H', 'D', 'D', 'D', 'H', 'H', 'H', 'H'},// A4
            { 'H', 'H', 'H', 'D', 'D', 'D', 'H', 'H', 'H', 'H'},// A5
            { 'H', 'H', 'D', 'D', 'D', 'D', 'H', 'H', 'H', 'H'},// A6
            { 'H', 'T', 'T', 'T', 'T', 'T', 'S', 'S', 'H', 'H'},// A7
            { 'S', 'S', 'S', 'S', 'S', 'T', 'S', 'S', 'S', 'S'},// A8
            { 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S'},// A9
        };

        public static char[,] hardMatrix =
        { 
          // ***************    DEALER CARD    *****************
          //  Ace  2    3    4    5    6    7    8    9    10  
            { 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H'},// 8
            { 'H', 'H', 'D', 'D', 'D', 'D', 'H', 'H', 'H', 'H'},// 9
            { 'H', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'H'},// 10
            { 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D'},// 11
            { 'H', 'H', 'H', 'S', 'S', 'S', 'H', 'H', 'H', 'H'},// 12
            { 'H', 'S', 'S', 'S', 'S', 'S', 'H', 'H', 'H', 'H'},// 13
            { 'H', 'S', 'S', 'S', 'S', 'S', 'H', 'H', 'H', 'H'},// 14
            { 'H', 'S', 'S', 'S', 'S', 'S', 'H', 'H', 'H', 'H'},// 15
            { 'H', 'S', 'S', 'S', 'S', 'S', 'H', 'H', 'H', 'H'},// 16
            { 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S'},// 17
        };
    }
}
