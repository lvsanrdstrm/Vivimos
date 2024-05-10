Feature: Place bid
  user places bid on an ad

  Scenario: Place bid after logging in
    Given I am on the "/" page
    When I log in
    When I click on the "Lägg ett bud" button
    And I am redirected to the "bid" page
    And I click on the Lägg ditt bud button
    Then I should see "Ditt bud har sparats" 