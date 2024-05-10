Feature: Navigation

  Scenario: See the home page
    Given I am on the "/" page
    When I click on "Hem" in the menu
    Then I should seen a "Aktuella aktioner:" title

  Scenario: See the test page
    Given I am on the "/" page
    When I click on "Test" in the menu
    Then I should see the "Test" page

  Scenario: See My page
    Given I am on the "/" page
    When I log in
    When I click on "Min sida" in the menu
    Then I should see the "Min sida" page