Feature: Individual
  View individual ad info.

  Scenario: View individual ad info
    Given I am on the "/" page
    When I click on an ad title
    Then I should be on an individual ad site