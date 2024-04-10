# You are given an integer array deck. There is a deck of cards where every 
# card has a unique integer. The integer on the iᵗʰ card is deck[i]. 
# 
#  You can order the deck in any order you want. Initially, all the cards start 
# face down (unrevealed) in one deck. 
# 
#  You will do the following steps repeatedly until all cards are revealed: 
# 
#  
#  Take the top card of the deck, reveal it, and take it out of the deck. 
#  If there are still cards in the deck then put the next top card of the deck 
# at the bottom of the deck. 
#  If there are still unrevealed cards, go back to step 1. Otherwise, stop. 
#  
# 
#  Return an ordering of the deck that would reveal the cards in increasing 
# order. 
# 
#  Note that the first entry in the answer is considered to be the top of the 
# deck. 
# 
#  
#  Example 1: 
# 
#  
# Input: deck = [17,13,11,2,3,5,7]
# Output: [2,13,3,11,5,17,7]
# Explanation: 
# We get the deck in the order [17,13,11,2,3,5,7] (this order does not matter), 
# and reorder it.
# After reordering, the deck starts as [2,13,3,11,5,17,7], where 2 is the top 
# of the deck.
# We reveal 2, and move 13 to the bottom.  The deck is now [3,11,5,17,7,13].
# We reveal 3, and move 11 to the bottom.  The deck is now [5,17,7,13,11].
# We reveal 5, and move 17 to the bottom.  The deck is now [7,13,11,17].
# We reveal 7, and move 13 to the bottom.  The deck is now [11,17,13].
# We reveal 11, and move 17 to the bottom.  The deck is now [13,17].
# We reveal 13, and move 17 to the bottom.  The deck is now [17].
# We reveal 17.
# Since all the cards revealed are in increasing order, the answer is correct.
#  
# 
#  Example 2: 
# 
#  
# Input: deck = [1,1000]
# Output: [1,1000]
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= deck.length <= 1000 
#  1 <= deck[i] <= 10⁶ 
#  All the values of deck are unique. 
#  
# 
#  Related Topics Array Queue Sorting Simulation 👍 3186 👎 574

import unittest
from typing import List


class RevealCardsInIncreasingOrder_Test(unittest.TestCase):

    def test_revealCardsInIncreasingOrder(self):
        test_data = [
            ([17, 13, 11, 2, 3, 5, 7], [2, 13, 3, 11, 5, 17, 7]),
            ([1, 1000], [1, 1000]),
            ([1, 2, 3, 4], [1, 3, 2, 4])
        ]
        for nums, expected in test_data:
            with self.subTest(nums=nums, expected=expected):
                self.assertEqual(expected, Solution().deckRevealedIncreasing(nums))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def deckRevealedIncreasing(self, deck: List[int]) -> List[int]:
        if len(deck) <= 1:
            return deck
        deck.sort()
        result = [0] * len(deck)
        indicies = [i for i in range(len(deck))]
        for card in deck:
            idx = indicies.pop(0)
            result[idx] = card
            if indicies:
                indicies.append(indicies.pop(0))
        return result

# leetcode submit region end(Prohibit modification and deletion)
