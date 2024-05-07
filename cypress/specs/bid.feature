Feature: Place bid
  user places bid on an ad

  Scenario: Place bid after logging in
    Given I am logged in
    When I click on the bidding button
    And I get redirected to the "Bekräfta bud" site
    And I click on bid-placing button
    Then a "Ditt bud har sparats" alert should pop up