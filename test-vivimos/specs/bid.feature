Feature: Create bid

  Scenario: Place bid when logged in
    Given I am logged in
    And I can see an ad
    When I click on "Lägg ett bud"
    And I can see the "Bekräfta bud" page
    And I click on the "Lägg ditt bud" button
    Then a "Ditt bud har sparats" message should show