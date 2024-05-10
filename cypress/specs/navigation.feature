Feature: Navigation
  User navigates the site.

  Scenario: Navigate the site
    Given I am on the "/" page
    When I click on "Test"
    Then I should see "Hej detta är testsidan" as the title