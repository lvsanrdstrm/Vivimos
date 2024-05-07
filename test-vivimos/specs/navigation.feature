Feature: Navigation

  Scenario: See the home page
    Given I am on the vivimos page
    When I click on Hem
    Then I should see the list of ads

  Scenario: See the test page
    Given I am on the vivimos page
    When I click on Test
    Then I should see the Test page
