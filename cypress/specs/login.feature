Feature: Login
  User gets logged-in

  Scenario:
    Given I am on the "/" page
    And I click on the "Logga in" button
    And a login modal pops up
    And I type in my username and password
    And I click on the "Login" button
    Then I should see a "Min sida" title

