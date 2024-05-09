Feature: Place bid
  user places bid on an ad

  Scenario: Place bid after logging in
    Given I am on the "/" page
    When I log in
    When I click on the bidding button
    And I can see "Bekräfta bud" heading
    And I click on bid-placing button
    Then a "Ditt bud har sparats" paragraph should be visible