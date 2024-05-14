Feature: Login
  User gets logged-in

  Scenario:
    Given I am on the "/" page
    And I click on the "Logga in" button
    And a modal pops up
    And I type in my user credentials
    And I click on the "Login" button
    Then I should see the Min sida title