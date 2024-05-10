Feature: Create bid

  Scenario: Place bid when logged in
    Given I am on the "/" page
    When I log in
    When I click on the "Lägg ett bud" button
    And I should see the "Bekräfta bud" page
    And I click on the "Lägg ditt bud" button
    Then a "Ditt bud har sparats" message should show

